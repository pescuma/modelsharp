using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.extends
{

	[DataContract]
	public class C : BaseC
	{
		public C()
		: base()
		{
		}
		
		public C(C other)
		: base(other)
		{
		}
		
	}
	
}
