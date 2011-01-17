using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace org.pescuma.ModelSharp.Core
{
	internal class TemplateWrapper
	{
		private string templateName;
		private Type type;
		private PropertyInfo sessionProperty;
		private MethodInfo transformText;
		private MethodInfo initialize;
		private object template;
		private Dictionary<string, object> session;

		public TemplateWrapper(string templateName)
		{
			this.templateName = templateName;

			type = (from t in Assembly.GetCallingAssembly().GetTypes()
			        where t.Name == templateName
			        select t).FirstOrDefault();
			if (type == null)
				throw new ArgumentException("Could not find template " + templateName);

			sessionProperty = (from p in type.GetProperties()
			                   where p.Name == "Session"
			                   select p).FirstOrDefault();
			if (sessionProperty == null)
				throw new ArgumentException("Invalid template " + templateName
				                            + " : it must have a property called Session");

			transformText = (from m in type.GetMethods()
			                 where m.Name == "TransformText"
			                 select m).FirstOrDefault();
			if (transformText == null)
				throw new ArgumentException("Invalid template " + templateName
				                            + " : it must have a method called TransformText");

			initialize = (from m in type.GetMethods()
			              where m.Name == "Initialize"
			              select m).FirstOrDefault();
			if (initialize == null)
				throw new ArgumentException("Invalid template " + templateName
				                            + " : it must have a method called Initialize");
		}

		public void StartSession()
		{
			template = Activator.CreateInstance(type);
			session = new Dictionary<string, object>();
		}

		public void SetAttribute(string name, object val)
		{
			session.Add(name, val);
		}

		public string Render()
		{
			sessionProperty.SetValue(template, session, null);
			initialize.Invoke(template, null);

			var txt = (string) transformText.Invoke(template, null);

			session = null;
			template = null;

			return txt;
		}
	}
}
