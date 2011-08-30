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

namespace examples.receiveInConstructor
{

	[DataContract]
	[DebuggerDisplay("Address[Street={Street} City={City} ZipCode={ZipCode}]")]
	[GeneratedCode("Model#", "0.2.1.0")]
	public abstract class BaseAddress : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable, ICopyable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public static readonly string STREET = ModelUtils.NameOfProperty((BaseAddress o) => o.Street);
			public static readonly string CITY = ModelUtils.NameOfProperty((BaseAddress o) => o.City);
			public static readonly string ZIP_CODE = ModelUtils.NameOfProperty((BaseAddress o) => o.ZipCode);
			
			protected PROPERTIES() {}
		}
		
		#endregion
		
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
		
		[DebuggerStepThrough]
		protected virtual string GetStreet()
		{
			return this.street;
		}
		
		[DebuggerStepThrough]
		protected virtual bool SetStreet(string street)
		{
			if (this.street == street)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.STREET);
			
			this.street = street;
			
			NotifyPropertyChanged(PROPERTIES.STREET);
			
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
		
		[DebuggerStepThrough]
		protected virtual string GetCity()
		{
			return this.city;
		}
		
		[DebuggerStepThrough]
		protected virtual bool SetCity(string city)
		{
			if (this.city == city)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.CITY);
			
			this.city = city;
			
			NotifyPropertyChanged(PROPERTIES.CITY);
			
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
		
		[DebuggerStepThrough]
		protected virtual string GetZipCode()
		{
			return this.zipCode;
		}
		
		[DebuggerStepThrough]
		protected virtual bool SetZipCode(string zipCode)
		{
			if (this.zipCode == zipCode)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.ZIP_CODE);
			
			this.zipCode = zipCode;
			
			NotifyPropertyChanged(PROPERTIES.ZIP_CODE);
			
			return true;
		}
		
		#endregion Property ZipCode
		
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
