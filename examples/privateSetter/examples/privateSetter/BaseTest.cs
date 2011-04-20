// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.privateSetter
{

	[DataContract]
	[DebuggerDisplay("Test[Date={Date}]")]
	public abstract class BaseTest : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, IDeserializationCallback, ICloneable, ICopyable
	{
		#region Constructors
		
		protected BaseTest()
		{
			AddDateListeners(this.date);
		}
		
		protected BaseTest(BaseTest other)
		{
			this.date = other.Date;
			AddDateListeners(this.date);
		}
		
		#endregion Constructors
		
		#region Property Date
		
		[DataMember(Name = "Date", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime date;
		
		protected DateTime Date
		{
			[DebuggerStepThrough]
			get {
				return GetDate();
			}
			[DebuggerStepThrough]
			private set {
				SetDate(value);
			}
		}
		
		protected virtual DateTime GetDate()
		{
			return this.date;
		}
		
		protected virtual bool SetDate(DateTime date)
		{
			if (this.date == date)
				return false;
				
			NotifyPropertyChanging(() => Date);
			
			RemoveDateListeners(date);
			
			this.date = date;
			
			AddDateListeners(date);
			
			NotifyPropertyChanged(() => Date);
			
			return true;
		}
		
		private void RemoveDateListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= DatePropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= DateChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= DatePropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= DateChildPropertyChangedEventHandler;
		}
		
		private void AddDateListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += DatePropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += DateChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += DatePropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += DateChildPropertyChangedEventHandler;
		}
		
		private void DatePropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(() => Date, sender, e);
		}
		
		private void DateChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(() => Date, sender, e);
		}
		
		private void DatePropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(() => Date, sender, e);
		}
		
		private void DateChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(() => Date, sender, e);
		}
		
		#endregion Property Date
		
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
			CopyFrom((Test) other);
		}
		
		public virtual void CopyFrom(Test other)
		{
			Date = other.Date;
		}
		
		#endregion CopyFrom
		
		#region Clone
		
#pragma warning disable 109
		public new Test Clone()
#pragma warning restore 109
		{
			return (Test) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new Test((Test) this);
		}
		
		#endregion Clone
		
		#region Serialization
		
		void IDeserializationCallback.OnDeserialization(object sender)
		{
			AddDateListeners(this.date);
		}
		
		#endregion Serialization
	}
	
}
