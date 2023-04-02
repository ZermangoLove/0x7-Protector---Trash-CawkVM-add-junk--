using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using at;
using aY;
using bu;
using Core;
using dnlib.DotNet;
using ExAntiTamper;
using f;
using ICore;
using LEncoder;
using ns1;
using ns5;
using Optimization;
using Protections;
using Protections.ControlFlow;
using Protections.ControlFlow2;
using Protections.Mutation;
using Protections.WeakControlFlow;
using Protections.Xor;
using Protections.ZControlFlow;
using w;

namespace _0x7_Protector_GUI
{
	public class GUI : Form
	{
		private DateTime eK;

		public const int WM_NCLBUTTONDOWN = 161;

		public const int HT_CAPTION = 2;

		public static Context ctx;

		public static string browseDir;

		public static string browseDir2;

		public static string FPath;

		public static string FPath2;

		public static bool Virt;

		private bool eL;

		public static int test;

		private IContainer eE;

		private SiticoneElipse eF;

		private SiticoneButton GoToProtections;

		private SiticoneButton GoToMain;

		private SiticoneButton GoToLog;

		private SiticoneButton GoToVirtualization;

		private TabControl TabControl1;

		private TabPage MainPage;

		private SiticoneButton ProtectAssembly;

		private SiticoneImageButton AddAssembly;

		private SiticoneImageButton SelectFolder;

		private TabPage VirtualizationPage;

		private TabPage LogPage;

		private SiticoneRoundedTextBox SavePath;

		private SiticoneRoundedTextBox AsmPath;

		private SiticoneButton GoToCodeOptimization;

		private TabPage CodeOptimizationPage;

		private TabPage HelpPage;

		private SiticoneImageButton DiscordServer;

		private TabPage ProtectionsPage;

		private SiticoneOSToggleSwith AntiHttp_cbox;

		private SiticoneOSToggleSwith AntiCracker_cbox;

		private SiticoneTrackBar ControlFlowSelection;

		private SiticoneOSToggleSwith AntiDump_cbox;

		private SiticoneOSToggleSwith L2F_cbox;

		private SiticoneOSToggleSwith AntiDebug_cbox;

		private TabPage RenamerPage;

		private SiticoneOSToggleSwith Renaming_cbox;

		private SiticoneButton GoToRenamer;

		private TabPage CreditsPage;

		private SiticoneOSToggleSwith AntiVM_cbox;

		private SiticoneOSToggleSwith Junk_cbox;

		private SiticoneOSToggleSwith MathInts_cbox;

		private TreeView treeView1;

		private TabPage GuidePage;

		private Panel panel14;

		private SiticoneVSeparator siticoneVSeparator15;

		private Panel panel13;

		private SiticoneOSToggleSwith Controlflow_CBOX;

		private SiticoneVSeparator siticoneVSeparator14;

		private Panel panel12;

		private SiticoneOSToggleSwith Mutation_CBOX;

		private SiticoneVSeparator siticoneVSeparator13;

		private Panel panel11;

		private SiticoneVSeparator siticoneVSeparator12;

		private Panel panel10;

		private SiticoneOSToggleSwith Strings_CBOX;

		private SiticoneVSeparator siticoneVSeparator11;

		private Panel panel9;

		private SiticoneVSeparator siticoneVSeparator10;

		private Panel panel8;

		private SiticoneVSeparator siticoneVSeparator9;

		private Panel panel7;

		private SiticoneVSeparator siticoneVSeparator8;

		private Panel panel6;

		private SiticoneVSeparator siticoneVSeparator7;

		private Panel panel5;

		private SiticoneVSeparator siticoneVSeparator6;

		private Panel panel4;

		private SiticoneVSeparator siticoneVSeparator5;

		private SiticoneRoundedButton Recommended;

		private SiticoneRoundedButton CheckAll_Button;

		private Panel panel16;

		private SiticoneOSToggleSwith CodeAnalyzation_cbox;

		private SiticoneOSToggleSwith HideNamespaces_Cbox;

		private SiticoneOSToggleSwith rParam_cbox;

		private SiticoneOSToggleSwith rEvents_cbox;

		private SiticoneOSToggleSwith rFields_cbox;

		private SiticoneOSToggleSwith rMethods_cbox;

		private SiticoneOSToggleSwith rProperties_cbox;

		private SiticoneOSToggleSwith rTypes_cbox;

		private SiticoneVSeparator siticoneVSeparator17;

		private Panel panel15;

		private SiticoneVSeparator siticoneVSeparator16;

		private Panel panel17;

		private SiticoneVSeparator siticoneVSeparator18;

		private SiticoneOSToggleSwith Virt_cbox;

		private Panel panel19;

		private SiticoneVSeparator siticoneVSeparator20;

		private SiticoneOSToggleSwith OptimizeMethods_cbox;

		private Panel panel18;

		private SiticoneVSeparator siticoneVSeparator19;

		private SiticoneOSToggleSwith OptimizeCode_cbox;

		private Panel panel20;

		private SiticoneVSeparator siticoneVSeparator21;

		private SiticoneOSToggleSwith ReduceMD_cbox;

		private SiticoneVSeparator siticoneVSeparator28;

		private SiticoneVSeparator siticoneVSeparator25;

		private SiticoneVSeparator siticoneVSeparator24;

		private SiticoneVSeparator siticoneVSeparator23;

		private SiticoneVSeparator siticoneVSeparator22;

		private TextBox textBox2;

		private SiticoneVSeparator siticoneVSeparator27;

		private ILabel iLabel2;

		private ILabel iLabel1;

		private ILabel iLabel7;

		private ILabel iLabel5;

		private ILabel iLabel18;

		private ILabel ControlFlowStatus;

		private ILabel iLabel17;

		private ILabel iLabel16;

		private ILabel iLabel15;

		private ILabel iLabel14;

		private ILabel iLabel12;

		private ILabel iLabel11;

		private ILabel iLabel10;

		private ILabel iLabel8;

		private ILabel iLabel28;

		private ILabel iLabel27;

		private ILabel iLabel26;

		private ILabel iLabel25;

		private ILabel iLabel24;

		private ILabel iLabel23;

		private ILabel iLabel22;

		private ILabel iLabel21;

		private ILabel iLabel20;

		private ILabel iLabel19;

		private ILabel iLabel29;

		private ILabel iLabel32;

		private ILabel iLabel31;

		private ILabel iLabel30;

		private ILabel iLabel34;

		private ILabel iLabel33;

		private ILabel iLabel40;

		private ILabel iLabel39;

		private ILabel iLabel37;

		private ILabel iLabel36;

		private ILabel iLabel35;

		private ILabel iLabel38;

		private ILabel iLabel43;

		private ILabel iLabel41;

		private Panel panel2;

		private ILabel iLabel4;

		private SiticoneVSeparator siticoneVSeparator3;

		private SiticoneOSToggleSwith Flood_CBOX;

		private Panel panel1;

		private ILabel iLabel3;

		private SiticoneVSeparator siticoneVSeparator2;

		private SiticoneOSToggleSwith HideMethods_cbox;

		private TextBox LogText;

		private SiticoneVSeparator siticoneVSeparator4;

		private ILabel iLabel45;

		private TabPage AntiCrackSettings;

		private ILabel iLabel46;

		private SiticoneOSToggleSwith BanCracker_CBOX;

		private SiticoneVSeparator siticoneVSeparator29;

		private ILabel iLabel44;

		private ILabel iLabel9;

		private SiticoneRoundedButton PasteWHLink;

		private SiticoneOSToggleSwith SendToWH_cbox;

		private SiticoneRoundedButton GoToACS;

		private SiticoneImageButton BackToProtections;

		private ILabel LinkStatus;

		private ILabel iLabel48;

		private SiticoneImageButton addP;

		private SiticoneTextBox pname;

		private ILabel iLabel47;

		private ILabel iLabel50;

		private ILabel iLabel49;

		private TabPage MutationSettingsPage;

		private SiticoneOSToggleSwith Mathop_CBOX;

		private ILabel iLabel54;

		private SiticoneOSToggleSwith Fakeif_CBOX;

		private ILabel iLabel53;

		private SiticoneImageButton siticoneImageButton2;

		private SiticoneVSeparator siticoneVSeparator30;

		private SiticoneOSToggleSwith MathMutate_CBOX;

		private ILabel iLabel51;

		private ILabel iLabel52;

		private SiticoneRoundedButton GoToMSettings;

		private ILabel iLabel58;

		private ILabel iLabel57;

		private ILabel iLabel55;

		private ILabel iLabel59;

		private TextBox textBox3;

		private SiticoneVSeparator siticoneVSeparator31;

		private Panel panel3;

		private ILabel iLabel61;

		private SiticoneOSToggleSwith RProxy_CBOX;

		private SiticoneVSeparator siticoneVSeparator32;

		private Panel panel21;

		private SiticoneRoundedButton siticoneRoundedButton1;

		private ILabel iLabel62;

		private SiticoneOSToggleSwith ConstantsMelting_CBOX;

		private SiticoneVSeparator siticoneVSeparator33;

		private TabPage ConstansMeltingPage;

		private SiticoneOSToggleSwith MeltInt_CBOX;

		private SiticoneVSeparator siticoneVSeparator34;

		private SiticoneOSToggleSwith MeltStr_CBOX;

		private ILabel iLabel65;

		private ILabel iLabel66;

		private ILabel iLabel67;

		private SiticoneImageButton siticoneImageButton3;

		private SiticoneRoundedButton UnBanBtn;

		private ILabel iLabel63;

		private SiticoneRoundedButton GoToStrings;

		private TabPage StringsSettingsPage;

		private SiticoneOSToggleSwith Str2FE_CBOX;

		private ILabel iLabel71;

		private SiticoneOSToggleSwith Xor_CBOX;

		private ILabel iLabel70;

		private SiticoneImageButton siticoneImageButton4;

		private SiticoneOSToggleSwith CEStr_CBOX;

		private SiticoneVSeparator siticoneVSeparator35;

		private ILabel iLabel64;

		private ILabel iLabel68;

		private SiticoneOSToggleSwith OutlineStrings_CBOX;

		private ILabel iLabel69;

		private ILabel iLabel72;

		private TextBox textBox4;

		private SiticoneVSeparator siticoneVSeparator36;

		private SiticoneRoundedButton JunkSettings;

		private TabPage JunkSettingsPage;

		private SiticoneOSToggleSwith JunkClasses_CBOX;

		private ILabel iLabel13;

		private SiticoneImageButton siticoneImageButton5;

		private SiticoneVSeparator siticoneVSeparator26;

		private ILabel iLabel76;

		private ILabel iLabel77;

		private SiticoneRoundedTextBox JunkMLength;

		private ILabel iLabel75;

		private SiticoneRoundedTextBox JunkCName;

		private ILabel iLabel74;

		private SiticoneOSToggleSwith JunkMethods_CBOX;

		private ILabel iLabel73;

		private SiticoneRoundedTextBox JunkLength;

		private ILabel iLabel78;

		private SiticoneRoundedTextBox JunkContent;

		private TabPage DonatePage;

		private SiticoneImageButton Bitcoin;

		private ILabel iLabel79;

		private SiticoneImageButton Paypal;

		private ILabel iLabel80;

		private ILabel iLabel81;

		private SiticoneVSeparator siticoneVSeparator37;

		private ILabel iLabel42;

		private SiticoneRoundedButton siticoneRoundedButton2;

		private TabPage RefProxyPage;

		private SiticoneOSToggleSwith StrongRef_CBOX;

		private ILabel iLabel84;

		private SiticoneOSToggleSwith BasicRef_CBOX;

		private ILabel iLabel83;

		private SiticoneVSeparator siticoneVSeparator38;

		private ILabel iLabel82;

		private SiticoneImageButton siticoneImageButton6;

		private ILabel iLabel85;

		private SiticoneOSToggleSwith SaveProtections_CBOX;

		private TabPage SettingsPage;

		private SiticoneOSToggleSwith AOT_CBOX;

		private ILabel iLabel88;

		private SiticoneOSToggleSwith TR_CBOX;

		private ILabel iLabel87;

		private SiticoneVSeparator siticoneVSeparator39;

		private ILabel iLabel86;

		private ILabel iLabel89;

		private ILabel iLabel90;

		private SiticoneVSeparator siticoneVSeparator40;

		private SiticoneButton ImportSession;

		private ILabel iLabel91;

		private SiticoneOSToggleSwith VMAll;

		private ILabel iLabel92;

		private SiticoneOSToggleSwith SaveSame_CBOX;

		private SiticoneOSToggleSwith FlatB_CBOX;

		private ILabel iLabel93;

		private SiticoneOSToggleSwith siticoneOSToggleSwith1;

		private ILabel iLabel94;

		private Panel panel22;

		private SiticoneRoundedButton SearchForMethod;

		private SiticoneRoundedTextBox SMethodText;

		private ILabel iLabel60;

		private SiticoneVSeparator siticoneVSeparator41;

		private ILabel iLabel56;
        private IContainer components;
        private SiticoneOSToggleSwith SaveNameMap_CBOX;

		public GUI()
		{
			InitializeComponent();
		}

		private void eM(object sender, EventArgs e)
		{
			if (!(f.e.a == "1") || f.e.b != 1 || !f.e.c || !f.e.g)
			{
				Environment.FailFast("");
			}
			string text = HWID.GetSerial() + ".0x7";
			string contents = f.e.Encoder.ToHexString(text);
			File.WriteAllText(Directory.GetCurrentDirectory() + "\\License.txt", contents);
			if (f.e.Encoder.FromHexString(File.ReadAllText(Directory.GetCurrentDirectory() + "\\License.txt")) != text)
			{
				Environment.FailFast("");
			}
		}

		private void eN(object sender, EventArgs e)
		{
			CheckAll_Button.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\CheckAll.png");
			Recommended.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\Recommend.png");
			base.Opacity = 0.98;
			SaveSame_CBOX.Checked = true;
		}

		private void eO(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void eP(object sender, EventArgs e)
		{
			Process.Start("https://discord.com/users/550441121822539834");
		}

		private void eQ(string format, params object[] args)
		{
			LogText.AppendText(string.Format(format, args) + Environment.NewLine);
		}

		private void eR(string format, params object[] args)
		{
			LogText.AppendText(string.Format(format, args));
		}

		public void Starting()
		{
			LogText.Clear();
			eK = DateTime.Now;
		}

		public void Finish()
		{
			DateTime now = DateTime.Now;
			string text = $"at {now.ToShortTimeString()}, {(int)now.Subtract(eK).TotalMinutes}:{now.Subtract(eK).Seconds:d2} elapsed.";
			eR("[Info] Obfuscation Completed ! : " + text);
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		private void eS(object sender, MouseEventArgs e)
		{
			if (MouseButtons.Left == e.Button)
			{
				if (TR_CBOX.Checked)
				{
					base.Opacity = 0.96;
					Cursor = Cursors.Hand;
					ReleaseCapture();
					SendMessage(base.Handle, 161, 2, 0);
					base.Opacity = 0.98;
					Cursor = Cursors.Default;
				}
				else
				{
					Cursor = Cursors.Hand;
					ReleaseCapture();
					SendMessage(base.Handle, 161, 2, 0);
					Cursor = Cursors.Default;
				}
			}
		}

		private void eT(object sender, EventArgs e)
		{
			TabControl1.SelectTab(ProtectionsPage);
		}

		private void eU(object sender, EventArgs e)
		{
			TabControl1.SelectTab(AntiCrackSettings);
		}

		private void eV(object sender, EventArgs e)
		{
			TabControl1.SelectTab(HelpPage);
		}

		private void eW(object sender, EventArgs e)
		{
			TabControl1.SelectTab(CreditsPage);
		}

		private void eX(object sender, EventArgs e)
		{
			TabControl1.SelectTab(GuidePage);
		}

		private void eY(object sender, EventArgs e)
		{
			GoToMain.FillColor = Color.FromArgb(229, 57, 53);
			GoToProtections.FillColor = Color.FromArgb(10, 10, 10);
			GoToRenamer.FillColor = Color.FromArgb(10, 10, 10);
			GoToVirtualization.FillColor = Color.FromArgb(10, 10, 10);
			GoToCodeOptimization.FillColor = Color.FromArgb(10, 10, 10);
			GoToLog.FillColor = Color.FromArgb(10, 10, 10);
			TabControl1.SelectTab(MainPage);
		}

		private void eZ(object sender, EventArgs e)
		{
			GoToProtections.FillColor = Color.FromArgb(229, 57, 53);
			GoToMain.FillColor = Color.FromArgb(10, 10, 10);
			GoToRenamer.FillColor = Color.FromArgb(10, 10, 10);
			GoToVirtualization.FillColor = Color.FromArgb(10, 10, 10);
			GoToCodeOptimization.FillColor = Color.FromArgb(10, 10, 10);
			GoToLog.FillColor = Color.FromArgb(10, 10, 10);
			TabControl1.SelectTab(ProtectionsPage);
		}

		private void fa(object sender, EventArgs e)
		{
			GoToRenamer.FillColor = Color.FromArgb(229, 57, 53);
			GoToMain.FillColor = Color.FromArgb(10, 10, 10);
			GoToProtections.FillColor = Color.FromArgb(10, 10, 10);
			GoToVirtualization.FillColor = Color.FromArgb(10, 10, 10);
			GoToCodeOptimization.FillColor = Color.FromArgb(10, 10, 10);
			GoToLog.FillColor = Color.FromArgb(10, 10, 10);
			TabControl1.SelectTab(RenamerPage);
		}

		private void fb(object sender, EventArgs e)
		{
			GoToVirtualization.FillColor = Color.FromArgb(229, 57, 53);
			GoToMain.FillColor = Color.FromArgb(10, 10, 10);
			GoToProtections.FillColor = Color.FromArgb(10, 10, 10);
			GoToRenamer.FillColor = Color.FromArgb(10, 10, 10);
			GoToCodeOptimization.FillColor = Color.FromArgb(10, 10, 10);
			GoToLog.FillColor = Color.FromArgb(10, 10, 10);
			TabControl1.SelectTab(VirtualizationPage);
		}

		private void fc(object sender, EventArgs e)
		{
			GoToCodeOptimization.FillColor = Color.FromArgb(229, 57, 53);
			GoToMain.FillColor = Color.FromArgb(10, 10, 10);
			GoToProtections.FillColor = Color.FromArgb(10, 10, 10);
			GoToRenamer.FillColor = Color.FromArgb(10, 10, 10);
			GoToVirtualization.FillColor = Color.FromArgb(10, 10, 10);
			GoToLog.FillColor = Color.FromArgb(10, 10, 10);
			TabControl1.SelectTab(CodeOptimizationPage);
		}

		private void fd(object sender, EventArgs e)
		{
			GoToLog.FillColor = Color.FromArgb(229, 57, 53);
			GoToMain.FillColor = Color.FromArgb(10, 10, 10);
			GoToProtections.FillColor = Color.FromArgb(10, 10, 10);
			GoToRenamer.FillColor = Color.FromArgb(10, 10, 10);
			GoToVirtualization.FillColor = Color.FromArgb(10, 10, 10);
			GoToCodeOptimization.FillColor = Color.FromArgb(10, 10, 10);
			TabControl1.SelectTab(LogPage);
		}

		private void fe(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Load Assembly";
			openFileDialog.Filter = ".NET Assembly (*.exe)|*.exe|(*.dll)|*.dll";
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			AsmPath.Text = openFileDialog.FileName;
			string text = AsmPath.Text;
			int num = text.LastIndexOf(".");
			if (num != -1)
			{
				string text2 = text.Substring(num);
				text2 = text2.ToLower();
				if (text2 == ".exe" || text2 == ".dll")
				{
					AsmPath.Text = text;
					SavePath.Text = Path.Combine(Path.GetDirectoryName(AsmPath.Text) + "\\Protected");
					ctx = new Context(AsmPath.Text);
					fK();
				}
			}
		}

		private void ff(object sender, DragEventArgs e)
		{
			Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
			if (array == null)
			{
				return;
			}
			string text = array.GetValue(0).ToString();
			int num = text.LastIndexOf(".");
			text.LastIndexOf("\\");
			if (num != -1)
			{
				string text2 = text.Substring(num);
				text2 = text2.ToLower();
				if (text2 == ".exe" || text2 == ".dll")
				{
					AsmPath.Text = text;
					SavePath.Text = Path.Combine(Path.GetDirectoryName(AsmPath.Text) + "\\Protected");
					ctx = new Context(AsmPath.Text);
					fK();
				}
			}
		}

		private void fg(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void fh(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = "Select folder";
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				SavePath.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void fi(object sender, EventArgs e)
		{
			switch (ControlFlowSelection.Value)
			{
			case 0:
				ControlFlowStatus.Text = "Off";
				break;
			case 1:
				ControlFlowStatus.Text = "Low";
				break;
			case 2:
				ControlFlowStatus.Text = "Weak";
				break;
			case 3:
				ControlFlowStatus.Text = "Normal";
				break;
			case 4:
				ControlFlowStatus.Text = "Strong";
				break;
			case 5:
				ControlFlowStatus.Text = "Aggressive";
				break;
			case 6:
				ControlFlowStatus.Text = "Maximum";
				break;
			}
		}

		public void ExecuteCflow(Context context)
		{
			switch (ControlFlowSelection.Value)
			{
			case 1:
				CFWVM.Execute(ctx);
				break;
			case 2:
				new WeakControlFlow().Execute(context);
				break;
			case 3:
				ControlFlow2.Execute(context);
				break;
			case 4:
				Protections.ZControlFlow.ControlFlow.Execute(context);
				break;
			case 5:
				Protections.ControlFlow.ControlFlow.Execute3(context);
				break;
			case 6:
				Protections.ControlFlow.ControlFlow.Execute(context);
				break;
			case 0:
				break;
			}
		}

		private void fj(object sender, EventArgs e)
		{
			TabControl1.SelectTab(ProtectionsPage);
		}

		private void fk(object sender, EventArgs e)
		{
			TabControl1.SelectTab(MutationSettingsPage);
		}

		public void ExecuteMutation(Context context)
		{
			if (MathMutate_CBOX.Checked)
			{
				MathMutation.Execute(context);
			}
			if (Fakeif_CBOX.Checked)
			{
				MutationConfusion.FakeIf(context);
			}
			if (Mathop_CBOX.Checked)
			{
				MutationConfusion.Arithmetic(context);
			}
		}

		private void fl(object sender, EventArgs e)
		{
			TabControl1.SelectTab(StringsSettingsPage);
		}

		private void fm(object sender, EventArgs e)
		{
			TabControl1.SelectTab(ProtectionsPage);
		}

		public void ExecuteStrings(Context context)
		{
			if (CEStr_CBOX.Checked)
			{
				StringEncryption2.Execute(context);
			}
			if (Xor_CBOX.Checked)
			{
				new Protections.Xor.StringEncryption().Run(context);
			}
			if (Str2FE_CBOX.Checked)
			{
				Protections.StringEncryption.Execute(context);
			}
		}

		private void fn(object sender, EventArgs e)
		{
			try
			{
				Starting();
				GoToLog.PerformClick();
				if (AsmPath.Text.EndsWith(".dll".ToLower()))
				{
					eQ("[ ! ] Warning : you are trying to obfuscate .dll file !, so these protections will be disabled .");
					eQ("Flood Cctor, Anti Dump, Anti Virtual Machine, Anti Crack, Anti Http Debug & Anti Debug");
					eQ("");
					Flood_CBOX.Checked = false;
					AntiDump_cbox.Checked = false;
					AntiVM_cbox.Checked = false;
					AntiCracker_cbox.Checked = false;
					AntiHttp_cbox.Checked = false;
					AntiDebug_cbox.Checked = false;
				}
				ctx = new Context(AsmPath.Text);
				ctx.FileName = Path.GetFileName(AsmPath.Text);
				ctx.DirPath = SavePath.Text;
				browseDir = ctx.DirPath;
				browseDir2 = Path.GetDirectoryName(AsmPath.Text);
				ctx.OutPutPath = SavePath.Text + "\\" + ctx.FileName;
				eQ("Obfuscating ....");
				if (Renaming_cbox.Checked)
				{
					if (SaveNameMap_CBOX.Checked)
					{
						bM.bO(ctx);
						eQ("[Info] Name map exported, check desktop !");
					}
					if (rTypes_cbox.Checked)
					{
						bC.bE(ctx);
					}
					if (rMethods_cbox.Checked)
					{
						bC.bI(ctx);
					}
					if (rProperties_cbox.Checked)
					{
						bC.bH(ctx);
					}
					if (rFields_cbox.Checked)
					{
						bC.bF(ctx);
					}
					if (rEvents_cbox.Checked)
					{
						bC.bG(ctx);
					}
					if (rParam_cbox.Checked)
					{
						bC.bJ(ctx);
					}
					if (HideNamespaces_Cbox.Checked)
					{
						bC.bK(ctx);
					}
					if (SaveNameMap_CBOX.Checked)
					{
						bM.bP(ctx);
					}
					eQ("Executed : Renaming Obfuscation");
				}
				if (AntiCracker_cbox.Checked)
				{
					if (BanCracker_CBOX.Checked)
					{
						global.Status = "1";
					}
					if (!BanCracker_CBOX.Checked)
					{
						global.Status = "0";
					}
					if (siticoneOSToggleSwith1.Checked)
					{
						global.SIMG = "1";
					}
					if (!siticoneOSToggleSwith1.Checked)
					{
						global.SIMG = "0";
					}
					global.rnd = Path.GetTempPath() + ICore.Utils.GenerateString() + ".jpg";
					if (SendToWH_cbox.Checked)
					{
						bi.bj(ctx);
						eQ("Executed : Anti Cracking ( Data Sender )");
					}
					else
					{
						bk.bj(ctx);
						eQ("Executed :  Anti Cracking");
					}
				}
				if (Flood_CBOX.Checked)
				{
					bb.ag(ctx);
					eQ("Executed : Flood Cctor");
				}
				if (AntiHttp_cbox.Checked)
				{
					bl.bj(ctx);
					eQ("Executed : Anti Http Debugging");
				}
				if (AntiVM_cbox.Checked)
				{
					bp.bj(ctx);
					bp.bq(ctx);
					eQ("Executed : Anti Virtual Machine");
				}
				if (AntiDump_cbox.Checked)
				{
					AntiDump.Execute(ctx);
					eQ("Executed : Anti Dump");
				}
				if (AntiDebug_cbox.Checked)
				{
					AntiDebug.Execute(ctx);
					eQ("Executed : Anti Debug");
				}
				if (Strings_CBOX.Checked && (CEStr_CBOX.Checked || Xor_CBOX.Checked || Str2FE_CBOX.Checked))
				{
					ExecuteStrings(ctx);
					eQ("Executed : Strings Encoding");
				}
				if (HideMethods_cbox.Checked)
				{
					new AntiTamperNormal().AntiTamper(ctx);
					eQ("Executed : Encrypt Methods");
				}
				if (Junk_cbox.Checked)
				{
					if (JunkClasses_CBOX.Checked)
					{
						bh.ag(ctx, Convert.ToInt32(JunkLength.Text));
						eQ("Executed : Junk Classes Adder");
					}
					if (JunkMethods_CBOX.Checked)
					{
						JAdder.Add(ctx, Convert.ToInt32(JunkMLength.Text), JunkCName.Text, JunkContent.Text);
						eQ("Executed : Junk Methods Adder");
					}
				}
				if (MathInts_cbox.Checked)
				{
					IntMathProtection.Execute(ctx);
					eQ("Executed : Math Ints");
				}
				if (Controlflow_CBOX.Checked && ControlFlowSelection.Value != 0)
				{
					ExecuteCflow(ctx);
					eQ("Executed : Control Flow");
				}
				if (Mutation_CBOX.Checked)
				{
					ExecuteMutation(ctx);
					eQ("Executed : Mutation");
				}
				if (ConstantsMelting_CBOX.Checked)
				{
					ExecuteMelt(ctx);
					eQ("Executed : Constants Melting");
				}
				if (RProxy_CBOX.Checked)
				{
					if (BasicRef_CBOX.Checked)
					{
						BasicReferenceProxy.Execute(ctx);
						eQ("Executed : Basic Reference Proxy");
					}
					if (StrongRef_CBOX.Checked)
					{
						FixedReferenceProxy.Execute(ctx);
						eQ("Executed : Strong Reference Proxy");
					}
				}
				if (L2F_cbox.Checked)
				{
					LocalToField.Execute1(ctx);
					eQ("Executed : Local To Field");
				}
				if (HideMethods_cbox.Checked)
				{
					HideMethods.Execute(ctx);
				}
				if (OptimizeMethods_cbox.Checked)
				{
					MethodsOptimization.Optimize(ctx);
					eQ("Optimized Methods");
				}
				if (OptimizeCode_cbox.Checked)
				{
					z.A(ctx);
					eQ("Optimized Codes");
				}
				if (ReduceMD_cbox.Checked)
				{
					ReduceMetadata.Execute(ctx);
					eQ("Reduced Meta Data");
				}
				ctx.SaveFile();
				FPath2 = ctx.OutPutPath;
				if (Virt_cbox.Checked)
				{
					eQ("Virtualizing ....");
					Virt = true;
					FPath = ctx.OutPutPath;
					string path = ctx.OutPutPath.Replace(".exe", "-VM.exe");
					byte[] bytes = Protector.Protect(File.ReadAllBytes(FPath));
					File.WriteAllBytes(path, bytes);
					eQ("Virtualized Methods !");
				}
				ctx.Clear();
				if (SaveProtections_CBOX.Checked)
				{
					StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\Saved.txt");
					streamWriter.WriteLine("Saved protection:\n———————————");
					if (BasicRef_CBOX.Checked)
					{
						streamWriter.WriteLine("Basic RProxy = true");
					}
					if (StrongRef_CBOX.Checked)
					{
						streamWriter.WriteLine("Strong RProxy = true");
					}
					if (JunkClasses_CBOX.Checked)
					{
						streamWriter.WriteLine("Junk Classes = true");
					}
					if (JunkMethods_CBOX.Checked)
					{
						streamWriter.WriteLine("Junk Methods = true");
					}
					if (CEStr_CBOX.Checked)
					{
						streamWriter.WriteLine("CEncode Strings = true");
					}
					if (Xor_CBOX.Checked)
					{
						streamWriter.WriteLine("Xor Strings = true");
					}
					if (Str2FE_CBOX.Checked)
					{
						streamWriter.WriteLine("Strings 2 Fields = true");
					}
					if (MeltInt_CBOX.Checked)
					{
						streamWriter.WriteLine("Melt Integers = true");
					}
					if (MeltStr_CBOX.Checked)
					{
						streamWriter.WriteLine("Melt Strings = true");
					}
					if (MathMutate_CBOX.Checked)
					{
						streamWriter.WriteLine("Math Mutation = true");
					}
					if (Fakeif_CBOX.Checked)
					{
						streamWriter.WriteLine("Fake IF = true");
					}
					if (Mathop_CBOX.Checked)
					{
						streamWriter.WriteLine("Math Operation = true");
					}
					if (SendToWH_cbox.Checked)
					{
						streamWriter.WriteLine("Send Data = true");
					}
					if (BanCracker_CBOX.Checked)
					{
						streamWriter.WriteLine("Ban Cracker = true");
					}
					if (siticoneOSToggleSwith1.Checked)
					{
						streamWriter.WriteLine("Capture Screen = true");
					}
					if (rTypes_cbox.Checked)
					{
						streamWriter.WriteLine("Types = true");
					}
					if (rProperties_cbox.Checked)
					{
						streamWriter.WriteLine("Properties = true");
					}
					if (rMethods_cbox.Checked)
					{
						streamWriter.WriteLine("Methods = true");
					}
					if (rFields_cbox.Checked)
					{
						streamWriter.WriteLine("Fields = true");
					}
					if (rEvents_cbox.Checked)
					{
						streamWriter.WriteLine("Events = true");
					}
					if (rParam_cbox.Checked)
					{
						streamWriter.WriteLine("Parameters = true");
					}
					if (HideNamespaces_Cbox.Checked)
					{
						streamWriter.WriteLine("Hide Namespaces = true");
					}
					streamWriter.WriteLine("Types = true");
					if (HideMethods_cbox.Checked)
					{
						streamWriter.WriteLine("Anti tamper = true");
					}
					if (Flood_CBOX.Checked)
					{
						streamWriter.WriteLine("Flood cctor = true");
					}
					if (AntiDump_cbox.Checked)
					{
						streamWriter.WriteLine("Anti dump = true");
					}
					if (AntiVM_cbox.Checked)
					{
						streamWriter.WriteLine("Anti vm = true");
					}
					if (AntiCracker_cbox.Checked)
					{
						streamWriter.WriteLine("Anti crack = true");
					}
					if (AntiHttp_cbox.Checked)
					{
						streamWriter.WriteLine("Anti http = true");
					}
					if (AntiDebug_cbox.Checked)
					{
						streamWriter.WriteLine("Anti debug = true");
					}
					if (Junk_cbox.Checked)
					{
						streamWriter.WriteLine("Junk = true");
					}
					if (Strings_CBOX.Checked)
					{
						streamWriter.WriteLine("Strings encoding = true");
					}
					if (MathInts_cbox.Checked)
					{
						streamWriter.WriteLine("Int math = true");
					}
					if (Mutation_CBOX.Checked)
					{
						streamWriter.WriteLine("Mutation = true");
					}
					if (OutlineStrings_CBOX.Checked)
					{
						streamWriter.WriteLine("Outliner = true");
					}
					if (RProxy_CBOX.Checked)
					{
						streamWriter.WriteLine("Ref proxy = true");
					}
					if (Controlflow_CBOX.Checked)
					{
						streamWriter.WriteLine("Control flow = true");
					}
					if (ControlFlowSelection.Value == 1)
					{
						streamWriter.WriteLine("Control Flow Preset 1 = true");
					}
					if (ControlFlowSelection.Value == 2)
					{
						streamWriter.WriteLine("Control Flow Preset 2 = true");
					}
					if (ControlFlowSelection.Value == 3)
					{
						streamWriter.WriteLine("Control Flow Preset 3 = true");
					}
					if (ControlFlowSelection.Value == 4)
					{
						streamWriter.WriteLine("Control Flow Preset 4 = true");
					}
					if (ControlFlowSelection.Value == 5)
					{
						streamWriter.WriteLine("Control Flow Preset 5 = true");
					}
					if (ControlFlowSelection.Value == 6)
					{
						streamWriter.WriteLine("Control Flow Preset 6 = true");
					}
					if (L2F_cbox.Checked)
					{
						streamWriter.WriteLine("L2F = true");
					}
					if (Renaming_cbox.Checked)
					{
						streamWriter.WriteLine("Renamer = true");
					}
					streamWriter.Dispose();
				}
				Activate();
				Finish();
				new Finished().ShowDialog();
			}
			catch (Exception ex)
			{
				eQ(ex.ToString());
			}
		}

		private void fo(object sender, EventArgs e)
		{
			if (!eL)
			{
				eL = true;
				CheckAll_Button.Text = "Uncheck All";
				Strings_CBOX.Checked = true;
				Controlflow_CBOX.Checked = true;
				Mutation_CBOX.Checked = true;
				Flood_CBOX.Checked = true;
				AntiCracker_cbox.Checked = true;
				AntiHttp_cbox.Checked = true;
				AntiVM_cbox.Checked = true;
				AntiDebug_cbox.Checked = true;
				AntiDump_cbox.Checked = true;
				HideMethods_cbox.Checked = true;
				Xor_CBOX.Checked = true;
				CEStr_CBOX.Checked = true;
				Str2FE_CBOX.Checked = true;
				L2F_cbox.Checked = true;
				Renaming_cbox.Checked = true;
				Junk_cbox.Checked = true;
				JunkClasses_CBOX.Checked = true;
				JunkMethods_CBOX.Checked = true;
				MathInts_cbox.Checked = true;
				ControlFlowSelection.Value = 4;
				rTypes_cbox.Checked = true;
				HideNamespaces_Cbox.Checked = true;
				Mathop_CBOX.Checked = true;
				Fakeif_CBOX.Checked = true;
				MathMutate_CBOX.Checked = true;
				RProxy_CBOX.Checked = true;
				ConstantsMelting_CBOX.Checked = true;
				MeltInt_CBOX.Checked = true;
				MeltStr_CBOX.Checked = true;
				BasicRef_CBOX.Checked = true;
				StrongRef_CBOX.Checked = true;
				CheckAll_Button.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\UncheckAll.png");
			}
			else
			{
				eL = false;
				CheckAll_Button.Text = "Check All";
				Strings_CBOX.Checked = false;
				Controlflow_CBOX.Checked = false;
				Mutation_CBOX.Checked = false;
				HideMethods_cbox.Checked = false;
				Flood_CBOX.Checked = false;
				AntiCracker_cbox.Checked = false;
				AntiHttp_cbox.Checked = false;
				AntiVM_cbox.Checked = false;
				AntiDebug_cbox.Checked = false;
				AntiDump_cbox.Checked = false;
				Xor_CBOX.Checked = false;
				CEStr_CBOX.Checked = false;
				Str2FE_CBOX.Checked = false;
				L2F_cbox.Checked = false;
				Renaming_cbox.Checked = false;
				Junk_cbox.Checked = false;
				MathInts_cbox.Checked = false;
				ControlFlowSelection.Value = 0;
				Mathop_CBOX.Checked = false;
				Fakeif_CBOX.Checked = false;
				MathMutate_CBOX.Checked = false;
				RProxy_CBOX.Checked = false;
				ConstantsMelting_CBOX.Checked = false;
				MeltInt_CBOX.Checked = false;
				MeltStr_CBOX.Checked = false;
				BasicRef_CBOX.Checked = false;
				StrongRef_CBOX.Checked = false;
				CheckAll_Button.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\CheckAll.png");
			}
		}

		private void fp(object sender, EventArgs e)
		{
			if (StrongRef_CBOX.Checked)
			{
				VMAll.Checked = false;
			}
		}

		private void fq(object sender, EventArgs e)
		{
			if (HideMethods_cbox.Checked)
			{
				@as.au = true;
				Virt_cbox.Checked = false;
				AntiDump_cbox.Checked = false;
			}
			else
			{
				@as.au = false;
			}
		}

		private void fr(object sender, EventArgs e)
		{
			if (AntiDump_cbox.Checked)
			{
				HideMethods_cbox.Checked = false;
			}
		}

		private void fs(object sender, EventArgs e)
		{
			if (Virt_cbox.Checked)
			{
				JunkMethods_CBOX.Checked = false;
				HideMethods_cbox.Checked = false;
			}
		}

		private void ft(object sender, EventArgs e)
		{
			if (SendToWH_cbox.Checked)
			{
				LinkStatus.Visible = true;
				return;
			}
			LinkStatus.Text = "";
			LinkStatus.Visible = false;
		}

		private void fu(object sender, EventArgs e)
		{
			global.ID = GetText();
			LinkStatus.Text = "Pasted !";
		}

		public static string GetText()
		{
			if (Clipboard.ContainsText())
			{
				return Clipboard.GetText();
			}
			return string.Empty;
		}

		private void fv(object sender, EventArgs e)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			if (File.Exists(folderPath + "\\Microsoft\\IVM.note"))
			{
				File.Delete(folderPath + "\\Microsoft\\IVM.note");
				iLabel63.Text = "Unbanned !";
			}
			else
			{
				iLabel63.Text = "You're not Banned !";
			}
		}

		private void fw(object sender, EventArgs e)
		{
			TabControl1.SelectTab(JunkSettingsPage);
		}

		private void fx(object sender, EventArgs e)
		{
			TabControl1.SelectTab(ProtectionsPage);
		}

		private void fy(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
			{
				e.Handled = true;
			}
		}

		private void fz(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
			{
				e.Handled = true;
			}
		}

		public void ExecuteMelt(Context ctx)
		{
			if (MeltStr_CBOX.Checked)
			{
				ConstantMelting.MeltStrings(ctx);
			}
			if (MeltInt_CBOX.Checked)
			{
				ConstantMelting.MeltIntegers(ctx);
			}
		}

		private void fA(object sender, EventArgs e)
		{
			TabControl1.SelectTab(ProtectionsPage);
		}

		private void fB(object sender, EventArgs e)
		{
			TabControl1.SelectTab(ConstansMeltingPage);
		}

		private void fC(object sender, EventArgs e)
		{
			TabControl1.SelectTab(RefProxyPage);
		}

		private void fD(object sender, EventArgs e)
		{
			TabControl1.SelectTab(ProtectionsPage);
		}

		private void fE(object sender, EventArgs e)
		{
			AntiCracker_cbox.Checked = false;
			AntiHttp_cbox.Checked = false;
			AntiVM_cbox.Checked = false;
			Junk_cbox.Checked = false;
			Flood_CBOX.Checked = false;
			rTypes_cbox.Checked = false;
			HideNamespaces_Cbox.Checked = false;
			Fakeif_CBOX.Checked = true;
			BasicRef_CBOX.Checked = true;
			ConstantsMelting_CBOX.Checked = true;
			MeltInt_CBOX.Checked = true;
			MeltStr_CBOX.Checked = true;
			RProxy_CBOX.Checked = true;
			Strings_CBOX.Checked = true;
			Controlflow_CBOX.Checked = true;
			Mutation_CBOX.Checked = true;
			AntiDebug_cbox.Checked = true;
			AntiDump_cbox.Checked = true;
			HideMethods_cbox.Checked = true;
			L2F_cbox.Checked = true;
			MathInts_cbox.Checked = true;
			Xor_CBOX.Checked = true;
			CEStr_CBOX.Checked = true;
			Str2FE_CBOX.Checked = true;
			ControlFlowSelection.Value = 4;
			Renaming_cbox.Checked = true;
		}

		private void fF(object sender, EventArgs e)
		{
			if (SaveSame_CBOX.Checked)
			{
				SavePath.Enabled = false;
				Context.samePath = true;
			}
			else
			{
				SavePath.Enabled = true;
				Context.samePath = false;
			}
		}

		private void fG(object sender, EventArgs e)
		{
			treeView1.SelectedNode.BackColor = Color.FromArgb(10, 10, 10);
		}

		private bool fH(IEnumerable nodes, string searchFor)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Text.ToUpper().Contains(searchFor))
				{
					treeView1.SelectedNode = node;
					node.BackColor = Color.Gray;
				}
				if (fH(node.Nodes, searchFor))
				{
					return true;
				}
			}
			return false;
		}

