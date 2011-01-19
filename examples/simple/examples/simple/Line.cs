using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.simple
{

	[DataContract]
	public class Line : BaseLine
	{
		public Line()
		: base()
		{
		}
		
		public Line(Line other)
		: base(other)
		{
		}
	}
	
}
