using System.Xml;
using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.@using
{

	[DataContract]
	public class Test : BaseTest
	{
		public Test()
		: base()
		{
		}
		
		public Test(Test other)
		: base(other)
		{
		}
	}
	
}
