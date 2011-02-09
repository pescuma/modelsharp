// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

[DataContract]
[DebuggerDisplay("Line[P1={P1} P2={P2}]")]
public abstract class BaseLine : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable
{
	#region Field Name Defines
	
	public class PROPERTIES
	{
		public const string P1 = "P1";
		public const string P2 = "P2";
	}
	
	#endregion
	
	#region Constructors
	
	public BaseLine()
	{
		AddP1Listeners(_p1);
		AddP2Listeners(_p2);
	}
	
	public BaseLine(BaseLine other)
	{
		_p1 = other.P1;
		AddP1Listeners(_p1);
		_p2 = other.P2;
		AddP2Listeners(_p2);
	}
	
	#endregion
	
	#region Property P1
	
	[DataMember(Name = "P1", Order = 0, IsRequired = false)]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point _p1;
	
	public Point P1
	{
		[DebuggerStepThrough]
		get {
			return GetP1();
		}
		[DebuggerStepThrough]
		set {
			SetP1(value);
		}
	}
	
	protected virtual Point GetP1()
	{
		return _p1;
	}
	
	protected virtual bool SetP1(Point p1)
	{
		if (_p1 == p1)
			return false;
			
		NotifyPropertyChanging(PROPERTIES.P1);
		
		RemoveP1Listeners(p1);
		
		_p1 = p1;
		
		AddP1Listeners(p1);
		
		NotifyPropertyChanged(PROPERTIES.P1);
		
		return true;
	}
	
	private void RemoveP1Listeners(object child)
	{
		if (child == null)
			return;
			
		var notifyPropertyChanging = child as INotifyPropertyChanging;
		if (notifyPropertyChanging != null)
			notifyPropertyChanging.PropertyChanging -= P1PropertyChangingEventHandler;
			
		var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
		if (notifyChildPropertyChanging != null)
			notifyChildPropertyChanging.ChildPropertyChanging -= P1ChildPropertyChangingEventHandler;
			
		var notifyPropertyChanged = child as INotifyPropertyChanged;
		if (notifyPropertyChanged != null)
			notifyPropertyChanged.PropertyChanged -= P1PropertyChangedEventHandler;
			
		var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
		if (notifyChildPropertyChanged != null)
			notifyChildPropertyChanged.ChildPropertyChanged -= P1ChildPropertyChangedEventHandler;
	}
	
	private void AddP1Listeners(object child)
	{
		if (child == null)
			return;
			
		var notifyPropertyChanging = child as INotifyPropertyChanging;
		if (notifyPropertyChanging != null)
			notifyPropertyChanging.PropertyChanging += P1PropertyChangingEventHandler;
			
		var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
		if (notifyChildPropertyChanging != null)
			notifyChildPropertyChanging.ChildPropertyChanging += P1ChildPropertyChangingEventHandler;
			
		var notifyPropertyChanged = child as INotifyPropertyChanged;
		if (notifyPropertyChanged != null)
			notifyPropertyChanged.PropertyChanged += P1PropertyChangedEventHandler;
			
		var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
		if (notifyChildPropertyChanged != null)
			notifyChildPropertyChanged.ChildPropertyChanged += P1ChildPropertyChangedEventHandler;
	}
	
	private void P1PropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
	{
		NotifyChildPropertyChanging(PROPERTIES.P1, sender, e);
	}
	
	private void P1ChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
	{
		NotifyChildPropertyChanging(PROPERTIES.P1, sender, e);
	}
	
	private void P1PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
	{
		NotifyChildPropertyChanged(PROPERTIES.P1, sender, e);
	}
	
	private void P1ChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
	{
		NotifyChildPropertyChanged(PROPERTIES.P1, sender, e);
	}
	
	#endregion Property P1
	
	#region Property P2
	
	[DataMember(Name = "P2", Order = 1, IsRequired = false)]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point _p2;
	
	public Point P2
	{
		[DebuggerStepThrough]
		get {
			return GetP2();
		}
		[DebuggerStepThrough]
		set {
			SetP2(value);
		}
	}
	
	protected virtual Point GetP2()
	{
		return _p2;
	}
	
	protected virtual bool SetP2(Point p2)
	{
		if (_p2 == p2)
			return false;
			
		NotifyPropertyChanging(PROPERTIES.P2);
		
		RemoveP2Listeners(p2);
		
		_p2 = p2;
		
		AddP2Listeners(p2);
		
		NotifyPropertyChanged(PROPERTIES.P2);
		
		return true;
	}
	
	private void RemoveP2Listeners(object child)
	{
		if (child == null)
			return;
			
		var notifyPropertyChanging = child as INotifyPropertyChanging;
		if (notifyPropertyChanging != null)
			notifyPropertyChanging.PropertyChanging -= P2PropertyChangingEventHandler;
			
		var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
		if (notifyChildPropertyChanging != null)
			notifyChildPropertyChanging.ChildPropertyChanging -= P2ChildPropertyChangingEventHandler;
			
		var notifyPropertyChanged = child as INotifyPropertyChanged;
		if (notifyPropertyChanged != null)
			notifyPropertyChanged.PropertyChanged -= P2PropertyChangedEventHandler;
			
		var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
		if (notifyChildPropertyChanged != null)
			notifyChildPropertyChanged.ChildPropertyChanged -= P2ChildPropertyChangedEventHandler;
	}
	
	private void AddP2Listeners(object child)
	{
		if (child == null)
			return;
			
		var notifyPropertyChanging = child as INotifyPropertyChanging;
		if (notifyPropertyChanging != null)
			notifyPropertyChanging.PropertyChanging += P2PropertyChangingEventHandler;
			
		var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
		if (notifyChildPropertyChanging != null)
			notifyChildPropertyChanging.ChildPropertyChanging += P2ChildPropertyChangingEventHandler;
			
		var notifyPropertyChanged = child as INotifyPropertyChanged;
		if (notifyPropertyChanged != null)
			notifyPropertyChanged.PropertyChanged += P2PropertyChangedEventHandler;
			
		var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
		if (notifyChildPropertyChanged != null)
			notifyChildPropertyChanged.ChildPropertyChanged += P2ChildPropertyChangedEventHandler;
	}
	
	private void P2PropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
	{
		NotifyChildPropertyChanging(PROPERTIES.P2, sender, e);
	}
	
	private void P2ChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
	{
		NotifyChildPropertyChanging(PROPERTIES.P2, sender, e);
	}
	
	private void P2PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
	{
		NotifyChildPropertyChanged(PROPERTIES.P2, sender, e);
	}
	
	private void P2ChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
	{
		NotifyChildPropertyChanged(PROPERTIES.P2, sender, e);
	}
	
	#endregion Property P2
	
	public virtual void CopyFrom(Line other)
	{
		P1 = other.P1;
		P2 = other.P2;
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
	
	public new Line Clone()
	{
		return (Line) ((ICloneable) this).Clone();
	}
	
	object ICloneable.Clone()
	{
		return new Line((Line) this);
	}
	
	#endregion
}
