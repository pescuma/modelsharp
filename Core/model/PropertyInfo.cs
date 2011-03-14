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
using System.Linq;

namespace org.pescuma.ModelSharp.Core.model
{
	public class PropertyInfo : BaseFieldInfo
	{
		public readonly TypeInfo Owner;
		public readonly bool Required;
		public readonly bool Lazy;
		public int Order = -1;
		protected bool? deepCopy;

		public MethodInfo Getter;
		public MethodInfo Setter;
		public MethodInfo WithSetter;
		public MethodInfo LazyInitializer;
		protected MethodInfo validator;

		public readonly List<string> FieldAnnotations = new List<string>();
		public readonly List<string> PropSetAnnotations = new List<string>();
		public readonly List<string> PropGetAnnotations = new List<string>();

		public readonly Dictionary<string, HashSet<PropertyInfo>> DependentPropertiesByPath =
			new Dictionary<string, HashSet<PropertyInfo>>();

		public readonly List<ValidationInfo> Validations = new List<ValidationInfo>();

		public virtual MethodInfo Validator
		{
			get
			{
				if (Validations.Count > 0)
					return validator;
				else
					return null;
			}
		}

		public virtual bool DeepCopy
		{
			get
			{
				if (deepCopy == null)
				{
					if (IsPrimitiveOrString)
						return false;
					else
						return Owner.DeepCopy;
				}
				else
				{
					return (bool) deepCopy;
				}
			}
			set { deepCopy = value; }
		}

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

		public PropertyInfo(NamingConventions conventions, TypeInfo owner, string name, string type,
		                    bool required, bool lazy)
			: base(conventions, name, type)
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

			string validatorName = GetValidatorName();
			if (validatorName != null)
				validator = new MethodInfo(validatorName, "void", TypeName);
		}

		private string GetValidatorName()
		{
			return "Validate" + Name;
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
			else if (Name != "Type")
				return "Get" + Name;
			else
				return "GetProperty" + Name;
		}

		private string GetSetterName()
		{
			if (Name != "Type")
				return "Set" + Name;
			else
				return "SetProperty" + Name;
		}

		private string GetWithSetterName()
		{
			if (!Owner.Immutable)
				return null;
			return "With" + Name;
		}

		public void AddDependentProperty(PropertyInfo other, string path)
		{
			if (!DependentPropertiesByPath.ContainsKey(path))
				DependentPropertiesByPath.Add(path, new HashSet<PropertyInfo>());

			DependentPropertiesByPath[path].Add(other);
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

		public bool IsComputedAndCached
		{
			get { return this is ComputedPropertyInfo && ((ComputedPropertyInfo) this).Cached; }
		}

		public virtual void MakeImmutable()
		{
			FieldName = Name;
			Getter = null;
			Setter = null;
			LazyInitializer = null;
		}

		public Dictionary<string, HashSet<ComputedPropertyInfo>> CachedComputedDependentPropertiesByPath
		{
			get
			{
				var result = new Dictionary<string, HashSet<ComputedPropertyInfo>>();

				foreach (var dep in DependentPropertiesByPath)
				{
					var props = new HashSet<ComputedPropertyInfo>();

					foreach (var prop in dep.Value)
					{
						if (prop.IsComputedAndCached)
							props.Add((ComputedPropertyInfo) prop);
					}

					if (props.Count > 0)
						result.Add(dep.Key, props);
				}

				return result;
			}
		}

		public IList<ComputedPropertyInfo> DependentProperties
		{
			get
			{
				return (from pair in DependentPropertiesByPath
				        from prop in pair.Value
				        select prop).Distinct().Cast<ComputedPropertyInfo>().ToList();
			}
		}

		public IList<ComputedPropertyInfo> CachedComputedDependentProperties
		{
			get
			{
				return (from prop in DependentProperties
				        where prop.IsComputedAndCached
				        select prop).ToList();
			}
		}

		public IList<ComputedPropertyInfo> ComputedDependentProperties
		{
			get
			{
				return (from prop in DependentProperties
				        where prop.IsComputed
				        select prop).ToList();
			}
		}

		public void AddValidation(string test, string exception = null)
		{
			if (test == null)
				return;

			Validations.Add(new ValidationInfo("!(" + test + ")",
			                                   exception
			                                   ??
			                                   "new ArgumentException(" + FormatCodeToString(test)
			                                   + ", property)"));
		}

		private string FormatCodeToString(string test)
		{
			return "\""
			       +
			       test.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "").
			       	Replace("\t", "") + "\"";
		}

		public void AddValidationAttrib(string attrib, string exception = null)
		{
			if (attrib == null)
				return;

			Owner.Using.Add("System.ComponentModel.DataAnnotations");
			Annotations.Add(attrib);

			var constructor = attrib;

			var start = attrib.IndexOf('(');
			if (start < 0)
				constructor += "Attribute()";
			else
				constructor = attrib.Substring(0, start) + "Attribute" + attrib.Substring(start);

			Validations.Add(new ValidationInfo("!new " + constructor + ".IsValid(value)",
			                                   exception
			                                   ??
			                                   "new ArgumentException(" + FormatCodeToString(attrib)
			                                   + ", property)"));
		}

		public override string ToString()
		{
			return string.Format("PropertyInfo[{0} {1}]", TypeName, Name);
		}
	}

	public class ValidationInfo
	{
		public string Test;
		public string Exception;
		public string Prefix;
		public string Suffix;

		public ValidationInfo(string test, string exception, string prefix = null, string suffix = null)
		{
			Test = test;
			Exception = exception;
			Prefix = prefix;
			Suffix = suffix;
		}
	}
}
