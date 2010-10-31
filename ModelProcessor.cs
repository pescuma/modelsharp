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
using org.pescuma.ModelSharp.Model;

namespace org.pescuma.ModelSharp
{
	internal class ModelProcessor
	{
		private readonly FileInfo _filename;
		private readonly string _templatesPath;
		private StringTemplateGroup _templates;

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

			foreach (var type in GetTypes())
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

		private List<TypeInfo> GetTypes()
		{
			List<TypeInfo> ret = new List<TypeInfo>();

			xml.model model = ReadXml();

			foreach (var type in model.type)
			{
				TypeInfo ti = new TypeInfo(type.name, model.package, type.immutable);

				foreach (var property in type.property)
				{
					property.name = StringUtils.FirstUpper(property.name);

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

				ret.Add(ti);
			}

			return ret;
		}

		private void CreateFileIfNotExits(TypeInfo type, string templateName, string outDir, string className)
		{
			var fullname = Path.Combine(outDir, type.Package.Replace('.', '\\'), className + ".cs");
			if (new FileInfo(fullname).Exists)
			{
				Console.WriteLine("Skiped (because already exists) file " + fullname);
				return;
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