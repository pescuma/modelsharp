// Automatically generated by Model#
// Remove the above line before editing this file and it won't be changed by Model#

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Diagnostics;
using System;

namespace examples.deepCopy
{

	[DataContract]
	public class ImmutablePerson : BaseImmutablePerson
	{
		public ImmutablePerson(IEnumerable<ImmutableAddress> homeAddressCol, IEnumerable<ImmutableAddress> workAddressCol, IEnumerable<string> stringCol, IEnumerable<string> stringCol2, IEnumerable<double> doubleCol, IEnumerable<double> doubleCol2, Address homeAddressProp, Address workAddressProp)
		: base(homeAddressCol, workAddressCol, stringCol, stringCol2, doubleCol, doubleCol2, homeAddressProp, workAddressProp)
		{
		}
		
		public ImmutablePerson(ImmutablePerson other)
		: base(other)
		{
		}
		
	}
	
}
