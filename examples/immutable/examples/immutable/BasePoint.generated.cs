//----------------------
// <auto-generated>
//     Automatically generated by Model#
// </auto-generated>
//----------------------
// DO NOT EDIT THIS FILE

using System.CodeDom.Compiler;
using System.Runtime.Serialization;
using System.Diagnostics;
using System;

namespace examples.immutable
{

	[DataContract]
	[DebuggerDisplay("Point[X={X} Y={Y}]")]
	[GeneratedCode("Model#", "0.2.0.0")]
	public abstract class BasePoint : ICloneable
	{
		[DataMember(Name = "X", Order = 0, IsRequired = false)]
		public readonly double X;
		
		[DataMember(Name = "Y", Order = 1, IsRequired = false)]
		public readonly double Y;
		
		protected BasePoint(double x, double y)
		{
			X = x;
			Y = y;
		}
		
		protected BasePoint(BasePoint other)
		{
			this.X = other.X;
			this.Y = other.Y;
		}
		
		public virtual Point WithX(double x)
		{
			return new Point(x, Y);
		}
		
		public virtual Point WithY(double y)
		{
			return new Point(X, y);
		}
		
		#region Clone
		
#pragma warning disable 109
		public new Point Clone()
#pragma warning restore 109
		{
			return (Point) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new Point((Point) this);
		}
		
		#endregion Clone
	}
	
}
