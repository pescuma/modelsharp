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

namespace examples.projectNamespace
{

	[DataContract]
	[DebuggerDisplay("Person[Name={Name}]")]
	[GeneratedCode("Model#", "0.2.1.0")]
	public abstract class BasePerson : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable, ICopyable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public static readonly string NAME = ModelUtils.NameOfProperty((BasePerson o) => o.Name);
			
			protected PROPERTIES() {}
		}
		
		#endregion
		
		#region Constructors
		
		protected BasePerson()
		{
		}
		
		protected BasePerson(BasePerson other)
		{
			this.name = other.Name;
		}
		
		#endregion Constructors
		
		#region Property Name
		
		[DataMember(Name = "Name", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name;
		
		public string Name
		{
			[DebuggerStepThrough]
			get {
				return GetName();
			}
			[DebuggerStepThrough]
			set {
				SetName(value);
			}
		}
		
		[DebuggerStepThrough]
		protected virtual string GetName()
		{
			return this.name;
		}
		
		[DebuggerStepThrough]
		protected virtual bool SetName(string name)
		{
			if (this.name == name)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.NAME);
			
			this.name = name;
			
			NotifyPropertyChanged(PROPERTIES.NAME);
			
			return true;
		}
		
		#endregion Property Name
		
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
			CopyFrom((Person) other);
		}
		
		public virtual void CopyFrom(Person other)
		{
			Name = other.Name;
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
	}
	
}
