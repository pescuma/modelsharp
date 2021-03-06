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

namespace examples.collection
{

	[DataContract]
	[DebuggerDisplay("House[Address={Address}]")]
	[GeneratedCode("Model#", "0.2.1.0")]
	public abstract class BaseHouse : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable, ICopyable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public static readonly string ADDRESS = ModelUtils.NameOfProperty((BaseHouse o) => o.Address);
			
			protected PROPERTIES() {}
		}
		
		#endregion
		
		#region Constructors
		
		protected BaseHouse()
		{
		}
		
		protected BaseHouse(BaseHouse other)
		{
			this.address = other.Address;
		}
		
		#endregion Constructors
		
		#region Property Address
		
		[DataMember(Name = "Address", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string address;
		
		public string Address
		{
			[DebuggerStepThrough]
			get {
				return GetAddress();
			}
			[DebuggerStepThrough]
			set {
				SetAddress(value);
			}
		}
		
		[DebuggerStepThrough]
		protected virtual string GetAddress()
		{
			return this.address;
		}
		
		[DebuggerStepThrough]
		protected virtual bool SetAddress(string address)
		{
			if (this.address == address)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.ADDRESS);
			
			this.address = address;
			
			NotifyPropertyChanged(PROPERTIES.ADDRESS);
			
			return true;
		}
		
		#endregion Property Address
		
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
			CopyFrom((House) other);
		}
		
		public virtual void CopyFrom(House other)
		{
			Address = other.Address;
		}
		
		#endregion CopyFrom
		
		#region Clone
		
#pragma warning disable 109
		public new House Clone()
#pragma warning restore 109
		{
			return (House) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new House((House) this);
		}
		
		#endregion Clone
	}
	
}
