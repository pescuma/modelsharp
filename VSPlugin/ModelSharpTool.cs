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

// Based on work by Richard Lowe for CustomToolTemplate: http://customtooltemplate.codeplex.com/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using CustomToolTemplate;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using org.pescuma.ModelSharp.Core;
using VSLangProj;

namespace org.pescuma.ModelSharp.VSPlugin
{
	[ComVisible(true)]
	[CustomToolRegistration("ModelSharpTool", typeof (ModelSharpTool), FileExtension = ".ms")]
	[ProvideObject(typeof (ModelSharpTool))]
	public class ModelSharpTool : CustomToolBase
	{
		public ModelSharpTool()
		{
			FileExtension = ".dot";

			OnGenerateCode += GenerateCode;
		}

		private void GenerateCode(object sender, GenerationEventArgs e)
		{
			e.OutputFileExtension = ".dot";

			string templatesDir = GetInstallPath("templates");
			if (!Directory.Exists(templatesDir))
			{
				e.GenerateError("Missing templates from install: " + templatesDir);
				return;
			}

			string libDll = GetInstallPath(GetInstallPath(@"lib\ModelSharp.Lib.dll"));
			if (!Directory.Exists(templatesDir))
			{
				e.GenerateError("Missing dll from install: " + libDll);
				return;
			}

			string tempFile = Path.GetTempFileName();
			string tempDir = null;
			try
			{
				tempDir = Directory.CreateDirectory(tempFile + "_dir").FullName;

				var modelProcessor = new ModelProcessor(templatesDir, e.InputFilePath, true);
				modelProcessor.BaseOutputPath = tempDir;
				modelProcessor.GlobalConfig.ProjectNamespace = e.Namespace;

				var result = modelProcessor.Process();

				// Output to console
//				foreach (var msg in result.Messages)
//				{
//					string txt;
//					if (msg.Line > 0)
//						txt = String.Format("[{0}] [{1:0000} : {2:000}] {3}",
//						                                msg.Error ? "ERROR" : "INFO ", msg.Line, msg.Column,
//						                                msg.Description);
//					else
//						txt = String.Format("[{0}] {1}", msg.Error ? "ERROR" : "INFO ", msg.Description);
//
//					Console.WriteLine(txt); 
//				}

				if (!result.Success)
				{
					e.GenerateError("Error generating model");

					foreach (var msg in result.Messages)
					{
						if (msg.Error)
						{
							if (msg.Line > 0)
								e.GenerateError(msg.Description, msg.Line - 1, msg.Column);
							else
								e.GenerateError(msg.Description);
						}
					}
					return;
				}

				//string filename = Path.Combine(tempDir, names.First());
				//foreach (var line in File.ReadLines(filename))
				//{
				//    e.OutputCode.AppendLine(line);
				//}

				string inputDir = new FileInfo(e.InputFilePath).DirectoryName;

				MergeFiles(result.NotToChangeFilenames, tempDir, inputDir, false);
				MergeFiles(result.EditableFilenames, tempDir, inputDir, true);

				SetSubItems(e, inputDir, result.NotToChangeFilenames);
				AddToProject(e, inputDir, result.EditableFilenames);

				EnsureDllIsInProject(e, libDll);
			}
			finally
			{
				if (tempDir != null)
				{
					foreach (var file in Directory.GetFiles(tempDir))
					{
						if (file == "." || file == "..")
							continue;

						DeleteFile(Path.Combine(tempDir, file), e);
					}

					DeleteDir(tempDir, e);
				}

				DeleteFile(tempFile, e);
			}
		}

		private void MergeFiles(IEnumerable<string> relativeNames, string srcDir, string destDir,
		                        bool onlyIfNotExists)
		{
			foreach (var relativeName in relativeNames)
			{
				FileInfo input = new FileInfo(Path.Combine(srcDir, relativeName));
				FileInfo output;

				if (onlyIfNotExists)
					output = new FileInfo(Path.Combine(destDir, relativeName));
				else
					output = new FileInfo(Path.Combine(destDir, relativeName.Split('\\').Last()));

				if (onlyIfNotExists && output.Exists && !ModelProcessor.IsMarkedToOverride(output.FullName))
					continue;

				Directory.CreateDirectory(output.Directory.FullName);

				File.WriteAllText(output.FullName, File.ReadAllText(input.FullName));
			}
		}

		private void SetSubItems(GenerationEventArgs e, string dir, IEnumerable<string> relativeNames)
		{
			HashSet<string> filenames = new HashSet<string>();
			foreach (var name in relativeNames)
				filenames.Add(name.Split('\\').Last());

			HashSet<string> existingNames = new HashSet<string>();
			foreach (ProjectItem item in e.ProjectItem.ProjectItems)
			{
				if (!filenames.Contains(item.Name) && !item.Name.EndsWith(".dot"))
					item.Delete();
				else
					existingNames.Add(item.FileNames[0]);
			}

			foreach (var name in filenames)
			{
				if (existingNames.Contains(name))
					continue;

				e.ProjectItem.ProjectItems.AddFromFile(Path.Combine(dir, name));
			}
		}

		private void AddToProject(GenerationEventArgs e, string dir, List<string> names)
		{
			var proj = e.ProjectItem.ContainingProject;

			foreach (var name in names)
			{
				AddFromFileWithFolders(proj.ProjectItems, name, dir);
			}
		}

