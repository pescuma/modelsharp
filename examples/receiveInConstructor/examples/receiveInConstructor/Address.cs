// Automatically generated by Model#
// Remove the above line before editing this file and it won't be changed by Model#

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.receiveInConstructor
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
