using System.Text;

namespace Core.ByteEncryption
{
	internal class Xor
	{
		public static string XorProcess(string text, string key)
		{
			int num = 1018054993;
			int num2 = 1;
			int num3 = default(int);
			StringBuilder stringBuilder = default(StringBuilder);
			while (true)
			{
				if (num2 == 1018054997 - num)
				{
					goto IL_007e;
				}
				goto IL_00bc;
				IL_00bc:
				if (num2 == -1018054987 + num)
				{
					goto IL_0028;
				}
				goto IL_006a;
				IL_006a:
				if (num2 == -1018054988 + num)
				{
					num3 += 1018054994 - num;
					num2 = 0x3CAE4957 ^ num;
				}
				if (num2 != 1018054996 - num)
				{
					if (num2 == -1018054991 + num)
					{
						num3 = 1018054993 - num;
						num2 = -1018054990 + num;
					}
					if (num2 == (0x3CAE4950 ^ num))
					{
						stringBuilder = new StringBuilder();
						num2 = -1018054991 + num;
					}
					if (num2 == 1018054993 - num)
					{
						num2 = 1018054994 - num;
					}
					if (num2 == -1018054986 + num)
					{
						break;
					}
					continue;
				}
				goto IL_0028;
				IL_007e:
				stringBuilder.Append((char)(text[num3] ^ key[num3 % key.Length]));
				num2 = 0x3CAE4954 ^ num;
				goto IL_00bc;
				IL_0028:
				if (num3 >= text.Length)
				{
					num2 = 0x3CAE4956 ^ num;
					goto IL_006a;
				}
				goto IL_007e;
			}
			return stringBuilder.ToString();
		}
	}
}
