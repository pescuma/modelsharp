//
// Copyright 2010 Ricardo Pescuma Domenecci
// 
// This file is part of Model#.
// 
// Model# is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
// 
// Model# is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along with Model#. If not, see <http://www.gnu.org/licenses/>.
// 

using System.Diagnostics.Contracts;

namespace org.pescuma.ModelSharp
{
	public class StringUtils
	{
		[Pure]
		public static string FirstUpper(string str)
		{
			if (string.IsNullOrEmpty(str))
				return str;

			return char.ToUpper(str[0]) + str.Substring(1);
		}

		[Pure]
		public static string FirstLower(string str)
		{
			if (string.IsNullOrEmpty(str))
				return str;

			return char.ToLower(str[0]) + str.Substring(1);
		}

		[Pure]
		public static bool IsValidVariableName(string str)
		{
			if (string.IsNullOrEmpty(str))
				return false;
			if (str.IndexOfAny(new[] {' ', '\r', '\n', '\t', '.'}) >= 0)
				return false;

			return true;
		}

		[Pure]
		public static bool IsValidTypeName(string str)
		{
			if (string.IsNullOrEmpty(str))
				return false;
			if (str.IndexOfAny(new[] {' ', '\r', '\n', '\t'}) >= 0)
				return false;

			return true;
		}

		[Pure]
		public static string ToDefineName(string name)
		{
			Contract.Requires(IsValidVariableName(name));
			Contract.Ensures(IsValidVariableName(Contract.Result<string>()));

			char[] cs = name.ToCharArray();

			string ret = "";
			for (int i = 0; i < cs.Length; i++)
			{
				char c = cs[i];
				if (char.IsUpper(c))
				{
					if (i == 0)
						ret += c;
					else if (!char.IsUpper(cs[i - 1]))
						ret += "_" + c;
					else if (i + 1 == cs.Length)
						ret += c;
					else if (!char.IsUpper(cs[i + 1]))
						ret += "_" + c;
					else
						ret += c;
				}
				else
				{
					ret += char.ToUpper(c);
				}
			}

			return ret;
		}
	}
}