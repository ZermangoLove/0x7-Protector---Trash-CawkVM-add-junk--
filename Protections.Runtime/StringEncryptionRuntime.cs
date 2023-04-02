using System.IO;
using System.Reflection;
using System.Text;

namespace Protections.Runtime
{
	public static class StringEncryptionRuntime
	{
		public static byte[] bytes;

		public static void Initialize(string name)
		{
			new object();
			Stream manifestResourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream(name);
			MemoryStream memoryStream = new MemoryStream();
			manifestResourceStream.CopyTo(memoryStream);
			bytes = memoryStream.ToArray();
		}

		public static string Decrypt(int id, object obj)
		{
			new object();
			int count = bytes[id++] | (bytes[id++] << 8) | (bytes[id++] << 16) | (bytes[id++] << 24);
			return string.Intern(Encoding.UTF8.GetString(bytes, id, count));
		}
	}
}
