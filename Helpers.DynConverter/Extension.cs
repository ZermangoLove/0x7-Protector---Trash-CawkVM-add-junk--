using System.IO;
using dnlib.DotNet;

namespace Helpers.DynConverter
{
	public static class Extension
	{
		public static void ConvertToBytes(this BinaryWriter writer, MethodDef method)
		{
			new Converter(method, writer).ConvertToBytes();
		}
	}
}
