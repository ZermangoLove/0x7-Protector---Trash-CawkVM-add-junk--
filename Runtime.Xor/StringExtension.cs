using System.Text;

namespace Runtime.Xor
{
	public static class StringExtension
	{
		public static string Xor0(string szPlainText)
		{
			StringBuilder stringBuilder = new StringBuilder(szPlainText);
			StringBuilder stringBuilder2 = new StringBuilder(szPlainText.Length);
			for (int i = 0; i < szPlainText.Length; i++)
			{
				char c = stringBuilder[i];
				c = (char)(c ^ 1u);
				stringBuilder2.Append(c);
			}
			return stringBuilder2.ToString();
		}

		public static string Xor2(string inputString)
		{
			char c = 'ع';
			string text = "";
			int length = inputString.Length;
			for (int i = 0; i < length; i++)
			{
				text += char.ToString((char)(inputString[i] ^ c));
			}
			return text;
		}

		public static string Xor3(string text)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				stringBuilder.Append((char)(text[i] ^ "0x7/"[i % "0x7/".Length]));
			}
			return stringBuilder.ToString();
		}

		public static string Xor(string text, string key)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				stringBuilder.Append((char)(text[i] ^ key[i % key.Length]));
			}
			return stringBuilder.ToString();
		}
	}
}
