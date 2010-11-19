using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Beckhoff.App.TCLManager;

namespace TcApplication
{
	public partial class FormSettings : Form
	{
		CTCLManager tclm;
		Settings settings;
		FontDialog ncFontDialog;

		public FormSettings()
		{
			InitializeComponent();

			tclm = MainApp.GetDoc().GetTCLanguageManager();
			settings = MainApp.appSettings;
			SetToScreen();
			labelTitle.BackColor = MainApp.GetDoc().ColorCaption;

			ncFontDialog = new FontDialog();
			ncFontDialog.Apply += new EventHandler(ncFontDialog_Apply);
		}

		private void FormSettings_Load(object sender, System.EventArgs e)
		{
			tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
			LoadLanguageStrings();
		}

		private void LoadLanguageStrings()
		{
			this.tabPage1.Text = tclm["FormSettings.tabPage1"];		//"General";
			this.labelStartUpScreen.Text = tclm.GetString("FormSettings.checkBoxStartupCNCScreen", "Startup screen", true);
			this.checkBoxStartMax.Text = tclm.GetString("FormSettings.checkBoxStartMax", "Start Maximized", true);
			this.checkBoxViewStatusBar.Text = tclm.GetString("FormSettings.checkBoxViewStatusBar", "View Status Bar", true);
			this.checkBoxApplicationFrame.Text = tclm.GetString("FormSettings.checkBoxApplicationFrame", "Show Application Frame", true);
			this.groupBoxTargetSystem.Text = tclm["FormSettings.groupBoxTargetSystem"];
			this.groupBoxGeneralSettings.Text = tclm["FormSettings.groupBoxGeneralSettings"];
			this.checkBoxManualTreeView.Text = tclm.GetString("FormSettings.checkBoxManualTreeView", "FormManual Tree view", true);

			this.labelBatch1.Text = tclm["FormSettings.labelBatch1"];	//"Batch Datei PCAW Host";
			this.labelBatch2.Text = tclm["FormSettings.labelBatch2"];	//"Batch Datei PCAW Remote";
			this.labelBatch3.Text = tclm["FormSettings.labelBatch3"];	//"Batch Datei Backup";
			this.labelBatch4.Text = tclm["FormSettings.labelBatch4"];	//"Externe Werkzeugverwaltung";
			this.labelBatch5.Text = tclm["FormSettings.labelBatch5"];	//"CNC Programm-Editor";
			this.tabPage2.Text = tclm["FormSettings.tabPage2"];			//"Path";

			this.labelPath1.Text = tclm["FormSettings.labelPath1"];
			this.labelPath2.Text = tclm["FormSettings.labelPath2"];
			this.labelPath3.Text = tclm["FormSettings.labelPath3"];
			this.labelPath4.Text = tclm["FormSettings.labelPath4"];
			this.labelPath5.Text = tclm["FormSettings.labelPath5"];
			this.labelPath6.Text = tclm["FormSettings.labelPath6"];
			this.labelPath7.Text = tclm["FormSettings.labelPath7"];
			this.labelPath8.Text = tclm["FormSettings.labelPath8"];

			this.tabPage3.Text = tclm.GetString("FormSettings.tabPage3", "Eventlog", true);
			this.label10.Text = tclm.GetString("FormSettings.label10", "Refresh Time", true);
			this.labelEvtLog.Text = tclm.GetString("FormSettings.labelEvtLog", "Settings Eventlogger", true);
			this.labelEvtLogLanguage.Text = tclm.GetString("FormSettings.labelEvtLogLanguage", "Language", true);

			this.label12.Text = tclm.GetString("FormSettings.label12", "ms", true);
			this.buttonSave.Text = tclm.GetString("FormSettings.buttonSave", "Save", true);
			this.buttonCancel.Text = tclm.GetString("FormSettings.buttonCancel", "Cancel", true);
			this.labelTitle.Text = tclm.GetString("FormSettings.labelTitle", "Application Settings", true);

			this.Text = tclm.GetString("FormSettings", "Settings", true);
		}

