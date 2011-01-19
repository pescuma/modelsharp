using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.required
{

	[DataContract]
	public class Type1 : BaseType1
	{
		public Type1(Type2 prop2, int prop4, string prop5)
		: base(prop2, prop4, prop5)
		{
		}
		
		public Type1(Type1 other)
		: base(other)
		{
		}
	}
	
}
