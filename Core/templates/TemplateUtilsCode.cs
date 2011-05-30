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
using System.Collections;
using System.Text;

namespace org.pescuma.ModelSharp.Core.templates
{
	partial class TemplateUtils
	{
		protected void Include(string templateName, object item, params object[] args)
		{
			TemplateWrapper template = new TemplateWrapper(templateName);

			template.StartSession();

			template.SetAttribute("it", item);
			template.SetAttribute("index", 0);
			for (int i = 0; i < args.Length; i += 2)
				template.SetAttribute((string) args[i], args[i + 1]);

			string txt = template.Render();

			if (txt != null)
				Write(txt);
		}

		protected void ForEach(IEnumerable items, string separator = "")
		{
			int index = 0;
			foreach (var item in items)
			{
				if (index > 0)
					Write(separator);

				Write(item == null ? "null" : item.ToString());

				index++;
			}
		}

		protected void ForEach(string templateName, IEnumerable items, string separator = "",
		                       params object[] args)
		{
			TemplateWrapper template = new TemplateWrapper(templateName);

			int index = 0;
			foreach (var item in items)
			{
				if (index > 0)
					Write(separator);

				template.StartSession();

				template.SetAttribute("it", item);
				template.SetAttribute("index", index);
				for (int i = 0; i < args.Length; i += 2)
					template.SetAttribute((string) args[i], args[i + 1]);

				string txt = template.Render();

				if (txt != null)
					Write(txt);

				index++;
			}
		}

		protected string ConvertPropertyPathToObfuscation(string path)
		{
			var result = new StringBuilder();
			foreach (var p in path.Split('.'))
			{
				if (result.Length > 0)
					result.Append(" + \".\" + ");
				result.Append("ModelUtils.NameOfParameter(" + p + " => {})");
			}
			return result.ToString();
		}
	}
}
