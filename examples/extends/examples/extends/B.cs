using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.extends
{

	[DataContract]
	public class B : BaseB
	{
		public B()
		: base()
		{
		}
		
		public B(B other)
		: base(other)
		{
		}
		
	}
	
}
