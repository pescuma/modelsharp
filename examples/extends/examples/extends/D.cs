using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.extends
{

	[DataContract]
	public class D : BaseD
	{
		public D()
		: base()
		{
		}
		
		public D(D other)
		: base(other)
		{
		}
		
	}
	
}
