using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.simple
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
