// 
//  Copyright (c) 2010 Ricardo Pescuma Domenecci
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
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

		public readonly GlobalConfiguration GlobalConfig = new GlobalConfiguration();
		public string BaseOutputPath { get; set; }

		public ILogger Logger { get; set; }

		public ModelProcessor(string templatesPath, string filename, bool overrideFiles)
		{
			this.templatesPath = templatesPath;
			this.overrideFiles = overrideFiles;
			this.filename = new FileInfo(filename);
			BaseOutputPath = this.filename.Directory.FullName;
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
					             CreateFileIfNotExits(type, "ImmutableClassExtended", type.Name, false));
					result.NotToChangeFilenames.Add(CreateFile(type, "ImmutableClass", type.ImplementationName,
					                                           true));
					result.NotToChangeFilenames.Add(CreateFile(type, "BuilderClass", type.Name + "Builder", true));
				}
				else
				{
					AddIfNotNull(result.EditableFilenames,
					             CreateFileIfNotExits(type, "MutableClassExtended", type.Name, false));
					result.NotToChangeFilenames.Add(CreateFile(type, "MutableClass", type.ImplementationName, true));
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
			model.@namespace =
				(model.@namespace ?? model.projectNamespace ?? GlobalConfig.ProjectNamespace ?? "").Trim();

			foreach (var modelItem in model.Items)
			{
				if (modelItem is type)
				{
					var type = (type) modelItem;

					if (!type.immutableSpecified)
						type.immutable = false;

					if (!type.cloneableSpecified)
						type.cloneable = true;

					if (!type.serializableSpecified)
						type.serializable = true;

					if (!type.equalsSpecified)
						type.equals = false;

					if (type.Items == null)
						type.Items = new object[0];

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

							if (!collection.readOnlySpecified)
								collection.readOnly = false;

							if (!collection.lazySpecified)
								collection.lazy = false;
						}
						else if (item is computedproperty)
						{
							var computed = (computedproperty) item;

							computed.name = StringUtils.FirstUpper(computed.name);

							if (computed.dependsOn == null)
								computed.dependsOn = "";

							if (computed.formula == null)
								computed.formula = "";

							if (!computed.cachedSpecified)
								computed.cached = false;
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
			PosProcessModel(model);

			return model;
		}

		private ModelInfo CreateModel(xml.model model)
		{
			NamingConventions conventions = new NamingConventions();

			ModelInfo result = new ModelInfo();

			if (!string.IsNullOrWhiteSpace(model.projectNamespace))
				GlobalConfig.ProjectNamespace = model.projectNamespace;

			foreach (var modelItem in model.Items)
			{
				if (modelItem is config)
				{
					var config = (config) modelItem;
					if (config.serialization != null && !string.IsNullOrWhiteSpace(config.serialization.@namespace))
						GlobalConfig.SerializationNamespace = config.serialization.@namespace.Trim();
				}
				else if (modelItem is type)
				{
					var type = (type) modelItem;

					var ti = new TypeInfo(type.name, model.@namespace, type.immutable, type.cloneable,
					                      type.serializable, type.equals);

					if (type.deepCopySpecified)
						ti.DeepCopy = type.deepCopy;

					if (!string.IsNullOrWhiteSpace(type.doc))
						ti.Documentation = type.doc;

					if (!string.IsNullOrWhiteSpace(type.implements))
					{
						var impls = type.implements.Split(',');
						foreach (var impl in impls)
						{
							var tmp = impl.Trim();
							if (!string.IsNullOrWhiteSpace(tmp))
								ti.Implements.Add(tmp);
						}
					}

					if (type.extends != null && type.extends.Trim() != "")
						ti.Extends = type.extends.Trim();

					if (type.baseClass != null)
					{
						var bc = type.baseClass;

						if (bc.hasChildPropertyChangedSpecified)
							ti.BaseClass.HasChildPropertyChanged = bc.hasChildPropertyChanged;
						if (bc.hasPropertyChangedSpecified)
							ti.BaseClass.HasPropertyChanged = bc.hasPropertyChanged;
						if (bc.hasChildPropertyChangingSpecified)
							ti.BaseClass.HasChildPropertyChanging = bc.hasChildPropertyChanging;
						if (bc.hasPropertyChangingSpecified)
							ti.BaseClass.HasPropertyChanging = bc.hasPropertyChanging;
						if (bc.hasCopyFromSpecified)
							ti.BaseClass.HasCopyFrom = bc.hasCopyFrom;
						if (bc.hasPropertiesSpecified)
							ti.BaseClass.HasProperties = bc.hasProperties;
					}

					foreach (var item in type.Items)
					{
						if (item is property)
						{
							var property = (property) item;

							var prop = new PropertyInfo(conventions, ti, property.name, property.type, property.required,
							                            false);

							if (property.deepCopySpecified)
								prop.DeepCopy = property.deepCopy;

							if (!string.IsNullOrWhiteSpace(property.doc))
								prop.Documentation = property.doc;

							if (!string.IsNullOrWhiteSpace(property.@default))
								prop.DefaultValue = property.@default;

							if (!string.IsNullOrWhiteSpace(property.getter)
							    && ValidateVisibility(property.getter, "getter"))
								prop.GetterVisibility = property.getter;
							if (!string.IsNullOrWhiteSpace(property.setter)
							    && ValidateVisibility(property.setter, "setter"))
								prop.SetterVisibility = property.setter;

							if (property.receiveInConstructorSpecified && property.receiveInConstructor)
								prop.ReceiveInConstructor = property.receiveInConstructor;

							if (property.precisionSpecified)
								prop.Precision = (double) property.precision;

							if (prop.Required && !prop.IsPrimitive)
								prop.Validations.Add(new ValidationInfo("value == null",
								                                        property.requiredException
								                                        ?? "new ArgumentNullException(property)",
								                                        "#pragma warning disable 472\n// ReSharper disable ConditionIsAlwaysTrueOrFalse",
								                                        "// ReSharper restore ConditionIsAlwaysTrueOrFalse\n#pragma warning restore 472"));

							prop.AddValidationAttrib(property.validationAttrib, property.validationException);
							prop.AddValidation(property.validation1, property.validationException);

							if (property.validation != null)
							{
								foreach (var validation in property.validation)
								{
									prop.AddValidationAttrib(validation.attrib, validation.exception);
									prop.AddValidation(validation.test, validation.exception);
								}
							}

							ti.Properties.Add(prop);
						}
						else if (item is component)
						{
							var component = (component) item;

							var comp = new ComponentInfo(conventions, ti, component.name, component.type, component.lazy);

							if (!string.IsNullOrWhiteSpace(component.doc))
								comp.Documentation = component.doc;

							if (!string.IsNullOrWhiteSpace(component.@default))
								comp.DefaultValue = component.@default;

							if (component.receiveInConstructorSpecified && component.receiveInConstructor)
								comp.ReceiveInConstructor = component.receiveInConstructor;

							comp.AddValidationAttrib(component.validationAttrib, component.validationException);
							comp.AddValidation(component.validation1, component.validationException);

							if (component.validation != null)
							{
								foreach (var validation in component.validation)
								{
									comp.AddValidationAttrib(validation.attrib, validation.exception);
									comp.AddValidation(validation.test, validation.exception);
								}
							}

							ti.Properties.Add(comp);
						}
						else if (item is collection)
						{
							var collection = (collection) item;

							var col = new CollectionInfo(conventions, ti, collection.name, collection.type,
							                             collection.lazy, collection.readOnly);

							if (collection.deepCopySpecified)
								col.DeepCopy = collection.deepCopy;

							if (!string.IsNullOrWhiteSpace(collection.doc))
								col.Documentation = collection.doc;

							if (!string.IsNullOrWhiteSpace(collection.@default))
								col.DefaultValue = collection.@default;

							ti.Properties.Add(col);
						}
						else if (item is computedproperty)
						{
							var computed = (computedproperty) item;

							var deps = (from d in computed.dependsOn.Split(',')
							            where d.Trim() != ""
							            select StringUtils.FirstUpper(d.Trim()));

							var prop = new ComputedPropertyInfo(conventions, ti, computed.name, computed.type,
							                                    computed.cached, deps, computed.formula);

							if (!string.IsNullOrWhiteSpace(computed.getter)
							    && ValidateVisibility(computed.getter, "getter"))
								prop.GetterVisibility = computed.getter;

							if (!string.IsNullOrWhiteSpace(computed.doc))
								prop.Documentation = computed.doc;

							ti.Properties.Add(prop);
						}
						else if (item is @using)
						{
							var us = item as @using;
							ti.Using.Add(us.@namespace);
						}
					}

					result.AddType(ti);
				}
				else if (modelItem is @using)
				{
					var us = modelItem as @using;
					result.Using.Add(us.@namespace);
				}
			}

			return result;
		}

		private bool ValidateVisibility(string visibility, string name)
		{
			if (visibility != "public" && visibility != "protected" && visibility != "private"
			    && visibility != "internal")
				throw new ArgumentException(name + " can be one of: public protected private internal");

			return true;
		}

		private void PosProcessModel(ModelInfo model)
		{
			ComputeDependentProperties(model);
			CopyUsingsToType(model);
			AddCollectionUsings(model);
			MakeChangesForImmutable(model);
			UpdateExtendsProperties(model);
			ComputeTypeInfoForProperties(model);
			ComputePropertyOrder(model);
			AddNotifcationInformation(model);
			AddDataContracts(model);
			AddDebugAttributes(model);
			AddClonable(model);
			AddCopyable(model);
//			CheckIfCanCloneAllNeededFields(model);
			AddUsingsForKnownTypes(model);
		}

		private void AddUsingsForKnownTypes(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				AddUsingsFromKnownTypes(type, type.Extends);

				foreach (var prop in type.Properties)
					AddUsingsFromKnownTypes(type, prop.TypeName);
			}
		}

		private void AddUsingsFromKnownTypes(TypeInfo type, string text)
		{
			if (text == null)
				return;

			if (text.StartsWith("List<") || text.StartsWith("HashSet<") || text.StartsWith("Dictionary<"))
				type.Using.Add("System.Collections.Generic");

			else if (text.StartsWith("List") || text.StartsWith("HashSet") || text.StartsWith("Dictionary"))
				type.Using.Add("System.Collections");
		}

//		private void CheckIfCanCloneAllNeededFields(ModelInfo model)
//		{
//			foreach (var type in model.Types)
//			{
//				if (!type.Cloneable)
//					continue;
//
//				foreach (var prop in type.Properties)
//				{
//					if (!prop.DeepCopy)
//						continue;
//
//					if (!prop.HasCopyConstructor && prop.CreateExternalCopyMethod("a") == null)
//						log.Error("Can't deep copy field " + type.Name + "." + prop.Name);
//				}
//			}
//		}

		private void UpdateExtendsProperties(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				if (!HasParent(model, type))
					continue;

				type.BaseClass.IsGenerated = true;
				type.BaseClass.HasChildPropertyChanged = true;
				type.BaseClass.HasChildPropertyChanging = true;
				type.BaseClass.HasPropertyChanged = true;
				type.BaseClass.HasPropertyChanging = true;
				type.BaseClass.HasCopyFrom = true;
				type.BaseClass.HasProperties = true;
			}
		}

		private bool HasParent(ModelInfo model, TypeInfo type, Func<TypeInfo, bool> filter = null)
		{
			// the max value is just to avoid an infinite loop
			for (int i = 0; i < 10000; i++)
			{
				if (type.Extends == null)
					return false;

				var baseType = model.GetType(type.Extends);
				if (baseType == null)
					return false;

				if (filter == null || filter(baseType))
					return true;

				type = baseType;
			}

			throw new InvalidOperationException("Type hierarchy is too deep. Didn't you made a recursion?");
		}

		private void ComputeTypeInfoForProperties(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				foreach (var prop in type.Properties)
				{
					prop.TypeInfo = model.GetType(prop.TypeName);

					if (prop is CollectionInfo)
					{
						var col = (CollectionInfo) prop;
						col.ContentsType.TypeInfo = model.GetType(col.ContentsType.TypeName);
					}
				}
			}
		}

		private void ComputeDependentProperties(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				foreach (var prop in type.Properties)
				{
					var computed = prop as ComputedPropertyInfo;
					if (computed == null)
						continue;

					foreach (var fullPath in computed.DependsOn)
					{
						var dep = fullPath.Split('.').First();

						var other = (from p in type.Properties
						             where p.Name == dep
						             select p).FirstOrDefault();

						if (other == null)
						{
							log.Error("Could not find property referenced on dependsOn: " + fullPath);
							continue;
						}

						var path = string.Join(".", fullPath.Split('.').Skip(1).ToArray());

						other.AddDependentProperty(computed, path);
					}
				}
			}
		}

		private void AddClonable(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				if (!type.Cloneable)
					continue;

				type.Using.Add("System");

				type.Implements.Add("ICloneable");
			}
		}

		private void AddCopyable(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				if (type.Immutable || !type.Cloneable)
					continue;

				type.Implements.Add("ICopyable");
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
					prop.MakeImmutable();
			}
		}

		private void ComputePropertyOrder(ModelInfo model)
		{
			foreach (var type in model.Types)
			{
				int index = 0;

				foreach (var prop in type.Properties)
				{
					if (prop is ComputedPropertyInfo)
						continue;

					prop.Order = index++;
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
				if (!type.Serializable)
					continue;

				type.Using.Add("System.Runtime.Serialization");

				if (!string.IsNullOrWhiteSpace(GlobalConfig.SerializationNamespace))
				{
					type.TypeOnlyAnnotations.Add(string.Format(
						"DataContract(Name = \"{0}\", Namespace = \"{1}\")", type.Name,
						GlobalConfig.SerializationNamespace));
					type.BaseOnlyAnnotations.Add(string.Format("DataContract(Namespace = \"{0}\")",
					                                           GlobalConfig.SerializationNamespace));
				}
				else
				{
					type.TypeOnlyAnnotations.Add(string.Format("DataContract(Name = \"{0}\")", type.Name));
					type.BaseOnlyAnnotations.Add("DataContract");
				}

				foreach (var prop in type.Properties)
				{
					if (prop is ComputedPropertyInfo)
						continue;

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

				type.BaseOnlyAnnotations.Add(CreateDebugDisplay(type));

				foreach (var prop in type.Properties)
				{
					if (prop is ComputedPropertyInfo)
					{
						var computed = (ComputedPropertyInfo) prop;

						computed.FieldAnnotations.Add("DebuggerBrowsable(DebuggerBrowsableState.Never)");
						computed.InvalidFieldAnnotations.Add("DebuggerBrowsable(DebuggerBrowsableState.Never)");
					}
					else if (!type.Immutable)
					{
						prop.FieldAnnotations.Add("DebuggerBrowsable(DebuggerBrowsableState.Never)");
					}

					prop.PropGetAnnotations.Add("DebuggerStepThrough");
					prop.PropSetAnnotations.Add("DebuggerStepThrough");

					if (prop.Getter != null)
						prop.Getter.Annotations.Add("DebuggerStepThrough");

					if (prop.Setter != null)
						prop.Setter.Annotations.Add("DebuggerStepThrough");

					if (prop.LazyInitializer != null)
						prop.LazyInitializer.Annotations.Add("DebuggerStepThrough");
				}
			}
		}

		private string CreateDebugDisplay(TypeInfo type)
		{
			StringBuilder dd = new StringBuilder();

			dd.Append("DebuggerDisplay(\"").Append(type.Name).Append("[");

			int count = 0;
			foreach (var prop in type.NonComputedProperties)
			{
				if (prop.IsComponent || prop.IsComputed)
					continue;

				if (count > 0)
					dd.Append(" ");

				dd.Append(prop.Name).Append("=");

				if (prop.IsCollection)
					dd.Append("{").Append(prop.Name).Append(".Count}items");
				else
					dd.Append("{").Append(prop.Name).Append("}");

				count++;
			}

			dd.Append("]\")");

			return dd.ToString();
		}

		private string GetPackageDir(TypeInfo type)
		{
			var pkg = type.Package;

			if (string.IsNullOrWhiteSpace(pkg) || pkg == GlobalConfig.ProjectNamespace)
				return "";

			if (!string.IsNullOrWhiteSpace(GlobalConfig.ProjectNamespace)
			    && pkg.StartsWith(GlobalConfig.ProjectNamespace + '.'))
				pkg = pkg.Substring(GlobalConfig.ProjectNamespace.Length + 1);

			return pkg.Replace('.', '\\');
		}

		private string CreateFileIfNotExits(TypeInfo type, string templateName, string className,
		                                    bool markAsGenerated)
		{
			var relativeName = Path.Combine(GetPackageDir(type), className + ".cs");
			var fullname = Path.Combine(BaseOutputPath, relativeName);
			if (new FileInfo(fullname).Exists)
			{
				if (!overrideFiles && !IsMarkedToOverride(fullname))
				{
					log.Info("Skipped (because already exists and was edited) file " + relativeName);
					return null;
				}

				log.Info("Overriding file " + relativeName);
			}

			return CreateFile(type, templateName, className, markAsGenerated);
		}

		public static bool IsMarkedToOverride(string fullName)
		{
			using (var file = new StreamReader(fullName))
			{
				var line = file.ReadLine();
				if (line == null)
					return false;

				line = line.Trim();
				return line == "// Automatically generated by Model#";
			}
		}

		private string CreateFile(TypeInfo type, string templateName, string className,
		                          bool markAsGenerated)
		{
			var relativeName = Path.Combine(GetPackageDir(type),
			                                className + (markAsGenerated ? ".generated" : "") + ".cs");
			var fullname = Path.Combine(BaseOutputPath, relativeName);

			Directory.CreateDirectory(Path.Combine(BaseOutputPath, GetPackageDir(type)));

			TemplateWrapper template = new TemplateWrapper(templateName);
			template.StartSession();
			template.SetAttribute("it", type);
			template.SetAttribute("class", className);

			File.WriteAllText(fullname, template.Render());
//			FormatFileWithNArranger(fullname);
			FormatFileWithAStyle(fullname);

			log.Info("Created file " + relativeName);

			return relativeName;
		}

//		private void FormatFileWithNArranger(string file)
//		{
//			WaitForUnlock(file);
//
//			FileArranger fileArranger = new FileArranger(Path.Combine(templatesPath, "SimpleConfig.xml"),
//			                                             new NArrangeLogger(log));
//			if (!fileArranger.Arrange(file, null))
//				log.Error("Could not format file: " + file + ". The file has wrong code :(");
//		}

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
					log.Info("[AStyle] [Warn] Could not format file: " + file + ". Error writing file to disc: "
					         + e.Message);
				}
			}
		}

// ReSharper disable UnusedParameter.Local
		private void WaitForUnlock(string file) // ReSharper restore UnusedParameter.Local
		{
			Thread.Sleep(10);
		}

//		private void WriteFile(StringTemplate template, string file)
//		{
//			using (TextWriter tw = new StreamWriter(file))
//			{
//				template.Write(new NoIndentWriter(tw));
//				tw.Close();
//			}
//		}
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
