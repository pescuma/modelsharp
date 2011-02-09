using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.extends
{

	[DataContract]
	public class A : BaseA
	{
		public A()
		: base()
		{
		}
		
		public A(A other)
		: base(other)
		{
		}
		
	}
	
}
