//
// Copyright 2010 Ricardo Pescuma Domenecci
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