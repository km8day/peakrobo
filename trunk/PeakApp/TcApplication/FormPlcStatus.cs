using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Beckhoff.Forms;
using Beckhoff.App.PlcStatus;
using Beckhoff.App.TCLManager;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	/// <summary>
	/// Summary description for FormPlcStatus.
	/// </summary>
	public partial class FormPlcStatus : FormTcApp
	{
		TcAdsPlcServer adsPlcServer;
		bool enableFKeyFunc = true;

		public FormPlcStatus(Form form)
		{
			parentForm = form;
			InitializeComponent();

			tclm = MainApp.GetDoc().GetTCLanguageManager();
			tcPlcStatus1.LanguageManager = tclm;
			tcPlcStatus1.UserLevel = MainApp.GetDoc().tcUserAdmin1.CurrentUserLevel;
			MainApp.GetDoc().tcUserAdmin1.CurrentUserChanged += new Beckhoff.App.Security.TcUserAdmin.CurrentUserChangedEventHandler(tcUserAdmin1_CurrentUserChanged);

			// error handler
			tcPlcStatus1.Error += new TcPlcStatus.PlcStatusErrorEventHandler(tcPlcStatus1_Error);

			if (tcPlcStatus1.Read(Application.StartupPath + "\\System\\PLCStatus.ini") == false)
				MainApp.log.Error("PLC status ini file could not be found! \\System\\PLCStatus.ini");
			adsPlcServer = MainApp.GetDoc().AdsPlcServer;

			labelCaption.BackColor = MainApp.GetDoc().ColorCaption;
		}

		#region Public functions

		/// <summary>
		/// Enables/Disables the form internal function keys.
		/// </summary>
		public void EnableFKeyFunction(bool bEnable)
		{
			enableFKeyFunc = bEnable;
		}

		/// <summary>
		/// Gets or sets the current group of the machine parameter list.
		/// </summary>
		[Description("Gets or sets the current group of the machine parameter list."), Category("TcApplication")]
		public void CurrentList(int list, string name)
		{
			if (string.IsNullOrEmpty(name))
				tcPlcStatus1.CurrentList(list);
			else
				tcPlcStatus1.CurrentList(name);
		}

		/// <summary>
		/// Gets or sets the current group of the machine parameter list.
		/// </summary>
		[Description("Gets or sets the current row of the machine parameter list."), Category("TcApplication")]
		public void CurrentRow(int row)
		{
			tcPlcStatus1.CurrentRow(row);
		}

		#endregion

		#region Implementation of Function Keys

		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
			if (enableFKeyFunc)
			{
				fKey.FKeyText(7, "Save", Image.FromFile(Application.StartupPath + "\\Bitmap\\Save.ico"));
			}
			fKey.FKeyImageAlign = System.Drawing.ContentAlignment.TopRight;
		}

		public override void FKeyUpEvent(int nIdx)
		{
			switch (nIdx)
			{
				case 7:
					//tcPlcStatus1.WriteConfig();
					//tcPlcStatus1.WriteData();

					if (tcPlcStatus1.ConfigHasChanged)
					{
						//writes the configuration and data
						tcPlcStatus1.Write();
						//writes the language strings to the database
						WriteCurrentLanguageStringsToDB();
					}
					else
						//writes the data only
						tcPlcStatus1.WriteData();
					break;
			}
		}

		private void Form_Activated(object sender, System.EventArgs e)
		{
			// is needed because we use a flicker free listview
			tcPlcStatus1.Refresh();

			timer1.Enabled = true;
			// trigger the timer
			timer1_Tick(null, null);
		}

		#endregion

		#region Events

		private void FormPlcStatus_Load(object sender, System.EventArgs e)
		{
			tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
			LoadLanguageStrings();
		}

		void tcPlcStatus1_Error(object sender, string message)
		{
			MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			MainApp.log.Error(message);
		}

		void tcUserAdmin1_CurrentUserChanged(Beckhoff.App.Security.TcUser user, bool logOn)
		{
			if (logOn == true)
				tcPlcStatus1.UserLevel = user.UserLevel;
		}

		private void FormPlcStatus_Deactivate(object sender, System.EventArgs e)
		{
			timer1.Enabled = false;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				Beckhoff.App.PlcStatus.PlcStatusData data;
				if (MainApp.GetDoc().ActiveMdiChild is TcApplication.FormPlcStatus
					&& adsPlcServer != null
					&& adsPlcServer.PlcIsRunning)
				{
					// get reference from PLC list object
					Beckhoff.App.PlcStatus.PlcStatusList list = tcPlcStatus1.SelectedList;
					if (list != null && list.Disabled == false)
					{
						for (int i = tcPlcStatus1.TopItemIndex; i < list.Data.Count; i++)
						{
							data = (Beckhoff.App.PlcStatus.PlcStatusData)list.Data[i];
							if (data.PlcVarName != "")
							{
								TwinCAT.Ads.ITcAdsSymbol sym;
								object obj = adsPlcServer.PlcClient.ReadSymbol(data.PlcVarName, out sym);
								if (obj != null)
								{
									tcPlcStatus1.SetListViewText(i, 2, obj.ToString());
									tcPlcStatus1.SetListViewText(i, 5, sym.Comment);
								}
							}
						}
					}
				}
				else
				{
					Beckhoff.App.PlcStatus.PlcStatusList list = tcPlcStatus1.SelectedList;
					for (int i = tcPlcStatus1.TopItemIndex; i < list.Data.Count; i++)
					{
						tcPlcStatus1.SetListViewText(i, 2, "");
						tcPlcStatus1.SetListViewText(i, 5, "");
					}
				}
			}
			catch (Exception ex)
			{
				//MainApp.log.Error("Error in FormPlcStatus timer1_Tick()", ex);
			}
		}

		const short WM_PAINT = 0x00f;
		public static bool _Paint = true;
		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == 5)
				return;

			// sometimes we want to eat the paint message so we don't have to see all the 
			//  flicker from when we select the text to change the color.
			if (m.Msg == WM_PAINT)
			{
				if (_Paint)
					base.WndProc(ref m);
				else
					m.Result = IntPtr.Zero;
			}
			else
				base.WndProc(ref m);
		}

		#endregion

		private void LoadLanguageStrings()
		{
			labelCaption.Text = tclm.GetString("FormPlcStatus.labelCaption", "PLC Status");

			foreach (PlcStatusList list in tcPlcStatus1.PlcStatus.Lists)
			{
				list.Description = tclm.GetString("PS." + list.Name + ".Description", list.Description, false);

				int line = 1;
				foreach (PlcStatusData data in list.Data)
				{
					data.Description = tclm.GetString("PS." + list.Name + ".Row[" + line.ToString("00") + "]", data.Description, false);
					line++;
				}
			}
		}

		private void WriteCurrentLanguageStringsToDB()
		{
			string tmp;
			foreach (PlcStatusList list in tcPlcStatus1.PlcStatus.Lists)
			{
				tmp = "PS." + list.Name + ".Description";
				if (string.IsNullOrEmpty(tclm[tmp]))
					// writes the default string to all languages
					tclm.GetString(tmp, list.Description);
				else
					// changes the string of the current language
					tclm[tmp] = list.Description;

				int line = 1;
				foreach (PlcStatusData data in list.Data)
				{
					tmp = "PS." + list.Name + ".Row[" + line.ToString("00") + "]";
					if (string.IsNullOrEmpty(tclm[tmp]))
						tclm.GetString(tmp, data.Description);
					else
						tclm[tmp] = data.Description;

					line++;
				}
			}
		}

	}
}
