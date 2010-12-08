﻿//
// Copyright (c) 2010 Ricardo Pescuma Domenecci
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 

using System.Diagnostics.Contracts;

namespace org.pescuma.ModelSharp.Core.model
{
	public class CollectionInfo : PropertyInfo
	{
		public readonly string Contents;
		public readonly BaseFieldInfo ContentsType;

		public CollectionInfo(TypeInfo owner, string name, string contents, bool lazy,
		                      string collectionType = "ObservableList")
			: base(owner, name, collectionType + "<" + contents + ">", false, lazy)
		{
			Contract.Requires(!string.IsNullOrEmpty(contents));

			ContentsType = new BaseFieldInfo("Items", contents);
			Contents = contents;
			Setter = null;
			WithSetter = null;
			ReadOnly = !lazy;
		}

		public override bool CanListenTo
		{
			get { return false; }
		}
	}
}