		private void AddFromFileWithFolders(ProjectItems root, string name, string dir)
		{
			string pathToNow = null;
			var tmp = name.Split('\\');
			for (int i = 0; i < tmp.Length - 1; i++)
			{
				string thisDir = tmp[i];
				pathToNow = pathToNow == null ? thisDir : Path.Combine(pathToNow, thisDir);

				var item = Find(root, thisDir);
				if (item == null)
				{
					//AddExistingFolder(root.ContainingProject, pathToNow);

					//item = Find(root, thisDir);
					//if (item == null)
					item = root.AddFolder(thisDir);
				}

				root = item.ProjectItems;
			}

			if (Find(root, tmp[tmp.Length - 1]) == null)
				root.AddFromFile(Path.Combine(dir, name));
		}

		//private bool AddExistingFolder(Project proj, string folder)
		//{
		//    var dte2 = ((DTE2)proj.DTE);
		//    var items = dte2.ToolWindows.SolutionExplorer.UIHierarchyItems;

		//    dte2.ExecuteCommand("Project.ShowAllFiles");

		//    try
		//    {
		//        UIHierarchyItem item = RecursiveFind(items.Item(proj.Name).UIHierarchyItems,
		//                                             proj.Name + "\\" + folder);
		//        if (item == null)
		//            return false;

		//        var oldSelection = (object[])dte2.ToolWindows.SolutionExplorer.SelectedItems;

		//        item.Select(vsUISelectionType.vsUISelectionTypeSelect);
		//        dte2.ExecuteCommand("Project.IncludeInProject");

		//        item.Select(vsUISelectionType.vsUISelectionTypeToggle);

		//        foreach (UIHierarchyItem sel in oldSelection)
		//        {
		//            sel.Select(vsUISelectionType.vsUISelectionTypeToggle);
		//        }
		//    }
		//    finally
		//    {
		//    }
		//    return true;
		//}

		private UIHierarchyItem RecursiveFind(UIHierarchyItems root, string name)
		{
			var tmp = name.Split('\\');
			for (int i = 0; i < tmp.Length - 1; i++)
			{
				var item = Find(root, tmp[i]);
				if (item == null)
					return null;

				root = item.UIHierarchyItems;
			}

			return Find(root, tmp[tmp.Length - 1]);
		}

		private UIHierarchyItem Find(UIHierarchyItems items, string name)
		{
			foreach (UIHierarchyItem item in items)
			{
				if (string.Compare(item.Name, name, StringComparison.CurrentCultureIgnoreCase) == 0)
					return item;
			}

			return null;
		}

		private ProjectItem RecursiveFind(ProjectItems root, string name)
		{
			var tmp = name.Split('\\');
			for (int i = 0; i < tmp.Length - 1; i++)
			{
				var item = Find(root, tmp[i]);
				if (item == null)
					return null;

				root = item.ProjectItems;
			}

			return Find(root, tmp[tmp.Length - 1]);
		}

		private ProjectItem Find(ProjectItems items, string name)
		{
			foreach (ProjectItem item in items)
			{
				if (string.Compare(item.Name, name, StringComparison.CurrentCultureIgnoreCase) == 0)
					return item;
			}

			return null;
		}

		private void DeleteDir(string dir, GenerationEventArgs e)
		{
			try
			{
				Directory.Delete(dir, true);
			}
			catch (Exception ex)
			{
				e.GenerateWarning(ex.Message);
			}
		}

		private void DeleteFile(string filename, GenerationEventArgs e)
		{
			try
			{
				File.Delete(filename);
			}
			catch (Exception ex)
			{
				e.GenerateWarning(ex.Message);
			}
		}

		private void EnsureDllIsInProject(GenerationEventArgs e, string libDll)
		{
			var project = (VSProject) e.ProjectItem.ContainingProject.Object;

			AddAssemblyDependency(e, project, Assembly.GetAssembly(typeof (DataContractAttribute)));
			AddAssemblyDependency(e, project, Assembly.GetAssembly(typeof (INotifyCollectionChanged)));
			AddAssemblyDependency(e, project, "ModelSharp.Lib", libDll, true);
		}

		private void AddAssemblyDependency(GenerationEventArgs e, VSProject project, Assembly assembly)
		{
			AddAssemblyDependency(e, project, assembly.GetName().Name, assembly.Location, false);
		}

		private void AddAssemblyDependency(GenerationEventArgs e, VSProject project, string assemblyName,
		                                   string assemblyLocation, bool copyLocal)
		{
			try
			{
				bool hasRef =
					project.References.Cast<Reference>().Any(
						r =>
						r != null && string.Equals(r.Name, assemblyName, StringComparison.InvariantCultureIgnoreCase));

				if (!hasRef)
				{
					Reference dllRef = project.References.Add(assemblyLocation);
					dllRef.CopyLocal = copyLocal;
				}
			}
			catch (Exception ex)
			{
				e.GenerateWarning("Failed to add reference to " + assemblyName + ":" + ex.Message);
			}
		}

		private static string installPath;

		public static string GetInstallPath(string filename = null)
		{
			if (installPath == null)
				installPath = Path.GetDirectoryName(typeof (ModelSharpTool).Assembly.Location);

			return string.IsNullOrEmpty(filename) ? installPath : Path.Combine(installPath, filename);
		}
	}
}
