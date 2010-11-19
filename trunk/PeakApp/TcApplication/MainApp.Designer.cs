namespace TcApplication
{
	partial class MainApp
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);

			// Dispose the used objects of the form cnc and the adsServer object
			// regular disposing is to late
			System.Windows.Forms.Form tmpForm = menu.GetForm("FormCnc");
			if (tmpForm != null)
			{
				tmpForm.Dispose();
			}
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
			this.panelHeader = new System.Windows.Forms.Panel();
			this.tcUserAdmin1 = new Beckhoff.App.Security.TcUserAdmin(this.components);
			this.tcFKey1 = new Beckhoff.App.TcFKey();
			this.statusBarMain = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// panelHeader
			// 
			this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelHeader.Location = new System.Drawing.Point(0, 0);
			this.panelHeader.Name = "panelHeader";
			this.panelHeader.Size = new System.Drawing.Size(1024, 96);
			this.panelHeader.TabIndex = 4;
			// 
			// tcUserAdmin1
			// 
			this.tcUserAdmin1.FileName = "TcAppUser.usr";
			this.tcUserAdmin1.LanguageManager = null;
			// 
			// tcFKey1
			// 
			this.tcFKey1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tcFKey1.FKeyBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
			this.tcFKey1.FKeyBtnForeColor = System.Drawing.Color.White;
			this.tcFKey1.FKeyBtnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(79)))), ((int)(((byte)(119)))));
			this.tcFKey1.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.tcFKey1.FKeyLabelAlign = System.Drawing.ContentAlignment.TopLeft;
			this.tcFKey1.FKeyLabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.tcFKey1.FKeyLabelForeColor = System.Drawing.Color.White;
			this.tcFKey1.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.tcFKey1.Location = new System.Drawing.Point(0, 614);
			this.tcFKey1.Name = "tcFKey1";
			this.tcFKey1.Size = new System.Drawing.Size(1024, 72);
			this.tcFKey1.TabIndex = 32;
			// 
			// statusBarMain
			// 
			this.statusBarMain.Location = new System.Drawing.Point(0, 598);
			this.statusBarMain.Name = "statusBarMain";
			this.statusBarMain.ShowPanels = true;
			this.statusBarMain.Size = new System.Drawing.Size(1024, 16);
			this.statusBarMain.SizingGrip = false;
			this.statusBarMain.TabIndex = 33;
			// 
			// MainApp
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1024, 686);
			this.Controls.Add(this.statusBarMain);
			this.Controls.Add(this.tcFKey1);
			this.Controls.Add(this.panelHeader);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.Name = "MainApp";
			this.Text = "TwinCAT Main application frame";
			this.Load += new System.EventHandler(this.MainApp_Load);
			this.Resize += new System.EventHandler(this.MainApp_Resize);
			this.ResumeLayout(false);

		}

		private System.Windows.Forms.Panel panelHeader;
		private static MainApp mainApp;
	
		#endregion
		public Beckhoff.App.TcFKey tcFKey1;
		internal System.Windows.Forms.StatusBar statusBarMain;


	}
}