﻿// 
//  Copyright (c) 2010 Ricardo Pescuma Domenecci
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
using System.Diagnostics.Contracts;

namespace org.pescuma.ModelSharp.Core.model
{
	public class CollectionInfo : PropertyInfo
	{
		public readonly string Contents;
		public readonly BaseFieldInfo ContentsType;
		public readonly bool ExposeAsReadOnly;

		public CollectionInfo(NamingConventions conventions, TypeInfo owner, string name, string contents,
		                      bool lazy, bool readOnly)
			: base(conventions, owner, name, "ObservableList<" + contents + ">", false, lazy)
		{
			Contract.Requires(!string.IsNullOrEmpty(contents));

			ContentsType = new BaseFieldInfo(conventions, "Items", contents);
			Contents = contents;
			ReadOnly = false; // !lazy; <= Needed for serializationa
			ExposeAsReadOnly = readOnly;

			Setter = null;
			WithSetter = null;
			validator = null;
			Getter.TypeName = ExposedTypeName;
		}

		public override bool CanListenTo
		{
			get { return false; }
		}

		public override bool DeepCopy
		{
			get
			{
				if (deepCopy == null)
				{
					if (ContentsType.IsPrimitiveOrString)
						return false;
					else
						return Owner.DeepCopy;
				}
				else
				{
					return (bool) deepCopy;
				}
			}
			set { base.DeepCopy = value; }
		}

		public override void MakeImmutable()
		{
			base.MakeImmutable();

			TypeName = "ReadOnlyCollection<" + Contents + ">";
			DefaultValue = "";

			Owner.Using.Add("System.Collections.ObjectModel");
			Owner.Using.Add("System.Collections.Generic");
		}

		public string ExposedTypeName
		{
			get
			{
				if (ExposeAsReadOnly)
					return "ReadOnlyObservableList<" + Contents + ">";
				else
					return TypeName;
			}
		}

		public string ExposedFieldName
		{
			get
			{
				if (ExposeAsReadOnly)
					return FieldName + "ReadOnly";
				else
					return FieldName;
			}
		}

		public override bool ReceiveInConstructor
		{
			get { return false; }
			set { base.ReceiveInConstructor = value; }
		}
	}
}
