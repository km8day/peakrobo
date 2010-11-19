namespace TcApplication
{
	partial class FormMView
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
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.picBoxMaschineView = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.gbCurrentPosition = new System.Windows.Forms.GroupBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnRead = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.lblMouseX1 = new System.Windows.Forms.Label();
			this.lblMouseY = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnConfig = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picBoxMaschineView)).BeginInit();
			this.gbCurrentPosition.SuspendLayout();
			this.SuspendLayout();
			// 
			// picBoxMaschineView
			// 
			this.picBoxMaschineView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picBoxMaschineView.Location = new System.Drawing.Point(0, 0);
			this.picBoxMaschineView.Name = "picBoxMaschineView";
			this.picBoxMaschineView.Size = new System.Drawing.Size(716, 514);
			this.picBoxMaschineView.TabIndex = 0;
			this.picBoxMaschineView.TabStop = false;
			this.picBoxMaschineView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxMaschineView_MouseMove);
			// 
			// timer1
			// 
			this.timer1.Interval = 750;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// gbCurrentPosition
			// 
			this.gbCurrentPosition.BackColor = System.Drawing.SystemColors.Control;
			this.gbCurrentPosition.Controls.Add(this.btnClose);
			this.gbCurrentPosition.Controls.Add(this.btnRead);
			this.gbCurrentPosition.Controls.Add(this.btnOpen);
			this.gbCurrentPosition.Controls.Add(this.lblMouseX1);
			this.gbCurrentPosition.Controls.Add(this.lblMouseY);
			this.gbCurrentPosition.Controls.Add(this.label1);
			this.gbCurrentPosition.Controls.Add(this.label4);
			this.gbCurrentPosition.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.gbCurrentPosition.ForeColor = System.Drawing.Color.Blue;
			this.gbCurrentPosition.Location = new System.Drawing.Point(0, 466);
			this.gbCurrentPosition.Name = "gbCurrentPosition";
			this.gbCurrentPosition.Size = new System.Drawing.Size(716, 48);
			this.gbCurrentPosition.TabIndex = 116;
			this.gbCurrentPosition.TabStop = false;
			this.gbCurrentPosition.Text = "Current Position";
			this.gbCurrentPosition.Visible = false;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(8, 16);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 24);
			this.btnClose.TabIndex = 121;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(168, 16);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(64, 24);
			this.btnRead.TabIndex = 120;
			this.btnRead.Text = "Read";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click1);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(96, 16);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(64, 24);
			this.btnOpen.TabIndex = 119;
			this.btnOpen.Text = "Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click1);
			// 
			// lblMouseX1
			// 
			this.lblMouseX1.Location = new System.Drawing.Point(280, 24);
			this.lblMouseX1.Name = "lblMouseX1";
			this.lblMouseX1.Size = new System.Drawing.Size(88, 16);
			this.lblMouseX1.TabIndex = 112;
			// 
			// lblMouseY
			// 
			this.lblMouseY.Location = new System.Drawing.Point(416, 24);
			this.lblMouseY.Name = "lblMouseY";
			this.lblMouseY.Size = new System.Drawing.Size(88, 16);
			this.lblMouseY.TabIndex = 111;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(392, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 16);
			this.label1.TabIndex = 110;
			this.label1.Text = "Y:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(256, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 16);
			this.label4.TabIndex = 109;
			this.label4.Text = "X:";
			// 
			// btnConfig
			// 
			this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnConfig.Location = new System.Drawing.Point(0, 476);
			this.btnConfig.Name = "btnConfig";
			this.btnConfig.Size = new System.Drawing.Size(64, 24);
			this.btnConfig.TabIndex = 117;
			this.btnConfig.Text = "Config";
			this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click1);
			// 
			// FormMView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(716, 514);
			this.Controls.Add(this.gbCurrentPosition);
			this.Controls.Add(this.btnConfig);
			this.Controls.Add(this.picBoxMaschineView);
			this.Name = "FormMView";
			this.Text = "FormMView";
			this.Deactivate += new System.EventHandler(this.FormMView_Deactivate);
			this.Activated += new System.EventHandler(this.Form_Activated);
			this.Load += new System.EventHandler(this.FormMView_Load);
			((System.ComponentModel.ISupportInitialize)(this.picBoxMaschineView)).EndInit();
			this.gbCurrentPosition.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.PictureBox picBoxMaschineView;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.GroupBox gbCurrentPosition;
		private System.Windows.Forms.Label lblMouseX1;
		private System.Windows.Forms.Label lblMouseY;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btnConfig;
	}
}