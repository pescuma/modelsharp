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

namespace examples.extends
{

	[DataContract]
	[DebuggerDisplay("D[X={X}]")]
	[GeneratedCode("Model#", "0.2.1.0")]
	public abstract class BaseD : B, INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable, ICopyable
	{
		#region Field Name Defines
		
		public new class PROPERTIES : B.PROPERTIES
		{
			public static readonly string X = ModelUtils.NameOfProperty((BaseD o) => o.X);
			
			protected PROPERTIES() {}
		}
		
		#endregion
		
		#region Constructors
		
		protected BaseD()
		{
		}
		
		protected BaseD(BaseD other)
		: base(other)
		{
			this.x = other.X;
		}
		
		#endregion Constructors
		
		#region Property X
		
		[DataMember(Name = "X", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double x;
		
		public double X
		{
			[DebuggerStepThrough]
			get {
				return GetX();
			}
			[DebuggerStepThrough]
			set {
				SetX(value);
			}
		}
		
		[DebuggerStepThrough]
		protected virtual double GetX()
		{
			return this.x;
		}
		
		[DebuggerStepThrough]
		protected virtual bool SetX(double x)
		{
			if (Math.Abs(this.x - x) < 1E-06)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.X);
			
			this.x = x;
			
			NotifyPropertyChanged(PROPERTIES.X);
			
			return true;
		}
		
		#endregion Property X
		
		#region Property Notification
		
		#endregion Property Notification
		
		#region CopyFrom
		
		void ICopyable.CopyFrom(object other)
		{
			CopyFrom((D) other);
		}
		
		public virtual void CopyFrom(D other)
		{
			base.CopyFrom(other);
			X = other.X;
		}
		
		#endregion CopyFrom
		
		#region Clone
		
#pragma warning disable 109
		public new D Clone()
#pragma warning restore 109
		{
			return (D) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new D((D) this);
		}
		
		#endregion Clone
	}
	
}
