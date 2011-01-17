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
			TemplateWrapper template = new TemplateWrapper(templateName);

			bool first = true;
			foreach (var item in items)
			{
				if (!first)
					Write(separator);
				first = false;

				template.StartSession();

				template.SetAttribute("it", item);
				if (args != null)
					foreach (var prop in args.GetType().GetProperties())
						template.SetAttribute(prop.Name, prop.GetValue(args, null));

				string txt = template.Render();

				if (txt != null)
					Write(txt);
			}
		}
	}
}
