using System;
using System.Drawing;

namespace TcApplication
{
	/// <summary>
	/// Summary description for Setting.
	/// </summary>
	public class Settings
	{
		public const int MAX_EVENTLOG_COLUMNS = 14;

		private Beckhoff.App.Setting.Xml AppSett;
		private string fileName;

		public bool applicationFrame;
		public bool applicationStartMax;
		public bool applicationViewStatusBar;
		public bool applicationManualTreeView;
		public string[] pathSettings;
		public string[] programName;
		public string[] mdiCommand;
		public bool[] eventlogColStatus;
		public int[] eventlogColWidth;
		public int[] eventlogColDisplayOrder;
		/// <summary>
		/// 0-1031(German) 1-1033(English)
		/// </summary>
		public int eventlogLanguage;
		public int eventlogRefreshTime;
		public int applicationStartupScreen;
		public int applicationHeaderType;
		public int applicationColorTheme;
		/// <summary>
		/// Contains the selected axes position types.
		/// </summary>
		public int axesPositionType;
		/// <summary>
		/// Contains 1-PCS(WKS) or 2-ACS(MKS)
		/// </summary>
		public int axesCoordinateSystem;
		/// <summary>
		/// 0-CNC, 1-NCI
		/// </summary>
		public int tagetSystem;
		/// <summary>
		/// The Ams Net Id, if the system is connected to a remote system.
		/// </summary>
		public string amsNetId;
		public string[] batchProcess;
		/// <summary>
		/// Axis value output format.
		/// </summary>
		public string axesValueOutputFormat;
		/// <summary>
		/// The height of the axes row.
		/// </summary>
		public int axesRowHeight;
		/// <summary>
		/// The Nc font name.
		/// </summary>
		public string ncFontName;
		/// <summary>
		/// The tab width of the Nc program section control.
		/// </summary>
		public int ncTabWidth;
		
		/// <summary>
		/// The Plc variable is written when the settings are saved
		/// </summary>
		public string plcVarWriteSettings;
	
		/// <summary>
		/// The Plc variable is used for NCI channel 1, or feed override for the PTP axes
		/// </summary>
		public string plcVarNciOverrideChannel1;

		/// <summary>
		/// If checked the override value can be changed from screen.
		/// </summary>
		public bool overrideStyle;
		/// <summary>
		/// The Plc variable is written by changing the override slider from screen.
		/// </summary>
		public string plcVarFeedOverride;
		/// <summary>
		/// The Plc variable is written by changing the override slider from screen.
		/// </summary>
		public string plcVarSpindleOverride;

		/// <summary>
		/// Direct Manual Mode over ADS to the NC (1) ohterwise to PLC.
		/// </summary>
		public int manualModeAds;

		public Settings()
		{
			pathSettings = new string[20];
			programName = new string[20];
			mdiCommand = new string[20];
			eventlogColStatus = new bool[MAX_EVENTLOG_COLUMNS];
			eventlogColWidth = new int[MAX_EVENTLOG_COLUMNS];
			eventlogColDisplayOrder = new int[MAX_EVENTLOG_COLUMNS];
			batchProcess = new string[10];
			eventlogLanguage = 0;
			axesPositionType = 1;
			axesCoordinateSystem = 1;
			ncFontName = "";
			ncTabWidth = 38;
			manualModeAds = 1;
			overrideStyle = false;
			plcVarFeedOverride = ".PlcFeedOverride2";
			plcVarSpindleOverride = "";
		}

		public string FileName
		{
			get { return fileName; }
			set
			{
				fileName = value;
				// the setting instance
				AppSett = null;
				AppSett = new Beckhoff.App.Setting.Xml(fileName);
				AppSett.Buffer();
			}
		}

		public bool ReadSettings()
		{
			string tmp = "";
			if (AppSett == null)
				return false;

			MainApp.log.Info("Settings loaded: " + fileName);

			// must be at first
			if (AppSett.Buffer().NeedsFlushing)
				AppSett.Buffer().Flush();

			// path settings
			int nMin = pathSettings.GetLowerBound(0);
			int nMax = pathSettings.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				pathSettings[i] = AppSett.GetValue("PathSettings", "Path" + i.ToString(), "");
			}

