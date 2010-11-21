//
// Copyright 2010 Ricardo Pescuma Domenecci
// 
// This file is part of Model#.
// 
// Model# is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
// 
// Model# is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along with Model#. If not, see <http://www.gnu.org/licenses/>.
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
