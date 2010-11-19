using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Beckhoff.Forms;
using Beckhoff.Forms.Nc;

namespace TcApplication
{
	public partial class OPModeManual : UserControl
	{
		TcAdsNcServer adsNcServer;

		public OPModeManual()
		{
			InitializeComponent();

			rbManualModeIncrements1.Enabled = false;
			rbManualModeIncrements10.Enabled = false;
			rbManualModeIncrements100.Enabled = false;
			rbManualModeIncrements1000.Enabled = false;
		}

		#region Public Functions

		public void SetManualModeAxisParam()
		{
			int speed = 0;
			int incs = 0;
			int scaling = 10;	// set to µm
			// get speed
			try { speed = (int)((float)int.Parse(textBoxManualModeSpeed.Text)); }
			catch { }
			if (speed < 0) speed = 1;
			// get increments
			if (rbManualModeIncrements1.Checked) incs = 1 * scaling;
			if (rbManualModeIncrements10.Checked) incs = 10 * scaling;
			if (rbManualModeIncrements100.Checked) incs = 100 * scaling;
			if (rbManualModeIncrements1000.Checked) incs = 1000 * scaling;

			// set values
			if (adsNcServer != null && adsNcServer.NcIsRunning)
				adsNcServer.NcClient.NcManual.ManualModeAxisParam(speed, incs);
		}

		#endregion

		#region Events Functions

		private void rbManualTipMode_CheckedChanged(object sender, System.EventArgs e)
		{
			// 1-Handrad, 2-Tippbetrieb kontinuierlich, 3-Jogbetrieb incr.
			if (rbManualTipMode.Checked && adsNcServer != null)
			{
				adsNcServer.NcClient.NcManual.ManualAxisMode(TcCncAxisManualOpMode.Continuous);
				rbManualModeIncrements1.Enabled = false;
				rbManualModeIncrements10.Enabled = false;
				rbManualModeIncrements100.Enabled = false;
				rbManualModeIncrements1000.Enabled = false;
			}
		}

		private void rbManualJogMode_CheckedChanged(object sender, System.EventArgs e)
		{
			// 1-Handrad, 2-Tippbetrieb kontinuierlich, 3-Jogbetrieb incr.
			if (rbManualJogMode.Checked && adsNcServer != null)
			{
				adsNcServer.NcClient.NcManual.ManualAxisMode(TcCncAxisManualOpMode.Incremental);
				rbManualModeIncrements1.Enabled = true;
				rbManualModeIncrements10.Enabled = true;
				rbManualModeIncrements100.Enabled = true;
				rbManualModeIncrements1000.Enabled = true;
			}
		}

		private void textBoxManualModeSpeed_Leave(object sender, System.EventArgs e)
		{
			SetManualModeAxisParam();
		}

		private void rbManualModeIncrements1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbManualModeIncrements1.Checked)
				SetManualModeAxisParam();
		}

		private void rbManualModeIncrements10_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbManualModeIncrements10.Checked)
				SetManualModeAxisParam();
		}
		private void rbManualModeIncrements100_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbManualModeIncrements100.Checked)
				SetManualModeAxisParam();
		}

		private void rbManualModeIncrements1000_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbManualModeIncrements1000.Checked)
				SetManualModeAxisParam();
		}

		private void buttonDownload_Click(object sender, System.EventArgs e)
		{
			SetManualModeAxisParam();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the caption text of the control.
		/// </summary>
		/// <value>The manual caption text of the control.</value>
		[Description(""), Category("TcCnc")]
		public string Caption
		{
			get { return labelBoxManual.Text; }
			set { labelBoxManual.Text = value; }
		}

		/// <summary>
		/// Gets or sets the backcolor of the caption.
		/// </summary>
		/// <value>The backcolor of the caption.</value>
		[Description(""), Category("TcCnc")]
		public Color CaptionBackColor
		{
			get { return groupBox3.BackColor; }
			set { groupBox3.BackColor = value; }
		}

		/// <summary>
		/// Gets or sets the ads server.
		/// </summary>
		/// <value>The ads server.</value>
		[Description("Gets or sets the Ads server. Connection to the Ads Server."), Category("TcCnc")]
		public Beckhoff.Forms.Nc.TcAdsNcServer AdsNcServer
		{
			get { return adsNcServer; }
			set { adsNcServer = value; }
		}

		#endregion

	}
}
