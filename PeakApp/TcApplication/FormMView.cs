using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Beckhoff.Forms;
using Beckhoff.App.TCLManager;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	public partial class FormMView : FormTcApp
	{
		TcAdsPlcServer adsPlcServer;
		bool enableFKeyFunc = true;
		float scalX;
		float scalY;
		int numberOfViews;
		TcApplication.MVStatus[] MViewBox;
		Point[] MViewBoxPoint;
		bool initDone;
		Size screenSize;
		int nStretchImage;
		Beckhoff.App.Setting.Ini MViewCfg;

		public FormMView(Form form)
		{
			parentForm = form;
			InitializeComponent();

			tclm = MainApp.GetDoc().GetTCLanguageManager();
			adsPlcServer = MainApp.GetDoc().AdsPlcServer;

			initDone = true;
		}

		/// <summary>
		/// Enables/Disables the form internal function keys.
		/// </summary>
		public void EnableFKeyFunction(bool bEnable)
		{
			enableFKeyFunc = bEnable;
		}

		#region Implementation of Function Keys

		private void SetFunctionKeys(Beckhoff.App.TcFKey fKey)
		{
			/* MK
			fKey.InstallFKeyDelegate(null, new FKeyDelegate(FKeyUpEvent));
			fKey.FKeyTextAlign = System.Drawing.ContentAlignment.BottomLeft;
			fKey.FKeyImageAlign = System.Drawing.ContentAlignment.TopCenter;
			SetFKeyText(fKey);
			*/
		}

		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
			//fKey.FKeyTextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//fKey.FKeyImageAlign = System.Drawing.ContentAlignment.TopCenter;

			fKey.FKeyText(1, tclm.GetString("FormMView.tcFKey1[1]", "Load"));
		}

		public override void FKeyUpEvent(int nIdx)
		{
			switch (nIdx)
			{
				case 1:
					LoadFile(Application.StartupPath + "\\Customer\\Machine.jpg");
					break;

				case 2:
					// Position on/off
					if (gbCurrentPosition.Visible)
						gbCurrentPosition.Visible = false;
					else
						gbCurrentPosition.Visible = true;
					break;
				case 3:
					// open config file
					try
					{
						Process newProcess = new Process();
						newProcess.StartInfo.FileName = "Notepad.exe";
						newProcess.StartInfo.Arguments = Application.StartupPath + "\\Customer\\MView.ini";
						newProcess.StartInfo.UseShellExecute = false;
						newProcess.StartInfo.CreateNoWindow = true;
						newProcess.StartInfo.RedirectStandardOutput = true;
						newProcess.Start();
					}
					catch
					{
						MessageBox.Show("MView ini file could not be found!", "MView", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					break;
				case 4:
					ReadConfig();
					break;
			}
		}

		private void Form_Activated(object sender, EventArgs e)
		{
			if (enableFKeyFunc)
			{
				SetFunctionKeys(MainApp.GetDoc().tcFKey1);
			}

			// Only the Administrator can change the configuration
			if (MainApp.GetDoc().tcUserAdmin1.CurrentUserLevel == Beckhoff.App.Security.TcUserLevel.Administrator)
				this.btnConfig.Visible = true;
			else
				this.btnConfig.Visible = false;

			timer1.Enabled = true;
			timer1_Tick(null, null);	// for faster progress
		}

		#endregion

		#region Events

		private void FormMView_Load(object sender, EventArgs e)
		{
			tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
			LoadLanguageStrings();
			LoadFile(Application.StartupPath + "\\Customer\\Machine.jpg");

			string fileName = Application.StartupPath + "\\Customer\\MView.ini";
			MViewCfg = new Beckhoff.App.Setting.Ini(fileName);
			if (!File.Exists(fileName))
			{
				WriteDefaultConfig();
				MessageBox.Show("MView ini file could not be found! Default configuration is set.\r\n" + fileName, "MView", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			if (File.Exists(fileName))
			{
				ReadConfig();
			}
		}

		private void FormMView_Deactivate(object sender, EventArgs e)
		{
			timer1.Enabled = false;
		}

		private void btnConfig_Click1(object sender, EventArgs e)
		{
			FKeyUpEvent(2);
		}

		private void btnOpen_Click1(object sender, EventArgs e)
		{
			FKeyUpEvent(3);
		}

		private void btnRead_Click1(object sender, EventArgs e)
		{
			FKeyUpEvent(4);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			FKeyUpEvent(2);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized;

			if (initDone == false)
				return;

			if (this.Height < 1 || this.Width < 1)
				return;

			if (nStretchImage != 0 && this.MViewBox != null)
			{
				// calc scaling
				scalX = (float)this.Width / screenSize.Width;
				scalY = (float)this.Height / screenSize.Height;

				for (int i = 0; i < numberOfViews; i++)
				{
					MViewBox[i].Location = new System.Drawing.Point((int)((float)MViewBoxPoint[i].X * scalX), (int)((float)MViewBoxPoint[i].Y * scalY));
				}
			}
		}

		private void picBoxMaschineView_MouseMove(object sender, MouseEventArgs e)
		{
			float pos_X, pos_Y;

			PointF m_snap_position;
			m_snap_position = new PointF(e.X, e.Y);

			// Scale
			if (nStretchImage != 0)
			{
				scalX = (float)this.Width / screenSize.Width;
				scalY = (float)this.Height / screenSize.Height;
			}
			else
			{
				scalX = 1;
				scalY = 1;
			}

			pos_X = e.X / scalX;
			pos_Y = e.Y / scalY;

			lblMouseX1.Text = pos_X.ToString("0");
			lblMouseY.Text = pos_Y.ToString("0");
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (MainApp.GetDoc().ActiveMdiChild is TcApplication.FormMView
				&& adsPlcServer != null
				&& adsPlcServer.PlcIsRunning)
			{
				TwinCAT.Ads.AdsStream adsStream = new TwinCAT.Ads.AdsStream(500);
				BinaryReader binRead = new BinaryReader(adsStream);
				int res;

				try
				{
					for (int i = 0; i < numberOfViews; i++)
					{
						adsStream.Position = 0;
						res = adsPlcServer.PlcClient.Read(".MViewStatus[" + (i + 1) + "].Color", ref adsStream);
						for (int field = 0; field < MViewBox[i].Fields; field++)
						{
							MViewBox[i].ValueBackColor(field, GetColor(binRead.ReadInt16()));
						}

						adsStream.Position = 0;
						res = adsPlcServer.PlcClient.Read(".MViewStatus[" + (i + 1) + "].Description", ref adsStream);
						for (int field = 0; field < MViewBox[i].Fields; field++)
						{
							MViewBox[i].Value(field, new string(binRead.ReadChars(31)));
						}
					}
				}
				catch (Exception ex)
				{
					MainApp.log.Error("Error in FormMView timer1_Tick()", ex);
				}
			}
		}

		private void LoadLanguageStrings()
		{
		}

		#endregion

		#region Private

		private void ReadConfig()
		{
			int nPos_X;
			int nPos_Y;
			string sMView_Name;
			int nWidth, nHeight;
			int nCycleTime;
			int fields;

			// Default Screen 
			screenSize.Width = 1604;
			screenSize.Height = 970;

			// Delete views
			if (numberOfViews > 0)
			{
				for (int j = 0; j < numberOfViews; j++)
				{
					Controls.Remove(this.MViewBox[j]);
				}
			}

			numberOfViews = MViewCfg.GetValue("General", "NumberOfViews", 0);
			nCycleTime = MViewCfg.GetValue("General", "Cycle_Time", 1500);
			nStretchImage = MViewCfg.GetValue("General", "StretchImage", 0);

			if (nCycleTime < 750)
				nCycleTime = 750;

			if (nStretchImage == 0)
			{
				this.picBoxMaschineView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;

				// Scale 
				scalX = 1;
				scalY = 1;
			}
			else
			{
				this.picBoxMaschineView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

				// Scale 
				scalX = (float)this.Width / screenSize.Width;
				scalY = (float)this.Height / screenSize.Height;
			}

			MViewBox = new TcApplication.MVStatus[numberOfViews];
			MViewBoxPoint = new Point[numberOfViews];

			for (int i = 0; i < numberOfViews; i++)
			{
				// read the values for the MView Box
				sMView_Name = MViewCfg.GetValue("MView" + (i + 1).ToString(), "Name", "");
				fields = MViewCfg.GetValue("MView" + (i + 1).ToString(), "Fields", 5);
				nPos_X = MViewCfg.GetValue("MView" + (i + 1).ToString(), "Pos_X", 0);
				nPos_Y = MViewCfg.GetValue("MView" + (i + 1).ToString(), "Pos_Y", 0);
				nWidth = MViewCfg.GetValue("MView" + (i + 1).ToString(), "Width", 0);
				nHeight = MViewCfg.GetValue("MView" + (i + 1).ToString(), "Height", 0);

				MViewBox[i] = new TcApplication.MVStatus();
				MViewBox[i].Location = new System.Drawing.Point((int)(nPos_X * scalX), (int)(nPos_Y * scalY));
				MViewBox[i].Name = "mvStatus";
				MViewBox[i].Size = new System.Drawing.Size(nWidth, nHeight);
				MViewBox[i].TabIndex = 0;
				MViewBox[i].Fields = fields;

				Controls.Add(MViewBox[i]);
				MViewBox[i].Caption = sMView_Name;
				MViewBox[i].BringToFront();

				MViewBoxPoint[i].X = nPos_X;
				MViewBoxPoint[i].Y = nPos_Y;
			}

			// start timer
			timer1.Interval = nCycleTime;
			timer1.Enabled = true;
			timer1_Tick(null, null);	// for faster progress
		}

		private void WriteDefaultConfig()
		{
			MViewCfg.SetValue("General", "NumberOfViews", 3);	// default 3 blocks
			MViewCfg.SetValue("General", "Cycle_Time", 1500);
			MViewCfg.SetValue("General", "StretchImage", 0);

			for (int i = 1; i <= 3; i++)
			{
				// write the default values
				MViewCfg.SetValue("MView" + i.ToString(), "Fields", 5);	// number of rows
				MViewCfg.SetValue("MView" + i.ToString(), "Pos_X", 100 * i);
				MViewCfg.SetValue("MView" + i.ToString(), "Pos_Y", 100);
				MViewCfg.SetValue("MView" + i.ToString(), "Width", 150);
				MViewCfg.SetValue("MView" + i.ToString(), "Height", 100);
				MViewCfg.SetValue("MView" + i.ToString(), "Name", "Status" + i.ToString());
			}
		}

		private bool LoadFile(string fileName)
		{
			if (File.Exists(fileName))
			{
				picBoxMaschineView.Image = Image.FromFile(fileName);
				return true;
			}
			return false;
		}

		private Color GetColor(int idx)
		{
			switch (idx)
			{
				case 0: return Color.White;
				case 1: return Color.Gray;
				case 2: return Color.DarkGray;
				case 3: return Color.Silver;
				case 4: return Color.Red;
				case 5: return Color.Orange;
				case 6: return Color.Yellow;
				case 7: return Color.LawnGreen;
				case 8: return Color.LightGreen;
				case 9: return Color.Green;
				case 10: return Color.Aqua;
				case 11: return Color.SkyBlue;
				case 12: return Color.LightBlue;
				case 13: return Color.Blue;
				case 14: return Color.Magenta;
				case 15: return Color.Pink;
			}
			return Color.White;
		}

		#endregion

	}
}
