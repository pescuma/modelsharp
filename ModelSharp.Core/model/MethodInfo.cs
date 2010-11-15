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

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace org.pescuma.ModelSharp.Core.model
{
	public class MethodInfo
	{
		public readonly string Name;
		public readonly string TypeName;
		public string[] Parameters;

		public readonly List<string> Annotations = new List<string>();

		public MethodInfo(string name, string type = "void", params string[] parameters)
		{
			Contract.Requires(StringUtils.IsValidVariableName(name));
			Contract.Requires(StringUtils.IsValidTypeName(type));
			Contract.Requires(!Array.Exists(parameters, x => !StringUtils.IsValidTypeName(x)));

			Name = name;
			TypeName = type;
			Parameters = parameters;
		}
	}
}