//----------------------
// <auto-generated>
//     Automatically generated by Model#
// </auto-generated>
//----------------------
// DO NOT EDIT THIS FILE

using System.CodeDom.Compiler;
using org.pescuma.ModelSharp.Lib;
using System.Collections.Specialized;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.equals
{

	[DataContract]
	[DebuggerDisplay("Rect[Ps={Ps.Count}items Ls={Ls.Count}items LLs={LLs.Count}items]")]
	[GeneratedCode("Model#", "0.2.0.0")]
	public abstract class BaseRect : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, IDeserializationCallback, ICloneable, ICopyable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public static readonly string MIN = ModelUtils.NameOfProperty((BaseRect o) => o.Min);
			public static readonly string MAX = ModelUtils.NameOfProperty((BaseRect o) => o.Max);
			public static readonly string LENGTH = ModelUtils.NameOfProperty((BaseRect o) => o.Length);
			public static readonly string PS = ModelUtils.NameOfProperty((BaseRect o) => o.Ps);
			public static readonly string LS = ModelUtils.NameOfProperty((BaseRect o) => o.Ls);
			public static readonly string L_LS = ModelUtils.NameOfProperty((BaseRect o) => o.LLs);
			
			protected PROPERTIES() {}
		}
		
		#endregion
		
		#region Constructors
		
		protected BaseRect()
		{
			this.min = new Point();
			AddMinListeners(this.min);
			this.max = new Point();
			AddMaxListeners(this.max);
			this.ps = new ObservableList<Point>();
			AddPsListListeners(this.ps);
			this.ls = new ObservableList<double?>();
			AddLsListListeners(this.ls);
			this.lLs = new ObservableList<double>();
			AddLLsListListeners(this.lLs);
		}
		
		protected BaseRect(BaseRect other)
		{
			this.min = new Point(other.Min);
			AddMinListeners(this.min);
			this.max = new Point(other.Max);
			AddMaxListeners(this.max);
			this.ps = new ObservableList<Point>();
			AddPsListListeners(this.ps);
			this.ps.AddRange(other.Ps);
			this.ls = new ObservableList<double?>();
			AddLsListListeners(this.ls);
			this.ls.AddRange(other.Ls);
			this.lLs = new ObservableList<double>();
			AddLLsListListeners(this.lLs);
			this.lLs.AddRange(other.LLs);
		}
		
		#endregion Constructors
		
		#region Property Min
		
		[DataMember(Name = "Min", Order = 0, IsRequired = true)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Point min;
		
		public Point Min
		{
			[DebuggerStepThrough]
			get {
				return GetMin();
			}
		}
		
		[DebuggerStepThrough]
		protected virtual Point GetMin()
		{
			return this.min;
		}
		
		private void AddMinListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += MinPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += MinChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += MinPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += MinChildPropertyChangedEventHandler;
		}
		
		private void MinPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.MIN, sender, e);
		}
		
		private void MinChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.MIN, sender, e);
		}
		
		private void MinPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.MIN, sender, e);
		}
		
		private void MinChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.MIN, sender, e);
		}
		
		#endregion Property Min
		
		#region Property Max
		
		[DataMember(Name = "Max", Order = 1, IsRequired = true)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Point max;
		
		public Point Max
		{
			[DebuggerStepThrough]
			get {
				return GetMax();
			}
		}
		
		[DebuggerStepThrough]
		protected virtual Point GetMax()
		{
			return this.max;
		}
		
		private void AddMaxListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += MaxPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += MaxChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += MaxPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += MaxChildPropertyChangedEventHandler;
		}
		
		private void MaxPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.MAX, sender, e);
		}
		
		private void MaxChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.MAX, sender, e);
		}
		
		private void MaxPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.MAX, sender, e);
		}
		
		private void MaxChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.MAX, sender, e);
		}
		
		#endregion Property Max
		
		#region Property Length
		
		public float Length
		{
			[DebuggerStepThrough]
			get {
				return ComputeLength();
			}
		}
		
		[DebuggerStepThrough]
		protected abstract float ComputeLength();
		
		#endregion Property Length
		
		#region Property Ps
		
		[DataMember(Name = "Ps", Order = 2, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ObservableList<Point> ps;
		
		public ObservableList<Point> Ps
		{
			[DebuggerStepThrough]
			get {
				return GetPs();
			}
		}
		
		[DebuggerStepThrough]
		protected virtual ObservableList<Point> GetPs()
		{
			return this.ps;
		}
		
		private void AddPsListListeners(ObservableList<Point> child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging += PsListPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged += PsListPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyCollectionChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanged.CollectionChanged += PsListChangedEventHandler;
				
			foreach (var item in child)
				AddPsItemListeners(item);
		}
		
		private void PsListPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName != ObservableList<Point>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanging(PROPERTIES.PS);
		}
		
		private void PsListPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != ObservableList<Point>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanged(PROPERTIES.PS);
		}
		
		private void PsListChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
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
							RemovePsItemListeners(item);
							
					if (e.NewItems != null)
						foreach (var item in e.NewItems)
							AddPsItemListeners(item);
							
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
		
		private void RemovePsItemListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging -= PsItemPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanging.ChildPropertyChanging -= PsItemChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged -= PsItemPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanged.ChildPropertyChanged -= PsItemChildPropertyChangedEventHandler;
		}
		
		private void AddPsItemListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging += PsItemPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanging.ChildPropertyChanging += PsItemChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged += PsItemPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanged.ChildPropertyChanged += PsItemChildPropertyChangedEventHandler;
		}
		
		private void PsItemPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.PS, sender, e);
		}
		
		private void PsItemChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.PS, sender, e);
		}
		
		private void PsItemPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.PS, sender, e);
		}
		
		private void PsItemChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.PS, sender, e);
		}
		
		#endregion Property Ps
		
		#region Property Ls
		
		[DataMember(Name = "Ls", Order = 3, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ObservableList<double?> ls;
		
		public ObservableList<double?> Ls
		{
			[DebuggerStepThrough]
			get {
				return GetLs();
			}
		}
		
		[DebuggerStepThrough]
		protected virtual ObservableList<double?> GetLs()
		{
			return this.ls;
		}
		
		private void AddLsListListeners(ObservableList<double?> child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging += LsListPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged += LsListPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyCollectionChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanged.CollectionChanged += LsListChangedEventHandler;
				
			foreach (var item in child)
				AddLsItemListeners(item);
		}
		
		private void LsListPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName != ObservableList<double?>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanging(PROPERTIES.LS);
		}
		
		private void LsListPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != ObservableList<double?>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanged(PROPERTIES.LS);
		}
		
		private void LsListChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
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
							RemoveLsItemListeners(item);
							
					if (e.NewItems != null)
						foreach (var item in e.NewItems)
							AddLsItemListeners(item);
							
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
		
		private void RemoveLsItemListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging -= LsItemPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanging.ChildPropertyChanging -= LsItemChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged -= LsItemPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanged.ChildPropertyChanged -= LsItemChildPropertyChangedEventHandler;
		}
		
		private void AddLsItemListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging += LsItemPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanging.ChildPropertyChanging += LsItemChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged += LsItemPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyChildPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyChildPropertyChanged.ChildPropertyChanged += LsItemChildPropertyChangedEventHandler;
		}
		
		private void LsItemPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.LS, sender, e);
		}
		
		private void LsItemChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.LS, sender, e);
		}
		
		private void LsItemPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.LS, sender, e);
		}
		
		private void LsItemChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.LS, sender, e);
		}
		
		#endregion Property Ls
		
		#region Property LLs
		
		[DataMember(Name = "LLs", Order = 4, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ObservableList<double> lLs;
		
		public ObservableList<double> LLs
		{
			[DebuggerStepThrough]
			get {
				return GetLLs();
			}
		}
		
		[DebuggerStepThrough]
		protected virtual ObservableList<double> GetLLs()
		{
			return this.lLs;
		}
		
		private void AddLLsListListeners(ObservableList<double> child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanging != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanging.PropertyChanging += LLsListPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if (notifyPropertyChanged != null)
// ReSharper restore ConditionIsAlwaysTrueOrFalse
				notifyPropertyChanged.PropertyChanged += LLsListPropertyChangedEventHandler;
		}
		
		private void LLsListPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName != ObservableList<double>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanging(PROPERTIES.L_LS);
		}
		
		private void LLsListPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != ObservableList<double>.PROPERTIES.ITEMS)
				return;
				
			NotifyPropertyChanged(PROPERTIES.L_LS);
		}
		
		#endregion Property LLs
		
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
			CopyFrom((Rect) other);
		}
		
		public virtual void CopyFrom(Rect other)
		{
			Min.CopyFrom(other.Min);
			Max.CopyFrom(other.Max);
			Ps.Clear();
			Ps.AddRange(other.Ps);
			Ls.Clear();
			Ls.AddRange(other.Ls);
			LLs.Clear();
			LLs.AddRange(other.LLs);
		}
		
		#endregion CopyFrom
		
		#region Clone
		
