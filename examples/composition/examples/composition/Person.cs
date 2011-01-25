using System;
using System.ComponentModel;
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
