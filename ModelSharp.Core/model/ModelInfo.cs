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