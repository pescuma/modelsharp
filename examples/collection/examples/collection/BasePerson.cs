// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using org.pescuma.ModelSharp.Lib;
using System.Collections.Specialized;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.collection
{

	[DataContract]
	[DebuggerDisplay("Person[Cars={Cars.Count}items Name={Name} Houses={Houses.Count}items]")]
	public abstract class BasePerson : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, IDeserializationCallback, ICloneable, ICopyable
	{
		#region Constructors
		
		protected BasePerson()
		{
			this.cars = new ObservableList<string>();
			AddCarsListListeners(this.cars);
			this.houses = new ObservableList<House>();
			AddHousesListListeners(this.houses);
		}
		
		protected BasePerson(BasePerson other)
		{
			this.cars = new ObservableList<string>();
			AddCarsListListeners(this.cars);
			this.cars.AddRange(other.Cars);
			this.name = other.Name;
			this.houses = new ObservableList<House>();
			AddHousesListListeners(this.houses);
			this.houses.AddRange(other.Houses);
		}
		
		#endregion Constructors
		
		#region Property Cars
		
		[DataMember(Name = "Cars", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ObservableList<string> cars;
		
		public ObservableList<string> Cars
		{
			[DebuggerStepThrough]
			get {
				return GetCars();
			}
		}
		
		protected virtual ObservableList<string> GetCars()
		{
			return this.cars;
		}
		
		private void AddCarsListListeners(ObservableList<string> child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging += CarsListPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged += CarsListPropertyChangedEventHandler;
		}
		
		private void CarsListPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName != ObservableList<string>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanging(() => Cars);
		}
		
		private void CarsListPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != ObservableList<string>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanged(() => Cars);
		}
		
		#endregion Property Cars
		
		#region Property Name
		
		[DataMember(Name = "Name", Order = 1, IsRequired = false)]
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
		
		protected virtual string GetName()
		{
			return this.name;
		}
		
		protected virtual bool SetName(string name)
		{
			if (this.name == name)
				return false;
				
			NotifyPropertyChanging(() => Name);
			
			this.name = name;
			
			NotifyPropertyChanged(() => Name);
			
			return true;
		}
		
		#endregion Property Name
		
		#region Property Houses
		
		[DataMember(Name = "Houses", Order = 2, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ObservableList<House> houses;
		
		public ObservableList<House> Houses
		{
			[DebuggerStepThrough]
			get {
				return GetHouses();
			}
		}
		
		protected virtual ObservableList<House> GetHouses()
		{
			return this.houses;
		}
		
		private void AddHousesListListeners(ObservableList<House> child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging += HousesListPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged += HousesListPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyCollectionChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanged.CollectionChanged += HousesListChangedEventHandler;
				
			foreach (var item in child)
				AddHousesItemListeners(item);
		}
		
		private void HousesListPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName != ObservableList<House>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanging(() => Houses);
		}
		
		private void HousesListPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != ObservableList<House>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanged(() => Houses);
		}
		
		private void HousesListChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
				case NotifyCollectionChangedAction.Remove:
				case NotifyCollectionChangedAction.Replace:
				
					if ((e.OldItems == null || e.OldItems.Count == 0)
					        && (e.NewItems == null || e.NewItems.Count == 0))
						throw new InvalidOperationException();
						
					if (e.OldItems != null)
						foreach (var item in e.OldItems)
							RemoveHousesItemListeners(item);
							
					if (e.NewItems != null)
						foreach (var item in e.NewItems)
							AddHousesItemListeners(item);
							
					break;
				case NotifyCollectionChangedAction.Move:
					// Do nothing
					break;
				default:
					// NotifyCollectionChangedAction.Reset: The list should not fire this or
					// we can't control the items
					throw new InvalidOperationException();
			}
		}
		
		private void RemoveHousesItemListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging -= HousesItemPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanging.ChildPropertyChanging -= HousesItemChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged -= HousesItemPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanged.ChildPropertyChanged -= HousesItemChildPropertyChangedEventHandler;
		}
		
		private void AddHousesItemListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging += HousesItemPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanging.ChildPropertyChanging += HousesItemChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged += HousesItemPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanged.ChildPropertyChanged += HousesItemChildPropertyChangedEventHandler;
		}
		
		private void HousesItemPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(() => Houses, sender, e);
		}
		
		private void HousesItemChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(() => Houses, sender, e);
		}
		
		private void HousesItemPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(() => Houses, sender, e);
		}
		
		private void HousesItemChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(() => Houses, sender, e);
		}
		
		#endregion Property Houses
		
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
			Cars.Clear();
			Cars.AddRange(other.Cars);
			Name = other.Name;
			Houses.Clear();
			Houses.AddRange(other.Houses);
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
			AddCarsListListeners(this.cars);
			AddHousesListListeners(this.houses);
		}
		
		#endregion Serialization
	}
	
}
