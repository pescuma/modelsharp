//
// Copyright 2010 Ricardo Pescuma Domenecci
// 

using System.Diagnostics.Contracts;

namespace org.pescuma.ModelSharp.Core.model
{
	public class CollectionInfo : PropertyInfo
	{
		public readonly string Contents;

		public CollectionInfo(string name, string contents, bool lazy, string collectionType = "ObservableCollection")
			: base(name, collectionType + "<" + contents + ">", false, lazy)
		{
			Contract.Requires(contents != null && contents != "");

			Contents = contents;
			Setter = null;
			ReadOnly = !lazy;
		}
	}
}