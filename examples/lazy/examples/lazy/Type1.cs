using org.pescuma.ModelSharp.Lib;
using System.Collections.Specialized;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.lazy
{

	[DataContract]
	public class Type1 : BaseType1
	{
		public Type1()
		: base()
		{
		}
		
		public Type1(Type1 other)
		: base(other)
		{
		}
		
	}
	
}