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
	public class ChildPropertyChangingEventArgs : PropertyChangingEventArgs
	{
		public ChildPropertyChangingEventArgs(object sender, string property, object child,
		                                      PropertyChangingEventArgs childArgs)
			: base(childArgs.PropertyName)
		{
			List<ObjectPathEntry> path = new List<ObjectPathEntry>();
			path.Add(new ObjectPathEntry(sender, property));

			if (child is ChildPropertyChangingEventArgs)
			{
				var other = (ChildPropertyChangingEventArgs) child;
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

		public bool IsFrom(object sender, string propertyName)
		{
			foreach (var entry in ObjectPath)
			{
				if (entry.Sender == sender && entry.Property == propertyName)
					return true;
			}

			return false;
		}

		public bool IsFrom<T>(object sender, Expression<Func<T>> property)
		{
			var lambda = (LambdaExpression) property;
			var memberExpression = (MemberExpression) lambda.Body;
			var propertyName = memberExpression.Member.Name;

			foreach (var entry in ObjectPath)
			{
				if (entry.Sender == sender && entry.Property == propertyName)
					return true;
			}

			return false;
		}

		public bool IsFrom(Type sender, string propertyName)
		{
			if (sender == null)
				return false;

			foreach (var entry in ObjectPath)
			{
				if (entry.Sender != null && sender.IsAssignableFrom(entry.Sender.GetType())
				    && entry.Property == propertyName)
					return true;
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
