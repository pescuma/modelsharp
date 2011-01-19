using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Diagnostics;
using System;

namespace examples.immutable
{

	[DataContract]
	public class Line : BaseLine
	{
		public Line(Point p1, Point p2, Point dir, IEnumerable<Point> border)
		: base(p1, p2, dir, border)
		{
		}
		
		public Line(Line other)
		: base(other)
		{
		}
	}
	
}
