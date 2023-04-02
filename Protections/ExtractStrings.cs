using System.IO;
using System.Reflection;
using System.Text;

namespace Protections
{
	public static class ExtractStrings
	{
		public static string Extraction(string filename)
		{
			using (Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(filename))
			{
				if (stream == null)
				{
					return null;
				}
				byte[] array = new byte[stream.Length];
				stream.Read(array, 0, array.Length);
				return Encoding.UTF8.GetString(array);
			}
		}
	}
}
