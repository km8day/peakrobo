using System;
using System.Windows.Forms;
using Beckhoff.Forms;
using Beckhoff.Forms.Nc;
using System.Reflection;
using Beckhoff.App;

namespace TcApplication
{
	public partial class FormSystemInfo
	{
		TcAdsNcServer adsNcServer;
		TcAdsPlcServer adsPlcServer;
		FormSystemInformation frmSystemInfo = new FormSystemInformation();

		/// <summary>
		/// Initializes a new instance of the <see cref="FormSystemInfo"/> class.
		/// </summary>
		public FormSystemInfo()
		{
			adsNcServer = MainApp.GetDoc().AdsNcServer;
			adsPlcServer = MainApp.GetDoc().AdsPlcServer;

			int languageId = 1031;
			if (MainApp.GetDoc().tcUserAdmin1.CurrentUser.Language != 0)
				languageId = 1033;
			frmSystemInfo.LanguageId = languageId;
			frmSystemInfo.Add(Assembly.GetExecutingAssembly().ManifestModule.Name, ApplicationVersion);
			frmSystemInfo.Add("TwinCAT.Ads.dll", typeof(TwinCAT.Ads.TcAdsClient));
			frmSystemInfo.Add("Beckhoff.Forms.dll", typeof(Beckhoff.Forms.TcAdsPlcServer));
			frmSystemInfo.Add("Beckhoff.Forms.Nc.dll", typeof(Beckhoff.Forms.Nc.TcAdsNcServer));
			frmSystemInfo.Add("Beckhoff.App.dll", typeof(Beckhoff.App.TcFKey));
			frmSystemInfo.Add("Beckhoff.EventLogger.dll", typeof(Beckhoff.EventLogger.TcLog4NetView));
			frmSystemInfo.Add("TcAppPlcManual.dll", typeof(TwinCAT.App.ManualFunctions.TcAppPlcManual));
			frmSystemInfo.Add("TwinCAT System.dll", TwinCATVersion);
			if (adsNcServer != null && adsNcServer.ClientPortNr == 553)
				frmSystemInfo.Add("TwinCAT CNC", CNCVersion);
			if (adsNcServer != null && adsNcServer.ClientPortNr == 501)
				frmSystemInfo.Add("TwinCAT NCI", CNCVersion);
			frmSystemInfo.Add("TwinCAT PLC Project", PlcProject);
		}

		/// <summary>
		/// Shows the system information dialog of the application and used assemblies.
		/// </summary>
		public void ShowDialog()
		{
			frmSystemInfo.ShowDialog();
		}

		#region Private

		/// <summary>
		/// Gets the TwinCAT version.
		/// </summary>
		/// <value>The TwinCAT version.</value>
		string TwinCATVersion
		{
			get
			{
				string str = adsPlcServer.PlcClient.ReadDeviceInfoString();
				if (string.IsNullOrEmpty(str))
					return "Unable to reach server";
				else
					return str;
			}
		}

		/// <summary>
		/// Gets the CNC version.
		/// </summary>
		/// <value>The CNC version.</value>
		string CNCVersion
		{
			get
			{
				string str = adsNcServer.NcClient.InterfaceData.VersionNumber;
				if (string.IsNullOrEmpty(str))
					return "Unable to reach server";
				else
					return str;
			}
		}

		/// <summary>
		/// Gets the application version.
		/// </summary>
		/// <value>The application version.</value>
		string ApplicationVersion
		{
			get
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
				AssemblyName assemName = assembly.GetName();
				return assemName.Version.ToString();
			}
		}

		/// <summary>
		/// Gets the name of the PLC project.
		/// </summary>
		/// <value>The name of the PLC project.</value>
		string PlcProject
		{
			get
			{
				try
				{
					string plcName = (string)adsPlcServer.PlcClient.ReadSymbol(".SystemInfo.projectName");
					return plcName;
				}
				catch
				{
					return "Unable to reach server";
				}
			}
		}

		#endregion

	}
}
