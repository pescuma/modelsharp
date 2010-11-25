//
// Copyright 2010 Ricardo Pescuma Domenecci
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
