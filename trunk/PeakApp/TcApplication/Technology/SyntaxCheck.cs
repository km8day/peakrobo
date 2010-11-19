using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Beckhoff.App.TCLManager;

namespace TcApplication
{
	public partial class SyntaxCheck : UserControl
	{
		Beckhoff.Forms.TcAdsPlcServer adsServer;
		Beckhoff.Forms.TcAdsPlcClient adsPlc;
		bool varStartTimer;
		CTCLManager tclm;
		Timer timer;

		#region Enum Syntax Check Modes

		/// <summary>
		/// Defines the possible Syntax modes for the CNC.
		/// </summary>
		public enum SyntaxCheckMode
		{
			/// <summary>
			/// Off, no syntax Check
			/// </summary>
			OFF = 0,

			/// <summary>
			/// Syntax Check
			/// </summary>
			SyntaxCheck = 2050,

			/// <summary>
			/// Dray Run
			/// </summary>
			DryRun = 64,
		};

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="SyntaxCheck"/> class.
		/// </summary>
		public SyntaxCheck()
		{
			InitializeComponent();
			timer = new Timer();
			timer.Tick += new EventHandler(TimerOnTick);
			timer.Interval = 1000;
		}

		/// <summary>
		/// Stops the syntax check.
		/// </summary>
		/// <returns></returns>
		public bool StopSyntaxCheck()
		{
			Stop_SyntaxCheck();
			return true;
		}

		#region Properties

		/// <summary>
		/// Gets or sets the ads server.
		/// </summary>
		/// <value>The ads server.</value>
		[Description("Gets or sets the Ads server. Connection to the Ads Server."), Category("TcCnc")]
		public Beckhoff.Forms.TcAdsPlcServer AdsPlcServer
		{
			get
			{
				return adsServer;
			}
			set
			{
				adsServer = value;
				if (adsServer != null)
					adsPlc = adsServer.PlcClient;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [timer enabled].
		/// </summary>
		/// <value><c>true</c> if [timer enabled]; otherwise, <c>false</c>.</value>
		[Description("Timer Enable"), Category("TcCnc")]
		public bool TimerEnabled
		{
			get
			{
				return varStartTimer;
			}
			set
			{
				varStartTimer = value;
				if (varStartTimer == true)
					TimerOnTick(null, null);
				timer.Enabled = varStartTimer;
			}
		}

		/// <summary>
		/// Gets or sets the language manager.
		/// </summary>
		/// <value>The language manager.</value>
		[Description("Connects to the Tc Language Manager."), Category("TcCnc")]
		public CTCLManager LanguageManager
		{
			get
			{
				return tclm;
			}
			set
			{
				tclm = value;
				if (tclm != null)
				{
					; // do something
				}
			}
		}

		/// <summary>
		/// Gets or sets the color of the caption back.
		/// </summary>
		/// <value>The color of the caption back.</value>
		[Description(""), Category("TcCnc")]
		public Color CaptionBackColor
		{
			get { return lbHeader.BackColor; }
			set { lbHeader.BackColor = value; }
		}

		#endregion

		#region Events

		private void SyntaxCheck_Load(object sender, EventArgs e)
		{
			if (tclm != null)
			{
				tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
				LoadLanguageStrings();
			}
		}

		private void LoadLanguageStrings()
		{
			if (tclm != null)
			{
				lbHeader.Text = tclm.GetString("SyntaxCheck.lbHeader", "Syntax Check", true);
				lbActive.Text = tclm.GetString("SyntaxCheck.lbActive", "Aktive", true);
				btStart.Text = tclm.GetString("SyntaxCheck.btStart", "Aktive", true);
				btStop.Text = tclm.GetString("SyntaxCheck.btStop", "Stop", true);
				rbSyntaxCheck.Text = tclm.GetString("SyntaxCheck.rbSyntaxCheck", "Syntax Check", true);
				rbDryRun.Text = tclm.GetString("SyntaxCheck.rbDryRun", "Dry Run (without axis movement)", true);
			}
		}

		private void btStop_Click(object sender, EventArgs e)
		{
			Stop_SyntaxCheck();
		}

		private void TimerOnTick(object sender, System.EventArgs e)
		{
			if (Enabled == false)
			{
				timer.Enabled = false;
				return;
			}

			try
			{
				if (adsServer != null && adsServer.PlcIsRunning)
				{
					int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
					string plcVar = ".PLCMachineMode[" + selectedChannel.ToString() + "].SyntaxCheck";

					object obj = adsPlc.ReadSymbol(plcVar + ".nType");
					if (obj != null && ((short)obj == (short)SyntaxCheckMode.SyntaxCheck || (short)obj == (short)SyntaxCheckMode.DryRun))
						lbActive.Visible = true;
					else
						lbActive.Visible = false;
				}
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Error in SyntaxCheck TimerOnTick()", ex);
			}
		}

		private void btStart_Click(object sender, EventArgs e)
		{
			Start_SyntaxCheck();
		}

		private void rbDryRun_CheckedChanged(object sender, EventArgs e)
		{
			Stop_SyntaxCheck();
		}

		private void rbSyntaxCheck_CheckedChanged(object sender, EventArgs e)
		{
			Stop_SyntaxCheck();
		}

		#endregion

		#region Private

		private void Start_SyntaxCheck()
		{
			try
			{
				if (adsServer != null && adsServer.PlcIsRunning)
				{
					int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
					string plcVar = ".PLCMachineMode[" + selectedChannel.ToString() + "].SyntaxCheck";

					// Syntax Check ON
					if (rbSyntaxCheck.Checked)
						adsPlc.WriteSymbol(plcVar + ".nType", (short)SyntaxCheckMode.SyntaxCheck);

					// Dry Run On
					if (rbDryRun.Checked)
						adsPlc.WriteSymbol(plcVar + ".nType", (short)SyntaxCheckMode.DryRun);

					TimerOnTick(null, null);
				}
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Error in Start_SyntaxCheck()", ex);
			}
		}

		private void Stop_SyntaxCheck()
		{
			if (Enabled == false)
				return;

			try
			{
				if (adsServer != null && adsServer.PlcIsRunning)
				{
					int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
					string plcVar = ".PLCMachineMode[" + selectedChannel.ToString() + "].SyntaxCheck";

					// Syntax Check OFF
					adsPlc.WriteSymbol(plcVar + ".nType", (short)SyntaxCheckMode.OFF);

					TimerOnTick(null, null);
				}
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Error in Stop_SyntaxCheck()", ex);
			}
		}

		#endregion

	}
}
