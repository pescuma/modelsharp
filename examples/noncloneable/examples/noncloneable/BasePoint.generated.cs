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

namespace examples.noncloneable
{

	[DataContract]
	[DebuggerDisplay("Point[X={X} Y={Y} A={A}]")]
	[GeneratedCode("Model#", "0.2.1.0")]
	public abstract class BasePoint : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged
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
			this.y = 2;
			this.a = new Point();
			AddAListeners(this.a);
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
			AddAListeners(this.a);
		}
		
		#endregion Serialization
	}
	
}
