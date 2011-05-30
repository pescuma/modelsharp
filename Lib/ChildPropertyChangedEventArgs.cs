// 
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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace org.pescuma.ModelSharp.Lib
{
	public class ChildPropertyChangedEventArgs : PropertyChangedEventArgs
	{
		public ChildPropertyChangedEventArgs(object sender, string property, object child,
		                                     PropertyChangedEventArgs childArgs)
			: base(childArgs.PropertyName)
		{
			List<ObjectPathEntry> path = new List<ObjectPathEntry>();
			path.Add(new ObjectPathEntry(sender, property));

			if (childArgs is ChildPropertyChangedEventArgs)
			{
				var other = (ChildPropertyChangedEventArgs) childArgs;
				path.AddRange(other.ObjectPath);
			}
			else
			{
				path.Add(new ObjectPathEntry(child, childArgs.PropertyName));
			}

			ObjectPath = new ReadOnlyCollection<ObjectPathEntry>(path);
		}

		public readonly IList<ObjectPathEntry> ObjectPath;

		public string FullPath
		{
			get
			{
				var result = new StringBuilder();
				foreach (var obj in ObjectPath)
				{
					if (result.Length > 0)
						result.Append(".");
					result.Append(obj.Property);
				}
				return result.ToString();
			}
		}

		public bool IsFrom<TS, T>(TS sender, Expression<Func<TS, T>> property)
		{
			return IsFrom(sender, ModelUtils.NameOfProperty(property));
		}

		public bool IsFrom(object sender, params string[] propertiesNames)
		{
			if (propertiesNames == null || propertiesNames.Length < 1)
				throw new ArgumentNullException();

			var propertyName = string.Join(".", propertiesNames);

			for (int i = 0; i < ObjectPath.Count; i++)
			{
				var entry = ObjectPath[i];

				if (entry.Sender == sender && IsProperty(propertyName, i))
					return true;
			}

			return false;
		}

		public bool IsFrom<T>(Type sender, Expression<Func<T>> property)
		{
			return IsFrom(sender, ModelUtils.NameOfProperty(property));
		}

		public bool IsFrom<TS, T>(Type sender, Expression<Func<TS, T>> property)
		{
			return IsFrom(sender, ModelUtils.NameOfProperty(property));
		}

		public bool IsFrom(Type sender, params string[] propertiesNames)
		{
			if (sender == null)
				throw new ArgumentNullException();
			if (propertiesNames == null || propertiesNames.Length < 1)
				throw new ArgumentNullException();

			var propertyName = string.Join(".", propertiesNames);

			for (int i = 0; i < ObjectPath.Count; i++)
			{
				var entry = ObjectPath[i];

				if (entry.Sender != null && sender.IsAssignableFrom(entry.Sender.GetType())
				    && IsProperty(propertyName, i))
					return true;
			}

			return false;
		}

		private bool IsProperty(string propertyName, int objectPathIndex)
		{
			var entryPropertyName = ObjectPath[objectPathIndex].Property;

			// Check if this is it
			if (entryPropertyName == propertyName)
				return true;

			// Check sub properties
			if (propertyName.IndexOf('.') >= 0)
			{
				for (int j = objectPathIndex + 1; j < ObjectPath.Count; j++)
				{
					if (!propertyName.StartsWith(entryPropertyName))
						break;

					var child = ObjectPath[j];

					entryPropertyName += "." + child.Property;

					if (entryPropertyName == propertyName)
						return true;
				}
			}

			return false;
		}

		public class ObjectPathEntry
		{
			public readonly object Sender;
			public readonly string Property;

			public ObjectPathEntry(object sender, string property)
			{
				Sender = sender;
				Property = property;
			}
		}
	}
}
