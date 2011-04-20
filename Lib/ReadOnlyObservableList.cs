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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace org.pescuma.ModelSharp.Lib
{
	/// <summary>
	///   A wrapper around a ObservableList to make it read-only.
	///   It still fires notification events.
	/// </summary>
	[DebuggerDisplay("Count = {Count}")]
	[Serializable]
	public class ReadOnlyObservableList<T> : IList<T>, IList, INotifyCollectionChanged,
	                                         INotifyPropertyChanging, INotifyPropertyChanged,
	                                         INotifyCollectionChangedConfiguration
	{
		#region Field Name Defines

		public class PROPERTIES
		{
			public const string ITEMS = "Item[]";
		}

		#endregion

		private readonly ObservableList<T> list;

		#region Constructors

		public ReadOnlyObservableList(ObservableList<T> wrappedList)
		{
			list = wrappedList;

			list.CollectionChanged += (s, e) =>
			                          	{
			                          		NotifyCollectionChangedEventHandler handler = CollectionChanged;
			                          		if (handler != null)
			                          			handler(this, e);
			                          	};

			list.PropertyChanging += (s, e) =>
			                         	{
			                         		PropertyChangingEventHandler handler = PropertyChanging;
			                         		if (handler != null)
			                         			handler(this, e);
			                         	};

			list.PropertyChanged += (s, e) =>
			                        	{
			                        		PropertyChangedEventHandler handler = PropertyChanged;
			                        		if (handler != null)
			                        			handler(this, e);
			                        	};
		}

		#endregion Constructors

		public T this[int index]
		{
			get { return list[index]; }
		}

		#region IList<T>

		T IList<T>.this[int index]
		{
			get { return list[index]; }
			set { throw new NotSupportedException(); }
		}

		public int IndexOf(T item)
		{
			return list.IndexOf(item);
		}

		void IList<T>.Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		void IList<T>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		#endregion IList<T>

		#region ICollection<T>

		public int Count
		{
			get { return ((ICollection<T>) list).Count; }
		}

		bool ICollection<T>.IsReadOnly
		{
			get { return true; }
		}

		void ICollection<T>.Add(T item)
		{
			throw new NotSupportedException();
		}

		void ICollection<T>.Clear()
		{
			throw new NotSupportedException();
		}

		public bool Contains(T item)
		{
			return ((ICollection<T>) list).Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			((ICollection<T>) list).CopyTo(array, arrayIndex);
		}

		bool ICollection<T>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		#endregion ICollection<T>

		#region IEnumerable<T>

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>) list).GetEnumerator();
		}

		#endregion IEnumerable<T>

		#region IEnumerable

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable) list).GetEnumerator();
		}

		#endregion IEnumerable

		#region IList

		object IList.this[int index]
		{
			get { return list[index]; }
			set { throw new NotSupportedException(); }
		}

		bool IList.IsReadOnly
		{
			get { return true; }
		}

		bool IList.IsFixedSize
		{
			get { return ((IList) list).IsFixedSize; }
		}

		int IList.Add(object value)
		{
			throw new NotSupportedException();
		}

		bool IList.Contains(object value)
		{
			return ((IList) list).Contains(value);
		}

		void IList.Clear()
		{
			throw new NotSupportedException();
		}

		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		int IList.IndexOf(object value)
		{
			return ((IList) list).IndexOf(value);
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object value)
		{
			throw new NotSupportedException();
		}

		#endregion IList

		#region ICollection

		object ICollection.SyncRoot
		{
			get { return ((ICollection) list).SyncRoot; }
		}

		bool ICollection.IsSynchronized
		{
			get { return ((ICollection) list).IsSynchronized; }
		}

		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection) list).CopyTo(array, index);
		}

		#endregion ICollection

		#region List

		public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			return list.BinarySearch(index, count, item, comparer);
		}

		public int BinarySearch(T item)
		{
			return list.BinarySearch(item);
		}

		public int BinarySearch(T item, IComparer<T> comparer)
		{
			return list.BinarySearch(item, comparer);
		}

		public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			return list.ConvertAll(converter);
		}

		public bool Exists(Predicate<T> match)
		{
			return list.Exists(match);
		}

		public T Find(Predicate<T> match)
		{
			return list.Find(match);
		}

		public List<T> FindAll(Predicate<T> match)
		{
			return list.FindAll(match);
		}

		public int FindIndex(Predicate<T> match)
		{
			return list.FindIndex(match);
		}

		public int FindIndex(int startIndex, Predicate<T> match)
		{
			return list.FindIndex(startIndex, match);
		}

		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			return list.FindIndex(startIndex, count, match);
		}

		public T FindLast(Predicate<T> match)
		{
			return list.FindLast(match);
		}

		public int FindLastIndex(Predicate<T> match)
		{
			return list.FindLastIndex(match);
		}

		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			return list.FindLastIndex(startIndex, match);
		}

		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			return list.FindLastIndex(startIndex, count, match);
		}

		public void ForEach(Action<T> action)
		{
			list.ForEach(action);
		}

		public List<T> GetRange(int index, int count)
		{
			return list.GetRange(index, count);
		}

		public int IndexOf(T item, int index)
		{
			return list.IndexOf(item, index);
		}

		public int IndexOf(T item, int index, int count)
		{
			return list.IndexOf(item, index, count);
		}

		public int LastIndexOf(T item)
		{
			return list.LastIndexOf(item);
		}

		public int LastIndexOf(T item, int index)
		{
			return list.LastIndexOf(item, index);
		}

		public int LastIndexOf(T item, int index, int count)
		{
			return list.LastIndexOf(item, index, count);
		}

		public bool TrueForAll(Predicate<T> match)
		{
			return list.TrueForAll(match);
		}

		public T[] ToArray()
		{
			return list.ToArray();
		}

		#endregion List

		#region INotifyCollectionChanged

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		#endregion INotifyCollectionChanged

		#region INotifyPropertyChanging

		public event PropertyChangingEventHandler PropertyChanging;

		#endregion INotifyPropertyChanging

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion INotifyPropertyChanged

		#region INotifyCollectionChangedConfiguration

		bool INotifyCollectionChangedConfiguration.BatchMode
		{
			get { return batchMode; }
			set { batchMode = value; }
		}

		private bool batchMode = true;

		#endregion INotifyCollectionChangedConfiguration
	}
}
