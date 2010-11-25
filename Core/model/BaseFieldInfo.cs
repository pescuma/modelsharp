//
// Copyright 2010 Ricardo Pescuma Domenecci
// 

using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace org.pescuma.ModelSharp.Core.model
{
	public class BaseFieldInfo
	{
		public string Name;
		public string FieldName;
		public string PrivateName;
		public string PublicName;
		public string VarName;
		public string TypeName;
		public string DefineName;
		public bool ReadOnly;
		public readonly List<string> Annotations = new List<string>();

		private string defaultValue;

		public BaseFieldInfo(string name, string type)
		{
			Contract.Requires(StringUtils.IsValidVariableName(name));
			Contract.Requires(StringUtils.IsValidTypeName(type));
			Contract.Ensures(StringUtils.IsValidVariableName(Name));
			Contract.Ensures(StringUtils.IsValidVariableName(PrivateName));
			Contract.Ensures(StringUtils.IsValidVariableName(PublicName));
			Contract.Ensures(StringUtils.IsValidVariableName(VarName));
			Contract.Ensures(StringUtils.IsValidTypeName(TypeName));
			Contract.Ensures(StringUtils.IsValidVariableName(DefineName));

			Name = name;
			PublicName = StringUtils.FirstUpper(name);
			FieldName = PrivateName = "_" + StringUtils.FirstLower(name);
			VarName = StringUtils.FirstLower(name);
			TypeName = type;
			DefineName = StringUtils.ToDefineName(name);
			ReadOnly = false;
		}

		public string DefaultValue
		{
			get
			{
				if (defaultValue == "")
					return null;

				return defaultValue;
			}
			set
			{
				defaultValue = value;

				if (TypeName == "string" && defaultValue != null
				    && (defaultValue.Length < 2 || defaultValue[0] != '"' || defaultValue[-1] != '"'))
				{
					defaultValue = defaultValue.Replace("\"", "\\\"");
					defaultValue = "\"" + defaultValue + "\"";
				}
			}
		}

		public bool IsPrimitive
		{
			get
			{
				HashSet<string> simpleTypes = new HashSet<string>();
				simpleTypes.Add("sbyte");
				simpleTypes.Add("byte");
				simpleTypes.Add("short");
				simpleTypes.Add("ushort");
				simpleTypes.Add("int");
				simpleTypes.Add("uint");
				simpleTypes.Add("long");
				simpleTypes.Add("ulong");
				simpleTypes.Add("char");
				simpleTypes.Add("float");
				simpleTypes.Add("double");
				simpleTypes.Add("bool");
				simpleTypes.Add("decimal");

				return simpleTypes.Contains(TypeName);
			}
		}

		public bool CanListenTo
		{
			get
			{
				HashSet<string> notListenTo = new HashSet<string>();
				notListenTo.Add("string");
				notListenTo.Add("String");

				return !IsPrimitive && !notListenTo.Contains(TypeName);
			}
		}
	}
}
