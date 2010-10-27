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

using System;
using System.IO;

namespace org.pescuma.ModelSharp
{
    internal class Program
    {
        private const string TemplatesPath = @"..\..\templates\";

        private static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Model# " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
                Console.WriteLine("");
                Console.WriteLine("Use:");
                Console.WriteLine("    ModelSharp <model.ms>");
                return 1;
            }

            foreach (var arg in args)
            {
                FileInfo xml = new FileInfo(arg);
                if (!xml.Exists)
                {
                    Console.WriteLine("File not found: " + xml.FullName);
                    return -1;
                }
            }

            foreach (var arg in args)
            {
                new ModelProcessor(TemplatesPath, arg).Process();
            }

            return 0;
        }
    }
}