using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwinCAT.App.ManualFunctions;
using Beckhoff.App.TCLManager;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	public partial class FormManual : FormTcApp
	{
		int pageNumber = 1;
		int groupSelected = 0;
		bool[] plcFKeyRightStatus;
		bool[] plcFKeyLeftStatus;

		public FormManual(Form form)
		{
			parentForm = form;
			InitializeComponent();

			tclm = MainApp.GetDoc().GetTCLanguageManager();

			// Delegate instance: PLC function keys left
			plcFKeyRightStatus = new bool[8];
			plcFKeyLeftStatus = new bool[8];
			tcAppPlcManual1.ActiveBackColor = MainApp.GetDoc().ColorCaption;
			tcAppPlcManual1.HeadBackColor = MainApp.GetDoc().ColorCaption;
			groupSelected = 1;
		}

		#region Public functions

		/// <summary>
		/// Sets the parent form.
		/// </summary>
		[Description("Sets the parent form."), Category("TcApplication")]
		public void SetParentForm(Form form)
		{
			parentForm = form;
		}

		/// <summary>
		/// Gets or sets the current group of the manual table.
		/// </summary>
		[Description("Gets or sets the current group of the manual table."), Category("TcApplication")]
		public void CurrentGroup(int group)
		{
			tcAppPlcManual1.SetCurrentGroup(group - 1);

			// Mark the button as selected, if the standard groups are used
			Beckhoff.App.TcFKey fKey = MainApp.GetDoc().tcFKey1;
			fKey.FKeySelectedMode = true;
			if (group > 0 && group <= 12)
			{
				groupSelected = group;
				fKey.FKeyBtnSelected = groupSelected;
			}
		}

		/// <summary>
		/// Gets or sets the current page of the manual table.
		/// </summary>
		[Description("Gets or sets the current page of the manual table."), Category("TcApplication")]
		public int CurrentPage
		{
			get { return pageNumber; }
			set { pageNumber = value; }
		}

		/// <summary>
		/// Gets or sets the active row.
		/// </summary>
		/// <value>The active row.</value>
		public int ActiveRow
		{
			get { return tcAppPlcManual1.ActiveRow; }
			set { tcAppPlcManual1.ActiveRow = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether [F key selected mode].
		/// </summary>
		/// <value><c>true</c> if [F key selected mode]; otherwise, <c>false</c>.</value>
		public bool FKeySelectedMode
		{
			set
			{
				MainApp.GetDoc().tcFKey1.FKeySelectedMode = value;
			}
		}

		#endregion

		#region Implementation of Function Keys

		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
			fKey.FKeySelectedMode = true;

			int pageNr = (pageNumber - 1) * 20;
			for (int group = 1; group < 12; group++)
			{
				string sIdx = (pageNr + group).ToString();
				string tmp = tclm.GetString("FormManual.tcFKey1[" + sIdx + "]", "Group " + sIdx, true);
				fKey.FKeyText(group, tmp);
				fKey.FKeyEnabled(group, !tmp.StartsWith(" "));
			}

			if (fKey.FKeySelectedMode)
			{
				fKey.FKeyBtnSelected = groupSelected;
			}
		}

		public override void FKeyDownEvent(int nIdx)
		{
			try
			{
				switch (nIdx)
				{
					case 10:
						this.tcAppPlcManual1.Message = "Dies ist eine Meldung !!!";
						break;
				}
			}
			catch
			{ }
		}

		public override void FKeyUpEvent(int nIdx)
		{
			int group = (nIdx - 1) + (pageNumber - 1) * 20;

			try
			{
				switch (nIdx)
				{
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
						//Page 1 - Group 1..11
						//Page 2 - Group 21..31
						tcAppPlcManual1.SetCurrentGroup(group);
						groupSelected = nIdx;

						break;
					case 12:
						MainApp.GetDoc().tcFKey1.FKeySelectedMode = false;
						parentForm.BringToFront();
						break;
				}
			}
			catch
			{ }
		}

		private void Form_Activated(object sender, System.EventArgs e)
		{
			// Only the Administrator can change the configuration
			if (MainApp.GetDoc().tcUserAdmin1.CurrentUserLevel == Beckhoff.App.Security.TcUserLevel.Administrator)
				this.buttonMode.Visible = true;
			else
				this.buttonMode.Visible = false;

			if (MainApp.appSettings.applicationManualTreeView == true)
				tcAppPlcManual1.TreeVisible = true;
			else
				tcAppPlcManual1.TreeVisible = false;
		}

		/// <summary>
		/// Must be called if the form is still open and other function keys are needed
		/// </summary>
		public void ActivateFKeys()
		{
			Form_Activated(this, null);
		}

		#endregion

		#region Events
		
		private void FormManual_Load(object sender, System.EventArgs e)
		{
			tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
			try
			{
				LoadData();
				LoadLanguageStrings();
				//MainApp.GetDoc().ManualMsgInfo +=new TcApplication.MainApp.ManualMsgInfoDelegate(FormManual_ManualMsgInfo);
			}
			catch
			{ }
		}

		private void buttonMode_Click(object sender, System.EventArgs e)
		{
			if (tcAppPlcManual1.Mode != DisplayMode.Edit)
			{
				buttonSave.Visible = true;
				tcAppPlcManual1.Mode = DisplayMode.Edit;
			}
			else
			{
				buttonSave.Visible = false;
				tcAppPlcManual1.Mode = DisplayMode.Show;
			}
		}

		private void buttonSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				//tcAppPlcManualData1.FileName = "Manual.dat";
				tcAppPlcManualData1.Write();
				WriteCurrentLanguageStringsToDB();
			}
			catch (System.IO.FileNotFoundException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/*
		 * If there is an information message from the eventlogger
		 * this message is shown to Manual Mode screen
		 */
		private void FormManual_ManualMsgInfo(int state, int alarmclass, int sourceId, int eventId, string message)
		{
			if (alarmclass == 5)			// Instruction
			{
				if (state == 1)			// set
					tcAppPlcManual1.Message = message;
				else if (state == 2)		// clear
					tcAppPlcManual1.Message = "";
			}
		}

		private void FormManual_PLCFKeyLeft(bool[] plcKeys)
		{
			if (MainApp.GetDoc().ActiveMdiChild is TcApplication.FormManual)
			{
				for (int i = 0; i < 8; i++)
				{
					if (plcKeys[i] != plcFKeyLeftStatus[i])
					{
						plcFKeyLeftStatus[i] = plcKeys[i];
						this.tcAppPlcManual1.SetLeftFunc(i, plcKeys[i]);
					}
				}
			}
		}

		private void FormManual_PLCFKeyRight(bool[] plcKeys)
		{
			if (MainApp.GetDoc().ActiveMdiChild is TcApplication.FormManual)
			{
				for (int i = 0; i < 8; i++)
				{
					if (plcKeys[i] != plcFKeyLeftStatus[i])
					{
						plcFKeyLeftStatus[i] = plcKeys[i];
						this.tcAppPlcManual1.SetRightFunc(i, plcKeys[i]);
					}
				}
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized;
		}

		#endregion

		#region Private functions

		private void LoadData()
		{
			try
			{
				tcAppPlcManualData1.FileName = MainApp.GetDoc().SystemFolder + "\\Manual.dat";
				tcAppPlcManualData1.Read();

				tcAppPlcManual1.VisibleRowCount = 8;
				tcAppPlcManual1.Font = new Font("Arial", 18);
				tcAppPlcManual1.DataSource = tcAppPlcManualData1;

				tcAppPlcManual1.SetCurrentGroup(0);	// see SetFunctionKeys
			}
			catch (System.IO.FileNotFoundException ex)
			{
				MainApp.log.Error("Error loading manual data.", ex);
				MessageBox.Show(ex.Message);
			}
		}

		private void LoadLanguageStrings()
		{
			foreach (plcManualGroup group in tcAppPlcManualData1.Groups)
			{
				group.Caption = tclm.GetString(this.Name + "." + group.Name + ".Caption", group.Caption, false);
				foreach (plcManualEntry entry in group.Entrys.Values)
				{
					entry.Caption = tclm.GetString(this.Name + "." + group.Name + ".Entry[" + entry.Index + "].Caption", entry.Caption, false);
					entry.MinusCaption = tclm.GetString(this.Name + "." + group.Name + ".Entry[" + entry.Index + "].MinusCaption", entry.MinusCaption, false);
					entry.PlusCaption = tclm.GetString(this.Name + "." + group.Name + ".Entry[" + entry.Index + "].PlusCaption", entry.PlusCaption, false);
				}
			}

			tcAppPlcManual1.RefreshAll();
		}

		private void WriteCurrentLanguageStringsToDB()
		{
			string tmp;
			foreach (plcManualGroup group in tcAppPlcManualData1.Groups)
			{
				tmp = this.Name + "." + group.Name + ".Caption";
				if (string.IsNullOrEmpty(tclm[tmp]))
					// writes the default string to all languages
					tclm.GetString(tmp, group.Caption);
				else
					// changes the string of the current language
					tclm[tmp] = group.Caption;

				int line = 1;
				foreach (plcManualEntry entry in group.Entrys.Values)
				{
					tmp = this.Name + "." + group.Name + ".Entry[" + entry.Index + "].Caption";
					if (string.IsNullOrEmpty(tclm[tmp]))
						tclm.GetString(tmp, entry.Caption);
					else
						tclm[tmp] = entry.Caption;

					tmp = this.Name + "." + group.Name + ".Entry[" + entry.Index + "].MinusCaption";
					if (string.IsNullOrEmpty(tclm[tmp]))
						tclm.GetString(tmp, entry.MinusCaption);
					else
						tclm[tmp] = entry.MinusCaption;

					tmp = this.Name + "." + group.Name + ".Entry[" + entry.Index + "].PlusCaption";
					if (string.IsNullOrEmpty(tclm[tmp]))
						tclm.GetString(tmp, entry.PlusCaption);
					else
						tclm[tmp] = entry.PlusCaption;

					line++;
				}
			}
		}

		#endregion

	}
}
