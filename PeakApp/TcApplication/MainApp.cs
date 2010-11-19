using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Beckhoff.Forms;
using Beckhoff.Forms.Nc;
using Beckhoff.App.TCLManager;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	/// <summary>
	/// Summary description for MainApp.
	/// </summary>
	public partial class MainApp : Form
	{
		public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// General Application settings.
		/// </summary>
		public static Settings appSettings;

		public Beckhoff.App.Security.TcUserAdmin tcUserAdmin1;
		public Color ColorCaption;
		public Color ColorRow2;
		public Color ColorRow3;
		public Color ColorFKey;
		public Color ColorFKeyLR;
		public IAppHeader AppHeader;

		//public delegate void ManualMsgInfoEventHandler(int state, int alarmclass, int sourceId, int eventId, string message);
		//public event ManualMsgInfoEventHandler ManualMsgInfo;

		FormMain formMain;
		CTCLManager tclm;
		TcAdsNcServer adsNcServer;
		TcAdsPlcServer adsPlcServer;
		Timer timerStartUp;
		StatusBarPanel pnlStatus;
		StatusBarPanel pnlConnection;
		TcMenu menu;
		FormSymbolBrowser symbolBrowser;
		bool noLeaveMessage;

		#region Constructor

		/// <summary>
		/// Constructor MainApp.
		/// </summary>
		public MainApp()
		{
			mainApp = this;
			InitializeComponent();

			// Load the user list
			tcUserAdmin1.Load();

			// Create the application header
			CreateHeader();

			// set the logo to the header
			AppHeader.CompanyImageFile = Application.StartupPath + "\\Customer\\Logo.bmp";

			// Language Manager
			try
			{
				tclm = new CTCLManager(this, false);

				// Delegate instance: Error handling for errors from the TCLM
				tclm.Error += new CTCLManager.TCLMErrorEventHandler(tclm_Error);
			}
			catch (Exception ex)
			{
				string tmp = "Error during opening language manager database!";
				log.Fatal(tmp, ex);

				Beckhoff.App.ExceptionDialog exc = new Beckhoff.App.ExceptionDialog();
				exc.SetText(Application.ProductName + " has encountered a problem.\r\n"
					+ "For further information take a look to the application event log.",
					ex);
				exc.ShowDialog();
				exc.Dispose();
				exc = null;
			}

			// status bar
			pnlStatus = new StatusBarPanel();
			try { pnlStatus.Icon = new Icon(Application.StartupPath + "\\Bitmap\\active.ico"); }
			catch { log.Error("File could not be opended! \\Bitmap\\active.ico"); }
			pnlStatus.AutoSize = StatusBarPanelAutoSize.Contents;

			pnlConnection = new StatusBarPanel();
			pnlConnection.AutoSize = StatusBarPanelAutoSize.Spring;

			statusBarMain.Panels.Add(pnlStatus);
			statusBarMain.Panels.Add(pnlConnection);
			statusBarMain.Visible = appSettings.applicationViewStatusBar;

			// Connect all components to the Language Manager
			tcUserAdmin1.LanguageManager = tclm;
			tcUserAdmin1.CurrentUserChanged += new Beckhoff.App.Security.TcUserAdmin.CurrentUserChangedEventHandler(tcUserAdmin1_CurrentUserChanged);
			tcUserAdmin1.UserLogOffEvent = new Beckhoff.App.Security.TcUserAdmin.UserLogOnEventHandler(tcUserAdmin1_UserLogOffEvent);

			SetFormStyle(this);
			SetColorTheme();
		}

		#endregion

		#region Override functions

		protected override void OnClosing(CancelEventArgs e)
		{
			if (noLeaveMessage)
			{
				e.Cancel = false;
			}
			else
			{
				// user can't exit application
				if (MainApp.GetDoc().tcUserAdmin1.CurrentUserLevel < Beckhoff.App.Security.TcUserLevel.User)
					e.Cancel = !LeaveApplication();
				else
					e.Cancel = true;
			}
			base.OnClosing(e);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			const int WM_KEYDOWN = 0x100;
			const int WM_KEYUP = 0x101;
			const int WM_SYSKEYDOWN = 0x104;

			// suppress Ctrl-F4, Ctrl-F6, Alt-F4, Alt-F6
			if ((keyData & Keys.Modifiers) == Keys.Control
				|| (keyData & Keys.Modifiers) == Keys.Alt)
			{
				if ((keyData & (~Keys.Modifiers)) == Keys.F4
					|| (keyData & (~Keys.Modifiers)) == Keys.F6
					|| (keyData & (~Keys.Modifiers)) == Keys.Tab)
				{
					return true;	// do nothing
				}

				/*
				if ((keyData & Keys.Modifiers) == Keys.Alt
					&& (keyData & (~Keys.Modifiers)) == Keys.F4)
					{
					return true;	// do nothing
				}
				
				if ((keyData & (~Keys.Modifiers)) == Keys.F4
					|| (keyData & (~Keys.Modifiers)) == Keys.F6)
				{
					if (msg.Msg == WM_KEYDOWN)
					{
						KeyEventArgs kea = new KeyEventArgs(keyData);
						OnKeyDown(kea);
						return true;
					}

					if (msg.Msg == WM_KEYUP)
					{
						KeyEventArgs kea = new KeyEventArgs(keyData);
						OnKeyUp(kea);
						return true;
					}
				}
				*/
			}

			if (msg.Msg == WM_KEYDOWN || msg.Msg == WM_SYSKEYDOWN)
			{
				if (Keys.F1 <= (keyData & (~Keys.Modifiers))
					&& (keyData & (~Keys.Modifiers)) <= Keys.F12)
				{
					if (fKeyIsPressed == true)
						return true;
					fKeyIsPressed = true;
					KeyEventArgs kea = new KeyEventArgs(keyData);
					oldKea = new KeyEventArgs(keyData);
					tcFKey1.FKeyDown(kea);
					return true;
				}
			}

			//control keys
			if ((msg.Msg == WM_KEYDOWN || msg.Msg == WM_SYSKEYDOWN)
				&& (keyData & Keys.Modifiers) == Keys.Control)
			{
				if ((keyData & (~Keys.Modifiers)) == Keys.Q
				&& MainApp.GetDoc().tcUserAdmin1.CurrentUserLevel == Beckhoff.App.Security.TcUserLevel.Administrator)
				{
					if (symbolBrowser == null || symbolBrowser.IsDisposed)
						symbolBrowser = new FormSymbolBrowser();
					symbolBrowser.AdsPlcServer = adsPlcServer;
					symbolBrowser.ShowDialog();
				}

				if ((keyData & (~Keys.Modifiers)) == Keys.A
					&& MainApp.GetDoc().tcUserAdmin1.CurrentUserLevel == Beckhoff.App.Security.TcUserLevel.Administrator)
				{
					if (menu != null)
						menu.MenuManager();
				}

				if ((keyData & (~Keys.Modifiers)) == Keys.L)
				{
					MainApp.GetDoc().tcUserAdmin1.LogOnDialog(true, false, false);
				}
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		protected override void WndProc(ref Message m)
		{
			// eat this window message
			if (m.Msg == 5)
				return;
			base.WndProc(ref m);
		}

		#endregion

		#region Public static functions

		/// <summary>
		/// Returns the static object of the main form.
		/// </summary>
		[Description("Returns the static object of the main form."), Category("Application")]
		public static MainApp GetDoc()
		{
			if (mainApp != null)
				return mainApp;
			return null;
		}

		#endregion

		#region Public functions

		/// <summary>
		/// Returns the object of the TwinCAT language manager.
		/// </summary>
		[Description("Returns the object of the TwinCAT language manager."), Category("Application")]
		public CTCLManager GetTCLanguageManager()
		{
			return tclm;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the ads server reference.
		/// </summary>
		/// <value>The ads server ref.</value>
		[Description("Gets or sets the ads server reference."), Category("Application")]
		public TcAdsPlcServer AdsPlcServer
		{
			get { return adsPlcServer; }
			set
			{
				adsPlcServer = value;

				// Connects the header controls to the AdsServer
				AppHeader.AdsPlcServer = adsPlcServer;
			}
		}

		/// <summary>
		/// Gets or sets the ads server reference.
		/// </summary>
		/// <value>The ads server ref.</value>
		[Description("Gets or sets the ads server reference."), Category("Application")]
		public TcAdsNcServer AdsNcServer
		{
			get { return adsNcServer; }
			set
			{
				adsNcServer = value;

				// Connects the header controls to the AdsServer
				AppHeader.AdsNcServer = adsNcServer;
			}
		}

		/// <summary>
		/// Returns the name of the system folder.
		/// </summary>
		[Description("Returns the name of the system folder."), Category("Application")]
		public string SystemFolder
		{
			get { return "System"; }
		}

		/// <summary>
		/// Gets/Sets the status bar text.
		/// </summary>
		[Description("Gets/Sets the status bar text."), Category("Application")]
		public string StatusBarText
		{
			get { return statusBarMain.Text; }
			set { statusBarMain.Text = value; }
		}

		#endregion

		#region Events

		private void MainApp_Load(object sender, System.EventArgs e)
		{
			tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
			LoadLanguageStrings();

			formMain = new FormMain();
			formMain.MdiParent = this;
			formMain.Show();
			formMain.BringToFront();

			// bind the visible control to the data
			menu = formMain.LocalMenu;

			menu.CommandLeaveApplication += new EventHandler(menu_CommandLeaveApplication);
			menu.CommandShutDown += new EventHandler(menu_CommandShutDown);

			//Form tmpForm = menu.FindForm(Type.GetType("TcApplication.FormMessages"));
			Form tmpForm = menu.GetForm("FormMessages");
			if (tmpForm != null)
			{
				AppHeader.EventLogLine.DataAdapter = ((FormMessages)tmpForm).tcEventLoggerData1;
			}

			// bind the menu to the header
			AppHeader.Menu = menu;

			Program.SplashTopMost(true);
			Program.CloseSplashScreen(500);

			timerStartUp = new Timer();
			timerStartUp.Tick += new EventHandler(timerStartUp_Tick);
			timerStartUp.Interval = 1;
			timerStartUp.Enabled = true;
		}

		private void timerStartUp_Tick(object sender, EventArgs e)
		{
			timerStartUp.Enabled = false;

			// go to start screen
			if (appSettings.applicationStartupScreen != 0)
				formMain.ShowStartSreen(appSettings.applicationStartupScreen);

			Program.SplashTopMost(false);
		}


		private KeyEventArgs oldKea;
		private bool fKeyIsPressed;
		protected override void OnKeyDown(KeyEventArgs kea)
		{
			if (Keys.F1 <= kea.KeyCode && kea.KeyCode <= Keys.F12)
			{
				if (fKeyIsPressed == true)
					return;
				fKeyIsPressed = true;
				oldKea = new KeyEventArgs(kea.KeyData);
				tcFKey1.FKeyDown(kea);
			}
		}

		protected override void OnKeyUp(KeyEventArgs kea)
		{
			if (Keys.F1 <= kea.KeyCode && kea.KeyCode <= Keys.F12)
			{
				if (oldKea == null)
					return;
				fKeyIsPressed = false;
				tcFKey1.FKeyUp(kea);
			}
		}

		private delegate void SetInstMessageTextCallback(string message);

		private void SetInstMessageText(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				AppHeader.LabelMessageInfo.Text = "";
				AppHeader.LabelMessageInfo.Visible = false;
			}
			else
			{
				AppHeader.LabelMessageInfo.Text = message;
				AppHeader.LabelMessageInfo.Visible = true;
			}
		}

		public void MainAppMsgInfo(Beckhoff.EventLogger.TcEventItem eventItem)
		{
			//if (ManualMsgInfo != null)
			//	ManualMsgInfo(state, alarmclass, sourceId, eventId, message);

			/*
			* If there is an information message from the eventlogger
			* this message is shown to Manual Mode screen
			*/
			if (eventItem.Class == (int)Beckhoff.EventLogger.TcEventClass.Instruction)
			{
				if (AppHeader.LabelMessageInfo.InvokeRequired)
				{
					SetInstMessageTextCallback d = new SetInstMessageTextCallback(SetInstMessageText);
					this.Invoke(d, new Object[] { eventItem.Message });
				}
				else
					SetInstMessageText(eventItem.Message);
			}
		}

		private void MainApp_Resize(object sender, System.EventArgs e)
		{
			if (formMain != null)
			{
				foreach (Form frm in formMain.MdiParent.MdiChildren)
				{
					if (formMain.MdiParent.ActiveMdiChild != frm)
						frm.Hide();
				}
			}

			//SetFormStyle(this);
		}

		private void tcUserAdmin1_CurrentUserChanged(Beckhoff.App.Security.TcUser user, bool logOn)
		{
			// language selection depends from the current user
			int languageId = user.Language;
			if (languageId > tclm.AvailableLanguages.GetLength(0))
				languageId = 1;

			string language = tclm.Translate(tclm.AvailableLanguages[languageId], tclm.Sprache, "DEUTSCH");
			if (String.Compare(language, tclm.Sprache, true) != 0)
			{
				tclm.Sprache = language;
				tclm.SaveAllChanges();

				// set the right language for the text of the function keys
				if (menu != null)
					menu.SetFKeyText();
			}

			if (logOn == true)
			{
				pnlStatus.Text = user.FullName;
				language = tclm.AvailableLanguages[languageId];
				pnlConnection.Text = "Level: " + user.UserLevel.ToString() + " (" + language + ")";
				log.Info("User logged on -> " + user.FullName);
			}
			else
				log.Info("User logged off -> " + user.FullName);
		}

		private void LoadLanguageStrings()
		{
			this.Text = tclm.GetString("x", "TcHmiPro Application");
			AppHeader.LabelChannelText = tclm.GetString("MainApp.labelChannelNr", "Channel");
		}

		void tclm_Error(object sender, string message, Exception exception)
		{
			MainApp.log.Error("TCLM " + sender.ToString() + " " + message, exception);
		}

		#endregion

		#region Private functions

		private void CreateHeader()
		{
			switch (appSettings.applicationHeaderType)
			{
				default:
				case 0:
					Header15 header15;
					header15 = new TcApplication.Header15();
					AppHeader = header15;

					panelHeader.Controls.Add(header15);
					header15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));

					header15.Width = panelHeader.Width;
					panelHeader.Height = header15.Height;
					break;

				case 1:
					Header12 header12;
					header12 = new TcApplication.Header12();
					AppHeader = header12;
					panelHeader.Controls.Add(header12);

					header12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));

					header12.Width = panelHeader.Width;
					panelHeader.Height = header12.Height;
					break;

				case 2:
					Header6p5 header6p5;
					header6p5 = new TcApplication.Header6p5();
					AppHeader = header6p5;
					panelHeader.Controls.Add(header6p5);

					header6p5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));

					header6p5.Width = panelHeader.Width;
					panelHeader.Height = header6p5.Height;
					break;

				case 3:
					UserHeader userHeader;
					userHeader = new TcApplication.UserHeader();
					AppHeader = userHeader;
					panelHeader.Controls.Add(userHeader);

					userHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));

					userHeader.Width = panelHeader.Width;
					panelHeader.Height = userHeader.Height;
					break;
			}

			AppHeader.AdsNcServer = null;
			AppHeader.AdsPlcServer = null;
			AppHeader.ChannelNr = 1;
			AppHeader.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			AppHeader.ColorRow2 = System.Drawing.Color.DarkBlue;
			AppHeader.ColorRow3 = System.Drawing.Color.LightSteelBlue;
			AppHeader.CompanyImageFile = "";
			//AppHeader.LabelChannelText = "Kanal";
		}

		private void SetFormStyle(Form form)
		{
			if (appSettings.applicationFrame)
				form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			else
				form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

			if (appSettings.applicationStartMax)
				form.WindowState = FormWindowState.Maximized;
		}

		private void SetColorTheme()
		{
			// set color theme
			switch (appSettings.applicationColorTheme)
			{
				default:
				case 1:
					ColorCaption = Beckhoff.App.TcColor.ColorTheme1.CaptionColor;
					ColorRow2 = Beckhoff.App.TcColor.ColorTheme1.HeaderColorRow2;
					ColorRow3 = Beckhoff.App.TcColor.ColorTheme1.HeaderColorRow3;
					ColorFKey = Beckhoff.App.TcColor.ColorTheme1.FKeyColor;
					ColorFKeyLR = Beckhoff.App.TcColor.ColorTheme1.FKeyLRColor;
					break;
				case 2:
					ColorCaption = Beckhoff.App.TcColor.ColorTheme2.CaptionColor;
					ColorRow2 = Beckhoff.App.TcColor.ColorTheme2.HeaderColorRow2;
					ColorRow3 = Beckhoff.App.TcColor.ColorTheme2.HeaderColorRow3;
					ColorFKey = Beckhoff.App.TcColor.ColorTheme2.FKeyColor;
					ColorFKeyLR = Beckhoff.App.TcColor.ColorTheme2.FKeyLRColor;
					break;
				case 3:
					ColorCaption = Beckhoff.App.TcColor.ColorTheme3.CaptionColor;
					ColorRow2 = Beckhoff.App.TcColor.ColorTheme3.HeaderColorRow2;
					ColorRow3 = Beckhoff.App.TcColor.ColorTheme3.HeaderColorRow3;
					ColorFKey = Beckhoff.App.TcColor.ColorTheme3.FKeyColor;
					ColorFKeyLR = Beckhoff.App.TcColor.ColorTheme3.FKeyLRColor;
					break;
				case 4:
					ColorCaption = Beckhoff.App.TcColor.ColorTheme4.CaptionColor;
					ColorRow2 = Beckhoff.App.TcColor.ColorTheme4.HeaderColorRow2;
					ColorRow3 = Beckhoff.App.TcColor.ColorTheme4.HeaderColorRow3;
					ColorFKey = Beckhoff.App.TcColor.ColorTheme4.FKeyColor;
					ColorFKeyLR = Beckhoff.App.TcColor.ColorTheme4.FKeyLRColor;
					break;
			}

			// color the header
			AppHeader.CaptionBackColor = ColorCaption;
			AppHeader.ColorRow2 = ColorRow2;
			AppHeader.ColorRow3 = ColorRow3;

			tcFKey1.BackColor = ColorFKey;
			tcFKey1.FKeyBtnBackColor = ColorFKey;
			tcFKey1.FKeyBtnSelectedColor = ColorCaption;

			for (int i = 1; i <= 12; i++)
			{
				Label lbl1 = tcFKey1.FKeyLabelTextObj(i);
				lbl1.ForeColor = Color.FromArgb(163, 166, 171);
			}
		}

		int tcUserAdmin1_UserLogOffEvent(string userName, string password, bool showMessage, bool logOn)
		{
			ShutDown();
			return 1;
		}

		void menu_CommandLeaveApplication(object sender, EventArgs e)
		{
			if (LeaveApplication())
				Application.Exit();
		}

		void menu_CommandShutDown(object sender, EventArgs e)
		{
			ShutDown();
		}

		private bool LeaveApplication()
		{
			string msg = "Do you really want to leave?";
			string caption = "Leave application";
			if (tclm != null)
			{
				msg = tclm.GetString("MainApp.LeaveApp.Msg", msg);
				caption = tclm.GetString("MainApp.LeaveApp.Caption", caption);
			}

			if (MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				return true;
			else
				return false;
		}

		private bool ShutDown()
		{
			string msg = "Do you really want to shut down?";
			string caption = "Shut down";
			if (tclm != null)
			{
				msg = tclm.GetString("UserLogOn.ShutDown.Msg", msg);
				caption = tclm.GetString("UserLogOn.ShutDown.Caption", caption);
			}

			if (MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				// clean up any resources beeing used
				adsPlcServer.PlcClient.Dispose();
				adsNcServer.NcClient.Dispose();
				noLeaveMessage = true;
				Beckhoff.App.Security.WinControl.ShutDown();
				return true;
			}
			return false;
		}

		#endregion

	}
}
