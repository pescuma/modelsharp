﻿//
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

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace org.pescuma.ModelSharp.Core.model
{
	public class TypeInfo
	{
		public readonly HashSet<string> Using = new HashSet<string>();

		public readonly string Name;
		public readonly string ImplementationName;
		public readonly string Package;
		public readonly bool Immutable;

		public string Extends;
		public readonly List<string> Implements = new List<string>();
		public readonly List<PropertyInfo> Properties = new List<PropertyInfo>();
		public readonly List<MethodInfo> Methods = new List<MethodInfo>();

		public readonly List<string> Annotations = new List<string>();

		public TypeInfo(string name, string package, bool immutable)
		{
			Contract.Requires(StringUtils.IsValidVariableName(name));
			Contract.Requires(string.IsNullOrEmpty(package) || StringUtils.IsValidTypeName(package));

			Name = name;
			ImplementationName = "Base" + name;
			Package = string.IsNullOrEmpty(package) ? null : package;
			Immutable = immutable;
		}

		public bool HasSettableProperties
		{
			get { return Properties.Count(prop => prop.Setter != null) > 0; }
		}

		public bool HasCollections
		{
			get { return Properties.Any(prop => prop.IsCollection); }
		}

		public bool HasCollectionWithListenContentType
		{
			get
			{
				return
					Properties.Any(prop => prop.IsCollection && ((CollectionInfo) prop).ContentsType.CanListenTo);
			}
		}

		public bool HasComponents
		{
			get { return Properties.Any(prop => prop.IsComponent); }
		}

		public IEnumerable<PropertyInfo> ContructorArguments
		{
			get
			{
				List<PropertyInfo> result = new List<PropertyInfo>();
				foreach (var prop in Properties)
				{
					if (!prop.IsComponent && prop.Required && prop.DefaultValue == null)
						result.Add(prop);
				}
				return result;
			}
		}
	}
}