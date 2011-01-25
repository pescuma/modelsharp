using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.noncloneable
{

	[DataContract]
	public class Point : BasePoint
	{
		public Point()
		: base()
		{
		}
		
		public Point(Point other)
		: base(other)
		{
		}
		
	}
	
}
