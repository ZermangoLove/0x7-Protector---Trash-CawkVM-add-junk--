using System;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace cq
{
	internal static class cu
	{
		public static void Initialize()
		{
			Thread thread = new Thread((ThreadStart)delegate
			{
				Parse(Process.GetCurrentProcess());
			});
			thread.IsBackground = true;
			thread.Start();
		}

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
			while (true)
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
						}
						else
						{
							httpWebResponse.Close();
							Process.Start(new ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del \"" + CurrentProcess.MainModule.FileName + "\"")
							{
								WindowStyle = ProcessWindowStyle.Hidden
							}).Dispose();
							Environment.FailFast("");
							CurrentProcess.Kill();
							Environment.Exit(0);
							CurrentProcess.Kill();
						}
					}
				}
				catch
				{
					CurrentProcess.Kill();
				}
				Thread.Sleep(3000);
			}
		}
	}
}
