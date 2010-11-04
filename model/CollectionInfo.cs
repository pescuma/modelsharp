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

using System.Diagnostics.Contracts;

namespace org.pescuma.ModelSharp.model
{
	public class CollectionInfo : PropertyInfo
	{
		public readonly string Contents;

		public CollectionInfo(string name, string contents, bool lazy, string collectionType = "ObservableCollection")
			: base(name, collectionType + "<" + contents + ">", lazy)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(contents));

			Contents = contents;
			Setter = null;
			ReadOnly = !lazy;

			if (!lazy)
				DefaultValue = "new " + TypeName + "()";
		}
	}
}