using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Beckhoff.App.TCLManager;
using Beckhoff.Forms;
using Beckhoff.Forms.Nc;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	public partial class FormCnc : FormTcApp, IDisposable
	{
		TcAdsNcServer adsNcServer;
		TcAdsPlcServer adsPlcServer;
		CncSpecialFunctions SpecialFunc;
		OperationModeWindow OpModeWindow;
		bool[] plcFKeyRightStatus;
		bool[] plcFKeyLeftStatus;
		int selectedKeyPressChannel = 1;
		Timer TimerStatusUpdate;
		TcPlcConnect tcPlcConnectNciOvrChannel0;

		/// <summary>
		/// Cnc special functions
		/// </summary>
		private struct CncSpecialFunctions
		{
			public bool EnableHW;
			public bool SingleBlockMode;
			public bool M01Stop;
			public bool Retrace;
			public bool SkipBlock;
			public bool ManualModeRapidFeed;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FormCnc"/> class.
		/// </summary>
		/// <param name="f">The form.</param>
		public FormCnc(Form form)
		{
			parentForm = form;
			InitializeComponent();

			//resolution 800x6000
			if (MainApp.appSettings.applicationHeaderType == 1
				|| MainApp.appSettings.applicationHeaderType == 2)
			{
				int left = panelCnc.Left;
				tcFKeyLeft.Visible = false;

				int diff = tcFKeyRight.Width - 100;
				tcFKeyRight.Width = 100;

				panelCnc.Left = 0;
				panelCnc.Width += left + diff;

				panelChannelOverview.Left = 0;
				panelChannelOverview.Width += left + diff;
			}

			MainApp mainApp = MainApp.GetDoc();
			int svrPortNrNc = 0;
			if (MainApp.appSettings.tagetSystem == 0)
			{
				svrPortNrNc = 553;
			}
			else
			{
				svrPortNrNc = 501;
				blockSearch1.Enabled = false;	// no block search with NCI
				syntaxCheck1.Enabled = false;	// no syntax check with NCI
			}

			// the one and only instance of the AdsNcServer and AdsPlcServer
			string amsNetId = MainApp.appSettings.amsNetId;

			adsNcServer = new TcAdsNcServer(svrPortNrNc, amsNetId);
			adsPlcServer = new TcAdsPlcServer(801, amsNetId);

			// map the adsServer object to the main form
			mainApp.AdsPlcServer = adsPlcServer;
			mainApp.AdsNcServer = adsNcServer;

			// connect the components to the adsServer
			tcSpeedControl1.AdsNcServer = adsNcServer;
			tcAxesList1.AdsNcServer = adsNcServer;
			tcOverride1.AdsNcServer = adsNcServer;
			tcTechnoData1.AdsNcServer = adsNcServer;
			blockSearch1.AdsPlcServer = adsPlcServer;
			syntaxCheck1.AdsPlcServer = adsPlcServer;
			teachIn1.AdsPlcServer = adsPlcServer;
			teachIn1.AdsNcServer = adsNcServer;
			opModeManual1.AdsNcServer = adsNcServer;

			if (svrPortNrNc == 501 && MainApp.appSettings.plcVarNciOverrideChannel1 != "")
			{
				tcPlcConnectNciOvrChannel0 = new TcPlcConnect();
				tcPlcConnectNciOvrChannel0.PlcVariableName = MainApp.appSettings.plcVarNciOverrideChannel1;
				tcPlcConnectNciOvrChannel0.AdsPlcServer = adsPlcServer;
				tcPlcConnectNciOvrChannel0.ValueChanged += new TcPlcValueChangedEventHandler(tcPlcConnectNciOvrChannel0_ValueChanged);
			}

			plcFKeyRightStatus = new bool[8];
			plcFKeyLeftStatus = new bool[8];

			// Language Manager
			tclm = mainApp.GetTCLanguageManager();
			tcAxesList1.LanguageManager = tclm;
			tcOverride1.LanguageManager = tclm;
			tcSpeedControl1.LanguageManager = tclm;
			tcTechnoData1.LanguageManager = tclm;
			blockSearch1.LanguageManager = tclm;
			syntaxCheck1.LanguageManager = tclm;
			teachIn1.LanguageManager = tclm;

			// Operation Mode Keys
			tcFKeyOpMode.Visible = false;

			// color for the right and left keys
			tcFKeyLeft.FKeyBtnBackColor = mainApp.ColorFKeyLR;
			tcFKeyLeft.FKeyBtnSelectedColor = mainApp.ColorCaption;
			tcFKeyLeft.BackColor = mainApp.ColorFKeyLR;
			tcFKeyRight.FKeyBtnBackColor = mainApp.ColorFKeyLR;
			tcFKeyRight.FKeyBtnSelectedColor = mainApp.ColorCaption;
			tcFKeyRight.BackColor = mainApp.ColorFKeyLR;

			// Set the program name for the first channel
			opModeAuto1.selectFile1.Arguments = MainApp.appSettings.programName[1];
			opModeAuto1.tcNcProgramSection1.CncProgramName = MainApp.appSettings.programName[1];

			System.Collections.Generic.List<string> listOfSearchPaths = new System.Collections.Generic.List<string>();
			int nMin = MainApp.appSettings.pathSettings.GetLowerBound(0);
			int nMax = MainApp.appSettings.pathSettings.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				if (!string.IsNullOrEmpty(MainApp.appSettings.pathSettings[i]))
				{
					listOfSearchPaths.Add(MainApp.appSettings.pathSettings[i]);
				}
			}
			adsNcServer.NcClient.ProgramSectionPathList(listOfSearchPaths);

			opModeMDI1.MdiText = MainApp.appSettings.mdiCommand[1];

			// Delegate instance: Selecting axis in manual mode
			tcAxesList1.AxisSelectEvent += new SingleAxisSelectEventHandler(tcAxesList1_AxisSelectEvent);

			// Delegate instance: Override change
			tcOverride1.OverrideChanged += new OverrideChangedEventHandler(tcOverride1_OverrideChanged);

			// Delegate instance: TwinCAT Cnc is Running
			adsNcServer.TcNcStateChanged += new Beckhoff.Forms.Nc.TcAdsStateChangedEventHandler(adsNcServer_TcNcStateChanged);

			// Delegate instance: TwinCAT Plc is Running
			adsPlcServer.TcPlcStateChanged += new Beckhoff.Forms.TcAdsStateChangedEventHandler(adsPlcServer_TcPlcStateChanged);

			// Delegate instance: Error handling for errors from the AdsServer
			adsNcServer.NcClient.Error += new Beckhoff.Forms.Nc.TcErrorEventHandler(AdsClient_Error);
			adsPlcServer.PlcClient.Error += new Beckhoff.Forms.TcErrorEventHandler(AdsClient_Error);

			// Delegate instance: Operation mode switch
			adsNcServer.NcClient.OpModeStateChanged += new CncOpModeStateChangedEventHandler(NcClient_OpModeStateChanged);

			// Moves the operation modes key-window
			OpModeWindow = new OperationModeWindow();

			TimerStatusUpdate = new Timer();
			TimerStatusUpdate.Interval = 2000;
			TimerStatusUpdate.Tick += new EventHandler(TimerStatusUpdate_Tick);

			//
			tcChannelStatus1.AdsNcServer = adsNcServer;
			tcChannelStatus2.AdsNcServer = adsNcServer;
			tcChannelStatus3.AdsNcServer = adsNcServer;
			tcChannelStatus4.AdsNcServer = adsNcServer;
			tcChannelStatus1.ChannelNumber = 1;
			tcChannelStatus2.ChannelNumber = 2;
			tcChannelStatus3.ChannelNumber = 3;
			tcChannelStatus4.ChannelNumber = 4;

			tcAxesList2.AdsNcServer = adsNcServer;
			tcAxesList3.AdsNcServer = adsNcServer;
			tcAxesList4.AdsNcServer = adsNcServer;
			tcAxesList5.AdsNcServer = adsNcServer;
			tcAxesList2.ChannelNumber = 1;
			tcAxesList3.ChannelNumber = 2;
			tcAxesList4.ChannelNumber = 3;
			tcAxesList5.ChannelNumber = 4;
			panelChannelOverview.BringToFront();

			tcAxesList1.CaptionBackColor = mainApp.ColorCaption;
			tcChannelStatus1.BackColor = mainApp.ColorCaption;
			tcChannelStatus2.BackColor = mainApp.ColorCaption;
			tcChannelStatus3.BackColor = mainApp.ColorCaption;
			tcChannelStatus4.BackColor = mainApp.ColorCaption;
			tcSpeedControl1.CaptionBackColor = mainApp.ColorCaption;
			tcTechnoData1.CaptionBackColor = mainApp.ColorCaption;
			tcOverride1.CaptionBackColor = mainApp.ColorCaption;
			opModeAuto1.CaptionBackColor = mainApp.ColorCaption;
			opModeManual1.CaptionBackColor = mainApp.ColorCaption;
			opModeMDI1.CaptionBackColor = mainApp.ColorCaption;
			blockSearch1.CaptionBackColor = mainApp.ColorCaption;
			syntaxCheck1.CaptionBackColor = mainApp.ColorCaption;
			teachIn1.CaptionBackColor = mainApp.ColorCaption;

			tcAxesList1.AxisRowHeight = MainApp.appSettings.axesRowHeight;
			if (MainApp.appSettings.overrideStyle == true)	//changeable by screen
				tcOverride1.PlcVarFeedOverride = MainApp.appSettings.plcVarFeedOverride;
			tcOverride1.PlcVarSpindleOverride = MainApp.appSettings.plcVarSpindleOverride;
			tcOverride1.OverrideStyle = (MainApp.appSettings.overrideStyle == true) ? 2 : 1;

			if (tcOverride1.OverrideStyle == 1 && tcOverride1.PlcVarSpindleOverride.Length != 0)
			{
				SetPLCVar(tcOverride1.PlcVarSpindleOverride, 100);
				tcOverride1.SpindleOverrideValue = 100;
			}

			// Status from the NCI channel
			oldOpState.Mode = new Int16[8];
			oldOpState.State = new Int16[8];
			if (svrPortNrNc == 501)
			{
				tcPlcConnect1.AdsPlcServer = adsPlcServer;
				tcPlcConnect2.AdsPlcServer = adsPlcServer;
				tcPlcConnect1.PlcVariableName = ".PLCNciChannelState.Mode";
				tcPlcConnect2.PlcVariableName = ".PLCNciChannelState.State";
			}
		}

		/*
		 * This destructor works only if the formCnc.Dispose() function is not called
		 * but probably this moment is to late..., and causes errors!
		 */
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="T:TcApplication.FormCnc"/> is reclaimed by garbage collection.
		/// </summary>
		~FormCnc()
		{
			Dispose(false);
		}

		#region IDisposable Members

		void System.IDisposable.Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion


		#region Implementation of Function Keys

		public override void FKeyWriteSymbol(string symbol, string value)
		{
			if (adsPlcServer != null && adsPlcServer.PlcIsRunning)
			{
				try
				{
					adsPlcServer.PlcClient.WriteSymbol(symbol, value);
				}
				catch (Exception ex)
				{
					MainApp.log.Error("Error in FKeyWriteSymbol()", ex);
				}
			}
		}

		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
			fKey.FKeyTextAlign = System.Drawing.ContentAlignment.BottomLeft;
			fKey.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;

			RestoreChannelStatus();
			fKey.FKeyText(4, tclm["FormCnc.tcFKey1[4]"]);
			fKey.FKeyText(5, tclm["FormCnc.tcFKey1[5]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\ChStart.ico"));
			fKey.FKeyText(6, tclm["FormCnc.tcFKey1[6]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\ChStop.ico"));
			fKey.FKeyText(7, tclm["FormCnc.tcFKey1[7]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\ChReset.ico"));
			//fKey.FKeyText(8, tclm["FormCnc.tcFKey1[8]"]);
			//fKey.FKeyText(9, tclm["FormCnc.tcFKey1[9]"]);
			//fKey.FKeyText(10, tclm["FormCnc.tcFKey1[10]"]);
			//fKey.FKeyText(11, tclm["FormCnc.tcFKey1[11]"]);
			fKey.FKeyText(12, tclm["FormCnc.tcFKey1[12]"]);
		}

		public override void FKeyDownEvent(int nIdx)
		{
			int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
			string plcString = ".PLCMachineMode[" + selectedChannel.ToString() + "]";
			if (tcFKeyOpMode.Visible == true)
				OpModeWindow.Close(0);

			try
			{
				switch (nIdx)
				{
					case 1:
						if (MainApp.appSettings.manualModeAds == 1)
						{
							if (adsNcServer != null && adsNcServer.NcIsRunning)
								adsNcServer.NcClient.NcManual.MoveAxisNegative(SpecialFunc.ManualModeRapidFeed);
						}
						else
							SetPLCVar(".PlcManualModeLeftKey", true);
						break;
					case 2:
						if (MainApp.appSettings.manualModeAds == 1)
						{
							if (adsNcServer.NcClient.Channel[selectedChannel].CmdOpMode == (int)OperationMode.Manual)
							{
								SpecialFunc.ManualModeRapidFeed = !SpecialFunc.ManualModeRapidFeed;
							}
						}
						else
						{
							SpecialFunc.ManualModeRapidFeed = !SpecialFunc.ManualModeRapidFeed;
							SetPLCVar(".PlcManualModeRapidFeedKey", SpecialFunc.ManualModeRapidFeed);
						}

						if (SpecialFunc.ManualModeRapidFeed)
							MainApp.GetDoc().tcFKey1.FKeyBackColor(2, Color.Orange);
						else
							MainApp.GetDoc().tcFKey1.FKeyBackColor(2, Color.Yellow);

						break;
					case 3:
						if (MainApp.appSettings.manualModeAds == 1)
						{
							if (adsNcServer != null && adsNcServer.NcIsRunning)
								adsNcServer.NcClient.NcManual.MoveAxisPositive(SpecialFunc.ManualModeRapidFeed);
						}
						else
							SetPLCVar(".PlcManualModeRightKey", true);
						break;
					case 4:
						if (tcFKeyOpMode.Visible == false)
						{
							OpModeWindow.Open(this.Height, tcFKeyOpMode);
						}
						break;
					case 5:
						MainApp.appSettings.mdiCommand[selectedChannel] = opModeMDI1.MdiText;
						SetPLCVar(plcString + ".MDIString", opModeMDI1.MdiText);
						SetPLCVar(plcString + ".ProgramName", opModeAuto1.selectFile1.Arguments);
						SetPLCVar(plcString + ".Start", true);
						break;
					case 6:
						SetPLCVar(plcString + ".Stop", true);
						break;
					case 7:
						SetPLCVar(plcString + ".Reset", true);
						SetPLCVar(".PLCReset", true);
						// Refresh the view by setting the actual channel number or the program name again
						opModeAuto1.tcNcProgramSection1.CncProgramName = opModeAuto1.selectFile1.Arguments;
						break;
					case 12:
						ManualModeSelected(false);
						break;
				}
			}
			catch (Exception ex)
			{
				MainApp.log.Error("FormCnc FKeyDownEvent()", ex);
			}
		}

		public override void FKeyUpEvent(int nIdx)
		{
			try
			{
				switch (nIdx)
				{
					case 1:
						if (MainApp.appSettings.manualModeAds == 1)
						{
							if (adsNcServer != null && adsNcServer.NcIsRunning)
								adsNcServer.NcClient.NcManual.StopAxisMotion();
						}
						else
						{
							SetPLCVar(".PlcManualModeLeftKey", false);
							SetPLCVar(".PlcManualModeRightKey", false);
						}
						break;
					case 3:
						if (MainApp.appSettings.manualModeAds == 1)
						{
							if (adsNcServer != null && adsNcServer.NcIsRunning)
								adsNcServer.NcClient.NcManual.StopAxisMotion();
						}
						else
						{
							SetPLCVar(".PlcManualModeLeftKey", false);
							SetPLCVar(".PlcManualModeRightKey", false);
						}
						break;
					case 4:
						if (OpModeWindow.Direction == 1)
							tcFKeyOpMode.Focus();
						break;
				}
			}
			catch (Exception ex)
			{
				MainApp.log.Error("FormCnc FKeyUpEvent()", ex);
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (tcFKeyOpMode.Visible)
			{
				if (Keys.D1 <= e.KeyCode && e.KeyCode <= Keys.D4)
				{
					int idx = e.KeyCode - Keys.D0;
					tcFKeyOpMode_FKeyUpEvent(idx);
				}
			}
			base.OnKeyDown(e);
		}

		#endregion

		#region Events

		private void FormCnc_Load(object sender, System.EventArgs e)
		{
			MainApp.GetDoc().tcFKey1.Focus();

			// restore the view type
			tcAxesList1.AxisPositionType = (TcAxisPositionType)MainApp.appSettings.axesPositionType;
			tcAxesList1.CncCoordinateSystem = (TcCoordinateSystem)MainApp.appSettings.axesCoordinateSystem;
			tcAxesList1.CncValueOutputFormat = MainApp.appSettings.axesValueOutputFormat;

			// Language Manager
			if (tclm != null)
			{
				tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
				LoadLanguageStrings();
			}

			// Operation Mode
			tcFKeyOpMode.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleRight;
			tcFKeyOpMode.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

			int i;
			Button btn;
			for (i = 1; i <= 4; i++)
			{
				btn = tcFKeyOpMode.FKeyButtonObj(i);
				btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			}

			// Left Keys
			for (i = 1; i <= 8; i++)
			{
				btn = tcFKeyLeft.FKeyButtonObj(i);
				btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			}

			// Path for CNC Program Selection
			opModeAuto1.selectFile1.InitialDirectory = MainApp.appSettings.pathSettings[0];
		}

		private void FormCnc_Activated(object sender, System.EventArgs e)
		{
			// channel description on left side
			LoadLanguageKeysLeft();
			// special functions on right side
			LoadLanguageKeysRight();

			NcClient_OpModeStateChanged(MainApp.GetDoc().AppHeader.ChannelNr, -1, -1);
			TimerStatusUpdate.Enabled = true;
			tcTechnoData1.EnableTimer = true;
		}

		private void FormCnc_Deactivate(object sender, System.EventArgs e)
		{
			TimerStatusUpdate.Enabled = false;
			tcTechnoData1.EnableTimer = false;
			// save the view type
			MainApp.appSettings.axesPositionType = (int)tcAxesList1.AxisPositionType;
			MainApp.appSettings.axesCoordinateSystem = (int)tcAxesList1.CncCoordinateSystem;

			ManualModeSelected(false);
			tcFKeyLeft.FKeySelectedMode = false;
		}

		private void tcAxesList1_AxisSelectEvent(int nIdx, int nLogAxisIdx)
		{
			// Write the number of the selected axis to the PLC 
			SetPLCVar(".PlcManualModeSelectedAxis", nLogAxisIdx.ToString());
		}

		private int tcOverride1_OverrideChanged(string plcVariableName, int value, bool write)
		{
			if (string.IsNullOrEmpty(plcVariableName))
				return 0;

			try
			{
				if (adsPlcServer.PlcIsRunning)
				{
					if (write == true)
						SetPLCVar(plcVariableName, value);
					else
						return (UInt16)GetPLCVar(plcVariableName);
				}
			}
			catch
			{ }
			return 0;
		}

		private void opModeAuto1_FileNameChanged(string strFileName)
		{
			int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
			string plcString = ".PLCMachineMode[" + selectedChannel.ToString() + "]";
			SetPLCVar(plcString + ".ProgramName", opModeAuto1.selectFile1.Arguments);
		}

		private void tcFKeyRight_FKeyUpEvent(int nIdx)
		{
			bool bActivate;
			int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
			string plcString = ".PLCMachineMode[" + selectedChannel.ToString() + "]";
			switch (nIdx)
			{
				case 1:	// Single step / Einzelsatz
					if (tclm["FormCnc.tcFKeyRight[1]"] != "")
					{
						bActivate = !SpecialFunc.SingleBlockMode;
						if (SetPLCVar(plcString + ".SingleBlock", bActivate))
							SpecialFunc.SingleBlockMode = bActivate;
					}
					break;
				case 2:	// Skip block / (Program block ignore) / Satz ausblenden
					if (tclm["FormCnc.tcFKeyRight[2]"] != "")
					{
						bActivate = !SpecialFunc.SkipBlock;
						if (SetPLCVar(plcString + ".PrgBlockIgnore", bActivate))
							SpecialFunc.SkipBlock = bActivate;
					}
					break;
				case 3:	// M01Stop / Wahlhalt
					if (tclm["FormCnc.tcFKeyRight[3]"] != "")
					{
						bActivate = !SpecialFunc.M01Stop;
						if (SetPLCVar(plcString + ".M01Stop", bActivate))
							SpecialFunc.M01Stop = bActivate;
					}
					break;
				case 4:	// Backward / Retrace / Rückwärts fahren
					if (tclm["FormCnc.tcFKeyRight[4]"] != "")
					{
						bActivate = !SpecialFunc.Retrace;
						if (SetPLCVar(plcString + ".Backward", bActivate))
							SpecialFunc.Retrace = bActivate;
					}
					break;
				case 6:
					break;


				case 7:	// Set Program
					if (tclm["FormCnc.tcFKeyRight[7]"] != "")
					{
						MainApp.appSettings.mdiCommand[selectedChannel] = opModeMDI1.MdiText;
						SetPLCVar(plcString + ".MDIString", opModeMDI1.MdiText);
						SetPLCVar(plcString + ".ProgramName", opModeAuto1.selectFile1.Arguments);
					}
					break;
				case 8:	// Enable / HW Freigabe
					if (tclm["FormCnc.tcFKeyRight[8]"] != "")
					{
						bActivate = !SpecialFunc.EnableHW;
						if (SetPLCVar(".PLCAxisEnable", bActivate))
							SpecialFunc.EnableHW = bActivate;
					}
					break;
			}
			ShowIconStatus();
		}

		private void tcFKeyLeft_FKeyUpEvent(int nIdx)
		{
			if (nIdx <= adsNcServer.NcClient.InterfaceData.NumberOfChannels)
			{
				panelChannelOverview.Visible = false;
				SelectChannel(nIdx);
				selectedKeyPressChannel = nIdx;
			}

			if (nIdx == 8)
			{
				int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;

				if (selectedChannel == 1)
					tcAxesList2.BackColor = Color.White;
				else
					tcAxesList2.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control);

				if (selectedChannel == 2)
					tcAxesList3.BackColor = Color.White;
				else
					tcAxesList3.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control);

				if (selectedChannel == 3)
					tcAxesList4.BackColor = Color.White;
				else
					tcAxesList4.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control);

				if (selectedChannel == 4)
					tcAxesList5.BackColor = Color.White;
				else
					tcAxesList5.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control);

				panelChannelOverview.Visible = true;
				panelChannelOverview.BringToFront();
				selectedKeyPressChannel = nIdx;
			}
		}

		private void tcFKeyOpMode_FKeyUpEvent(int nIdx)
		{
			int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
			string plcString = ".PLCMachineMode[" + selectedChannel.ToString() + "]";
			bool res = false;

			OpModeWindow.Close(1);
			// deactivated the selected axis, if the manual mode was previously selected
			ManualModeSelected(false);
			switch (nIdx)
			{
				case 1:	// Automatic Mode
					res = SetPLCVar(plcString + ".Automatic", true);
					break;
				case 2:	// Manual Mode
					opModeManual1.SetManualModeAxisParam();	// set the default value
					res = SetPLCVar(plcString + ".Manual", true);
					break;
				case 3:	// MDI Mode
					res = SetPLCVar(plcString + ".MDI", true);
					break;
				case 4:	// Reference Mode
					res = SetPLCVar(plcString + ".Reference", true);
					break;
			}
			//if (res == true)
			//	SetFKeyOpModeStatus(nIdx);
		}

		private void adsNcServer_TcNcStateChanged(TwinCAT.Ads.AdsState state)
		{
			for (int i = 1; i <= 8; i++)
				tcFKeyLeft.FKeyText(i, "");

			if (state == TwinCAT.Ads.AdsState.Run)
			{
				adsNcServer.NcClient.SuppressInternalCncMessages(true);

				//if (MainApp.GetDoc().ActiveMdiChild is TcApplication.FormCnc)
				LoadLanguageKeysLeft();
			}
			else
				tcFKeyLeft.FKeySelectedMode = false;
		}

		private void adsPlcServer_TcPlcStateChanged(TwinCAT.Ads.AdsState state)
		{
			if (state == TwinCAT.Ads.AdsState.Run)
			{
				// set the initial value for the feedrate override
				if (tcOverride1.PlcVarFeedOverride.Length != 0)
				{
					SetPLCVar(tcOverride1.PlcVarFeedOverride, 100);
					tcOverride1.FeedrateOverrideValue = 100;
				}
				if (tcOverride1.PlcVarSpindleOverride.Length != 0)
				{
					SetPLCVar(tcOverride1.PlcVarSpindleOverride, 100);
					tcOverride1.SpindleOverrideValue = 100;
				}

				tcFKeyLeft.FKeySelectedMode = true;
				tcFKeyLeft.FKeyButtonObj(1).BackColor = MainApp.GetDoc().ColorCaption;	// is the selected color
				selectedKeyPressChannel = 1;
				SelectChannel(1);

				// write startup ProgramName to the PLC
				int max = adsNcServer.NcClient.InterfaceData.NumberOfChannels;
				for (int i = 1; i <= max; i++)
				{
					string plcString = ".PLCMachineMode[" + i.ToString() + "]";
					SetPLCVar(plcString + ".ProgramName", MainApp.appSettings.programName[i]);
				}
			}
		}

		void AdsClient_Error(object sender, string msg, Exception ex)
		{
			MainApp.log.Error("Module " + sender.ToString() + " " + msg, ex);
		}

		void NcClient_OpModeStateChanged(int channel, int mode, int state)
		{
			int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
			if (MainApp.GetDoc().ActiveMdiChild is TcApplication.FormCnc
				&& selectedChannel == channel)
			{
				RestoreChannelStatus();
				RestoreFunctionStatus(true);
			}
		}

		private void FormCnc_PLCFKeyLeft(bool[] plcKeys)
		{
			if (MainApp.GetDoc().ActiveMdiChild is TcApplication.FormCnc)
			{
				for (int i = 0; i < 8; i++)
				{
					if (plcKeys[i] != plcFKeyLeftStatus[i])
					{
						plcFKeyLeftStatus[i] = plcKeys[i];
						if (plcFKeyLeftStatus[i] == true)
							tcFKeyLeft_FKeyUpEvent(i + 1);
					}
				}
			}
		}

		private void FormCnc_PLCFKeyRight(bool[] plcKeys)
		{
			if (MainApp.GetDoc().ActiveMdiChild is TcApplication.FormCnc)
			{
				for (int i = 0; i < 8; i++)
				{
					if (plcKeys[i] != plcFKeyRightStatus[i])
					{
						plcFKeyRightStatus[i] = plcKeys[i];
						if (plcFKeyRightStatus[i] == true)
							tcFKeyRight_FKeyUpEvent(i + 1);
					}
				}
			}
		}

		private void TimerStatusUpdate_Tick(object sender, EventArgs e)
		{
			RestoreFunctionStatus(false);
		}

		private void tcFunctionView_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Technology functions
			if (tcFunctionView.SelectedIndex == 0)
				tcTechnoData1.EnableTimer = true;
			else
				tcTechnoData1.EnableTimer = false;

			// Block Search
			if (tcFunctionView.SelectedIndex == 1)
			{
				blockSearch1.TimerEnabled = true;
			}
			else
			{
				blockSearch1.StopBlockSearch();
				blockSearch1.TimerEnabled = false;
			}

			// Syntax Check
			if (tcFunctionView.SelectedIndex == 2)
			{
				syntaxCheck1.TimerEnabled = true;
			}
			else
			{
				syntaxCheck1.StopSyntaxCheck();
				syntaxCheck1.TimerEnabled = false;
			}

			// VE - variables
		}

		void tcPlcConnectNciOvrChannel0_ValueChanged(object sender, TcAdsNotificationItem notificationItem)
		{
			try
			{
				if (notificationItem.PlcObject != null)
				{
					int val = (Int16)notificationItem.PlcObject;
					adsNcServer.NcClient.Channel[1].Override = val;
				}
			}
			catch (Exception)
			{
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

		private void LoadLanguageStrings()
		{
			// Operation Mode
			tcFKeyOpMode.FKeyText(1, tclm["FormCnc.tcFKeyOpMode[1]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\M_AUTO.bmp"));
			tcFKeyOpMode.FKeyText(2, tclm["FormCnc.tcFKeyOpMode[2]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\M_MANUAL.bmp"));
			tcFKeyOpMode.FKeyText(3, tclm["FormCnc.tcFKeyOpMode[3]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\M_MDI.bmp"));
			tcFKeyOpMode.FKeyText(4, tclm["FormCnc.tcFKeyOpMode[4]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\M_RPF.bmp"));

			opModeAuto1.ActiveProgramCaption = tclm["FormCnc.labelActiveProgram"];
			opModeMDI1.Caption = tclm["FormCnc.groupBoxMDI"];								//"Operation Mode - MDI"
			opModeManual1.groupBoxManual.Text = tclm["FormCnc.groupBoxManual"];		//"Operation Mode - Manual"
			opModeManual1.label1.Text = tclm["FormCnc.label1"];							//"Velo:"
			opModeManual1.rbManualTipMode.Text = tclm["FormCnc.rbManualTipMode"];	//"Tip-Mode"
			opModeManual1.rbManualJogMode.Text = tclm["FormCnc.rbManualJogMode"];	//"Jog-Mode"
			opModeManual1.groupBox2.Text = tclm["FormCnc.groupBox2"] + "      ";		//"Increments"
			opModeManual1.groupBox1.Text = tclm["FormCnc.groupBox1"] + "     ";		//"Op Type"

			//SetLowerFKeyText(MainApp.GetDoc().tcFKey1);
			//SetFKeyText(MainApp.GetDoc().tcFKey2);

			// MK tcChannelStatus1.ChannelName = tclm["MainApp.labelChannelNr"];
			// MK tcChannelStatus2.ChannelName = tclm["MainApp.labelChannelNr"];
			// MK tcChannelStatus3.ChannelName = tclm["MainApp.labelChannelNr"];
			// MK tcChannelStatus4.ChannelName = tclm["MainApp.labelChannelNr"];

			tabPage2.Text = tclm.GetString("FormCnc.BlockSearch", "Block Search", true);
			tabPage3.Text = tclm.GetString("FormCnc.SyntaxCheck", "Syntax Check", true);
		}

		private void LoadLanguageKeysLeft()
		{
			Button btn;
			tcFKeyLeft.FKeySelectedMode = true;
			if (adsNcServer != null && adsNcServer.NcIsRunning)
			{
				int max = adsNcServer.NcClient.InterfaceData.NumberOfChannels;
				for (int i = 1; i <= max; i++)
					tcFKeyLeft.FKeyText(i, tclm["FormCnc.tcFKeyLeft[1]"] + " " + i.ToString());

				// select first
				if (0 < selectedKeyPressChannel && selectedKeyPressChannel <= max || selectedKeyPressChannel == 8)
				{
					btn = tcFKeyLeft.FKeyButtonObj(selectedKeyPressChannel);
					btn.BackColor = MainApp.GetDoc().ColorCaption;	// is the selected color
				}

				tcFKeyLeft.FKeyText(8, tclm["FormCnc.tcFKeyLeft[8]"]);	//"CNC Kanäle"
			}
		}

		private void LoadLanguageKeysRight()
		{
			try
			{
				// Right Keys
				tcFKeyRight.FKeyTextAlign = System.Drawing.ContentAlignment.BottomLeft;
				if (tclm["FormCnc.tcFKeyRight[1]"] != "")
					tcFKeyRight.FKeyText(1, tclm["FormCnc.tcFKeyRight[1]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\Single.ico"));
				if (tclm["FormCnc.tcFKeyRight[2]"] != "")
					tcFKeyRight.FKeyText(2, tclm["FormCnc.tcFKeyRight[2]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\BlkIgn.ico"));
				if (tclm["FormCnc.tcFKeyRight[3]"] != "")
					tcFKeyRight.FKeyText(3, tclm["FormCnc.tcFKeyRight[3]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\M01Stop.ico"));
				if (tclm["FormCnc.tcFKeyRight[4]"] != "")
					tcFKeyRight.FKeyText(4, tclm["FormCnc.tcFKeyRight[4]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\Backward.ico"));
				if (tclm["FormCnc.tcFKeyRight[7]"] != "")
					tcFKeyRight.FKeyText(7, tclm["FormCnc.tcFKeyRight[7]"]);
				if (tclm["FormCnc.tcFKeyRight[8]"] != "")
					tcFKeyRight.FKeyText(8, tclm["FormCnc.tcFKeyRight[8]"], Image.FromFile(Application.StartupPath + "\\Bitmap\\State\\Enable.ico"));
			}
			catch
			{ }
		}

		private object GetPLCVar(string plcVariableName)
		{
			if (adsPlcServer != null && adsPlcServer.PlcIsRunning)
			{
				try
				{
					return adsPlcServer.PlcClient.ReadSymbol(plcVariableName);
				}
				catch (Exception ex)
				{
					MainApp.log.Error("Error in GetPLCVar()", ex);
				}
			}
			return 0;
		}

		private bool SetPLCVar(string plcVariableName, object plcValue)
		{
			if (adsPlcServer != null && adsPlcServer.PlcIsRunning)
			{
				try
				{
					adsPlcServer.PlcClient.WriteSymbol(plcVariableName, plcValue);
					return true;
				}
				catch (Exception ex)
				{
					MainApp.log.Error("Error in SetPLCVar()", ex);
				}
			}
			return false;
		}

		private void RestoreChannelStatus()
		{
			int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
			int nIdx = 0;

			// Reads the status and restore after activation
			//int nOpMode = MainApp.GetDoc().header1.tcChannelStatus1.AdsServer.Clients.Channel[selectedChannel].CmdOpMode;
			int nOpMode = adsNcServer.NcClient.Channel[selectedChannel].CmdOpMode;
			switch ((Beckhoff.Forms.Nc.OperationMode)nOpMode)
			{
				case OperationMode.Automatic: nIdx = 1; break;
				case OperationMode.Manual: nIdx = 2; break;
				case OperationMode.MDI: nIdx = 3; break;
				case OperationMode.Reference: nIdx = 4; break;
				default: nIdx = -1; break;
			}
			// deselect the manual mode if selected
			ManualModeSelected(false);
			SetFKeyOpModeStatus(nIdx);
		}

		private void RestoreFunctionStatus(bool alwaysUpdate)
		{
			int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
			string plcString = ".PLCMachineMode[" + selectedChannel.ToString() + "]";
			CncSpecialFunctions cncFunc = SpecialFunc;

			// Reads the status and restore after activation
			SpecialFunc.SingleBlockMode = false;
			SpecialFunc.M01Stop = false;
			SpecialFunc.Retrace = false;
			SpecialFunc.EnableHW = false;
			SpecialFunc.SkipBlock = false;

			try
			{
				if (adsPlcServer.PlcIsRunning == true)
				{
					try
					{
						SpecialFunc.SingleBlockMode = (bool)adsPlcServer.PlcClient.ReadSymbol(plcString + ".SingleBlock");
						SpecialFunc.M01Stop = (bool)adsPlcServer.PlcClient.ReadSymbol(plcString + ".M01Stop");
						SpecialFunc.Retrace = (bool)adsPlcServer.PlcClient.ReadSymbol(plcString + ".Backward");
						SpecialFunc.EnableHW = (bool)adsPlcServer.PlcClient.ReadSymbol(".PLCAxisEnable");
						SpecialFunc.SkipBlock = (bool)adsPlcServer.PlcClient.ReadSymbol(plcString + ".PrgBlockIgnore");

						if (adsNcServer.ClientPortNr == 553)
						{
							// Restore BlockSearch
							object obj = adsPlcServer.PlcClient.ReadSymbol(plcString + ".BlockSearch.Active");
							if (obj != null && (bool)obj)
							{
								tcFunctionView.SelectedIndex = 1;
								blockSearch1.TimerEnabled = true;
							}
						}
					}
					catch (Exception ex)
					{
						MainApp.log.Error("Error in FormCnc RestoreFunctionStatus()", ex);
					}
				}
			}
			catch
			{ }

			if (alwaysUpdate
				|| cncFunc.EnableHW != SpecialFunc.EnableHW
				|| cncFunc.M01Stop != SpecialFunc.M01Stop
				|| cncFunc.ManualModeRapidFeed != SpecialFunc.ManualModeRapidFeed
				|| cncFunc.Retrace != SpecialFunc.Retrace
				|| cncFunc.SingleBlockMode != SpecialFunc.SingleBlockMode
				|| cncFunc.SkipBlock != SpecialFunc.SkipBlock)
				ShowIconStatus();
		}

		private void SetRightKey(int keyNr, bool condition, string iconName)
		{
			try
			{
				if (tclm["FormCnc.tcFKeyRight[" + keyNr.ToString() + "]"] != "")
				{
					if (condition == true)
						iconName = iconName + "2.ico";
					else
						iconName = iconName + ".ico";
					tcFKeyRight.FKeyPicture(keyNr, Image.FromFile(Application.StartupPath + iconName));
				}
			}
			catch
			{ }
		}
		private void ShowIconStatus()
		{
			SetRightKey(1, SpecialFunc.SingleBlockMode, "\\Bitmap\\State\\Single");
			SetRightKey(2, SpecialFunc.SkipBlock, "\\Bitmap\\State\\BlkIgn");
			SetRightKey(3, SpecialFunc.M01Stop, "\\Bitmap\\State\\M01Stop");
			SetRightKey(4, SpecialFunc.Retrace, "\\Bitmap\\State\\Backward");
			SetRightKey(8, SpecialFunc.EnableHW, "\\Bitmap\\State\\Enable");
		}

		private void SetFKeyOpModeStatus(int nIdx)
		{
			bool bAutomaticMode = false;
			bool bManualMode = false;
			bool bMDIMode = false;

			tcFKeyOpMode.FKeyBackColor(1, Beckhoff.App.TcColor.Gray);
			tcFKeyOpMode.FKeyBackColor(2, Beckhoff.App.TcColor.Gray);
			tcFKeyOpMode.FKeyBackColor(3, Beckhoff.App.TcColor.Gray);
			tcFKeyOpMode.FKeyBackColor(4, Beckhoff.App.TcColor.Gray);
			tcFKeyOpMode.FKeyBackColor(nIdx, MainApp.GetDoc().ColorCaption);

			Beckhoff.App.TcFKey fkey = MainApp.GetDoc().tcFKey1;
			fkey.FKeyText(1, "", null, Color.Empty);
			fkey.FKeyText(2, "", null, Color.Empty);
			fkey.FKeyText(3, "", null, Color.Empty);

			switch (nIdx)
			{
				case 1:	// Automatic
					bAutomaticMode = true;
					break;
				case 2:	// Manual
					fkey.FKeyText(1, "", Image.FromFile(Application.StartupPath + "\\Bitmap\\Key_M.ico"), Color.Yellow);
					fkey.FKeyText(2, "", Image.FromFile(Application.StartupPath + "\\Bitmap\\Eilgang.ico"));
					fkey.FKeyText(3, "", Image.FromFile(Application.StartupPath + "\\Bitmap\\Key_P.ico"), Color.Yellow);
					if (SpecialFunc.ManualModeRapidFeed)
						fkey.FKeyBackColor(2, Color.Orange);
					else
						fkey.FKeyBackColor(2, Color.Yellow);
					bManualMode = true;
					break;
				case 3:	// MDI
					bMDIMode = true;
					break;
				case 4:	// Reference
					break;
			}

			// selects the right screen
			ManualModeSelected(bManualMode);
			opModeAuto1.Visible = bAutomaticMode;
			opModeManual1.Visible = bManualMode;
			opModeMDI1.Visible = bMDIMode;
		}

		private void SelectChannel(int channel)
		{
			int prevChannel = tcAxesList1.ChannelNumber;
			tcAxesList1.ChannelNumber = channel;
			tcOverride1.ChannelNumber = channel;
			tcSpeedControl1.ChannelNumber = channel;
			tcTechnoData1.ChannelNumber = channel;
			opModeAuto1.tcNcProgramSection1.ChannelNumber = channel;

			// save the program name from the active channel and switch to the new one
			MainApp.appSettings.programName[prevChannel] = opModeAuto1.selectFile1.Arguments;
			MainApp.appSettings.mdiCommand[prevChannel] = opModeMDI1.MdiText;
			opModeAuto1.selectFile1.Arguments = MainApp.appSettings.programName[channel];
			opModeAuto1.tcNcProgramSection1.CncProgramName = opModeAuto1.selectFile1.Arguments;
			opModeMDI1.MdiText = MainApp.appSettings.mdiCommand[channel];

			// ...also set to main form
			MainApp.GetDoc().AppHeader.ChannelNr = channel;
			MainApp.GetDoc().AppHeader.LabelChannelText = tclm["MainApp.labelChannelNr"];

			// ...also selection to the PLC
			SetPLCVar(".PLCSelectedChannel", channel);

			// ... and restore the display info
			NcClient_OpModeStateChanged(channel, -1, -1);
		}

		void ManualModeSelected(bool state)
		{
			if (tcAxesList1.CncManualModeSelected == true
				&& state == false)
			{
				// after selection -> always false
				SpecialFunc.ManualModeRapidFeed = false;
				SetPLCVar(".PlcManualModeRapidFeedKey", SpecialFunc.ManualModeRapidFeed);
				SetPLCVar(".PlcManualModeSelectedAxis", 0);
			}

			if (tcAxesList1.CncManualModeSelected != state)
				tcAxesList1.CncManualModeSelected = state;
		}

		#endregion


		struct NciChannelState
		{
			public Int16[] Mode;			// Operation Mode
			public Int16[] State;		// Operation State
		}
		NciChannelState oldOpState;

		private void tcPlcConnect1_ValueChanged(object sender, TcAdsNotificationItem notificationItem)
		{
			NciChannelState operation;

			try
			{
				operation.Mode = (Int16[])notificationItem.PlcObject;

				for (int i = 0; i < operation.Mode.GetLength(0); i++)
				{
					if (operation.Mode[i] != oldOpState.Mode[i])
					{
						adsNcServer.NcClient.TcNciOpModeStateChange(i + 1, (OperationMode)operation.Mode[i], (OperationState)oldOpState.State[i]);
					}
				}
				oldOpState.Mode = operation.Mode;
			}
			catch
			{ }
		}

		private void tcPlcConnect2_ValueChanged(object sender, TcAdsNotificationItem notificationItem)
		{
			NciChannelState operation;

			try
			{
				operation.State = (Int16[])notificationItem.PlcObject;

				for (int i = 0; i < operation.State.GetLength(0); i++)
				{
					if (operation.State[i] != oldOpState.State[i])
					{
						adsNcServer.NcClient.TcNciOpModeStateChange(i + 1, (OperationMode)oldOpState.Mode[i], (OperationState)operation.State[i]);
					}
				}
				oldOpState.State = operation.State;
			}
			catch
			{ }
		}

	}
}
