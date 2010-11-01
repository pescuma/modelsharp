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
using System.Diagnostics.Contracts;
using System.Linq;

namespace org.pescuma.ModelSharp.model
{
	public class TypeInfo
	{
		public readonly string Name;
		public readonly string ImplementationName;
		public readonly string Package;
		public readonly bool Immutable;

		public List<PropertyInfo> Properties = new List<PropertyInfo>();
		public List<FieldInfo> Fields = new List<FieldInfo>();
		public List<MethodInfo> Methods = new List<MethodInfo>();

		public readonly List<string> Annotations = new List<string>();

		public TypeInfo(string name, string package, bool immutable)
		{
			Contract.Requires(StringUtils.IsValidVariableName(name));
			Contract.Requires(StringUtils.IsValidTypeName(package));

			Name = name;
			ImplementationName = "Base" + name;
			Package = package;
			Immutable = immutable;
		}

		public bool HasSettableProperties
		{
			get { return Properties.Count(prop => prop.Setter != null) > 0; }
		}

		public bool HasCollections
		{
			get { return Properties.Count(prop => prop is CollectionInfo) > 0; }
		}
	}
}