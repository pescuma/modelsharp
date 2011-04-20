// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.receiveInConstructor
{

	[DataContract]
	[DebuggerDisplay("Person[WorkAddress={WorkAddress}]")]
	public abstract class BasePerson : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, IDeserializationCallback, ICloneable, ICopyable
	{
		#region Constructors
		
		protected BasePerson(Address homeAddress, Address workAddress)
		{
			if (homeAddress == null)
				throw new ArgumentNullException("homeAddress");
			this.homeAddress = homeAddress;
			AddHomeAddressListeners(this.homeAddress);
			this.workAddress = workAddress;
			AddWorkAddressListeners(this.workAddress);
		}
		
		protected BasePerson(BasePerson other)
		{
			this.homeAddress = new Address(other.HomeAddress);
			AddHomeAddressListeners(this.homeAddress);
			this.workAddress = other.WorkAddress;
			AddWorkAddressListeners(this.workAddress);
		}
		
		#endregion Constructors
		
		#region Property HomeAddress
		
		[DataMember(Name = "HomeAddress", Order = 0, IsRequired = true)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Address homeAddress;
		
		public Address HomeAddress
		{
			[DebuggerStepThrough]
			get {
				return GetHomeAddress();
			}
		}
		
		protected virtual Address GetHomeAddress()
		{
			return this.homeAddress;
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
			NotifyChildPropertyChanging(() => HomeAddress, sender, e);
		}
		
		private void HomeAddressChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(() => HomeAddress, sender, e);
		}
		
		private void HomeAddressPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(() => HomeAddress, sender, e);
		}
		
		private void HomeAddressChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(() => HomeAddress, sender, e);
		}
		
		#endregion Property HomeAddress
		
		#region Property WorkAddress
		
		[DataMember(Name = "WorkAddress", Order = 1, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Address workAddress;
		
		public Address WorkAddress
		{
			[DebuggerStepThrough]
			get {
				return GetWorkAddress();
			}
			[DebuggerStepThrough]
			set {
				SetWorkAddress(value);
			}
		}
		
		protected virtual Address GetWorkAddress()
		{
			return this.workAddress;
		}
		
		protected virtual bool SetWorkAddress(Address workAddress)
		{
			if (this.workAddress == workAddress)
				return false;
				
			NotifyPropertyChanging(() => WorkAddress);
			
			RemoveWorkAddressListeners(workAddress);
			
			this.workAddress = workAddress;
			
			AddWorkAddressListeners(workAddress);
			
			NotifyPropertyChanged(() => WorkAddress);
			
			return true;
		}
		
		private void RemoveWorkAddressListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= WorkAddressPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= WorkAddressChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= WorkAddressPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= WorkAddressChildPropertyChangedEventHandler;
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
			NotifyChildPropertyChanging(() => WorkAddress, sender, e);
		}
		
		private void WorkAddressChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(() => WorkAddress, sender, e);
		}
		
		private void WorkAddressPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(() => WorkAddress, sender, e);
		}
		
		private void WorkAddressChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(() => WorkAddress, sender, e);
		}
		
		#endregion Property WorkAddress
		
		#region Property Notification
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		protected virtual void NotifyPropertyChanging<T>(Expression<Func<T>> property)
		{
			string propertyName = ModelUtils.NameOfProperty(property);
			
			PropertyChangingEventHandler handler = PropertyChanging;
			if (handler != null)
				handler(this, new PropertyChangingEventArgs(propertyName));
		}
		
		public event ChildPropertyChangingEventHandler ChildPropertyChanging;
		
		protected virtual void NotifyChildPropertyChanging<T>(Expression<Func<T>> property, object sender, PropertyChangingEventArgs e)
		{
			string propertyName = ModelUtils.NameOfProperty(property);
			
			ChildPropertyChangingEventHandler handler = ChildPropertyChanging;
			if (handler != null)
				handler(sender, new ChildPropertyChangingEventArgs(this, propertyName, sender, e));
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void NotifyPropertyChanged<T>(Expression<Func<T>> property)
		{
			string propertyName = ModelUtils.NameOfProperty(property);
			
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
		
		public event ChildPropertyChangedEventHandler ChildPropertyChanged;
		
		protected virtual void NotifyChildPropertyChanged<T>(Expression<Func<T>> property, object sender, PropertyChangedEventArgs e)
		{
			string propertyName = ModelUtils.NameOfProperty(property);
			
			ChildPropertyChangedEventHandler handler = ChildPropertyChanged;
			if (handler != null)
				handler(sender, new ChildPropertyChangedEventArgs(this, propertyName, sender, e));
		}
		
		#endregion Property Notification
		
		#region CopyFrom
		
		void ICopyable.CopyFrom(object other)
		{
			CopyFrom((Person) other);
		}
		
		public virtual void CopyFrom(Person other)
		{
			HomeAddress.CopyFrom(other.HomeAddress);
			WorkAddress = other.WorkAddress;
		}
		
		#endregion CopyFrom
		
		#region Clone
		
#pragma warning disable 109
		public new Person Clone()
#pragma warning restore 109
		{
			return (Person) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new Person((Person) this);
		}
		
		#endregion Clone
		
		#region Serialization
		
		void IDeserializationCallback.OnDeserialization(object sender)
		{
			AddHomeAddressListeners(this.homeAddress);
			AddWorkAddressListeners(this.workAddress);
		}
		
		#endregion Serialization
	}
	
}