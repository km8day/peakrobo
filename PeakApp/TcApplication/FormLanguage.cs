using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Beckhoff.App.TCLManager;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	public partial class FormLanguage : FormTcApp
	{
		string aktuelleSprachversion;   // Aktuelle Sprache in der der aktuellen übersetzten Version

		public FormLanguage(Form form)
		{
			parentForm = form;
			InitializeComponent();
			tclm = MainApp.GetDoc().GetTCLanguageManager();
		}

		#region Implementation of Function Keys

		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
		}

		public override void FKeyUpEvent(int nIdx)
		{
			switch (nIdx)
			{
				case 1:
					break;
				case 2:
					break;
			}
		}

		private void SetLanguageKeys(Beckhoff.App.TcFKey fKey)
		{
			fKey.InstallFKeyDelegate(null, new FKeyDelegate(FKey1UpEvent));
			string[] availableLanguages = tclm.AvailableLanguages;
			string[] availableFlags = tclm.AvailableFlags;

			for (int i = 0; i < availableLanguages.Length; i++)
			{
				fKey.FKeyText(i + 1, availableLanguages[i], Image.FromFile(Application.StartupPath + availableFlags[i]));
			}
			aktuelleSprachversion = tclm.Translate(tclm.Sprache, "DEUTSCH", tclm.Sprache);
		}

		private void FKey1UpEvent(int nIdx)
		{
			if (String.Compare(tcFKeyLanguage.FKeyText(nIdx), aktuelleSprachversion, true) != 0)
			{
				tclm.Sprache = tclm.Translate(tcFKeyLanguage.FKeyText(nIdx), tclm.Sprache, "DEUTSCH");
				tclm.SaveAllChanges();

				// set the right language for the text of the function keys
				if (LocalMenu != null)
					LocalMenu.SetFKeyText();
			}
			else
			{
				this.DialogResult = DialogResult.Cancel;
			}
		}

		private void FormLanguage_Activated(object sender, System.EventArgs e)
		{
		}

		#endregion

		#region Events

		private void FormLanguage_Load(object sender, System.EventArgs e)
		{
			tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
			LoadLanguageStrings();
		}

		private void btnTextData_Click(object sender, System.EventArgs e)
		{
			tclm.ShowStringEditDialog(this);
		}

		private void btnLanguageSelect_Click(object sender, System.EventArgs e)
		{
			bool res = tclm.ShowLanguageSelectionDialog(this);
			if (res == true && LocalMenu != null)
				LocalMenu.SetFKeyText();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized;
		}

		#endregion

		#region LoadLanguageStrings

		private void LoadLanguageStrings()
		{
			try
			{
				lblLanguages.Text = tclm["_Language.Header"];
				btnLanguageSelect.Text = tclm["_Language.Title"];
				btnTextData.Text = tclm["_String.Title"];
				SetLanguageKeys(tcFKeyLanguage);
			}
			catch (Exception ex)
			{
				MainApp.log.Error("Error in LoadLanguageStrings().", ex);
			}
		}

		#endregion

	}
}
