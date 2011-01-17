//
// Copyright (c) 2010 Ricardo Pescuma Domenecci
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 

using System.Diagnostics.Contracts;

namespace org.pescuma.ModelSharp.Core
{
	public static class StringUtils
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

			var chars = str.ToCharArray();

			for (int i = 0; i < chars.Length; i++)
			{
				var lower = char.ToLower(chars[i]);

				if (i == 0 || i == chars.Length - 1 || char.IsUpper(chars[i + 1]))
					chars[i] = lower;
				else
					break;
			}

			return new string(chars);
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
