namespace TcApplication
{
	partial class BlockSearch
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
			this.dbBlockSearch = new System.Windows.Forms.GroupBox();
			this.btSetBreakPoint = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tbDistance = new System.Windows.Forms.TextBox();
			this.tbBlockCount = new System.Windows.Forms.TextBox();
			this.tbBlockNr = new System.Windows.Forms.TextBox();
			this.tbBreakPoint = new System.Windows.Forms.TextBox();
			this.lbDistance = new System.Windows.Forms.Label();
			this.rbBlockCount = new System.Windows.Forms.RadioButton();
			this.rbStartBlockNr = new System.Windows.Forms.RadioButton();
			this.rbStartBreakPoint = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btStop = new System.Windows.Forms.Button();
			this.btStart = new System.Windows.Forms.Button();
			this.lbHeader = new System.Windows.Forms.Label();
			this.lbActive = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lbBlockCount = new System.Windows.Forms.Label();
			this.lbActDistance = new System.Windows.Forms.Label();
			this.tbActDistance = new System.Windows.Forms.TextBox();
			this.tbActBlockCount = new System.Windows.Forms.TextBox();
			this.dbBlockSearch.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dbBlockSearch
			// 
			this.dbBlockSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.dbBlockSearch.Controls.Add(this.btSetBreakPoint);
			this.dbBlockSearch.Controls.Add(this.label1);
			this.dbBlockSearch.Controls.Add(this.tbDistance);
			this.dbBlockSearch.Controls.Add(this.tbBlockCount);
			this.dbBlockSearch.Controls.Add(this.tbBlockNr);
			this.dbBlockSearch.Controls.Add(this.tbBreakPoint);
			this.dbBlockSearch.Controls.Add(this.lbDistance);
			this.dbBlockSearch.Controls.Add(this.rbBlockCount);
			this.dbBlockSearch.Controls.Add(this.rbStartBlockNr);
			this.dbBlockSearch.Controls.Add(this.rbStartBreakPoint);
			this.dbBlockSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.dbBlockSearch.Location = new System.Drawing.Point(0, 53);
			this.dbBlockSearch.Name = "dbBlockSearch";
			this.dbBlockSearch.Size = new System.Drawing.Size(266, 144);
			this.dbBlockSearch.TabIndex = 0;
			this.dbBlockSearch.TabStop = false;
			// 
			// btSetBreakPoint
			// 
			this.btSetBreakPoint.Enabled = false;
			this.btSetBreakPoint.Location = new System.Drawing.Point(236, 15);
			this.btSetBreakPoint.Name = "btSetBreakPoint";
			this.btSetBreakPoint.Size = new System.Drawing.Size(28, 24);
			this.btSetBreakPoint.TabIndex = 9;
			this.btSetBreakPoint.Text = "#";
			this.btSetBreakPoint.Click += new System.EventHandler(this.btSetBreakPoint_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(237, 116);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(15, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "%";
			// 
			// tbDistance
			// 
			this.tbDistance.Cursor = System.Windows.Forms.Cursors.Default;
			this.tbDistance.Enabled = false;
			this.tbDistance.Location = new System.Drawing.Point(185, 112);
			this.tbDistance.Name = "tbDistance";
			this.tbDistance.Size = new System.Drawing.Size(48, 20);
			this.tbDistance.TabIndex = 7;
			this.tbDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbBlockCount
			// 
			this.tbBlockCount.Cursor = System.Windows.Forms.Cursors.Default;
			this.tbBlockCount.Enabled = false;
			this.tbBlockCount.Location = new System.Drawing.Point(184, 80);
			this.tbBlockCount.Name = "tbBlockCount";
			this.tbBlockCount.Size = new System.Drawing.Size(48, 20);
			this.tbBlockCount.TabIndex = 6;
			this.tbBlockCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbBlockNr
			// 
			this.tbBlockNr.Cursor = System.Windows.Forms.Cursors.Default;
			this.tbBlockNr.Enabled = false;
			this.tbBlockNr.Location = new System.Drawing.Point(184, 48);
			this.tbBlockNr.Name = "tbBlockNr";
			this.tbBlockNr.Size = new System.Drawing.Size(48, 20);
			this.tbBlockNr.TabIndex = 5;
			this.tbBlockNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbBreakPoint
			// 
			this.tbBreakPoint.Cursor = System.Windows.Forms.Cursors.Default;
			this.tbBreakPoint.Enabled = false;
			this.tbBreakPoint.Location = new System.Drawing.Point(184, 16);
			this.tbBreakPoint.Name = "tbBreakPoint";
			this.tbBreakPoint.Size = new System.Drawing.Size(48, 20);
			this.tbBreakPoint.TabIndex = 4;
			this.tbBreakPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbDistance
			// 
			this.lbDistance.AutoSize = true;
			this.lbDistance.Location = new System.Drawing.Point(28, 115);
			this.lbDistance.Name = "lbDistance";
			this.lbDistance.Size = new System.Drawing.Size(108, 13);
			this.lbDistance.TabIndex = 3;
			this.lbDistance.Text = "Zurückgelegter Weg:";
			// 
			// rbBlockCount
			// 
			this.rbBlockCount.AutoSize = true;
			this.rbBlockCount.Cursor = System.Windows.Forms.Cursors.Default;
			this.rbBlockCount.Location = new System.Drawing.Point(8, 80);
			this.rbBlockCount.Name = "rbBlockCount";
			this.rbBlockCount.Size = new System.Drawing.Size(156, 17);
			this.rbBlockCount.TabIndex = 2;
			this.rbBlockCount.TabStop = true;
			this.rbBlockCount.Text = "Fortsetzung über Satzzähler";
			this.rbBlockCount.CheckedChanged += new System.EventHandler(this.rbBlockCount_CheckedChanged);
			// 
			// rbStartBlockNr
			// 
			this.rbStartBlockNr.AutoSize = true;
			this.rbStartBlockNr.Cursor = System.Windows.Forms.Cursors.Default;
			this.rbStartBlockNr.Location = new System.Drawing.Point(8, 48);
			this.rbStartBlockNr.Name = "rbStartBlockNr";
			this.rbStartBlockNr.Size = new System.Drawing.Size(165, 17);
			this.rbStartBlockNr.TabIndex = 1;
			this.rbStartBlockNr.TabStop = true;
			this.rbStartBlockNr.Text = "Fortsetzung über Satznummer";
			this.rbStartBlockNr.CheckedChanged += new System.EventHandler(this.rbStartBlockNr_CheckedChanged);
			// 
			// rbStartBreakPoint
			// 
			this.rbStartBreakPoint.AutoSize = true;
			this.rbStartBreakPoint.Cursor = System.Windows.Forms.Cursors.Default;
			this.rbStartBreakPoint.Location = new System.Drawing.Point(8, 16);
			this.rbStartBreakPoint.Name = "rbStartBreakPoint";
			this.rbStartBreakPoint.Size = new System.Drawing.Size(165, 17);
			this.rbStartBreakPoint.TabIndex = 0;
			this.rbStartBreakPoint.TabStop = true;
			this.rbStartBreakPoint.Text = "Start an Unterbrechungsstelle";
			this.rbStartBreakPoint.CheckedChanged += new System.EventHandler(this.rbStartBreakPoint_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btStop);
			this.groupBox1.Controls.Add(this.btStart);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(0, 194);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(266, 40);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// btStop
			// 
			this.btStop.Cursor = System.Windows.Forms.Cursors.Default;
			this.btStop.Location = new System.Drawing.Point(163, 10);
			this.btStop.Name = "btStop";
			this.btStop.Size = new System.Drawing.Size(72, 24);
			this.btStop.TabIndex = 5;
			this.btStop.Text = "Stopp";
			this.btStop.Click += new System.EventHandler(this.btStopp_Click);
			// 
			// btStart
			// 
			this.btStart.Cursor = System.Windows.Forms.Cursors.Default;
			this.btStart.Location = new System.Drawing.Point(8, 10);
			this.btStart.Name = "btStart";
			this.btStart.Size = new System.Drawing.Size(72, 24);
			this.btStart.TabIndex = 4;
			this.btStart.Text = "Aktiv";
			this.btStart.Click += new System.EventHandler(this.btStart_Click);
			// 
			// lbHeader
			// 
			this.lbHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.lbHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.lbHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbHeader.ForeColor = System.Drawing.Color.White;
			this.lbHeader.Location = new System.Drawing.Point(0, 0);
			this.lbHeader.Name = "lbHeader";
			this.lbHeader.Size = new System.Drawing.Size(266, 16);
			this.lbHeader.TabIndex = 34;
			this.lbHeader.Text = "Satz Suchlauf";
			// 
			// lbActive
			// 
			this.lbActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbActive.BackColor = System.Drawing.Color.Green;
			this.lbActive.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbActive.ForeColor = System.Drawing.Color.White;
			this.lbActive.Location = new System.Drawing.Point(182, 0);
			this.lbActive.Name = "lbActive";
			this.lbActive.Size = new System.Drawing.Size(84, 16);
			this.lbActive.TabIndex = 37;
			this.lbActive.Text = "Aktiv";
			this.lbActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbActive.Visible = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.lbBlockCount);
			this.groupBox2.Controls.Add(this.lbActDistance);
			this.groupBox2.Controls.Add(this.tbActDistance);
			this.groupBox2.Controls.Add(this.tbActBlockCount);
			this.groupBox2.Location = new System.Drawing.Point(0, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(266, 40);
			this.groupBox2.TabIndex = 38;
			this.groupBox2.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(239, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(15, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "%";
			// 
			// lbBlockCount
			// 
			this.lbBlockCount.Location = new System.Drawing.Point(2, 16);
			this.lbBlockCount.Name = "lbBlockCount";
			this.lbBlockCount.Size = new System.Drawing.Size(69, 13);
			this.lbBlockCount.TabIndex = 11;
			this.lbBlockCount.Text = "Satzzähler:";
			this.lbBlockCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbActDistance
			// 
			this.lbActDistance.Location = new System.Drawing.Point(124, 16);
			this.lbActDistance.Name = "lbActDistance";
			this.lbActDistance.Size = new System.Drawing.Size(58, 13);
			this.lbActDistance.TabIndex = 10;
			this.lbActDistance.Text = "Weg:";
			this.lbActDistance.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tbActDistance
			// 
			this.tbActDistance.BackColor = System.Drawing.SystemColors.Control;
			this.tbActDistance.Cursor = System.Windows.Forms.Cursors.Default;
			this.tbActDistance.Location = new System.Drawing.Point(184, 14);
			this.tbActDistance.Name = "tbActDistance";
			this.tbActDistance.ReadOnly = true;
			this.tbActDistance.Size = new System.Drawing.Size(48, 20);
			this.tbActDistance.TabIndex = 8;
			this.tbActDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbActBlockCount
			// 
			this.tbActBlockCount.BackColor = System.Drawing.SystemColors.Control;
			this.tbActBlockCount.Cursor = System.Windows.Forms.Cursors.Default;
			this.tbActBlockCount.Location = new System.Drawing.Point(73, 14);
			this.tbActBlockCount.Name = "tbActBlockCount";
			this.tbActBlockCount.ReadOnly = true;
			this.tbActBlockCount.Size = new System.Drawing.Size(48, 20);
			this.tbActBlockCount.TabIndex = 5;
			this.tbActBlockCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// BlockSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.lbActive);
			this.Controls.Add(this.lbHeader);
			this.Controls.Add(this.dbBlockSearch);
			this.Controls.Add(this.groupBox1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Name = "BlockSearch";
			this.Size = new System.Drawing.Size(267, 240);
			this.Load += new System.EventHandler(this.BlockSearch_Load);
			this.dbBlockSearch.ResumeLayout(false);
			this.dbBlockSearch.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox dbBlockSearch;
		private System.Windows.Forms.RadioButton rbStartBreakPoint;
		private System.Windows.Forms.RadioButton rbStartBlockNr;
		private System.Windows.Forms.TextBox tbBreakPoint;
		private System.Windows.Forms.Label lbDistance;
		private System.Windows.Forms.RadioButton rbBlockCount;
		private System.Windows.Forms.TextBox tbDistance;
		private System.Windows.Forms.TextBox tbBlockCount;
		private System.Windows.Forms.TextBox tbBlockNr;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btStop;
		private System.Windows.Forms.Button btStart;
		private System.Windows.Forms.Label lbHeader;
		private System.Windows.Forms.Label lbActive;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lbActDistance;
		private System.Windows.Forms.TextBox tbActDistance;
		private System.Windows.Forms.TextBox tbActBlockCount;
		private System.Windows.Forms.Button btSetBreakPoint;
		private System.Windows.Forms.Label lbBlockCount;
		private System.Windows.Forms.Label label4;
	}
}
