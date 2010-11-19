using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	/// <summary>
	/// Summary description for Form8.
	/// </summary>
	public partial class Form8 : FormTcApp
	{
		private Beckhoff.Forms.TcAdsPlcServer adsPlcServer;
		private Beckhoff.Forms.Nc.TcAdsNcServer adsNcServer;

		public Form8()
		{
			InitializeComponent();

			adsPlcServer = MainApp.GetDoc().AdsPlcServer;
			adsNcServer = MainApp.GetDoc().AdsNcServer;

		}

		#region Implementation of Function Keys

		public override void FKeyWriteSymbol(string symbol, string value)
		{
			if (adsPlcServer != null && adsPlcServer.PlcIsRunning)
			{
				try
				{
					adsPlcServer.PlcClient.WriteSymbol(symbol, value);
				}
				catch (Exception ex)
				{
					MainApp.log.Error("Error in FKeyWriteSymbol()", ex);
				}
			}
		}

		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
			fKey.FKeyText(1, "Menü");
			fKey.FKeyText(2, "Test");
			fKey.FKeyText(3, "Swap");
			fKey.FKeyText(4, "Menü2");
		}

		public override void FKeyDownEvent(int nIdx)
		{
		}

		public override void FKeyUpEvent(int nIdx)
		{
			switch (nIdx)
			{
				case 1:
					FormTcMenuManager setup = new FormTcMenuManager(LocalMenu);
					setup.ShowDialog();
					break;

				case 2:
					string[] elements;
					LocalMenu.GetPathElements(out elements);
					string tmp = "";
					for (int i = 0; i < elements.Length; i++)
					{
						tmp = tmp + elements[i] + ">";
					}
					MessageBox.Show(tmp);
					break;

				case 3:
					{
						int a = 3;
						int b = 4;

						Swap(ref a, ref b);
					}
					break;

				case 4:
					LocalMenu.MenuManager();
					break;
			}
		}

		/// <summary>
		/// Swap data of type <typeparamref name="T"/>
		/// </summary>
		/// <param name="lhs">left <typeparamref name="T"/> to swap</param>
		/// <param name="rhs">right <typeparamref name="T"/> to swap</param>
		/// <typeparam name="T">The element type to swap</typeparam>
		public void Swap<T>(ref T lhs, ref T rhs)
		{
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		void Form8_Activated(object sender, System.EventArgs e)
		{
		}

		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			string[] lines;
			bool lineChanged;
			int activeLine = adsNcServer.NcClient.ProgramSection(1, "", out lines, out lineChanged);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			adsNcServer.NcClient.ProgramSectionNumberOfLines(1, 10);
		}

	}
}