			// read default cnc path
			if (string.IsNullOrEmpty(pathSettings[0]))
			{
				try
				{
					Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.LocalMachine;
					using (Microsoft.Win32.RegistryKey subKey = regKey.OpenSubKey("SOFTWARE\\Beckhoff\\TwinCAT\\System"))
						tmp = (string)subKey.GetValue("UserPath2");
					if (!string.IsNullOrEmpty(tmp))
						pathSettings[0] = tmp;
				}
				catch
				{ }
			}

			// eventlogger
			ReadEventLogSettings();

			// batchProcess
			nMin = batchProcess.GetLowerBound(0);
			nMax = batchProcess.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				batchProcess[i] = AppSett.GetValue("BatchProcess", "Batch" + i.ToString(), "");
			}
			applicationFrame = AppSett.GetValue("General", "AppFrame", true);
			applicationStartMax = AppSett.GetValue("General", "AppStartMax", true);
			applicationViewStatusBar = AppSett.GetValue("General", "AppStatusBar", true);
			applicationManualTreeView = AppSett.GetValue("General", "AppManualTableView", false);
			applicationStartupScreen = AppSett.GetValue("General", "AppStartUpScreen", 0);
			applicationHeaderType = AppSett.GetValue("General", "AppHeaderType", 0);
			applicationColorTheme = AppSett.GetValue("General", "ColorTheme", 1);
			tagetSystem = AppSett.GetValue("General", "TagetSystem", 0);
			amsNetId = AppSett.GetValue("General", "AmsNetId", "");

			axesValueOutputFormat = AppSett.GetValue("General", "AxesValueOutputFormat", "0.000");
			axesRowHeight = AppSett.GetValue("General", "AxesRowHeight", 32);

