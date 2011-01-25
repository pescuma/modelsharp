using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Diagnostics;

namespace examples.nonserializable
{

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
