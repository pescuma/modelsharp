//----------------------
// <auto-generated>
//     Automatically generated by Model#
// </auto-generated>
//----------------------
// DO NOT EDIT THIS FILE

using System.CodeDom.Compiler;
using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.equals
{

	[DataContract]
	[DebuggerDisplay("Point[X={X} Y={Y} A={A}]")]
	[GeneratedCode("Model#", "0.2.1.0")]
	public abstract class BasePoint : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable, ICopyable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public static readonly string X = ModelUtils.NameOfProperty((BasePoint o) => o.X);
			public static readonly string Y = ModelUtils.NameOfProperty((BasePoint o) => o.Y);
			public static readonly string A = ModelUtils.NameOfProperty((BasePoint o) => o.A);
			
			protected PROPERTIES() {}
		}
		
		#endregion
		
		#region Constructors
		
		protected BasePoint()
		{
			AddXListeners(this.x);
			this.y = 2;
			this.a = new Point();
			AddAListeners(this.a);
		}
		
		protected BasePoint(BasePoint other)
		{
			this.x = other.X;
			AddXListeners(this.x);
			this.y = other.Y;
			this.a = other.A;
			AddAListeners(this.a);
		}
		
		#endregion Constructors
		
		#region Property X
		
		[DataMember(Name = "X", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double? x;
		
		public double? X
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
		
		[DebuggerStepThrough]
		protected virtual double? GetX()
		{
			return this.x;
		}
		
		[DebuggerStepThrough]
		protected virtual bool SetX(double? x)
		{
			if (this.x == null && x == null)
				return false;
			if (this.x != null && x != null && Math.Abs((double) this.x - (double) x) < 1E-06)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.X);
			
			RemoveXListeners(this.x);
			
			this.x = x;
			
			AddXListeners(this.x);
			
			NotifyPropertyChanged(PROPERTIES.X);
			
			return true;
		}
		
		private void RemoveXListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= XPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= XChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= XPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= XChildPropertyChangedEventHandler;
		}
		
		private void AddXListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += XPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += XChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += XPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += XChildPropertyChangedEventHandler;
		}
		
		private void XPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.X, sender, e);
		}
		
		private void XChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.X, sender, e);
		}
		
		private void XPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.X, sender, e);
		}
		
		private void XChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.X, sender, e);
		}
		
		#endregion Property X
		
		#region Property Y
		
		[DataMember(Name = "Y", Order = 1, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double y;
		
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
		
		[DebuggerStepThrough]
		protected virtual double GetY()
		{
			return this.y;
		}
		
		[DebuggerStepThrough]
		protected virtual bool SetY(double y)
		{
			if (Math.Abs(this.y - y) < 1E-06)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.Y);
			
			this.y = y;
			
			NotifyPropertyChanged(PROPERTIES.Y);
			
			return true;
		}
		
		#endregion Property Y
		
		#region Property A
		
		[DataMember(Name = "A", Order = 2, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Point a;
		
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
		
		[DebuggerStepThrough]
		protected virtual Point GetA()
		{
			return this.a;
		}
		
		[DebuggerStepThrough]
		protected virtual bool SetA(Point a)
		{
			if (this.a == a)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.A);
			
			RemoveAListeners(this.a);
			
			this.a = a;
			
			AddAListeners(this.a);
			
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
				handler(sender, new ChildPropertyChangingEventArgs(this, propertyName, sender, e));
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
				handler(sender, new ChildPropertyChangedEventArgs(this, propertyName, sender, e));
		}
		
		#endregion Property Notification
		
		#region CopyFrom
		
		void ICopyable.CopyFrom(object other)
		{
			CopyFrom((Point) other);
		}
		
		public virtual void CopyFrom(Point other)
		{
			X = other.X;
			Y = other.Y;
			A = other.A;
		}
		
		#endregion CopyFrom
		
		#region Clone
		
#pragma warning disable 109
		public new Point Clone()
#pragma warning restore 109
		{
			return (Point) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new Point((Point) this);
		}
		
		#endregion Clone
		
		#region Serialization
		
		[OnDeserializing]
		private void OnDeserializing(StreamingContext context)
		{
			this.y = 2;
			this.a = new Point();
		}
		
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			AddXListeners(this.x);
			AddAListeners(this.a);
		}
		
		#endregion Serialization
		
		#region Equals
		
		public bool Equals(Point other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return ((X == null && other.X == null) || (X != null && other.X != null && Math.Abs((double) X - (double) other.X) < 1E-06))
			       && Math.Abs(Y - other.Y) < 1E-06
			       && Equals(A, other.A)
			       ;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Point)) return false;
			return Equals((Point) obj);
		}
		
		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				result = (result * 397) ^ (X != null ? X.GetHashCode() : 0);
				result = (result * 397) ^ Y.GetHashCode();
				result = (result * 397) ^ (A != null ? A.GetHashCode() : 0);
				return result;
			}
		}
		
		public static bool operator ==(BasePoint left, BasePoint right)
		{
			return Equals(left, right);
		}
		
		public static bool operator !=(BasePoint left, BasePoint right)
		{
			return !Equals(left, right);
		}
		
		#endregion Equals
	}
	
}
