//
// Copyright 2010 Ricardo Pescuma Domenecci
// 

namespace org.pescuma.ModelSharp.Core.model
{
	public class ComponentInfo : PropertyInfo
	{
		public ComponentInfo(string name, string type, bool lazy)
			: base(name, type, !lazy, lazy)
		{
			Setter = null;
			ReadOnly = !lazy;
		}
	}
}