using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.lazy
{

	[DataContract]
	public class Type2 : BaseType2
	{
		public Type2()
		: base()
		{
		}
		
		public Type2(Type2 other)
		: base(other)
		{
		}
	}
	
}
