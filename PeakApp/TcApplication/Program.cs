using System;
using System.Windows.Forms;

namespace TcApplication
{
	static class Program
	{
		[System.Runtime.InteropServices.DllImport("User32.dll")]
		static extern IntPtr SetForegroundWindow(IntPtr hWnd);

		[System.Runtime.InteropServices.DllImport("User32.dll")]
		static extern IntPtr ShowWindow(IntPtr hWnd, int nCmdShow);

		public static MainApp mainApp;
		static FormSplash formSplash;
		static bool exceptionSignaled;
		static Timer timerSplashWait;

		const int SW_RESTORE = 9;

		#region Main Entry

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);

            FormInputEncryptFile inputencrypt = new FormInputEncryptFile();
            inputencrypt.StartPosition = FormStartPosition.CenterScreen;
            if (inputencrypt.ShowDialog() == DialogResult.OK)
            {

            }
            else
                return;

			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

			if (CheckActiveProcess() == true)
			{
				Application.Exit();
				return;
			}

			ShowSplashScreen();

			// BasicConfigurator.Configure();
			log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Application.StartupPath + "\\System\\log.xml"));

			// Einschalten internes Debugging der LOG Komponenete
			// log4net.Util.LogLog.InternalDebugging = true;
			MainApp.log.Info("Application started.");

			// set the NumberGroupSeparator for all forms
			System.Globalization.CultureInfo newCultureInfo = new System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.LCID);
			newCultureInfo.NumberFormat.NumberDecimalSeparator = ".";
			newCultureInfo.NumberFormat.NumberGroupSeparator = ",";
			newCultureInfo.TextInfo.ListSeparator = ";";
			Application.CurrentCulture = newCultureInfo;

			// load the settings
			MainApp.appSettings = new Settings();
			MainApp.appSettings.FileName = Application.StartupPath + "\\System\\AppSet.xml";
			MainApp.appSettings.ReadSettings();

			mainApp = new MainApp();
			Application.Run(mainApp);
			MainApp.log.Info("Application stopped.");

			MainApp.appSettings.WriteSettings();
		}

		#endregion

		#region Public functions

		public static void ShowSplashScreen()
		{
			String[] arguments = Environment.GetCommandLineArgs();
			for (int i = 1; i < arguments.Length; i++)
			{
				if (arguments[i].StartsWith("/NoSplash"))
					return;
			}

			if (formSplash == null)
				formSplash = new FormSplash();

			if (timerSplashWait == null)
			{
				timerSplashWait = new Timer();
				timerSplashWait.Tick += new EventHandler(timerSplashWait_Tick);
			}

			formSplash.Parameters("HMI " + Application.ProductVersion,
				325, 296,
				new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				System.Drawing.Color.FromArgb(0, 104, 157),
				System.Drawing.Color.Black);
			formSplash.Show();
			Application.DoEvents();
		}

		static void timerSplashWait_Tick(object sender, EventArgs e)
		{
			timerSplashWait.Enabled = false;
			CloseSplashScreen();
		}

		public static void CloseSplashScreen(int interval)
		{
			if (interval < 1)
				interval = 1;

			if (timerSplashWait != null)
			{
				timerSplashWait.Interval = interval;
				timerSplashWait.Enabled = true;
			}
		}

		public static void CloseSplashScreen()
		{
			if (formSplash != null)
			{
				formSplash.Close();
				formSplash.Dispose();
				formSplash = null;
			}
		}

		public static void BringSplashToFront()
		{
			if (formSplash != null)
				formSplash.BringToFront();
		}

		public static void SplashTopMost(bool level)
		{
			if (formSplash != null)
				formSplash.TopMost = level;
		}

		#endregion

		#region Private functions

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			if (!exceptionSignaled)
			{
				exceptionSignaled = true;

				MainApp.log.Fatal(sender, e.Exception);
				Beckhoff.App.ExceptionDialog exc = new Beckhoff.App.ExceptionDialog();
				exc.SetText(Application.ProductName + " has encountered a problem.\r\n"
					+ "For further information take a look to the application event log!",
					e.Exception);
				exc.ShowDialog();
				exceptionSignaled = !exc.ExceptionSignaledChecked;
				exc.Dispose();
				exc = null;
			}
		}

		private static bool CheckActiveProcess()
		{
			try
			{
				int c = System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length;
				if (c > 0)
				{
					bool bFoundSame = false;
					foreach (System.Diagnostics.Process pr in System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName))
					{
						if (pr.MainModule.FileName == Application.ExecutablePath && pr.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
						{
							SetForegroundWindow(pr.MainWindowHandle);
							// 9 = SW_RESTORE (winuser.h)
							ShowWindow(pr.MainWindowHandle, SW_RESTORE);

							bFoundSame = true;
						}
					}
					return bFoundSame;
				}
				else
				{
					return false;
				}
			}
			catch //(System.Security.SecurityException ex)
			{
				return false;
			}
		}

		#endregion

	}
}
