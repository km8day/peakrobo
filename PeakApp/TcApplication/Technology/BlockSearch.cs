using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Beckhoff.App.TCLManager;
using Beckhoff.Forms;

namespace TcApplication
{
	public partial class BlockSearch : UserControl
	{
		TcAdsPlcServer adsServer;
		TcAdsPlcClient adsPlc;
		bool varStartTimer;
		CTCLManager tclm;
		Timer timer;

		#region Enum Block Search Modes

		/// <summary>
		/// Defines the possible block search modes for the CNC.
		/// </summary>
		public enum BlockSearchMode
		{
			/// <summary>
			/// Off, no block search
			/// </summary>
			OFF = 0,

			/// <summary>
			/// Start position by block count
			/// </summary>
			START_BLOCK_COUNT = 3,

			/// <summary>
			/// Start position by block nr
			/// </summary>
			START_BLOCK_NR,

			/// <summary>
			/// Start position by individual mark
			/// </summary>
			START_INDIVID_MARK
		};

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="T:BlockSearch"/> class.
		/// </summary>
		public BlockSearch()
		{
			InitializeComponent();
			timer = new Timer();
			timer.Tick += new EventHandler(TimerOnTick);
			timer.Interval = 1000;
		}

		/// <summary>
		/// Stops the block search.
		/// </summary>
		/// <returns></returns>
		public bool StopBlockSearch()
		{
			Stop_BlockSearch();
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

		private void rbStartBreakPoint_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (rbStartBreakPoint.Checked && adsServer != null && adsServer.PlcIsRunning)
				{
					Stop_BlockSearch();
					int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
					object obj = adsPlc.ReadSymbol(".CNCSystem.Channel[" + selectedChannel + "].ActBlockCount");
					if (obj != null)
						tbBreakPoint.Text = obj.ToString();
					obj = adsPlc.ReadSymbol(".CNCSystem.Channel[" + selectedChannel + "].ActDistance");
					if (obj != null)
						tbDistance.Text = obj.ToString();

					tbBreakPoint.Enabled = true;
					tbBlockCount.Enabled = false;
					tbBlockNr.Enabled = false;
					tbDistance.Enabled = true;
					btSetBreakPoint.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Error in rbStartBreakPoint_CheckedChanged()", ex);
			}
		}

		private void rbStartBlockNr_CheckedChanged(object sender, EventArgs e)
		{
			if (rbStartBlockNr.Checked)
			{
				Stop_BlockSearch();
				tbDistance.Text = "0";
				tbBreakPoint.Enabled = false;
				tbBlockCount.Enabled = false;
				tbBlockNr.Enabled = true;
				tbDistance.Enabled = true;
				btSetBreakPoint.Enabled = false;
			}
		}