#pragma warning disable 109
		public new Rect Clone()
#pragma warning restore 109
		{
			return (Rect) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new Rect((Rect) this);
		}
		
		#endregion Clone
		
		#region Serialization
		
		void IDeserializationCallback.OnDeserialization(object sender)
		{
			AddMinListeners(this.min);
			AddMaxListeners(this.max);
			AddPsListListeners(this.ps);
			AddLsListListeners(this.ls);
			AddLLsListListeners(this.lLs);
		}
		
		#endregion Serialization
		
		#region Equals
		
		public bool Equals(Rect other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (Ps.Count != other.Ps.Count)
				return false;
			for(int i = 0; i < Ps.Count; ++i)
			{
				var mine = Ps[i];
				var theirs = other.Ps[i];
				if (!Equals(mine, theirs))
					return false;
			}
			if (Ls.Count != other.Ls.Count)
				return false;
			for(int i = 0; i < Ls.Count; ++i)
			{
				var mine = Ls[i];
				var theirs = other.Ls[i];
				if ((mine == null) != (theirs == null) || (mine != null && Math.Abs((double) mine - (double) theirs) >= 1E-06))
					return false;
			}
			if (LLs.Count != other.LLs.Count)
				return false;
			for(int i = 0; i < LLs.Count; ++i)
			{
				var mine = LLs[i];
				var theirs = other.LLs[i];
				if (Math.Abs(mine - theirs) >= 1E-06)
					return false;
			}
			return Min.Equals(other.Min)
			       && Max.Equals(other.Max)
			       ;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Rect)) return false;
			return Equals((Rect) obj);
		}
		
		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				result = (result * 397) ^ Min.GetHashCode();
				result = (result * 397) ^ Max.GetHashCode();
				for(var obj in Ps)
					result = (result * 397) ^ (obj != null ? obj.GetHashCode() : 0);
				for(var obj in Ls)
					result = (result * 397) ^ (obj != null ? obj.GetHashCode() : 0);
				for(var obj in LLs)
					result = (result * 397) ^ obj.GetHashCode();
				return result;
			}
		}
		
		public static bool operator ==(BaseRect left, BaseRect right)
		{
			return Equals(left, right);
		}
		
		public static bool operator !=(BaseRect left, BaseRect right)
		{
			return !Equals(left, right);
		}
		
		#endregion Equals
	}
	
}
