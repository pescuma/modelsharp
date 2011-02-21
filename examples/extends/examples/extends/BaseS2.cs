// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.extends
{

	[DataContract]
	[DebuggerDisplay("S2[Date2={Date2}]")]
	public abstract class BaseS2 : String, INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public const string DATE2 = "Date2";
		}
		
		#endregion
		
		#region Constructors
		
		public BaseS2()
		{
			AddDate2Listeners(_date2);
		}
		
		public BaseS2(BaseS2 other)
		: base(other)
		{
			_date2 = new DateTime(other.Date2);
			AddDate2Listeners(_date2);
		}
		
		#endregion
		
		#region Property Date2
		
		[DataMember(Name = "Date2", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _date2;
		
		public DateTime Date2
		{
			[DebuggerStepThrough]
			get {
				return GetDate2();
			}
			[DebuggerStepThrough]
			set {
				SetDate2(value);
			}
		}
		
		protected virtual DateTime GetDate2()
		{
			return _date2;
		}
		
		protected virtual bool SetDate2(DateTime date2)
		{
			if (_date2 == date2)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.DATE2);
			
			RemoveDate2Listeners(date2);
			
			_date2 = date2;
			
			AddDate2Listeners(date2);
			
			NotifyPropertyChanged(PROPERTIES.DATE2);
			
			return true;
		}
		
		private void RemoveDate2Listeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= Date2PropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= Date2ChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= Date2PropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= Date2ChildPropertyChangedEventHandler;
		}
		
		private void AddDate2Listeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += Date2PropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += Date2ChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += Date2PropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += Date2ChildPropertyChangedEventHandler;
		}
		
		private void Date2PropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.DATE2, sender, e);
		}
		
		private void Date2ChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.DATE2, sender, e);
		}
		
		private void Date2PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.DATE2, sender, e);
		}
		
		private void Date2ChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.DATE2, sender, e);
		}
		
		#endregion Property Date2
		
		public virtual void CopyFrom(S2 other)
		{
			Date2 = new DateTime(other.Date2);
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
		public new S2 Clone()
#pragma warning restore 109
		{
			return (S2) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new S2((S2) this);
		}
		
		#endregion
	}
	
}
