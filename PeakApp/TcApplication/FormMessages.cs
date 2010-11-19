using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Beckhoff.App.TCLManager;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	/// <summary>
	/// Handles active and logged messages, use of TwinCAT EventLogger.
	/// </summary>
	public partial class FormMessages : FormTcApp
	{
		Settings settings;
		bool mustSaveSettings = false;
		string eventLogStatusTag = "FormMessages.labelEventLogStatus.ActiveEvents";

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FormMessages"/> class.
		/// </summary>
		/// <param name="form">The form.</param>
		public FormMessages(Form form)
		{
			parentForm = form;
			InitializeComponent();

			settings = MainApp.appSettings;
			string amsNetId = settings.amsNetId;
			if (!string.IsNullOrEmpty(amsNetId))
				tcEventLoggerData1.Connection = Beckhoff.EventLogger.ConnectionType.Ads;
			tcEventLoggerData1.AdsServerNetId = amsNetId;
			tclm = MainApp.GetDoc().GetTCLanguageManager();

			tcEventLoggerData1.EventChanged += new Beckhoff.EventLogger.TcEventChangedEventHandler(tcEventLoggerData1_EventChanged);
			tcEventLoggerData1.InstructionEventChanged += new Beckhoff.EventLogger.TcEventChangedEventHandler(tcEventLoggerData1_InstructionEventChanged);
			tcEventLoggerData1.GetActiveEvents();
			labelEventLogStatus.Text = "Active Events";
			cBLanguage.SelectedIndex = settings.eventlogLanguage;

			tcLog4NetView1.FileName = Application.StartupPath + "\\program.log";

			tcEventLoggerList1.ColumnReordered += new ColumnReorderedEventHandler(tcEventLoggerList1_ColumnReordered);
			tcEventLoggerList1.ColumnWidthChanging += new ColumnWidthChangingEventHandler(tcEventLoggerList1_ColumnWidthChanging);

			labelEventLogStatus.BackColor = MainApp.GetDoc().ColorCaption;
			tcEventLoggerList1.CaptionColor = MainApp.GetDoc().ColorCaption;
			tcLog4NetView1.CaptionColor = MainApp.GetDoc().ColorCaption;
			MainApp.GetDoc().tcUserAdmin1.CurrentUserChanged += new Beckhoff.App.Security.TcUserAdmin.CurrentUserChangedEventHandler(tcUserAdmin1_CurrentUserChanged);
		}

		/// <summary>
		/// Sets the parent form.
		/// </summary>
		/// <param name="form">The form.</param>
		public void SetParentForm(Form form)
		{
			parentForm = form;
		}

		#region Implementation of Function Keys

		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
			fKey.FKeyText(1, tclm.GetString("FormMessages.tcFKey1[1]", "View Active"));
			fKey.FKeyText(2, tclm.GetString("FormMessages.tcFKey1[2]", "View Logged"));
			fKey.FKeyText(3, tclm.GetString("FormMessages.tcFKey1[3]", "Show Details"));
			fKey.FKeyText(5, tclm.GetString("FormMessages.tcFKey1[5]", "Clear Active"));
			fKey.FKeyText(6, tclm.GetString("FormMessages.tcFKey1[6]", "Clear Logged"));
			fKey.FKeyText(7, tclm.GetString("FormMessages.tcFKey1[7]", "Save Logged"));

			fKey.FKeyEnabled(5, false);
			fKey.FKeyEnabled(6, tcLog4NetView1.Visible);
			fKey.FKeyEnabled(7, tcLog4NetView1.Visible);
		}

		public override void FKeyUpEvent(int nIdx)
		{
			switch (nIdx)
			{
				case 1:
					cBLanguage.Visible = true;
					buttonLocate.Visible = true;
					eventLogStatusTag = "FormMessages.labelEventLogStatus.ActiveEvents";
					tcEventLoggerData1.GetActiveEvents();	// not absolutely necessary
					LoadLanguageStrings();
					tcEventLoggerList1.Focus();
					tcLog4NetView1.ShowEvents(false);
					MainApp.GetDoc().tcFKey1.FKeyEnabled(6, false);
					MainApp.GetDoc().tcFKey1.FKeyEnabled(7, false);
					break;
				case 2:
					cBLanguage.Visible = false;
					buttonLocate.Visible = false;
					eventLogStatusTag = "FormMessages.labelEventLogStatus.LoggedEvents";
					LoadLanguageStrings();
					tcLog4NetView1.ShowEvents(true);
					MainApp.GetDoc().tcFKey1.FKeyEnabled(6, true);
					MainApp.GetDoc().tcFKey1.FKeyEnabled(7, true);

					/*
					try
					{
						eventLogStatusTag = "FormMessages.labelEventLogStatus.LoggedEvents";
						tcEventLoggerData1.GetAllLoggedEvents();
					}
					catch {}
					LoadLanguageStrings();
					tcEventLoggerList1.Focus();
					*/
					break;
				case 3:
					if (tcLog4NetView1.Visible == true)
					{
						tcLog4NetView1.ShowDetailWindow = !tcLog4NetView1.ShowDetailWindow;
						tcLog4NetView1.Focus();
					}
					else
					{
						tcEventLoggerList1.ShowDetailWindow = !tcEventLoggerList1.ShowDetailWindow;
						tcEventLoggerList1.Focus();
					}
					break;
				case 5:
					eventLogStatusTag = "FormMessages.labelEventLogStatus.ActiveEvents";
					tcEventLoggerData1.ClearActiveEvents();
					LoadLanguageStrings();
					break;
				case 6:
					try
					{
						string logFile = tcLog4NetView1.FileName;
						DialogResult msgBoxRes = new DialogResult();
						// make a copy
						msgBoxRes = MessageBox.Show("Do you want to save the logfile before clearing it?", "Save logfile",
							MessageBoxButtons.YesNoCancel,
							MessageBoxIcon.Question);
						if (msgBoxRes == DialogResult.Yes)
						{
							SaveFileDialog dlg = new SaveFileDialog();
							dlg.Filter = "LOG files (*.log)|*.log|All files (*.*)|*.*"; ;
							dlg.RestoreDirectory = true;
							if (dlg.ShowDialog() == DialogResult.OK)
							{
								System.IO.File.Copy(logFile, dlg.FileName, true);
							}
						}

						// delete logfile
						if (msgBoxRes == DialogResult.Yes
							|| msgBoxRes == DialogResult.No)
						{
							log4net.LogManager.GetRepository().ResetConfiguration();
							log4net.LogManager.GetRepository().Shutdown();
							System.IO.File.Delete(logFile);

							log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Application.StartupPath + "\\System\\log.xml"));
							MainApp.log.Info("Log file has been deleted by " + LocalMenu.UserAdmin.CurrentUser.Name
								+ " (" + LocalMenu.UserAdmin.CurrentUser.FullName + ")");
							tcLog4NetView1.ShowEvents();
						}
					}
					catch { }
					break;
				case 7:
					try
					{
						// make a copy
						string logFile = tcLog4NetView1.FileName;
						SaveFileDialog dlg = new SaveFileDialog();
						dlg.Filter = "LOG files (*.log)|*.log|All files (*.*)|*.*"; ;
						dlg.RestoreDirectory = true;
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							System.IO.File.Copy(logFile, dlg.FileName, true);
						}
					}
					catch { }
					break;
			}
		}

		#endregion

		#region Events

		private void FormMessages_Load(object sender, System.EventArgs e)
		{
			tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
			LoadLanguageStrings();
			tcEventLoggerList1.Focus();
			SetViewSettings();
		}

		private void FormMessages_Activated(object sender, System.EventArgs e)
		{
			if (tcLog4NetView1.Visible == true)
				tcLog4NetView1.ShowEvents();
		}

		private void FormMessages_Deactivate(object sender, EventArgs e)
		{
			SaveSettings();
		}

		void tcUserAdmin1_CurrentUserChanged(Beckhoff.App.Security.TcUser user, bool logOn)
		{
			if (logOn)
			{
				if (user.UserLevel == Beckhoff.App.Security.TcUserLevel.Administrator)
					tcEventLoggerList1.AllowColumnReorder = true;
				else
					tcEventLoggerList1.AllowColumnReorder = false;
			}
		}

		private void tcEventLoggerData1_EventChanged(Beckhoff.EventLogger.TcEventItem eventItem, Beckhoff.EventLogger.TcEventType eventType)
		{
			if (eventItem == null)
				return;

			// route message to the log4net, if an error happens...
			if (eventItem.Class == (int)Beckhoff.EventLogger.TcEventClass.Alarm)
				MainApp.log.Error(eventItem.Message);
		}

		private void tcEventLoggerData1_InstructionEventChanged(Beckhoff.EventLogger.TcEventItem eventItem, Beckhoff.EventLogger.TcEventType eventType)
		{
			if (eventItem == null)
				return;

			// route message to the main menu
			MainApp.GetDoc().MainAppMsgInfo(eventItem);
		}

		private void cBLanguage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int id = 1031;
			switch (cBLanguage.SelectedIndex)
			{
				case 0: id = 1031; break;
				case 1: id = 1033; break;
				case 2: id = 1034; break;
				case 3: id = 1036; break;
				case 4: id = 1040; break;
			}

			if (tcEventLoggerData1.LanguageId != id)
			{
				tcEventLoggerData1.LanguageId = id;
				// activate view
				eventLogStatusTag = "FormMessages.labelEventLogStatus.ActiveEvents";
				tcEventLoggerData1.GetActiveEvents();
				LoadLanguageStrings();
			}
		}

		string GetString(string message, string token)
		{
			int idx, idx2;
			idx = message.IndexOf(token);
			if (idx != -1)
			{
				idx2 = message.IndexOf("@", idx + 1);
				if (idx2 != -1)
				{
					idx += token.Length;
					return message.Substring(idx, idx2 - idx);
				}
			}
			return "";
		}

		void tcEventLoggerList1_SelectedIndexChanged(object sender, ListViewItem lvwItem)
		{
			if (lvwItem == null)
			{
				buttonLocate.Enabled = false;
				return;
			}

			if (lvwItem.SubItems[11].Text != "")
				buttonLocate.Enabled = true;
			else
				buttonLocate.Enabled = false;
		}

		private void buttonLocate_Click(object sender, EventArgs e)
		{
			string message = tcEventLoggerList1.GetSelectedAlarm();
			//string[] msg = message.Split('@');
			//string sPath = GetString(message, "@PATH:");
			string sFile = GetString(message, "@FILE:").Trim();
			string sFOffs = GetString(message, "@FOFFS:");
			string sBOffs = GetString(message, "@BOFFS:");

			if (sFile == "" || sFOffs == "" || sBOffs == "")
				return;

			// call shell process
			try
			{
				Process newProcess = new Process();
				// add standard file path for sub programs without full path
				if (!File.Exists(sFile) && File.Exists(settings.pathSettings[0] + "\\" + sFile))
					sFile = settings.pathSettings[0] + "\\" + sFile;
				newProcess.StartInfo.FileName = settings.batchProcess[4];
				newProcess.StartInfo.Arguments = "\"" + sFile + "\"" + " /FOFFS:" + sFOffs + "/BOFFS:" + sBOffs;
				newProcess.StartInfo.UseShellExecute = false;
				newProcess.StartInfo.CreateNoWindow = true;
				newProcess.StartInfo.RedirectStandardOutput = true;
				newProcess.Start();
			}
			catch
			{ }
		}

		private void LoadLanguageStrings()
		{
			// Text ListView
			tcEventLoggerList1.ColCaptionClass = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionClass", "Class", true);
			tcEventLoggerList1.ColCaptionConfirm = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionConfirm", "Confirm", true);
			tcEventLoggerList1.ColCaptionDate = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionDate", "Date", true);
			tcEventLoggerList1.ColCaptionId = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionID", "Id", true);
			tcEventLoggerList1.ColCaptionMessage = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionMessage", "Message", true);
			tcEventLoggerList1.ColCaptionSource = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionSource", "Source", true);
			tcEventLoggerList1.ColCaptionSourceName = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionSName", "Source Name", true);
			tcEventLoggerList1.ColCaptionState = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionState", "State", true);
			tcEventLoggerList1.ColCaptionPrority = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionPriority", "Priority", true);
			tcEventLoggerList1.ColCaptionTime = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionTime", "Time", true);

			// Text ListView, Detailed Messages
			tcEventLoggerList1.DetailCaptionText = tclm.GetString("FormMessages.tcEventLoggerList1.DetailCaptionText", "Detailed Messages", true);
			tcEventLoggerList1.ColCaptionNr = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionNr", "Nr", true);
			tcEventLoggerList1.ColCaptionDescription = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionDescr", "Description", true);
			tcEventLoggerList1.ColCaptionValue = tclm.GetString("FormMessages.tcEventLoggerList1.ColCaptionValue", "Value", true);

			// Text Logged Event View
			tcLog4NetView1.ColCaptionDate = tclm.GetString("FormMessages.tcEventLogView1.ColCaptionDate", "Date", true);
			tcLog4NetView1.ColCaptionTime = tclm.GetString("FormMessages.tcEventLogView1.ColCaptionTime", "Time", true);
			tcLog4NetView1.ColCaptionThread = tclm.GetString("FormMessages.tcEventLogView1.ColCaptionThread", "Thread", true);
			tcLog4NetView1.ColCaptionLevel = tclm.GetString("FormMessages.tcEventLogView1.ColCaptionLevel", "Level", true);
			tcLog4NetView1.ColCaptionModule = tclm.GetString("FormMessages.tcEventLogView1.ColCaptionModule", "Module", true);
			tcLog4NetView1.ColCaptionMessage = tclm.GetString("FormMessages.tcEventLogView1.ColCaptionMessage", "Message", true);
			tcLog4NetView1.ColCaptionMsgExt = tclm.GetString("FormMessages.tcEventLogView1.ColCaptionMsgExt", "MsgExt", true);
			tcLog4NetView1.DetailCaptionText = tclm.GetString("FormMessages.tcEventLoggerList1.DetailCaptionText", "Detailed Messages", true);

			// Text Logged Event View, filter buttons
			tcLog4NetView1.ButtonErrorText = tclm.GetString("FormMessages.tcEventLogView1.ButtonErrorText", "Errors", true);
			tcLog4NetView1.ButtonWarningText = tclm.GetString("FormMessages.tcEventLogView1.ButtonWarningText", "Warnings", true);
			tcLog4NetView1.ButtonMessageText = tclm.GetString("FormMessages.tcEventLogView1.ButtonMessageText", "Messages", true);

			labelEventLogStatus.Text = tclm[eventLogStatusTag];
		}

		void tcEventLoggerList1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
		{
			mustSaveSettings = true;
		}

		void tcEventLoggerList1_ColumnReordered(object sender, ColumnReorderedEventArgs e)
		{
			mustSaveSettings = true;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized;
		}

		#endregion

		#region Private Functions

		void SetViewSettings()
		{
			tcEventLoggerList1.ShowCol = settings.eventlogColStatus;

			int nMin = settings.eventlogColWidth.GetLowerBound(0);
			int nMax = settings.eventlogColWidth.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				if (settings.eventlogColWidth[i] != -1)
					tcEventLoggerList1.SetListViewColumn(i, settings.eventlogColWidth[i]);
				tcEventLoggerList1.SetListViewDisplayIndex(i, settings.eventlogColDisplayOrder[i]);
			}
		}

		void SaveSettings()
		{
			if (mustSaveSettings == false)
				return;

			mustSaveSettings = false;
			int nMin = settings.eventlogColWidth.GetLowerBound(0);
			int nMax = settings.eventlogColWidth.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				settings.eventlogColWidth[i] = tcEventLoggerList1.SetListViewColumn(i, -1);
				settings.eventlogColDisplayOrder[i] = tcEventLoggerList1.SetListViewDisplayIndex(i, -1);
			}
		}

		#endregion

	}
}
