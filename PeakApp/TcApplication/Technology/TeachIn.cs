using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Beckhoff.App.TCLManager;

namespace TcApplication
{
	public partial class TeachIn : UserControl
	{
		Beckhoff.Forms.TcAdsPlcServer adsPlcServer;
		Beckhoff.Forms.Nc.TcAdsNcServer adsNcServer;

		CTCLManager tclm;
		string initDir;
		string initFilter;
		string selectedFile;
		bool generateLineNumber = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TeachIn"/> class.
		/// </summary>
		public TeachIn()
		{
			InitializeComponent();

			initDir = "C:\\TwinCAT\\CNC";
			initFilter = "NC files (*.nc)|*.nc|All files (*.*)|*.*";
		}

		#region Properties
		
		/// <summary>
		/// Gets or sets the ads server.
		/// </summary>
		/// <value>The ads server.</value>
		[Description("Gets or sets the Ads server. Connection to the Ads Server."), Category("TcCnc")]
		public Beckhoff.Forms.TcAdsPlcServer AdsPlcServer
		{
			get { return adsPlcServer; }
			set { adsPlcServer = value; }
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

		/// <summary>
		/// Gets or sets the language manager.
		/// </summary>
		/// <value>The language manager.</value>
		[Description("Connects to the Tc Language Manager."), Category("TcCnc")]
		public CTCLManager LanguageManager
		{
			get { return tclm; }
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

		/// <summary>
		/// Gets or sets a value indicating whether [generate line number].
		/// If set to true line numbers will be generated.
		/// </summary>
		/// <value><c>true</c> if [generate line number]; otherwise, <c>false</c>.</value>
		[Description(""), Category("TcCnc")]
		public bool GenerateLineNumber
		{
			get { return generateLineNumber; }
			set { generateLineNumber = value; }
		}

		#endregion

		#region Events

		private void TeachIn_Load(object sender, EventArgs e)
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
				lbHeader.Text = tclm.GetString("TeachIn.lbHeader", "Teach In", true);
				//lbActive.Text = tclm.GetString("TeachIn.lbActive", "Aktiv", true);
				//btStart.Text = tclm.GetString("TeachIn.btStart", "Aktiv", true);
				//btStop.Text = tclm.GetString("TeachIn.btStop", "Stopp", true);
			}
		}

		private void btAdd_Click(object sender, EventArgs e)
		{
			int selectedChannel = MainApp.GetDoc().AppHeader.ChannelNr;

			if (adsPlcServer == null)
				return;

			int maxChannelAxes = adsNcServer.NcClient.Channel[selectedChannel].AxisMax;
			string[] axisName;
			int[] axisNr;
			string valueOutputFormat = "0.000";

			axisName = new string[maxChannelAxes];
			axisNr = new int[maxChannelAxes];

			int i;
			int axis = 0;
			int maxAxes = adsNcServer.NcClient.InterfaceData.NumberOfAxis;
			for (int j = 1; j <= maxAxes; j++)
			{
				i = j;
				// for the NCI
				if (adsNcServer.ClientPortNr == 501)
					i = adsNcServer.NcClient.Channel[selectedChannel].McAxes[j];

				if (adsNcServer.NcClient.Axis[i].ChannelNr == selectedChannel
					&& adsNcServer.NcClient.Axis[i].AxisName != null)	// this can be a gantry axis, don't show
				{
					axisNr[axis] = i;
					axisName[axis++] = adsNcServer.NcClient.Axis[i].AxisName;
				}
			}

			if (axis != 0)
			{
				// generate the default header
				if (tbTeachIn.TextLength < 3)
				{
					tbTeachIn.Text = "(Teach Program)\r\n";
					tbTeachIn.Text += "(Created: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("T") + ")\r\n";
					tbTeachIn.Text += "G90 G01 F1000 G17\r\n";
				}

				// build 
				string tmp = "";
				string tmpAxisName = "";
				for (i = 0; i < maxChannelAxes; i++)
				{
					tmpAxisName = axisName[i];
					if (tmpAxisName != null)
					{
						char lastChar = tmpAxisName[tmpAxisName.Length-1];
						if ('0' <= lastChar && lastChar <= '9')
							tmpAxisName += "=";

						tmp = tmp + tmpAxisName + adsNcServer.NcClient.Axis[axisNr[i]].McActivePosition.ToString(valueOutputFormat) + " ";
					}
				}

				tbTeachIn.Text += tmp + "\r\n";
			}
		}

		/*
		private void btInsert_Click(object sender, EventArgs e)
		{
			if (lvTeachIn.FocusedItem == null)
				return;
			int idx = lvTeachIn.FocusedItem.Index;
			if (idx == -1)
				return;
			lvTeachIn.Items.Insert(idx, "(* *)");
		}

		private void btDelete_Click(object sender, EventArgs e)
		{
			if (lvTeachIn.FocusedItem == null)
				return;
			lvTeachIn.FocusedItem.Remove();
		}
		*/

		private void btSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.InitialDirectory = initDir;
			dlg.Filter = initFilter;
			dlg.FilterIndex = 1;
			dlg.RestoreDirectory = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				selectedFile = dlg.FileName;
				SaveFile(selectedFile);
			}
		}

		#endregion

		#region Private

		private bool SaveFile(string selectedFile)
		{
			try
			{
				StreamWriter stream = new StreamWriter(selectedFile, false, System.Text.Encoding.Default);

				int rowIdx = 10;
				string tmp;
				for (int row = 0; row < tbTeachIn.Lines.GetLength(0); row++)
				{
					if (tbTeachIn.Lines[row] == "")
						continue;

					if (generateLineNumber )
						tmp = "N" + rowIdx.ToString() + "\t" + tbTeachIn.Lines[row];
					else
						tmp = tbTeachIn.Lines[row];
					rowIdx += 10;
					stream.WriteLine(tmp);
				}

				if (generateLineNumber)
					tmp = "N" + rowIdx.ToString() + "\t" + "M02";
				else
					tmp = "M02";
				stream.WriteLine(tmp);

				stream.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in SaveFile ", ex.Message);
				return false;
			}
			return true;
		}

		#endregion

	}
}
