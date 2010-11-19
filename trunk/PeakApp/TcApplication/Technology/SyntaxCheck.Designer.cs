namespace TcApplication
{
	partial class SyntaxCheck
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
			this.rbDryRun = new System.Windows.Forms.RadioButton();
			this.rbSyntaxCheck = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btStop = new System.Windows.Forms.Button();
			this.btStart = new System.Windows.Forms.Button();
			this.lbActive = new System.Windows.Forms.Label();
			this.lbHeader = new System.Windows.Forms.Label();
			this.dbBlockSearch.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dbBlockSearch
			// 
			this.dbBlockSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.dbBlockSearch.Controls.Add(this.rbDryRun);
			this.dbBlockSearch.Controls.Add(this.rbSyntaxCheck);
			this.dbBlockSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.dbBlockSearch.Location = new System.Drawing.Point(0, 0);
			this.dbBlockSearch.Name = "dbBlockSearch";
			this.dbBlockSearch.Size = new System.Drawing.Size(266, 197);
			this.dbBlockSearch.TabIndex = 38;
			this.dbBlockSearch.TabStop = false;
			// 
			// rbDryRun
			// 
			this.rbDryRun.AutoSize = true;
			this.rbDryRun.Cursor = System.Windows.Forms.Cursors.Default;
			this.rbDryRun.Location = new System.Drawing.Point(8, 64);
			this.rbDryRun.Name = "rbDryRun";
			this.rbDryRun.Size = new System.Drawing.Size(168, 17);
			this.rbDryRun.TabIndex = 1;
			this.rbDryRun.Text = "Dry Run ohne Achsbewegung";
			this.rbDryRun.UseVisualStyleBackColor = true;
			this.rbDryRun.CheckedChanged += new System.EventHandler(this.rbDryRun_CheckedChanged);
			// 
			// rbSyntaxCheck
			// 
			this.rbSyntaxCheck.AutoSize = true;
			this.rbSyntaxCheck.Checked = true;
			this.rbSyntaxCheck.Cursor = System.Windows.Forms.Cursors.Default;
			this.rbSyntaxCheck.Location = new System.Drawing.Point(8, 32);
			this.rbSyntaxCheck.Name = "rbSyntaxCheck";
			this.rbSyntaxCheck.Size = new System.Drawing.Size(91, 17);
			this.rbSyntaxCheck.TabIndex = 0;
			this.rbSyntaxCheck.TabStop = true;
			this.rbSyntaxCheck.Text = "Syntax Check";
			this.rbSyntaxCheck.UseVisualStyleBackColor = true;
			this.rbSyntaxCheck.CheckedChanged += new System.EventHandler(this.rbSyntaxCheck_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btStop);
			this.groupBox1.Controls.Add(this.btStart);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(0, 194);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(266, 40);
			this.groupBox1.TabIndex = 39;
			this.groupBox1.TabStop = false;
			// 
			// btStop
			// 
			this.btStop.Cursor = System.Windows.Forms.Cursors.Default;
			this.btStop.Location = new System.Drawing.Point(160, 10);
			this.btStop.Name = "btStop";
			this.btStop.Size = new System.Drawing.Size(72, 24);
			this.btStop.TabIndex = 5;
			this.btStop.Text = "Stopp";
			this.btStop.UseVisualStyleBackColor = true;
			this.btStop.Click += new System.EventHandler(this.btStop_Click);
			// 
			// btStart
			// 
			this.btStart.Cursor = System.Windows.Forms.Cursors.Default;
			this.btStart.Location = new System.Drawing.Point(8, 10);
			this.btStart.Name = "btStart";
			this.btStart.Size = new System.Drawing.Size(72, 24);
			this.btStart.TabIndex = 4;
			this.btStart.Text = "Aktiv";
			this.btStart.UseVisualStyleBackColor = true;
			this.btStart.Click += new System.EventHandler(this.btStart_Click);
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
			this.lbActive.TabIndex = 41;
			this.lbActive.Text = "Aktiv";
			this.lbActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbActive.Visible = false;
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
			this.lbHeader.TabIndex = 40;
			this.lbHeader.Text = "Syntax Check";
			// 
			// SyntaxCheck
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbActive);
			this.Controls.Add(this.lbHeader);
			this.Controls.Add(this.dbBlockSearch);
			this.Controls.Add(this.groupBox1);
			this.Name = "SyntaxCheck";
			this.Size = new System.Drawing.Size(267, 236);
			this.Load += new System.EventHandler(this.SyntaxCheck_Load);
			this.dbBlockSearch.ResumeLayout(false);
			this.dbBlockSearch.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox dbBlockSearch;
		private System.Windows.Forms.RadioButton rbDryRun;
		private System.Windows.Forms.RadioButton rbSyntaxCheck;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btStop;
		private System.Windows.Forms.Button btStart;
		private System.Windows.Forms.Label lbActive;
		private System.Windows.Forms.Label lbHeader;

	}
}
