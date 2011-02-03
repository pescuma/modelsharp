using org.pescuma.ModelSharp.Lib;
using System.Collections.Specialized;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.computeProperty
{

	[DataContract]
	public class MyClass : BaseMyClass
	{
		public MyClass()
		: base()
		{
		}
		
		public MyClass(MyClass other)
		: base(other)
		{
		}
		
		protected override string ComputeDummy()
		{
			// TODO
			throw new NotImplementedException();
		}
		
		protected override double ComputeSquaredLength()
		{
			// TODO
			throw new NotImplementedException();
		}
		
		protected override double ComputeSquaredLengthCached()
		{
			// TODO
			throw new NotImplementedException();
		}
		
	}
	
}
