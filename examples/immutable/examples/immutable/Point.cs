using System.Runtime.Serialization;
using System.Diagnostics;
using System;

namespace examples.immutable
{

	[DataContract]
	public class Point : BasePoint
	{
		public Point(double x, double y)
		: base(x, y)
		{
		}
		
		public Point(Point other)
		: base(other)
		{
		}
	}
	
}
