using System;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace f
{
	internal class e
	{
		public static class Encoder
		{
			public static string ToHexString(string str)
			{
				StringBuilder stringBuilder = new StringBuilder();
				byte[] bytes = Encoding.Unicode.GetBytes(str);
				foreach (byte b in bytes)
				{
					stringBuilder.Append(b.ToString("X2"));
				}
				return stringBuilder.ToString();
			}

			public static string FromHexString(string hexString)
			{
				byte[] array = new byte[hexString.Length / 2];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
				}
				return Encoding.Unicode.GetString(array);
			}

			public static string Base64Encode(string plainText)
			{
				return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
			}

			public static string Base64Decode(string base64EncodedData)
			{
				byte[] bytes = Convert.FromBase64String(base64EncodedData);
				return Encoding.UTF8.GetString(bytes);
			}

			public static string Encode(string content)
			{
				return Base64Encode(ToHexString(content));
			}

			public static string Decode(string content)
			{
				return FromHexString(Base64Decode(content));
			}
		}

		public static bool g = false;

		public static string a = "0";

		public static int b = 0;

		public static bool c = false;

		public static bool h(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			if (sslPolicyErrors <= SslPolicyErrors.None)
			{
				if (chain.ChainPolicy.VerificationFlags == X509VerificationFlags.NoFlag && chain.ChainPolicy.RevocationMode == X509RevocationMode.Online)
				{
					return true;
				}
				X509Chain x509Chain = new X509Chain();
				X509ChainElementCollection chainElements = chain.ChainElements;
				for (int i = 1; i < chainElements.Count - 1; i++)
				{
					x509Chain.ChainPolicy.ExtraStore.Add(chainElements[i].Certificate);
				}
				return x509Chain.Build(chainElements[0].Certificate);
			}
			return false;
		}

		public static void Parse(Process CurrentProcess)
		{
			try
			{
				WebRequest.DefaultWebProxy = new WebProxy();
				ServicePointManager.CheckCertificateRevocationList = true;
				HttpWebRequest obj = WebRequest.Create("https://google.com") as HttpWebRequest;
				obj.Timeout = 10000;
				obj.ContinueTimeout = 10000;
				obj.ReadWriteTimeout = 10000;
				obj.KeepAlive = true;
				obj.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:75.0) Gecko/20100101 Firefox/75.0";
				obj.Host = "www.google.com";
				obj.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
				obj.Method = "GET";
				obj.ServerCertificateValidationCallback = h;
				using (HttpWebResponse httpWebResponse = obj.GetResponse() as HttpWebResponse)
				{
					if (httpWebResponse.StatusCode == HttpStatusCode.OK)
					{
						httpWebResponse.Close();
						return;
					}
					httpWebResponse.Close();
					Environment.FailFast("");
					Environment.Exit(0);
					CurrentProcess.Kill();
				}
			}
			catch
			{
				Environment.FailFast("");
				Environment.Exit(0);
				CurrentProcess.Kill();
			}
		}
	}
}
