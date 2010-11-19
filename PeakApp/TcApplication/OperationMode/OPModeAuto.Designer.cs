namespace TcApplication
{
	partial class OPModeAuto
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.selectFile1 = new Beckhoff.App.SelectFile();
			this.tcNcProgramSection1 = new Beckhoff.Forms.Nc.TcNcProgramSection();
			this.timerActiveProgram = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelBoxActiveProgram = new System.Windows.Forms.Label();
			this.labelActiveProgram = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// selectFile1
			// 
			this.selectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.selectFile1.Arguments = "";
			this.selectFile1.ButtonDescription = "Program";
			this.selectFile1.FileName = "Notepad.exe";
			this.selectFile1.InitialDirectory = "C:\\TwinCAT\\CNC";
			this.selectFile1.InitialFilter = "NC files (*.nc)|*.nc|All files (*.*)|*.*";
			this.selectFile1.Location = new System.Drawing.Point(0, 32);
			this.selectFile1.Name = "selectFile1";
			this.selectFile1.Size = new System.Drawing.Size(392, 32);
			this.selectFile1.TabIndex = 35;
			this.selectFile1.FileSelected += new Beckhoff.App.SelectFile.FileSelectedEventHandler(this.selectFile1_SelectedFileChanged);
			// 
			// tcNcProgramSection1
			// 
			this.tcNcProgramSection1.AdsNcServer = null;
			this.tcNcProgramSection1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tcNcProgramSection1.BackColor = System.Drawing.Color.White;
			this.tcNcProgramSection1.CncProgramName = null;
			this.tcNcProgramSection1.Location = new System.Drawing.Point(0, 64);
			this.tcNcProgramSection1.Name = "tcNcProgramSection1";
			this.tcNcProgramSection1.Size = new System.Drawing.Size(392, 184);
			this.tcNcProgramSection1.TabIndex = 34;
			// 
			// timerActiveProgram
			// 
			this.timerActiveProgram.Interval = 500;
			this.timerActiveProgram.Tick += new System.EventHandler(this.timerActiveProgram_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.groupBox1.Controls.Add(this.labelBoxActiveProgram);
			this.groupBox1.Controls.Add(this.labelActiveProgram);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(0, -7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 39);
			this.groupBox1.TabIndex = 43;
			this.groupBox1.TabStop = false;
			// 
			// labelBoxActiveProgram
			// 
			this.labelBoxActiveProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.labelBoxActiveProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBoxActiveProgram.ForeColor = System.Drawing.Color.White;
			this.labelBoxActiveProgram.Location = new System.Drawing.Point(120, 12);
			this.labelBoxActiveProgram.Name = "labelBoxActiveProgram";
			this.labelBoxActiveProgram.Size = new System.Drawing.Size(264, 22);
			this.labelBoxActiveProgram.TabIndex = 40;
			this.labelBoxActiveProgram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelActiveProgram
			// 
			this.labelActiveProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelActiveProgram.ForeColor = System.Drawing.Color.White;
			this.labelActiveProgram.Location = new System.Drawing.Point(4, 15);
			this.labelActiveProgram.Name = "labelActiveProgram";
			this.labelActiveProgram.Size = new System.Drawing.Size(112, 16);
			this.labelActiveProgram.TabIndex = 39;
			this.labelActiveProgram.Text = "Active program :";
			this.labelActiveProgram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OPModeAuto
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.selectFile1);
			this.Controls.Add(this.tcNcProgramSection1);
			this.Name = "OPModeAuto";
			this.Size = new System.Drawing.Size(392, 248);
			this.Load += new System.EventHandler(this.OPModeAuto_Load);
			this.VisibleChanged += new System.EventHandler(this.OPModeAuto_VisibleChanged);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public Beckhoff.App.SelectFile selectFile1;
		private System.Windows.Forms.Label labelBoxActiveProgram;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelActiveProgram;
		private System.Windows.Forms.Timer timerActiveProgram;
		public Beckhoff.Forms.Nc.TcNcProgramSection tcNcProgramSection1;
	}
}
