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
using org.pescuma.ModelSharp.Core.model;
using org.pescuma.ModelSharp.Core.xml;

namespace org.pescuma.ModelSharp.Core
{
	public class ModelProcessor
	{
		private readonly Logger _log = new Logger();

		private readonly FileInfo _filename;
		private readonly string _templatesPath;
		private readonly bool _overrideFiles;
		private readonly StringTemplateGroup _templates;

		public string ProjectNamespace { get; set; }

		public ModelProcessor(string templatesPath, string filename, bool overrideFiles)
		{
			_templatesPath = templatesPath;
			_overrideFiles = overrideFiles;
			_filename = new FileInfo(filename);
			_templates = new StringTemplateGroup("templates", templatesPath);
			ProjectNamespace = "";
		}

		public bool Process()
		{
			_log.Info("Processing " + _filename + " ...");

			var model = GetModel();

			string outDir = _filename.Directory.FullName;

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
			if (model.projectNamespace == null)
				model.projectNamespace = "";

			foreach (var modelItem in model.Items)
			{
				if (modelItem is type)
				{
					var type = (type) modelItem;
					if (!type.immutableSpecified)
						type.immutable = false;

					foreach (var item in type.Items)
					{
						if (item is property)
						{
							var property = (property) item;

							property.name = StringUtils.FirstUpper(property.name);

							if (!property.requiredSpecified)
								property.required = true;
						}
						else if (item is component)
						{
							var component = (component) item;

							component.name = StringUtils.FirstUpper(component.name);

							if (!component.lazySpecified)
								component.lazy = false;

							if (!component.requiredSpecified)
								component.required = true;
						}
						else if (item is collection)
						{
							var collection = (collection) item;

							collection.name = StringUtils.FirstUpper(collection.name);

							if (!collection.lazySpecified)
								collection.lazy = false;
						}
					}
				}
				else if (modelItem is @using)
				{
					@using us = modelItem as @using;
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

			if (model.projectNamespace != "")
				ProjectNamespace = model.projectNamespace;

			foreach (var modelItem in model.Items)
			{
				if (modelItem is type)
				{
					type type = (type) modelItem;

					TypeInfo ti = new TypeInfo(type.name, model.@namespace, type.immutable);

					if (!string.IsNullOrEmpty(type.implements))
					{
						var impls = type.implements.Split(',');
						foreach (var impl in impls)
						{
							var tmp = impl.Trim();
							if (!string.IsNullOrEmpty(tmp))
								ti.Implements.Add(tmp);
						}
					}

					foreach (var item in type.Items)
					{
						if (item is property)
						{
							var property = (property) item;

							PropertyInfo prop = new PropertyInfo(property.name, property.type, property.required, false);

							if (!string.IsNullOrEmpty(property.@default))
								prop.DefaultValue = property.@default;

							if (!string.IsNullOrEmpty(property.getter) && ValidateVisibility(property.getter, "getter"))
								prop.GetterVisibility = property.getter;
							if (!string.IsNullOrEmpty(property.setter) && ValidateVisibility(property.setter, "setter"))
								prop.SetterVisibility = property.setter;

							ti.Properties.Add(prop);
						}
						else if (item is component)
						{
							var component = (component) item;

							ComponentInfo comp = new ComponentInfo(component.name, component.type, component.required,
							                                       component.lazy);
							ti.Properties.Add(comp);
						}
						else if (item is collection)
						{
							var collection = (collection) item;

							CollectionInfo prop = new CollectionInfo(collection.name, collection.contents,
							                                         collection.lazy);
							ti.Properties.Add(prop);
						}
					}

					ret.AddType(ti);
				}
				else if (modelItem is @using)
				{
					@using us = modelItem as @using;
					ret.Using.Add(us.@namespace);
				}
			}

			return ret;
		}

		private bool ValidateVisibility(string visibility, string name)
		{
			if (visibility != "public" && visibility != "protected" && visibility != "private")
				throw new ArgumentException(name + " can be one of: public protected private");

			return true;
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

		private string GetPackageDir(string outDir, TypeInfo type)
		{
			var pkg = type.Package;

			if (pkg == "" || pkg == ProjectNamespace)
				return outDir;

			if (ProjectNamespace != "" && pkg.StartsWith(ProjectNamespace + '.'))
				pkg = pkg.Substring(ProjectNamespace.Length + 1);

			return Path.Combine(outDir, pkg.Replace('.', '\\'));
		}

		private void CreateFileIfNotExits(TypeInfo type, string templateName, string outDir,
		                                  string className)
		{
			var fullname = Path.Combine(GetPackageDir(outDir, type), className + ".cs");
			if (new FileInfo(fullname).Exists)
			{
				if (!_overrideFiles)
				{
					_log.Info("Skipped (because already exists) file " + fullname);
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

			var path = GetPackageDir(outDir, type);
			Directory.CreateDirectory(path);
			var fullname = Path.Combine(path, className + ".cs");

			WriteFile(template, fullname);
			FormatFile(fullname);

			_log.Info("Created file " + fullname);
		}

		private void FormatFile(string filename)
		{
			FileArranger fileArranger = new FileArranger(Path.Combine(_templatesPath, "SimpleConfig.xml"),
			                                             new NArrangeLogger());
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

	public class NArrangeLogger : ILogger
	{
		public void LogMessage(LogLevel level, string message, params object[] args)
		{
			message = string.Format(message, args);

			switch (level)
			{
				case LogLevel.Error:
				{
					Console.WriteLine("[NArrange] [ERR] " + message);
					break;
				}
				case LogLevel.Warning:
				{
					Console.WriteLine("[NArrange] [WARN] " + message);
					break;
				}
				case LogLevel.Info:
				{
					Console.WriteLine("[NArrange] [INFO] " + message);
					break;
				}
			}
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