using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using examples.collection;
using org.pescuma.ModelSharp.Lib;

namespace examples
{
	public class Program
	{
		private static int Main(string[] args)
		{
			var x = ModelUtils.NameOfProperty((Person p) => p.Houses[0].Address);
			return 0;
		}
	}
}
