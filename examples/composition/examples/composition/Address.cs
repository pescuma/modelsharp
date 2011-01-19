using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.composition
{

	[DataContract]
	public class Address : BaseAddress
	{
		public Address()
		: base()
		{
		}
		
		public Address(Address other)
		: base(other)
		{
		}
	}
	
}
