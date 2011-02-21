// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using org.pescuma.ModelSharp.Lib;
using System.Collections.Specialized;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.lazy
{

	[DataContract]
	[DebuggerDisplay("Type1[Prop1={Prop1} Col1={Col1.Count}items]")]
	public abstract class BaseType1 : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public const string PROP1 = "Prop1";
			public const string COMP1 = "Comp1";
			public const string COL1 = "Col1";
		}
		
		#endregion
		
		#region Constructors
		
		public BaseType1()
		{
			AddProp1Listeners(_prop1);
		}
		
		public BaseType1(BaseType1 other)
		{
			_prop1 = new Type2(other.Prop1);
			AddProp1Listeners(_prop1);
			if (other._comp1 != null)
			{
				_comp1 = new Type2(other.Comp1);
				AddComp1Listeners(_comp1);
			}
			if (other._col1 != null)
			{
				_col1 = new ObservableList<Type2>();
				AddCol1ListListeners(_col1);
				foreach (Type2 otherItem in other.Col1)
					_col1.Add(new Type2(otherItem));
			}
		}
		
		#endregion
		
		#region Property Prop1
		
		[DataMember(Name = "Prop1", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Type2 _prop1;
		
		public Type2 Prop1
		{
			[DebuggerStepThrough]
			get {
				return GetProp1();
			}
			[DebuggerStepThrough]
			set {
				SetProp1(value);
			}
		}
		
		protected virtual Type2 GetProp1()
		{
			return _prop1;
		}
		
		protected virtual bool SetProp1(Type2 prop1)
		{
			if (_prop1 == prop1)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.PROP1);
			
			RemoveProp1Listeners(prop1);
			
			_prop1 = prop1;
			
			AddProp1Listeners(prop1);
			
			NotifyPropertyChanged(PROPERTIES.PROP1);
			
			return true;
		}
		
		private void RemoveProp1Listeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= Prop1PropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= Prop1ChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= Prop1PropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= Prop1ChildPropertyChangedEventHandler;
		}
		
		private void AddProp1Listeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += Prop1PropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += Prop1ChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += Prop1PropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += Prop1ChildPropertyChangedEventHandler;
		}
		
		private void Prop1PropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.PROP1, sender, e);
		}
		
		private void Prop1ChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.PROP1, sender, e);
		}
		
		private void Prop1PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.PROP1, sender, e);
		}
		
		private void Prop1ChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.PROP1, sender, e);
		}
		
		#endregion Property Prop1
		
		#region Property Comp1
		
		[DataMember(Name = "Comp1", Order = 1, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Type2 _comp1;
		
		public Type2 Comp1
		{
			[DebuggerStepThrough]
			get {
				return GetComp1();
			}
		}
		
		protected virtual void LazyInitComp1()
		{
			if (_comp1 != null)
				return;
				
			_comp1 = new Type2();
			AddComp1Listeners(_comp1);
		}
		
		protected virtual Type2 GetComp1()
		{
			LazyInitComp1();
			return _comp1;
		}
		
		private void AddComp1Listeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += Comp1PropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += Comp1ChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += Comp1PropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += Comp1ChildPropertyChangedEventHandler;
		}
		
		private void Comp1PropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.COMP1, sender, e);
		}
		
		private void Comp1ChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.COMP1, sender, e);
		}
		
		private void Comp1PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.COMP1, sender, e);
		}
		
		private void Comp1ChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.COMP1, sender, e);
		}
		
		#endregion Property Comp1
		
		#region Property Col1
		
		[DataMember(Name = "Col1", Order = 2, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableList<Type2> _col1;
		
		public ObservableList<Type2> Col1
		{
			[DebuggerStepThrough]
			get {
				return GetCol1();
			}
		}
		
		protected virtual void LazyInitCol1()
		{
			if (_col1 != null)
				return;
				
			_col1 = new ObservableList<Type2>();
			AddCol1ListListeners(_col1);
		}
		
		protected virtual ObservableList<Type2> GetCol1()
		{
			LazyInitCol1();
			return _col1;
		}
		
		private void AddCol1ListListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += Col1ListPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += Col1ListPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyCollectionChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.CollectionChanged += Col1ListChangedEventHandler;
		}
		
		private void Col1ListPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName != ObservableList<Type2>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanging(PROPERTIES.COL1);
		}
		
		private void Col1ListPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != ObservableList<Type2>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanged(PROPERTIES.COL1);
		}
		
		private void Col1ListChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
				case NotifyCollectionChangedAction.Remove:
				case NotifyCollectionChangedAction.Replace:
				
					if ((e.OldItems == null || e.OldItems.Count == 0)
					        && (e.NewItems == null || e.NewItems.Count == 0))
						throw new InvalidOperationException();
						
					if (e.OldItems != null)
						foreach (var item in e.OldItems)
							RemoveCol1ItemListeners(item);
							
					if (e.NewItems != null)
						foreach (var item in e.NewItems)
							AddCol1ItemListeners(item);
							
					break;
				case NotifyCollectionChangedAction.Move:
					// Do nothing
					break;
				default:
					// NotifyCollectionChangedAction.Reset: The list should not fire this or
					// we can't control the items
					throw new InvalidOperationException();
			}
		}
		
		private void RemoveCol1ItemListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= Col1ItemPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= Col1ItemChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= Col1ItemPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= Col1ItemChildPropertyChangedEventHandler;
		}
		
		private void AddCol1ItemListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += Col1ItemPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += Col1ItemChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += Col1ItemPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += Col1ItemChildPropertyChangedEventHandler;
		}
		
		private void Col1ItemPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.COL1, sender, e);
		}
		
		private void Col1ItemChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.COL1, sender, e);
		}
		
		private void Col1ItemPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.COL1, sender, e);
		}
		
		private void Col1ItemChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.COL1, sender, e);
		}
		
		#endregion Property Col1
		
		public virtual void CopyFrom(Type1 other)
		{
			Prop1 = new Type2(other.Prop1);
			if (other._comp1 != null)
			{
				Comp1.CopyFrom(other.Comp1);
			}
			else
			{
				if (_comp1 != null)
					_comp1.CopyFrom(new Type2());
			}
			if (other._col1 != null)
			{
				Col1.Clear();
				foreach (Type2 otherItem in other.Col1)
					Col1.Add(new Type2(otherItem));
			}
			else
			{
				if (_col1 != null)
					Col1.Clear();
			}
		}
		
		#region Property Notification
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		protected virtual void NotifyPropertyChanging(string propertyName)
		{
			PropertyChangingEventHandler handler = PropertyChanging;
			if (handler != null)
				handler(this, new PropertyChangingEventArgs(propertyName));
		}
		
		public event ChildPropertyChangingEventHandler ChildPropertyChanging;
		
		protected virtual void NotifyChildPropertyChanging(string propertyName, object sender, PropertyChangingEventArgs e)
		{
			ChildPropertyChangingEventHandler handler = ChildPropertyChanging;
			if (handler != null)
				handler(sender, new ChildPropertyChangingEventArgs(this, propertyName, e));
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void NotifyPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
		
		public event ChildPropertyChangedEventHandler ChildPropertyChanged;
		
		protected virtual void NotifyChildPropertyChanged(string propertyName, object sender, PropertyChangedEventArgs e)
		{
			ChildPropertyChangedEventHandler handler = ChildPropertyChanged;
			if (handler != null)
				handler(sender, new ChildPropertyChangedEventArgs(this, propertyName, e));
		}
		
		#endregion
		
		#region Clone
		
#pragma warning disable 109
		public new Type1 Clone()
#pragma warning restore 109
		{
			return (Type1) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new Type1((Type1) this);
		}
		
		#endregion
	}
	
}
