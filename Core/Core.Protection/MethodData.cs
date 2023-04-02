using dnlib.DotNet;

namespace Core.Protection
{
	public class MethodData
	{
		public MethodDef Method;

		public byte[] DecryptedBytes;

		public byte[] EncryptedBytes;

		public bool Converted;

		public bool Encrypted;

		public int ID;

		public int size;

		public int cipherSize;

		public int position;

		public MethodData(MethodDef methods)
		{
			Method = methods;
		}
	}
}
