using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Diagnostics;
using System;

namespace examples.doc
{

	[DataContract]
	public class ImmutablePoint : BaseImmutablePoint
	{
		public ImmutablePoint(double x, Point y, IEnumerable<double> ws)
		: base(x, y, ws)
		{
		}
		
		public ImmutablePoint(ImmutablePoint other)
		: base(other)
		{
		}
		
		protected override double ComputeLen()
		{
			// TODO
			throw new NotImplementedException();
		}
		
	}
	
}
