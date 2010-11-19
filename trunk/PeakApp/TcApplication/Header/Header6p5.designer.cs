namespace TcApplication
{
	partial class Header6p5
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
			timerDateTime.Enabled = false;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Header6p5));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox8 = new System.Windows.Forms.PictureBox();
			this.pictureBox12 = new System.Windows.Forms.PictureBox();
			this.tcSystemState1 = new Beckhoff.Forms.TcSystemState();
			this.picBoxCompanyName = new System.Windows.Forms.PictureBox();
			this.labelChannelNr = new System.Windows.Forms.Label();
			this.labelMessageInfo = new System.Windows.Forms.Label();
			this.tcEventLoggerLine1 = new Beckhoff.EventLogger.TcEventLogLine();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tcChannelStatus1 = new Beckhoff.Forms.Nc.TcChannelStatus();
			this.timerDateTime = new System.Windows.Forms.Timer(this.components);
			this.pictureBox10 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this.pictureBox11 = new System.Windows.Forms.PictureBox();
			this.labelTime = new System.Windows.Forms.Label();
			this.labelDate = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picBoxCompanyName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pictureBox8);
			this.panel1.Controls.Add(this.pictureBox12);
			this.panel1.Controls.Add(this.tcSystemState1);
			this.panel1.Controls.Add(this.picBoxCompanyName);
			this.panel1.Controls.Add(this.labelChannelNr);
			this.panel1.Controls.Add(this.labelMessageInfo);
			this.panel1.Controls.Add(this.tcEventLoggerLine1);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.tcChannelStatus1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(640, 64);
			this.panel1.TabIndex = 5;
			// 
			// pictureBox8
			// 
			this.pictureBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox8.BackColor = System.Drawing.Color.White;
			this.pictureBox8.Location = new System.Drawing.Point(0, 32);
			this.pictureBox8.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new System.Drawing.Size(475, 1);
			this.pictureBox8.TabIndex = 66;
			this.pictureBox8.TabStop = false;
			// 
			// pictureBox12
			// 
			this.pictureBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox12.BackColor = System.Drawing.Color.White;
			this.pictureBox12.Location = new System.Drawing.Point(475, 0);
			this.pictureBox12.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox12.Name = "pictureBox12";
			this.pictureBox12.Size = new System.Drawing.Size(1, 64);
			this.pictureBox12.TabIndex = 67;
			this.pictureBox12.TabStop = false;
			// 
			// tcSystemState1
			// 
			this.tcSystemState1.AdsPlcServer = null;
			this.tcSystemState1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tcSystemState1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcSystemState1.Location = new System.Drawing.Point(294, 0);
			this.tcSystemState1.Name = "tcSystemState1";
			this.tcSystemState1.Size = new System.Drawing.Size(181, 32);
			this.tcSystemState1.TabIndex = 54;
			// 
			// picBoxCompanyName
			// 
			this.picBoxCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.picBoxCompanyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
			this.picBoxCompanyName.Location = new System.Drawing.Point(476, 0);
			this.picBoxCompanyName.Name = "picBoxCompanyName";
			this.picBoxCompanyName.Size = new System.Drawing.Size(166, 64);
			this.picBoxCompanyName.TabIndex = 24;
			this.picBoxCompanyName.TabStop = false;
			this.picBoxCompanyName.DoubleClick += new System.EventHandler(this.picBoxCompanyName_DoubleClick);
			// 
			// labelChannelNr
			// 
			this.labelChannelNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChannelNr.ForeColor = System.Drawing.Color.White;
			this.labelChannelNr.Location = new System.Drawing.Point(188, 26);
			this.labelChannelNr.Name = "labelChannelNr";
			this.labelChannelNr.Size = new System.Drawing.Size(75, 16);
			this.labelChannelNr.TabIndex = 70;
			this.labelChannelNr.Text = "Kanal";
			this.labelChannelNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelChannelNr.Visible = false;
			// 
			// labelMessageInfo
			// 
			this.labelMessageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.labelMessageInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.labelMessageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelMessageInfo.Location = new System.Drawing.Point(0, 33);
			this.labelMessageInfo.Name = "labelMessageInfo";
			this.labelMessageInfo.Size = new System.Drawing.Size(415, 31);
			this.labelMessageInfo.TabIndex = 69;
			this.labelMessageInfo.Text = "labelMessageInfo";
			this.labelMessageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelMessageInfo.Visible = false;
			// 
			// tcEventLoggerLine1
			// 
			this.tcEventLoggerLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tcEventLoggerLine1.BackColor = System.Drawing.Color.White;
			this.tcEventLoggerLine1.DataAdapter = null;
			this.tcEventLoggerLine1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tcEventLoggerLine1.Location = new System.Drawing.Point(0, 32);
			this.tcEventLoggerLine1.Name = "tcEventLoggerLine1";
			this.tcEventLoggerLine1.Size = new System.Drawing.Size(415, 30);
			this.tcEventLoggerLine1.TabIndex = 71;
			this.tcEventLoggerLine1.LogLineDoubleClick += new System.EventHandler(this.tcEventLoggerLine1_DoubleClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(262, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.TabIndex = 68;
			this.pictureBox1.TabStop = false;
			// 
			// tcChannelStatus1
			// 
			this.tcChannelStatus1.AdsNcServer = null;
			this.tcChannelStatus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcChannelStatus1.Location = new System.Drawing.Point(0, 0);
			this.tcChannelStatus1.Name = "tcChannelStatus1";
			this.tcChannelStatus1.Size = new System.Drawing.Size(262, 32);
			this.tcChannelStatus1.TabIndex = 53;
			// 
			// timerDateTime
			// 
			this.timerDateTime.Enabled = true;
			this.timerDateTime.Interval = 990;
			this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
			// 
			// pictureBox10
			// 
			this.pictureBox10.BackColor = System.Drawing.Color.White;
			this.pictureBox10.Location = new System.Drawing.Point(262, 0);
			this.pictureBox10.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox10.Name = "pictureBox10";
			this.pictureBox10.Size = new System.Drawing.Size(1, 32);
			this.pictureBox10.TabIndex = 11;
			this.pictureBox10.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.White;
			this.pictureBox2.Location = new System.Drawing.Point(294, 0);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(1, 32);
			this.pictureBox2.TabIndex = 12;
			this.pictureBox2.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.panel2.Controls.Add(this.pictureBox9);
			this.panel2.Controls.Add(this.pictureBox11);
			this.panel2.Controls.Add(this.labelTime);
			this.panel2.Controls.Add(this.labelDate);
			this.panel2.Location = new System.Drawing.Point(411, 33);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(64, 31);
			this.panel2.TabIndex = 74;
			// 
			// pictureBox9
			// 
			this.pictureBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox9.BackColor = System.Drawing.Color.White;
			this.pictureBox9.Location = new System.Drawing.Point(0, 15);
			this.pictureBox9.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(65, 1);
			this.pictureBox9.TabIndex = 82;
			this.pictureBox9.TabStop = false;
			// 
			// pictureBox11
			// 
			this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox11.BackColor = System.Drawing.Color.White;
			this.pictureBox11.Location = new System.Drawing.Point(0, 0);
			this.pictureBox11.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox11.Name = "pictureBox11";
			this.pictureBox11.Size = new System.Drawing.Size(1, 32);
			this.pictureBox11.TabIndex = 81;
			this.pictureBox11.TabStop = false;
			// 
			// labelTime
			// 
			this.labelTime.ForeColor = System.Drawing.Color.White;
			this.labelTime.Location = new System.Drawing.Point(2, 19);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(62, 10);
			this.labelTime.TabIndex = 73;
			this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDate
			// 
			this.labelDate.ForeColor = System.Drawing.Color.White;
			this.labelDate.Location = new System.Drawing.Point(2, 4);
			this.labelDate.Name = "labelDate";
			this.labelDate.Size = new System.Drawing.Size(62, 10);
			this.labelDate.TabIndex = 72;
			this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Header6p5
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox10);
			this.Controls.Add(this.panel1);
			this.Name = "Header6p5";
			this.Size = new System.Drawing.Size(640, 65);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picBoxCompanyName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.PictureBox picBoxCompanyName;
		private System.Windows.Forms.Timer timerDateTime;
		private Beckhoff.Forms.Nc.TcChannelStatus tcChannelStatus1;
		private Beckhoff.Forms.TcSystemState tcSystemState1;
		private System.Windows.Forms.PictureBox pictureBox8;
		private System.Windows.Forms.PictureBox pictureBox12;
		private System.Windows.Forms.PictureBox pictureBox10;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.Label labelDate;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label labelChannelNr;
		public System.Windows.Forms.Label labelMessageInfo;
		public Beckhoff.EventLogger.TcEventLogLine tcEventLoggerLine1;
		private System.Windows.Forms.PictureBox pictureBox11;
		private System.Windows.Forms.PictureBox pictureBox9;
	}
}