		private void buttonPath1_Click(object sender, System.EventArgs e)
		{
			this.textBoxPath1.Text = SelectPath(this.textBoxPath1.Text);
		}
		private void buttonPath2_Click(object sender, System.EventArgs e)
		{
			this.textBoxPath2.Text = SelectPath(this.textBoxPath2.Text);
		}
		private void buttonPath3_Click(object sender, System.EventArgs e)
		{
			this.textBoxPath3.Text = SelectPath(this.textBoxPath3.Text);
		}
		private void buttonPath4_Click(object sender, System.EventArgs e)
		{
			this.textBoxPath4.Text = SelectPath(this.textBoxPath4.Text);
		}
		private void buttonPath5_Click(object sender, System.EventArgs e)
		{
			this.textBoxPath5.Text = SelectPath(this.textBoxPath5.Text);
		}
		private void buttonPath6_Click(object sender, System.EventArgs e)
		{
			this.textBoxPath6.Text = SelectPath(this.textBoxPath6.Text);
		}
		private void buttonPath7_Click(object sender, System.EventArgs e)
		{
			this.textBoxPath7.Text = SelectPath(this.textBoxPath7.Text);
		}
		private void buttonPath8_Click(object sender, System.EventArgs e)
		{
			this.textBoxPath8.Text = SelectPath(this.textBoxPath8.Text);
		}
		private void buttonBatch1_Click(object sender, System.EventArgs e)
		{
			textBoxBatch1.Text = SelectFile(textBoxBatch1.Text);
		}
		private void buttonBatch2_Click(object sender, System.EventArgs e)
		{
			textBoxBatch2.Text = SelectFile(textBoxBatch2.Text);
		}
		private void buttonBatch3_Click(object sender, System.EventArgs e)
		{
			textBoxBatch3.Text = SelectFile(textBoxBatch3.Text);
		}
		private void buttonBatch4_Click(object sender, System.EventArgs e)
		{
			textBoxBatch4.Text = SelectFile(textBoxBatch4.Text);
		}
		private void buttonBatch5_Click(object sender, System.EventArgs e)
		{
			textBoxBatch5.Text = SelectFile(textBoxBatch5.Text);
		}

		private void buttonSave_Click(object sender, System.EventArgs e)
		{
			GetFromScreen();
			settings.WriteSettings();
			WriteVariableToPlc();
			Close();
		}
		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private string SelectPath(string path)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.ShowNewFolderButton = true;
			if (path == null || path == "")
				dlg.SelectedPath = Application.StartupPath;
			else
				dlg.SelectedPath = path;
			if (dlg.ShowDialog() == DialogResult.OK)
				return dlg.SelectedPath;
			else
				return path;
		}
		private string SelectFile(string fileName)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.InitialDirectory = fileName;
			//dlg.Filter = "NC files (*.nc)|*.nc|All files (*.*)|*.*";
			dlg.Filter = "All files (*.*)|*.*";
			dlg.FilterIndex = 1;
			dlg.RestoreDirectory = true;

