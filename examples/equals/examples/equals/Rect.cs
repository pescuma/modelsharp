// Automatically generated by Model#
// Remove the above line before editing this file and it won't be changed by Model#

using org.pescuma.ModelSharp.Lib;
using System.Collections.Specialized;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace examples.equals
{

	[DataContract(Name = "Rect")]
	public class Rect : BaseRect
	{
		public Rect()
		: base()
		{
		}
		
		public Rect(Rect other)
		: base(other)
		{
		}
		
		protected override float ComputeLength()
		{
			// TODO
			throw new NotImplementedException();
		}
		
	}
	
}