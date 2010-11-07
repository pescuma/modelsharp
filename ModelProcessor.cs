//
// Copyright 2010 Ricardo Pescuma Domenecci
// 
// This file is part of Model#.
// 
// Model# is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
// 
// Model# is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along with Model#. If not, see <http://www.gnu.org/licenses/>.
// 

using System;
using System.IO;
using System.Xml.Serialization;
using Antlr3.ST;
using NArrange.Core;
using org.pescuma.ModelSharp.model;

namespace org.pescuma.ModelSharp
{
	internal class ModelProcessor
	{
		private readonly Logger _log = new Logger();

		private readonly FileInfo _filename;
		private readonly string _templatesPath;
		private readonly bool _overrideFiles;
		private readonly StringTemplateGroup _templates;

		public ModelProcessor(string templatesPath, string filename, bool overrideFiles)
		{
			_templatesPath = templatesPath;
			_overrideFiles = overrideFiles;
			_filename = new FileInfo(filename);
			_templates = new StringTemplateGroup("templates", templatesPath);
		}

		public bool Process()
		{
			_log.Info("Processing " + _filename + " ...");

			string outDir = _filename.Directory.FullName;

			var model = GetModel();
			foreach (var type in model.Types)
			{
				if (type.Immutable)
				{
					CreateFileIfNotExits(type, "immutable_class_extended", outDir, type.Name);
					CreateFile(type, "immutable_class", outDir, type.ImplementationName);
					CreateFile(type, "builder_class", outDir, type.Name + "Builder");
				}
				else
				{
					CreateFileIfNotExits(type, "mutable_class_extended", outDir, type.Name);
					CreateFile(type, "mutable_class", outDir, type.ImplementationName);
				}
			}
			_log.Info("... Done");
			_log.Info("");

			return !_log.HasError;
		}

		private xml.model ReadXml()
		{
			TextReader textReader = null;
			try
			{
				XmlSerializer deserializer = new XmlSerializer(typeof (xml.model));
				textReader = new StreamReader(_filename.FullName);
				return (xml.model) deserializer.Deserialize(textReader);
			}
			finally
			{
				if (textReader != null)
					textReader.Close();
			}
		}

		private void PosProcessXml(xml.model model)
		{
			foreach (var modelItem in model.Items)
			{
				if (modelItem is xml.type)
				{
					var type = (xml.type) modelItem;
					if (!type.immutableSpecified)
						type.immutable = false;

					foreach (var item in type.Items)
					{
						if (item is xml.property)
						{
							var property = (xml.property) item;

							property.name = StringUtils.FirstUpper(property.name);

							if (!property.requiredSpecified)
								property.required = true;
						}
						else if (item is xml.component)
						{
							var component = (xml.component) item;

							component.name = StringUtils.FirstUpper(component.name);

							if (!component.lazySpecified)
								component.lazy = false;

							if (!component.requiredSpecified)
								component.required = true;
						}
						else if (item is xml.collection)
						{
							var collection = (xml.collection) item;

							collection.name = StringUtils.FirstUpper(collection.name);

							if (!collection.lazySpecified)
								collection.lazy = false;
						}
					}
				}
				else if (modelItem is xml.@using)
				{
					xml.@using us = modelItem as xml.@using;
					us.@namespace = us.@namespace.Trim();
				}
			}
		}

		private ModelInfo GetModel()
		{
			var xmlModel = ReadXml();
			PosProcessXml(xmlModel);

			var model = CreateModel(xmlModel);
			ProcessModel(model);

			return model;
		}

		private ModelInfo CreateModel(xml.model model)
		{
			ModelInfo ret = new ModelInfo();

			foreach (var modelItem in model.Items)
			{
				if (modelItem is xml.type)
				{
					xml.type type = (xml.type) modelItem;

					TypeInfo ti = new TypeInfo(type.name, model.@namespace, type.immutable);

					foreach (var item in type.Items)
					{
						if (item is xml.property)
						{
							var property = (xml.property) item;

							PropertyInfo prop = new PropertyInfo(property.name, property.type, property.required, false);

							if (!string.IsNullOrEmpty(property.@default))
								prop.DefaultValue = property.@default;

							ti.Properties.Add(prop);
						}
						else if (item is xml.component)
						{
							var component = (xml.component) item;

							ComponentInfo comp = new ComponentInfo(component.name, component.type, component.required,
							                                       component.lazy);
							ti.Properties.Add(comp);
						}
						else if (item is xml.collection)
						{
							var collection = (xml.collection) item;

							CollectionInfo prop = new CollectionInfo(collection.name, collection.contents,
							                                         collection.lazy);
							ti.Properties.Add(prop);
						}
					}

					ret.AddType(ti);
				}
				else if (modelItem is xml.@using)
				{
					xml.@using us = modelItem as xml.@using;
					ret.Using.Add(us.@namespace);
				}
			}

			return ret;
		}

