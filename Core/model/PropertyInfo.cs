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
	public class PropertyInfo : BaseFieldInfo
	{
		public readonly TypeInfo Owner;
		public bool Required;
		public bool Lazy;
		public int Order = -1;

		public MethodInfo Getter;
		public MethodInfo Setter;
		public MethodInfo WithSetter;
		public MethodInfo LazyInitializer;

		public string GetterVisibility
		{
			get
			{
				if (Getter != null)
					return Getter.Visibility == "public" ? null : Getter.Visibility;
				else
					return null;
			}
			set
			{
				if (Getter != null)
					Getter.Visibility = value ?? "public";
			}
		}

		public string SetterVisibility
		{
			get
			{
				if (Setter != null)
					return Setter.Visibility == "public" ? null : Setter.Visibility;
				else if (WithSetter != null)
					return WithSetter.Visibility == "public" ? null : WithSetter.Visibility;
				else
					return null;
			}
			set
			{
				if (Setter != null)
					Setter.Visibility = value ?? "public";
				if (WithSetter != null)
					WithSetter.Visibility = value ?? "public";
			}
		}

		public readonly List<string> FieldAnnotations = new List<string>();
		public readonly List<string> PropSetAnnotations = new List<string>();
		public readonly List<string> PropGetAnnotations = new List<string>();
		public readonly HashSet<PropertyInfo> DependentProperties = new HashSet<PropertyInfo>();

		public PropertyInfo(TypeInfo owner, string name, string type, bool required, bool lazy)
			: base(name, type)
		{
			Owner = owner;
			Required = required;
			Lazy = lazy;

			string getter = GetGetterName();
			if (getter != null)
				Getter = new MethodInfo(getter, TypeName);

			string setter = GetSetterName();
			if (setter != null)
				Setter = new MethodInfo(setter, "bool", TypeName);

			string withSetter = GetWithSetterName();
			if (withSetter != null)
				WithSetter = new MethodInfo(withSetter, owner.Name, TypeName);

			string lazyIntializer = GetLazyInitializerName();
			if (lazyIntializer != null)
				LazyInitializer = new MethodInfo(lazyIntializer);
		}

		private string GetLazyInitializerName()
		{
			if (!Lazy)
				return null;
			return "LazyInit" + Name;
		}

		private string GetGetterName()
		{
			if (TypeName == "bool" || TypeName == "Boolean")
				return "Is" + Name;
			else
				return "Get" + Name;
		}

		private string GetSetterName()
		{
			return "Set" + Name;
		}

		private string GetWithSetterName()
		{
			if (!Owner.Immutable)
				return null;
			return "With" + Name;
		}

		public bool IsCollection
		{
			get { return this is CollectionInfo; }
		}

		public bool IsComponent
		{
			get { return this is ComponentInfo; }
		}

		public bool IsComputed
		{
			get { return this is ComputedPropertyInfo; }
		}

		public bool AssertNotNull
		{
			get { return !IsPrimitive && Required; }
		}

		public override string ToString()
		{
			return string.Format("PropertyInfo[{0} {1}]", TypeName, Name);
		}

		public virtual void MakeImmutable()
		{
			FieldName = Name;
			Getter = null;
			Setter = null;
			LazyInitializer = null;
		}
	}
}
