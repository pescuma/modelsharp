using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace org.pescuma.ModelSharp.Core.templates
{
	partial class TemplateUtils
	{
		protected void ForEach(IEnumerable items, string separator = "")
		{
			bool first = true;
			foreach (var item in items)
			{
				if (!first)
					Write(separator);
				first = false;

				Write(item == null ? "null" : item.ToString());
			}
		}

		protected void ForEach(string templateName, IEnumerable items, object args = null,
		                       string separator = "")
		{
			var type = (from t in Assembly.GetCallingAssembly().GetTypes()
			            where t.Name == templateName
			            select t).FirstOrDefault();
			if (type == null)
				throw new ArgumentException("Could not find template " + templateName);

			var sessionProperty = (from p in type.GetProperties()
			                       where p.Name == "Session"
			                       select p).FirstOrDefault();
			if (sessionProperty == null)
				throw new ArgumentException("Invalid template " + templateName
				                            + " : it must have a property called Session");

			var transformText = (from m in type.GetMethods()
			                     where m.Name == "TransformText"
			                     select m).FirstOrDefault();
			if (transformText == null)
				throw new ArgumentException("Invalid template " + templateName
				                            + " : it must have a method called TransformText");

			var initialize = (from m in type.GetMethods()
			                  where m.Name == "Initialize"
			                  select m).FirstOrDefault();
			if (initialize == null)
				throw new ArgumentException("Invalid template " + templateName
				                            + " : it must have a method called Initialize");

			bool first = true;
			foreach (var item in items)
			{
				if (!first)
					Write(separator);
				first = false;

				var template = Activator.CreateInstance(type);

				var session = new Dictionary<string, object>();

				session.Add("it", item);
				if (args != null)
					foreach (var prop in args.GetType().GetProperties())
						session.Add(prop.Name, prop.GetValue(args, null));

				sessionProperty.SetValue(template, session, null);
				initialize.Invoke(template, null);
				string txt = (string) transformText.Invoke(template, null);

				if (txt != null)
					Write(txt);
			}
		}
	}
}
