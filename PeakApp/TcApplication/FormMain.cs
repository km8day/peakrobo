using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Beckhoff.App.TCLManager;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	public partial class FormMain : FormTcApp
	{
		
		#region Private variables

		Bitmap mainScreenBitmap;
		TcMenu menu;

		#endregion

		#region Public Instance Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="FormMain"/> class.
		/// </summary>
		public FormMain()
		{
			InitializeComponent();

			MainApp mainApp = MainApp.GetDoc();

			// get the TcLM and set to the base class
			tclm = mainApp.GetTCLanguageManager();

			menu = new TcMenu(this, tclm, mainApp.tcFKey1);
			menu.UserAdmin = mainApp.tcUserAdmin1;
			menu.FormsList.Add("FormMain", this);

			// set the created menu to the base class
			LocalMenu = menu;

			bool autoLogOn = mainApp.tcUserAdmin1.CurrentUser.AutoLogOn;
			if (autoLogOn == false)
				Program.CloseSplashScreen(500);
			else
				Program.CloseSplashScreen(3000);

			mainApp.tcUserAdmin1.LogOnDialog(true, autoLogOn);

			// base settings
			menu.ShowForm("FormMain");
			menu.SetFunctionKeys(mainApp.tcFKey1);

			// This is only needed at the main form, because the delegate from the menu cannot be called
			// because activation is not done.
			SetFKeyText(mainApp.tcFKey1);

			// adds the global objects to the object list
			menu.AddObject(mainApp.AdsPlcServer);
			menu.AddObject(mainApp.AdsNcServer);
			menu.AddObject(MainApp.log);

			// At the end of menu initialization
			// This function calls the forms initialisation which needs the added objects
			menu.InitializationDone();
		}

		#endregion

		#region Public

		public void ShowStartSreen(int idx)
		{
			LocalMenu.FKeyUpEvent(idx);
		}

		/// <summary>
		/// Displays the user administration dialog.
		/// </summary>
		/// <param name="bHideBackground">if set to <c>true</c> [b hide background].</param>
		/// <param name="bAutoLogOn">if set to <c>true</c> [b auto log on].</param>
		/// <param name="bLockComputer">if set to <c>true</c> [b lock computer].</param>
		public void UserAdminDialog(bool bHideBackground, bool bAutoLogOn, bool bLockComputer)
		{
			Beckhoff.App.TcFKey fKey = MainApp.GetDoc().tcFKey1;
			MainApp.GetDoc().tcUserAdmin1.LogOnDialog(bHideBackground, bAutoLogOn, bLockComputer);
		}

		/// <summary>
		/// Displays the user manager dialog.
		/// </summary>
		public void UserManagerDialog()
		{
			MainApp.GetDoc().tcUserAdmin1.UserManagerDialog();
		}

		/// <summary>
		/// Lets users select a language.
		/// </summary>
		public void LanguageDialog()
		{
			if (tclm != null)
			{
				bool res = tclm.ShowLanguageSelectionDialog(this);
				if (res == true && LocalMenu != null)
					LocalMenu.SetFKeyText();
			}
		}

		/// <summary>
		/// Lets users select string edit dialog.
		/// </summary>
		public void ShowStringEditDialog()
		{
			if (tclm != null)
			{
				tclm.ShowStringEditDialog(this);
			}
		}

		/// <summary>
		/// Lets users select the System Info.
		/// </summary>
		public void SystemInfoDialog()
		{
			FormSystemInfo formInfo = new FormSystemInfo();
			formInfo.ShowDialog();
		}

		/// <summary>
		/// Lets users select the settings.
		/// </summary>
		public void SettingsDialog()
		{
			FormSettings frmSettings = new FormSettings();
			frmSettings.ShowDialog();
		}

		/// <summary>
		/// Write infos to the log.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="exception">The exception.</param>
		public void LogInfo(string message, Exception exception)
		{
			if (MainApp.log != null)
				MainApp.log.Info(message, exception);
		}

		/// <summary>
		/// Write warnings to the log.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="exception">The exception.</param>
		public void LogWarn(string message, Exception exception)
		{
			if (MainApp.log != null)
				MainApp.log.Warn(message, exception);
		}

		/// <summary>
		/// Write errors to the log.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="exception">The exception.</param>
		public void LogError(string message, Exception exception)
		{
			if (MainApp.log != null)
				MainApp.log.Error(message, exception);
		}

		/// <summary>
		/// Write fatal errors to the log.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="exception">The exception.</param>
		public void LogFatal(string message, Exception exception)
		{
			if (MainApp.log != null)
				MainApp.log.Fatal(message, exception);
		}

		/// <summary>
		/// Writes the symbol to the Plc.
		/// </summary>
		/// <param name="symbol">The symbol.</param>
		/// <param name="value">The value.</param>
		public void WriteSymbolToPlc(string symbol, string value)
		{
			Beckhoff.Forms.TcAdsPlcServer adsPlcServer = MainApp.GetDoc().AdsPlcServer;
			if (adsPlcServer != null && adsPlcServer.PlcIsRunning)
			{
				try
				{
					adsPlcServer.PlcClient.WriteSymbol(symbol, value);
				}
				catch (Exception ex)
				{
					MainApp.log.Error(this, ex);
				}
			}
		}

		#endregion

		#region Implementation of Function Keys
		
		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
			fKey.FKeyTextAlign = System.Drawing.ContentAlignment.BottomLeft;
			fKey.FKeyImageAlign = System.Drawing.ContentAlignment.TopCenter;
			fKey.FKeyText(11, tclm.GetString("FormMain.tcFKey1[11]", "Exit"), null, System.Drawing.Color.Red);
		}

		public override void FKeyDownEvent(int nIdx)
		{
			switch (nIdx)
			{
				case 1:
					break;
			}
		}

		public override void FKeyUpEvent(int nIdx)
		{
			switch (nIdx)
			{
				case 11:
					ParentForm.Close();
					break;
			}
		}

		private void FormMain_Activated(object sender, System.EventArgs e)
		{
			Beckhoff.App.TcFKey fKey = MainApp.GetDoc().tcFKey1;
			fKey.FKeySelectedMode = false;
		}

		#endregion

		#region Events

		private void FormMain_Load(object sender, System.EventArgs e)
		{
			ShowPicture(Application.StartupPath + "\\Bitmap\\BeckhoffMain.jpg");
			tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
			LoadLanguageStrings();
		}

		protected override void OnResize(EventArgs e)
		{
			//base.OnResize (e);

			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized;

			if (pictureBox1 != null)
			{
				pictureBox1.Top = (this.Height - pictureBox1.Height) / 2 - 10;
				pictureBox1.Left = (this.Width - pictureBox1.Width) / 2;
			}
		}

		#endregion

		#region Private functions
		
		private void LoadLanguageStrings()
		{
		}

		private void ShowPicture(string pictureFile)
		{
			// Sets up an image object to be displayed.
			if (mainScreenBitmap != null)
			{
				mainScreenBitmap.Dispose();
			}

			try
			{
				// Stretches the image to fit the pictureBox.
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
				mainScreenBitmap = new Bitmap(pictureFile);
				pictureBox1.ClientSize = new Size(524, 374);
				pictureBox1.Image = (Image)mainScreenBitmap;
			}
			catch
			{
				MessageBox.Show("MainScreen Bitmap '" + pictureFile + "' cannot be found!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		#endregion

	}
}
