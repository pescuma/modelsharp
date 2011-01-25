using org.pescuma.ModelSharp.Lib;
using System.Collections.Specialized;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.collection
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