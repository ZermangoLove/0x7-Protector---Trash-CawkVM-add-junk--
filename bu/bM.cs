using System;
using System.IO;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using ICore;

namespace bu
{
	internal static class bM
	{
		private static void bN(string sourceFilePath, string destinationFilePath)
		{
			string[] source = File.ReadAllLines(sourceFilePath, Encoding.Default);
			File.WriteAllLines(destinationFilePath, source.Distinct().ToArray(), Encoding.Default);
		}

		public static void bO(Context context)
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Map.map";
			File.WriteAllText(text, null);
			using (StreamWriter streamWriter = new StreamWriter(File.OpenWrite(text)))
			{
				foreach (TypeDef type in context.Module.GetTypes())
				{
					foreach (MethodDef method in type.Methods)
					{
						foreach (FieldDef field in type.Fields)
						{
							streamWriter.WriteLine("{0}\n{1}", string.Concat("Old method name: ", method.Name, " / MDToken: ", method.MDToken.ToString()), "Field: " + field.Name);
						}
					}
				}
				streamWriter.Flush();
				streamWriter.Close();
			}
			bN(text, text);
		}

		public static void bP(Context context)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Map.map";
			string[] array = File.ReadAllLines(path);
			using (StreamWriter streamWriter = new StreamWriter(File.OpenWrite(path)))
			{
				foreach (TypeDef type in context.Module.GetTypes())
				{
					foreach (MethodDef method in type.Methods)
					{
						string[] array2 = array;
						foreach (string text in array2)
						{
							if (text.Contains(method.MDToken.ToString()))
							{
								streamWriter.WriteLine(text.Substring(0, text.LastIndexOf('/')) + Environment.NewLine + "New method name: " + method.Name);
							}
						}
					}
				}
				streamWriter.Flush();
				streamWriter.Close();
			}
		}
	}
}