		private void rbBlockCount_CheckedChanged(object sender, EventArgs e)
		{
			if (rbBlockCount.Checked)
			{
				Stop_BlockSearch();
				tbDistance.Text = "0";
				tbBreakPoint.Enabled = false;
				tbBlockCount.Enabled = true;
				tbBlockNr.Enabled = false;
				tbDistance.Enabled = true;
				btSetBreakPoint.Enabled = false;
			}
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
					string plcVar = ".PLCMachineMode[" + selectedChannel.ToString() + "].BlockSearch";

					object obj = adsPlc.ReadSymbol(plcVar + ".Active");
					if (obj != null && (bool)obj)
						lbActive.Visible = true;
					else
						lbActive.Visible = false;

					obj = adsPlc.ReadSymbol(".CNCSystem.Channel[" + selectedChannel + "].ActBlockCount");
					if (obj != null)
						tbActBlockCount.Text = obj.ToString();
					obj = adsPlc.ReadSymbol(".CNCSystem.Channel[" + selectedChannel + "].ActDistance");
					if (obj != null)
						tbActDistance.Text = ((double)obj).ToString("0.0");
				}
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Error in BlockSearch TimerOnTick()", ex);
			}
		}

		private void btStopp_Click(object sender, EventArgs e)
		{
			Stop_BlockSearch();
		}

		private void btStart_Click(object sender, EventArgs e)
		{
			Start_BlockSearch();
		}

		private void BlockSearch_Load(object sender, EventArgs e)
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
				lbHeader.Text = tclm.GetString("BlockSearch.lbHeader", "Satz Suchlauf", true);
				lbActive.Text = tclm.GetString("BlockSearch.lbActive", "Aktiv", true);
				btStart.Text = tclm.GetString("BlockSearch.btStart", "Aktiv", true);
				btStop.Text = tclm.GetString("BlockSearch.btStop", "Stopp", true);
				btStop.Text = tclm.GetString("BlockSearch.btStop", "Stopp", true);
				lbBlockCount.Text = tclm.GetString("BlockSearch.lbBlockCount", "Satzzähler:", true);
				lbActDistance.Text = tclm.GetString("BlockSearch.lbActDistance", "Weg:", true);
				rbStartBreakPoint.Text = tclm.GetString("BlockSearch.rbStartBreakPoint", "Start an Unterbrechungsstelle", true);

				rbStartBlockNr.Text = tclm.GetString("BlockSearch.rbStartBlockNr", "Fortsetzung über Satznummer", true);
				rbBlockCount.Text = tclm.GetString("BlockSearch.rbBlockCount", "Fortsetzung über Satzzähler", true);
				lbDistance.Text = tclm.GetString("BlockSearch.lbDistance", "Zurückgelegter Weg", true);

				tclm.GetString("BlockSearch.MessageString", "Satzvorlaufmodus oder Parameter fehlerhaft!", true);
				tclm.GetString("BlockSearch.MessageHeader", "Satzsuchlauf", true);
			}
		}

		private void btSetBreakPoint_Click(object sender, EventArgs e)
		{
			Stop_BlockSearch();
			tbBreakPoint.Text = tbActBlockCount.Text;
			tbDistance.Text = tbActDistance.Text;
		}

		#endregion

		#region Private

		private void Start_BlockSearch()
		{
			try
			{
				if ((rbStartBreakPoint.Checked && tbBreakPoint.Text != "") || (rbBlockCount.Checked && tbBlockCount.Text != "") || (rbStartBlockNr.Checked && tbBlockNr.Text != ""))
				{
					if (adsServer != null && adsServer.PlcIsRunning)
					{
						int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
						string plcVar = ".PLCMachineMode[" + selectedChannel.ToString() + "].BlockSearch";

						// Automatische Anfahrt an Unterbrechungsstelle
						adsPlc.WriteSymbol(plcVar + ".bAutoReturn", "TRUE");

						// Zurueckgelegter Weg
						if (tbDistance.Text != "")
						{
							adsPlc.WriteSymbol(plcVar + ".fDistance", tbDistance.Text);
						}
						else
						{
							adsPlc.WriteSymbol(plcVar + ".fDistance", "0");
						}

						// Typ festlegen
						if (rbStartBreakPoint.Checked) // Suchtyp Unterbrechungsstelle
						{
							adsPlc.WriteSymbol(plcVar + ".nBlockCount", tbBreakPoint.Text);
							adsPlc.WriteSymbol(plcVar + ".nType", (short)BlockSearchMode.START_INDIVID_MARK);
						}

						if (rbStartBlockNr.Checked)	// Suchtyp Satznummer
						{
							adsPlc.WriteSymbol(plcVar + ".nType", (short)BlockSearchMode.START_BLOCK_NR);
							adsPlc.WriteSymbol(plcVar + ".nBlockNumber", tbBlockNr.Text);
						}

						if (rbBlockCount.Checked)		// Suchtyp Satzzähler
						{
							adsPlc.WriteSymbol(plcVar + ".nType", (short)BlockSearchMode.START_BLOCK_COUNT);
							adsPlc.WriteSymbol(plcVar + ".nBlockCount", tbBlockCount.Text);
						}

						// Suchlauf starten
						adsPlc.WriteSymbol(plcVar + ".bStartWrite", "TRUE");

						// Set Flag Satzsuchlauf aktiv
						adsPlc.WriteSymbol(plcVar + ".Active", "TRUE");

						TimerOnTick(null, null);
					}
				}
				else
				{
					string caption = tclm.GetString("BlockSearch.MessageHeader", "Block Search");
					string msg = tclm.GetString("BlockSearch.MessageString", "Wrong mode or parameter missing");
					MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Error in Start_BlockSearch()", ex);
			}
		}

		private void Stop_BlockSearch()
		{
			if (Enabled == false)
				return;

			try
			{
				if (adsServer != null && adsServer.PlcIsRunning)
				{
					int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
					string plcVar = ".PLCMachineMode[" + selectedChannel.ToString() + "].BlockSearch";

					// Typ auf 0 setzen
					adsPlc.WriteSymbol(plcVar + ".nType", (short)BlockSearchMode.OFF);

					// Wert schreiben
					adsPlc.WriteSymbol(plcVar + ".bStartWrite", "TRUE");

					// Reset Flag Satzsuchlauf aktiv
					adsPlc.WriteSymbol(plcVar + ".Active", "False");

					TimerOnTick(null, null);
				}
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Error in Stop_BlockSearch()", ex);
			}
		}

		#endregion

	}
}
