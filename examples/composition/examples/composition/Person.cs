// Automatically generated by Model#
// Remove the above line before editing this file and it won't be changed by Model#

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.composition
{

	[DataContract]
	public class Person : BasePerson
	{
		public Person()
		: base()
		{
		}
		
		public Person(Person other)
		: base(other)
		{
		}
		
	}
	
}