		private void fI(object sender, EventArgs e)
		{
			treeView1.SelectedNode.BackColor = Color.FromArgb(10, 10, 10);
			string text = SMethodText.Text.Trim().ToUpper();
			if (text != "" && treeView1.Nodes.Count > 0 && fH(treeView1.Nodes, text))
			{
				treeView1.SelectedNode.Expand();
				treeView1.Focus();
			}
		}

		private void fJ(object sender, EventArgs e)
		{
			if (VMAll.Checked)
			{
				StrongRef_CBOX.Checked = false;
                VMUtils.Utils.ProtectAll = true;
				treeView1.Enabled = false;
			}
			else
			{
				VMUtils.Utils.ProtectAll = false;
				treeView1.Enabled = true;
			}
		}

		private void fK()
		{
			treeView1.Nodes.Clear();
			foreach (TypeDef type in ctx.Module.GetTypes())
			{
				VMUtils.Utils.hashSet.Add(type.Namespace);
			}
			VMUtils.Utils.hashSet.Distinct();
			foreach (TypeDef type2 in ctx.Module.Types)
			{
				TreeNode treeNode = new TreeNode(type2.Name, 0, 0)
				{
					Tag = 1
				};
				foreach (MethodDef method in type2.Methods)
				{
					if (method != ctx.Module.GlobalType.FindOrCreateStaticConstructor())
					{
						TreeNode treeNode2 = new TreeNode(method.FullName + " MDToken : " + method.MDToken);
						if (method.IsPublic && method.IsConstructor)
						{
							treeNode2.ImageIndex = 2;
							treeNode2.SelectedImageIndex = 2;
						}
						else if (method.IsPrivate && method.IsConstructor)
						{
							treeNode2.ImageIndex = 3;
							treeNode2.SelectedImageIndex = 3;
						}
						else if (method.IsAssembly && method.IsConstructor)
						{
							treeNode2.ImageIndex = 4;
							treeNode2.SelectedImageIndex = 4;
						}
						else if (method.IsFamily && method.IsConstructor)
						{
							treeNode2.ImageIndex = 5;
							treeNode2.SelectedImageIndex = 5;
						}
						else if (method.IsFamilyOrAssembly && method.IsConstructor)
						{
							treeNode2.ImageIndex = 6;
							treeNode2.SelectedImageIndex = 6;
						}
						else if (method.IsPublic)
						{
							treeNode2.ImageIndex = 2;
							treeNode2.SelectedImageIndex = 2;
						}
						else if (method.IsPrivate)
						{
							treeNode2.ImageIndex = 3;
							treeNode2.SelectedImageIndex = 3;
						}
						else if (method.IsAssembly)
						{
							treeNode2.ImageIndex = 4;
							treeNode2.SelectedImageIndex = 4;
						}
						else if (method.IsFamily)
						{
							treeNode2.ImageIndex = 5;
							treeNode2.SelectedImageIndex = 5;
						}
						else if (method.IsFamilyOrAssembly)
						{
							treeNode2.ImageIndex = 6;
							treeNode2.SelectedImageIndex = 6;
						}
						treeNode2.Tag = 2;
						treeNode.Nodes.Add(treeNode2);
						VMUtils.Utils.tempMethodsList.Add(method.FullName);
					}
				}
				treeView1.Nodes.Add(treeNode);
			}
			TreeNode treeNode3 = null;
			foreach (string item in VMUtils.Utils.hashSet)
			{
				if (!(item != string.Empty))
				{
					continue;
				}
				treeNode3 = new TreeNode(item, 0, 0);
				treeNode3.Tag = 0;
				treeView1.Nodes.Add(treeNode3);
				foreach (TypeDef type3 in ctx.Module.Types)
				{
					if (!(treeNode3.Text == type3.Namespace) || !(type3.Namespace != string.Empty) || type3.IsValueType || type3.IsInterface)
					{
						continue;
					}
					TreeNode treeNode4 = new TreeNode(type3.Name.Contains("`") ? type3.Name.Substring(0, type3.Name.IndexOf('`')) : type3.Name.Replace("`", string.Empty), 0, 0);
					treeNode4.Tag = 1;
					foreach (MethodDef method2 in type3.Methods)
					{
						if (method2 != ctx.Module.GlobalType.FindOrCreateStaticConstructor())
						{
							TreeNode treeNode5 = new TreeNode(method2.FullName);
							if (method2.IsPublic && method2.IsConstructor)
							{
								treeNode5.ImageIndex = 2;
								treeNode5.SelectedImageIndex = 2;
							}
							else if (method2.IsPrivate && method2.IsConstructor)
							{
								treeNode5.ImageIndex = 3;
								treeNode5.SelectedImageIndex = 3;
							}
							else if (method2.IsAssembly && method2.IsConstructor)
							{
								treeNode5.ImageIndex = 4;
								treeNode5.SelectedImageIndex = 4;
							}
							else if (method2.IsFamily && method2.IsConstructor)
							{
								treeNode5.ImageIndex = 5;
								treeNode5.SelectedImageIndex = 5;
							}
							else if (method2.IsFamilyOrAssembly && method2.IsConstructor)
							{
								treeNode5.ImageIndex = 6;
								treeNode5.SelectedImageIndex = 6;
							}
							else if (method2.IsPublic)
							{
								treeNode5.ImageIndex = 2;
								treeNode5.SelectedImageIndex = 2;
							}
							else if (method2.IsPrivate)
							{
								treeNode5.ImageIndex = 3;
								treeNode5.SelectedImageIndex = 3;
							}
							else if (method2.IsAssembly)
							{
								treeNode5.ImageIndex = 4;
								treeNode5.SelectedImageIndex = 4;
							}
							else if (method2.IsFamily)
							{
								treeNode5.ImageIndex = 5;
								treeNode5.SelectedImageIndex = 5;
							}
							else if (method2.IsFamilyOrAssembly)
							{
								treeNode5.ImageIndex = 6;
								treeNode5.SelectedImageIndex = 6;
							}
							treeNode5.Tag = 2;
							VMUtils.Utils.tempMethodsList.Add(method2.FullName);
						}
					}
					treeNode3.Nodes.Add(treeNode4);
				}
			}
			try
			{
				int num = 0;
				while (num < treeView1.Nodes.Count)
				{
					TreeNode treeNode6 = treeView1.Nodes[num];
					if (treeNode6.Nodes.Count == 0)
					{
						treeView1.Nodes.Remove(treeNode6);
					}
					else
					{
						num++;
					}
				}
			}
			catch
			{
			}
			treeView1.Sort();
		}

		private void fL(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode.ForeColor == Color.FromArgb(229, 57, 53))
			{
				treeView1.SelectedNode.ForeColor = Color.White;
				VMUtils.Utils.SelectedMethods = VMUtils.Utils.SelectedMethods.Replace(treeView1.SelectedNode.Text, "");
			}
			else if (test == 1)
			{
				test = 0;
				treeView1.SelectedNode.ForeColor = Color.FromArgb(229, 57, 53);
				string text = treeView1.SelectedNode.Text.ToString();
				VMUtils.Utils.SelectedMethods += text;
			}
		}

		private void fM(object sender, TreeViewEventArgs e)
		{
			test = 1;
		}

		private void fN(object sender, KeyPressEventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if (e.KeyChar == '\r' && selectedNode != null)
			{
				if (treeView1.SelectedNode.ForeColor == Color.FromArgb(229, 57, 53))
				{
					treeView1.SelectedNode.ForeColor = Color.White;
					VMUtils.Utils.SelectedMethods = VMUtils.Utils.SelectedMethods.Replace(treeView1.SelectedNode.Text, "");
				}
				else if (test == 1)
				{
					test = 0;
					treeView1.SelectedNode.ForeColor = Color.FromArgb(229, 57, 53);
					string text = treeView1.SelectedNode.Text.ToString();
					VMUtils.Utils.SelectedMethods += text;
				}
			}
		}

		private void fO(object sender, EventArgs e)
		{
		}

		private void fP(object sender, EventArgs e)
		{
			TabControl1.SelectTab(DonatePage);
		}

		private void fQ(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.com/paypalme/inx707");
		}

		private void fR(object sender, EventArgs e)
		{
			Process.Start("https://pastebin.com/raw/3tsH1PVL");
		}

		private void fS(object sender, EventArgs e)
		{
			if (File.Exists(Directory.GetCurrentDirectory() + "\\Saved.txt"))
			{
				string obj = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Saved.txt");
				if (obj.Contains("Control Flow Preset 1 = true"))
				{
					ControlFlowSelection.Value = 1;
				}
				if (obj.Contains("Control Flow Preset 2 = true"))
				{
					ControlFlowSelection.Value = 2;
				}
				if (obj.Contains("Control Flow Preset 3 = true"))
				{
					ControlFlowSelection.Value = 3;
				}
				if (obj.Contains("Control Flow Preset 4 = true"))
				{
					ControlFlowSelection.Value = 4;
				}
				if (obj.Contains("Control Flow Preset 5 = true"))
				{
					ControlFlowSelection.Value = 5;
				}
				if (obj.Contains("Control Flow Preset 6 = true"))
				{
					ControlFlowSelection.Value = 6;
				}
				if (obj.Contains("Basic RProxy = true"))
				{
					BasicRef_CBOX.Checked = true;
				}
				if (obj.Contains("Strong RProxy = true"))
				{
					StrongRef_CBOX.Checked = true;
				}
				if (obj.Contains("Junk Classes = true"))
				{
					JunkClasses_CBOX.Checked = true;
				}
				if (obj.Contains("Junk Methods = true"))
				{
					JunkMethods_CBOX.Checked = true;
				}
				if (obj.Contains("CEncode Strings = true"))
				{
					CEStr_CBOX.Checked = true;
				}
				if (obj.Contains("Xor Strings = true"))
				{
					Xor_CBOX.Checked = true;
				}
				if (obj.Contains("Strings 2 Fields = true"))
				{
					Str2FE_CBOX.Checked = true;
				}
				if (obj.Contains("Melt Integers = true"))
				{
					MeltInt_CBOX.Checked = true;
				}
				if (obj.Contains("Melt Strings = true"))
				{
					MeltStr_CBOX.Checked = true;
				}
				if (obj.Contains("Math Mutation = true"))
				{
					MathMutate_CBOX.Checked = true;
				}
				if (obj.Contains("Fake IF = true"))
				{
					Fakeif_CBOX.Checked = true;
				}
				if (obj.Contains("Math Operation = true"))
				{
					Mathop_CBOX.Checked = true;
				}
				if (obj.Contains("Send Data = true"))
				{
					SendToWH_cbox.Checked = true;
				}
				if (obj.Contains("Ban Cracker = true"))
				{
					BanCracker_CBOX.Checked = true;
				}
				if (obj.Contains("Capture Screen = true"))
				{
					siticoneOSToggleSwith1.Checked = true;
				}
				if (obj.Contains("Types = true"))
				{
					rTypes_cbox.Checked = true;
				}
				if (obj.Contains("Properties = true"))
				{
					rProperties_cbox.Checked = true;
				}
				if (obj.Contains("Methods = true"))
				{
					rMethods_cbox.Checked = true;
				}
				if (obj.Contains("Fields = true"))
				{
					rFields_cbox.Checked = true;
				}
				if (obj.Contains("Events = true"))
				{
					rEvents_cbox.Checked = true;
				}
				if (obj.Contains("Parameters = true"))
				{
					rParam_cbox.Checked = true;
				}
				if (obj.Contains("Hide Namespaces = true"))
				{
					HideNamespaces_Cbox.Checked = true;
				}
				if (obj.Contains("Anti tamper = true"))
				{
					HideMethods_cbox.Checked = true;
				}
				if (obj.Contains("Flood cctor = true"))
				{
					Flood_CBOX.Checked = true;
				}
				if (obj.Contains("Anti dump = true"))
				{
					AntiDump_cbox.Checked = true;
				}
				if (obj.Contains("Anti vm = true"))
				{
					AntiVM_cbox.Checked = true;
				}
				if (obj.Contains("Anti crack = true"))
				{
					AntiCracker_cbox.Checked = true;
				}
				if (obj.Contains("Anti http = true"))
				{
					AntiHttp_cbox.Checked = true;
				}
				if (obj.Contains("Anti debug = true"))
				{
					AntiDebug_cbox.Checked = true;
				}
				if (obj.Contains("Junk = true"))
				{
					Junk_cbox.Checked = true;
				}
				if (obj.Contains("Strings encoding = true"))
				{
					Strings_CBOX.Checked = true;
				}
				if (obj.Contains("Int math = true"))
				{
					MathInts_cbox.Checked = true;
				}
				if (obj.Contains("Mutation = true"))
				{
					Mutation_CBOX.Checked = true;
				}
				if (obj.Contains("Ref proxy = true"))
				{
					RProxy_CBOX.Checked = true;
				}
				if (obj.Contains("Control flow = true"))
				{
					Controlflow_CBOX.Checked = true;
				}
				if (obj.Contains("L2F = true"))
				{
					L2F_cbox.Checked = true;
				}
				if (obj.Contains("Renamer = true"))
				{
					Renaming_cbox.Checked = true;
				}
			}
		}

		private void fT(object sender, EventArgs e)
		{
			TabControl1.SelectTab(SettingsPage);
		}

		private void fU(object sender, EventArgs e)
		{
			if (TR_CBOX.Checked)
			{
				base.Opacity = 0.98;
			}
			else
			{
				base.Opacity = 100.0;
			}
		}

		private void fV(object sender, EventArgs e)
		{
			if (AOT_CBOX.Checked)
			{
				base.TopMost = true;
			}
			else
			{
				base.TopMost = false;
			}
		}

