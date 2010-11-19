using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Beckhoff.Forms;
using Beckhoff.App.MachineParam;
using Beckhoff.App.TCLManager;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	public partial class FormMaschPara : FormTcApp
	{
		TcAdsPlcServer adsPlcServer;

		public FormMaschPara(Form form)
		{
			parentForm = form;
			InitializeComponent();

			// Language Manager
			tclm = MainApp.GetDoc().GetTCLanguageManager();
			tcMachineParam1.LanguageManager = tclm;
			tcMachineParam1.UserLevel = MainApp.GetDoc().tcUserAdmin1.CurrentUserLevel;
			tcMachineParam1.ValidateValue += new TcMachineParam.OnValidateValue(tcMachineParam1_ValidateValue);
			MainApp.GetDoc().tcUserAdmin1.CurrentUserChanged += new Beckhoff.App.Security.TcUserAdmin.CurrentUserChangedEventHandler(tcUserAdmin1_CurrentUserChanged);

			// error handler
			tcMachineParam1.Error += new TcMachineParam.MaschParErrorEventHandler(tcMachineParam1_Error);

			if (tcMachineParam1.Read(Application.StartupPath + "\\System\\MaschParam.ini") == false)
				MainApp.log.Error("Machine parameter ini file could not be found! \\System\\MaschParam.ini");

			adsPlcServer = MainApp.GetDoc().AdsPlcServer;
			if (adsPlcServer != null)
				adsPlcServer.TcPlcStateChanged += new TcAdsStateChangedEventHandler(adsPlcServer_TcPlcStateChanged);

			labelCaption.BackColor = MainApp.GetDoc().ColorCaption;
		}

		#region Public Functions

		/// <summary>
		/// Gets or sets the current group of the machine parameter list.
		/// </summary>
		[Description("Gets or sets the current group of the machine parameter list."), Category("TcApplication")]
		public void CurrentList(int list, string name)
		{
			if (string.IsNullOrEmpty(name))
				tcMachineParam1.CurrentList(list);
			else
				tcMachineParam1.CurrentList(name);
		}

		/// <summary>
		/// Gets or sets the current group of the machine parameter list.
		/// </summary>
		[Description("Gets or sets the current row of the machine parameter list."), Category("TcApplication")]
		public void CurrentRow(int row)
		{
			tcMachineParam1.CurrentRow(row);
		}

		/// <summary>
		/// Sets the column width of the list view.
		/// </summary>
		/// <param name="col">The col.</param>
		/// <param name="width">The width.</param>
		public void ColumnWidth(int col, int width)
		{
			tcMachineParam1.ColumnWidth(col, width);
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets a value indicating whether [tree view visible].
		/// </summary>
		/// <value><c>true</c> if [tree view visible]; otherwise, <c>false</c>.</value>
		[Description("Gets or sets a value indicating whether [tree view visible]."), Category("TcApplication")]
		public bool TreeViewVisible
		{
			get { return tcMachineParam1.TreeViewVisible; }
			set { tcMachineParam1.TreeViewVisible = value; }
		}

		#endregion

		#region Implementation of Function Keys

		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
			fKey.FKeyTextAlign = System.Drawing.ContentAlignment.BottomLeft;
			fKey.FKeyImageAlign = System.Drawing.ContentAlignment.TopRight;

			fKey.FKeyText(1, tclm.GetString("FormMaschPara.tcFKey1[1]", "Help"), Image.FromFile(Application.StartupPath + "\\Bitmap\\Help.ico"));
			fKey.FKeyText(6, tclm.GetString("FormMaschPara.tcFKey1[6]", "Save"), Image.FromFile(Application.StartupPath + "\\Bitmap\\Save.ico"));
			fKey.FKeyText(7, tclm.GetString("FormMaschPara.tcFKey1[7]", "Write to PLC"));
		}

		public override void FKeyUpEvent(int nIdx)
		{
			switch (nIdx)
			{
				case 1:
					MessageBox.Show("Not implemented");
					break;
				case 6:
					//tcMachineParam1.Write(Application.StartupPath + "\\System\\MaschParam.ini");
					if (tcMachineParam1.ConfigHasChanged)
					{
						//writes the configuration and data
						tcMachineParam1.Write();
						//writes the language strings to the database
						WriteCurrentLanguageStringsToDB();
					}
					else
						//writes the data only
						tcMachineParam1.WriteData();
					break;
				case 7:
					WriteAllListsToPlc();
					break;
			}
		}

		#endregion

		#region Events

		private void FormMaschPar_Load(object sender, System.EventArgs e)
		{
			tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
			LoadLanguageStrings();
		}

		void tcMachineParam1_Error(object sender, string message)
		{
			MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			MainApp.log.Error(message);
		}

		void tcUserAdmin1_CurrentUserChanged(Beckhoff.App.Security.TcUser user, bool logOn)
		{
			if (logOn == true)
				tcMachineParam1.UserLevel = user.UserLevel;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized;
		}

		private void adsPlcServer_TcPlcStateChanged(TwinCAT.Ads.AdsState state)
		{
			if (state == TwinCAT.Ads.AdsState.Run)
				WriteAllListsToPlc();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				ReadListFromPlc();
			}
			catch
			{ }
		}

		void tcMachineParam1_ValidateValue(object sender, CancelEventArgs e, int rowNumber, MachineParamData data)
		{
			try
			{
				if (data.Value.Length == 0)
					return;

				if (adsPlcServer.PlcIsRunning)
				{
					MachineParamList list = tcMachineParam1.SelectedList;
					TwinCAT.Ads.ITcAdsSymbol symbol = adsPlcServer.PlcClient.ReadSymbolInfo(list.PLCVar);
					if (symbol != null)
					{
						switch (symbol.Datatype)
						{
							case TwinCAT.Ads.AdsDatatypeId.ADST_BIT:
								if (data.DataType != typeof(bool))
									e.Cancel = true;
								break;
							case TwinCAT.Ads.AdsDatatypeId.ADST_INT8:
							case TwinCAT.Ads.AdsDatatypeId.ADST_INT16:
							case TwinCAT.Ads.AdsDatatypeId.ADST_INT32:
							case TwinCAT.Ads.AdsDatatypeId.ADST_INT64:
							case TwinCAT.Ads.AdsDatatypeId.ADST_UINT8:
							case TwinCAT.Ads.AdsDatatypeId.ADST_UINT16:
							case TwinCAT.Ads.AdsDatatypeId.ADST_UINT32:
							case TwinCAT.Ads.AdsDatatypeId.ADST_UINT64:
								if (data.DataType != typeof(int))
									e.Cancel = true;
								break;
							case TwinCAT.Ads.AdsDatatypeId.ADST_REAL32:
							case TwinCAT.Ads.AdsDatatypeId.ADST_REAL64:
							case TwinCAT.Ads.AdsDatatypeId.ADST_REAL80:
								if (data.DataType != typeof(int)
									&& data.DataType != typeof(double))
									e.Cancel = true;
								break;
						}
					}
				}

				/*
				double oldVal = data.val;
				double val = double.Parse(((TextBox)sender).Text);

				if (rowNumber == 10 && val > 100)
				{
					MessageBox.Show("Out of range. Value to big!");
					e.Cancel = true;
				}
				*/
			}
			catch
			{
				e.Cancel = true;
			}
		}

		private void FormMaschPara_Deactivate(object sender, EventArgs e)
		{
			if (tcMachineParam1.ConfigHasChanged)
			{
				string tmp = tclm.GetString(this.Name + ".SaveChangesQuest", "The configuration of the machining data has changed.\r\nDo you want to save changes?");
				string tmp2 = tclm.GetString(this.Name + ".SaveChangesCaption", "Save changes");
				if (MessageBox.Show(tmp, tmp2, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					//writes the configuration and data
					tcMachineParam1.Write();
					//writes the language strings to the database
					WriteCurrentLanguageStringsToDB();
				}
				//discard changes
				tcMachineParam1.ConfigHasChanged = false;
				//FKeyUpEvent(nIdx);
			}
		}

		#endregion

		#region Private functions

		private void ReadListFromPlc()
		{
			int i = 0;
			MachineParamList list = tcMachineParam1.SelectedList;

			if (adsPlcServer == null
				|| adsPlcServer.PlcIsRunning == false
				|| list == null
				|| list.Disabled == true
				|| list.PLCVar.Length == 0)
			{
				return;
			}


			try
			{
				int rows = list.Data.Count;
				TwinCAT.Ads.ITcAdsSymbol symbol = adsPlcServer.PlcClient.ReadSymbolInfo(list.PLCVar);

				if (symbol == null)
				{
					MainApp.log.Error("Machine parameter list cannot be read from the Plc! Symbol not found! List: " + list.Name + " PlcVar: " + list.PLCVar);
					return;
				}

				switch (symbol.Datatype)
				{
					case TwinCAT.Ads.AdsDatatypeId.ADST_BIT:
						bool[] b = (bool[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(bool[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = b[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_INT8:
						sbyte[] n8 = (sbyte[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(sbyte[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = n8[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_INT16:
						Int16[] n16 = (Int16[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(Int16[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = n16[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_INT32:
						Int32[] n32 = (Int32[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(Int32[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = n32[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_INT64:
						Int64[] n64 = (Int64[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(Int64[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = n64[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_UINT8:
						byte[] u8 = (byte[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(byte[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = u8[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_UINT16:
						UInt16[] u16 = (UInt16[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(UInt16[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = u16[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_UINT32:
						UInt32[] u32 = (UInt32[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(UInt32[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = u32[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_UINT64:
						UInt64[] u64 = (UInt64[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(UInt64[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = u64[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_REAL32:
						float[] f32 = (float[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(float[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = f32[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_REAL64:
						double[] f64 = (double[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(double[]), new int[] { rows });
						for (i = 0; i < rows; i++)
							list.Data[i].Value = f64[i].ToString();
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_BIGTYPE:
						{
							if (symbol.Type.Contains("STRING"))
							{
								int stringLength = 0;
								bool res = adsPlcServer.PlcClient.GetBigTypeArgs(symbol.Type, ref stringLength);
								if (res == true)
								{
									string[] fVal = (string[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(string[]), new int[] { stringLength, rows });
									for (i = 0; i < rows; i++)
										list.Data[i].Value = fVal[i].ToString();
								}
							}
							else if (symbol.Type.Contains("TIME"))
							{
								UInt32[] fVal = (UInt32[])adsPlcServer.PlcClient.ReadAny(list.PLCVar, typeof(UInt32[]), new int[] { rows });
								for (i = 0; i < rows; i++)
									list.Data[i].Value = fVal[i].ToString();
							}
						}
						break;
					default:
						MainApp.log.Error("Machine parameter list cannot be read from the Plc! Datatype not supported! List: " + list.Name + ", PlcVar: " + list.PLCVar);
						break;
				}

				// write the data back to the grid
				tcMachineParam1.FillGrid(list);
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Error in FormMaschPara ReadListFromPlc()", ex);
			}
		}

		private void WriteAllListsToPlc()
		{
			for (int i = 0; i < tcMachineParam1.MaxParaLists; i++)
				WriteListToPlc(i);
		}

		private void WriteListToPlc(int listIdx)
		{
			int i = 0;
			// get reference from parameter list object
			MachineParamList list = tcMachineParam1.GetMParList(listIdx);

			if (adsPlcServer == null
				|| adsPlcServer.PlcIsRunning == false
				|| list == null
				|| list.Disabled == true
				|| list.PLCVar.Length == 0)
			{
				return;
			}


			try
			{
				int rows = list.Data.Count;
				TwinCAT.Ads.ITcAdsSymbol symbol = adsPlcServer.PlcClient.ReadSymbolInfo(list.PLCVar);

				if (symbol == null)
				{
					MainApp.log.Error("Machine parameter list cannot be written to the Plc! Symbol not found! List: " + list.Name + " PlcVar: " + list.PLCVar);
					return;
				}

				switch (symbol.Datatype)
				{
					case TwinCAT.Ads.AdsDatatypeId.ADST_BIT:
						bool[] b = new bool[rows];
						for (i = 0; i < rows; i++)
							b[i] = (list.Data[i].Value.Length == 0) ? false : bool.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, b);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_INT8:
						sbyte[] n8 = new sbyte[rows];
						for (i = 0; i < rows; i++)
							n8[i] = (list.Data[i].Value.Length == 0) ? (sbyte)0 : sbyte.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, n8);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_INT16:
						Int16[] n16 = new Int16[rows];
						for (i = 0; i < rows; i++)
							n16[i] = (list.Data[i].Value.Length == 0) ? (Int16)0 : Int16.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, n16);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_INT32:
						Int32[] n32 = new Int32[rows];
						for (i = 0; i < rows; i++)
							n32[i] = (list.Data[i].Value.Length == 0) ? (Int32)0 : Int32.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, n32);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_INT64:
						Int64[] n64 = new Int64[rows];
						for (i = 0; i < rows; i++)
							n64[i] = (list.Data[i].Value.Length == 0) ? (Int64)0 : Int64.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, n64);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_UINT8:
						byte[] u8 = new byte[rows];
						for (i = 0; i < rows; i++)
							u8[i] = (list.Data[i].Value.Length == 0) ? (byte)0 : byte.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, u8);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_UINT16:
						UInt16[] u16 = new UInt16[rows];
						for (i = 0; i < rows; i++)
							u16[i] = (list.Data[i].Value.Length == 0) ? (UInt16)0 : UInt16.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, u16);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_UINT32:
						UInt32[] u32 = new UInt32[rows];
						for (i = 0; i < rows; i++)
							u32[i] = (list.Data[i].Value.Length == 0) ? (UInt32)0 : UInt32.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, u32);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_UINT64:
						UInt64[] u64 = new UInt64[rows];
						for (i = 0; i < rows; i++)
							u64[i] = (list.Data[i].Value.Length == 0) ? (UInt64)0 : UInt64.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, u64);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_REAL32:
						float[] f32 = new float[rows];
						for (i = 0; i < rows; i++)
							f32[i] = (list.Data[i].Value.Length == 0) ? 0 : float.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, f32);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_REAL64:
						double[] f64 = new double[rows];
						for (i = 0; i < rows; i++)
							f64[i] = (list.Data[i].Value.Length == 0) ? 0 : double.Parse(list.Data[i].Value);
						adsPlcServer.PlcClient.WriteAny(list.PLCVar, f64);
						break;
					case TwinCAT.Ads.AdsDatatypeId.ADST_BIGTYPE:
						{
							if (symbol.Type.Contains("STRING"))
							{
								string[] strVal = new string[rows];
								for (i = 0; i < rows; i++)
									strVal[i] = list.Data[i].Value;
								int stringLength = 0;
								bool res = adsPlcServer.PlcClient.GetBigTypeArgs(symbol.Type, ref stringLength);
								if (res == true)
									adsPlcServer.PlcClient.WriteAny(list.PLCVar, strVal, new int[] { stringLength, rows });
								else
									MainApp.log.Error("Machine parameter list cannot be written to the Plc! Write Strings! " + "List: " + list.Name + ", Row: " + (i + 1).ToString());
							}
							else if (symbol.Type.Contains("TIME"))
							{
								UInt32[] fVal = new UInt32[rows];
								for (i = 0; i < rows; i++)
									fVal[i] = (list.Data[i].Value.Length == 0) ? (UInt32)0 : UInt32.Parse(list.Data[i].Value);
								adsPlcServer.PlcClient.WriteAny(list.PLCVar, fVal);
							}
							break;
						}
					default:
						MainApp.log.Error("Machine parameter list cannot be written to the Plc! Datatype not supported! List: " + list.Name + ", PlcVar: " + list.PLCVar);
						break;
				}
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Machine parameter list cannot be written to the Plc! " + "List: " + list.Name + ", Row: " + (i + 1).ToString(), ex);
			}
		}

		private void LoadLanguageStrings()
		{
			labelCaption.Text = tclm.GetString("FormMaschPara.labelCaption", "Machining Data");

			foreach (MachineParamList list in tcMachineParam1.MachineParameter.Lists)
			{
				list.Description = tclm.GetString("MP." + list.Name + ".Description", list.Description, false);

				int line = 1;
				foreach (MachineParamData data in list.Data)
				{
					data.Description = tclm.GetString("MP." + list.Name + ".Row[" + line.ToString("00") + "]", data.Description, false);
					line++;
				}
			}
		}

		private void WriteCurrentLanguageStringsToDB()
		{
			string tmp;
			foreach (MachineParamList list in tcMachineParam1.MachineParameter.Lists)
			{
				tmp = "MP." + list.Name + ".Description";
				if (string.IsNullOrEmpty(tclm[tmp]))
					// writes the default string to all languages
					tclm.GetString(tmp, list.Description);
				else
					// changes the string of the current language
					tclm[tmp] = list.Description;

				int line = 1;
				foreach (MachineParamData data in list.Data)
				{
					tmp = "MP." + list.Name + ".Row[" + line.ToString("00") + "]";
					if (string.IsNullOrEmpty(tclm[tmp]))
						tclm.GetString(tmp, data.Description);
					else
						tclm[tmp] = data.Description;

					line++;
				}
			}
		}

		#endregion

	}
}
