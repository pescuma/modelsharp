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

namespace examples.config1
{

	[DataContract(Namespace = "data")]
	[DebuggerDisplay("Point[X={X} Y={Y}]")]
	[GeneratedCode("Model#", "0.2.1.0")]
	public abstract class BasePoint : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable, ICopyable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public static readonly string X = ModelUtils.NameOfProperty((BasePoint o) => o.X);
			public static readonly string Y = ModelUtils.NameOfProperty((BasePoint o) => o.Y);
			
			protected PROPERTIES() {}
		}
		
		#endregion
		
		#region Constructors
		
		protected BasePoint()
		{
			this.y = 2;
		}
		
		protected BasePoint(BasePoint other)
		{
			this.x = other.X;
			this.y = other.Y;
		}
		
		#endregion Constructors
		
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
		
		[DebuggerStepThrough]
		protected virtual double GetX()
		{
			return this.x;
		}
		
		[DebuggerStepThrough]
		protected virtual bool SetX(double x)
		{
			if (Math.Abs(this.x - x) < 1E-06)
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
		}
		
		#endregion Serialization
	}
	
}
