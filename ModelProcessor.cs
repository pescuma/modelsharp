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
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Antlr3.ST;
using NArrange.Core;
using org.pescuma.ModelSharp.model;

namespace org.pescuma.ModelSharp
{
	internal class ModelProcessor
	{
		private readonly FileInfo _filename;
		private readonly string _templatesPath;
		private readonly StringTemplateGroup _templates;

		public ModelProcessor(string templatesPath, string filename)
		{
			_templatesPath = templatesPath;
			_filename = new FileInfo(filename);
			_templates = new StringTemplateGroup("templates", templatesPath);
		}

		public void Process()
		{
			Console.WriteLine("Processing " + _filename + " ...");

			string outDir = _filename.Directory.FullName;

			var model = GetModel();
			foreach (var type in model.Types)
			{
				if (type.Immutable)
				{
					CreateFileIfNotExits(model.Using, type, "immutable_class_extended", outDir, type.Name);
					CreateFile(model.Using, type, "immutable_class", outDir, type.ImplementationName);
					CreateFile(model.Using, type, "builder_class", outDir, type.Name + "Builder");
				}
				else
				{
					CreateFileIfNotExits(model.Using, type, "mutable_class_extended", outDir, type.Name);
					CreateFile(model.Using, type, "mutable_class", outDir, type.ImplementationName);
				}
			}
			Console.WriteLine("... Done");
			Console.WriteLine("");
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

		private void ReprocessXml(xml.model model)
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
						}
						else if (item is xml.component)
						{
							var component = (xml.component) item;

							component.name = StringUtils.FirstUpper(component.name);

							if (!component.lazySpecified)
								component.lazy = false;
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
			ReprocessXml(xmlModel);

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

							if (ti.Immutable)
							{
								FieldInfo fi = new FieldInfo(property.name, property.type, true, true);

								if (!string.IsNullOrEmpty(property.@default))
									fi.DefaultValue = property.@default;

								ti.Fields.Add(fi);
							}
							else
							{
								PropertyInfo prop = new PropertyInfo(property.name, property.type, false, false);

								if (!string.IsNullOrEmpty(property.@default))
									prop.Field.DefaultValue = property.@default;

								ti.Properties.Add(prop);
							}
						}
						else if (item is xml.component)
						{
							var component = (xml.component) item;

							if (ti.Immutable)
							{
								FieldInfo fi = new FieldInfo(component.name, component.type, true, true);
								fi.DefaultValue = "new " + fi.TypeName + "()";
								ti.Fields.Add(fi);
							}
							else
							{
								ComponentInfo comp = new ComponentInfo(component.name, component.type, component.lazy);
								ti.Properties.Add(comp);
							}
						}
						else if (item is xml.collection)
						{
							var collection = (xml.collection) item;

							if (ti.Immutable)
							{
								FieldInfo fi = new FieldInfo(collection.name, "List<" + collection.contents + ">", true, true);
								ti.Fields.Add(fi);
							}
							else
							{
								CollectionInfo prop = new CollectionInfo(collection.name, collection.contents, collection.lazy);
								ti.Properties.Add(prop);
							}
						}
					}

					ret.AddType(ti);
				}
				else if (modelItem is xml.@using)
				{
					xml.@using us = modelItem as xml.@using;
					ret.AddUsing(us.@namespace);
				}
			}

			return ret;
		}

		private void ProcessModel(ModelInfo model)
		{
			// Add needed using namespaces
			foreach (var type in model.Types)
			{
				if (type.Properties.Count > 0)
				{
					model.AddUsing("System");
					model.AddUsing("System.ComponentModel");
				}

				if (type.HasCollections)
					model.AddUsing("System.Collections.ObjectModel");
			}
		}

		private void CreateFileIfNotExits(List<string> @using, TypeInfo type, string templateName, string outDir, string className)
		{
			var fullname = Path.Combine(outDir, type.Package.Replace('.', '\\'), className + ".cs");
			if (new FileInfo(fullname).Exists)
			{
				Console.WriteLine("Skiped (because already exists) file " + fullname);
				return;
			}

			CreateFile(@using, type, templateName, outDir, className);
		}

		private void CreateFile(List<string> @using, TypeInfo type, string templateName, string outDir, string className)
		{
			var template = _templates.GetInstanceOf(templateName);
			template.SetAttribute("using", @using);
			template.SetAttribute("it", type);
			template.SetAttribute("class", className);

			var path = Path.Combine(outDir, type.Package.Replace('.', '\\'));
			Directory.CreateDirectory(path);
			var fullname = Path.Combine(path, className + ".cs");

			WriteFile(template, fullname);
			FormatFile(fullname);

			Console.WriteLine("Created file " + fullname);
		}

		private void FormatFile(string filename)
		{
			FileArranger fileArranger = new FileArranger(Path.Combine(_templatesPath, "SimpleConfig.xml"), null);
			if (!fileArranger.Arrange(filename, null))
				throw new InvalidDataException();
		}

		private void WriteFile(StringTemplate template, string filename)
		{
			TextWriter tw = new StreamWriter(filename);
			template.Write(new NoIndentWriter(tw));
			tw.Close();
		}
	}
}