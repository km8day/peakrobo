using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Beckhoff.App.TCLManager;
using Beckhoff.App;
using Beckhoff.Forms;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	public partial class FormRecipe : FormTcApp
	{
		private const string folder = "Auftrag";
		private const string ending = ".dat";
		private string recipeFilename = "";
		private string rootdir;
		private TcAdsPlcServer adsServer;
		private Color oldButtonColor;

		// true if changes are not saved;
		private bool hasChanged = false;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FormRecipe"/> class.
		/// </summary>
		/// <param name="form">The form.</param>
		public FormRecipe(Form form)
		{
			parentForm = form;
			InitializeComponent();

			adsServer = MainApp.GetDoc().AdsPlcServer;
			adsServer.TcPlcStateChanged += new TcAdsStateChangedEventHandler(adsServer_TcPlcStateChanged);

			tclm = MainApp.GetDoc().GetTCLanguageManager();
			tcRecipe1.LanguageManager = tclm;
			tcRecipe1.afterRead += new TcRecipeGrid.TcAfterReadDelegate(tcRecipe1_afterRead);
			tcRecipe1.afterChange += new TcRecipeGrid.TcAfterChangeDelegate(tcRecipe1_afterChange);
			tcRecipe1.ConfigFileName = Application.StartupPath + "\\" + folder + "\\RecipeConfig.xml";

			treeView1.Nodes.Clear();
			treeView1.Nodes.Add(folder);        // folder = root folder

			if (!System.IO.Directory.Exists(Application.StartupPath + "\\" + folder))
				System.IO.Directory.CreateDirectory(Application.StartupPath + "\\" + folder);

			string[] directories = System.IO.Directory.GetDirectories(Application.StartupPath + "\\" + folder);
			foreach (string dirs in directories)
			{
				string[] sa = dirs.Split('\\');
				string name = sa[sa.Length - 1];          // the last element is the pure filename
				treeView1.Nodes[0].Nodes.Add(name, name);
			}
			treeView1.Nodes[0].ExpandAll();
			rootdir = Application.StartupPath + "\\" + folder;

			treeView1.SelectedNode = treeView1.Nodes[0];
		}

		void tcRecipe1_afterChange()
		{
			MainApp.GetDoc().tcFKey1.FKeyBackColor(10, Color.DarkGray);
			hasChanged = true;
		}

		private void tcRecipe1_afterRead()
		{
			//button1.Top = tcRecipe1.Top + tcRecipe1.Height;
			//button1.Left = tcRecipe1.Left;
			MainApp.GetDoc().tcFKey1.FKeyBackColor(10, oldButtonColor);
		}

		private void FormRecipe_Load(object sender, EventArgs e)
		{
			tcRecipe1.Focus();
		}

		private void FormRecipe_Activated(object sender, EventArgs e)
		{
			labelOrder.Text = tclm.GetString("FormRecipe.LabelOrder", "Auftrag", true);
			labelRecipe.Text = tclm.GetString("FormRecipe.LabelRecipe", "Rezept", true);
			tcRecipe1.LoadLanguageStrings();

			//SetFunctionKeys(MainApp.GetDoc().tcFKey1);
			ReadDirectoryContent();
		}

		private void FormRecipe_Deactivate(object sender, EventArgs e)
		{
			timerListbox.Enabled = false;
			if (hasChanged)
			{
				if (askSaveData())
				{
					tcRecipe1.WriteData();
				}
				hasChanged = false;
				MainApp.GetDoc().tcFKey1.FKeyBackColor(10, oldButtonColor);
			}
		}

		private void ReadDirectoryContent()
		{
			treeView2.Nodes.Clear();

			string[] files = System.IO.Directory.GetFiles(rootdir, "*" + ending);
			foreach (string file in files)
			{
				string[] sa = file.Split('\\');
				string name = sa[sa.Length - 1];
				name = name.Substring(0, (name.Length - ending.Length));  // delete ending form string                
				treeView2.Nodes.Add(name, name);
			}
		}

		private void timerListbox_Tick(object sender, EventArgs e)
		{
			timerListbox.Enabled = false;
			if ((tcRecipe1 != null) && (treeView2.SelectedNode != null))
			{
				if (hasChanged)
				{
					if (askSaveData())
					{
						tcRecipe1.WriteData();
					}
					hasChanged = false;
					MainApp.GetDoc().tcFKey1.FKeyBackColor(10, oldButtonColor);
				}
				recipeFilename = rootdir + "\\" + treeView2.SelectedNode.Text + ending;
				tcRecipe1.ReadData(recipeFilename);
			}

			string[] sa = rootdir.Split('\\');
			textBoxKunde.Text = sa[sa.Length - 1];          // the last element is the pure filename
			if (treeView2.SelectedNode != null)
				textBoxAuftrag.Text = treeView2.SelectedNode.Text;
		}

		private void gListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Restart the timer
			timerListbox.Enabled = false;
			timerListbox.Enabled = true;
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			string selectedDir = e.Node.Text;
			if (e.Node.Equals(treeView1.Nodes[0]))
				rootdir = Application.StartupPath + "\\" + folder;
			else
				rootdir = Application.StartupPath + "\\" + folder + "\\" + e.Node.Text;
			ReadDirectoryContent();
		}

		private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
		{
			timerListbox.Enabled = false;
			timerListbox.Enabled = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			tcRecipe1.ConfigMode = !tcRecipe1.ConfigMode;
			if (tcRecipe1.ConfigMode)
			{
				button1.BackColor = Color.Red;
			}
			else
			{
				button1.BackColor = System.Drawing.SystemColors.Control;
			}

			//button1.Top = tcRecipe1.Top + tcRecipe1.Height;
			//button1.Left = tcRecipe1.Left;
		}

		void adsServer_TcPlcStateChanged(TwinCAT.Ads.AdsState state)
		{
			if (state == TwinCAT.Ads.AdsState.Run)
				tcRecipe1.ReadData();
		}

		private string GetText(string ident, string defaultStr)
		{
			if (tclm != null)
				return tclm.GetString("FormRecipe." + ident, defaultStr, true);
			else
				return defaultStr;
		}

		private bool askSaveData()
		{
			string message = GetText("Save", "Sollen die geänderten Daten gespeichert werden?"); ;
			string caption = GetText("CaptionSave", "Daten speichern");

			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result = MessageBox.Show(this, message, caption, buttons,
				 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

			if (result == DialogResult.Yes)
				return true;
			else
				return false;
		}

		private bool askDeleteRecipe(string fileName)
		{
			string message;
			string caption = GetText("CaptionDelete", "Rezept löschen");

			StringBuilder sb = new StringBuilder(GetText("ReallyDelete", "Soll das Rezept <{0}> gelöscht werden"));
			sb.Replace("{0}", fileName);
			message = sb.ToString();

			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result = MessageBox.Show(this, message, caption, buttons,
				 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

			if (result == DialogResult.Yes)
				return true;
			else
				return false;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized;
		}

		#region Implementation of Function Keys

		/*
		private void SetFunctionKeys(Beckhoff.App.TcFKey fKey)
		{
			fKey.InstallFKeyDelegate(null, new FKeyDelegate(FKeyUpEvent));
			fKey.FKeyImageAlign = System.Drawing.ContentAlignment.TopRight;
			SetFKeyText(fKey);
			oldButtonColor = MainApp.GetDoc().tcFKey1.FKeyBtnBackColor;
		}
		*/

		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
			fKey.FKeyText(4, tclm.GetString("FormRecipe.FKey[4]", "Zeile einfügen", true));
			fKey.FKeyText(5, tclm.GetString("FormRecipe.FKey[5]", "Zeile löschen", true));

			fKey.FKeyText(7, tclm.GetString("FormRecipe.FKey[7]", "Löschen", true));
			fKey.FKeyText(8, tclm.GetString("FormRecipe.FKey[8]", "Neu anlegen", true));
			fKey.FKeyText(9, tclm.GetString("FormRecipe.FKey[9]", "Laden", true), Image.FromFile(Application.StartupPath + "\\Bitmap\\Load.ico"));
			fKey.FKeyText(10, tclm.GetString("FormRecipe.FKey[10]", "Speichern", true), Image.FromFile(Application.StartupPath + "\\Bitmap\\Save.ico"));
			fKey.FKeyText(11, tclm.GetString("FormRecipe.FKey[11]", "Schreiben an \r\nSPS", true));

			if (MainApp.GetDoc().tcUserAdmin1.CurrentUserLevel > Beckhoff.App.Security.TcUserLevel.Administrator)
				button1.Visible = false;
			else
				button1.Visible = true;
			oldButtonColor = MainApp.GetDoc().tcFKey1.FKeyBtnBackColor;
		}

		public override void FKeyUpEvent(int nIdx)
		{
			switch (nIdx)
			{
				case 1:
					break;

				case 4:
					tcRecipe1.InsertRow();
					MainApp.GetDoc().tcFKey1.FKeyBackColor(10, Color.DarkGray);
					hasChanged = true;
					break;

				case 5:
					tcRecipe1.DeleteRow();
					MainApp.GetDoc().tcFKey1.FKeyBackColor(10, Color.DarkGray);
					hasChanged = true;
					break;

				case 7:    // Recipe löschen
					if (textBoxAuftrag.Text != "")
					{
						if (askDeleteRecipe(textBoxAuftrag.Text))
						{
							System.IO.File.Delete(rootdir + "\\" + textBoxAuftrag.Text + ending);
							if (treeView2.SelectedNode != null)
								treeView2.Nodes.Remove(treeView2.SelectedNode);
							// ein anderes Element selektieren
							if (treeView2.Nodes.Count != 0)
								treeView2.SelectedNode = treeView2.Nodes[0];
							else
							{
								textBoxAuftrag.Text = "";
								recipeFilename = "";
							}
						}
					}
					break;

				case 8:
					InputBox box = new InputBox(GetText("New", "Neu anlegen"), GetText("FileName", "Dateiname:"));
					box.ShowDialog();
					if (box.DialogResult == DialogResult.OK && !box.GetInput().Equals(""))
					{
						string fileName = box.GetInput();
						recipeFilename = rootdir + "\\" + fileName + ending;
						tcRecipe1.NewFile(recipeFilename);
						tcRecipe1.WriteData();
						treeView2.Nodes.Add(fileName, fileName);
						textBoxAuftrag.Text = fileName;
					}
					break;

				case 9:
					tcRecipe1.ReadData();
					break;

				case 10:
					tcRecipe1.WriteData();
					MainApp.GetDoc().tcFKey1.FKeyBackColor(10, oldButtonColor);
					hasChanged = false;
					break;

				case 11:
					try
					{
						// Get recipe data and write to the Plc
						System.IO.MemoryStream memStream;
						tcRecipe1.WriteDataToMemory(out memStream);
						TwinCAT.Ads.AdsStream adsStream = new TwinCAT.Ads.AdsStream((int)memStream.Capacity);
						adsStream.Write(memStream.GetBuffer(), 0, (int)memStream.Length);
						adsServer.PlcClient.Write(".RecipeData", adsStream);
						memStream = null;
					}
					catch (Exception ex)
					{
						string tmp = this.Name + " Error writing recipe data to the PLC!";
						MainApp.log.Error(tmp, ex);
						MessageBox.Show(tmp);
					}
					break;

				case 12:
					timerListbox.Enabled = false;
					break;
			}
		}

		#endregion

	}
}
