using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using f;
using LEncoder;
using ns1;
using ns5;

namespace _0x7_Protector_GUI
{
	public class Login : Form
	{
		public static string License = "";

		public static string lurl = "";

		public const int WM_NCLBUTTONDOWN = 161;

		public const int HT_CAPTION = 2;

		private IContainer eE;

		private SiticoneElipse eF;

		private Panel CPanel;

		private new SiticoneRoundedButton HelpButton;

		private SiticoneRoundedButton LoginButton;

		private SiticoneRoundedButton CopyButton;

		private SiticoneRoundedTextBox IDText;

		private Panel CPanel2;

		private SiticoneImageButton TeleButton;

		private SiticoneImageButton DiscordButton;

		private SiticoneImageButton CImage;

		private Panel SPanel;

		private SiticoneImageButton StatusImage;

		private Panel MPanel;

		private SiticoneControlBox MinButton;

		private SiticoneControlBox MaxButton;

		private SiticoneControlBox EndButton;

		private Panel LPanel1;

		private Panel LPanel2;

		private SiticoneImageButton Logo;

		private ILabel iLabel3;

		private ILabel StatusLabel;

		private ILabel iLabel4;

		private ILabel iLabel2;

		private ILabel iLabel1;

		private ILabel iLabel6;

		public Login()
		{
			InitializeComponent();
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public static bool CheckInternetConnection()
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					using (webClient.OpenRead("http://www.google.com"))
					{
						return true;
					}
				}
			}
			catch
			{
				return false;
			}
		}

		private void fY(object sender, EventArgs e)
		{
			f.e.Parse(Process.GetCurrentProcess());
			f.e.c = true;
			if (IDText.Text != null && !(IDText.Text == ""))
			{
				if (CheckInternetConnection())
				{
					try
					{
						ServicePointManager.Expect100Continue = true;
						ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
						string[] array = new WebClient().DownloadString(lurl).Split(new string[2] { "<br>", "</br>" }, StringSplitOptions.None);
						int num = 0;
						while (true)
						{
							if (num >= array.Length)
							{
								return;
							}
							string obj = array[num];
							if (lurl != f.e.Encoder.Base64Decode("aHR0cHM6Ly9yYXcuZ2l0aHVidXNlcmNvbnRlbnQuY29tL0lueDQwNC8weDcvbWFpbi9MaWNlbnNlcw=="))
							{
								Environment.FailFast("");
							}
							if (!obj.Contains(f.e.Encoder.Encode(License)))
							{
								break;
							}
							StatusImage.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\Verified.png");
							StatusLabel.Text = "Status : you are verified !";
							string contents = f.e.Encoder.ToHexString(License);
							File.WriteAllText(Directory.GetCurrentDirectory() + "\\License.txt", contents);
							if (f.e.Encoder.FromHexString(File.ReadAllText(Directory.GetCurrentDirectory() + "\\License.txt")) == License)
							{
								new GUI().Show();
								Hide();
								return;
							}
							num++;
						}
						StatusImage.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\Unverified.png");
						StatusLabel.Text = "Status : you are not verified !";
						string contents2 = f.e.Encoder.ToHexString(License);
						File.WriteAllText(Directory.GetCurrentDirectory() + "\\License.txt", contents2);
						return;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
						return;
					}
				}
				StatusImage.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\Unverified.png");
				StatusLabel.Text = "Status : No connection !";
			}
			else
			{
				StatusImage.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\Unverified.png");
				StatusLabel.Text = "Status : Error, Empty license !";
			}
		}

		private void fZ(object sender, EventArgs e)
		{
			Clipboard.SetText(IDText.Text);
		}

		private void ga(object sender, EventArgs e)
		{
			new Help().ShowDialog();
		}

		private void gb(object sender, EventArgs e)
		{
			Process.Start("https://discord.com/users/550441121822539834");
		}

		private void gc(object sender, EventArgs e)
		{
			Process.Start("https://t.me/x7C53");
		}

		private void gd(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void ge(object sender, MouseEventArgs e)
		{
			if (MouseButtons.Left == e.Button)
			{
				base.Opacity = 0.96;
				Cursor = Cursors.Hand;
				ReleaseCapture();
				SendMessage(base.Handle, 161, 2, 0);
				base.Opacity = 0.98;
				Cursor = Cursors.Default;
			}
		}

		private void gf(object sender, EventArgs e)
		{
			f.e.a = "1";
			f.e.Parse(Process.GetCurrentProcess());
			try
			{
				if (!File.Exists(Directory.GetCurrentDirectory() + "\\License.txt"))
				{
					File.WriteAllText(Directory.GetCurrentDirectory() + "\\License.txt", "You are not activated !");
				}
				License = HWID.GetSerial() + ".0x7";
				IDText.Text = License;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void gg(object sender, EventArgs e)
		{
			f.e.b = 1;
			lurl = f.e.Encoder.Base64Decode("aHR0cHM6Ly9yYXcuZ2l0aHVidXNlcmNvbnRlbnQuY29tL0lueDQwNC8weDcvbWFpbi9MaWNlbnNlcw==");
			f.e.Parse(Process.GetCurrentProcess());
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && eE != null)
			{
				eE.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.eE = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_0x7_Protector_GUI.Login));
			this.eF = new ns1.SiticoneElipse(this.eE);
			this.LPanel1 = new System.Windows.Forms.Panel();
			this.LPanel2 = new System.Windows.Forms.Panel();
			this.Logo = new ns1.SiticoneImageButton();
			this.MPanel = new System.Windows.Forms.Panel();
			this.MinButton = new ns1.SiticoneControlBox();
			this.MaxButton = new ns1.SiticoneControlBox();
			this.EndButton = new ns1.SiticoneControlBox();
			this.CPanel = new System.Windows.Forms.Panel();
			this.HelpButton = new ns1.SiticoneRoundedButton();
			this.LoginButton = new ns1.SiticoneRoundedButton();
			this.CopyButton = new ns1.SiticoneRoundedButton();
			this.IDText = new ns1.SiticoneRoundedTextBox();
			this.SPanel = new System.Windows.Forms.Panel();
			this.StatusImage = new ns1.SiticoneImageButton();
			this.CPanel2 = new System.Windows.Forms.Panel();
			this.TeleButton = new ns1.SiticoneImageButton();
			this.DiscordButton = new ns1.SiticoneImageButton();
			this.CImage = new ns1.SiticoneImageButton();
			this.iLabel3 = new ILabel();
			this.StatusLabel = new ILabel();
			this.iLabel4 = new ILabel();
			this.iLabel6 = new ILabel();
			this.iLabel2 = new ILabel();
			this.iLabel1 = new ILabel();
			this.LPanel1.SuspendLayout();
			this.LPanel2.SuspendLayout();
			this.MPanel.SuspendLayout();
			this.CPanel.SuspendLayout();
			this.SPanel.SuspendLayout();
			this.CPanel2.SuspendLayout();
			base.SuspendLayout();
			this.eF.BorderRadius = 4;
			this.eF.TargetControl = this;
			this.LPanel1.BackColor = System.Drawing.Color.FromArgb(229, 57, 53);
			this.LPanel1.Controls.Add(this.iLabel2);
			this.LPanel1.Controls.Add(this.iLabel1);
			this.LPanel1.Controls.Add(this.LPanel2);
			this.LPanel1.Location = new System.Drawing.Point(0, 39);
			this.LPanel1.Name = "LPanel1";
			this.LPanel1.Size = new System.Drawing.Size(320, 320);
			this.LPanel1.TabIndex = 0;
			this.LPanel2.BackColor = System.Drawing.Color.FromArgb(232, 97, 93);
			this.LPanel2.Controls.Add(this.Logo);
			this.LPanel2.Location = new System.Drawing.Point(40, 0);
			this.LPanel2.Name = "LPanel2";
			this.LPanel2.Size = new System.Drawing.Size(280, 150);
			this.LPanel2.TabIndex = 0;
			this.Logo.CheckedState.Parent = this.Logo;
			this.Logo.HoveredState.ImageSize = new System.Drawing.Size(96, 96);
			this.Logo.HoveredState.Parent = this.Logo;
			this.Logo.Image = (System.Drawing.Image)resources.GetObject("Logo.Image");
			this.Logo.ImageSize = new System.Drawing.Size(96, 96);
			this.Logo.Location = new System.Drawing.Point(72, 27);
			this.Logo.Name = "Logo";
			this.Logo.PressedState.ImageSize = new System.Drawing.Size(96, 96);
			this.Logo.PressedState.Parent = this.Logo;
			this.Logo.Size = new System.Drawing.Size(96, 96);
			this.Logo.TabIndex = 0;
			this.MPanel.BackColor = System.Drawing.Color.FromArgb(10, 10, 10);
			this.MPanel.Controls.Add(this.iLabel6);
			this.MPanel.Controls.Add(this.MinButton);
			this.MPanel.Controls.Add(this.MaxButton);
			this.MPanel.Controls.Add(this.EndButton);
			this.MPanel.Location = new System.Drawing.Point(0, 0);
			this.MPanel.Name = "MPanel";
			this.MPanel.Size = new System.Drawing.Size(800, 40);
			this.MPanel.TabIndex = 1;
			this.MPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(ge);
			this.MinButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.MinButton.ControlBoxType = ns5.ControlBoxType.MinimizeBox;
			this.MinButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MinButton.FillColor = System.Drawing.Color.FromArgb(10, 10, 10);
			this.MinButton.HoveredState.Parent = this.MinButton;
			this.MinButton.IconColor = System.Drawing.Color.White;
			this.MinButton.Location = new System.Drawing.Point(680, 0);
			this.MinButton.Name = "MinButton";
			this.MinButton.ShadowDecoration.Parent = this.MinButton;
			this.MinButton.Size = new System.Drawing.Size(40, 40);
			this.MinButton.TabIndex = 6;
			this.MaxButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.MaxButton.ControlBoxType = ns5.ControlBoxType.MaximizeBox;
			this.MaxButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MaxButton.FillColor = System.Drawing.Color.FromArgb(10, 10, 10);
			this.MaxButton.HoveredState.Parent = this.MaxButton;
			this.MaxButton.IconColor = System.Drawing.Color.White;
			this.MaxButton.Location = new System.Drawing.Point(720, 0);
			this.MaxButton.Name = "MaxButton";
			this.MaxButton.ShadowDecoration.Parent = this.MaxButton;
			this.MaxButton.Size = new System.Drawing.Size(40, 40);
			this.MaxButton.TabIndex = 5;
			this.EndButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.EndButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.EndButton.FillColor = System.Drawing.Color.FromArgb(10, 10, 10);
			this.EndButton.HoveredState.Parent = this.EndButton;
			this.EndButton.IconColor = System.Drawing.Color.White;
			this.EndButton.Location = new System.Drawing.Point(760, 0);
			this.EndButton.Name = "EndButton";
			this.EndButton.ShadowDecoration.Parent = this.EndButton;
			this.EndButton.Size = new System.Drawing.Size(40, 40);
			this.EndButton.TabIndex = 2;
			this.EndButton.Click += new System.EventHandler(gd);
			this.CPanel.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
			this.CPanel.Controls.Add(this.iLabel3);
			this.CPanel.Controls.Add(this.HelpButton);
			this.CPanel.Controls.Add(this.LoginButton);
			this.CPanel.Controls.Add(this.CopyButton);
			this.CPanel.Controls.Add(this.IDText);
			this.CPanel.Controls.Add(this.SPanel);
			this.CPanel.Controls.Add(this.CPanel2);
			this.CPanel.Location = new System.Drawing.Point(319, 39);
			this.CPanel.Name = "CPanel";
			this.CPanel.Size = new System.Drawing.Size(481, 320);
			this.CPanel.TabIndex = 2;
			this.HelpButton.CheckedState.Parent = this.HelpButton;
			this.HelpButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.HelpButton.CustomImages.Parent = this.HelpButton;
			this.HelpButton.FillColor = System.Drawing.Color.FromArgb(229, 57, 53);
			this.HelpButton.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.HelpButton.ForeColor = System.Drawing.Color.White;
			this.HelpButton.HoveredState.Parent = this.HelpButton;
			this.HelpButton.Image = (System.Drawing.Image)resources.GetObject("HelpButton.Image");
			this.HelpButton.ImageSize = new System.Drawing.Size(24, 24);
			this.HelpButton.Location = new System.Drawing.Point(32, 109);
			this.HelpButton.Name = "HelpButton";
			this.HelpButton.ShadowDecoration.Parent = this.HelpButton;
			this.HelpButton.Size = new System.Drawing.Size(110, 40);
			this.HelpButton.TabIndex = 19;
			this.HelpButton.Text = "Help";
			this.HelpButton.Click += new System.EventHandler(ga);
			this.LoginButton.CheckedState.Parent = this.LoginButton;
			this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LoginButton.CustomImages.Parent = this.LoginButton;
			this.LoginButton.FillColor = System.Drawing.Color.FromArgb(229, 57, 53);
			this.LoginButton.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.LoginButton.ForeColor = System.Drawing.Color.White;
			this.LoginButton.HoveredState.Parent = this.LoginButton;
			this.LoginButton.Image = (System.Drawing.Image)resources.GetObject("LoginButton.Image");
			this.LoginButton.ImageSize = new System.Drawing.Size(24, 24);
			this.LoginButton.Location = new System.Drawing.Point(264, 109);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.ShadowDecoration.Parent = this.LoginButton;
			this.LoginButton.Size = new System.Drawing.Size(184, 40);
			this.LoginButton.TabIndex = 18;
			this.LoginButton.Text = "Login";
			this.LoginButton.Click += new System.EventHandler(fY);
			this.CopyButton.CheckedState.Parent = this.CopyButton;
			this.CopyButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CopyButton.CustomImages.Parent = this.CopyButton;
			this.CopyButton.FillColor = System.Drawing.Color.FromArgb(229, 57, 53);
			this.CopyButton.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.CopyButton.ForeColor = System.Drawing.Color.White;
			this.CopyButton.HoveredState.Parent = this.CopyButton;
			this.CopyButton.Image = (System.Drawing.Image)resources.GetObject("CopyButton.Image");
			this.CopyButton.ImageSize = new System.Drawing.Size(24, 24);
			this.CopyButton.Location = new System.Drawing.Point(148, 109);
			this.CopyButton.Name = "CopyButton";
			this.CopyButton.ShadowDecoration.Parent = this.CopyButton;
			this.CopyButton.Size = new System.Drawing.Size(110, 40);
			this.CopyButton.TabIndex = 17;
			this.CopyButton.Text = "Copy";
			this.CopyButton.Click += new System.EventHandler(fZ);
			this.IDText.BorderColor = System.Drawing.Color.FromArgb(229, 57, 53);
			this.IDText.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.IDText.DefaultText = "";
			this.IDText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			this.IDText.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			this.IDText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			this.IDText.DisabledState.Parent = this.IDText;
			this.IDText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			this.IDText.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
			this.IDText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(232, 97, 93);
			this.IDText.FocusedState.Parent = this.IDText;
			this.IDText.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
			this.IDText.HoveredState.BorderColor = System.Drawing.Color.FromArgb(232, 97, 93);
			this.IDText.HoveredState.Parent = this.IDText;
			this.IDText.IconLeft = (System.Drawing.Image)resources.GetObject("IDText.IconLeft");
			this.IDText.IconLeftOffset = new System.Drawing.Point(5, 0);
			this.IDText.IconLeftSize = new System.Drawing.Size(24, 24);
			this.IDText.Location = new System.Drawing.Point(32, 64);
			this.IDText.Name = "IDText";
			this.IDText.PasswordChar = '\0';
			this.IDText.PlaceholderText = "";
			this.IDText.ReadOnly = true;
			this.IDText.SelectedText = "";
			this.IDText.ShadowDecoration.Parent = this.IDText;
			this.IDText.Size = new System.Drawing.Size(416, 36);
			this.IDText.TabIndex = 16;
			this.IDText.TextOffset = new System.Drawing.Point(1, 0);
			this.SPanel.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
			this.SPanel.Controls.Add(this.StatusLabel);
			this.SPanel.Controls.Add(this.StatusImage);
			this.SPanel.Location = new System.Drawing.Point(0, 250);
			this.SPanel.Name = "SPanel";
			this.SPanel.Size = new System.Drawing.Size(481, 70);
			this.SPanel.TabIndex = 6;
			this.StatusImage.CheckedState.Parent = this.StatusImage;
			this.StatusImage.HoveredState.ImageSize = new System.Drawing.Size(30, 30);
			this.StatusImage.HoveredState.Parent = this.StatusImage;
			this.StatusImage.Image = (System.Drawing.Image)resources.GetObject("StatusImage.Image");
			this.StatusImage.ImageSize = new System.Drawing.Size(30, 30);
			this.StatusImage.Location = new System.Drawing.Point(21, 22);
			this.StatusImage.Name = "StatusImage";
			this.StatusImage.PressedState.ImageSize = new System.Drawing.Size(30, 30);
			this.StatusImage.PressedState.Parent = this.StatusImage;
			this.StatusImage.Size = new System.Drawing.Size(30, 30);
			this.StatusImage.TabIndex = 5;
			this.CPanel2.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
			this.CPanel2.Controls.Add(this.iLabel4);
			this.CPanel2.Controls.Add(this.TeleButton);
			this.CPanel2.Controls.Add(this.DiscordButton);
			this.CPanel2.Controls.Add(this.CImage);
			this.CPanel2.Location = new System.Drawing.Point(0, 178);
			this.CPanel2.Name = "CPanel2";
			this.CPanel2.Size = new System.Drawing.Size(481, 70);
			this.CPanel2.TabIndex = 14;
			this.TeleButton.CheckedState.Parent = this.TeleButton;
			this.TeleButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.TeleButton.HoveredState.ImageSize = new System.Drawing.Size(29, 29);
			this.TeleButton.HoveredState.Parent = this.TeleButton;
			this.TeleButton.Image = (System.Drawing.Image)resources.GetObject("TeleButton.Image");
			this.TeleButton.ImageSize = new System.Drawing.Size(30, 30);
			this.TeleButton.Location = new System.Drawing.Point(205, 23);
			this.TeleButton.Name = "TeleButton";
			this.TeleButton.PressedState.Parent = this.TeleButton;
			this.TeleButton.Size = new System.Drawing.Size(28, 28);
			this.TeleButton.TabIndex = 7;
			this.TeleButton.Click += new System.EventHandler(gc);
			this.DiscordButton.CheckedState.Parent = this.DiscordButton;
			this.DiscordButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.DiscordButton.HoveredState.ImageSize = new System.Drawing.Size(29, 29);
			this.DiscordButton.HoveredState.Parent = this.DiscordButton;
			this.DiscordButton.Image = (System.Drawing.Image)resources.GetObject("DiscordButton.Image");
			this.DiscordButton.ImageSize = new System.Drawing.Size(30, 30);
			this.DiscordButton.Location = new System.Drawing.Point(165, 23);
			this.DiscordButton.Name = "DiscordButton";
			this.DiscordButton.PressedState.ImageSize = new System.Drawing.Size(28, 28);
			this.DiscordButton.PressedState.Parent = this.DiscordButton;
			this.DiscordButton.Size = new System.Drawing.Size(30, 30);
			this.DiscordButton.TabIndex = 6;
			this.DiscordButton.Click += new System.EventHandler(gb);
			this.CImage.CheckedState.Parent = this.CImage;
			this.CImage.HoveredState.ImageSize = new System.Drawing.Size(30, 30);
			this.CImage.HoveredState.Parent = this.CImage;
			this.CImage.Image = (System.Drawing.Image)resources.GetObject("CImage.Image");
			this.CImage.ImageSize = new System.Drawing.Size(30, 30);
			this.CImage.Location = new System.Drawing.Point(21, 22);
			this.CImage.Name = "CImage";
			this.CImage.PressedState.ImageSize = new System.Drawing.Size(30, 30);
			this.CImage.PressedState.Parent = this.CImage;
			this.CImage.Size = new System.Drawing.Size(30, 30);
			this.CImage.TabIndex = 5;
			this.iLabel3.AutoSize = true;
			this.iLabel3.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
			this.iLabel3.ForeColor = System.Drawing.Color.White;
			this.iLabel3.Location = new System.Drawing.Point(194, 17);
			this.iLabel3.Name = "iLabel3";
			this.iLabel3.Size = new System.Drawing.Size(94, 32);
			this.iLabel3.TabIndex = 27;
			this.iLabel3.Text = "Sign in";
			this.iLabel3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 11f);
			this.StatusLabel.ForeColor = System.Drawing.Color.White;
			this.StatusLabel.Location = new System.Drawing.Point(57, 25);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(177, 20);
			this.StatusLabel.TabIndex = 28;
			this.StatusLabel.Text = "Status: Waiting for user ....";
			this.StatusLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.iLabel4.AutoSize = true;
			this.iLabel4.Font = new System.Drawing.Font("Segoe UI", 11f);
			this.iLabel4.ForeColor = System.Drawing.Color.White;
			this.iLabel4.Location = new System.Drawing.Point(57, 27);
			this.iLabel4.Name = "iLabel4";
			this.iLabel4.Size = new System.Drawing.Size(97, 20);
			this.iLabel4.TabIndex = 27;
			this.iLabel4.Text = "Reach me via";
			this.iLabel4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.iLabel6.AutoSize = true;
			this.iLabel6.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.iLabel6.ForeColor = System.Drawing.Color.White;
			this.iLabel6.Location = new System.Drawing.Point(8, 10);
			this.iLabel6.Name = "iLabel6";
			this.iLabel6.Size = new System.Drawing.Size(43, 19);
			this.iLabel6.TabIndex = 25;
			this.iLabel6.Text = "Login";
			this.iLabel6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.iLabel6.MouseDown += new System.Windows.Forms.MouseEventHandler(ge);
			this.iLabel2.AutoSize = true;
			this.iLabel2.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
			this.iLabel2.ForeColor = System.Drawing.Color.White;
			this.iLabel2.Location = new System.Drawing.Point(63, 204);
			this.iLabel2.Name = "iLabel2";
			this.iLabel2.Size = new System.Drawing.Size(195, 32);
			this.iLabel2.TabIndex = 26;
			this.iLabel2.Text = "Welcome Back !";
			this.iLabel2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.iLabel1.AutoSize = true;
			this.iLabel1.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
			this.iLabel1.ForeColor = System.Drawing.Color.White;
			this.iLabel1.Location = new System.Drawing.Point(96, 172);
			this.iLabel1.Name = "iLabel1";
			this.iLabel1.Size = new System.Drawing.Size(129, 32);
			this.iLabel1.TabIndex = 25;
			this.iLabel1.Text = "Hooooray";
			this.iLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
			base.ClientSize = new System.Drawing.Size(800, 360);
			base.Controls.Add(this.CPanel);
			base.Controls.Add(this.MPanel);
			base.Controls.Add(this.LPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(800, 360);
			base.Name = "Login";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login 0x7 Protector";
			base.Load += new System.EventHandler(gg);
			base.Shown += new System.EventHandler(gf);
			this.LPanel1.ResumeLayout(false);
			this.LPanel1.PerformLayout();
			this.LPanel2.ResumeLayout(false);
			this.MPanel.ResumeLayout(false);
			this.MPanel.PerformLayout();
			this.CPanel.ResumeLayout(false);
			this.CPanel.PerformLayout();
			this.SPanel.ResumeLayout(false);
			this.SPanel.PerformLayout();
			this.CPanel2.ResumeLayout(false);
			this.CPanel2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
