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
using System;
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
		public readonly bool Cloneable;
		public readonly bool Serializable;
		public readonly bool Equals;
		public string Documentation;
		public bool DeepCopy;

		public string Extends;
		public readonly BaseClassInfo BaseClass = new BaseClassInfo();
		public readonly List<string> Implements = new List<string>();
		public readonly List<PropertyInfo> Properties = new List<PropertyInfo>();
		public readonly List<MethodInfo> Methods = new List<MethodInfo>();

		public readonly List<string> Annotations = new List<string>();
		public readonly List<string> BaseOnlyAnnotations = new List<string>();
		public readonly List<string> TypeOnlyAnnotations = new List<string>();

		public TypeInfo(string name, string package, bool immutable, bool cloneable, bool serializable,
		                bool equals)
		{
			Contract.Requires(StringUtils.IsValidVariableName(name));
			Contract.Requires(string.IsNullOrEmpty(package) || StringUtils.IsValidTypeName(package));

			Name = name;
			Equals = equals;
			ImplementationName = "Base" + name;
			Package = string.IsNullOrEmpty(package) ? null : package;
			Immutable = immutable;
			Cloneable = cloneable;
			Serializable = serializable;
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

		public bool HasCachedComputedProperties
		{
			get { return Properties.Any(prop => prop.IsComputedAndCached); }
		}

		public IEnumerable<PropertyInfo> ConstructorArguments
		{
			get
			{
				return (from p in Properties
				        where p.ReceiveInConstructor
				        select p);
			}
		}

		public IEnumerable<PropertyInfo> NonComputedProperties
		{
			get
			{
				return (from prop in Properties
				        where !prop.IsComputed
				        select prop);
			}
		}

		public IEnumerable<PropertyInfo> SimpleProperties
		{
			get
			{
				return (from prop in Properties
				        where !prop.IsComputed && !prop.IsComponent && !prop.IsCollection
				        select prop);
			}
		}

		public IEnumerable<PropertyInfo> SimpleOrComponentProperties
		{
			get
			{
				return (from prop in Properties
				        where !prop.IsComputed && !prop.IsCollection
				        select prop);
			}
		}

		public IEnumerable<CollectionInfo> CollectionProperties
		{
			get
			{
				return (from prop in Properties
				        where prop.IsCollection
				        select prop).Cast<CollectionInfo>();
			}
		}

		public IEnumerable<PropertyInfo> NonConstructorArgumentsNorComputedProperties
		{
			get
			{
				return (from p in Properties
				        where !p.ReceiveInConstructor && !p.IsComputed
				        select p);
			}
		}

		public List<PropertyInfo> PropertiesWithDependencies
		{
			get
			{
				return (from prop in Properties
				        where prop.DependentPropertiesByPath.Count > 0
				        select prop).ToList();
			}
		}

		public List<PropertyInfo> PropertiesWithDependenciesOnChildren
		{
			get
			{
				return (from prop in Properties
				        where prop.DependentPropertiesByPath.Count(d => d.Key != "") > 0
				        select prop).ToList();
			}
		}

		public IEnumerable<PropertyInfo> PropertiesWithCachedComputedDependencies
		{
			get
			{
				return (from prop in Properties
				        where prop.CachedComputedDependentProperties.Count > 0
				        select prop);
			}
		}

		public IEnumerable<PropertyInfo> PropertiesWithCachedComputedDependenciesOnChildren
		{
			get
			{
				return (from prop in Properties
				        where prop.CachedComputedDependentPropertiesByPath.Count(d => d.Key != "") > 0
				        select prop);
			}
		}

		public IEnumerable<ComputedPropertyInfo> CachedComputedProperties
		{
			get
			{
				return (from prop in Properties
				        where prop.IsComputedAndCached
				        select prop).Cast<ComputedPropertyInfo>();
			}
		}

		public List<string> ExtendsOrImplements
		{
			get
			{
				var ret = new List<string>();
				if (Extends != null)
					ret.Add(Extends);
				ret.AddRange(Implements);
				return ret;
			}
		}

		public bool NeedOnDeserialized
		{
			get
			{
				return !Immutable && Serializable && (from p in Properties
				                                      where p.IsCollection || p.CanListenTo
				                                      select p).Count() > 0;
			}
		}

		public bool NeedOnDeserializing
		{
			get
			{
				return !Immutable && Serializable && (from p in Properties
				                                      where
				                                      	p.LazyInitializer == null
				                                      	&&
				                                      	(p.IsCollection || p.DefaultValue != null
				                                      	 || p.IsComputedAndCached)
				                                      select p).Count() > 0;
			}
		}
	}

	public class BaseClassInfo
	{
		public bool HasPropertyChanging;
		public bool HasChildPropertyChanging;
		public bool HasPropertyChanged;
		public bool HasChildPropertyChanged;
		public bool HasCopyFrom;
		public bool HasProperties;
		public bool IsGenerated;

		public bool HasPropertyChange(string type)
		{
			if (type == "Changing")
				return HasPropertyChanging;
			else if (type == "Changed")
				return HasPropertyChanged;
			else
				throw new ArgumentException();
		}

		public bool HasChildPropertyChange(string type)
		{
			if (type == "Changing")
				return HasChildPropertyChanging;
			else if (type == "Changed")
				return HasChildPropertyChanged;
			else
				throw new ArgumentException();
		}
	}
}
