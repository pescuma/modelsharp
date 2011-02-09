// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using org.pescuma.ModelSharp.Lib;
using System.Collections.Specialized;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.computeProperty
{

	[DataContract]
	[DebuggerDisplay("MyClass[X={X} Y={Y} Children={Children.Count}items]")]
	public abstract class BaseMyClass : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public const string X = "X";
			public const string Y = "Y";
			public const string LENGTH = "Length";
			public const string DUMMY = "Dummy";
			public const string SQUARED_LENGTH = "SquaredLength";
			public const string SQUARED_LENGTH_CACHED = "SquaredLengthCached";
			public const string CHILDREN = "Children";
		}
		
		#endregion
		
		#region Constructors
		
		public BaseMyClass()
		{
			_y = 2;
			_children = new ObservableList<MyClass>();
			AddChildrenListListeners(_children);
		}
		
		public BaseMyClass(BaseMyClass other)
		{
			_x = other.X;
			_y = other.Y;
			_children = new ObservableList<MyClass>(other.Children);
			AddChildrenListListeners(_children);
		}
		
		#endregion
		
		#region Property X
		
		[DataMember(Name = "X", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _x;
		
		public double X
		{
			[DebuggerStepThrough]
			get {
				return GetX();
			}
			[DebuggerStepThrough]
			set {
				SetX(value);
			}
		}
		
		protected virtual double GetX()
		{
			return _x;
		}
		
		protected virtual bool SetX(double x)
		{
			if (_x == x)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.X);
			
			_x = x;
			
			NotifyPropertyChanged(PROPERTIES.X);
			
			return true;
		}
		
		#endregion Property X
		
		#region Property Y
		
		[DataMember(Name = "Y", Order = 1, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _y;
		
		public double Y
		{
			[DebuggerStepThrough]
			get {
				return GetY();
			}
			[DebuggerStepThrough]
			set {
				SetY(value);
			}
		}
		
		protected virtual double GetY()
		{
			return _y;
		}
		
		protected virtual bool SetY(double y)
		{
			if (_y == y)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.Y);
			
			_y = y;
			
			NotifyPropertyChanged(PROPERTIES.Y);
			
			return true;
		}
		
		#endregion Property Y
		
		#region Property Length
		
		public double Length
		{
			[DebuggerStepThrough]
			get {
				return ComputeLength();
			}
		}
		
		protected virtual double ComputeLength()
		{
			return Math.Sqrt(X * X + Y * Y);
		}
		
		#endregion Property Length
		
		#region Property Dummy
		
		public string Dummy
		{
			[DebuggerStepThrough]
			get {
				return ComputeDummy();
			}
		}
		
		protected abstract string ComputeDummy();
		
		#endregion Property Dummy
		
		#region Property SquaredLength
		
		public double SquaredLength
		{
			[DebuggerStepThrough]
			get {
				return ComputeSquaredLength();
			}
		}
		
		protected abstract double ComputeSquaredLength();
		
		#endregion Property SquaredLength
		
		#region Property SquaredLengthCached
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _squaredLengthCachedCache;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _squaredLengthCachedCacheValid;
		
		public double SquaredLengthCached
		{
			[DebuggerStepThrough]
			get {
				return ComputeAndCacheSquaredLengthCached();
			}
		}
		
		protected virtual void InvalidateSquaredLengthCachedCache()
		{
			_squaredLengthCachedCacheValid = false;
		}
		
		private double ComputeAndCacheSquaredLengthCached()
		{
			if (!_squaredLengthCachedCacheValid)
			{
				_squaredLengthCachedCache = ComputeSquaredLengthCached();
				_squaredLengthCachedCacheValid = true;
			}
			
			return _squaredLengthCachedCache;
		}
		
		protected abstract double ComputeSquaredLengthCached();
		
		#endregion Property SquaredLengthCached
		
		#region Property Children
		
		[DataMember(Name = "Children", Order = 2, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ObservableList<MyClass> _children;
		
		public ObservableList<MyClass> Children
		{
			[DebuggerStepThrough]
			get {
				return GetChildren();
			}
		}
		
		protected virtual ObservableList<MyClass> GetChildren()
		{
			return _children;
		}
		
		private void AddChildrenListListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += ChildrenListPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += ChildrenListPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyCollectionChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.CollectionChanged += ChildrenListChangedEventHandler;
		}
		
		private void ChildrenListPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName != ObservableList<MyClass>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanging(PROPERTIES.CHILDREN);
		}
		
		private void ChildrenListPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != ObservableList<MyClass>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanged(PROPERTIES.CHILDREN);
		}
		
		private void ChildrenListChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
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
							RemoveChildrenItemListeners(item);
							
					if (e.NewItems != null)
						foreach (var item in e.NewItems)
							AddChildrenItemListeners(item);
							
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
		
		private void RemoveChildrenItemListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= ChildrenItemPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= ChildrenItemChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= ChildrenItemPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= ChildrenItemChildPropertyChangedEventHandler;
		}
		
		private void AddChildrenItemListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += ChildrenItemPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += ChildrenItemChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += ChildrenItemPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += ChildrenItemChildPropertyChangedEventHandler;
		}
		
		private void ChildrenItemPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.CHILDREN, sender, e);
		}
		
		private void ChildrenItemChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.CHILDREN, sender, e);
		}
		
		private void ChildrenItemPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.CHILDREN, sender, e);
		}
		
		private void ChildrenItemChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.CHILDREN, sender, e);
		}
		
		#endregion Property Children
		
		public virtual void CopyFrom(MyClass other)
		{
			X = other.X;
			Y = other.Y;
			Children.Clear();
			Children.AddRange(other.Children);
		}
		
		#region Property Notification
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		protected virtual void NotifyPropertyChanging(string propertyName)
		{
			PropertyChangingEventHandler handler = PropertyChanging;
			if (handler != null)
				handler(this, new PropertyChangingEventArgs(propertyName));
				
			if (propertyName == PROPERTIES.X)
			{
				NotifyPropertyChanging(PROPERTIES.LENGTH);
				NotifyPropertyChanging(PROPERTIES.SQUARED_LENGTH);
				NotifyPropertyChanging(PROPERTIES.SQUARED_LENGTH_CACHED);
			}
			else if (propertyName == PROPERTIES.Y)
			{
				NotifyPropertyChanging(PROPERTIES.LENGTH);
				NotifyPropertyChanging(PROPERTIES.SQUARED_LENGTH);
				NotifyPropertyChanging(PROPERTIES.SQUARED_LENGTH_CACHED);
			}
			else if (propertyName == PROPERTIES.CHILDREN)
			{
				NotifyPropertyChanging(PROPERTIES.SQUARED_LENGTH);
			}
		}
		
		public event ChildPropertyChangingEventHandler ChildPropertyChanging;
		
		protected virtual void NotifyChildPropertyChanging(string propertyName, object sender, PropertyChangingEventArgs e)
		{
			ChildPropertyChangingEventHandler handler = ChildPropertyChanging;
			if (handler != null)
				handler(sender, new ChildPropertyChangingEventArgs(this, propertyName, e));
				
			if (propertyName == PROPERTIES.X)
			{
				NotifyPropertyChanging(PROPERTIES.LENGTH);
				NotifyPropertyChanging(PROPERTIES.SQUARED_LENGTH);
				NotifyPropertyChanging(PROPERTIES.SQUARED_LENGTH_CACHED);
			}
			else if (propertyName == PROPERTIES.Y)
			{
				NotifyPropertyChanging(PROPERTIES.LENGTH);
				NotifyPropertyChanging(PROPERTIES.SQUARED_LENGTH);
				NotifyPropertyChanging(PROPERTIES.SQUARED_LENGTH_CACHED);
			}
			else if (propertyName == PROPERTIES.CHILDREN)
			{
				NotifyPropertyChanging(PROPERTIES.SQUARED_LENGTH);
			}
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void NotifyPropertyChanged(string propertyName)
		{
			if (propertyName == PROPERTIES.X)
			{
				InvalidateSquaredLengthCachedCache();
			}
			else if (propertyName == PROPERTIES.Y)
			{
				InvalidateSquaredLengthCachedCache();
			}
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
				
			if (propertyName == PROPERTIES.X)
			{
				NotifyPropertyChanged(PROPERTIES.LENGTH);
				NotifyPropertyChanged(PROPERTIES.SQUARED_LENGTH);
				NotifyPropertyChanged(PROPERTIES.SQUARED_LENGTH_CACHED);
			}
			else if (propertyName == PROPERTIES.Y)
			{
				NotifyPropertyChanged(PROPERTIES.LENGTH);
				NotifyPropertyChanged(PROPERTIES.SQUARED_LENGTH);
				NotifyPropertyChanged(PROPERTIES.SQUARED_LENGTH_CACHED);
			}
			else if (propertyName == PROPERTIES.CHILDREN)
			{
				NotifyPropertyChanged(PROPERTIES.SQUARED_LENGTH);
			}
		}
		
		public event ChildPropertyChangedEventHandler ChildPropertyChanged;
		
		protected virtual void NotifyChildPropertyChanged(string propertyName, object sender, PropertyChangedEventArgs e)
		{
			if (propertyName == PROPERTIES.X)
			{
				InvalidateSquaredLengthCachedCache();
			}
			else if (propertyName == PROPERTIES.Y)
			{
				InvalidateSquaredLengthCachedCache();
			}
			ChildPropertyChangedEventHandler handler = ChildPropertyChanged;
			if (handler != null)
				handler(sender, new ChildPropertyChangedEventArgs(this, propertyName, e));
				
			if (propertyName == PROPERTIES.X)
			{
				NotifyPropertyChanged(PROPERTIES.LENGTH);
				NotifyPropertyChanged(PROPERTIES.SQUARED_LENGTH);
				NotifyPropertyChanged(PROPERTIES.SQUARED_LENGTH_CACHED);
			}
			else if (propertyName == PROPERTIES.Y)
			{
				NotifyPropertyChanged(PROPERTIES.LENGTH);
				NotifyPropertyChanged(PROPERTIES.SQUARED_LENGTH);
				NotifyPropertyChanged(PROPERTIES.SQUARED_LENGTH_CACHED);
			}
			else if (propertyName == PROPERTIES.CHILDREN)
			{
				NotifyPropertyChanged(PROPERTIES.SQUARED_LENGTH);
			}
		}
		
		#endregion
		
		#region Clone
		
		public new MyClass Clone()
		{
			return (MyClass) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new MyClass((MyClass) this);
		}
		
		#endregion
	}
	
}
