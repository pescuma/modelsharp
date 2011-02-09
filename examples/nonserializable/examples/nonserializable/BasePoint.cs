// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Diagnostics;

namespace examples.nonserializable
{

	[DebuggerDisplay("Point[X={X} Y={Y} A={A}]")]
	public abstract class BasePoint : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public const string X = "X";
			public const string Y = "Y";
			public const string A = "A";
		}
		
		#endregion
		
		#region Constructors
		
		public BasePoint()
		{
			_y = 2;
			_a = new Point(2, 3);
			AddAListeners(_a);
		}
		
		public BasePoint(BasePoint other)
		{
			_x = other.X;
			_y = other.Y;
			_a = other.A;
			AddAListeners(_a);
		}
		
		#endregion
		
		#region Property X
		
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
		
		#region Property A
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Point _a;
		
		public Point A
		{
			[DebuggerStepThrough]
			get {
				return GetA();
			}
			[DebuggerStepThrough]
			set {
				SetA(value);
			}
		}
		
		protected virtual Point GetA()
		{
			return _a;
		}
		
		protected virtual bool SetA(Point a)
		{
			if (_a == a)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.A);
			
			RemoveAListeners(a);
			
			_a = a;
			
			AddAListeners(a);
			
			NotifyPropertyChanged(PROPERTIES.A);
			
			return true;
		}
		
		private void RemoveAListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= APropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= AChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= APropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= AChildPropertyChangedEventHandler;
		}
		
		private void AddAListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += APropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += AChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += APropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += AChildPropertyChangedEventHandler;
		}
		
		private void APropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.A, sender, e);
		}
		
		private void AChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.A, sender, e);
		}
		
		private void APropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.A, sender, e);
		}
		
		private void AChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.A, sender, e);
		}
		
		#endregion Property A
		
		public virtual void CopyFrom(Point other)
		{
			X = other.X;
			Y = other.Y;
			A = other.A;
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
		
		public new Point Clone()
		{
			return (Point) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new Point((Point) this);
		}
		
		#endregion
	}
	
}
