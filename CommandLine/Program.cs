// 
//  Copyright (c) 2010 Ricardo Pescuma Domenecci
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
using System;
using System.Collections.Generic;
using System.IO;
using org.pescuma.ModelSharp.Core;

namespace org.pescuma.ModelSharp.CommandLine
{
	public class Program
	{
		private static string templatesPath;

		private static int Main(string[] args)
		{
			ComputeTemplatePath();

			bool overrideFile = false;
			List<string> files = new List<string>();
			foreach (var arg in args)
			{
				if (IsOverrideArg(arg))
				{
					overrideFile = true;
				}
				else
				{
					FileInfo xml = new FileInfo(arg);
					if (!xml.Exists)
					{
						Console.WriteLine("File not found: " + xml.FullName);
						return -1;
					}
					files.Add(arg);
				}
			}

			if (files.Count < 1)
			{
				Console.WriteLine("Model# "
				                  + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
				Console.WriteLine("");
				Console.WriteLine("Use:");
				Console.WriteLine("    ModelSharp [-override] <model.ms>");
				return 1;
			}

			int ret = 0;
			foreach (var file in files)
			{
				var modelProcessor = new ModelProcessor(templatesPath, file, overrideFile);
				modelProcessor.Logger = new Logger();

				var result = modelProcessor.Process();
				if (!result.Success)
					ret = -1;
			}

			if (ret != 0)
				Console.WriteLine("Finished with error(s)");
			return ret;
		}

		private static bool IsOverrideArg(string arg)
		{
			return string.Compare(arg, "-override", true) == 0;
		}

		private static void ComputeTemplatePath()
		{
			string fullPath = System.Reflection.Assembly.GetAssembly(typeof (Program)).Location;
			string dir = Path.GetDirectoryName(fullPath);

#if DEBUG
			templatesPath = Path.GetFullPath(Path.Combine(dir, @"..\..\..\Core\templates\"));
#else
			templatesPath = Path.GetFullPath(Path.Combine(dir, @"templates\"));
#endif
		}
	}

	public class Logger : ILogger
	{
		public void Info(string msg, int line = 0, int column = 0)
		{
			Console.WriteLine(msg);
		}

		public void Error(string msg, int line = 0, int column = 0)
		{
			Console.WriteLine(" [ERR] " + msg);
		}
	}
}
