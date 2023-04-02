using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns1;

namespace _0x7_Protector_GUI
{
	public class NewUpdate : Form
	{
		public const int WM_NCLBUTTONDOWN = 161;

		public const int HT_CAPTION = 2;

		private IContainer eE;

		private SiticoneElipse eF;

		private SiticoneRoundedButton VisitDiscordServer;

		private SiticoneRoundedButton SkipUpdate;

		private Panel MPanel;

		private SiticoneControlBox EndButton;

		private ILabel iLabel6;

		public NewUpdate()
		{
			InitializeComponent();
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		private void gh(object sender, EventArgs e)
		{
			Close();
		}

		private void gi(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/bKQgcVW8fT");
		}

		private void gj(object sender, EventArgs e)
		{
			base.Opacity = 0.98;
		}

		private void eS(object sender, MouseEventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_0x7_Protector_GUI.NewUpdate));
			this.eF = new ns1.SiticoneElipse(this.eE);
			this.SkipUpdate = new ns1.SiticoneRoundedButton();
			this.VisitDiscordServer = new ns1.SiticoneRoundedButton();
			this.MPanel = new System.Windows.Forms.Panel();
			this.EndButton = new ns1.SiticoneControlBox();
			this.iLabel6 = new ILabel();
			this.MPanel.SuspendLayout();
			base.SuspendLayout();
			this.eF.TargetControl = this;
			this.SkipUpdate.BorderColor = System.Drawing.Color.FromArgb(229, 57, 53);
			this.SkipUpdate.BorderThickness = 1;
			this.SkipUpdate.CheckedState.Parent = this.SkipUpdate;
			this.SkipUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SkipUpdate.CustomImages.Parent = this.SkipUpdate;
			this.SkipUpdate.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
			this.SkipUpdate.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.SkipUpdate.ForeColor = System.Drawing.Color.White;
			this.SkipUpdate.HoveredState.Parent = this.SkipUpdate;
			this.SkipUpdate.ImageSize = new System.Drawing.Size(24, 24);
			this.SkipUpdate.Location = new System.Drawing.Point(352, 152);
			this.SkipUpdate.Name = "SkipUpdate";
			this.SkipUpdate.ShadowDecoration.Parent = this.SkipUpdate;
			this.SkipUpdate.Size = new System.Drawing.Size(116, 36);
			this.SkipUpdate.TabIndex = 22;
			this.SkipUpdate.Text = "Skip";
			this.SkipUpdate.Click += new System.EventHandler(gh);
			this.VisitDiscordServer.BorderColor = System.Drawing.Color.FromArgb(229, 57, 53);
			this.VisitDiscordServer.BorderThickness = 1;
			this.VisitDiscordServer.CheckedState.Parent = this.VisitDiscordServer;
			this.VisitDiscordServer.Cursor = System.Windows.Forms.Cursors.Hand;
			this.VisitDiscordServer.CustomImages.Parent = this.VisitDiscordServer;
			this.VisitDiscordServer.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
			this.VisitDiscordServer.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.VisitDiscordServer.ForeColor = System.Drawing.Color.White;
			this.VisitDiscordServer.HoveredState.Parent = this.VisitDiscordServer;
			this.VisitDiscordServer.ImageSize = new System.Drawing.Size(24, 24);
			this.VisitDiscordServer.Location = new System.Drawing.Point(136, 152);
			this.VisitDiscordServer.Name = "VisitDiscordServer";
			this.VisitDiscordServer.ShadowDecoration.Parent = this.VisitDiscordServer;
			this.VisitDiscordServer.Size = new System.Drawing.Size(210, 36);
			this.VisitDiscordServer.TabIndex = 23;
			this.VisitDiscordServer.Text = "Go to discord";
			this.VisitDiscordServer.Click += new System.EventHandler(gi);
			this.MPanel.BackColor = System.Drawing.Color.FromArgb(10, 10, 10);
			this.MPanel.Controls.Add(this.iLabel6);
			this.MPanel.Controls.Add(this.EndButton);
			this.MPanel.Location = new System.Drawing.Point(0, 0);
			this.MPanel.Name = "MPanel";
			this.MPanel.Size = new System.Drawing.Size(480, 40);
			this.MPanel.TabIndex = 24;
			this.MPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(eS);
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
			this.iLabel6.AutoSize = true;
			this.iLabel6.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.iLabel6.ForeColor = System.Drawing.Color.White;
			this.iLabel6.Location = new System.Drawing.Point(8, 10);
			this.iLabel6.Name = "iLabel6";
			this.iLabel6.Size = new System.Drawing.Size(43, 19);
			this.iLabel6.TabIndex = 26;
			this.iLabel6.Text = "Login";
			this.iLabel6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.iLabel6.MouseDown += new System.Windows.Forms.MouseEventHandler(eS);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
			this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(480, 200);
			base.Controls.Add(this.MPanel);
			base.Controls.Add(this.VisitDiscordServer);
			base.Controls.Add(this.SkipUpdate);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(480, 200);
			base.Name = "NewUpdate";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Update !";
			base.Load += new System.EventHandler(gj);
			this.MPanel.ResumeLayout(false);
			this.MPanel.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
