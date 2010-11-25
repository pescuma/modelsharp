//
// Copyright 2010 Ricardo Pescuma Domenecci
// 

using System.Diagnostics.Contracts;

namespace org.pescuma.ModelSharp.Core
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