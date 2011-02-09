// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.composition
{

	[DataContract]
	[DebuggerDisplay("Person[]")]
	public abstract class BasePerson : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public const string HOME_ADDRESS = "HomeAddress";
			public const string WORK_ADDRESS = "WorkAddress";
		}
		
		#endregion
		
		#region Constructors
		
		public BasePerson()
		{
			_homeAddress = new Address();
			AddHomeAddressListeners(_homeAddress);
			_workAddress = new Address();
			AddWorkAddressListeners(_workAddress);
		}
		
		public BasePerson(BasePerson other)
		{
			_homeAddress = new Address(other.HomeAddress);
			AddHomeAddressListeners(_homeAddress);
			_workAddress = new Address(other.WorkAddress);
			AddWorkAddressListeners(_workAddress);
		}
		
		#endregion
		
		#region Property HomeAddress
		
		[DataMember(Name = "HomeAddress", Order = 0, IsRequired = true)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Address _homeAddress;
		
		public Address HomeAddress
		{
			[DebuggerStepThrough]
			get {
				return GetHomeAddress();
			}
		}
		
		protected virtual Address GetHomeAddress()
		{
			return _homeAddress;
		}
		
		private void AddHomeAddressListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += HomeAddressPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += HomeAddressChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += HomeAddressPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += HomeAddressChildPropertyChangedEventHandler;
		}
		
		private void HomeAddressPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.HOME_ADDRESS, sender, e);
		}
		
		private void HomeAddressChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.HOME_ADDRESS, sender, e);
		}
		
		private void HomeAddressPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.HOME_ADDRESS, sender, e);
		}
		
		private void HomeAddressChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.HOME_ADDRESS, sender, e);
		}
		
		#endregion Property HomeAddress
		
		#region Property WorkAddress
		
		[DataMember(Name = "WorkAddress", Order = 1, IsRequired = true)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Address _workAddress;
		
		public Address WorkAddress
		{
			[DebuggerStepThrough]
			get {
				return GetWorkAddress();
			}
		}
		
		protected virtual Address GetWorkAddress()
		{
			return _workAddress;
		}
		
		private void AddWorkAddressListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += WorkAddressPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += WorkAddressChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += WorkAddressPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += WorkAddressChildPropertyChangedEventHandler;
		}
		
		private void WorkAddressPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.WORK_ADDRESS, sender, e);
		}
		
		private void WorkAddressChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.WORK_ADDRESS, sender, e);
		}
		
		private void WorkAddressPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.WORK_ADDRESS, sender, e);
		}
		
		private void WorkAddressChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.WORK_ADDRESS, sender, e);
		}
		
		#endregion Property WorkAddress
		
		public virtual void CopyFrom(Person other)
		{
			HomeAddress.CopyFrom(other.HomeAddress);
			WorkAddress.CopyFrom(other.WorkAddress);
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
		
		public new Person Clone()
		{
			return (Person) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new Person((Person) this);
		}
		
		#endregion
	}
	
}
