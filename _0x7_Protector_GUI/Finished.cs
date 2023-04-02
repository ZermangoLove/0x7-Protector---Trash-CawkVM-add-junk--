using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ICore;
using ns1;

namespace _0x7_Protector_GUI
{
	public class Finished : Form
	{
		public const int WM_NCLBUTTONDOWN = 161;

		public const int HT_CAPTION = 2;

		private IContainer eE;

		private SiticoneElipse eF;

		private SiticoneImageButton siticoneImageButton1;

		private SiticoneRoundedButton OkButton;

		private SiticoneRoundedButton BrowseFile;

		private Panel panel1;

		private SiticoneControlBox siticoneControlBox3;

		private SiticoneImageButton Logo;

		private Panel MPanel;

		private SiticoneControlBox EndButton;

		private ILabel iLabel2;

		private ILabel iLabel1;

		public Finished()
		{
			InitializeComponent();
		}

		private void eG(object sender, EventArgs e)
		{
			base.Opacity = 0.98;
		}

		private void eH(object sender, EventArgs e)
		{
			if (GUI.Virt)
			{
				Environment.Exit(0);
			}
			Close();
		}

		private void eI(object sender, EventArgs e)
		{
			if (Context.samePath)
			{
				Process.Start(GUI.browseDir2);
			}
			else
			{
				Process.Start(GUI.browseDir);
			}
			if (GUI.Virt)
			{
				Environment.Exit(0);
			}
			Close();
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		private void eJ(object sender, MouseEventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_0x7_Protector_GUI.Finished));
			this.eF = new ns1.SiticoneElipse(this.eE);
			this.OkButton = new ns1.SiticoneRoundedButton();
			this.BrowseFile = new ns1.SiticoneRoundedButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.siticoneControlBox3 = new ns1.SiticoneControlBox();
			this.Logo = new ns1.SiticoneImageButton();
			this.MPanel = new System.Windows.Forms.Panel();
			this.EndButton = new ns1.SiticoneControlBox();
			this.iLabel1 = new ILabel();
			this.iLabel2 = new ILabel();
			this.panel1.SuspendLayout();
			this.MPanel.SuspendLayout();
			base.SuspendLayout();
			this.eF.BorderRadius = 4;
			this.eF.TargetControl = this;
			this.OkButton.BorderColor = System.Drawing.Color.FromArgb(229, 57, 53);
			this.OkButton.BorderThickness = 1;
			this.OkButton.CheckedState.Parent = this.OkButton;
			this.OkButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.OkButton.CustomImages.Parent = this.OkButton;
			this.OkButton.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
			this.OkButton.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.OkButton.ForeColor = System.Drawing.Color.White;
			this.OkButton.HoveredState.Parent = this.OkButton;
			this.OkButton.ImageSize = new System.Drawing.Size(24, 24);
			this.OkButton.Location = new System.Drawing.Point(388, 113);
			this.OkButton.Name = "OkButton";
			this.OkButton.ShadowDecoration.Parent = this.OkButton;
			this.OkButton.Size = new System.Drawing.Size(80, 36);
			this.OkButton.TabIndex = 21;
			this.OkButton.Text = "Okay";
			this.OkButton.Click += new System.EventHandler(eH);
			this.BrowseFile.BorderColor = System.Drawing.Color.FromArgb(229, 57, 53);
			this.BrowseFile.BorderThickness = 1;
			this.BrowseFile.CheckedState.Parent = this.BrowseFile;
			this.BrowseFile.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BrowseFile.CustomImages.Parent = this.BrowseFile;
			this.BrowseFile.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
			this.BrowseFile.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.BrowseFile.ForeColor = System.Drawing.Color.White;
			this.BrowseFile.HoveredState.Parent = this.BrowseFile;
			this.BrowseFile.ImageSize = new System.Drawing.Size(24, 24);
			this.BrowseFile.Location = new System.Drawing.Point(242, 113);
			this.BrowseFile.Name = "BrowseFile";
			this.BrowseFile.ShadowDecoration.Parent = this.BrowseFile;
			this.BrowseFile.Size = new System.Drawing.Size(140, 36);
			this.BrowseFile.TabIndex = 22;
			this.BrowseFile.Text = "Browse file";
			this.BrowseFile.Click += new System.EventHandler(eI);
			this.panel1.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
			this.panel1.Controls.Add(this.iLabel2);
			this.panel1.Controls.Add(this.siticoneControlBox3);
			this.panel1.Controls.Add(this.BrowseFile);
			this.panel1.Controls.Add(this.Logo);
			this.panel1.Controls.Add(this.OkButton);
			this.panel1.Location = new System.Drawing.Point(0, 39);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(480, 160);
			this.panel1.TabIndex = 24;
			this.siticoneControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.siticoneControlBox3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.siticoneControlBox3.FillColor = System.Drawing.Color.FromArgb(10, 10, 10);
			this.siticoneControlBox3.HoveredState.Parent = this.siticoneControlBox3;
			this.siticoneControlBox3.IconColor = System.Drawing.Color.White;
			this.siticoneControlBox3.Location = new System.Drawing.Point(-87, 0);
			this.siticoneControlBox3.Name = "siticoneControlBox3";
			this.siticoneControlBox3.ShadowDecoration.Parent = this.siticoneControlBox3;
			this.siticoneControlBox3.Size = new System.Drawing.Size(29, 40);
			this.siticoneControlBox3.TabIndex = 2;
			this.Logo.CheckedState.Parent = this.Logo;
			this.Logo.HoveredState.ImageSize = new System.Drawing.Size(60, 60);
			this.Logo.HoveredState.Parent = this.Logo;
			this.Logo.Image = (System.Drawing.Image)resources.GetObject("Logo.Image");
			this.Logo.ImageSize = new System.Drawing.Size(60, 60);
			this.Logo.Location = new System.Drawing.Point(44, 50);
			this.Logo.Name = "Logo";
			this.Logo.PressedState.ImageSize = new System.Drawing.Size(60, 60);
			this.Logo.PressedState.Parent = this.Logo;
			this.Logo.Size = new System.Drawing.Size(60, 60);
			this.Logo.TabIndex = 3;
			this.MPanel.BackColor = System.Drawing.Color.FromArgb(10, 10, 10);
			this.MPanel.Controls.Add(this.iLabel1);
			this.MPanel.Controls.Add(this.EndButton);
			this.MPanel.Location = new System.Drawing.Point(0, 0);
			this.MPanel.Name = "MPanel";
			this.MPanel.Size = new System.Drawing.Size(480, 40);
			this.MPanel.TabIndex = 23;
			this.MPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(eJ);
			this.EndButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.EndButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.EndButton.FillColor = System.Drawing.Color.FromArgb(10, 10, 10);
			this.EndButton.HoveredState.Parent = this.EndButton;
			this.EndButton.IconColor = System.Drawing.Color.White;
			this.EndButton.Location = new System.Drawing.Point(-87, 0);
			this.EndButton.Name = "EndButton";
			this.EndButton.ShadowDecoration.Parent = this.EndButton;
			this.EndButton.Size = new System.Drawing.Size(29, 40);
			this.EndButton.TabIndex = 2;
			this.iLabel1.AutoSize = true;
			this.iLabel1.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.iLabel1.ForeColor = System.Drawing.Color.White;
			this.iLabel1.Location = new System.Drawing.Point(8, 10);
			this.iLabel1.Name = "iLabel1";
			this.iLabel1.Size = new System.Drawing.Size(133, 19);
			this.iLabel1.TabIndex = 23;
			this.iLabel1.Text = "Obfuscation process";
			this.iLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.iLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(eJ);
			this.iLabel2.AutoSize = true;
			this.iLabel2.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.iLabel2.ForeColor = System.Drawing.Color.White;
			this.iLabel2.Location = new System.Drawing.Point(110, 61);
			this.iLabel2.Name = "iLabel2";
			this.iLabel2.Size = new System.Drawing.Size(206, 38);
			this.iLabel2.TabIndex = 24;
			this.iLabel2.Text = "Your file obfuscated successfully,\r\ncheck log for more info .";
			this.iLabel2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
			base.ClientSize = new System.Drawing.Size(480, 200);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.MPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(480, 200);
			base.Name = "Finished";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Finished";
			base.Load += new System.EventHandler(eG);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.MPanel.ResumeLayout(false);
			this.MPanel.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
