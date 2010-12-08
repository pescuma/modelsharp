//
// Copyright (c) 2010 Ricardo Pescuma Domenecci
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using Antlr3.ST;
using NArrange.Core;
using org.pescuma.ModelSharp.Core.model;
using org.pescuma.ModelSharp.Core.xml;

namespace org.pescuma.ModelSharp.Core
{
	public class ModelProcessor
	{
		private LoggerWrapper log;

		private readonly FileInfo filename;
		private readonly string templatesPath;
		private readonly bool overrideFiles;
		private readonly StringTemplateGroup templates;

		public string ProjectNamespace { get; set; }
		public string BaseOutputPath { get; set; }

		public ILogger Logger { get; set; }

		public ModelProcessor(string templatesPath, string filename, bool overrideFiles)
		{
			this.templatesPath = templatesPath;
			this.overrideFiles = overrideFiles;
			this.filename = new FileInfo(filename);
			BaseOutputPath = this.filename.Directory.FullName;

			templates = new StringTemplateGroup("templates", templatesPath);
			ProjectNamespace = "";
		}

		public ModelProcessorResult Process()
		{
			ModelProcessorResult result = new ModelProcessorResult();
			result.Success = true;

			log = new LoggerWrapper(Logger, result);

			log.Info("Processing " + filename + " ...");

			var model = GetModel();

			foreach (var type in model.Types)
			{
				if (type.Immutable)
				{
					AddIfNotNull(result.EditableFilenames,
					             CreateFileIfNotExits(type, "immutable_class_extended", type.Name));
					result.NotToChangeFilenames.Add(CreateFile(type, "immutable_class", type.ImplementationName));
					result.NotToChangeFilenames.Add(CreateFile(type, "builder_class", type.Name + "Builder"));
				}
				else
				{
					AddIfNotNull(result.EditableFilenames,
					             CreateFileIfNotExits(type, "mutable_class_extended", type.Name));
					result.NotToChangeFilenames.Add(CreateFile(type, "mutable_class", type.ImplementationName));
				}
			}
			log.Info("... Done");
			log.Info("");

			log = null;

			return result;
		}

		private void AddIfNotNull(List<string> list, string value)
		{
			if (value != null)
				list.Add(value);
		}

		private xml.model ReadXml()
		{
			TextReader textReader = null;
			try
			{
				XmlSerializer deserializer = new XmlSerializer(typeof (xml.model));
				textReader = new StreamReader(filename.FullName);
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
			if (model.@namespace == null)
				model.@namespace = model.projectNamespace ?? ProjectNamespace;
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
								property.required = false;
						}
						else if (item is component)
						{
							var component = (component) item;

							component.name = StringUtils.FirstUpper(component.name);

							if (!component.lazySpecified)
								component.lazy = false;
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

							ComponentInfo comp = new ComponentInfo(component.name, component.type, component.lazy);
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
			AddClonable(model);
		}

		private void AddClonable(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				type.Using.Add("System");

				type.Implements.Add("ICloneable");
			}
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
				if (type.HasCollections && !type.Immutable)
				{
					type.Using.Add("org.pescuma.ModelSharp.Lib");

					if (type.HasCollectionWithListenContentType)
						type.Using.Add("System.Collections.Specialized");
				}
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

						type.Using.Add("System.Collections.ObjectModel");
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
				type.Using.Add("org.pescuma.ModelSharp.Lib");

				type.Implements.Add("INotifyPropertyChanging");
				type.Implements.Add("INotifyChildPropertyChanging");
				type.Implements.Add("INotifyPropertyChanged");
				type.Implements.Add("INotifyChildPropertyChanged");
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
				if (type.Immutable)
					continue;

				type.Using.Add("System.Diagnostics");

				foreach (var prop in type.Properties)
				{
					prop.FieldAnnotations.Add("DebuggerBrowsable(DebuggerBrowsableState.Never)");
					prop.PropGetAnnotations.Add("DebuggerStepThrough");
					prop.PropSetAnnotations.Add("DebuggerStepThrough");
				}
			}
		}

		private string GetPackageDir(TypeInfo type)
		{
			var pkg = type.Package;

			if (string.IsNullOrEmpty(pkg) || pkg == ProjectNamespace)
				return "";

			if (!string.IsNullOrEmpty(ProjectNamespace) && pkg.StartsWith(ProjectNamespace + '.'))
				pkg = pkg.Substring(ProjectNamespace.Length + 1);

			return pkg.Replace('.', '\\');
		}

