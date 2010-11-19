using System;
using System.Drawing;
using System.Windows.Forms;
using Beckhoff.App.TCLManager;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	/// <summary>
	/// Summary description for FormOption.
	/// </summary>
	public partial class FormOption : FormTcApp
	{
		public FormOption(Form form)
		{
			parentForm = form;
			InitializeComponent();

			tclm = MainApp.GetDoc().GetTCLanguageManager();
		}

		#region Implementation of Function Keys

		public override void SetFKeyText(Beckhoff.App.TcFKey fKey)
		{
			// only Admins and Supervisors are admitted to...
			/*
			if (MainApp.GetDoc().tcUserAdmin1.CurrentUserLevel > Beckhoff.App.Security.TcUserLevel.Supervisor)
			{
				fKey.FKeyEnabled(2, false);
				fKey.FKeyEnabled(5, false);
				fKey.FKeyEnabled(6, false);
			}
			*/
		}

		public override void FKeyUpEvent(int nIdx)
		{
			switch (nIdx)
			{
				case 1:
					break;
			}
		}

		void FormOption_Activated(object sender, System.EventArgs e)
		{
		}

		#endregion

		#region Events

		private void FormOption_Load(object sender, System.EventArgs e)
		{
			tclm.StringDel += new CTCLManager.InitStringDelegate(LoadLanguageStrings);
			LoadLanguageStrings();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized;
		}

		#endregion

		private void LoadLanguageStrings()
		{
		}
	
	}
}