			if (dlg.ShowDialog() == DialogResult.OK)
				return dlg.FileName;
			else
				return fileName;
		}

		private void SetToScreen()
		{
			// path settings
			textBoxPath1.Text = settings.pathSettings[0];
			textBoxPath2.Text = settings.pathSettings[1];
			textBoxPath3.Text = settings.pathSettings[2];
			textBoxPath4.Text = settings.pathSettings[3];
			textBoxPath5.Text = settings.pathSettings[4];
			textBoxPath6.Text = settings.pathSettings[5];
			textBoxPath7.Text = settings.pathSettings[6];
			textBoxPath8.Text = settings.pathSettings[7];

			// eventlogger
			AddListViewItem("FormSettings.checkBox1", "Date", settings.eventlogColStatus[0]);
			AddListViewItem("FormSettings.checkBox2", "Time", settings.eventlogColStatus[1]);
			AddListViewItem("FormSettings.checkBox3", "Confirm", settings.eventlogColStatus[2]);
			AddListViewItem("FormSettings.checkBox4", "Reset", settings.eventlogColStatus[3]);
			AddListViewItem("FormSettings.checkBox5", "Confirmed", settings.eventlogColStatus[4]);
			AddListViewItem("FormSettings.checkBox6", "Id", settings.eventlogColStatus[5]);
			AddListViewItem("FormSettings.checkBox7", "Class", settings.eventlogColStatus[6]);
			AddListViewItem("FormSettings.checkBox8", "State", settings.eventlogColStatus[7]);
			AddListViewItem("FormSettings.checkBox9", "Priority", settings.eventlogColStatus[8]);
			AddListViewItem("FormSettings.checkBox10", "Source Id", settings.eventlogColStatus[9]);
			AddListViewItem("FormSettings.checkBox11", "SourceName", settings.eventlogColStatus[10]);
			AddListViewItem("FormSettings.checkBox12", "Message", settings.eventlogColStatus[11]);
			AddListViewItem("FormSettings.checkBox13", "Reason", settings.eventlogColStatus[12]);
			AddListViewItem("FormSettings.checkBox14", "Fix", settings.eventlogColStatus[13]);

			textBoxRefreshTime.Text = settings.eventlogRefreshTime.ToString();
			comboBoxEvtLogLanguage.SelectedIndex = settings.eventlogLanguage;

			// batchProcess
			textBoxBatch1.Text = settings.batchProcess[0];
			textBoxBatch2.Text = settings.batchProcess[1];
			textBoxBatch3.Text = settings.batchProcess[2];
			textBoxBatch4.Text = settings.batchProcess[3];
			textBoxBatch5.Text = settings.batchProcess[4];

			checkBoxApplicationFrame.Checked = settings.applicationFrame;
			checkBoxStartMax.Checked = settings.applicationStartMax;
			checkBoxViewStatusBar.Checked = settings.applicationViewStatusBar;
			checkBoxManualTreeView.Checked = settings.applicationManualTreeView;
			comboBoxTaget.SelectedIndex = settings.tagetSystem;
			textBoxAmsNetId.Text = settings.amsNetId;

			numericUpDownStartup.Value = settings.applicationStartupScreen;
			comboBoxHeaderType.SelectedIndex = 0;
			if (settings.applicationHeaderType < comboBoxHeaderType.Items.Count)
				comboBoxHeaderType.SelectedIndex = settings.applicationHeaderType;
			numericUpDownColorTheme.Value = (settings.applicationColorTheme == 0) ? 1 : settings.applicationColorTheme;
			textBoxAxesValueFormat.Text = settings.axesValueOutputFormat;
			textBoxAxesRowHeight.Text = settings.axesRowHeight.ToString();

			// Cnc Page
			TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
			textBoxNcText.Font = (Font)tc.ConvertFromString(settings.ncFontName);
			textBoxNcFont.Text = settings.ncFontName;
			textBoxTabWidth.Text = settings.ncTabWidth.ToString();
			checkBoxOverrideStyle.Checked = settings.overrideStyle;
			textBoxPlcVariableFeedOverride.Text = settings.plcVarFeedOverride;
			textBoxPlcVariableSpindleOverride.Text = settings.plcVarSpindleOverride;
			if (settings.manualModeAds == 1)
				radioButtonManualModeAds.Checked = true;
			else
				radioButtonManualModePlc.Checked = true;

			// Settings
			textBoxPlcVarWriteSettings.Text = settings.plcVarWriteSettings;
			textBoxPlcVarNciOverrideChannel1.Text = settings.plcVarNciOverrideChannel1;
		}

		private void GetFromScreen()
		{
			// path settings
			settings.pathSettings[0] = textBoxPath1.Text;
			settings.pathSettings[1] = textBoxPath2.Text;
			settings.pathSettings[2] = textBoxPath3.Text;
			settings.pathSettings[3] = textBoxPath4.Text;
			settings.pathSettings[4] = textBoxPath5.Text;
			settings.pathSettings[5] = textBoxPath6.Text;
			settings.pathSettings[6] = textBoxPath7.Text;
			settings.pathSettings[7] = textBoxPath8.Text;

			// eventlogger
			for (int i = 0; i < lvEvtLogConfig.Items.Count; i++)
			{
				settings.eventlogColStatus[i] = lvEvtLogConfig.Items[i].Checked;
			}
			settings.eventlogRefreshTime = int.Parse(textBoxRefreshTime.Text);
			settings.eventlogLanguage = comboBoxEvtLogLanguage.SelectedIndex;

			// batchProcess
			settings.batchProcess[0] = textBoxBatch1.Text;
			settings.batchProcess[1] = textBoxBatch2.Text;
			settings.batchProcess[2] = textBoxBatch3.Text;
			settings.batchProcess[3] = textBoxBatch4.Text;
			settings.batchProcess[4] = textBoxBatch5.Text;

			// general settings
			settings.applicationFrame = checkBoxApplicationFrame.Checked;
			settings.applicationStartMax = checkBoxStartMax.Checked;
			settings.applicationViewStatusBar = checkBoxViewStatusBar.Checked;
			settings.applicationManualTreeView = checkBoxManualTreeView.Checked;
			settings.tagetSystem = comboBoxTaget.SelectedIndex;
			settings.amsNetId = textBoxAmsNetId.Text;

			settings.applicationStartupScreen = (int)numericUpDownStartup.Value;
			settings.applicationColorTheme = (int)numericUpDownColorTheme.Value;
			settings.axesValueOutputFormat = textBoxAxesValueFormat.Text;
			try
			{
				settings.applicationHeaderType = 0;
				settings.applicationHeaderType = comboBoxHeaderType.SelectedIndex;
				settings.axesRowHeight = 32;
				settings.axesRowHeight = int.Parse(textBoxAxesRowHeight.Text);
			}
			catch { }

			try
			{
				// Cnc page
				if (radioButtonManualModeAds.Checked == true)
					settings.manualModeAds = 1;
				else
					settings.manualModeAds = 0;

				TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
				settings.ncFontName = tc.ConvertToString(textBoxNcText.Font);
				settings.ncTabWidth = int.Parse(textBoxTabWidth.Text);
				settings.overrideStyle = checkBoxOverrideStyle.Checked;
				settings.plcVarFeedOverride = textBoxPlcVariableFeedOverride.Text;
				settings.plcVarSpindleOverride = textBoxPlcVariableSpindleOverride.Text;
			}
			catch
			{ }

			// settings
			settings.plcVarWriteSettings = textBoxPlcVarWriteSettings.Text;
			settings.plcVarNciOverrideChannel1 = textBoxPlcVarNciOverrideChannel1.Text;
		}

		void AddListViewItem(string languageKey, string defaultName, bool status)
		{
			ListViewItem item = new ListViewItem(tclm.GetString(languageKey, defaultName, true));
			lvEvtLogConfig.Items.Add(item);
			item.Checked = status;
		}

		private void buttonSelectFont_Click(object sender, EventArgs e)
		{
			ncFontDialog.ShowApply = true;
			ncFontDialog.ShowColor = true;
			ncFontDialog.Font = textBoxNcText.Font;
			if (ncFontDialog.ShowDialog() == DialogResult.OK)
			{
				textBoxNcText.Font = ncFontDialog.Font;
				textBoxNcText.ForeColor = ncFontDialog.Color;

				try
				{
					TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
					textBoxNcFont.Text = tc.ConvertToString(textBoxNcText.Font);
				}
				catch { }
			}
		}

		private void ncFontDialog_Apply(object sender, EventArgs e)
		{
			textBoxNcText.Font = ncFontDialog.Font;
			textBoxNcText.ForeColor = ncFontDialog.Color;
		}

		void WriteVariableToPlc()
		{
			try
			{
				if (!string.IsNullOrEmpty(settings.plcVarWriteSettings))
					MainApp.GetDoc().AdsPlcServer.PlcClient.WriteSymbol(settings.plcVarWriteSettings, true);
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Error in WriteVariableToPlc() ", ex);
			}
		}

		private void checkBoxOverrideStyle_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox cb = (CheckBox)sender;
			textBoxPlcVariableFeedOverride.ReadOnly = !cb.Checked;
		}

		private void buttonTargetSystem_Click(object sender, EventArgs e)
		{
			Beckhoff.Forms.TcAdsPlcServer adsPlcServer = MainApp.GetDoc().AdsPlcServer;
			Beckhoff.Forms.TcRemoteDialog remoteDlg = new Beckhoff.Forms.TcRemoteDialog();
			remoteDlg.LocalAmsNetId = adsPlcServer.PlcClient.TcAdsSystemClient.ClientNetID.ToString();
			remoteDlg.ShowDialog();
			if (remoteDlg.DialogResult == DialogResult.OK)
			{
				if (remoteDlg.IsLocal)
					textBoxAmsNetId.Clear();
				else
					textBoxAmsNetId.Text = remoteDlg.AmsNetId;
				Application.DoEvents();
				if (adsPlcServer.ClientNetId != textBoxAmsNetId.Text)
				{
					adsPlcServer.ClientNetId = textBoxAmsNetId.Text;
					adsPlcServer.PlcClient.Reconnect();
				}
			}
		}

		private void buttonEvtLogDefault_Click(object sender, EventArgs e)
		{
			DialogResult res = new DialogResult();
			res = MessageBox.Show("Do you want to restore the default logview settings?", "Default settings",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (res == DialogResult.Yes)
			{
				int nMin = settings.eventlogColWidth.GetLowerBound(0);
				int nMax = settings.eventlogColWidth.GetUpperBound(0);
				for (int i = nMin; i <= nMax; i++)
				{
					settings.eventlogColWidth[i] = -1;
					settings.eventlogColDisplayOrder[i] = i;
				}
			}
		}


	}
}
