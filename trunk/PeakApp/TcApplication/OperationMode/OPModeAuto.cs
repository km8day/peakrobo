using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TcApplication
{
	public partial class OPModeAuto : UserControl
	{
		private const int EM_SETTABSTOPS = 0x00CB;

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr h, int msg, int wParam, int[] lParam);

		public event Beckhoff.App.SelectFile.FileSelectedEventHandler FileNameChanged;
		
		Beckhoff.Forms.TcAdsPlcServer adsPlcServer;
		Beckhoff.Forms.Nc.TcAdsNcServer adsNcServer;

		public OPModeAuto()
		{
			InitializeComponent();
		}

		#region Properties
		
		/// <summary>
		/// Gets or sets the back color caption.
		/// </summary>
		/// <value>The color of the caption back.</value>
		[Description(""), Category("TcCnc")]
		public Color CaptionBackColor
		{
			get { return groupBox1.BackColor; }
			set { groupBox1.BackColor = value; }
		}

		/// <summary>
		/// Gets or sets the caption of the active program.
		/// </summary>
		/// <value>The name of the active program.</value>
		public string ActiveProgramCaption
		{
			get { return labelActiveProgram.Text; }
			set { labelActiveProgram.Text = value; }
		}

		#endregion

		#region Events
		
		private void OPModeAuto_Load(object sender, System.EventArgs e)
		{
			if (MainApp.GetDoc() != null)
			{
				adsPlcServer = MainApp.GetDoc().AdsPlcServer;
				adsNcServer = MainApp.GetDoc().AdsNcServer;
				tcNcProgramSection1.AdsNcServer = adsNcServer;
				selectFile1.FileName = MainApp.appSettings.batchProcess[4];

				TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
				Font newFont = (Font)tc.ConvertFromString(MainApp.appSettings.ncFontName);
				tcNcProgramSection1.Font = newFont;

				int[] stops = { MainApp.appSettings.ncTabWidth };
				SendMessage(tcNcProgramSection1.RichTextBoxHandle, EM_SETTABSTOPS, 1, stops);
			}
		}

		private void timerActiveProgram_Tick(object sender, System.EventArgs e)
		{
			if (MainApp.GetDoc() != null)
			{
				int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
				labelBoxActiveProgram.Text = adsNcServer.NcClient.Channel[selectedChannel].FileName;
			}
		}

		private void OPModeAuto_VisibleChanged(object sender, System.EventArgs e)
		{
			timerActiveProgram.Enabled = this.Visible;
		}

		private void selectFile1_SelectedFileChanged(string strFileName)
		{
			if (MainApp.GetDoc() != null)
			{
				int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;
				MainApp.appSettings.programName[selectedChannel] = strFileName;
				tcNcProgramSection1.CncProgramName = strFileName;

				if (FileNameChanged != null)
					FileNameChanged(strFileName);
			}
		}

		#endregion

	}
}
