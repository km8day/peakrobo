using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Beckhoff.Forms;

namespace TcApplication
{
	public partial class FormSymbolBrowser : Form
	{
		public FormSymbolBrowser()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the Ads server. Connection to the Ads.
		/// </summary>
		/// <value>The ads server.</value>
		[Description("Gets or sets the Ads server. Connection to the Ads."), Category("TcAds")]
		public TcAdsPlcServer AdsPlcServer
		{
			get
			{
				return tcSymbolBrowser1.AdsPlcServer;
			}
			set
			{
				if (tcSymbolBrowser1.AdsPlcServer != null)
					tcSymbolBrowser1.AdsPlcServer.TcPlcStateChanged -= AdsPlcServer_TcPlcStateChanged;

				tcSymbolBrowser1.AdsPlcServer = value;
				if (tcSymbolBrowser1.AdsPlcServer != null)
					tcSymbolBrowser1.AdsPlcServer.TcPlcStateChanged += new TcAdsStateChangedEventHandler(AdsPlcServer_TcPlcStateChanged);
			}
		}

		void buttonOk_Click(object sender, EventArgs e)
		{
			Close();
		}

		void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		void FormSymbolBrowser_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (tcSymbolBrowser1.AdsPlcServer != null)
				tcSymbolBrowser1.AdsPlcServer.TcPlcStateChanged -= AdsPlcServer_TcPlcStateChanged;
		}

		void AdsPlcServer_TcPlcStateChanged(TwinCAT.Ads.AdsState state)
		{
			tcSymbolBrowser1.CheckActive();
		}

	}
}