		private string CreateFileIfNotExits(TypeInfo type, string templateName, string className)
		{
			var relativeName = Path.Combine(GetPackageDir(type), className + ".cs");
			var fullname = Path.Combine(BaseOutputPath, relativeName);
			if (new FileInfo(fullname).Exists)
			{
				if (!overrideFiles)
				{
					log.Info("Skipped (because already exists) file " + relativeName);
					return null;
				}
				else
				{
					log.Info("Overriding file " + relativeName);
				}
			}

			return CreateFile(type, templateName, className);
		}

		private string CreateFile(TypeInfo type, string templateName, string className)
		{
			var template = templates.GetInstanceOf(templateName);
			template.SetAttribute("it", type);
			template.SetAttribute("class", className);

			var relativeName = Path.Combine(GetPackageDir(type), className + ".cs");
			var fullname = Path.Combine(BaseOutputPath, relativeName);

			Directory.CreateDirectory(Path.Combine(BaseOutputPath, GetPackageDir(type)));

			WriteFile(template, fullname);
			FormatFileWithNArranger(fullname);
			FormatFileWithAStyle(fullname);

			log.Info("Created file " + relativeName);

			return relativeName;
		}

		private void FormatFileWithNArranger(string file)
		{
			WaitForUnlock(file);

			FileArranger fileArranger = new FileArranger(Path.Combine(templatesPath, "SimpleConfig.xml"),
			                                             new NArrangeLogger(log));
			if (!fileArranger.Arrange(file, null))
				log.Error("Could not format file: " + file + ". The file has wrong code :(");
		}

		private void FormatFileWithAStyle(string file)
		{
			WaitForUnlock(file);

			AStyleInterface astyle = new AStyleInterface(new AStyleLogger(log));

			var options = File.ReadAllLines(Path.Combine(templatesPath, "astylerc"));

			string result = astyle.FormatSource(File.ReadAllText(file),
			                                    "mode=cs " + string.Join(" ", options));

			if (result == null)
			{
				log.Error("Could not format file: " + file + ". The file has wrong code :(");
			}
			else
			{
				result = result.Replace("\r\n", "\n").Replace('\r', '\n').Replace("\n", "\r\n");

				try
				{
					File.WriteAllText(file, result);
				}
				catch (IOException e)
				{
					log.Info("[AStyle] [Warn] Could not format file: " + file + ". Error writting file to disc: "
					         + e.Message);
				}
			}
		}

		private void WaitForUnlock(string file)
		{
			Thread.Sleep(10);
		}

		private void WriteFile(StringTemplate template, string file)
		{
			using (TextWriter tw = new StreamWriter(file))
			{
				template.Write(new NoIndentWriter(tw));
				tw.Close();
			}
		}
	}

	public class AStyleLogger : AStyleInterface.ILog
	{
		private readonly ILogger log;

		public AStyleLogger(ILogger log)
		{
			this.log = log;
		}

		public void Error(int errorNumber, string errorMessage)
		{
			log.Error("[AStyle] " + errorNumber + ": " + (errorMessage ?? ""));
		}

		public void Warning(int errorNumber, string errorMessage)
		{
			log.Info("[AStyle] " + errorNumber + ": " + (errorMessage ?? ""));
		}
	}

	public class NArrangeLogger : NArrange.Core.ILogger
	{
		private readonly ILogger log;

		public NArrangeLogger(ILogger log)
		{
			this.log = log;
		}

		public void LogMessage(LogLevel level, string message, params object[] args)
		{
			message = string.Format(message, args);

			switch (level)
			{
				case LogLevel.Error:
				{
					log.Error("[NArrange] " + message);
					break;
				}
				case LogLevel.Warning:
				{
					log.Info("[NArrange] [WARN] " + message);
					break;
				}
				case LogLevel.Info:
				{
					log.Info("[NArrange] " + message);
					break;
				}
			}
		}
	}

	public interface ILogger
	{
		void Info(string msg, int line = 0, int column = 0);

		void Error(string msg, int line = 0, int column = 0);
	}

	internal class LoggerWrapper : ILogger
	{
		private readonly ILogger log;
		private readonly ModelProcessorResult result;

		public LoggerWrapper(ILogger log, ModelProcessorResult result)
		{
			this.log = log;
			this.result = result;
		}

		public void Info(string msg, int line = 0, int column = 0)
		{
			result.Messages.Add(new ModelProcessorResult.Message(false, msg, line, column));

			if (log != null)
				log.Info(msg, line, column);
		}

		public void Error(string msg, int line = 0, int column = 0)
		{
			result.Success = false;
			result.Messages.Add(new ModelProcessorResult.Message(true, msg, line, column));

			if (log != null)
				log.Error(msg, line, column);
		}
	}
}
