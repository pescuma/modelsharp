using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace org.pescuma.ModelSharp.Lib
{
	public class ChildPropertyChangingEventArgs : PropertyChangingEventArgs
	{
		public ChildPropertyChangingEventArgs(object sender, string property, PropertyChangingEventArgs child)
			: base(child.PropertyName)
		{
			List<ObjectPathEntry> path = new List<ObjectPathEntry>();
			path.Add(new ObjectPathEntry(sender, property));

			var other = child as ChildPropertyChangingEventArgs;
			if (other != null)
				path.AddRange(other.ObjectPath);

			ObjectPath = new ReadOnlyCollection<ObjectPathEntry>(path);
		}

		public readonly IList<ObjectPathEntry> ObjectPath;

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
