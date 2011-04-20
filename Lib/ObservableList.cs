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
using System.Linq.Expressions;

namespace org.pescuma.ModelSharp.Lib
{
	/// <summary>
	///   A observable list that implements all methods of List and add notifications to it. 
	///   It only notifies of Add, Remove and Replace (and not about Move), but those notifications are always with an 
	///   index and object.
	/// </summary>
	[DebuggerDisplay("Count = {Count}")]
	[Serializable]
	public class ObservableList<T> : IList<T>, IList, INotifyCollectionChanged, INotifyPropertyChanging,
	                                 INotifyPropertyChanged, INotifyCollectionChangedConfiguration
	{
		#region Field Name Defines

		public class PROPERTIES
		{
			public const string ITEMS = "Item[]";
		}

		#endregion

		private readonly List<T> items;

		#region Constructors

		public ObservableList()
		{
			items = new List<T>();
		}

		public ObservableList(int capacity)
		{
			items = new List<T>(capacity);
		}

		public ObservableList(IEnumerable<T> collection)
		{
			items = new List<T>(collection);
		}

		#endregion Constructors

		#region IList<T>

		public T this[int index]
		{
			get { return items[index]; }
			set
			{
				OnItemsChanging();
				T oldItem = items[index];

				items[index] = value;

				OnItemsChanged();
				OnCollectionReplace(index, oldItem, value);
			}
		}

		public int IndexOf(T item)
		{
			return items.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			OnCountChanging();
			OnItemsChanging();

			items.Insert(index, item);

			OnCountChanged();
			OnItemsChanged();
			OnCollectionAdd(index, item);
		}

		public void RemoveAt(int index)
		{
			OnCountChanging();
			OnItemsChanging();
			T oldItem = items[index];

			items.RemoveAt(index);

			OnCountChanged();
			OnItemsChanged();
			OnCollectionRemove(index, oldItem);
		}

		#endregion IList<T>

		#region ICollection<T>

		public int Count
		{
			get { return ((ICollection<T>) items).Count; }
		}

		bool ICollection<T>.IsReadOnly
		{
			get { return ((ICollection<T>) items).IsReadOnly; }
		}

		public void Add(T item)
		{
			OnCountChanging();
			OnItemsChanging();

			items.Add(item);

			OnCountChanged();
			OnItemsChanged();
			OnCollectionAdd(Count - 1, item);
		}

		public void Clear()
		{
			if (Count == 0)
				return;

			if (batchMode)
			{
				OnCountChanging();
				OnItemsChanging();
				T[] oldItems = items.ToArray();

				((ICollection<T>) items).Clear();

				OnCountChanged();
				OnItemsChanged();
				OnCollectionRemove(0, oldItems);
			}
			else
			{
				while (Count > 0)
					RemoveAt(0);
			}
		}

		public bool Contains(T item)
		{
			return ((ICollection<T>) items).Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			((ICollection<T>) items).CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			int index = items.IndexOf(item);
			if (index < 0)
			{
				return false;
			}
			else
			{
				RemoveAt(index);
				return true;
			}
		}

		#endregion ICollection<T>

		#region IEnumerable<T>

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>) items).GetEnumerator();
		}

		#endregion IEnumerable<T>

		#region IEnumerable

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable) items).GetEnumerator();
		}

		#endregion IEnumerable

		#region IList

		object IList.this[int index]
		{
			get { return items[index]; }
			set
			{
				OnItemsChanging();
				T oldItem = items[index];

				((IList) items)[index] = value;

				OnItemsChanged();
				OnCollectionReplace(index, oldItem, (T) value);
			}
		}

		bool IList.IsReadOnly
		{
			get { return ((IList) items).IsReadOnly; }
		}

		bool IList.IsFixedSize
		{
			get { return ((IList) items).IsFixedSize; }
		}

		int IList.Add(object value)
		{
			OnCountChanging();
			OnItemsChanging();

			int result = ((IList) items).Add(value);

			OnCountChanged();
			OnItemsChanged();
			OnCollectionAdd(result, (T) value);

			return result;
		}

		bool IList.Contains(object value)
		{
			return ((IList) items).Contains(value);
		}

		int IList.IndexOf(object value)
		{
			return ((IList) items).IndexOf(value);
		}

		void IList.Insert(int index, object value)
		{
			OnCountChanging();
			OnItemsChanging();

			((IList) items).Insert(index, value);

			OnCountChanged();
			OnItemsChanged();
			OnCollectionAdd(index, (T) value);
		}

		void IList.Remove(object value)
		{
			Remove((T) value);
		}

		#endregion IList

		#region ICollection

		object ICollection.SyncRoot
		{
			get { return ((ICollection) items).SyncRoot; }
		}

		bool ICollection.IsSynchronized
		{
			get { return ((ICollection) items).IsSynchronized; }
		}

		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection) items).CopyTo(array, index);
		}

		#endregion ICollection

		#region List

		public void AddRange(IEnumerable<T> collection)
		{
			var asArray = new List<T>(collection).ToArray();
			if (asArray.Length < 1)
				return;

			if (batchMode)
			{
				OnCountChanging();
				OnItemsChanging();
				int oldCount = items.Count;

				items.AddRange(asArray);

				OnCountChanged();
				OnItemsChanged();
				OnCollectionAdd(oldCount, asArray);
			}
			else
			{
				foreach (var element in asArray)
					Add(element);
			}
		}

		public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			return items.BinarySearch(index, count, item, comparer);
		}

		public int BinarySearch(T item)
		{
			return items.BinarySearch(item);
		}

		public int BinarySearch(T item, IComparer<T> comparer)
		{
			return items.BinarySearch(item, comparer);
		}

		public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			return items.ConvertAll(converter);
		}

		public bool Exists(Predicate<T> match)
		{
			return items.Exists(match);
		}

		public T Find(Predicate<T> match)
		{
			return items.Find(match);
		}

		public List<T> FindAll(Predicate<T> match)
		{
			return items.FindAll(match);
		}

		public int FindIndex(Predicate<T> match)
		{
			return items.FindIndex(match);
		}

		public int FindIndex(int startIndex, Predicate<T> match)
		{
			return items.FindIndex(startIndex, match);
		}

		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			return items.FindIndex(startIndex, count, match);
		}

		public T FindLast(Predicate<T> match)
		{
			return items.FindLast(match);
		}

		public int FindLastIndex(Predicate<T> match)
		{
			return items.FindLastIndex(match);
		}

		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			return items.FindLastIndex(startIndex, match);
		}

		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			return items.FindLastIndex(startIndex, count, match);
		}

		public void ForEach(Action<T> action)
		{
			items.ForEach(action);
		}

		public List<T> GetRange(int index, int count)
		{
			return items.GetRange(index, count);
		}

		public int IndexOf(T item, int index)
		{
			return items.IndexOf(item, index);
		}

		public int IndexOf(T item, int index, int count)
		{
			return items.IndexOf(item, index, count);
		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
			var asArray = new List<T>(collection).ToArray();
			if (asArray.Length < 1)
				return;

			if (batchMode)
			{
				OnCountChanging();
				OnItemsChanging();

				items.InsertRange(index, asArray);

				OnCountChanged();
				OnItemsChanged();
				OnCollectionAdd(index, asArray);
			}
			else
			{
				for (int i = 0; i < asArray.Length; i++)
					Insert(index + i, asArray[i]);
			}
		}

		public int LastIndexOf(T item)
		{
			return items.LastIndexOf(item);
		}

		public int LastIndexOf(T item, int index)
		{
			return items.LastIndexOf(item, index);
		}

		public int LastIndexOf(T item, int index, int count)
		{
			return items.LastIndexOf(item, index, count);
		}

		public int RemoveAll(Predicate<T> match)
		{
			var toRemove = new HashSet<T>();
			int firstIndex = -1;
			for (int i = 0; i < items.Count; i++)
			{
				T value = items[i];
				if (match(value))
				{
					if (firstIndex < 0)
						firstIndex = i;
					toRemove.Add(value);
				}
			}

			if (toRemove.Count < 1)
				return 0;

			int result;

			if (batchMode)
			{
				OnCountChanging();
				OnItemsChanging();

				result = items.RemoveAll(toRemove.Contains);

				OnCountChanged();
				OnItemsChanged();

				var removed = new T[toRemove.Count];
				toRemove.CopyTo(removed);
				OnCollectionRemove(removed.Length == 1 ? firstIndex : -1, removed);
			}
			else
			{
				result = 0;
				foreach (var element in toRemove)
				{
					if (Remove(element))
						result++;
				}
			}

			return result;
		}

		public void RemoveRange(int index, int count)
		{
			if (count == 0)
				return;

			if (batchMode)
			{
				OnCountChanging();
				OnItemsChanging();
				T[] oldItems = items.GetRange(index, count).ToArray();

				items.RemoveRange(index, count);

				OnCountChanged();
				OnItemsChanged();
				OnCollectionRemove(index, oldItems);
			}
			else
			{
				while (count > 0 && Count > index)
				{
					RemoveAt(index);
					count--;
				}
			}
		}

		public bool TrueForAll(Predicate<T> match)
		{
			return items.TrueForAll(match);
		}

		public T[] ToArray()
		{
			return items.ToArray();
		}

		public void TrimExcess()
		{
			items.TrimExcess();
		}

		public void Reverse()
		{
			if (batchMode)
			{
				T[] oldItems = items.ToArray();
				if (oldItems.Length < 1)
					return;

				OnItemsChanging();

				items.Reverse();

				OnItemsChanged();
				OnCollectionReplace(0, oldItems, ToArray());
			}
			else
			{
				var tmp = new List<T>(items);

				tmp.Reverse();

				Clear();
				AddRange(tmp);
			}
		}

		public void Reverse(int index, int count)
		{
			if (batchMode)
			{
				T[] oldItems = items.GetRange(index, count).ToArray();
				if (oldItems.Length < 1)
					return;

				OnItemsChanging();

				items.Reverse(index, count);

				OnItemsChanged();
				OnCollectionReplace(index, oldItems, items.GetRange(index, count).ToArray());
			}
			else
			{
				var tmp = new List<T>(items);

				tmp.Reverse(index, count);

				Clear();
				AddRange(tmp);
			}
		}

		public void Sort()
		{
			if (batchMode)
			{
				T[] oldItems = items.ToArray();
				if (oldItems.Length < 1)
					return;

				OnItemsChanging();

				items.Sort();

				OnItemsChanged();
				OnCollectionReplace(0, oldItems, ToArray());
			}
			else
			{
				var tmp = new List<T>(items);

				tmp.Sort();

				Clear();
				AddRange(tmp);
			}
		}

		public void Sort(IComparer<T> comparer)
		{
			if (batchMode)
			{
				T[] oldItems = items.ToArray();
				if (oldItems.Length < 1)
					return;

				OnItemsChanging();

				items.Sort(comparer);

				OnItemsChanged();
				OnCollectionReplace(0, oldItems, ToArray());
			}
			else
			{
				var tmp = new List<T>(items);

				tmp.Sort(comparer);

				Clear();
				AddRange(tmp);
			}
		}

		public void Sort(int index, int count, IComparer<T> comparer)
		{
			if (batchMode)
			{
				T[] oldItems = items.GetRange(index, count).ToArray();
				if (oldItems.Length < 1)
					return;

				OnItemsChanging();

				items.Sort(index, count, comparer);

				OnItemsChanged();
				OnCollectionReplace(0, oldItems, GetRange(index, count).ToArray());
			}
			else
			{
				var tmp = new List<T>(items);

				tmp.Sort(index, count, comparer);

				Clear();
				AddRange(tmp);
			}
		}

		public void Sort(Comparison<T> comparison)
		{
			if (batchMode)
			{
				T[] oldItems = items.ToArray();
				if (oldItems.Length < 1)
					return;

				OnItemsChanging();

				items.Sort(comparison);

				OnItemsChanged();
				OnCollectionReplace(0, oldItems, ToArray());
			}
			else
			{
				var tmp = new List<T>(items);

				tmp.Sort(comparison);

				Clear();
				AddRange(tmp);
			}
		}

		#endregion List

		#region INotifyCollectionChanged

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		private void OnCollectionAdd(int startIndex, params T[] newItems)
		{
			NotifyCollectionChanged(NotifyCollectionChangedAction.Add, startIndex, newItems);
		}

		private void OnCollectionRemove(int startIndex, params T[] oldItems)
		{
			NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, startIndex, oldItems);
		}

		private void NotifyCollectionChanged(NotifyCollectionChangedAction type, int startIndex, T[] items)
		{
			NotifyCollectionChangedEventHandler handler = CollectionChanged;
			if (handler != null)
				handler(this, new NotifyCollectionChangedEventArgs(type, items, startIndex));
		}

		private void OnCollectionReplace(int index, T oldItem, T newItem)
		{
			NotifyCollectionChangedEventHandler handler = CollectionChanged;
			if (handler != null)
				handler(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, //
				                                                   oldItem, newItem, index));
		}

		private void OnCollectionReplace(int index, T[] oldItems, T[] newItems)
		{
			NotifyCollectionChangedEventHandler handler = CollectionChanged;
			if (handler != null)
				handler(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, //
				                                                   oldItems, newItems, index));
		}

		#endregion INotifyCollectionChanged

		private string NameOf<T>(Expression<Func<T>> property)
		{
			var lambda = (LambdaExpression) property;
			var memberExpression = (MemberExpression) lambda.Body;
			return memberExpression.Member.Name;
		}

		#region INotifyPropertyChanging

		public event PropertyChangingEventHandler PropertyChanging;

		private void OnCountChanging()
		{
			PropertyChangingEventHandler handler = PropertyChanging;
			if (handler != null)
				handler(this, new PropertyChangingEventArgs(NameOf(() => Count)));
		}

		private void OnItemsChanging()
		{
			PropertyChangingEventHandler handler = PropertyChanging;
			if (handler != null)
				handler(this, new PropertyChangingEventArgs(PROPERTIES.ITEMS));
		}

		#endregion INotifyPropertyChanging

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnCountChanged()
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(NameOf(() => Count)));
		}

		private void OnItemsChanged()
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(PROPERTIES.ITEMS));
		}

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
