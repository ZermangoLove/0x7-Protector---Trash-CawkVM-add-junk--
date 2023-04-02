using System.Text;

namespace Core.ByteEncryption
{
	public class EBytes
	{
		private byte[] Keys { get; set; }

		public EBytes(string password)
		{
			Keys = Encoding.ASCII.GetBytes(password);
		}

		public byte[] Encrypt(byte[] data)
		{
			int num = 392210043;
			int num2 = 1;
			int num3 = default(int);
			while (true)
			{
				if (num2 == (0x1760A67F ^ num))
				{
					num3 += 0x1760A67A ^ num;
					num2 = 0x1760A67E ^ num;
				}
				if (num2 == -392210038 + num)
				{
					goto IL_0025;
				}
				goto IL_008f;
				IL_0031:
				data[num3] = (byte)(data[num3] ^ Keys[num3 % Keys.Length]);
				num2 = 0x1760A67F ^ num;
				goto IL_006d;
				IL_0025:
				if (num3 < data.Length)
				{
					goto IL_0031;
				}
				num2 = 0x1760A67D ^ num;
				goto IL_008f;
				IL_008f:
				if (num2 == (0x1760A678 ^ num))
				{
					goto IL_0031;
				}
				goto IL_006d;
				IL_006d:
				if (num2 == (0x1760A679 ^ num))
				{
					goto IL_0025;
				}
				if (num2 == 392210044 - num)
				{
					num3 = -392210043 + num;
					num2 = 392210045 - num;
				}
				if (num2 == -392210043 + num)
				{
					num2 = -392210042 + num;
				}
				if (num2 == -392210037 + num)
				{
					break;
				}
			}
			return data;
		}
	}
}
