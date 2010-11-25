//
// Copyright 2010 Ricardo Pescuma Domenecci
// 

using System.Collections.Generic;

namespace org.pescuma.ModelSharp.Core.model
{
	public class PropertyInfo : BaseFieldInfo
	{
		public bool Required;
		public bool Lazy;
		public int Order = -1;

		public MethodInfo Getter;
		public MethodInfo Setter;
		public MethodInfo LazyInitializer;
		public string GetterVisibility;
		public string SetterVisibility;

		public readonly List<string> FieldAnnotations = new List<string>();
		public readonly List<string> PropSetAnnotations = new List<string>();
		public readonly List<string> PropGetAnnotations = new List<string>();

		public PropertyInfo(string name, string type, bool required, bool lazy)
			: base(name, type)
		{
			Required = required;
			Lazy = lazy;

			string getter = GetGetterName();
			if (getter != null)
				Getter = new MethodInfo(getter, TypeName);

			string setter = GetSetterName();
			if (setter != null)
				Setter = new MethodInfo(setter, "bool", TypeName);

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

		public bool IsCollection
		{
			get { return this is CollectionInfo; }
		}

		public bool IsComponent
		{
			get { return this is ComponentInfo; }
		}

		public bool AssertNotNull
		{
			get { return !IsPrimitive && Required; }
		}

		public override string ToString()
		{
			return string.Format("PropertyInfo[{0} {1}]", TypeName, Name);
		}
	}
}
