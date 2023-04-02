using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace U
{
	internal static class ac
	{
		private static void Init()
		{
			Thread thread = new Thread((ThreadStart)delegate
			{
				DoWork();
			});
			thread.IsBackground = true;
			thread.Start();
		}

		private static void DoWork()
		{
			while (true)
			{
				string str = MutationClass.Str2;
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				if (File.Exists(folderPath + "\\Microsoft\\IVM.note"))
				{
					File.WriteAllBytes(Directory.GetCurrentDirectory() + "\\You are banned !", new byte[1]);
					Environment.Exit(0);
				}
				string[] array = new string[56]
				{
					"CosMos", "SimpleAssemblyExplorer", "StringDecryptor", "CodeCracker", "x32dbg", "x64dbg", "ollydbg", "simpleassembly", "httpanalyzer", "httpdebug",
					"fiddler", "processhacker", "scylla_x86", "scylla_x64", "scylla", "IMMUNITYDEBUGGER", "MegaDumper", "reshacker", "cheat engine", "solarwinds",
					"HTTPDebuggerSvc", "netcheat", "megadumper", "ilspy", "reflector", "exeinfope", "DetectItEasy", "Exeinfo PE", "Process Hacker", "HTTP Debugger",
					"dnSpy", "Fiddler Everywhere", "ExtremeDumper", "KsDumper", "ollydbg", "HxD", "dumper", "Progress Telerik Fiddler Web Debugger", "dnSpy-x86", "cheat engine",
					"Cheat Engine", "cheatengine", "cheatengine-x86_64", "HTTPDebuggerUI", "ProcessHacker", "x32dbg", "x64dbg", "DotNetDataCollector32", "DotNetDataCollector64", "CFF Explorer",
					"M*3*G*4**D*u*m*p*3*R*", "ĘẍtŗęḿęĎựḿҏęŗ", "solarwinds", "HTTPDebuggerSvc", "HTTPDebuggerUI", "netcheat"
				};
				Process[] processes = Process.GetProcesses();
				foreach (Process process in processes)
				{
					string[] array2 = array;
					foreach (string text in array2)
					{
						if (!process.ProcessName.ToLower().Contains(text.ToLower()))
						{
							continue;
						}
						string text2 = "easyanticheat";
						string text3 = "eac";
						if (process.ProcessName.ToLower().Contains(text2.ToLower()) || process.ProcessName.ToLower().Contains(text3.ToLower()))
						{
							return;
						}
						try
						{
							if (str == "0")
							{
								process.Kill();
								Environment.Exit(0);
							}
							else if (str == "1")
							{
								File.WriteAllText(folderPath + "\\Microsoft\\IVM.note", "");
								new FileInfo(folderPath + "\\Microsoft\\IVM.note").Attributes = FileAttributes.Hidden;
								process.Kill();
								Environment.Exit(0);
							}
						}
						catch
						{
							process.CloseMainWindow();
							Environment.Exit(0);
							Environment.FailFast("");
						}
					}
				}
				Thread.Sleep(3000);
			}
		}
	}
}
