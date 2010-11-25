//
// Copyright 2010 Ricardo Pescuma Domenecci
// 

using System.Collections.Generic;

namespace org.pescuma.ModelSharp.Core.model
{
	public class ModelInfo
	{
		public readonly HashSet<string> Using = new HashSet<string>();
		private readonly List<TypeInfo> _types = new List<TypeInfo>();

		public List<TypeInfo> Types
		{
			get { return _types; }
		}

		public void AddType(TypeInfo type)
		{
			_types.Add(type);
		}

		public TypeInfo GetType(string name)
		{
			return _types.Find(type => name == type.Name);
		}
	}
}