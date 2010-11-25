//
// Copyright 2010 Ricardo Pescuma Domenecci
// 

using System;
using System.Collections.Generic;
using System.IO;
using org.pescuma.ModelSharp.Core;

namespace org.pescuma.ModelSharp.CommandLine
{
	public class Program
	{
		private static string _templatesPath;

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
				var modelProcessor = new ModelProcessor(_templatesPath, file, overrideFile);
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
			_templatesPath = Path.GetFullPath(Path.Combine(dir, @"..\..\..\ModelSharp.Core\templates\"));
#else
			_templatesPath = Path.GetFullPath(Path.Combine(dir, @"templates\"));
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