		private void ProcessModel(ModelInfo model)
		{
			CopyUsingsToType(model);
			AddCollectionUsings(model);
			MakeChangesForImmutable(model);
			ComputePropertyOrder(model);
			AddNotifcationInformation(model);
			AddDataContracts(model);
			AddDebugAttributes(model);
		}

		private void CopyUsingsToType(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				foreach (var ns in model.Using)
				{
					type.Using.Add(ns);
				}
			}
		}

		private void AddCollectionUsings(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				if (type.HasCollections)
					type.Using.Add("System.Collections.ObjectModel");
			}
		}

		private void MakeChangesForImmutable(ModelInfo model)
		{
			// Convert all properties to fields
			foreach (var type in model.Types)
			{
				if (!type.Immutable)
					continue;

				foreach (var prop in type.Properties)
				{
					prop.FieldName = prop.Name;
					prop.Getter = null;
					prop.Setter = null;
					prop.LazyInitializer = null;

					if (prop is CollectionInfo)
					{
						string contents = ((CollectionInfo) prop).Contents;

						prop.TypeName = "ReadOnlyCollection<" + contents + ">";
						prop.DefaultValue = "";

						type.Using.Add("System.Collections.Generic");
					}
					else if (prop is ComponentInfo)
					{
						prop.DefaultValue = "";
					}
				}
			}
		}

		private void ComputePropertyOrder(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				for (int i = 0; i < type.Properties.Count; i++)
				{
					var prop = type.Properties[i];
					prop.Order = i;
				}
			}
		}

		private void AddNotifcationInformation(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				if (type.Immutable)
					continue;

				type.Using.Add("System");
				type.Using.Add("System.ComponentModel");

				type.Implements.Add("INotifyPropertyChanging");
				type.Implements.Add("INotifyPropertyChanged");
			}
		}

		private void AddDataContracts(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				type.Using.Add("System.Runtime.Serialization");
				type.Annotations.Add("DataContract");
				foreach (var prop in type.Properties)
				{
					prop.FieldAnnotations.Add(
						string.Format("DataMember(Name = \"{0}\", Order = {1}, IsRequired = {2})", prop.Name,
						              prop.Order, prop.Required ? "true" : "false"));
				}
			}
		}

		private void AddDebugAttributes(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				type.Using.Add("System.Diagnostics");
				foreach (var prop in type.Properties)
				{
					prop.FieldAnnotations.Add("DebuggerBrowsable(DebuggerBrowsableState.Never)");
					prop.PropGetAnnotations.Add("DebuggerStepThrough");
					prop.PropSetAnnotations.Add("DebuggerStepThrough");
				}
			}
		}

		private void CreateFileIfNotExits(TypeInfo type, string templateName, string outDir,
		                                  string className)
		{
			var fullname = Path.Combine(outDir, type.Package.Replace('.', '\\'), className + ".cs");
			if (new FileInfo(fullname).Exists)
			{
				if (!_overrideFiles)
				{
					_log.Info("Skiped (because already exists) file " + fullname);
					return;
				}
				else
				{
					_log.Info("Overriding file " + fullname);
				}
			}

			CreateFile(type, templateName, outDir, className);
		}

		private void CreateFile(TypeInfo type, string templateName, string outDir, string className)
		{
			var template = _templates.GetInstanceOf(templateName);
			template.SetAttribute("it", type);
			template.SetAttribute("class", className);

			var path = Path.Combine(outDir, type.Package.Replace('.', '\\'));
			Directory.CreateDirectory(path);
			var fullname = Path.Combine(path, className + ".cs");

			WriteFile(template, fullname);
			FormatFile(fullname);

			_log.Info("Created file " + fullname);
		}

		private void FormatFile(string filename)
		{
			FileArranger fileArranger = new FileArranger(Path.Combine(_templatesPath, "SimpleConfig.xml"),
			                                             null);
			if (!fileArranger.Arrange(filename, null))
				_log.Error("Could not format file: " + filename + ". The file has wrong code :(");
		}

		private void WriteFile(StringTemplate template, string filename)
		{
			TextWriter tw = new StreamWriter(filename);
			template.Write(new NoIndentWriter(tw));
			tw.Close();
		}
	}

	public class Logger
	{
		public bool HasError;

		public void Info(string msg)
		{
			Console.WriteLine(msg);
		}

		public void Error(string msg)
		{
			Console.WriteLine(" [ERR] " + msg);
			HasError = true;
		}
	}
}