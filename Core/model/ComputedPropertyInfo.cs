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
using System.Collections.Generic;

namespace org.pescuma.ModelSharp.Core.model
{
	public class ComputedPropertyInfo : PropertyInfo
	{
		public readonly List<string> DependsOn = new List<string>();
		public readonly string Formula;
		public readonly bool Cached;

		public string InvalidFieldName;
		public readonly List<string> InvalidFieldAnnotations = new List<string>();

		public MethodInfo Cacher;
		public MethodInfo Invalidate;

		public ComputedPropertyInfo(TypeInfo owner, string name, string type, bool cached,
		                            IEnumerable<string> dependsOn, string formula)
			: base(owner, name, type, false, false)
		{
			Cached = cached;
			DependsOn.AddRange(dependsOn);
			Formula = (formula == "" ? null : formula);

			Getter = new MethodInfo(GetGetterName(), TypeName);

			Setter = null;
			LazyInitializer = null;

			if (Cached)
			{
				FieldName = FieldName + "Cache";
				InvalidFieldName = FieldName + "Invalid";
				Cacher = new MethodInfo(GetCacherName(), TypeName);
				Invalidate = new MethodInfo(GetInvalidateName());
			}
			else
			{
				FieldName = null;
				InvalidFieldName = null;
				Cacher = Getter;
				Invalidate = null;
			}
		}

		private string GetGetterName()
		{
			return "Compute" + Name;
		}

		private string GetCacherName()
		{
			return "ComputeAndCache" + Name;
		}

		private string GetInvalidateName()
		{
			return "Invalidate" + Name + "Cache";
		}

		public override bool CanListenTo
		{
			get { return false; }
		}

		public override void MakeImmutable()
		{
			FieldName = Name;
		}
	}
}
