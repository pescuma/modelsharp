// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Diagnostics;
using System;

namespace examples.computeProperty
{

	[DataContract]
	[DebuggerDisplay("MyImmutableClass[X={X} Y={Y} Children={Children.Count}items]")]
	public abstract class BaseMyImmutableClass : ICloneable
	{
		[DataMember(Name = "X", Order = 0, IsRequired = false)]
		public readonly double X;
		
		[DataMember(Name = "Y", Order = 1, IsRequired = false)]
		public readonly double Y;
		
		[DataMember(Name = "Children", Order = 2, IsRequired = false)]
		public readonly ReadOnlyCollection<MyClass> Children;
		
		public BaseMyImmutableClass(double x, double y, IEnumerable<MyClass> children)
		{
			X = x;
			Y = y;
			_squaredLengthCachedCacheValid = false;
			Children = new ReadOnlyCollection<MyClass>(new List<MyClass>(children));
		}
		
		public BaseMyImmutableClass(BaseMyImmutableClass other)
		{
			X = other.X;
			Y = other.Y;
			_squaredLengthCachedCacheValid = false;
			var children = new List<MyClass>();
			foreach (MyClass otherItem in other.Children)
				children.Add(new MyClass(otherItem));
			Children = new ReadOnlyCollection<MyClass>(children);
		}
		
		public virtual MyImmutableClass WithX(double x)
		{
			return new MyImmutableClass(x, Y, Children);
		}
		
		public virtual MyImmutableClass WithY(double y)
		{
			return new MyImmutableClass(X, y, Children);
		}
		
		public double Length
		{
			[DebuggerStepThrough]
			get {
				return ComputeLength();
			}
		}
		
		protected virtual double ComputeLength()
		{
			return Math.Sqrt(X * X + Y * Y);
		}
		
		public string Dummy
		{
			[DebuggerStepThrough]
			get {
				return ComputeDummy();
			}
		}
		
		protected abstract string ComputeDummy();
		
		public double SquaredLength
		{
			[DebuggerStepThrough]
			get {
				return ComputeSquaredLength();
			}
		}
		
		protected abstract double ComputeSquaredLength();
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _squaredLengthCachedCache;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _squaredLengthCachedCacheValid;
		
		public double SquaredLengthCached
		{
			[DebuggerStepThrough]
			get {
				return ComputeAndCacheSquaredLengthCached();
			}
		}
		
		protected virtual void InvalidateSquaredLengthCachedCache()
		{
			_squaredLengthCachedCacheValid = false;
		}
		
		private double ComputeAndCacheSquaredLengthCached()
		{
			if (!_squaredLengthCachedCacheValid)
			{
				_squaredLengthCachedCache = ComputeSquaredLengthCached();
				_squaredLengthCachedCacheValid = true;
			}
			
			return _squaredLengthCachedCache;
		}
		
		protected abstract double ComputeSquaredLengthCached();
		
#pragma warning disable 109
		public new MyImmutableClass Clone()
#pragma warning restore 109
		{
			return (MyImmutableClass) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new MyImmutableClass((MyImmutableClass) this);
		}
	}
	
}
