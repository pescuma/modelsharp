// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.simple
{

	[DataContract]
	[DebuggerDisplay("Point[X={X} Y={Y}]")]
	public abstract class BasePoint : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public const string X = "X";
			public const string Y = "Y";
		}
		
		#endregion
		
		#region Constructors
		
		public BasePoint()
		{
			this.y = 2;
		}
		
		public BasePoint(BasePoint other)
		{
			this.x = other.X;
			this.y = other.Y;
		}
		
		#endregion
		
		#region Property X
		
		[DataMember(Name = "X", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double x;
		
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
			return this.x;
		}
		
		protected virtual bool SetX(double x)
		{
			if (this.x == x)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.X);
			
			this.x = x;
			
			NotifyPropertyChanged(PROPERTIES.X);
			
			return true;
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
		
		protected virtual double GetY()
		{
			return this.y;
		}
		
		protected virtual bool SetY(double y)
		{
			if (this.y == y)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.Y);
			
			this.y = y;
			
			NotifyPropertyChanged(PROPERTIES.Y);
			
			return true;
		}
		
		#endregion Property Y
		
		public virtual void CopyFrom(Point other)
		{
			X = other.X;
			Y = other.Y;
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
				handler(sender, new ChildPropertyChangedEventArgs(this, propertyName, sender, e));
		}
		
		#endregion
		
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
		
		#endregion
	}
	
}
