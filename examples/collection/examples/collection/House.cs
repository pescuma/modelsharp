using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.collection
{

	[DataContract]
	public class House : BaseHouse
	{
		public House()
		: base()
		{
		}
		
		public House(House other)
		: base(other)
		{
		}
		
	}
	
}
