namespace TcApplication
{
	partial class OPModeManual
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
			this.groupBoxManual = new System.Windows.Forms.GroupBox();
			this.buttonDownload = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxManualModeSpeed = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbManualTipMode = new System.Windows.Forms.RadioButton();
			this.rbManualJogMode = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbManualModeIncrements1 = new System.Windows.Forms.RadioButton();
			this.rbManualModeIncrements10 = new System.Windows.Forms.RadioButton();
			this.rbManualModeIncrements100 = new System.Windows.Forms.RadioButton();
			this.rbManualModeIncrements1000 = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.labelBoxManual = new System.Windows.Forms.Label();
			this.groupBoxManual.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxManual
			// 
			this.groupBoxManual.Controls.Add(this.buttonDownload);
			this.groupBoxManual.Controls.Add(this.label2);
			this.groupBoxManual.Controls.Add(this.label1);
			this.groupBoxManual.Controls.Add(this.textBoxManualModeSpeed);
			this.groupBoxManual.Controls.Add(this.groupBox1);
			this.groupBoxManual.Controls.Add(this.groupBox2);
			this.groupBoxManual.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBoxManual.Location = new System.Drawing.Point(0, 16);
			this.groupBoxManual.Name = "groupBoxManual";
			this.groupBoxManual.Size = new System.Drawing.Size(488, 200);
			this.groupBoxManual.TabIndex = 25;
			this.groupBoxManual.TabStop = false;
			this.groupBoxManual.Text = "Operation Mode - Manual";
			// 
			// buttonDownload
			// 
			this.buttonDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonDownload.Location = new System.Drawing.Point(16, 168);
			this.buttonDownload.Name = "buttonDownload";
			this.buttonDownload.Size = new System.Drawing.Size(200, 24);
			this.buttonDownload.TabIndex = 4;
			this.buttonDownload.Text = "Download";
			this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "mm/min  °/min";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(131)))), ((int)(((byte)(190)))));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(16, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Velo:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxManualModeSpeed
			// 
			this.textBoxManualModeSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxManualModeSpeed.Location = new System.Drawing.Point(72, 136);
			this.textBoxManualModeSpeed.Name = "textBoxManualModeSpeed";
			this.textBoxManualModeSpeed.Size = new System.Drawing.Size(72, 20);
			this.textBoxManualModeSpeed.TabIndex = 1;
			this.textBoxManualModeSpeed.Text = "1000";
			this.textBoxManualModeSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxManualModeSpeed.Leave += new System.EventHandler(this.textBoxManualModeSpeed_Leave);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbManualTipMode);
			this.groupBox1.Controls.Add(this.rbManualJogMode);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(16, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 88);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Type     ";
			// 
			// rbManualTipMode
			// 
			this.rbManualTipMode.Checked = true;
			this.rbManualTipMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbManualTipMode.Location = new System.Drawing.Point(8, 24);
			this.rbManualTipMode.Name = "rbManualTipMode";
			this.rbManualTipMode.Size = new System.Drawing.Size(88, 24);
			this.rbManualTipMode.TabIndex = 1;
			this.rbManualTipMode.TabStop = true;
			this.rbManualTipMode.Text = "Tip-Mode";
			this.rbManualTipMode.Click += new System.EventHandler(this.rbManualTipMode_CheckedChanged);
			// 
			// rbManualJogMode
			// 
			this.rbManualJogMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbManualJogMode.Location = new System.Drawing.Point(8, 56);
			this.rbManualJogMode.Name = "rbManualJogMode";
			this.rbManualJogMode.Size = new System.Drawing.Size(88, 24);
			this.rbManualJogMode.TabIndex = 1;
			this.rbManualJogMode.Text = "Jog-Mode";
			this.rbManualJogMode.Click += new System.EventHandler(this.rbManualJogMode_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rbManualModeIncrements1);
			this.groupBox2.Controls.Add(this.rbManualModeIncrements10);
			this.groupBox2.Controls.Add(this.rbManualModeIncrements100);
			this.groupBox2.Controls.Add(this.rbManualModeIncrements1000);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(240, 24);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(240, 168);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Distance in µm       ";
			// 
			// rbManualModeIncrements1
			// 
			this.rbManualModeIncrements1.Checked = true;
			this.rbManualModeIncrements1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbManualModeIncrements1.Location = new System.Drawing.Point(8, 16);
			this.rbManualModeIncrements1.Name = "rbManualModeIncrements1";
			this.rbManualModeIncrements1.Size = new System.Drawing.Size(224, 24);
			this.rbManualModeIncrements1.TabIndex = 0;
			this.rbManualModeIncrements1.TabStop = true;
			this.rbManualModeIncrements1.Text = "1 µm";
			this.rbManualModeIncrements1.Click += new System.EventHandler(this.rbManualModeIncrements1_CheckedChanged);
			// 
			// rbManualModeIncrements10
			// 
			this.rbManualModeIncrements10.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbManualModeIncrements10.Location = new System.Drawing.Point(8, 56);
			this.rbManualModeIncrements10.Name = "rbManualModeIncrements10";
			this.rbManualModeIncrements10.Size = new System.Drawing.Size(224, 24);
			this.rbManualModeIncrements10.TabIndex = 0;
			this.rbManualModeIncrements10.Text = "10 µm";
			this.rbManualModeIncrements10.Click += new System.EventHandler(this.rbManualModeIncrements10_CheckedChanged);
			// 
			// rbManualModeIncrements100
			// 
			this.rbManualModeIncrements100.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbManualModeIncrements100.Location = new System.Drawing.Point(8, 96);
			this.rbManualModeIncrements100.Name = "rbManualModeIncrements100";
			this.rbManualModeIncrements100.Size = new System.Drawing.Size(224, 24);
			this.rbManualModeIncrements100.TabIndex = 0;
			this.rbManualModeIncrements100.Text = "100 µm";
			this.rbManualModeIncrements100.Click += new System.EventHandler(this.rbManualModeIncrements100_CheckedChanged);
			// 
			// rbManualModeIncrements1000
			// 
			this.rbManualModeIncrements1000.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbManualModeIncrements1000.Location = new System.Drawing.Point(8, 136);
			this.rbManualModeIncrements1000.Name = "rbManualModeIncrements1000";
			this.rbManualModeIncrements1000.Size = new System.Drawing.Size(224, 24);
			this.rbManualModeIncrements1000.TabIndex = 0;
			this.rbManualModeIncrements1000.Text = "1000 µm";
			this.rbManualModeIncrements1000.Click += new System.EventHandler(this.rbManualModeIncrements1000_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.groupBox3.Controls.Add(this.labelBoxManual);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(0, -7);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(496, 39);
			this.groupBox3.TabIndex = 44;
			this.groupBox3.TabStop = false;
			// 
			// labelBoxManual
			// 
			this.labelBoxManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBoxManual.ForeColor = System.Drawing.Color.White;
			this.labelBoxManual.Location = new System.Drawing.Point(8, 16);
			this.labelBoxManual.Name = "labelBoxManual";
			this.labelBoxManual.Size = new System.Drawing.Size(256, 16);
			this.labelBoxManual.TabIndex = 39;
			this.labelBoxManual.Text = "Operation Mode - Manual";
			this.labelBoxManual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OPModeManual
			// 
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBoxManual);
			this.Name = "OPModeManual";
			this.Size = new System.Drawing.Size(496, 232);
			this.groupBoxManual.ResumeLayout(false);
			this.groupBoxManual.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.GroupBox groupBoxManual;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.RadioButton rbManualTipMode;
		public System.Windows.Forms.RadioButton rbManualJogMode;
		public System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button buttonDownload;
		private System.Windows.Forms.TextBox textBoxManualModeSpeed;
		private System.Windows.Forms.RadioButton rbManualModeIncrements1;
		private System.Windows.Forms.RadioButton rbManualModeIncrements10;
		private System.Windows.Forms.RadioButton rbManualModeIncrements100;
		private System.Windows.Forms.RadioButton rbManualModeIncrements1000;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label labelBoxManual;

	}
}
