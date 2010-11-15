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

		private string _defaultValue;

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
				if (_defaultValue == "")
					return null;

				return _defaultValue;
			}
			set
			{
				_defaultValue = value;

				if (TypeName == "string" && _defaultValue != null
				    && (_defaultValue.Length < 2 || _defaultValue[0] != '"' || _defaultValue[-1] != '"'))
				{
					_defaultValue = _defaultValue.Replace("\"", "\\\"");
					_defaultValue = "\"" + _defaultValue + "\"";
				}
			}
		}
	}
}