		private void fW(object sender, EventArgs e)
		{
			if (FlatB_CBOX.Checked)
			{
				eF.BorderRadius = 0;
			}
			else
			{
				eF.BorderRadius = 6;
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
            this.components = new System.ComponentModel.Container();
            this.eF = new ns1.SiticoneElipse(this.components);
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.MainPage = new System.Windows.Forms.TabPage();
            this.iLabel92 = new ILabel();
            this.SaveSame_CBOX = new ns1.SiticoneOSToggleSwith();
            this.ImportSession = new ns1.SiticoneButton();
            this.iLabel85 = new ILabel();
            this.SaveProtections_CBOX = new ns1.SiticoneOSToggleSwith();
            this.iLabel2 = new ILabel();
            this.iLabel1 = new ILabel();
            this.SavePath = new ns1.SiticoneRoundedTextBox();
            this.AsmPath = new ns1.SiticoneRoundedTextBox();
            this.SelectFolder = new ns1.SiticoneImageButton();
            this.ProtectAssembly = new ns1.SiticoneButton();
            this.AddAssembly = new ns1.SiticoneImageButton();
            this.ProtectionsPage = new System.Windows.Forms.TabPage();
            this.panel21 = new System.Windows.Forms.Panel();
            this.siticoneRoundedButton1 = new ns1.SiticoneRoundedButton();
            this.iLabel62 = new ILabel();
            this.ConstantsMelting_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator33 = new ns1.SiticoneVSeparator();
            this.panel3 = new System.Windows.Forms.Panel();
            this.siticoneRoundedButton2 = new ns1.SiticoneRoundedButton();
            this.iLabel61 = new ILabel();
            this.RProxy_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator32 = new ns1.SiticoneVSeparator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iLabel4 = new ILabel();
            this.siticoneVSeparator3 = new ns1.SiticoneVSeparator();
            this.Flood_CBOX = new ns1.SiticoneOSToggleSwith();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iLabel3 = new ILabel();
            this.siticoneVSeparator2 = new ns1.SiticoneVSeparator();
            this.HideMethods_cbox = new ns1.SiticoneOSToggleSwith();
            this.Recommended = new ns1.SiticoneRoundedButton();
            this.CheckAll_Button = new ns1.SiticoneRoundedButton();
            this.panel14 = new System.Windows.Forms.Panel();
            this.iLabel18 = new ILabel();
            this.siticoneVSeparator15 = new ns1.SiticoneVSeparator();
            this.L2F_cbox = new ns1.SiticoneOSToggleSwith();
            this.panel13 = new System.Windows.Forms.Panel();
            this.ControlFlowStatus = new ILabel();
            this.iLabel17 = new ILabel();
            this.Controlflow_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator14 = new ns1.SiticoneVSeparator();
            this.ControlFlowSelection = new ns1.SiticoneTrackBar();
            this.panel12 = new System.Windows.Forms.Panel();
            this.GoToMSettings = new ns1.SiticoneRoundedButton();
            this.iLabel16 = new ILabel();
            this.Mutation_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator13 = new ns1.SiticoneVSeparator();
            this.panel11 = new System.Windows.Forms.Panel();
            this.iLabel15 = new ILabel();
            this.siticoneVSeparator12 = new ns1.SiticoneVSeparator();
            this.MathInts_cbox = new ns1.SiticoneOSToggleSwith();
            this.panel10 = new System.Windows.Forms.Panel();
            this.GoToStrings = new ns1.SiticoneRoundedButton();
            this.iLabel14 = new ILabel();
            this.Strings_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator11 = new ns1.SiticoneVSeparator();
            this.panel9 = new System.Windows.Forms.Panel();
            this.JunkSettings = new ns1.SiticoneRoundedButton();
            this.iLabel12 = new ILabel();
            this.siticoneVSeparator10 = new ns1.SiticoneVSeparator();
            this.Junk_cbox = new ns1.SiticoneOSToggleSwith();
            this.panel8 = new System.Windows.Forms.Panel();
            this.iLabel11 = new ILabel();
            this.siticoneVSeparator9 = new ns1.SiticoneVSeparator();
            this.AntiDebug_cbox = new ns1.SiticoneOSToggleSwith();
            this.panel7 = new System.Windows.Forms.Panel();
            this.iLabel10 = new ILabel();
            this.siticoneVSeparator8 = new ns1.SiticoneVSeparator();
            this.AntiHttp_cbox = new ns1.SiticoneOSToggleSwith();
            this.panel6 = new System.Windows.Forms.Panel();
            this.GoToACS = new ns1.SiticoneRoundedButton();
            this.iLabel8 = new ILabel();
            this.siticoneVSeparator7 = new ns1.SiticoneVSeparator();
            this.AntiCracker_cbox = new ns1.SiticoneOSToggleSwith();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iLabel7 = new ILabel();
            this.siticoneVSeparator6 = new ns1.SiticoneVSeparator();
            this.AntiVM_cbox = new ns1.SiticoneOSToggleSwith();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iLabel5 = new ILabel();
            this.siticoneVSeparator5 = new ns1.SiticoneVSeparator();
            this.AntiDump_cbox = new ns1.SiticoneOSToggleSwith();
            this.RenamerPage = new System.Windows.Forms.TabPage();
            this.panel16 = new System.Windows.Forms.Panel();
            this.iLabel56 = new ILabel();
            this.SaveNameMap_CBOX = new ns1.SiticoneOSToggleSwith();
            this.iLabel28 = new ILabel();
            this.iLabel27 = new ILabel();
            this.iLabel26 = new ILabel();
            this.iLabel25 = new ILabel();
            this.iLabel24 = new ILabel();
            this.iLabel23 = new ILabel();
            this.iLabel22 = new ILabel();
            this.iLabel21 = new ILabel();
            this.iLabel20 = new ILabel();
            this.CodeAnalyzation_cbox = new ns1.SiticoneOSToggleSwith();
            this.HideNamespaces_Cbox = new ns1.SiticoneOSToggleSwith();
            this.rParam_cbox = new ns1.SiticoneOSToggleSwith();
            this.rEvents_cbox = new ns1.SiticoneOSToggleSwith();
            this.rFields_cbox = new ns1.SiticoneOSToggleSwith();
            this.rMethods_cbox = new ns1.SiticoneOSToggleSwith();
            this.rProperties_cbox = new ns1.SiticoneOSToggleSwith();
            this.rTypes_cbox = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator17 = new ns1.SiticoneVSeparator();
            this.panel15 = new System.Windows.Forms.Panel();
            this.iLabel19 = new ILabel();
            this.siticoneVSeparator16 = new ns1.SiticoneVSeparator();
            this.Renaming_cbox = new ns1.SiticoneOSToggleSwith();
            this.VirtualizationPage = new System.Windows.Forms.TabPage();
            this.panel22 = new System.Windows.Forms.Panel();
            this.SearchForMethod = new ns1.SiticoneRoundedButton();
            this.SMethodText = new ns1.SiticoneRoundedTextBox();
            this.iLabel60 = new ILabel();
            this.siticoneVSeparator41 = new ns1.SiticoneVSeparator();
            this.panel17 = new System.Windows.Forms.Panel();
            this.iLabel91 = new ILabel();
            this.VMAll = new ns1.SiticoneOSToggleSwith();
            this.iLabel29 = new ILabel();
            this.siticoneVSeparator18 = new ns1.SiticoneVSeparator();
            this.Virt_cbox = new ns1.SiticoneOSToggleSwith();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.CodeOptimizationPage = new System.Windows.Forms.TabPage();
            this.panel20 = new System.Windows.Forms.Panel();
            this.iLabel32 = new ILabel();
            this.siticoneVSeparator21 = new ns1.SiticoneVSeparator();
            this.ReduceMD_cbox = new ns1.SiticoneOSToggleSwith();
            this.panel19 = new System.Windows.Forms.Panel();
            this.iLabel31 = new ILabel();
            this.siticoneVSeparator20 = new ns1.SiticoneVSeparator();
            this.OptimizeMethods_cbox = new ns1.SiticoneOSToggleSwith();
            this.panel18 = new System.Windows.Forms.Panel();
            this.iLabel30 = new ILabel();
            this.siticoneVSeparator19 = new ns1.SiticoneVSeparator();
            this.OptimizeCode_cbox = new ns1.SiticoneOSToggleSwith();
            this.LogPage = new System.Windows.Forms.TabPage();
            this.LogText = new System.Windows.Forms.TextBox();
            this.siticoneVSeparator4 = new ns1.SiticoneVSeparator();
            this.iLabel45 = new ILabel();
            this.HelpPage = new System.Windows.Forms.TabPage();
            this.iLabel34 = new ILabel();
            this.siticoneVSeparator28 = new ns1.SiticoneVSeparator();
            this.DiscordServer = new ns1.SiticoneImageButton();
            this.iLabel33 = new ILabel();
            this.CreditsPage = new System.Windows.Forms.TabPage();
            this.iLabel89 = new ILabel();
            this.iLabel90 = new ILabel();
            this.siticoneVSeparator40 = new ns1.SiticoneVSeparator();
            this.siticoneVSeparator25 = new ns1.SiticoneVSeparator();
            this.siticoneVSeparator24 = new ns1.SiticoneVSeparator();
            this.siticoneVSeparator23 = new ns1.SiticoneVSeparator();
            this.siticoneVSeparator22 = new ns1.SiticoneVSeparator();
            this.iLabel50 = new ILabel();
            this.iLabel49 = new ILabel();
            this.iLabel40 = new ILabel();
            this.iLabel39 = new ILabel();
            this.iLabel37 = new ILabel();
            this.iLabel36 = new ILabel();
            this.iLabel35 = new ILabel();
            this.iLabel38 = new ILabel();
            this.GuidePage = new System.Windows.Forms.TabPage();
            this.iLabel43 = new ILabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.siticoneVSeparator27 = new ns1.SiticoneVSeparator();
            this.iLabel41 = new ILabel();
            this.AntiCrackSettings = new System.Windows.Forms.TabPage();
            this.siticoneOSToggleSwith1 = new ns1.SiticoneOSToggleSwith();
            this.UnBanBtn = new ns1.SiticoneRoundedButton();
            this.addP = new ns1.SiticoneImageButton();
            this.pname = new ns1.SiticoneTextBox();
            this.BackToProtections = new ns1.SiticoneImageButton();
            this.BanCracker_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator29 = new ns1.SiticoneVSeparator();
            this.PasteWHLink = new ns1.SiticoneRoundedButton();
            this.SendToWH_cbox = new ns1.SiticoneOSToggleSwith();
            this.iLabel94 = new ILabel();
            this.iLabel63 = new ILabel();
            this.iLabel48 = new ILabel();
            this.iLabel47 = new ILabel();
            this.LinkStatus = new ILabel();
            this.iLabel46 = new ILabel();
            this.iLabel44 = new ILabel();
            this.iLabel9 = new ILabel();
            this.MutationSettingsPage = new System.Windows.Forms.TabPage();
            this.iLabel59 = new ILabel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.siticoneVSeparator31 = new ns1.SiticoneVSeparator();
            this.Mathop_CBOX = new ns1.SiticoneOSToggleSwith();
            this.Fakeif_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneImageButton2 = new ns1.SiticoneImageButton();
            this.siticoneVSeparator30 = new ns1.SiticoneVSeparator();
            this.MathMutate_CBOX = new ns1.SiticoneOSToggleSwith();
            this.iLabel58 = new ILabel();
            this.iLabel57 = new ILabel();
            this.iLabel55 = new ILabel();
            this.iLabel54 = new ILabel();
            this.iLabel53 = new ILabel();
            this.iLabel51 = new ILabel();
            this.iLabel52 = new ILabel();
            this.ConstansMeltingPage = new System.Windows.Forms.TabPage();
            this.iLabel72 = new ILabel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.siticoneVSeparator36 = new ns1.SiticoneVSeparator();
            this.siticoneImageButton3 = new ns1.SiticoneImageButton();
            this.MeltInt_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator34 = new ns1.SiticoneVSeparator();
            this.MeltStr_CBOX = new ns1.SiticoneOSToggleSwith();
            this.iLabel65 = new ILabel();
            this.iLabel66 = new ILabel();
            this.iLabel67 = new ILabel();
            this.StringsSettingsPage = new System.Windows.Forms.TabPage();
            this.OutlineStrings_CBOX = new ns1.SiticoneOSToggleSwith();
            this.Str2FE_CBOX = new ns1.SiticoneOSToggleSwith();
            this.Xor_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneImageButton4 = new ns1.SiticoneImageButton();
            this.CEStr_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator35 = new ns1.SiticoneVSeparator();
            this.iLabel69 = new ILabel();
            this.iLabel71 = new ILabel();
            this.iLabel70 = new ILabel();
            this.iLabel64 = new ILabel();
            this.iLabel68 = new ILabel();
            this.JunkSettingsPage = new System.Windows.Forms.TabPage();
            this.iLabel78 = new ILabel();
            this.JunkContent = new ns1.SiticoneRoundedTextBox();
            this.JunkMLength = new ns1.SiticoneRoundedTextBox();
            this.JunkCName = new ns1.SiticoneRoundedTextBox();
            this.JunkMethods_CBOX = new ns1.SiticoneOSToggleSwith();
            this.JunkLength = new ns1.SiticoneRoundedTextBox();
            this.JunkClasses_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneImageButton5 = new ns1.SiticoneImageButton();
            this.siticoneVSeparator26 = new ns1.SiticoneVSeparator();
            this.iLabel77 = new ILabel();
            this.iLabel75 = new ILabel();
            this.iLabel74 = new ILabel();
            this.iLabel73 = new ILabel();
            this.iLabel13 = new ILabel();
            this.iLabel76 = new ILabel();
            this.DonatePage = new System.Windows.Forms.TabPage();
            this.Bitcoin = new ns1.SiticoneImageButton();
            this.Paypal = new ns1.SiticoneImageButton();
            this.siticoneVSeparator37 = new ns1.SiticoneVSeparator();
            this.iLabel79 = new ILabel();
            this.iLabel80 = new ILabel();
            this.iLabel81 = new ILabel();
            this.iLabel42 = new ILabel();
            this.RefProxyPage = new System.Windows.Forms.TabPage();
            this.siticoneImageButton6 = new ns1.SiticoneImageButton();
            this.StrongRef_CBOX = new ns1.SiticoneOSToggleSwith();
            this.BasicRef_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator38 = new ns1.SiticoneVSeparator();
            this.iLabel84 = new ILabel();
            this.iLabel83 = new ILabel();
            this.iLabel82 = new ILabel();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.FlatB_CBOX = new ns1.SiticoneOSToggleSwith();
            this.AOT_CBOX = new ns1.SiticoneOSToggleSwith();
            this.TR_CBOX = new ns1.SiticoneOSToggleSwith();
            this.siticoneVSeparator39 = new ns1.SiticoneVSeparator();
            this.iLabel93 = new ILabel();
            this.iLabel88 = new ILabel();
            this.iLabel87 = new ILabel();
            this.iLabel86 = new ILabel();
            this.GoToLog = new ns1.SiticoneButton();
            this.GoToCodeOptimization = new ns1.SiticoneButton();
            this.GoToRenamer = new ns1.SiticoneButton();
            this.GoToVirtualization = new ns1.SiticoneButton();
            this.GoToProtections = new ns1.SiticoneButton();
            this.GoToMain = new ns1.SiticoneButton();
            this.TabControl1.SuspendLayout();
            this.MainPage.SuspendLayout();
            this.ProtectionsPage.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.RenamerPage.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.VirtualizationPage.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel17.SuspendLayout();
            this.CodeOptimizationPage.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel18.SuspendLayout();
            this.LogPage.SuspendLayout();
            this.HelpPage.SuspendLayout();
            this.CreditsPage.SuspendLayout();
            this.GuidePage.SuspendLayout();
            this.AntiCrackSettings.SuspendLayout();
            this.MutationSettingsPage.SuspendLayout();
            this.ConstansMeltingPage.SuspendLayout();
            this.StringsSettingsPage.SuspendLayout();
            this.JunkSettingsPage.SuspendLayout();
            this.DonatePage.SuspendLayout();
            this.RefProxyPage.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // eF
            // 
            this.eF.TargetControl = this;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.MainPage);
            this.TabControl1.Controls.Add(this.ProtectionsPage);
            this.TabControl1.Controls.Add(this.RenamerPage);
            this.TabControl1.Controls.Add(this.VirtualizationPage);
            this.TabControl1.Controls.Add(this.CodeOptimizationPage);
            this.TabControl1.Controls.Add(this.LogPage);
            this.TabControl1.Controls.Add(this.HelpPage);
            this.TabControl1.Controls.Add(this.CreditsPage);
            this.TabControl1.Controls.Add(this.GuidePage);
            this.TabControl1.Controls.Add(this.AntiCrackSettings);
            this.TabControl1.Controls.Add(this.MutationSettingsPage);
            this.TabControl1.Controls.Add(this.ConstansMeltingPage);
            this.TabControl1.Controls.Add(this.StringsSettingsPage);
            this.TabControl1.Controls.Add(this.JunkSettingsPage);
            this.TabControl1.Controls.Add(this.DonatePage);
            this.TabControl1.Controls.Add(this.RefProxyPage);
            this.TabControl1.Controls.Add(this.SettingsPage);
            this.TabControl1.Location = new System.Drawing.Point(218, 17);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(705, 337);
            this.TabControl1.TabIndex = 0;
            // 
            // MainPage
            // 
            this.MainPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.MainPage.Controls.Add(this.iLabel92);
            this.MainPage.Controls.Add(this.SaveSame_CBOX);
            this.MainPage.Controls.Add(this.ImportSession);
            this.MainPage.Controls.Add(this.iLabel85);
            this.MainPage.Controls.Add(this.SaveProtections_CBOX);
            this.MainPage.Controls.Add(this.iLabel2);
            this.MainPage.Controls.Add(this.iLabel1);
            this.MainPage.Controls.Add(this.SavePath);
            this.MainPage.Controls.Add(this.AsmPath);
            this.MainPage.Controls.Add(this.SelectFolder);
            this.MainPage.Controls.Add(this.ProtectAssembly);
            this.MainPage.Controls.Add(this.AddAssembly);
            this.MainPage.Location = new System.Drawing.Point(4, 22);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainPage.Size = new System.Drawing.Size(697, 311);
            this.MainPage.TabIndex = 0;
            // 
            // iLabel92
            // 
            this.iLabel92.AutoSize = true;
            this.iLabel92.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel92.ForeColor = System.Drawing.Color.White;
            this.iLabel92.Location = new System.Drawing.Point(78, 149);
            this.iLabel92.Name = "iLabel92";
            this.iLabel92.Size = new System.Drawing.Size(228, 19);
            this.iLabel92.TabIndex = 154;
            this.iLabel92.Text = "Save protected file in the same path";
            this.iLabel92.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // SaveSame_CBOX
            // 
            this.SaveSame_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.SaveSame_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.SaveSame_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveSame_CBOX.Location = new System.Drawing.Point(32, 148);
            this.SaveSame_CBOX.Name = "SaveSame_CBOX";
            this.SaveSame_CBOX.Size = new System.Drawing.Size(38, 22);
            this.SaveSame_CBOX.TabIndex = 153;
            this.SaveSame_CBOX.Text = "siticoneOSToggleSwith1";
            this.SaveSame_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.SaveSame_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.SaveSame_CBOX.CheckedChanged += new System.EventHandler(this.fF);
            // 
            // ImportSession
            // 
            this.ImportSession.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.ImportSession.BorderRadius = 6;
            this.ImportSession.BorderThickness = 1;
            this.ImportSession.CheckedState.Parent = this.ImportSession;
            this.ImportSession.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImportSession.CustomImages.Parent = this.ImportSession;
            this.ImportSession.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ImportSession.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ImportSession.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ImportSession.HoveredState.Parent = this.ImportSession;
            this.ImportSession.ImageSize = new System.Drawing.Size(24, 24);
            this.ImportSession.Location = new System.Drawing.Point(32, 214);
            this.ImportSession.Name = "ImportSession";
            this.ImportSession.ShadowDecoration.Parent = this.ImportSession;
            this.ImportSession.Size = new System.Drawing.Size(281, 45);
            this.ImportSession.TabIndex = 152;
            this.ImportSession.Text = "Import saved protections";
            this.ImportSession.Click += new System.EventHandler(this.fS);
            // 
            // iLabel85
            // 
            this.iLabel85.AutoSize = true;
            this.iLabel85.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel85.ForeColor = System.Drawing.Color.White;
            this.iLabel85.Location = new System.Drawing.Point(78, 178);
            this.iLabel85.Name = "iLabel85";
            this.iLabel85.Size = new System.Drawing.Size(110, 19);
            this.iLabel85.TabIndex = 150;
            this.iLabel85.Text = "Save Protections";
            this.iLabel85.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // SaveProtections_CBOX
            // 
            this.SaveProtections_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.SaveProtections_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.SaveProtections_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveProtections_CBOX.Location = new System.Drawing.Point(32, 177);
            this.SaveProtections_CBOX.Name = "SaveProtections_CBOX";
            this.SaveProtections_CBOX.Size = new System.Drawing.Size(38, 22);
            this.SaveProtections_CBOX.TabIndex = 149;
            this.SaveProtections_CBOX.Text = "siticoneOSToggleSwith1";
            this.SaveProtections_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.SaveProtections_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // iLabel2
            // 
            this.iLabel2.AutoSize = true;
            this.iLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel2.ForeColor = System.Drawing.Color.White;
            this.iLabel2.Location = new System.Drawing.Point(28, 72);
            this.iLabel2.Name = "iLabel2";
            this.iLabel2.Size = new System.Drawing.Size(61, 19);
            this.iLabel2.TabIndex = 148;
            this.iLabel2.Text = "Save to :";
            this.iLabel2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel1
            // 
            this.iLabel1.AutoSize = true;
            this.iLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel1.ForeColor = System.Drawing.Color.White;
            this.iLabel1.Location = new System.Drawing.Point(28, 11);
            this.iLabel1.Name = "iLabel1";
            this.iLabel1.Size = new System.Drawing.Size(44, 19);
            this.iLabel1.TabIndex = 147;
            this.iLabel1.Text = "Path :";
            this.iLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // SavePath
            // 
            this.SavePath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.SavePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SavePath.DefaultText = "";
            this.SavePath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SavePath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SavePath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SavePath.DisabledState.Parent = this.SavePath;
            this.SavePath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SavePath.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.SavePath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.SavePath.FocusedState.Parent = this.SavePath;
            this.SavePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.SavePath.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.SavePath.HoveredState.Parent = this.SavePath;
            this.SavePath.Location = new System.Drawing.Point(17, 95);
            this.SavePath.Name = "SavePath";
            this.SavePath.PasswordChar = '\0';
            this.SavePath.PlaceholderText = "";
            this.SavePath.SelectedText = "";
            this.SavePath.ShadowDecoration.Parent = this.SavePath;
            this.SavePath.Size = new System.Drawing.Size(446, 36);
            this.SavePath.TabIndex = 17;
            // 
            // AsmPath
            // 
            this.AsmPath.AllowDrop = true;
            this.AsmPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.AsmPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AsmPath.DefaultText = "Drag n drop assembly here !";
            this.AsmPath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.AsmPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.AsmPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.AsmPath.DisabledState.Parent = this.AsmPath;
            this.AsmPath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.AsmPath.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.AsmPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.AsmPath.FocusedState.Parent = this.AsmPath;
            this.AsmPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.AsmPath.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.AsmPath.HoveredState.Parent = this.AsmPath;
            this.AsmPath.Location = new System.Drawing.Point(17, 33);
            this.AsmPath.Name = "AsmPath";
            this.AsmPath.PasswordChar = '\0';
            this.AsmPath.PlaceholderText = "";
            this.AsmPath.SelectedText = "";
            this.AsmPath.ShadowDecoration.Parent = this.AsmPath;
            this.AsmPath.Size = new System.Drawing.Size(446, 36);
            this.AsmPath.TabIndex = 16;
            this.AsmPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.ff);
            this.AsmPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.fg);
            // 
            // SelectFolder
            // 
            this.SelectFolder.CheckedState.Parent = this.SelectFolder;
            this.SelectFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectFolder.HoveredState.ImageSize = new System.Drawing.Size(31, 31);
            this.SelectFolder.HoveredState.Parent = this.SelectFolder;
            this.SelectFolder.ImageSize = new System.Drawing.Size(36, 36);
            this.SelectFolder.Location = new System.Drawing.Point(472, 95);
            this.SelectFolder.Name = "SelectFolder";
            this.SelectFolder.PressedState.ImageSize = new System.Drawing.Size(30, 30);
            this.SelectFolder.PressedState.Parent = this.SelectFolder;
            this.SelectFolder.Size = new System.Drawing.Size(36, 36);
            this.SelectFolder.TabIndex = 15;
            this.SelectFolder.Click += new System.EventHandler(this.fh);
            // 
            // ProtectAssembly
            // 
            this.ProtectAssembly.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.ProtectAssembly.BorderRadius = 6;
            this.ProtectAssembly.BorderThickness = 1;
            this.ProtectAssembly.CheckedState.Parent = this.ProtectAssembly;
            this.ProtectAssembly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProtectAssembly.CustomImages.Parent = this.ProtectAssembly;
            this.ProtectAssembly.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ProtectAssembly.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ProtectAssembly.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ProtectAssembly.HoveredState.Parent = this.ProtectAssembly;
            this.ProtectAssembly.ImageSize = new System.Drawing.Size(24, 24);
            this.ProtectAssembly.Location = new System.Drawing.Point(513, 251);
            this.ProtectAssembly.Name = "ProtectAssembly";
            this.ProtectAssembly.ShadowDecoration.Parent = this.ProtectAssembly;
            this.ProtectAssembly.Size = new System.Drawing.Size(169, 45);
            this.ProtectAssembly.TabIndex = 14;
            this.ProtectAssembly.Text = "Protect !";
            this.ProtectAssembly.Click += new System.EventHandler(this.fn);
            // 
            // AddAssembly
            // 
            this.AddAssembly.CheckedState.Parent = this.AddAssembly;
            this.AddAssembly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddAssembly.HoveredState.ImageSize = new System.Drawing.Size(31, 31);
            this.AddAssembly.HoveredState.Parent = this.AddAssembly;
            this.AddAssembly.ImageSize = new System.Drawing.Size(36, 36);
            this.AddAssembly.Location = new System.Drawing.Point(472, 33);
            this.AddAssembly.Name = "AddAssembly";
            this.AddAssembly.PressedState.ImageSize = new System.Drawing.Size(30, 30);
            this.AddAssembly.PressedState.Parent = this.AddAssembly;
            this.AddAssembly.Size = new System.Drawing.Size(36, 36);
            this.AddAssembly.TabIndex = 11;
            this.AddAssembly.Click += new System.EventHandler(this.fe);
            // 
            // ProtectionsPage
            // 
            this.ProtectionsPage.AutoScroll = true;
            this.ProtectionsPage.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.ProtectionsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ProtectionsPage.Controls.Add(this.panel21);
            this.ProtectionsPage.Controls.Add(this.panel3);
            this.ProtectionsPage.Controls.Add(this.panel2);
            this.ProtectionsPage.Controls.Add(this.panel1);
            this.ProtectionsPage.Controls.Add(this.Recommended);
            this.ProtectionsPage.Controls.Add(this.CheckAll_Button);
            this.ProtectionsPage.Controls.Add(this.panel14);
            this.ProtectionsPage.Controls.Add(this.panel13);
            this.ProtectionsPage.Controls.Add(this.panel12);
            this.ProtectionsPage.Controls.Add(this.panel11);
            this.ProtectionsPage.Controls.Add(this.panel10);
            this.ProtectionsPage.Controls.Add(this.panel9);
            this.ProtectionsPage.Controls.Add(this.panel8);
            this.ProtectionsPage.Controls.Add(this.panel7);
            this.ProtectionsPage.Controls.Add(this.panel6);
            this.ProtectionsPage.Controls.Add(this.panel5);
            this.ProtectionsPage.Controls.Add(this.panel4);
            this.ProtectionsPage.Location = new System.Drawing.Point(4, 22);
            this.ProtectionsPage.Name = "ProtectionsPage";
            this.ProtectionsPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProtectionsPage.Size = new System.Drawing.Size(697, 311);
            this.ProtectionsPage.TabIndex = 1;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel21.Controls.Add(this.siticoneRoundedButton1);
            this.panel21.Controls.Add(this.iLabel62);
            this.panel21.Controls.Add(this.ConstantsMelting_CBOX);
            this.panel21.Controls.Add(this.siticoneVSeparator33);
            this.panel21.Location = new System.Drawing.Point(10, 584);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(658, 50);
            this.panel21.TabIndex = 163;
            // 
            // siticoneRoundedButton1
            // 
            this.siticoneRoundedButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneRoundedButton1.BorderThickness = 1;
            this.siticoneRoundedButton1.CheckedState.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneRoundedButton1.CustomImages.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.siticoneRoundedButton1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.siticoneRoundedButton1.ForeColor = System.Drawing.Color.White;
            this.siticoneRoundedButton1.HoveredState.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.ImageSize = new System.Drawing.Size(24, 24);
            this.siticoneRoundedButton1.Location = new System.Drawing.Point(551, 10);
            this.siticoneRoundedButton1.Name = "siticoneRoundedButton1";
            this.siticoneRoundedButton1.PressedColor = System.Drawing.Color.BlanchedAlmond;
            this.siticoneRoundedButton1.ShadowDecoration.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.Size = new System.Drawing.Size(97, 30);
            this.siticoneRoundedButton1.TabIndex = 162;
            this.siticoneRoundedButton1.Text = "Settings";
            this.siticoneRoundedButton1.Click += new System.EventHandler(this.fB);
            // 
            // iLabel62
            // 
            this.iLabel62.AutoSize = true;
            this.iLabel62.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel62.ForeColor = System.Drawing.Color.White;
            this.iLabel62.Location = new System.Drawing.Point(67, 15);
            this.iLabel62.Name = "iLabel62";
            this.iLabel62.Size = new System.Drawing.Size(125, 19);
            this.iLabel62.TabIndex = 160;
            this.iLabel62.Text = "Constants Outliner";
            this.iLabel62.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // ConstantsMelting_CBOX
            // 
            this.ConstantsMelting_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.ConstantsMelting_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.ConstantsMelting_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConstantsMelting_CBOX.Location = new System.Drawing.Point(21, 14);
            this.ConstantsMelting_CBOX.Name = "ConstantsMelting_CBOX";
            this.ConstantsMelting_CBOX.Size = new System.Drawing.Size(38, 22);
            this.ConstantsMelting_CBOX.TabIndex = 154;
            this.ConstantsMelting_CBOX.Text = "siticoneOSToggleSwith2";
            this.ConstantsMelting_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.ConstantsMelting_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneVSeparator33
            // 
            this.siticoneVSeparator33.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator33.FillThickness = 4;
            this.siticoneVSeparator33.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator33.Name = "siticoneVSeparator33";
            this.siticoneVSeparator33.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator33.TabIndex = 90;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel3.Controls.Add(this.siticoneRoundedButton2);
            this.panel3.Controls.Add(this.iLabel61);
            this.panel3.Controls.Add(this.RProxy_CBOX);
            this.panel3.Controls.Add(this.siticoneVSeparator32);
            this.panel3.Location = new System.Drawing.Point(10, 636);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(658, 50);
            this.panel3.TabIndex = 155;
            // 
            // siticoneRoundedButton2
            // 
            this.siticoneRoundedButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneRoundedButton2.BorderThickness = 1;
            this.siticoneRoundedButton2.CheckedState.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneRoundedButton2.CustomImages.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.siticoneRoundedButton2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.siticoneRoundedButton2.ForeColor = System.Drawing.Color.White;
            this.siticoneRoundedButton2.HoveredState.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.ImageSize = new System.Drawing.Size(24, 24);
            this.siticoneRoundedButton2.Location = new System.Drawing.Point(551, 10);
            this.siticoneRoundedButton2.Name = "siticoneRoundedButton2";
            this.siticoneRoundedButton2.PressedColor = System.Drawing.Color.BlanchedAlmond;
            this.siticoneRoundedButton2.ShadowDecoration.Parent = this.siticoneRoundedButton2;
            this.siticoneRoundedButton2.Size = new System.Drawing.Size(97, 30);
            this.siticoneRoundedButton2.TabIndex = 163;
            this.siticoneRoundedButton2.Text = "Settings";
            this.siticoneRoundedButton2.Click += new System.EventHandler(this.fC);
            // 
            // iLabel61
            // 
            this.iLabel61.AutoSize = true;
            this.iLabel61.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel61.ForeColor = System.Drawing.Color.White;
            this.iLabel61.Location = new System.Drawing.Point(67, 15);
            this.iLabel61.Name = "iLabel61";
            this.iLabel61.Size = new System.Drawing.Size(106, 19);
            this.iLabel61.TabIndex = 160;
            this.iLabel61.Text = "Reference Proxy";
            this.iLabel61.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // RProxy_CBOX
            // 
            this.RProxy_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.RProxy_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.RProxy_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RProxy_CBOX.Location = new System.Drawing.Point(21, 14);
            this.RProxy_CBOX.Name = "RProxy_CBOX";
            this.RProxy_CBOX.Size = new System.Drawing.Size(38, 22);
            this.RProxy_CBOX.TabIndex = 154;
            this.RProxy_CBOX.Text = "siticoneOSToggleSwith2";
            this.RProxy_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.RProxy_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneVSeparator32
            // 
            this.siticoneVSeparator32.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator32.FillThickness = 4;
            this.siticoneVSeparator32.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator32.Name = "siticoneVSeparator32";
            this.siticoneVSeparator32.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator32.TabIndex = 90;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel2.Controls.Add(this.iLabel4);
            this.panel2.Controls.Add(this.siticoneVSeparator3);
            this.panel2.Controls.Add(this.Flood_CBOX);
            this.panel2.Location = new System.Drawing.Point(10, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 50);
            this.panel2.TabIndex = 154;
            // 
            // iLabel4
            // 
            this.iLabel4.AutoSize = true;
            this.iLabel4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel4.ForeColor = System.Drawing.Color.White;
            this.iLabel4.Location = new System.Drawing.Point(67, 15);
            this.iLabel4.Name = "iLabel4";
            this.iLabel4.Size = new System.Drawing.Size(80, 19);
            this.iLabel4.TabIndex = 148;
            this.iLabel4.Text = "Flood Cctor";
            this.iLabel4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator3
            // 
            this.siticoneVSeparator3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator3.FillThickness = 4;
            this.siticoneVSeparator3.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator3.Name = "siticoneVSeparator3";
            this.siticoneVSeparator3.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator3.TabIndex = 131;
            // 
            // Flood_CBOX
            // 
            this.Flood_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.Flood_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Flood_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Flood_CBOX.Location = new System.Drawing.Point(21, 14);
            this.Flood_CBOX.Name = "Flood_CBOX";
            this.Flood_CBOX.Size = new System.Drawing.Size(38, 22);
            this.Flood_CBOX.TabIndex = 129;
            this.Flood_CBOX.Text = "siticoneOSToggleSwith1";
            this.Flood_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.Flood_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel1.Controls.Add(this.iLabel3);
            this.panel1.Controls.Add(this.siticoneVSeparator2);
            this.panel1.Controls.Add(this.HideMethods_cbox);
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 50);
            this.panel1.TabIndex = 153;
            // 
            // iLabel3
            // 
            this.iLabel3.AutoSize = true;
            this.iLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel3.ForeColor = System.Drawing.Color.White;
            this.iLabel3.Location = new System.Drawing.Point(67, 15);
            this.iLabel3.Name = "iLabel3";
            this.iLabel3.Size = new System.Drawing.Size(114, 19);
            this.iLabel3.TabIndex = 147;
            this.iLabel3.Text = "Encrypt Methods";
            this.iLabel3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator2
            // 
            this.siticoneVSeparator2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator2.FillThickness = 4;
            this.siticoneVSeparator2.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator2.Name = "siticoneVSeparator2";
            this.siticoneVSeparator2.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator2.TabIndex = 41;
            // 
            // HideMethods_cbox
            // 
            this.HideMethods_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.HideMethods_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.HideMethods_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HideMethods_cbox.Location = new System.Drawing.Point(21, 14);
            this.HideMethods_cbox.Name = "HideMethods_cbox";
            this.HideMethods_cbox.Size = new System.Drawing.Size(38, 22);
            this.HideMethods_cbox.TabIndex = 39;
            this.HideMethods_cbox.Text = "siticoneOSToggleSwith1";
            this.HideMethods_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.HideMethods_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.HideMethods_cbox.CheckedChanged += new System.EventHandler(this.fq);
            // 
            // Recommended
            // 
            this.Recommended.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Recommended.BorderThickness = 1;
            this.Recommended.CheckedState.Parent = this.Recommended;
            this.Recommended.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Recommended.CustomImages.Parent = this.Recommended;
            this.Recommended.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Recommended.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Recommended.ForeColor = System.Drawing.Color.White;
            this.Recommended.HoveredState.Parent = this.Recommended;
            this.Recommended.ImageSize = new System.Drawing.Size(24, 24);
            this.Recommended.Location = new System.Drawing.Point(350, 798);
            this.Recommended.Name = "Recommended";
            this.Recommended.ShadowDecoration.Parent = this.Recommended;
            this.Recommended.Size = new System.Drawing.Size(184, 40);
            this.Recommended.TabIndex = 152;
            this.Recommended.Text = "Recommended";
            this.Recommended.Click += new System.EventHandler(this.fE);
            // 
            // CheckAll_Button
            // 
            this.CheckAll_Button.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.CheckAll_Button.BorderThickness = 1;
            this.CheckAll_Button.CheckedState.Parent = this.CheckAll_Button;
            this.CheckAll_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckAll_Button.CustomImages.Parent = this.CheckAll_Button;
            this.CheckAll_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CheckAll_Button.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CheckAll_Button.ForeColor = System.Drawing.Color.White;
            this.CheckAll_Button.HoveredState.Parent = this.CheckAll_Button;
            this.CheckAll_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.CheckAll_Button.Location = new System.Drawing.Point(540, 798);
            this.CheckAll_Button.Name = "CheckAll_Button";
            this.CheckAll_Button.ShadowDecoration.Parent = this.CheckAll_Button;
            this.CheckAll_Button.Size = new System.Drawing.Size(128, 40);
            this.CheckAll_Button.TabIndex = 151;
            this.CheckAll_Button.Text = "Check all";
            this.CheckAll_Button.Click += new System.EventHandler(this.fo);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel14.Controls.Add(this.iLabel18);
            this.panel14.Controls.Add(this.siticoneVSeparator15);
            this.panel14.Controls.Add(this.L2F_cbox);
            this.panel14.Location = new System.Drawing.Point(10, 740);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(658, 50);
            this.panel14.TabIndex = 150;
            // 
            // iLabel18
            // 
            this.iLabel18.AutoSize = true;
            this.iLabel18.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel18.ForeColor = System.Drawing.Color.White;
            this.iLabel18.Location = new System.Drawing.Point(67, 15);
            this.iLabel18.Name = "iLabel18";
            this.iLabel18.Size = new System.Drawing.Size(90, 19);
            this.iLabel18.TabIndex = 162;
            this.iLabel18.Text = "Local To Field";
            this.iLabel18.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator15
            // 
            this.siticoneVSeparator15.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator15.FillThickness = 4;
            this.siticoneVSeparator15.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator15.Name = "siticoneVSeparator15";
            this.siticoneVSeparator15.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator15.TabIndex = 69;
            // 
            // L2F_cbox
            // 
            this.L2F_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.L2F_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.L2F_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L2F_cbox.Location = new System.Drawing.Point(21, 14);
            this.L2F_cbox.Name = "L2F_cbox";
            this.L2F_cbox.Size = new System.Drawing.Size(38, 22);
            this.L2F_cbox.TabIndex = 67;
            this.L2F_cbox.Text = "siticoneOSToggleSwith1";
            this.L2F_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.L2F_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel13.Controls.Add(this.ControlFlowStatus);
            this.panel13.Controls.Add(this.iLabel17);
            this.panel13.Controls.Add(this.Controlflow_CBOX);
            this.panel13.Controls.Add(this.siticoneVSeparator14);
            this.panel13.Controls.Add(this.ControlFlowSelection);
            this.panel13.Location = new System.Drawing.Point(10, 688);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(658, 50);
            this.panel13.TabIndex = 149;
            // 
            // ControlFlowStatus
            // 
            this.ControlFlowStatus.AutoSize = true;
            this.ControlFlowStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ControlFlowStatus.ForeColor = System.Drawing.Color.White;
            this.ControlFlowStatus.Location = new System.Drawing.Point(577, 14);
            this.ControlFlowStatus.Name = "ControlFlowStatus";
            this.ControlFlowStatus.Size = new System.Drawing.Size(42, 19);
            this.ControlFlowStatus.TabIndex = 162;
            this.ControlFlowStatus.Text = "None";
            this.ControlFlowStatus.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel17
            // 
            this.iLabel17.AutoSize = true;
            this.iLabel17.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel17.ForeColor = System.Drawing.Color.White;
            this.iLabel17.Location = new System.Drawing.Point(67, 15);
            this.iLabel17.Name = "iLabel17";
            this.iLabel17.Size = new System.Drawing.Size(87, 19);
            this.iLabel17.TabIndex = 161;
            this.iLabel17.Text = "Control Flow";
            this.iLabel17.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Controlflow_CBOX
            // 
            this.Controlflow_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.Controlflow_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Controlflow_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Controlflow_CBOX.Location = new System.Drawing.Point(21, 14);
            this.Controlflow_CBOX.Name = "Controlflow_CBOX";
            this.Controlflow_CBOX.Size = new System.Drawing.Size(38, 22);
            this.Controlflow_CBOX.TabIndex = 156;
            this.Controlflow_CBOX.Text = "siticoneOSToggleSwith3";
            this.Controlflow_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.Controlflow_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneVSeparator14
            // 
            this.siticoneVSeparator14.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator14.FillThickness = 4;
            this.siticoneVSeparator14.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator14.Name = "siticoneVSeparator14";
            this.siticoneVSeparator14.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator14.TabIndex = 93;
            // 
            // ControlFlowSelection
            // 
            this.ControlFlowSelection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ControlFlowSelection.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.ControlFlowSelection.HoveredState.Parent = this.ControlFlowSelection;
            this.ControlFlowSelection.Location = new System.Drawing.Point(458, 14);
            this.ControlFlowSelection.Maximum = 6;
            this.ControlFlowSelection.Name = "ControlFlowSelection";
            this.ControlFlowSelection.Size = new System.Drawing.Size(113, 23);
            this.ControlFlowSelection.TabIndex = 90;
            this.ControlFlowSelection.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.ControlFlowSelection.Value = 0;
            this.ControlFlowSelection.ValueChanged += new System.EventHandler(this.fi);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel12.Controls.Add(this.GoToMSettings);
            this.panel12.Controls.Add(this.iLabel16);
            this.panel12.Controls.Add(this.Mutation_CBOX);
            this.panel12.Controls.Add(this.siticoneVSeparator13);
            this.panel12.Location = new System.Drawing.Point(10, 532);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(658, 50);
            this.panel12.TabIndex = 148;
            // 
            // GoToMSettings
            // 
            this.GoToMSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.GoToMSettings.BorderThickness = 1;
            this.GoToMSettings.CheckedState.Parent = this.GoToMSettings;
            this.GoToMSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToMSettings.CustomImages.Parent = this.GoToMSettings;
            this.GoToMSettings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.GoToMSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GoToMSettings.ForeColor = System.Drawing.Color.White;
            this.GoToMSettings.HoveredState.Parent = this.GoToMSettings;
            this.GoToMSettings.ImageSize = new System.Drawing.Size(24, 24);
            this.GoToMSettings.Location = new System.Drawing.Point(551, 10);
            this.GoToMSettings.Name = "GoToMSettings";
            this.GoToMSettings.PressedColor = System.Drawing.Color.BlanchedAlmond;
            this.GoToMSettings.ShadowDecoration.Parent = this.GoToMSettings;
            this.GoToMSettings.Size = new System.Drawing.Size(97, 30);
            this.GoToMSettings.TabIndex = 162;
            this.GoToMSettings.Text = "Settings";
            this.GoToMSettings.Click += new System.EventHandler(this.fk);
            // 
            // iLabel16
            // 
            this.iLabel16.AutoSize = true;
            this.iLabel16.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel16.ForeColor = System.Drawing.Color.White;
            this.iLabel16.Location = new System.Drawing.Point(67, 15);
            this.iLabel16.Name = "iLabel16";
            this.iLabel16.Size = new System.Drawing.Size(132, 19);
            this.iLabel16.TabIndex = 160;
            this.iLabel16.Text = "Constants Mutation";
            this.iLabel16.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Mutation_CBOX
            // 
            this.Mutation_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.Mutation_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Mutation_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mutation_CBOX.Location = new System.Drawing.Point(21, 14);
            this.Mutation_CBOX.Name = "Mutation_CBOX";
            this.Mutation_CBOX.Size = new System.Drawing.Size(38, 22);
            this.Mutation_CBOX.TabIndex = 154;
            this.Mutation_CBOX.Text = "siticoneOSToggleSwith2";
            this.Mutation_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.Mutation_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneVSeparator13
            // 
            this.siticoneVSeparator13.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator13.FillThickness = 4;
            this.siticoneVSeparator13.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator13.Name = "siticoneVSeparator13";
            this.siticoneVSeparator13.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator13.TabIndex = 90;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel11.Controls.Add(this.iLabel15);
            this.panel11.Controls.Add(this.siticoneVSeparator12);
            this.panel11.Controls.Add(this.MathInts_cbox);
            this.panel11.Location = new System.Drawing.Point(10, 480);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(658, 50);
            this.panel11.TabIndex = 147;
            // 
            // iLabel15
            // 
            this.iLabel15.AutoSize = true;
            this.iLabel15.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel15.ForeColor = System.Drawing.Color.White;
            this.iLabel15.Location = new System.Drawing.Point(67, 15);
            this.iLabel15.Name = "iLabel15";
            this.iLabel15.Size = new System.Drawing.Size(63, 19);
            this.iLabel15.TabIndex = 159;
            this.iLabel15.Text = "Int Math";
            this.iLabel15.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator12
            // 
            this.siticoneVSeparator12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator12.FillThickness = 4;
            this.siticoneVSeparator12.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator12.Name = "siticoneVSeparator12";
            this.siticoneVSeparator12.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator12.TabIndex = 127;
            // 
            // MathInts_cbox
            // 
            this.MathInts_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.MathInts_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.MathInts_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MathInts_cbox.Location = new System.Drawing.Point(21, 14);
            this.MathInts_cbox.Name = "MathInts_cbox";
            this.MathInts_cbox.Size = new System.Drawing.Size(38, 22);
            this.MathInts_cbox.TabIndex = 125;
            this.MathInts_cbox.Text = "siticoneOSToggleSwith1";
            this.MathInts_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.MathInts_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel10.Controls.Add(this.GoToStrings);
            this.panel10.Controls.Add(this.iLabel14);
            this.panel10.Controls.Add(this.Strings_CBOX);
            this.panel10.Controls.Add(this.siticoneVSeparator11);
            this.panel10.Location = new System.Drawing.Point(10, 428);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(658, 50);
            this.panel10.TabIndex = 146;
            // 
            // GoToStrings
            // 
            this.GoToStrings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.GoToStrings.BorderThickness = 1;
            this.GoToStrings.CheckedState.Parent = this.GoToStrings;
            this.GoToStrings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToStrings.CustomImages.Parent = this.GoToStrings;
            this.GoToStrings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.GoToStrings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GoToStrings.ForeColor = System.Drawing.Color.White;
            this.GoToStrings.HoveredState.Parent = this.GoToStrings;
            this.GoToStrings.ImageSize = new System.Drawing.Size(24, 24);
            this.GoToStrings.Location = new System.Drawing.Point(551, 10);
            this.GoToStrings.Name = "GoToStrings";
            this.GoToStrings.PressedColor = System.Drawing.Color.BlanchedAlmond;
            this.GoToStrings.ShadowDecoration.Parent = this.GoToStrings;
            this.GoToStrings.Size = new System.Drawing.Size(97, 30);
            this.GoToStrings.TabIndex = 163;
            this.GoToStrings.Text = "Settings";
            this.GoToStrings.Click += new System.EventHandler(this.fl);
            // 
            // iLabel14
            // 
            this.iLabel14.AutoSize = true;
            this.iLabel14.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel14.ForeColor = System.Drawing.Color.White;
            this.iLabel14.Location = new System.Drawing.Point(67, 15);
            this.iLabel14.Name = "iLabel14";
            this.iLabel14.Size = new System.Drawing.Size(111, 19);
            this.iLabel14.TabIndex = 158;
            this.iLabel14.Text = "Strings Encoding";
            this.iLabel14.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Strings_CBOX
            // 
            this.Strings_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.Strings_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Strings_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Strings_CBOX.Location = new System.Drawing.Point(21, 14);
            this.Strings_CBOX.Name = "Strings_CBOX";
            this.Strings_CBOX.Size = new System.Drawing.Size(38, 22);
            this.Strings_CBOX.TabIndex = 152;
            this.Strings_CBOX.Text = "siticoneOSToggleSwith1";
            this.Strings_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.Strings_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneVSeparator11
            // 
            this.siticoneVSeparator11.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator11.FillThickness = 4;
            this.siticoneVSeparator11.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator11.Name = "siticoneVSeparator11";
            this.siticoneVSeparator11.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator11.TabIndex = 108;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel9.Controls.Add(this.JunkSettings);
            this.panel9.Controls.Add(this.iLabel12);
            this.panel9.Controls.Add(this.siticoneVSeparator10);
            this.panel9.Controls.Add(this.Junk_cbox);
            this.panel9.Location = new System.Drawing.Point(10, 376);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(658, 50);
            this.panel9.TabIndex = 145;
            // 
            // JunkSettings
            // 
            this.JunkSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.JunkSettings.BorderThickness = 1;
            this.JunkSettings.CheckedState.Parent = this.JunkSettings;
            this.JunkSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JunkSettings.CustomImages.Parent = this.JunkSettings;
            this.JunkSettings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.JunkSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.JunkSettings.ForeColor = System.Drawing.Color.White;
            this.JunkSettings.HoveredState.Parent = this.JunkSettings;
            this.JunkSettings.ImageSize = new System.Drawing.Size(24, 24);
            this.JunkSettings.Location = new System.Drawing.Point(551, 10);
            this.JunkSettings.Name = "JunkSettings";
            this.JunkSettings.PressedColor = System.Drawing.Color.BlanchedAlmond;
            this.JunkSettings.ShadowDecoration.Parent = this.JunkSettings;
            this.JunkSettings.Size = new System.Drawing.Size(97, 30);
            this.JunkSettings.TabIndex = 164;
            this.JunkSettings.Text = "Settings";
            this.JunkSettings.Click += new System.EventHandler(this.fw);
            // 
            // iLabel12
            // 
            this.iLabel12.AutoSize = true;
            this.iLabel12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel12.ForeColor = System.Drawing.Color.White;
            this.iLabel12.Location = new System.Drawing.Point(67, 15);
            this.iLabel12.Name = "iLabel12";
            this.iLabel12.Size = new System.Drawing.Size(78, 19);
            this.iLabel12.TabIndex = 158;
            this.iLabel12.Text = "Junk Adder";
            this.iLabel12.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator10
            // 
            this.siticoneVSeparator10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator10.FillThickness = 4;
            this.siticoneVSeparator10.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator10.Name = "siticoneVSeparator10";
            this.siticoneVSeparator10.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator10.TabIndex = 120;
            // 
            // Junk_cbox
            // 
            this.Junk_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.Junk_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Junk_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Junk_cbox.Location = new System.Drawing.Point(21, 14);
            this.Junk_cbox.Name = "Junk_cbox";
            this.Junk_cbox.Size = new System.Drawing.Size(38, 22);
            this.Junk_cbox.TabIndex = 118;
            this.Junk_cbox.Text = "siticoneOSToggleSwith1";
            this.Junk_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.Junk_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel8.Controls.Add(this.iLabel11);
            this.panel8.Controls.Add(this.siticoneVSeparator9);
            this.panel8.Controls.Add(this.AntiDebug_cbox);
            this.panel8.Location = new System.Drawing.Point(10, 324);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(658, 50);
            this.panel8.TabIndex = 144;
            // 
            // iLabel11
            // 
            this.iLabel11.AutoSize = true;
            this.iLabel11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel11.ForeColor = System.Drawing.Color.White;
            this.iLabel11.Location = new System.Drawing.Point(67, 15);
            this.iLabel11.Name = "iLabel11";
            this.iLabel11.Size = new System.Drawing.Size(79, 19);
            this.iLabel11.TabIndex = 158;
            this.iLabel11.Text = "Anti Debug";
            this.iLabel11.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator9
            // 
            this.siticoneVSeparator9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator9.FillThickness = 4;
            this.siticoneVSeparator9.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator9.Name = "siticoneVSeparator9";
            this.siticoneVSeparator9.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator9.TabIndex = 43;
            // 
            // AntiDebug_cbox
            // 
            this.AntiDebug_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.AntiDebug_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.AntiDebug_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AntiDebug_cbox.Location = new System.Drawing.Point(21, 14);
            this.AntiDebug_cbox.Name = "AntiDebug_cbox";
            this.AntiDebug_cbox.Size = new System.Drawing.Size(38, 22);
            this.AntiDebug_cbox.TabIndex = 41;
            this.AntiDebug_cbox.Text = "siticoneOSToggleSwith1";
            this.AntiDebug_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.AntiDebug_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel7.Controls.Add(this.iLabel10);
            this.panel7.Controls.Add(this.siticoneVSeparator8);
            this.panel7.Controls.Add(this.AntiHttp_cbox);
            this.panel7.Location = new System.Drawing.Point(10, 272);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(658, 50);
            this.panel7.TabIndex = 143;
            // 
            // iLabel10
            // 
            this.iLabel10.AutoSize = true;
            this.iLabel10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel10.ForeColor = System.Drawing.Color.White;
            this.iLabel10.Location = new System.Drawing.Point(67, 15);
            this.iLabel10.Name = "iLabel10";
            this.iLabel10.Size = new System.Drawing.Size(115, 19);
            this.iLabel10.TabIndex = 158;
            this.iLabel10.Text = "Anti HTTP Debug";
            this.iLabel10.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator8
            // 
            this.siticoneVSeparator8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator8.FillThickness = 4;
            this.siticoneVSeparator8.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator8.Name = "siticoneVSeparator8";
            this.siticoneVSeparator8.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator8.TabIndex = 105;
            // 
            // AntiHttp_cbox
            // 
            this.AntiHttp_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.AntiHttp_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.AntiHttp_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AntiHttp_cbox.Location = new System.Drawing.Point(21, 14);
            this.AntiHttp_cbox.Name = "AntiHttp_cbox";
            this.AntiHttp_cbox.Size = new System.Drawing.Size(38, 22);
            this.AntiHttp_cbox.TabIndex = 103;
            this.AntiHttp_cbox.Text = "siticoneOSToggleSwith1";
            this.AntiHttp_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.AntiHttp_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel6.Controls.Add(this.GoToACS);
            this.panel6.Controls.Add(this.iLabel8);
            this.panel6.Controls.Add(this.siticoneVSeparator7);
            this.panel6.Controls.Add(this.AntiCracker_cbox);
            this.panel6.Location = new System.Drawing.Point(10, 220);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(658, 50);
            this.panel6.TabIndex = 142;
            // 
            // GoToACS
            // 
            this.GoToACS.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.GoToACS.BorderThickness = 1;
            this.GoToACS.CheckedState.Parent = this.GoToACS;
            this.GoToACS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToACS.CustomImages.Parent = this.GoToACS;
            this.GoToACS.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.GoToACS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GoToACS.ForeColor = System.Drawing.Color.White;
            this.GoToACS.HoveredState.Parent = this.GoToACS;
            this.GoToACS.ImageSize = new System.Drawing.Size(24, 24);
            this.GoToACS.Location = new System.Drawing.Point(551, 10);
            this.GoToACS.Name = "GoToACS";
            this.GoToACS.PressedColor = System.Drawing.Color.BlanchedAlmond;
            this.GoToACS.ShadowDecoration.Parent = this.GoToACS;
            this.GoToACS.Size = new System.Drawing.Size(97, 30);
            this.GoToACS.TabIndex = 161;
            this.GoToACS.Text = "Settings";
            this.GoToACS.Click += new System.EventHandler(this.eU);
            // 
            // iLabel8
            // 
            this.iLabel8.AutoSize = true;
            this.iLabel8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel8.ForeColor = System.Drawing.Color.White;
            this.iLabel8.Location = new System.Drawing.Point(67, 15);
            this.iLabel8.Name = "iLabel8";
            this.iLabel8.Size = new System.Drawing.Size(72, 19);
            this.iLabel8.TabIndex = 157;
            this.iLabel8.Text = "Anti Crack";
            this.iLabel8.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator7
            // 
            this.siticoneVSeparator7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator7.FillThickness = 4;
            this.siticoneVSeparator7.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator7.Name = "siticoneVSeparator7";
            this.siticoneVSeparator7.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator7.TabIndex = 98;
            // 
            // AntiCracker_cbox
            // 
            this.AntiCracker_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.AntiCracker_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.AntiCracker_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AntiCracker_cbox.Location = new System.Drawing.Point(21, 14);
            this.AntiCracker_cbox.Name = "AntiCracker_cbox";
            this.AntiCracker_cbox.Size = new System.Drawing.Size(38, 22);
            this.AntiCracker_cbox.TabIndex = 96;
            this.AntiCracker_cbox.Text = "siticoneOSToggleSwith1";
            this.AntiCracker_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.AntiCracker_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel5.Controls.Add(this.iLabel7);
            this.panel5.Controls.Add(this.siticoneVSeparator6);
            this.panel5.Controls.Add(this.AntiVM_cbox);
            this.panel5.Location = new System.Drawing.Point(10, 168);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(658, 50);
            this.panel5.TabIndex = 141;
            // 
            // iLabel7
            // 
            this.iLabel7.AutoSize = true;
            this.iLabel7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel7.ForeColor = System.Drawing.Color.White;
            this.iLabel7.Location = new System.Drawing.Point(67, 15);
            this.iLabel7.Name = "iLabel7";
            this.iLabel7.Size = new System.Drawing.Size(134, 19);
            this.iLabel7.TabIndex = 150;
            this.iLabel7.Text = "Anti Virtual Machine";
            this.iLabel7.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator6
            // 
            this.siticoneVSeparator6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator6.FillThickness = 4;
            this.siticoneVSeparator6.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator6.Name = "siticoneVSeparator6";
            this.siticoneVSeparator6.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator6.TabIndex = 116;
            // 
            // AntiVM_cbox
            // 
            this.AntiVM_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.AntiVM_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.AntiVM_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AntiVM_cbox.Location = new System.Drawing.Point(21, 14);
            this.AntiVM_cbox.Name = "AntiVM_cbox";
            this.AntiVM_cbox.Size = new System.Drawing.Size(38, 22);
            this.AntiVM_cbox.TabIndex = 114;
            this.AntiVM_cbox.Text = "siticoneOSToggleSwith1";
            this.AntiVM_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.AntiVM_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel4.Controls.Add(this.iLabel5);
            this.panel4.Controls.Add(this.siticoneVSeparator5);
            this.panel4.Controls.Add(this.AntiDump_cbox);
            this.panel4.Location = new System.Drawing.Point(10, 116);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(658, 50);
            this.panel4.TabIndex = 140;
            // 
            // iLabel5
            // 
            this.iLabel5.AutoSize = true;
            this.iLabel5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel5.ForeColor = System.Drawing.Color.White;
            this.iLabel5.Location = new System.Drawing.Point(67, 15);
            this.iLabel5.Name = "iLabel5";
            this.iLabel5.Size = new System.Drawing.Size(76, 19);
            this.iLabel5.TabIndex = 149;
            this.iLabel5.Text = "Anti Dump";
            this.iLabel5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator5
            // 
            this.siticoneVSeparator5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator5.FillThickness = 4;
            this.siticoneVSeparator5.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator5.Name = "siticoneVSeparator5";
            this.siticoneVSeparator5.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator5.TabIndex = 74;
            // 
            // AntiDump_cbox
            // 
            this.AntiDump_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.AntiDump_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.AntiDump_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AntiDump_cbox.Location = new System.Drawing.Point(21, 14);
            this.AntiDump_cbox.Name = "AntiDump_cbox";
            this.AntiDump_cbox.Size = new System.Drawing.Size(38, 22);
            this.AntiDump_cbox.TabIndex = 72;
            this.AntiDump_cbox.Text = "siticoneOSToggleSwith1";
            this.AntiDump_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.AntiDump_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.AntiDump_cbox.CheckedChanged += new System.EventHandler(this.fr);
            // 
            // RenamerPage
            // 
            this.RenamerPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.RenamerPage.Controls.Add(this.panel16);
            this.RenamerPage.Controls.Add(this.panel15);
            this.RenamerPage.Location = new System.Drawing.Point(4, 22);
            this.RenamerPage.Name = "RenamerPage";
            this.RenamerPage.Padding = new System.Windows.Forms.Padding(3);
            this.RenamerPage.Size = new System.Drawing.Size(697, 311);
            this.RenamerPage.TabIndex = 6;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel16.Controls.Add(this.iLabel56);
            this.panel16.Controls.Add(this.SaveNameMap_CBOX);
            this.panel16.Controls.Add(this.iLabel28);
            this.panel16.Controls.Add(this.iLabel27);
            this.panel16.Controls.Add(this.iLabel26);
            this.panel16.Controls.Add(this.iLabel25);
            this.panel16.Controls.Add(this.iLabel24);
            this.panel16.Controls.Add(this.iLabel23);
            this.panel16.Controls.Add(this.iLabel22);
            this.panel16.Controls.Add(this.iLabel21);
            this.panel16.Controls.Add(this.iLabel20);
            this.panel16.Controls.Add(this.CodeAnalyzation_cbox);
            this.panel16.Controls.Add(this.HideNamespaces_Cbox);
            this.panel16.Controls.Add(this.rParam_cbox);
            this.panel16.Controls.Add(this.rEvents_cbox);
            this.panel16.Controls.Add(this.rFields_cbox);
            this.panel16.Controls.Add(this.rMethods_cbox);
            this.panel16.Controls.Add(this.rProperties_cbox);
            this.panel16.Controls.Add(this.rTypes_cbox);
            this.panel16.Controls.Add(this.siticoneVSeparator17);
            this.panel16.Location = new System.Drawing.Point(10, 64);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(676, 237);
            this.panel16.TabIndex = 155;
            // 
            // iLabel56
            // 
            this.iLabel56.AutoSize = true;
            this.iLabel56.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel56.ForeColor = System.Drawing.Color.White;
            this.iLabel56.Location = new System.Drawing.Point(197, 142);
            this.iLabel56.Name = "iLabel56";
            this.iLabel56.Size = new System.Drawing.Size(106, 19);
            this.iLabel56.TabIndex = 182;
            this.iLabel56.Text = "Save name map";
            this.iLabel56.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // SaveNameMap_CBOX
            // 
            this.SaveNameMap_CBOX.Checked = true;
            this.SaveNameMap_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.SaveNameMap_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.SaveNameMap_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveNameMap_CBOX.Location = new System.Drawing.Point(151, 141);
            this.SaveNameMap_CBOX.Name = "SaveNameMap_CBOX";
            this.SaveNameMap_CBOX.Size = new System.Drawing.Size(38, 22);
            this.SaveNameMap_CBOX.TabIndex = 181;
            this.SaveNameMap_CBOX.Text = "siticoneOSToggleSwith1";
            this.SaveNameMap_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.SaveNameMap_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // iLabel28
            // 
            this.iLabel28.AutoSize = true;
            this.iLabel28.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel28.ForeColor = System.Drawing.Color.White;
            this.iLabel28.Location = new System.Drawing.Point(198, 114);
            this.iLabel28.Name = "iLabel28";
            this.iLabel28.Size = new System.Drawing.Size(116, 19);
            this.iLabel28.TabIndex = 180;
            this.iLabel28.Text = "Code Analyzation";
            this.iLabel28.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel27
            // 
            this.iLabel27.AutoSize = true;
            this.iLabel27.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel27.ForeColor = System.Drawing.Color.White;
            this.iLabel27.Location = new System.Drawing.Point(197, 86);
            this.iLabel27.Name = "iLabel27";
            this.iLabel27.Size = new System.Drawing.Size(117, 19);
            this.iLabel27.TabIndex = 179;
            this.iLabel27.Text = "Hide Namespaces";
            this.iLabel27.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel26
            // 
            this.iLabel26.AutoSize = true;
            this.iLabel26.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel26.ForeColor = System.Drawing.Color.White;
            this.iLabel26.Location = new System.Drawing.Point(197, 60);
            this.iLabel26.Name = "iLabel26";
            this.iLabel26.Size = new System.Drawing.Size(78, 19);
            this.iLabel26.TabIndex = 178;
            this.iLabel26.Text = "Parameters";
            this.iLabel26.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel25
            // 
            this.iLabel25.AutoSize = true;
            this.iLabel25.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel25.ForeColor = System.Drawing.Color.White;
            this.iLabel25.Location = new System.Drawing.Point(67, 170);
            this.iLabel25.Name = "iLabel25";
            this.iLabel25.Size = new System.Drawing.Size(49, 19);
            this.iLabel25.TabIndex = 177;
            this.iLabel25.Text = "Events";
            this.iLabel25.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel24
            // 
            this.iLabel24.AutoSize = true;
            this.iLabel24.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel24.ForeColor = System.Drawing.Color.White;
            this.iLabel24.Location = new System.Drawing.Point(67, 142);
            this.iLabel24.Name = "iLabel24";
            this.iLabel24.Size = new System.Drawing.Size(43, 19);
            this.iLabel24.TabIndex = 176;
            this.iLabel24.Text = "Fields";
            this.iLabel24.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel23
            // 
            this.iLabel23.AutoSize = true;
            this.iLabel23.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel23.ForeColor = System.Drawing.Color.White;
            this.iLabel23.Location = new System.Drawing.Point(67, 114);
            this.iLabel23.Name = "iLabel23";
            this.iLabel23.Size = new System.Drawing.Size(64, 19);
            this.iLabel23.TabIndex = 175;
            this.iLabel23.Text = "Methods";
            this.iLabel23.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel22
            // 
            this.iLabel22.AutoSize = true;
            this.iLabel22.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel22.ForeColor = System.Drawing.Color.White;
            this.iLabel22.Location = new System.Drawing.Point(67, 86);
            this.iLabel22.Name = "iLabel22";
            this.iLabel22.Size = new System.Drawing.Size(71, 19);
            this.iLabel22.TabIndex = 174;
            this.iLabel22.Text = "Properties";
            this.iLabel22.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel21
            // 
            this.iLabel21.AutoSize = true;
            this.iLabel21.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel21.ForeColor = System.Drawing.Color.White;
            this.iLabel21.Location = new System.Drawing.Point(67, 58);
            this.iLabel21.Name = "iLabel21";
            this.iLabel21.Size = new System.Drawing.Size(43, 19);
            this.iLabel21.TabIndex = 173;
            this.iLabel21.Text = "Types";
            this.iLabel21.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel20
            // 
            this.iLabel20.AutoSize = true;
            this.iLabel20.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.iLabel20.ForeColor = System.Drawing.Color.White;
            this.iLabel20.Location = new System.Drawing.Point(13, 14);
            this.iLabel20.Name = "iLabel20";
            this.iLabel20.Size = new System.Drawing.Size(64, 20);
            this.iLabel20.TabIndex = 172;
            this.iLabel20.Text = "Options";
            this.iLabel20.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // CodeAnalyzation_cbox
            // 
            this.CodeAnalyzation_cbox.Checked = true;
            this.CodeAnalyzation_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.CodeAnalyzation_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.CodeAnalyzation_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CodeAnalyzation_cbox.Enabled = false;
            this.CodeAnalyzation_cbox.Location = new System.Drawing.Point(151, 113);
            this.CodeAnalyzation_cbox.Name = "CodeAnalyzation_cbox";
            this.CodeAnalyzation_cbox.Size = new System.Drawing.Size(38, 22);
            this.CodeAnalyzation_cbox.TabIndex = 170;
            this.CodeAnalyzation_cbox.Text = "siticoneOSToggleSwith1";
            this.CodeAnalyzation_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.CodeAnalyzation_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // HideNamespaces_Cbox
            // 
            this.HideNamespaces_Cbox.CheckedFillColor = System.Drawing.Color.White;
            this.HideNamespaces_Cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.HideNamespaces_Cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HideNamespaces_Cbox.Location = new System.Drawing.Point(151, 85);
            this.HideNamespaces_Cbox.Name = "HideNamespaces_Cbox";
            this.HideNamespaces_Cbox.Size = new System.Drawing.Size(38, 22);
            this.HideNamespaces_Cbox.TabIndex = 168;
            this.HideNamespaces_Cbox.Text = "siticoneOSToggleSwith1";
            this.HideNamespaces_Cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.HideNamespaces_Cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // rParam_cbox
            // 
            this.rParam_cbox.Checked = true;
            this.rParam_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.rParam_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.rParam_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rParam_cbox.Location = new System.Drawing.Point(151, 57);
            this.rParam_cbox.Name = "rParam_cbox";
            this.rParam_cbox.Size = new System.Drawing.Size(38, 22);
            this.rParam_cbox.TabIndex = 164;
            this.rParam_cbox.Text = "siticoneOSToggleSwith1";
            this.rParam_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.rParam_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // rEvents_cbox
            // 
            this.rEvents_cbox.Checked = true;
            this.rEvents_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.rEvents_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.rEvents_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rEvents_cbox.Location = new System.Drawing.Point(21, 169);
            this.rEvents_cbox.Name = "rEvents_cbox";
            this.rEvents_cbox.Size = new System.Drawing.Size(38, 22);
            this.rEvents_cbox.TabIndex = 162;
            this.rEvents_cbox.Text = "siticoneOSToggleSwith1";
            this.rEvents_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.rEvents_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // rFields_cbox
            // 
            this.rFields_cbox.Checked = true;
            this.rFields_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.rFields_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.rFields_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rFields_cbox.Location = new System.Drawing.Point(21, 141);
            this.rFields_cbox.Name = "rFields_cbox";
            this.rFields_cbox.Size = new System.Drawing.Size(38, 22);
            this.rFields_cbox.TabIndex = 160;
            this.rFields_cbox.Text = "siticoneOSToggleSwith1";
            this.rFields_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.rFields_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // rMethods_cbox
            // 
            this.rMethods_cbox.Checked = true;
            this.rMethods_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.rMethods_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.rMethods_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rMethods_cbox.Location = new System.Drawing.Point(21, 113);
            this.rMethods_cbox.Name = "rMethods_cbox";
            this.rMethods_cbox.Size = new System.Drawing.Size(38, 22);
            this.rMethods_cbox.TabIndex = 158;
            this.rMethods_cbox.Text = "siticoneOSToggleSwith1";
            this.rMethods_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.rMethods_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // rProperties_cbox
            // 
            this.rProperties_cbox.Checked = true;
            this.rProperties_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.rProperties_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.rProperties_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rProperties_cbox.Location = new System.Drawing.Point(21, 85);
            this.rProperties_cbox.Name = "rProperties_cbox";
            this.rProperties_cbox.Size = new System.Drawing.Size(38, 22);
            this.rProperties_cbox.TabIndex = 156;
            this.rProperties_cbox.Text = "siticoneOSToggleSwith1";
            this.rProperties_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.rProperties_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // rTypes_cbox
            // 
            this.rTypes_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.rTypes_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.rTypes_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rTypes_cbox.Location = new System.Drawing.Point(21, 57);
            this.rTypes_cbox.Name = "rTypes_cbox";
            this.rTypes_cbox.Size = new System.Drawing.Size(38, 22);
            this.rTypes_cbox.TabIndex = 154;
            this.rTypes_cbox.Text = "siticoneOSToggleSwith1";
            this.rTypes_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.rTypes_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneVSeparator17
            // 
            this.siticoneVSeparator17.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator17.FillThickness = 4;
            this.siticoneVSeparator17.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator17.Name = "siticoneVSeparator17";
            this.siticoneVSeparator17.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator17.TabIndex = 41;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel15.Controls.Add(this.iLabel19);
            this.panel15.Controls.Add(this.siticoneVSeparator16);
            this.panel15.Controls.Add(this.Renaming_cbox);
            this.panel15.Location = new System.Drawing.Point(10, 12);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(676, 50);
            this.panel15.TabIndex = 154;
            // 
            // iLabel19
            // 
            this.iLabel19.AutoSize = true;
            this.iLabel19.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel19.ForeColor = System.Drawing.Color.White;
            this.iLabel19.Location = new System.Drawing.Point(67, 15);
            this.iLabel19.Name = "iLabel19";
            this.iLabel19.Size = new System.Drawing.Size(148, 19);
            this.iLabel19.TabIndex = 147;
            this.iLabel19.Text = "Renaming Obfuscation";
            this.iLabel19.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator16
            // 
            this.siticoneVSeparator16.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator16.FillThickness = 4;
            this.siticoneVSeparator16.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator16.Name = "siticoneVSeparator16";
            this.siticoneVSeparator16.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator16.TabIndex = 41;
            // 
            // Renaming_cbox
            // 
            this.Renaming_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.Renaming_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Renaming_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Renaming_cbox.Location = new System.Drawing.Point(21, 14);
            this.Renaming_cbox.Name = "Renaming_cbox";
            this.Renaming_cbox.Size = new System.Drawing.Size(38, 22);
            this.Renaming_cbox.TabIndex = 118;
            this.Renaming_cbox.Text = "siticoneOSToggleSwith1";
            this.Renaming_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.Renaming_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // VirtualizationPage
            // 
            this.VirtualizationPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VirtualizationPage.Controls.Add(this.panel22);
            this.VirtualizationPage.Controls.Add(this.panel17);
            this.VirtualizationPage.Controls.Add(this.treeView1);
            this.VirtualizationPage.Location = new System.Drawing.Point(4, 22);
            this.VirtualizationPage.Name = "VirtualizationPage";
            this.VirtualizationPage.Size = new System.Drawing.Size(697, 311);
            this.VirtualizationPage.TabIndex = 2;
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel22.Controls.Add(this.SearchForMethod);
            this.panel22.Controls.Add(this.SMethodText);
            this.panel22.Controls.Add(this.iLabel60);
            this.panel22.Controls.Add(this.siticoneVSeparator41);
            this.panel22.Location = new System.Drawing.Point(10, 250);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(676, 50);
            this.panel22.TabIndex = 156;
            // 
            // SearchForMethod
            // 
            this.SearchForMethod.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.SearchForMethod.BorderThickness = 1;
            this.SearchForMethod.CheckedState.Parent = this.SearchForMethod;
            this.SearchForMethod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchForMethod.CustomImages.Parent = this.SearchForMethod;
            this.SearchForMethod.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.SearchForMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SearchForMethod.ForeColor = System.Drawing.Color.White;
            this.SearchForMethod.HoveredState.Parent = this.SearchForMethod;
            this.SearchForMethod.ImageSize = new System.Drawing.Size(24, 24);
            this.SearchForMethod.Location = new System.Drawing.Point(569, 10);
            this.SearchForMethod.Name = "SearchForMethod";
            this.SearchForMethod.PressedColor = System.Drawing.Color.BlanchedAlmond;
            this.SearchForMethod.ShadowDecoration.Parent = this.SearchForMethod;
            this.SearchForMethod.Size = new System.Drawing.Size(97, 30);
            this.SearchForMethod.TabIndex = 225;
            this.SearchForMethod.Text = "Search";
            this.SearchForMethod.Click += new System.EventHandler(this.fI);
            // 
            // SMethodText
            // 
            this.SMethodText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.SMethodText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SMethodText.DefaultText = "";
            this.SMethodText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SMethodText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SMethodText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SMethodText.DisabledState.Parent = this.SMethodText;
            this.SMethodText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SMethodText.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.SMethodText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.SMethodText.FocusedState.Parent = this.SMethodText;
            this.SMethodText.ForeColor = System.Drawing.Color.Silver;
            this.SMethodText.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.SMethodText.HoveredState.Parent = this.SMethodText;
            this.SMethodText.Location = new System.Drawing.Point(146, 10);
            this.SMethodText.Name = "SMethodText";
            this.SMethodText.PasswordChar = '\0';
            this.SMethodText.PlaceholderText = "";
            this.SMethodText.SelectedText = "";
            this.SMethodText.ShadowDecoration.Parent = this.SMethodText;
            this.SMethodText.Size = new System.Drawing.Size(416, 30);
            this.SMethodText.TabIndex = 224;
            this.SMethodText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // iLabel60
            // 
            this.iLabel60.AutoSize = true;
            this.iLabel60.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel60.ForeColor = System.Drawing.Color.White;
            this.iLabel60.Location = new System.Drawing.Point(11, 15);
            this.iLabel60.Name = "iLabel60";
            this.iLabel60.Size = new System.Drawing.Size(129, 19);
            this.iLabel60.TabIndex = 147;
            this.iLabel60.Text = "Search for method :";
            this.iLabel60.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator41
            // 
            this.siticoneVSeparator41.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator41.FillThickness = 4;
            this.siticoneVSeparator41.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator41.Name = "siticoneVSeparator41";
            this.siticoneVSeparator41.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator41.TabIndex = 41;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel17.Controls.Add(this.iLabel91);
            this.panel17.Controls.Add(this.VMAll);
            this.panel17.Controls.Add(this.iLabel29);
            this.panel17.Controls.Add(this.siticoneVSeparator18);
            this.panel17.Controls.Add(this.Virt_cbox);
            this.panel17.Location = new System.Drawing.Point(10, 12);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(676, 50);
            this.panel17.TabIndex = 155;
            // 
            // iLabel91
            // 
            this.iLabel91.AutoSize = true;
            this.iLabel91.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel91.ForeColor = System.Drawing.Color.White;
            this.iLabel91.Location = new System.Drawing.Point(536, 15);
            this.iLabel91.Name = "iLabel91";
            this.iLabel91.Size = new System.Drawing.Size(128, 19);
            this.iLabel91.TabIndex = 149;
            this.iLabel91.Text = "Protect all methods";
            this.iLabel91.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // VMAll
            // 
            this.VMAll.CheckedFillColor = System.Drawing.Color.White;
            this.VMAll.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.VMAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VMAll.Location = new System.Drawing.Point(490, 14);
            this.VMAll.Name = "VMAll";
            this.VMAll.Size = new System.Drawing.Size(38, 22);
            this.VMAll.TabIndex = 148;
            this.VMAll.Text = "siticoneOSToggleSwith1";
            this.VMAll.UncheckedFillColor = System.Drawing.Color.Black;
            this.VMAll.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.VMAll.CheckedChanged += new System.EventHandler(this.fJ);
            // 
            // iLabel29
            // 
            this.iLabel29.AutoSize = true;
            this.iLabel29.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel29.ForeColor = System.Drawing.Color.White;
            this.iLabel29.Location = new System.Drawing.Point(67, 15);
            this.iLabel29.Name = "iLabel29";
            this.iLabel29.Size = new System.Drawing.Size(147, 19);
            this.iLabel29.TabIndex = 147;
            this.iLabel29.Text = "Dynamic Methods VM";
            this.iLabel29.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator18
            // 
            this.siticoneVSeparator18.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator18.FillThickness = 4;
            this.siticoneVSeparator18.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator18.Name = "siticoneVSeparator18";
            this.siticoneVSeparator18.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator18.TabIndex = 41;
            // 
            // Virt_cbox
            // 
            this.Virt_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.Virt_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Virt_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Virt_cbox.Location = new System.Drawing.Point(21, 14);
            this.Virt_cbox.Name = "Virt_cbox";
            this.Virt_cbox.Size = new System.Drawing.Size(38, 22);
            this.Virt_cbox.TabIndex = 118;
            this.Virt_cbox.Text = "siticoneOSToggleSwith1";
            this.Virt_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.Virt_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Virt_cbox.CheckedChanged += new System.EventHandler(this.fs);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(10, 63);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(676, 186);
            this.treeView1.TabIndex = 45;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fM);
            this.treeView1.Click += new System.EventHandler(this.fG);
            this.treeView1.DoubleClick += new System.EventHandler(this.fL);
            this.treeView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fN);
            // 
            // CodeOptimizationPage
            // 
            this.CodeOptimizationPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CodeOptimizationPage.Controls.Add(this.panel20);
            this.CodeOptimizationPage.Controls.Add(this.panel19);
            this.CodeOptimizationPage.Controls.Add(this.panel18);
            this.CodeOptimizationPage.Location = new System.Drawing.Point(4, 22);
            this.CodeOptimizationPage.Name = "CodeOptimizationPage";
            this.CodeOptimizationPage.Size = new System.Drawing.Size(697, 311);
            this.CodeOptimizationPage.TabIndex = 4;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel20.Controls.Add(this.iLabel32);
            this.panel20.Controls.Add(this.siticoneVSeparator21);
            this.panel20.Controls.Add(this.ReduceMD_cbox);
            this.panel20.Location = new System.Drawing.Point(10, 116);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(676, 50);
            this.panel20.TabIndex = 157;
            // 
            // iLabel32
            // 
            this.iLabel32.AutoSize = true;
            this.iLabel32.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel32.ForeColor = System.Drawing.Color.White;
            this.iLabel32.Location = new System.Drawing.Point(67, 15);
            this.iLabel32.Name = "iLabel32";
            this.iLabel32.Size = new System.Drawing.Size(122, 19);
            this.iLabel32.TabIndex = 150;
            this.iLabel32.Text = "Reduce Meta Data";
            this.iLabel32.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator21
            // 
            this.siticoneVSeparator21.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator21.FillThickness = 4;
            this.siticoneVSeparator21.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator21.Name = "siticoneVSeparator21";
            this.siticoneVSeparator21.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator21.TabIndex = 41;
            // 
            // ReduceMD_cbox
            // 
            this.ReduceMD_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.ReduceMD_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.ReduceMD_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReduceMD_cbox.Location = new System.Drawing.Point(21, 14);
            this.ReduceMD_cbox.Name = "ReduceMD_cbox";
            this.ReduceMD_cbox.Size = new System.Drawing.Size(38, 22);
            this.ReduceMD_cbox.TabIndex = 118;
            this.ReduceMD_cbox.Text = "siticoneOSToggleSwith1";
            this.ReduceMD_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.ReduceMD_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel19.Controls.Add(this.iLabel31);
            this.panel19.Controls.Add(this.siticoneVSeparator20);
            this.panel19.Controls.Add(this.OptimizeMethods_cbox);
            this.panel19.Location = new System.Drawing.Point(10, 64);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(676, 50);
            this.panel19.TabIndex = 156;
            // 
            // iLabel31
            // 
            this.iLabel31.AutoSize = true;
            this.iLabel31.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel31.ForeColor = System.Drawing.Color.White;
            this.iLabel31.Location = new System.Drawing.Point(67, 15);
            this.iLabel31.Name = "iLabel31";
            this.iLabel31.Size = new System.Drawing.Size(123, 19);
            this.iLabel31.TabIndex = 149;
            this.iLabel31.Text = "Optimize Methods";
            this.iLabel31.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator20
            // 
            this.siticoneVSeparator20.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator20.FillThickness = 4;
            this.siticoneVSeparator20.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator20.Name = "siticoneVSeparator20";
            this.siticoneVSeparator20.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator20.TabIndex = 41;
            // 
            // OptimizeMethods_cbox
            // 
            this.OptimizeMethods_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.OptimizeMethods_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.OptimizeMethods_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OptimizeMethods_cbox.Location = new System.Drawing.Point(21, 14);
            this.OptimizeMethods_cbox.Name = "OptimizeMethods_cbox";
            this.OptimizeMethods_cbox.Size = new System.Drawing.Size(38, 22);
            this.OptimizeMethods_cbox.TabIndex = 118;
            this.OptimizeMethods_cbox.Text = "siticoneOSToggleSwith1";
            this.OptimizeMethods_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.OptimizeMethods_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel18.Controls.Add(this.iLabel30);
            this.panel18.Controls.Add(this.siticoneVSeparator19);
            this.panel18.Controls.Add(this.OptimizeCode_cbox);
            this.panel18.Location = new System.Drawing.Point(10, 12);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(676, 50);
            this.panel18.TabIndex = 155;
            // 
            // iLabel30
            // 
            this.iLabel30.AutoSize = true;
            this.iLabel30.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel30.ForeColor = System.Drawing.Color.White;
            this.iLabel30.Location = new System.Drawing.Point(67, 15);
            this.iLabel30.Name = "iLabel30";
            this.iLabel30.Size = new System.Drawing.Size(100, 19);
            this.iLabel30.TabIndex = 148;
            this.iLabel30.Text = "Optimize Code";
            this.iLabel30.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator19
            // 
            this.siticoneVSeparator19.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator19.FillThickness = 4;
            this.siticoneVSeparator19.Location = new System.Drawing.Point(-3, 10);
            this.siticoneVSeparator19.Name = "siticoneVSeparator19";
            this.siticoneVSeparator19.Size = new System.Drawing.Size(10, 30);
            this.siticoneVSeparator19.TabIndex = 41;
            // 
            // OptimizeCode_cbox
            // 
            this.OptimizeCode_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.OptimizeCode_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.OptimizeCode_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OptimizeCode_cbox.Location = new System.Drawing.Point(21, 14);
            this.OptimizeCode_cbox.Name = "OptimizeCode_cbox";
            this.OptimizeCode_cbox.Size = new System.Drawing.Size(38, 22);
            this.OptimizeCode_cbox.TabIndex = 118;
            this.OptimizeCode_cbox.Text = "siticoneOSToggleSwith1";
            this.OptimizeCode_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.OptimizeCode_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // LogPage
            // 
            this.LogPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.LogPage.Controls.Add(this.LogText);
            this.LogPage.Controls.Add(this.siticoneVSeparator4);
            this.LogPage.Controls.Add(this.iLabel45);
            this.LogPage.Location = new System.Drawing.Point(4, 22);
            this.LogPage.Name = "LogPage";
            this.LogPage.Size = new System.Drawing.Size(697, 311);
            this.LogPage.TabIndex = 3;
            // 
            // LogText
            // 
            this.LogText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.LogText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogText.ForeColor = System.Drawing.Color.White;
            this.LogText.Location = new System.Drawing.Point(50, 72);
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogText.Size = new System.Drawing.Size(590, 208);
            this.LogText.TabIndex = 175;
            this.LogText.TabStop = false;
            // 
            // siticoneVSeparator4
            // 
            this.siticoneVSeparator4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator4.FillThickness = 4;
            this.siticoneVSeparator4.Location = new System.Drawing.Point(34, 74);
            this.siticoneVSeparator4.Name = "siticoneVSeparator4";
            this.siticoneVSeparator4.Size = new System.Drawing.Size(10, 204);
            this.siticoneVSeparator4.TabIndex = 174;
            // 
            // iLabel45
            // 
            this.iLabel45.AutoSize = true;
            this.iLabel45.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel45.ForeColor = System.Drawing.Color.White;
            this.iLabel45.Location = new System.Drawing.Point(28, 20);
            this.iLabel45.Name = "iLabel45";
            this.iLabel45.Size = new System.Drawing.Size(247, 32);
            this.iLabel45.TabIndex = 176;
            this.iLabel45.Text = "Obfuscation process";
            this.iLabel45.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // HelpPage
            // 
            this.HelpPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.HelpPage.Controls.Add(this.iLabel34);
            this.HelpPage.Controls.Add(this.siticoneVSeparator28);
            this.HelpPage.Controls.Add(this.DiscordServer);
            this.HelpPage.Controls.Add(this.iLabel33);
            this.HelpPage.Location = new System.Drawing.Point(4, 22);
            this.HelpPage.Name = "HelpPage";
            this.HelpPage.Padding = new System.Windows.Forms.Padding(3);
            this.HelpPage.Size = new System.Drawing.Size(697, 311);
            this.HelpPage.TabIndex = 5;
            // 
            // iLabel34
            // 
            this.iLabel34.AutoSize = true;
            this.iLabel34.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel34.ForeColor = System.Drawing.Color.White;
            this.iLabel34.Location = new System.Drawing.Point(46, 72);
            this.iLabel34.Name = "iLabel34";
            this.iLabel34.Size = new System.Drawing.Size(228, 38);
            this.iLabel34.TabIndex = 164;
            this.iLabel34.Text = "If you want to report a bug !\r\nYou can contact with me via discord";
            this.iLabel34.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator28
            // 
            this.siticoneVSeparator28.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator28.FillThickness = 4;
            this.siticoneVSeparator28.Location = new System.Drawing.Point(34, 74);
            this.siticoneVSeparator28.Name = "siticoneVSeparator28";
            this.siticoneVSeparator28.Size = new System.Drawing.Size(10, 37);
            this.siticoneVSeparator28.TabIndex = 161;
            // 
            // DiscordServer
            // 
            this.DiscordServer.CheckedState.Parent = this.DiscordServer;
            this.DiscordServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DiscordServer.HoveredState.ImageSize = new System.Drawing.Size(95, 95);
            this.DiscordServer.HoveredState.Parent = this.DiscordServer;
            this.DiscordServer.ImageSize = new System.Drawing.Size(96, 96);
            this.DiscordServer.Location = new System.Drawing.Point(50, 126);
            this.DiscordServer.Name = "DiscordServer";
            this.DiscordServer.PressedState.ImageSize = new System.Drawing.Size(94, 94);
            this.DiscordServer.PressedState.Parent = this.DiscordServer;
            this.DiscordServer.Size = new System.Drawing.Size(96, 96);
            this.DiscordServer.TabIndex = 4;
            this.DiscordServer.Click += new System.EventHandler(this.eP);
            // 
            // iLabel33
            // 
            this.iLabel33.AutoSize = true;
            this.iLabel33.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel33.ForeColor = System.Drawing.Color.White;
            this.iLabel33.Location = new System.Drawing.Point(28, 20);
            this.iLabel33.Name = "iLabel33";
            this.iLabel33.Size = new System.Drawing.Size(213, 32);
            this.iLabel33.TabIndex = 163;
            this.iLabel33.Text = "Have a problem ?";
            this.iLabel33.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // CreditsPage
            // 
            this.CreditsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CreditsPage.Controls.Add(this.iLabel89);
            this.CreditsPage.Controls.Add(this.iLabel90);
            this.CreditsPage.Controls.Add(this.siticoneVSeparator40);
            this.CreditsPage.Controls.Add(this.siticoneVSeparator25);
            this.CreditsPage.Controls.Add(this.siticoneVSeparator24);
            this.CreditsPage.Controls.Add(this.siticoneVSeparator23);
            this.CreditsPage.Controls.Add(this.siticoneVSeparator22);
            this.CreditsPage.Controls.Add(this.iLabel50);
            this.CreditsPage.Controls.Add(this.iLabel49);
            this.CreditsPage.Controls.Add(this.iLabel40);
            this.CreditsPage.Controls.Add(this.iLabel39);
            this.CreditsPage.Controls.Add(this.iLabel37);
            this.CreditsPage.Controls.Add(this.iLabel36);
            this.CreditsPage.Controls.Add(this.iLabel35);
            this.CreditsPage.Controls.Add(this.iLabel38);
            this.CreditsPage.Location = new System.Drawing.Point(4, 22);
            this.CreditsPage.Name = "CreditsPage";
            this.CreditsPage.Padding = new System.Windows.Forms.Padding(3);
            this.CreditsPage.Size = new System.Drawing.Size(697, 311);
            this.CreditsPage.TabIndex = 7;
            // 
            // iLabel89
            // 
            this.iLabel89.AutoSize = true;
            this.iLabel89.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel89.ForeColor = System.Drawing.Color.White;
            this.iLabel89.Location = new System.Drawing.Point(50, 164);
            this.iLabel89.Name = "iLabel89";
            this.iLabel89.Size = new System.Drawing.Size(265, 19);
            this.iLabel89.TabIndex = 178;
            this.iLabel89.Tag = "";
            this.iLabel89.Text = "For helping me with methods encryption .";
            this.iLabel89.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel90
            // 
            this.iLabel90.AutoSize = true;
            this.iLabel90.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.iLabel90.ForeColor = System.Drawing.Color.White;
            this.iLabel90.Location = new System.Drawing.Point(50, 145);
            this.iLabel90.Name = "iLabel90";
            this.iLabel90.Size = new System.Drawing.Size(91, 19);
            this.iLabel90.TabIndex = 177;
            this.iLabel90.Text = "0x29A#5107";
            this.iLabel90.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // siticoneVSeparator40
            // 
            this.siticoneVSeparator40.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator40.FillThickness = 4;
            this.siticoneVSeparator40.Location = new System.Drawing.Point(34, 146);
            this.siticoneVSeparator40.Name = "siticoneVSeparator40";
            this.siticoneVSeparator40.Size = new System.Drawing.Size(10, 37);
            this.siticoneVSeparator40.TabIndex = 176;
            // 
            // siticoneVSeparator25
            // 
            this.siticoneVSeparator25.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator25.FillThickness = 4;
            this.siticoneVSeparator25.Location = new System.Drawing.Point(34, 263);
            this.siticoneVSeparator25.Name = "siticoneVSeparator25";
            this.siticoneVSeparator25.Size = new System.Drawing.Size(10, 22);
            this.siticoneVSeparator25.TabIndex = 167;
            // 
            // siticoneVSeparator24
            // 
            this.siticoneVSeparator24.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator24.FillThickness = 4;
            this.siticoneVSeparator24.Location = new System.Drawing.Point(34, 239);
            this.siticoneVSeparator24.Name = "siticoneVSeparator24";
            this.siticoneVSeparator24.Size = new System.Drawing.Size(10, 22);
            this.siticoneVSeparator24.TabIndex = 165;
            // 
            // siticoneVSeparator23
            // 
            this.siticoneVSeparator23.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator23.FillThickness = 4;
            this.siticoneVSeparator23.Location = new System.Drawing.Point(34, 107);
            this.siticoneVSeparator23.Name = "siticoneVSeparator23";
            this.siticoneVSeparator23.Size = new System.Drawing.Size(10, 37);
            this.siticoneVSeparator23.TabIndex = 161;
            // 
            // siticoneVSeparator22
            // 
            this.siticoneVSeparator22.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator22.FillThickness = 4;
            this.siticoneVSeparator22.Location = new System.Drawing.Point(34, 68);
            this.siticoneVSeparator22.Name = "siticoneVSeparator22";
            this.siticoneVSeparator22.Size = new System.Drawing.Size(10, 37);
            this.siticoneVSeparator22.TabIndex = 158;
            // 
            // iLabel50
            // 
            this.iLabel50.AutoSize = true;
            this.iLabel50.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel50.ForeColor = System.Drawing.Color.White;
            this.iLabel50.Location = new System.Drawing.Point(50, 125);
            this.iLabel50.Name = "iLabel50";
            this.iLabel50.Size = new System.Drawing.Size(381, 19);
            this.iLabel50.TabIndex = 175;
            this.iLabel50.Tag = "";
            this.iLabel50.Text = "For helping me with methods selection in dynamic methods .";
            this.iLabel50.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel49
            // 
            this.iLabel49.AutoSize = true;
            this.iLabel49.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel49.ForeColor = System.Drawing.Color.White;
            this.iLabel49.Location = new System.Drawing.Point(50, 86);
            this.iLabel49.Name = "iLabel49";
            this.iLabel49.Size = new System.Drawing.Size(471, 19);
            this.iLabel49.TabIndex = 174;
            this.iLabel49.Text = "For helping me with renaming schemes, generation and vb.net analyzation .";
            this.iLabel49.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel40
            // 
            this.iLabel40.AutoSize = true;
            this.iLabel40.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.iLabel40.ForeColor = System.Drawing.Color.White;
            this.iLabel40.Location = new System.Drawing.Point(50, 264);
            this.iLabel40.Name = "iLabel40";
            this.iLabel40.Size = new System.Drawing.Size(51, 19);
            this.iLabel40.TabIndex = 173;
            this.iLabel40.Text = "Icons8";
            this.iLabel40.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel39
            // 
            this.iLabel39.AutoSize = true;
            this.iLabel39.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.iLabel39.ForeColor = System.Drawing.Color.White;
            this.iLabel39.Location = new System.Drawing.Point(50, 240);
            this.iLabel39.Name = "iLabel39";
            this.iLabel39.Size = new System.Drawing.Size(80, 19);
            this.iLabel39.TabIndex = 172;
            this.iLabel39.Text = "Siticone UI";
            this.iLabel39.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel37
            // 
            this.iLabel37.AutoSize = true;
            this.iLabel37.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.iLabel37.ForeColor = System.Drawing.Color.White;
            this.iLabel37.Location = new System.Drawing.Point(50, 105);
            this.iLabel37.Name = "iLabel37";
            this.iLabel37.Size = new System.Drawing.Size(90, 19);
            this.iLabel37.TabIndex = 170;
            this.iLabel37.Text = "0x58B#5958";
            this.iLabel37.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel36
            // 
            this.iLabel36.AutoSize = true;
            this.iLabel36.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.iLabel36.ForeColor = System.Drawing.Color.White;
            this.iLabel36.Location = new System.Drawing.Point(50, 66);
            this.iLabel36.Name = "iLabel36";
            this.iLabel36.Size = new System.Drawing.Size(168, 19);
            this.iLabel36.TabIndex = 169;
            this.iLabel36.Text = "HatersGonnaHate#4497";
            this.iLabel36.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel35
            // 
            this.iLabel35.AutoSize = true;
            this.iLabel35.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel35.ForeColor = System.Drawing.Color.White;
            this.iLabel35.Location = new System.Drawing.Point(28, 20);
            this.iLabel35.Name = "iLabel35";
            this.iLabel35.Size = new System.Drawing.Size(207, 32);
            this.iLabel35.TabIndex = 168;
            this.iLabel35.Text = "Special thanks to";
            this.iLabel35.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel38
            // 
            this.iLabel38.AutoSize = true;
            this.iLabel38.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel38.ForeColor = System.Drawing.Color.White;
            this.iLabel38.Location = new System.Drawing.Point(28, 194);
            this.iLabel38.Name = "iLabel38";
            this.iLabel38.Size = new System.Drawing.Size(182, 32);
            this.iLabel38.TabIndex = 171;
            this.iLabel38.Text = "Icons / Images";
            this.iLabel38.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // GuidePage
            // 
            this.GuidePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.GuidePage.Controls.Add(this.iLabel43);
            this.GuidePage.Controls.Add(this.textBox2);
            this.GuidePage.Controls.Add(this.siticoneVSeparator27);
            this.GuidePage.Controls.Add(this.iLabel41);
            this.GuidePage.Location = new System.Drawing.Point(4, 22);
            this.GuidePage.Name = "GuidePage";
            this.GuidePage.Padding = new System.Windows.Forms.Padding(3);
            this.GuidePage.Size = new System.Drawing.Size(697, 311);
            this.GuidePage.TabIndex = 8;
            // 
            // iLabel43
            // 
            this.iLabel43.AutoSize = true;
            this.iLabel43.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iLabel43.ForeColor = System.Drawing.Color.White;
            this.iLabel43.Location = new System.Drawing.Point(50, 72);
            this.iLabel43.Name = "iLabel43";
            this.iLabel43.Size = new System.Drawing.Size(145, 17);
            this.iLabel43.TabIndex = 174;
            this.iLabel43.Text = "Dyanmic Methods VM";
            this.iLabel43.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(52, 96);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(592, 34);
            this.textBox2.TabIndex = 167;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "You can select methods from list by double right mouse click or pressing enter on" +
    " desired method .\r\nMake sure to use dynamic method vm after selecting your desir" +
    "ed protections !";
            // 
            // siticoneVSeparator27
            // 
            this.siticoneVSeparator27.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator27.FillThickness = 4;
            this.siticoneVSeparator27.Location = new System.Drawing.Point(34, 74);
            this.siticoneVSeparator27.Name = "siticoneVSeparator27";
            this.siticoneVSeparator27.Size = new System.Drawing.Size(10, 52);
            this.siticoneVSeparator27.TabIndex = 165;
            // 
            // iLabel41
            // 
            this.iLabel41.AutoSize = true;
            this.iLabel41.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel41.ForeColor = System.Drawing.Color.White;
            this.iLabel41.Location = new System.Drawing.Point(28, 20);
            this.iLabel41.Name = "iLabel41";
            this.iLabel41.Size = new System.Drawing.Size(378, 32);
            this.iLabel41.TabIndex = 169;
            this.iLabel41.Text = "Guide for dyanmic methods VM";
            this.iLabel41.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // AntiCrackSettings
            // 
            this.AntiCrackSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.AntiCrackSettings.Controls.Add(this.siticoneOSToggleSwith1);
            this.AntiCrackSettings.Controls.Add(this.UnBanBtn);
            this.AntiCrackSettings.Controls.Add(this.addP);
            this.AntiCrackSettings.Controls.Add(this.pname);
            this.AntiCrackSettings.Controls.Add(this.BackToProtections);
            this.AntiCrackSettings.Controls.Add(this.BanCracker_CBOX);
            this.AntiCrackSettings.Controls.Add(this.siticoneVSeparator29);
            this.AntiCrackSettings.Controls.Add(this.PasteWHLink);
            this.AntiCrackSettings.Controls.Add(this.SendToWH_cbox);
            this.AntiCrackSettings.Controls.Add(this.iLabel94);
            this.AntiCrackSettings.Controls.Add(this.iLabel63);
            this.AntiCrackSettings.Controls.Add(this.iLabel48);
            this.AntiCrackSettings.Controls.Add(this.iLabel47);
            this.AntiCrackSettings.Controls.Add(this.LinkStatus);
            this.AntiCrackSettings.Controls.Add(this.iLabel46);
            this.AntiCrackSettings.Controls.Add(this.iLabel44);
            this.AntiCrackSettings.Controls.Add(this.iLabel9);
            this.AntiCrackSettings.Location = new System.Drawing.Point(4, 22);
            this.AntiCrackSettings.Name = "AntiCrackSettings";
            this.AntiCrackSettings.Padding = new System.Windows.Forms.Padding(3);
            this.AntiCrackSettings.Size = new System.Drawing.Size(697, 311);
            this.AntiCrackSettings.TabIndex = 9;
            // 
            // siticoneOSToggleSwith1
            // 
            this.siticoneOSToggleSwith1.CheckedFillColor = System.Drawing.Color.White;
            this.siticoneOSToggleSwith1.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneOSToggleSwith1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneOSToggleSwith1.Location = new System.Drawing.Point(80, 179);
            this.siticoneOSToggleSwith1.Name = "siticoneOSToggleSwith1";
            this.siticoneOSToggleSwith1.Size = new System.Drawing.Size(38, 22);
            this.siticoneOSToggleSwith1.TabIndex = 183;
            this.siticoneOSToggleSwith1.Text = "siticoneOSToggleSwith1";
            this.siticoneOSToggleSwith1.UncheckedFillColor = System.Drawing.Color.Black;
            this.siticoneOSToggleSwith1.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // UnBanBtn
            // 
            this.UnBanBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.UnBanBtn.BorderThickness = 1;
            this.UnBanBtn.CheckedState.Parent = this.UnBanBtn;
            this.UnBanBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UnBanBtn.CustomImages.Parent = this.UnBanBtn;
            this.UnBanBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.UnBanBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.UnBanBtn.ForeColor = System.Drawing.Color.White;
            this.UnBanBtn.HoveredState.Parent = this.UnBanBtn;
            this.UnBanBtn.ImageSize = new System.Drawing.Size(24, 24);
            this.UnBanBtn.Location = new System.Drawing.Point(64, 234);
            this.UnBanBtn.Name = "UnBanBtn";
            this.UnBanBtn.PressedColor = System.Drawing.Color.BlanchedAlmond;
            this.UnBanBtn.ShadowDecoration.Parent = this.UnBanBtn;
            this.UnBanBtn.Size = new System.Drawing.Size(128, 43);
            this.UnBanBtn.TabIndex = 181;
            this.UnBanBtn.Text = "Unban me";
            this.UnBanBtn.Click += new System.EventHandler(this.fv);
            // 
            // addP
            // 
            this.addP.CheckedState.Parent = this.addP;
            this.addP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addP.HoveredState.ImageSize = new System.Drawing.Size(29, 29);
            this.addP.HoveredState.Parent = this.addP;
            this.addP.ImageSize = new System.Drawing.Size(30, 30);
            this.addP.Location = new System.Drawing.Point(574, 49);
            this.addP.Name = "addP";
            this.addP.PressedState.ImageSize = new System.Drawing.Size(28, 28);
            this.addP.PressedState.Parent = this.addP;
            this.addP.Size = new System.Drawing.Size(30, 30);
            this.addP.TabIndex = 179;
            this.addP.Visible = false;
            this.addP.Click += new System.EventHandler(this.fO);
            // 
            // pname
            // 
            this.pname.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.pname.BorderRadius = 1;
            this.pname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pname.DefaultText = "";
            this.pname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.pname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pname.DisabledState.Parent = this.pname;
            this.pname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pname.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pname.FocusedState.Parent = this.pname;
            this.pname.ForeColor = System.Drawing.Color.White;
            this.pname.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pname.HoveredState.Parent = this.pname;
            this.pname.Location = new System.Drawing.Point(397, 46);
            this.pname.Name = "pname";
            this.pname.PasswordChar = '\0';
            this.pname.PlaceholderText = "";
            this.pname.SelectedText = "";
            this.pname.ShadowDecoration.Parent = this.pname;
            this.pname.Size = new System.Drawing.Size(171, 36);
            this.pname.TabIndex = 178;
            this.pname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pname.Visible = false;
            // 
            // BackToProtections
            // 
            this.BackToProtections.CheckedState.Parent = this.BackToProtections;
            this.BackToProtections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackToProtections.HoveredState.ImageSize = new System.Drawing.Size(49, 49);
            this.BackToProtections.HoveredState.Parent = this.BackToProtections;
            this.BackToProtections.ImageSize = new System.Drawing.Size(50, 50);
            this.BackToProtections.Location = new System.Drawing.Point(636, 250);
            this.BackToProtections.Name = "BackToProtections";
            this.BackToProtections.PressedState.ImageSize = new System.Drawing.Size(48, 48);
            this.BackToProtections.PressedState.Parent = this.BackToProtections;
            this.BackToProtections.Size = new System.Drawing.Size(50, 50);
            this.BackToProtections.TabIndex = 174;
            this.BackToProtections.Click += new System.EventHandler(this.eT);
            // 
            // BanCracker_CBOX
            // 
            this.BanCracker_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.BanCracker_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.BanCracker_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BanCracker_CBOX.Location = new System.Drawing.Point(80, 151);
            this.BanCracker_CBOX.Name = "BanCracker_CBOX";
            this.BanCracker_CBOX.Size = new System.Drawing.Size(38, 22);
            this.BanCracker_CBOX.TabIndex = 172;
            this.BanCracker_CBOX.Text = "siticoneOSToggleSwith1";
            this.BanCracker_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.BanCracker_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneVSeparator29
            // 
            this.siticoneVSeparator29.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator29.FillThickness = 4;
            this.siticoneVSeparator29.Location = new System.Drawing.Point(64, 74);
            this.siticoneVSeparator29.Name = "siticoneVSeparator29";
            this.siticoneVSeparator29.Size = new System.Drawing.Size(10, 128);
            this.siticoneVSeparator29.TabIndex = 171;
            // 
            // PasteWHLink
            // 
            this.PasteWHLink.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.PasteWHLink.BorderThickness = 1;
            this.PasteWHLink.CheckedState.Parent = this.PasteWHLink;
            this.PasteWHLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PasteWHLink.CustomImages.Parent = this.PasteWHLink;
            this.PasteWHLink.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.PasteWHLink.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PasteWHLink.ForeColor = System.Drawing.Color.White;
            this.PasteWHLink.HoveredState.Parent = this.PasteWHLink;
            this.PasteWHLink.ImageSize = new System.Drawing.Size(24, 24);
            this.PasteWHLink.Location = new System.Drawing.Point(80, 104);
            this.PasteWHLink.Name = "PasteWHLink";
            this.PasteWHLink.PressedColor = System.Drawing.Color.BlanchedAlmond;
            this.PasteWHLink.ShadowDecoration.Parent = this.PasteWHLink;
            this.PasteWHLink.Size = new System.Drawing.Size(280, 40);
            this.PasteWHLink.TabIndex = 160;
            this.PasteWHLink.Text = "Paste Discord WebHook Link";
            this.PasteWHLink.Click += new System.EventHandler(this.fu);
            // 
            // SendToWH_cbox
            // 
            this.SendToWH_cbox.CheckedFillColor = System.Drawing.Color.White;
            this.SendToWH_cbox.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.SendToWH_cbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendToWH_cbox.Location = new System.Drawing.Point(80, 76);
            this.SendToWH_cbox.Name = "SendToWH_cbox";
            this.SendToWH_cbox.Size = new System.Drawing.Size(38, 22);
            this.SendToWH_cbox.TabIndex = 159;
            this.SendToWH_cbox.Text = "siticoneOSToggleSwith1";
            this.SendToWH_cbox.UncheckedFillColor = System.Drawing.Color.Black;
            this.SendToWH_cbox.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.SendToWH_cbox.CheckedChanged += new System.EventHandler(this.ft);
            // 
            // iLabel94
            // 
            this.iLabel94.AutoSize = true;
            this.iLabel94.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel94.ForeColor = System.Drawing.Color.White;
            this.iLabel94.Location = new System.Drawing.Point(124, 180);
            this.iLabel94.Name = "iLabel94";
            this.iLabel94.Size = new System.Drawing.Size(334, 19);
            this.iLabel94.TabIndex = 184;
            this.iLabel94.Text = "Send screenshot from cracker pc to Discord webhook";
            this.iLabel94.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel63
            // 
            this.iLabel63.AutoSize = true;
            this.iLabel63.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel63.ForeColor = System.Drawing.Color.White;
            this.iLabel63.Location = new System.Drawing.Point(199, 244);
            this.iLabel63.Name = "iLabel63";
            this.iLabel63.Size = new System.Drawing.Size(21, 19);
            this.iLabel63.TabIndex = 182;
            this.iLabel63.Text = "....";
            this.iLabel63.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel48
            // 
            this.iLabel48.AutoSize = true;
            this.iLabel48.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel48.ForeColor = System.Drawing.Color.White;
            this.iLabel48.Location = new System.Drawing.Point(656, 60);
            this.iLabel48.Name = "iLabel48";
            this.iLabel48.Size = new System.Drawing.Size(0, 19);
            this.iLabel48.TabIndex = 180;
            this.iLabel48.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.iLabel48.Visible = false;
            // 
            // iLabel47
            // 
            this.iLabel47.AutoSize = true;
            this.iLabel47.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel47.ForeColor = System.Drawing.Color.White;
            this.iLabel47.Location = new System.Drawing.Point(390, 20);
            this.iLabel47.Name = "iLabel47";
            this.iLabel47.Size = new System.Drawing.Size(296, 19);
            this.iLabel47.TabIndex = 177;
            this.iLabel47.Text = "Process detection, add process to be detected .";
            this.iLabel47.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.iLabel47.Visible = false;
            // 
            // LinkStatus
            // 
            this.LinkStatus.AutoSize = true;
            this.LinkStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LinkStatus.ForeColor = System.Drawing.Color.White;
            this.LinkStatus.Location = new System.Drawing.Point(379, 112);
            this.LinkStatus.Name = "LinkStatus";
            this.LinkStatus.Size = new System.Drawing.Size(0, 19);
            this.LinkStatus.TabIndex = 175;
            this.LinkStatus.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.LinkStatus.Visible = false;
            // 
            // iLabel46
            // 
            this.iLabel46.AutoSize = true;
            this.iLabel46.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel46.ForeColor = System.Drawing.Color.White;
            this.iLabel46.Location = new System.Drawing.Point(124, 152);
            this.iLabel46.Name = "iLabel46";
            this.iLabel46.Size = new System.Drawing.Size(236, 19);
            this.iLabel46.TabIndex = 173;
            this.iLabel46.Text = "Ban cracker from using my app again";
            this.iLabel46.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel44
            // 
            this.iLabel44.AutoSize = true;
            this.iLabel44.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel44.ForeColor = System.Drawing.Color.White;
            this.iLabel44.Location = new System.Drawing.Point(28, 20);
            this.iLabel44.Name = "iLabel44";
            this.iLabel44.Size = new System.Drawing.Size(231, 32);
            this.iLabel44.TabIndex = 170;
            this.iLabel44.Text = "Anti Crack Settings";
            this.iLabel44.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel9
            // 
            this.iLabel9.AutoSize = true;
            this.iLabel9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel9.ForeColor = System.Drawing.Color.White;
            this.iLabel9.Location = new System.Drawing.Point(124, 77);
            this.iLabel9.Name = "iLabel9";
            this.iLabel9.Size = new System.Drawing.Size(242, 19);
            this.iLabel9.TabIndex = 161;
            this.iLabel9.Text = "Send cracker data to discord webhook";
            this.iLabel9.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // MutationSettingsPage
            // 
            this.MutationSettingsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.MutationSettingsPage.Controls.Add(this.iLabel59);
            this.MutationSettingsPage.Controls.Add(this.textBox3);
            this.MutationSettingsPage.Controls.Add(this.siticoneVSeparator31);
            this.MutationSettingsPage.Controls.Add(this.Mathop_CBOX);
            this.MutationSettingsPage.Controls.Add(this.Fakeif_CBOX);
            this.MutationSettingsPage.Controls.Add(this.siticoneImageButton2);
            this.MutationSettingsPage.Controls.Add(this.siticoneVSeparator30);
            this.MutationSettingsPage.Controls.Add(this.MathMutate_CBOX);
            this.MutationSettingsPage.Controls.Add(this.iLabel58);
            this.MutationSettingsPage.Controls.Add(this.iLabel57);
            this.MutationSettingsPage.Controls.Add(this.iLabel55);
            this.MutationSettingsPage.Controls.Add(this.iLabel54);
            this.MutationSettingsPage.Controls.Add(this.iLabel53);
            this.MutationSettingsPage.Controls.Add(this.iLabel51);
            this.MutationSettingsPage.Controls.Add(this.iLabel52);
            this.MutationSettingsPage.Location = new System.Drawing.Point(4, 22);
            this.MutationSettingsPage.Name = "MutationSettingsPage";
            this.MutationSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.MutationSettingsPage.Size = new System.Drawing.Size(697, 311);
            this.MutationSettingsPage.TabIndex = 10;
            // 
            // iLabel59
            // 
            this.iLabel59.AutoSize = true;
            this.iLabel59.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel59.ForeColor = System.Drawing.Color.White;
            this.iLabel59.Location = new System.Drawing.Point(80, 187);
            this.iLabel59.Name = "iLabel59";
            this.iLabel59.Size = new System.Drawing.Size(67, 19);
            this.iLabel59.TabIndex = 192;
            this.iLabel59.Text = "Warning :";
            this.iLabel59.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(80, 214);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(538, 50);
            this.textBox3.TabIndex = 191;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Using ( Fake if + Math operation ) may slow down obfuscation process !";
            // 
            // siticoneVSeparator31
            // 
            this.siticoneVSeparator31.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator31.FillThickness = 4;
            this.siticoneVSeparator31.Location = new System.Drawing.Point(64, 189);
            this.siticoneVSeparator31.Name = "siticoneVSeparator31";
            this.siticoneVSeparator31.Size = new System.Drawing.Size(10, 40);
            this.siticoneVSeparator31.TabIndex = 190;
            // 
            // Mathop_CBOX
            // 
            this.Mathop_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.Mathop_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Mathop_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mathop_CBOX.Location = new System.Drawing.Point(80, 132);
            this.Mathop_CBOX.Name = "Mathop_CBOX";
            this.Mathop_CBOX.Size = new System.Drawing.Size(38, 22);
            this.Mathop_CBOX.TabIndex = 184;
            this.Mathop_CBOX.Text = "siticoneOSToggleSwith3";
            this.Mathop_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.Mathop_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // Fakeif_CBOX
            // 
            this.Fakeif_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.Fakeif_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Fakeif_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Fakeif_CBOX.Location = new System.Drawing.Point(80, 104);
            this.Fakeif_CBOX.Name = "Fakeif_CBOX";
            this.Fakeif_CBOX.Size = new System.Drawing.Size(38, 22);
            this.Fakeif_CBOX.TabIndex = 182;
            this.Fakeif_CBOX.Text = "siticoneOSToggleSwith2";
            this.Fakeif_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.Fakeif_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneImageButton2
            // 
            this.siticoneImageButton2.CheckedState.Parent = this.siticoneImageButton2;
            this.siticoneImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneImageButton2.HoveredState.ImageSize = new System.Drawing.Size(49, 49);
            this.siticoneImageButton2.HoveredState.Parent = this.siticoneImageButton2;
            this.siticoneImageButton2.ImageSize = new System.Drawing.Size(50, 50);
            this.siticoneImageButton2.Location = new System.Drawing.Point(636, 250);
            this.siticoneImageButton2.Name = "siticoneImageButton2";
            this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(48, 48);
            this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
            this.siticoneImageButton2.Size = new System.Drawing.Size(50, 50);
            this.siticoneImageButton2.TabIndex = 179;
            this.siticoneImageButton2.Click += new System.EventHandler(this.fj);
            // 
            // siticoneVSeparator30
            // 
            this.siticoneVSeparator30.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator30.FillThickness = 4;
            this.siticoneVSeparator30.Location = new System.Drawing.Point(64, 74);
            this.siticoneVSeparator30.Name = "siticoneVSeparator30";
            this.siticoneVSeparator30.Size = new System.Drawing.Size(10, 84);
            this.siticoneVSeparator30.TabIndex = 178;
            // 
            // MathMutate_CBOX
            // 
            this.MathMutate_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.MathMutate_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.MathMutate_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MathMutate_CBOX.Location = new System.Drawing.Point(80, 76);
            this.MathMutate_CBOX.Name = "MathMutate_CBOX";
            this.MathMutate_CBOX.Size = new System.Drawing.Size(38, 22);
            this.MathMutate_CBOX.TabIndex = 175;
            this.MathMutate_CBOX.Text = "siticoneOSToggleSwith1";
            this.MathMutate_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.MathMutate_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // iLabel58
            // 
            this.iLabel58.AutoSize = true;
            this.iLabel58.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel58.ForeColor = System.Drawing.Color.White;
            this.iLabel58.Location = new System.Drawing.Point(285, 133);
            this.iLabel58.Name = "iLabel58";
            this.iLabel58.Size = new System.Drawing.Size(100, 19);
            this.iLabel58.TabIndex = 189;
            this.iLabel58.Text = "Recommended";
            this.iLabel58.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel57
            // 
            this.iLabel57.AutoSize = true;
            this.iLabel57.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel57.ForeColor = System.Drawing.Color.White;
            this.iLabel57.Location = new System.Drawing.Point(285, 105);
            this.iLabel57.Name = "iLabel57";
            this.iLabel57.Size = new System.Drawing.Size(100, 19);
            this.iLabel57.TabIndex = 188;
            this.iLabel57.Text = "Recommended";
            this.iLabel57.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel55
            // 
            this.iLabel55.AutoSize = true;
            this.iLabel55.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel55.ForeColor = System.Drawing.Color.White;
            this.iLabel55.Location = new System.Drawing.Point(285, 77);
            this.iLabel55.Name = "iLabel55";
            this.iLabel55.Size = new System.Drawing.Size(100, 19);
            this.iLabel55.TabIndex = 186;
            this.iLabel55.Text = "Recommended";
            this.iLabel55.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel54
            // 
            this.iLabel54.AutoSize = true;
            this.iLabel54.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel54.ForeColor = System.Drawing.Color.White;
            this.iLabel54.Location = new System.Drawing.Point(124, 133);
            this.iLabel54.Name = "iLabel54";
            this.iLabel54.Size = new System.Drawing.Size(105, 19);
            this.iLabel54.TabIndex = 185;
            this.iLabel54.Text = "Math operation";
            this.iLabel54.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel53
            // 
            this.iLabel53.AutoSize = true;
            this.iLabel53.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel53.ForeColor = System.Drawing.Color.White;
            this.iLabel53.Location = new System.Drawing.Point(124, 105);
            this.iLabel53.Name = "iLabel53";
            this.iLabel53.Size = new System.Drawing.Size(48, 19);
            this.iLabel53.TabIndex = 183;
            this.iLabel53.Text = "Fake if";
            this.iLabel53.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel51
            // 
            this.iLabel51.AutoSize = true;
            this.iLabel51.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel51.ForeColor = System.Drawing.Color.White;
            this.iLabel51.Location = new System.Drawing.Point(28, 20);
            this.iLabel51.Name = "iLabel51";
            this.iLabel51.Size = new System.Drawing.Size(219, 32);
            this.iLabel51.TabIndex = 177;
            this.iLabel51.Text = "Mutation Settings";
            this.iLabel51.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel52
            // 
            this.iLabel52.AutoSize = true;
            this.iLabel52.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel52.ForeColor = System.Drawing.Color.White;
            this.iLabel52.Location = new System.Drawing.Point(124, 77);
            this.iLabel52.Name = "iLabel52";
            this.iLabel52.Size = new System.Drawing.Size(102, 19);
            this.iLabel52.TabIndex = 176;
            this.iLabel52.Text = "Math mutation";
            this.iLabel52.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // ConstansMeltingPage
            // 
            this.ConstansMeltingPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ConstansMeltingPage.Controls.Add(this.iLabel72);
            this.ConstansMeltingPage.Controls.Add(this.textBox4);
            this.ConstansMeltingPage.Controls.Add(this.siticoneVSeparator36);
            this.ConstansMeltingPage.Controls.Add(this.siticoneImageButton3);
            this.ConstansMeltingPage.Controls.Add(this.MeltInt_CBOX);
            this.ConstansMeltingPage.Controls.Add(this.siticoneVSeparator34);
            this.ConstansMeltingPage.Controls.Add(this.MeltStr_CBOX);
            this.ConstansMeltingPage.Controls.Add(this.iLabel65);
            this.ConstansMeltingPage.Controls.Add(this.iLabel66);
            this.ConstansMeltingPage.Controls.Add(this.iLabel67);
            this.ConstansMeltingPage.Location = new System.Drawing.Point(4, 22);
            this.ConstansMeltingPage.Name = "ConstansMeltingPage";
            this.ConstansMeltingPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConstansMeltingPage.Size = new System.Drawing.Size(697, 311);
            this.ConstansMeltingPage.TabIndex = 11;
            // 
            // iLabel72
            // 
            this.iLabel72.AutoSize = true;
            this.iLabel72.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel72.ForeColor = System.Drawing.Color.White;
            this.iLabel72.Location = new System.Drawing.Point(80, 173);
            this.iLabel72.Name = "iLabel72";
            this.iLabel72.Size = new System.Drawing.Size(67, 19);
            this.iLabel72.TabIndex = 197;
            this.iLabel72.Text = "Warning :";
            this.iLabel72.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(80, 201);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(538, 50);
            this.textBox4.TabIndex = 196;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Melting may slow down obfuscation process !\r\nMay slow down if used many options i" +
    "n mutation";
            // 
            // siticoneVSeparator36
            // 
            this.siticoneVSeparator36.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator36.FillThickness = 4;
            this.siticoneVSeparator36.Location = new System.Drawing.Point(64, 175);
            this.siticoneVSeparator36.Name = "siticoneVSeparator36";
            this.siticoneVSeparator36.Size = new System.Drawing.Size(10, 58);
            this.siticoneVSeparator36.TabIndex = 195;
            // 
            // siticoneImageButton3
            // 
            this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
            this.siticoneImageButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(49, 49);
            this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
            this.siticoneImageButton3.ImageSize = new System.Drawing.Size(50, 50);
            this.siticoneImageButton3.Location = new System.Drawing.Point(636, 250);
            this.siticoneImageButton3.Name = "siticoneImageButton3";
            this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(48, 48);
            this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
            this.siticoneImageButton3.Size = new System.Drawing.Size(50, 50);
            this.siticoneImageButton3.TabIndex = 194;
            this.siticoneImageButton3.Click += new System.EventHandler(this.fA);
            // 
            // MeltInt_CBOX
            // 
            this.MeltInt_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.MeltInt_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.MeltInt_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MeltInt_CBOX.Location = new System.Drawing.Point(80, 104);
            this.MeltInt_CBOX.Name = "MeltInt_CBOX";
            this.MeltInt_CBOX.Size = new System.Drawing.Size(38, 22);
            this.MeltInt_CBOX.TabIndex = 192;
            this.MeltInt_CBOX.Text = "siticoneOSToggleSwith1";
            this.MeltInt_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.MeltInt_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneVSeparator34
            // 
            this.siticoneVSeparator34.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator34.FillThickness = 4;
            this.siticoneVSeparator34.Location = new System.Drawing.Point(64, 74);
            this.siticoneVSeparator34.Name = "siticoneVSeparator34";
            this.siticoneVSeparator34.Size = new System.Drawing.Size(10, 54);
            this.siticoneVSeparator34.TabIndex = 191;
            // 
            // MeltStr_CBOX
            // 
            this.MeltStr_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.MeltStr_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.MeltStr_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MeltStr_CBOX.Location = new System.Drawing.Point(80, 76);
            this.MeltStr_CBOX.Name = "MeltStr_CBOX";
            this.MeltStr_CBOX.Size = new System.Drawing.Size(38, 22);
            this.MeltStr_CBOX.TabIndex = 188;
            this.MeltStr_CBOX.Text = "siticoneOSToggleSwith1";
            this.MeltStr_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.MeltStr_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // iLabel65
            // 
            this.iLabel65.AutoSize = true;
            this.iLabel65.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel65.ForeColor = System.Drawing.Color.White;
            this.iLabel65.Location = new System.Drawing.Point(124, 105);
            this.iLabel65.Name = "iLabel65";
            this.iLabel65.Size = new System.Drawing.Size(91, 19);
            this.iLabel65.TabIndex = 193;
            this.iLabel65.Text = "Melt Integers";
            this.iLabel65.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel66
            // 
            this.iLabel66.AutoSize = true;
            this.iLabel66.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel66.ForeColor = System.Drawing.Color.White;
            this.iLabel66.Location = new System.Drawing.Point(28, 20);
            this.iLabel66.Name = "iLabel66";
            this.iLabel66.Size = new System.Drawing.Size(322, 32);
            this.iLabel66.TabIndex = 190;
            this.iLabel66.Text = "Constants Melting Settings";
            this.iLabel66.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel67
            // 
            this.iLabel67.AutoSize = true;
            this.iLabel67.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel67.ForeColor = System.Drawing.Color.White;
            this.iLabel67.Location = new System.Drawing.Point(124, 77);
            this.iLabel67.Name = "iLabel67";
            this.iLabel67.Size = new System.Drawing.Size(83, 19);
            this.iLabel67.TabIndex = 189;
            this.iLabel67.Text = "Melt Strings";
            this.iLabel67.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // StringsSettingsPage
            // 
            this.StringsSettingsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.StringsSettingsPage.Controls.Add(this.OutlineStrings_CBOX);
            this.StringsSettingsPage.Controls.Add(this.Str2FE_CBOX);
            this.StringsSettingsPage.Controls.Add(this.Xor_CBOX);
            this.StringsSettingsPage.Controls.Add(this.siticoneImageButton4);
            this.StringsSettingsPage.Controls.Add(this.CEStr_CBOX);
            this.StringsSettingsPage.Controls.Add(this.siticoneVSeparator35);
            this.StringsSettingsPage.Controls.Add(this.iLabel69);
            this.StringsSettingsPage.Controls.Add(this.iLabel71);
            this.StringsSettingsPage.Controls.Add(this.iLabel70);
            this.StringsSettingsPage.Controls.Add(this.iLabel64);
            this.StringsSettingsPage.Controls.Add(this.iLabel68);
            this.StringsSettingsPage.Location = new System.Drawing.Point(4, 22);
            this.StringsSettingsPage.Name = "StringsSettingsPage";
            this.StringsSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.StringsSettingsPage.Size = new System.Drawing.Size(697, 311);
            this.StringsSettingsPage.TabIndex = 12;
            // 
            // OutlineStrings_CBOX
            // 
            this.OutlineStrings_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.OutlineStrings_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.OutlineStrings_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OutlineStrings_CBOX.Location = new System.Drawing.Point(80, 211);
            this.OutlineStrings_CBOX.Name = "OutlineStrings_CBOX";
            this.OutlineStrings_CBOX.Size = new System.Drawing.Size(38, 22);
            this.OutlineStrings_CBOX.TabIndex = 206;
            this.OutlineStrings_CBOX.Text = "siticoneOSToggleSwith4";
            this.OutlineStrings_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.OutlineStrings_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.OutlineStrings_CBOX.Visible = false;
            // 
            // Str2FE_CBOX
            // 
            this.Str2FE_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.Str2FE_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Str2FE_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Str2FE_CBOX.Location = new System.Drawing.Point(80, 132);
            this.Str2FE_CBOX.Name = "Str2FE_CBOX";
            this.Str2FE_CBOX.Size = new System.Drawing.Size(38, 22);
            this.Str2FE_CBOX.TabIndex = 204;
            this.Str2FE_CBOX.Text = "siticoneOSToggleSwith4";
            this.Str2FE_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.Str2FE_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // Xor_CBOX
            // 
            this.Xor_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.Xor_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Xor_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Xor_CBOX.Location = new System.Drawing.Point(80, 104);
            this.Xor_CBOX.Name = "Xor_CBOX";
            this.Xor_CBOX.Size = new System.Drawing.Size(38, 22);
            this.Xor_CBOX.TabIndex = 202;
            this.Xor_CBOX.Text = "siticoneOSToggleSwith3";
            this.Xor_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.Xor_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneImageButton4
            // 
            this.siticoneImageButton4.CheckedState.Parent = this.siticoneImageButton4;
            this.siticoneImageButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneImageButton4.HoveredState.ImageSize = new System.Drawing.Size(49, 49);
            this.siticoneImageButton4.HoveredState.Parent = this.siticoneImageButton4;
            this.siticoneImageButton4.ImageSize = new System.Drawing.Size(50, 50);
            this.siticoneImageButton4.Location = new System.Drawing.Point(636, 250);
            this.siticoneImageButton4.Name = "siticoneImageButton4";
            this.siticoneImageButton4.PressedState.ImageSize = new System.Drawing.Size(48, 48);
            this.siticoneImageButton4.PressedState.Parent = this.siticoneImageButton4;
            this.siticoneImageButton4.Size = new System.Drawing.Size(50, 50);
            this.siticoneImageButton4.TabIndex = 201;
            this.siticoneImageButton4.Click += new System.EventHandler(this.fm);
            // 
            // CEStr_CBOX
            // 
            this.CEStr_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.CEStr_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.CEStr_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CEStr_CBOX.Location = new System.Drawing.Point(80, 76);
            this.CEStr_CBOX.Name = "CEStr_CBOX";
            this.CEStr_CBOX.Size = new System.Drawing.Size(38, 22);
            this.CEStr_CBOX.TabIndex = 199;
            this.CEStr_CBOX.Text = "siticoneOSToggleSwith1";
            this.CEStr_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.CEStr_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneVSeparator35
            // 
            this.siticoneVSeparator35.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator35.FillThickness = 4;
            this.siticoneVSeparator35.Location = new System.Drawing.Point(64, 74);
            this.siticoneVSeparator35.Name = "siticoneVSeparator35";
            this.siticoneVSeparator35.Size = new System.Drawing.Size(10, 82);
            this.siticoneVSeparator35.TabIndex = 198;
            // 
            // iLabel69
            // 
            this.iLabel69.AutoSize = true;
            this.iLabel69.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel69.ForeColor = System.Drawing.Color.White;
            this.iLabel69.Location = new System.Drawing.Point(124, 212);
            this.iLabel69.Name = "iLabel69";
            this.iLabel69.Size = new System.Drawing.Size(100, 19);
            this.iLabel69.TabIndex = 207;
            this.iLabel69.Text = "Outline Strings";
            this.iLabel69.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.iLabel69.Visible = false;
            // 
            // iLabel71
            // 
            this.iLabel71.AutoSize = true;
            this.iLabel71.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel71.ForeColor = System.Drawing.Color.White;
            this.iLabel71.Location = new System.Drawing.Point(124, 133);
            this.iLabel71.Name = "iLabel71";
            this.iLabel71.Size = new System.Drawing.Size(161, 19);
            this.iLabel71.TabIndex = 205;
            this.iLabel71.Text = "Convert to field / encode";
            this.iLabel71.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel70
            // 
            this.iLabel70.AutoSize = true;
            this.iLabel70.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel70.ForeColor = System.Drawing.Color.White;
            this.iLabel70.Location = new System.Drawing.Point(124, 105);
            this.iLabel70.Name = "iLabel70";
            this.iLabel70.Size = new System.Drawing.Size(75, 19);
            this.iLabel70.TabIndex = 203;
            this.iLabel70.Text = "Xor strings";
            this.iLabel70.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel64
            // 
            this.iLabel64.AutoSize = true;
            this.iLabel64.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel64.ForeColor = System.Drawing.Color.White;
            this.iLabel64.Location = new System.Drawing.Point(124, 77);
            this.iLabel64.Name = "iLabel64";
            this.iLabel64.Size = new System.Drawing.Size(172, 19);
            this.iLabel64.TabIndex = 200;
            this.iLabel64.Text = "Compress / encode strings";
            this.iLabel64.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel68
            // 
            this.iLabel68.AutoSize = true;
            this.iLabel68.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel68.ForeColor = System.Drawing.Color.White;
            this.iLabel68.Location = new System.Drawing.Point(28, 20);
            this.iLabel68.Name = "iLabel68";
            this.iLabel68.Size = new System.Drawing.Size(306, 32);
            this.iLabel68.TabIndex = 197;
            this.iLabel68.Text = "Strings Encoding Settings";
            this.iLabel68.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // JunkSettingsPage
            // 
            this.JunkSettingsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.JunkSettingsPage.Controls.Add(this.iLabel78);
            this.JunkSettingsPage.Controls.Add(this.JunkContent);
            this.JunkSettingsPage.Controls.Add(this.JunkMLength);
            this.JunkSettingsPage.Controls.Add(this.JunkCName);
            this.JunkSettingsPage.Controls.Add(this.JunkMethods_CBOX);
            this.JunkSettingsPage.Controls.Add(this.JunkLength);
            this.JunkSettingsPage.Controls.Add(this.JunkClasses_CBOX);
            this.JunkSettingsPage.Controls.Add(this.siticoneImageButton5);
            this.JunkSettingsPage.Controls.Add(this.siticoneVSeparator26);
            this.JunkSettingsPage.Controls.Add(this.iLabel77);
            this.JunkSettingsPage.Controls.Add(this.iLabel75);
            this.JunkSettingsPage.Controls.Add(this.iLabel74);
            this.JunkSettingsPage.Controls.Add(this.iLabel73);
            this.JunkSettingsPage.Controls.Add(this.iLabel13);
            this.JunkSettingsPage.Controls.Add(this.iLabel76);
            this.JunkSettingsPage.Location = new System.Drawing.Point(4, 22);
            this.JunkSettingsPage.Name = "JunkSettingsPage";
            this.JunkSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.JunkSettingsPage.Size = new System.Drawing.Size(697, 311);
            this.JunkSettingsPage.TabIndex = 13;
            // 
            // iLabel78
            // 
            this.iLabel78.AutoSize = true;
            this.iLabel78.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel78.ForeColor = System.Drawing.Color.White;
            this.iLabel78.Location = new System.Drawing.Point(411, 222);
            this.iLabel78.Name = "iLabel78";
            this.iLabel78.Size = new System.Drawing.Size(59, 19);
            this.iLabel78.TabIndex = 233;
            this.iLabel78.Text = "Content";
            this.iLabel78.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // JunkContent
            // 
            this.JunkContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.JunkContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.JunkContent.DefaultText = "Why are you gay ?\r\nHaa ?";
            this.JunkContent.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.JunkContent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.JunkContent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.JunkContent.DisabledState.Parent = this.JunkContent;
            this.JunkContent.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.JunkContent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.JunkContent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.JunkContent.FocusedState.Parent = this.JunkContent;
            this.JunkContent.ForeColor = System.Drawing.Color.Silver;
            this.JunkContent.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.JunkContent.HoveredState.Parent = this.JunkContent;
            this.JunkContent.Location = new System.Drawing.Point(80, 209);
            this.JunkContent.Multiline = true;
            this.JunkContent.Name = "JunkContent";
            this.JunkContent.PasswordChar = '\0';
            this.JunkContent.PlaceholderText = "";
            this.JunkContent.SelectedText = "";
            this.JunkContent.ShadowDecoration.Parent = this.JunkContent;
            this.JunkContent.Size = new System.Drawing.Size(325, 45);
            this.JunkContent.TabIndex = 232;
            this.JunkContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // JunkMLength
            // 
            this.JunkMLength.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.JunkMLength.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.JunkMLength.DefaultText = "25";
            this.JunkMLength.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.JunkMLength.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.JunkMLength.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.JunkMLength.DisabledState.Parent = this.JunkMLength;
            this.JunkMLength.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.JunkMLength.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.JunkMLength.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.JunkMLength.FocusedState.Parent = this.JunkMLength;
            this.JunkMLength.ForeColor = System.Drawing.Color.Silver;
            this.JunkMLength.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.JunkMLength.HoveredState.Parent = this.JunkMLength;
            this.JunkMLength.Location = new System.Drawing.Point(336, 173);
            this.JunkMLength.Name = "JunkMLength";
            this.JunkMLength.PasswordChar = '\0';
            this.JunkMLength.PlaceholderText = "";
            this.JunkMLength.SelectedText = "";
            this.JunkMLength.ShadowDecoration.Parent = this.JunkMLength;
            this.JunkMLength.Size = new System.Drawing.Size(69, 30);
            this.JunkMLength.TabIndex = 230;
            this.JunkMLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.JunkMLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fz);
            // 
            // JunkCName
            // 
            this.JunkCName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.JunkCName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.JunkCName.DefaultText = "Fuck you :)";
            this.JunkCName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.JunkCName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.JunkCName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.JunkCName.DisabledState.Parent = this.JunkCName;
            this.JunkCName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.JunkCName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.JunkCName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.JunkCName.FocusedState.Parent = this.JunkCName;
            this.JunkCName.ForeColor = System.Drawing.Color.Silver;
            this.JunkCName.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.JunkCName.HoveredState.Parent = this.JunkCName;
            this.JunkCName.Location = new System.Drawing.Point(80, 173);
            this.JunkCName.Name = "JunkCName";
            this.JunkCName.PasswordChar = '\0';
            this.JunkCName.PlaceholderText = "";
            this.JunkCName.SelectedText = "";
            this.JunkCName.ShadowDecoration.Parent = this.JunkCName;
            this.JunkCName.Size = new System.Drawing.Size(166, 30);
            this.JunkCName.TabIndex = 228;
            this.JunkCName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // JunkMethods_CBOX
            // 
            this.JunkMethods_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.JunkMethods_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.JunkMethods_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JunkMethods_CBOX.Location = new System.Drawing.Point(80, 143);
            this.JunkMethods_CBOX.Name = "JunkMethods_CBOX";
            this.JunkMethods_CBOX.Size = new System.Drawing.Size(38, 22);
            this.JunkMethods_CBOX.TabIndex = 224;
            this.JunkMethods_CBOX.Text = "siticoneOSToggleSwith2";
            this.JunkMethods_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.JunkMethods_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // JunkLength
            // 
            this.JunkLength.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.JunkLength.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.JunkLength.DefaultText = "25";
            this.JunkLength.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.JunkLength.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.JunkLength.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.JunkLength.DisabledState.Parent = this.JunkLength;
            this.JunkLength.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.JunkLength.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.JunkLength.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.JunkLength.FocusedState.Parent = this.JunkLength;
            this.JunkLength.ForeColor = System.Drawing.Color.Silver;
            this.JunkLength.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(97)))), ((int)(((byte)(93)))));
            this.JunkLength.HoveredState.Parent = this.JunkLength;
            this.JunkLength.Location = new System.Drawing.Point(80, 105);
            this.JunkLength.Name = "JunkLength";
            this.JunkLength.PasswordChar = '\0';
            this.JunkLength.PlaceholderText = "";
            this.JunkLength.SelectedText = "";
            this.JunkLength.ShadowDecoration.Parent = this.JunkLength;
            this.JunkLength.Size = new System.Drawing.Size(166, 30);
            this.JunkLength.TabIndex = 223;
            this.JunkLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.JunkLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fy);
            // 
            // JunkClasses_CBOX
            // 
            this.JunkClasses_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.JunkClasses_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.JunkClasses_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JunkClasses_CBOX.Location = new System.Drawing.Point(80, 75);
            this.JunkClasses_CBOX.Name = "JunkClasses_CBOX";
            this.JunkClasses_CBOX.Size = new System.Drawing.Size(38, 22);
            this.JunkClasses_CBOX.TabIndex = 219;
            this.JunkClasses_CBOX.Text = "siticoneOSToggleSwith1";
            this.JunkClasses_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.JunkClasses_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneImageButton5
            // 
            this.siticoneImageButton5.CheckedState.Parent = this.siticoneImageButton5;
            this.siticoneImageButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneImageButton5.HoveredState.ImageSize = new System.Drawing.Size(49, 49);
            this.siticoneImageButton5.HoveredState.Parent = this.siticoneImageButton5;
            this.siticoneImageButton5.ImageSize = new System.Drawing.Size(50, 50);
            this.siticoneImageButton5.Location = new System.Drawing.Point(636, 250);
            this.siticoneImageButton5.Name = "siticoneImageButton5";
            this.siticoneImageButton5.PressedState.ImageSize = new System.Drawing.Size(48, 48);
            this.siticoneImageButton5.PressedState.Parent = this.siticoneImageButton5;
            this.siticoneImageButton5.Size = new System.Drawing.Size(50, 50);
            this.siticoneImageButton5.TabIndex = 214;
            this.siticoneImageButton5.Click += new System.EventHandler(this.fx);
            // 
            // siticoneVSeparator26
            // 
            this.siticoneVSeparator26.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator26.FillThickness = 4;
            this.siticoneVSeparator26.Location = new System.Drawing.Point(64, 74);
            this.siticoneVSeparator26.Name = "siticoneVSeparator26";
            this.siticoneVSeparator26.Size = new System.Drawing.Size(10, 180);
            this.siticoneVSeparator26.TabIndex = 211;
            // 
            // iLabel77
            // 
            this.iLabel77.AutoSize = true;
            this.iLabel77.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel77.ForeColor = System.Drawing.Color.White;
            this.iLabel77.Location = new System.Drawing.Point(411, 178);
            this.iLabel77.Name = "iLabel77";
            this.iLabel77.Size = new System.Drawing.Size(52, 19);
            this.iLabel77.TabIndex = 231;
            this.iLabel77.Text = "Length";
            this.iLabel77.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel75
            // 
            this.iLabel75.AutoSize = true;
            this.iLabel75.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel75.ForeColor = System.Drawing.Color.White;
            this.iLabel75.Location = new System.Drawing.Point(252, 178);
            this.iLabel75.Name = "iLabel75";
            this.iLabel75.Size = new System.Drawing.Size(78, 19);
            this.iLabel75.TabIndex = 229;
            this.iLabel75.Text = "Class name";
            this.iLabel75.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel74
            // 
            this.iLabel74.AutoSize = true;
            this.iLabel74.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel74.ForeColor = System.Drawing.Color.White;
            this.iLabel74.Location = new System.Drawing.Point(254, 110);
            this.iLabel74.Name = "iLabel74";
            this.iLabel74.Size = new System.Drawing.Size(52, 19);
            this.iLabel74.TabIndex = 227;
            this.iLabel74.Text = "Length";
            this.iLabel74.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel73
            // 
            this.iLabel73.AutoSize = true;
            this.iLabel73.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel73.ForeColor = System.Drawing.Color.White;
            this.iLabel73.Location = new System.Drawing.Point(124, 144);
            this.iLabel73.Name = "iLabel73";
            this.iLabel73.Size = new System.Drawing.Size(95, 19);
            this.iLabel73.TabIndex = 225;
            this.iLabel73.Text = "Junk methods";
            this.iLabel73.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel13
            // 
            this.iLabel13.AutoSize = true;
            this.iLabel13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel13.ForeColor = System.Drawing.Color.White;
            this.iLabel13.Location = new System.Drawing.Point(124, 76);
            this.iLabel13.Name = "iLabel13";
            this.iLabel13.Size = new System.Drawing.Size(82, 19);
            this.iLabel13.TabIndex = 220;
            this.iLabel13.Text = "Junk classes";
            this.iLabel13.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel76
            // 
            this.iLabel76.AutoSize = true;
            this.iLabel76.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel76.ForeColor = System.Drawing.Color.White;
            this.iLabel76.Location = new System.Drawing.Point(28, 20);
            this.iLabel76.Name = "iLabel76";
            this.iLabel76.Size = new System.Drawing.Size(167, 32);
            this.iLabel76.TabIndex = 210;
            this.iLabel76.Text = "Junk Settings";
            this.iLabel76.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // DonatePage
            // 
            this.DonatePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.DonatePage.Controls.Add(this.Bitcoin);
            this.DonatePage.Controls.Add(this.Paypal);
            this.DonatePage.Controls.Add(this.siticoneVSeparator37);
            this.DonatePage.Controls.Add(this.iLabel79);
            this.DonatePage.Controls.Add(this.iLabel80);
            this.DonatePage.Controls.Add(this.iLabel81);
            this.DonatePage.Controls.Add(this.iLabel42);
            this.DonatePage.Location = new System.Drawing.Point(4, 22);
            this.DonatePage.Name = "DonatePage";
            this.DonatePage.Padding = new System.Windows.Forms.Padding(3);
            this.DonatePage.Size = new System.Drawing.Size(697, 311);
            this.DonatePage.TabIndex = 14;
            // 
            // Bitcoin
            // 
            this.Bitcoin.CheckedState.Parent = this.Bitcoin;
            this.Bitcoin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bitcoin.HoveredState.ImageSize = new System.Drawing.Size(143, 143);
            this.Bitcoin.HoveredState.Parent = this.Bitcoin;
            this.Bitcoin.ImageSize = new System.Drawing.Size(144, 144);
            this.Bitcoin.Location = new System.Drawing.Point(249, 132);
            this.Bitcoin.Name = "Bitcoin";
            this.Bitcoin.PressedState.ImageSize = new System.Drawing.Size(142, 142);
            this.Bitcoin.PressedState.Parent = this.Bitcoin;
            this.Bitcoin.Size = new System.Drawing.Size(144, 144);
            this.Bitcoin.TabIndex = 227;
            this.Bitcoin.Click += new System.EventHandler(this.fR);
            // 
            // Paypal
            // 
            this.Paypal.CheckedState.Parent = this.Paypal;
            this.Paypal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Paypal.HoveredState.ImageSize = new System.Drawing.Size(143, 143);
            this.Paypal.HoveredState.Parent = this.Paypal;
            this.Paypal.ImageSize = new System.Drawing.Size(144, 144);
            this.Paypal.Location = new System.Drawing.Point(50, 132);
            this.Paypal.Name = "Paypal";
            this.Paypal.PressedState.ImageSize = new System.Drawing.Size(142, 142);
            this.Paypal.PressedState.Parent = this.Paypal;
            this.Paypal.Size = new System.Drawing.Size(144, 144);
            this.Paypal.TabIndex = 225;
            this.Paypal.Click += new System.EventHandler(this.fQ);
            // 
            // siticoneVSeparator37
            // 
            this.siticoneVSeparator37.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator37.FillThickness = 4;
            this.siticoneVSeparator37.Location = new System.Drawing.Point(34, 74);
            this.siticoneVSeparator37.Name = "siticoneVSeparator37";
            this.siticoneVSeparator37.Size = new System.Drawing.Size(10, 37);
            this.siticoneVSeparator37.TabIndex = 222;
            // 
            // iLabel79
            // 
            this.iLabel79.AutoSize = true;
            this.iLabel79.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel79.ForeColor = System.Drawing.Color.White;
            this.iLabel79.Location = new System.Drawing.Point(200, 180);
            this.iLabel79.Name = "iLabel79";
            this.iLabel79.Size = new System.Drawing.Size(42, 32);
            this.iLabel79.TabIndex = 226;
            this.iLabel79.Text = "Or";
            this.iLabel79.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel80
            // 
            this.iLabel80.AutoSize = true;
            this.iLabel80.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel80.ForeColor = System.Drawing.Color.White;
            this.iLabel80.Location = new System.Drawing.Point(46, 92);
            this.iLabel80.Name = "iLabel80";
            this.iLabel80.Size = new System.Drawing.Size(583, 19);
            this.iLabel80.TabIndex = 224;
            this.iLabel80.Text = "So if you want to support me, you can support me via ( paypal or crypto like ( bt" +
    "c, usdt or ltc )";
            this.iLabel80.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel81
            // 
            this.iLabel81.AutoSize = true;
            this.iLabel81.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.iLabel81.ForeColor = System.Drawing.Color.White;
            this.iLabel81.Location = new System.Drawing.Point(46, 72);
            this.iLabel81.Name = "iLabel81";
            this.iLabel81.Size = new System.Drawing.Size(246, 19);
            this.iLabel81.TabIndex = 223;
            this.iLabel81.Text = "Currently i work on end low Laptop";
            this.iLabel81.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel42
            // 
            this.iLabel42.AutoSize = true;
            this.iLabel42.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel42.ForeColor = System.Drawing.Color.White;
            this.iLabel42.Location = new System.Drawing.Point(28, 20);
            this.iLabel42.Name = "iLabel42";
            this.iLabel42.Size = new System.Drawing.Size(140, 32);
            this.iLabel42.TabIndex = 211;
            this.iLabel42.Text = "Donate Me";
            this.iLabel42.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // RefProxyPage
            // 
            this.RefProxyPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.RefProxyPage.Controls.Add(this.siticoneImageButton6);
            this.RefProxyPage.Controls.Add(this.StrongRef_CBOX);
            this.RefProxyPage.Controls.Add(this.BasicRef_CBOX);
            this.RefProxyPage.Controls.Add(this.siticoneVSeparator38);
            this.RefProxyPage.Controls.Add(this.iLabel84);
            this.RefProxyPage.Controls.Add(this.iLabel83);
            this.RefProxyPage.Controls.Add(this.iLabel82);
            this.RefProxyPage.Location = new System.Drawing.Point(4, 22);
            this.RefProxyPage.Name = "RefProxyPage";
            this.RefProxyPage.Padding = new System.Windows.Forms.Padding(3);
            this.RefProxyPage.Size = new System.Drawing.Size(697, 311);
            this.RefProxyPage.TabIndex = 15;
            // 
            // siticoneImageButton6
            // 
            this.siticoneImageButton6.CheckedState.Parent = this.siticoneImageButton6;
            this.siticoneImageButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneImageButton6.HoveredState.ImageSize = new System.Drawing.Size(49, 49);
            this.siticoneImageButton6.HoveredState.Parent = this.siticoneImageButton6;
            this.siticoneImageButton6.ImageSize = new System.Drawing.Size(50, 50);
            this.siticoneImageButton6.Location = new System.Drawing.Point(636, 250);
            this.siticoneImageButton6.Name = "siticoneImageButton6";
            this.siticoneImageButton6.PressedState.ImageSize = new System.Drawing.Size(48, 48);
            this.siticoneImageButton6.PressedState.Parent = this.siticoneImageButton6;
            this.siticoneImageButton6.Size = new System.Drawing.Size(50, 50);
            this.siticoneImageButton6.TabIndex = 225;
            this.siticoneImageButton6.Click += new System.EventHandler(this.fD);
            // 
            // StrongRef_CBOX
            // 
            this.StrongRef_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.StrongRef_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.StrongRef_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StrongRef_CBOX.Location = new System.Drawing.Point(80, 103);
            this.StrongRef_CBOX.Name = "StrongRef_CBOX";
            this.StrongRef_CBOX.Size = new System.Drawing.Size(38, 22);
            this.StrongRef_CBOX.TabIndex = 223;
            this.StrongRef_CBOX.Text = "siticoneOSToggleSwith2";
            this.StrongRef_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.StrongRef_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.StrongRef_CBOX.CheckedChanged += new System.EventHandler(this.fp);
            // 
            // BasicRef_CBOX
            // 
            this.BasicRef_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.BasicRef_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.BasicRef_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BasicRef_CBOX.Location = new System.Drawing.Point(80, 75);
            this.BasicRef_CBOX.Name = "BasicRef_CBOX";
            this.BasicRef_CBOX.Size = new System.Drawing.Size(38, 22);
            this.BasicRef_CBOX.TabIndex = 221;
            this.BasicRef_CBOX.Text = "siticoneOSToggleSwith1";
            this.BasicRef_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.BasicRef_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            // 
            // siticoneVSeparator38
            // 
            this.siticoneVSeparator38.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator38.FillThickness = 4;
            this.siticoneVSeparator38.Location = new System.Drawing.Point(64, 74);
            this.siticoneVSeparator38.Name = "siticoneVSeparator38";
            this.siticoneVSeparator38.Size = new System.Drawing.Size(10, 52);
            this.siticoneVSeparator38.TabIndex = 213;
            // 
            // iLabel84
            // 
            this.iLabel84.AutoSize = true;
            this.iLabel84.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel84.ForeColor = System.Drawing.Color.White;
            this.iLabel84.Location = new System.Drawing.Point(124, 104);
            this.iLabel84.Name = "iLabel84";
            this.iLabel84.Size = new System.Drawing.Size(148, 19);
            this.iLabel84.TabIndex = 224;
            this.iLabel84.Text = "Strong reference proxy";
            this.iLabel84.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel83
            // 
            this.iLabel83.AutoSize = true;
            this.iLabel83.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel83.ForeColor = System.Drawing.Color.White;
            this.iLabel83.Location = new System.Drawing.Point(124, 76);
            this.iLabel83.Name = "iLabel83";
            this.iLabel83.Size = new System.Drawing.Size(288, 19);
            this.iLabel83.TabIndex = 222;
            this.iLabel83.Text = "Basic reference proxy ( Highly recommended )";
            this.iLabel83.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel82
            // 
            this.iLabel82.AutoSize = true;
            this.iLabel82.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel82.ForeColor = System.Drawing.Color.White;
            this.iLabel82.Location = new System.Drawing.Point(28, 20);
            this.iLabel82.Name = "iLabel82";
            this.iLabel82.Size = new System.Drawing.Size(299, 32);
            this.iLabel82.TabIndex = 212;
            this.iLabel82.Text = "Reference Proxy Settings";
            this.iLabel82.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // SettingsPage
            // 
            this.SettingsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.SettingsPage.Controls.Add(this.FlatB_CBOX);
            this.SettingsPage.Controls.Add(this.AOT_CBOX);
            this.SettingsPage.Controls.Add(this.TR_CBOX);
            this.SettingsPage.Controls.Add(this.siticoneVSeparator39);
            this.SettingsPage.Controls.Add(this.iLabel93);
            this.SettingsPage.Controls.Add(this.iLabel88);
            this.SettingsPage.Controls.Add(this.iLabel87);
            this.SettingsPage.Controls.Add(this.iLabel86);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(697, 311);
            this.SettingsPage.TabIndex = 16;
            // 
            // FlatB_CBOX
            // 
            this.FlatB_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.FlatB_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.FlatB_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlatB_CBOX.Location = new System.Drawing.Point(80, 132);
            this.FlatB_CBOX.Name = "FlatB_CBOX";
            this.FlatB_CBOX.Size = new System.Drawing.Size(38, 22);
            this.FlatB_CBOX.TabIndex = 227;
            this.FlatB_CBOX.Text = "siticoneOSToggleSwith2";
            this.FlatB_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.FlatB_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.FlatB_CBOX.CheckedChanged += new System.EventHandler(this.fW);
            // 
            // AOT_CBOX
            // 
            this.AOT_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.AOT_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.AOT_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AOT_CBOX.Location = new System.Drawing.Point(80, 104);
            this.AOT_CBOX.Name = "AOT_CBOX";
            this.AOT_CBOX.Size = new System.Drawing.Size(38, 22);
            this.AOT_CBOX.TabIndex = 225;
            this.AOT_CBOX.Text = "siticoneOSToggleSwith2";
            this.AOT_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.AOT_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.AOT_CBOX.CheckedChanged += new System.EventHandler(this.fV);
            // 
            // TR_CBOX
            // 
            this.TR_CBOX.Checked = true;
            this.TR_CBOX.CheckedFillColor = System.Drawing.Color.White;
            this.TR_CBOX.CheckedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.TR_CBOX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TR_CBOX.Location = new System.Drawing.Point(80, 76);
            this.TR_CBOX.Name = "TR_CBOX";
            this.TR_CBOX.Size = new System.Drawing.Size(38, 22);
            this.TR_CBOX.TabIndex = 223;
            this.TR_CBOX.Text = "siticoneOSToggleSwith1";
            this.TR_CBOX.UncheckedFillColor = System.Drawing.Color.Black;
            this.TR_CBOX.UncheckInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.TR_CBOX.CheckedChanged += new System.EventHandler(this.fU);
            // 
            // siticoneVSeparator39
            // 
            this.siticoneVSeparator39.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.siticoneVSeparator39.FillThickness = 4;
            this.siticoneVSeparator39.Location = new System.Drawing.Point(64, 74);
            this.siticoneVSeparator39.Name = "siticoneVSeparator39";
            this.siticoneVSeparator39.Size = new System.Drawing.Size(10, 80);
            this.siticoneVSeparator39.TabIndex = 214;
            // 
            // iLabel93
            // 
            this.iLabel93.AutoSize = true;
            this.iLabel93.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel93.ForeColor = System.Drawing.Color.White;
            this.iLabel93.Location = new System.Drawing.Point(124, 133);
            this.iLabel93.Name = "iLabel93";
            this.iLabel93.Size = new System.Drawing.Size(82, 19);
            this.iLabel93.TabIndex = 228;
            this.iLabel93.Text = "Flat borders";
            this.iLabel93.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel88
            // 
            this.iLabel88.AutoSize = true;
            this.iLabel88.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel88.ForeColor = System.Drawing.Color.White;
            this.iLabel88.Location = new System.Drawing.Point(124, 105);
            this.iLabel88.Name = "iLabel88";
            this.iLabel88.Size = new System.Drawing.Size(96, 19);
            this.iLabel88.TabIndex = 226;
            this.iLabel88.Text = "Always on top";
            this.iLabel88.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel87
            // 
            this.iLabel87.AutoSize = true;
            this.iLabel87.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iLabel87.ForeColor = System.Drawing.Color.White;
            this.iLabel87.Location = new System.Drawing.Point(124, 77);
            this.iLabel87.Name = "iLabel87";
            this.iLabel87.Size = new System.Drawing.Size(89, 19);
            this.iLabel87.TabIndex = 224;
            this.iLabel87.Text = "Transparency";
            this.iLabel87.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // iLabel86
            // 
            this.iLabel86.AutoSize = true;
            this.iLabel86.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.iLabel86.ForeColor = System.Drawing.Color.White;
            this.iLabel86.Location = new System.Drawing.Point(28, 20);
            this.iLabel86.Name = "iLabel86";
            this.iLabel86.Size = new System.Drawing.Size(155, 32);
            this.iLabel86.TabIndex = 213;
            this.iLabel86.Text = "GUI Settings";
            this.iLabel86.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // GoToLog
            // 
            this.GoToLog.CheckedState.Parent = this.GoToLog;
            this.GoToLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToLog.CustomImages.Parent = this.GoToLog;
            this.GoToLog.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.GoToLog.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GoToLog.ForeColor = System.Drawing.Color.White;
            this.GoToLog.HoveredState.Parent = this.GoToLog;
            this.GoToLog.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToLog.ImageOffset = new System.Drawing.Point(5, 0);
            this.GoToLog.ImageSize = new System.Drawing.Size(24, 24);
            this.GoToLog.Location = new System.Drawing.Point(0, 300);
            this.GoToLog.Name = "GoToLog";
            this.GoToLog.ShadowDecoration.Parent = this.GoToLog;
            this.GoToLog.Size = new System.Drawing.Size(222, 50);
            this.GoToLog.TabIndex = 6;
            this.GoToLog.Text = "Log";
            this.GoToLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToLog.TextOffset = new System.Drawing.Point(5, 0);
            this.GoToLog.Click += new System.EventHandler(this.fd);
            // 
            // GoToCodeOptimization
            // 
            this.GoToCodeOptimization.CheckedState.Parent = this.GoToCodeOptimization;
            this.GoToCodeOptimization.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToCodeOptimization.CustomImages.Parent = this.GoToCodeOptimization;
            this.GoToCodeOptimization.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.GoToCodeOptimization.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GoToCodeOptimization.ForeColor = System.Drawing.Color.White;
            this.GoToCodeOptimization.HoveredState.Parent = this.GoToCodeOptimization;
            this.GoToCodeOptimization.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToCodeOptimization.ImageOffset = new System.Drawing.Point(5, 0);
            this.GoToCodeOptimization.ImageSize = new System.Drawing.Size(24, 24);
            this.GoToCodeOptimization.Location = new System.Drawing.Point(0, 250);
            this.GoToCodeOptimization.Name = "GoToCodeOptimization";
            this.GoToCodeOptimization.ShadowDecoration.Parent = this.GoToCodeOptimization;
            this.GoToCodeOptimization.Size = new System.Drawing.Size(222, 50);
            this.GoToCodeOptimization.TabIndex = 8;
            this.GoToCodeOptimization.Text = "Code Optimization";
            this.GoToCodeOptimization.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToCodeOptimization.TextOffset = new System.Drawing.Point(5, 0);
            this.GoToCodeOptimization.Click += new System.EventHandler(this.fc);
            // 
            // GoToRenamer
            // 
            this.GoToRenamer.CheckedState.Parent = this.GoToRenamer;
            this.GoToRenamer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToRenamer.CustomImages.Parent = this.GoToRenamer;
            this.GoToRenamer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.GoToRenamer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GoToRenamer.ForeColor = System.Drawing.Color.White;
            this.GoToRenamer.HoveredState.Parent = this.GoToRenamer;
            this.GoToRenamer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToRenamer.ImageOffset = new System.Drawing.Point(5, 0);
            this.GoToRenamer.ImageSize = new System.Drawing.Size(24, 24);
            this.GoToRenamer.Location = new System.Drawing.Point(0, 150);
            this.GoToRenamer.Name = "GoToRenamer";
            this.GoToRenamer.ShadowDecoration.Parent = this.GoToRenamer;
            this.GoToRenamer.Size = new System.Drawing.Size(222, 50);
            this.GoToRenamer.TabIndex = 9;
            this.GoToRenamer.Text = "Renamer ( BETA )";
            this.GoToRenamer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToRenamer.TextOffset = new System.Drawing.Point(5, 0);
            this.GoToRenamer.Click += new System.EventHandler(this.fa);
            // 
            // GoToVirtualization
            // 
            this.GoToVirtualization.CheckedState.Parent = this.GoToVirtualization;
            this.GoToVirtualization.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToVirtualization.CustomImages.Parent = this.GoToVirtualization;
            this.GoToVirtualization.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.GoToVirtualization.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GoToVirtualization.ForeColor = System.Drawing.Color.White;
            this.GoToVirtualization.HoveredState.Parent = this.GoToVirtualization;
            this.GoToVirtualization.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToVirtualization.ImageOffset = new System.Drawing.Point(5, 0);
            this.GoToVirtualization.ImageSize = new System.Drawing.Size(24, 24);
            this.GoToVirtualization.Location = new System.Drawing.Point(0, 200);
            this.GoToVirtualization.Name = "GoToVirtualization";
            this.GoToVirtualization.ShadowDecoration.Parent = this.GoToVirtualization;
            this.GoToVirtualization.Size = new System.Drawing.Size(222, 50);
            this.GoToVirtualization.TabIndex = 5;
            this.GoToVirtualization.Text = "Dynamic Methods VM";
            this.GoToVirtualization.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToVirtualization.TextOffset = new System.Drawing.Point(5, 0);
            this.GoToVirtualization.Click += new System.EventHandler(this.fb);
            // 
            // GoToProtections
            // 
            this.GoToProtections.CheckedState.Parent = this.GoToProtections;
            this.GoToProtections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToProtections.CustomImages.Parent = this.GoToProtections;
            this.GoToProtections.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.GoToProtections.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GoToProtections.ForeColor = System.Drawing.Color.White;
            this.GoToProtections.HoveredState.Parent = this.GoToProtections;
            this.GoToProtections.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToProtections.ImageOffset = new System.Drawing.Point(5, 0);
            this.GoToProtections.ImageSize = new System.Drawing.Size(24, 24);
            this.GoToProtections.Location = new System.Drawing.Point(0, 100);
            this.GoToProtections.Name = "GoToProtections";
            this.GoToProtections.ShadowDecoration.Parent = this.GoToProtections;
            this.GoToProtections.Size = new System.Drawing.Size(222, 50);
            this.GoToProtections.TabIndex = 1;
            this.GoToProtections.Text = "Protections";
            this.GoToProtections.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToProtections.TextOffset = new System.Drawing.Point(5, 0);
            this.GoToProtections.Click += new System.EventHandler(this.eZ);
            // 
            // GoToMain
            // 
            this.GoToMain.CheckedState.Parent = this.GoToMain;
            this.GoToMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToMain.CustomImages.Parent = this.GoToMain;
            this.GoToMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.GoToMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GoToMain.ForeColor = System.Drawing.Color.White;
            this.GoToMain.HoveredState.Parent = this.GoToMain;
            this.GoToMain.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToMain.ImageOffset = new System.Drawing.Point(5, 0);
            this.GoToMain.ImageSize = new System.Drawing.Size(24, 24);
            this.GoToMain.Location = new System.Drawing.Point(0, 40);
            this.GoToMain.Name = "GoToMain";
            this.GoToMain.ShadowDecoration.Parent = this.GoToMain;
            this.GoToMain.Size = new System.Drawing.Size(222, 60);
            this.GoToMain.TabIndex = 7;
            this.GoToMain.Text = "Main";
            this.GoToMain.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GoToMain.TextOffset = new System.Drawing.Point(5, 0);
            this.GoToMain.Click += new System.EventHandler(this.eY);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(920, 351);
            this.Controls.Add(this.GoToLog);
            this.Controls.Add(this.GoToCodeOptimization);
            this.Controls.Add(this.GoToRenamer);
            this.Controls.Add(this.GoToVirtualization);
            this.Controls.Add(this.GoToProtections);
            this.Controls.Add(this.GoToMain);
            this.Controls.Add(this.TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(920, 351);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI";
            this.TabControl1.ResumeLayout(false);
            this.MainPage.ResumeLayout(false);
            this.MainPage.PerformLayout();
            this.ProtectionsPage.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.RenamerPage.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.VirtualizationPage.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.CodeOptimizationPage.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.LogPage.ResumeLayout(false);
            this.LogPage.PerformLayout();
            this.HelpPage.ResumeLayout(false);
            this.HelpPage.PerformLayout();
            this.CreditsPage.ResumeLayout(false);
            this.CreditsPage.PerformLayout();
            this.GuidePage.ResumeLayout(false);
            this.GuidePage.PerformLayout();
            this.AntiCrackSettings.ResumeLayout(false);
            this.AntiCrackSettings.PerformLayout();
            this.MutationSettingsPage.ResumeLayout(false);
            this.MutationSettingsPage.PerformLayout();
            this.ConstansMeltingPage.ResumeLayout(false);
            this.ConstansMeltingPage.PerformLayout();
            this.StringsSettingsPage.ResumeLayout(false);
            this.StringsSettingsPage.PerformLayout();
            this.JunkSettingsPage.ResumeLayout(false);
            this.JunkSettingsPage.PerformLayout();
            this.DonatePage.ResumeLayout(false);
            this.DonatePage.PerformLayout();
            this.RefProxyPage.ResumeLayout(false);
            this.RefProxyPage.PerformLayout();
            this.SettingsPage.ResumeLayout(false);
            this.SettingsPage.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}