			// program names for automatic process
			nMin = programName.GetLowerBound(0) + 1;
			nMax = programName.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				programName[i] = AppSett.GetValue("ProgramName", "Channel" + i.ToString(), "");
			}

			// program names for automatic process
			nMin = mdiCommand.GetLowerBound(0) + 1;
			nMax = mdiCommand.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				mdiCommand[i] = AppSett.GetValue("MDICommand", "Channel" + i.ToString(), "");
			}

			// cnc page
			axesCoordinateSystem = AppSett.GetValue("CNC", "AxesCoordinateSystem", 1);
			axesPositionType = AppSett.GetValue("CNC", "AxesPositionType", 1);
			ncFontName = AppSett.GetValue("CNC", "FontName", "");
			ncTabWidth = AppSett.GetValue("CNC", "TabWidth", 15);
			manualModeAds = AppSett.GetValue("CNC", "ManualModeAds", 1);
			overrideStyle = AppSett.GetValue("CNC", "OverrideStyle", false);
			plcVarFeedOverride = AppSett.GetValue("CNC", "PlcVarFeedOverride", ".PlcFeedOverride2");
			plcVarSpindleOverride = AppSett.GetValue("CNC", "PlcVarSpindleOverride", "");

			// settings
			plcVarWriteSettings = AppSett.GetValue("Settings", "PlcVarWriteSettings", "");
			plcVarNciOverrideChannel1 = AppSett.GetValue("Settings", "PlcVarNciOverrideChannel1", "");

			return true;
		}

		public bool WriteSettings()
		{
			if (AppSett == null)
				return false;

			// path settings
			int nMin = pathSettings.GetLowerBound(0);
			int nMax = pathSettings.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				AppSett.SetValue("PathSettings", "Path" + i.ToString(), this.pathSettings[i]);
			}

			// eventlogger
			WriteEventLogSettings();

			// batchProcess
			nMin = batchProcess.GetLowerBound(0);
			nMax = batchProcess.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				AppSett.SetValue("BatchProcess", "Batch" + i.ToString(), batchProcess[i]);
			}
			AppSett.SetValue("General", "AppFrame", applicationFrame);
			AppSett.SetValue("General", "AppStartMax", applicationStartMax);
			AppSett.SetValue("General", "AppStatusBar", applicationViewStatusBar);
			AppSett.SetValue("General", "AppStartUpScreen", applicationStartupScreen);
			AppSett.SetValue("General", "AppManualTableView", applicationManualTreeView);
			AppSett.SetValue("General", "AppHeaderType", applicationHeaderType);
			AppSett.SetValue("General", "ColorTheme", applicationColorTheme);
			AppSett.SetValue("General", "TagetSystem", tagetSystem);
			AppSett.SetValue("General", "AmsNetId", amsNetId);

			AppSett.SetValue("General", "AxesValueOutputFormat", axesValueOutputFormat);
			AppSett.SetValue("General", "AxesRowHeight", axesRowHeight);

			// program names for automatic process
			nMin = programName.GetLowerBound(0) + 1;
			nMax = programName.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				AppSett.SetValue("ProgramName", "Channel" + i.ToString(), programName[i]);
			}

			// program names for automatic process
			nMin = mdiCommand.GetLowerBound(0) + 1;
			nMax = mdiCommand.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				AppSett.SetValue("MDICommand", "Channel" + i.ToString(), mdiCommand[i]);
			}

			// cnc page
			AppSett.SetValue("CNC", "AxesCoordinateSystem", axesCoordinateSystem);
			AppSett.SetValue("CNC", "AxesPositionType", axesPositionType);
			AppSett.SetValue("CNC", "FontName", ncFontName);
			AppSett.SetValue("CNC", "TabWidth", ncTabWidth);
			AppSett.SetValue("CNC", "ManualModeAds", manualModeAds);
			AppSett.SetValue("CNC", "OverrideStyle", overrideStyle);
			AppSett.SetValue("CNC", "PlcVarFeedOverride", plcVarFeedOverride);
			AppSett.SetValue("CNC", "PlcVarSpindleOverride", plcVarSpindleOverride);

			// settings
			AppSett.SetValue("Settings", "PlcVarWriteSettings", plcVarWriteSettings);
			AppSett.SetValue("Settings", "PlcVarNciOverrideChannel1", plcVarNciOverrideChannel1);

			// must be at the end
			AppSett.Buffer().Flush();
			return true;
		}

		void ReadEventLogSettings()
		{
			int value = 0;
			string tmp = AppSett.GetValue("EventLogger", "ColWidth", "");
			string tmp2 = AppSett.GetValue("EventLogger", "DisplayOrder", "");
			string[] tmpX = tmp.Split(';');
			string[] tmp2X = tmp2.Split(';');

			int nMin = eventlogColStatus.GetLowerBound(0);
			int nMax = eventlogColStatus.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				eventlogColStatus[i] = AppSett.GetValue("EventLogger", "Col" + i.ToString(), true);
				eventlogColWidth[i] = 0;
			}

			for (int i = 0; i < MAX_EVENTLOG_COLUMNS; i++)
			{
				eventlogColDisplayOrder[i] = i + 1;
				eventlogColWidth[i] = -1;
			}

			nMin = tmpX.GetLowerBound(0);
			nMax = tmpX.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				value = -1;
				if (int.TryParse(tmpX[i], out value))
					eventlogColWidth[i] = value;
			}

			nMin = tmp2X.GetLowerBound(0);
			nMax = tmp2X.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				value = i + 1;
				if (int.TryParse(tmp2X[i], out value))
					eventlogColDisplayOrder[i] = value;
			}

			eventlogRefreshTime = AppSett.GetValue("EventLogger", "RefreshTime", 1500);
			eventlogLanguage = AppSett.GetValue("EventLogger", "Language", 0);
		}

		void WriteEventLogSettings()
		{
			string tmp = "";
			string tmp2 = "";

			int nMin = eventlogColStatus.GetLowerBound(0);
			int nMax = eventlogColStatus.GetUpperBound(0);
			for (int i = nMin; i <= nMax; i++)
			{
				AppSett.SetValue("EventLogger", "Col" + i.ToString(), eventlogColStatus[i]);
				tmp += eventlogColWidth[i].ToString() + ";";
				tmp2 += eventlogColDisplayOrder[i].ToString() + ";";
			}

			AppSett.SetValue("EventLogger", "ColWidth", tmp);
			AppSett.SetValue("EventLogger", "DisplayOrder", tmp2);
			AppSett.SetValue("EventLogger", "RefreshTime", eventlogRefreshTime);
			AppSett.SetValue("EventLogger", "Language", eventlogLanguage);
		}

	}
}
