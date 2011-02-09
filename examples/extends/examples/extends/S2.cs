using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.extends
{

	[DataContract]
	public class S2 : BaseS2
	{
		public S2()
		: base()
		{
		}
		
		public S2(S2 other)
		: base(other)
		{
		}
		
	}
	
}
