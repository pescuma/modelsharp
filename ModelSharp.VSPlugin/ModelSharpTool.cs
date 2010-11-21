// Based on work by Richard Lowe for CustomToolTemplate: http://customtooltemplate.codeplex.com/

using System;
using System.Collections.Generic;
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

			string tempFile = Path.GetTempFileName();
			string tempDir = null;
			try
			{
				tempDir = Directory.CreateDirectory(tempFile + "_dir").FullName;

				var modelProcessor = new ModelProcessor(templatesDir, e.InputFilePath, true);
				modelProcessor.BaseOutputPath = tempDir;
				modelProcessor.ProjectNamespace = e.Namespace;

				var result = modelProcessor.Process();
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

				EnsureDllIsInProject(e);
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

				if (onlyIfNotExists && output.Exists)
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
			Project project = e.ProjectItem.ContainingProject;

			var proj = e.ProjectItem.ContainingProject;

			foreach (var name in names)
			{
				AddFromFileWithFolders(proj.ProjectItems, name, dir);
			}
		}

		private bool HasInProject(ProjectItems root, string name)
		{
			var tmp = name.Split('\\');
			for (int i = 0; i < tmp.Length - 1; i++)
			{
				var item = Find(root, tmp[i]);
				if (item == null)
					return false;

				root = item.ProjectItems;
			}

			return Find(root, tmp[tmp.Length - 1]) != null;
		}

		private void AddFromFileWithFolders(ProjectItems root, string name, string dir)
		{
			var pathToNow = dir;
			var tmp = name.Split('\\');
			for (int i = 0; i < tmp.Length - 1; i++)
			{
				string thisDir = tmp[i];
				pathToNow = Path.Combine(pathToNow, thisDir);

				var item = Find(root, thisDir);
				if (item == null)
					item = root.AddFolder(thisDir, EnvDTE.Constants.vsProjectItemKindPhysicalFolder);

				root = item.ProjectItems;
			}

			if (Find(root, tmp[tmp.Length - 1]) == null)
				root.AddFromFile(Path.Combine(dir, name));
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

		private void EnsureDllIsInProject(GenerationEventArgs e)
		{
			AddAssemblyDependency(e, (VSProject) e.ProjectItem.ContainingProject.Object,
			                      Assembly.GetAssembly(typeof (DataContractAttribute)));
		}

		private void AddAssemblyDependency(GenerationEventArgs e, VSProject project, Assembly assembly)
		{
			string assemblyName = assembly.GetName().Name;

			try
			{
				bool hasRef =
					project.References.Cast<Reference>().Any(
						r =>
						r != null && string.Equals(r.Name, assemblyName, StringComparison.InvariantCultureIgnoreCase));

				if (!hasRef)
				{
					Reference dllRef = project.References.Add(assembly.Location);
					dllRef.CopyLocal = false;
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
