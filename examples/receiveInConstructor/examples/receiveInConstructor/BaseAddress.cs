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
	[DebuggerDisplay("Address[Street={Street} City={City} ZipCode={ZipCode}]")]
	public abstract class BaseAddress : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable, ICopyable
	{
		#region Constructors
		
		protected BaseAddress()
		{
		}
		
		protected BaseAddress(BaseAddress other)
		{
			this.street = other.Street;
			this.city = other.City;
			this.zipCode = other.ZipCode;
		}
		
		#endregion Constructors
		
		#region Property Street
		
		[DataMember(Name = "Street", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string street;
		
		public string Street
		{
			[DebuggerStepThrough]
			get {
				return GetStreet();
			}
			[DebuggerStepThrough]
			set {
				SetStreet(value);
			}
		}
		
		protected virtual string GetStreet()
		{
			return this.street;
		}
		
		protected virtual bool SetStreet(string street)
		{
			if (this.street == street)
				return false;
				
			NotifyPropertyChanging(() => Street);
			
			this.street = street;
			
			NotifyPropertyChanged(() => Street);
			
			return true;
		}
		
		#endregion Property Street
		
		#region Property City
		
		[DataMember(Name = "City", Order = 1, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string city;
		
		public string City
		{
			[DebuggerStepThrough]
			get {
				return GetCity();
			}
			[DebuggerStepThrough]
			set {
				SetCity(value);
			}
		}
		
		protected virtual string GetCity()
		{
			return this.city;
		}
		
		protected virtual bool SetCity(string city)
		{
			if (this.city == city)
				return false;
				
			NotifyPropertyChanging(() => City);
			
			this.city = city;
			
			NotifyPropertyChanged(() => City);
			
			return true;
		}
		
		#endregion Property City
		
		#region Property ZipCode
		
		[DataMember(Name = "ZipCode", Order = 2, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string zipCode;
		
		public string ZipCode
		{
			[DebuggerStepThrough]
			get {
				return GetZipCode();
			}
			[DebuggerStepThrough]
			set {
				SetZipCode(value);
			}
		}
		
		protected virtual string GetZipCode()
		{
			return this.zipCode;
		}
		
		protected virtual bool SetZipCode(string zipCode)
		{
			if (this.zipCode == zipCode)
				return false;
				
			NotifyPropertyChanging(() => ZipCode);
			
			this.zipCode = zipCode;
			
			NotifyPropertyChanged(() => ZipCode);
			
			return true;
		}
		
		#endregion Property ZipCode
		
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
			CopyFrom((Address) other);
		}
		
		public virtual void CopyFrom(Address other)
		{
			Street = other.Street;
			City = other.City;
			ZipCode = other.ZipCode;
		}
		
		#endregion CopyFrom
		
		#region Clone
		
#pragma warning disable 109
		public new Address Clone()
#pragma warning restore 109
		{
			return (Address) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new Address((Address) this);
		}
		
		#endregion Clone
	}
	
}