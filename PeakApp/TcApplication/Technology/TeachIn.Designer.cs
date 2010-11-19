namespace TcApplication
{
	partial class TeachIn
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
			this.tbTeachIn = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btDelete = new System.Windows.Forms.Button();
			this.btAdd = new System.Windows.Forms.Button();
			this.btSave = new System.Windows.Forms.Button();
			this.btInsert = new System.Windows.Forms.Button();
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
			this.dbBlockSearch.Controls.Add(this.tbTeachIn);
			this.dbBlockSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.dbBlockSearch.Location = new System.Drawing.Point(0, 0);
			this.dbBlockSearch.Name = "dbBlockSearch";
			this.dbBlockSearch.Size = new System.Drawing.Size(266, 178);
			this.dbBlockSearch.TabIndex = 38;
			this.dbBlockSearch.TabStop = false;
			// 
			// tbTeachIn
			// 
			this.tbTeachIn.AcceptsReturn = true;
			this.tbTeachIn.AcceptsTab = true;
			this.tbTeachIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tbTeachIn.Location = new System.Drawing.Point(0, 16);
			this.tbTeachIn.Multiline = true;
			this.tbTeachIn.Name = "tbTeachIn";
			this.tbTeachIn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbTeachIn.Size = new System.Drawing.Size(267, 162);
			this.tbTeachIn.TabIndex = 1;
			this.tbTeachIn.WordWrap = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btDelete);
			this.groupBox1.Controls.Add(this.btAdd);
			this.groupBox1.Controls.Add(this.btSave);
			this.groupBox1.Controls.Add(this.btInsert);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(0, 175);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(266, 40);
			this.groupBox1.TabIndex = 39;
			this.groupBox1.TabStop = false;
			// 
			// btDelete
			// 
			this.btDelete.Enabled = false;
			this.btDelete.Location = new System.Drawing.Point(134, 11);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(44, 24);
			this.btDelete.TabIndex = 6;
			this.btDelete.Text = "Del";
			this.btDelete.UseVisualStyleBackColor = true;
			// 
			// btAdd
			// 
			this.btAdd.Location = new System.Drawing.Point(6, 11);
			this.btAdd.Name = "btAdd";
			this.btAdd.Size = new System.Drawing.Size(72, 24);
			this.btAdd.TabIndex = 1;
			this.btAdd.Text = "Add";
			this.btAdd.UseVisualStyleBackColor = true;
			this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
			// 
			// btSave
			// 
			this.btSave.Cursor = System.Windows.Forms.Cursors.Default;
			this.btSave.Location = new System.Drawing.Point(185, 11);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(72, 24);
			this.btSave.TabIndex = 5;
			this.btSave.Text = "Save";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btInsert
			// 
			this.btInsert.Cursor = System.Windows.Forms.Cursors.Default;
			this.btInsert.Enabled = false;
			this.btInsert.Location = new System.Drawing.Point(84, 11);
			this.btInsert.Name = "btInsert";
			this.btInsert.Size = new System.Drawing.Size(44, 24);
			this.btInsert.TabIndex = 2;
			this.btInsert.Text = "Ins";
			this.btInsert.UseVisualStyleBackColor = true;
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
			this.lbActive.Text = "Aktive";
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
			this.lbHeader.Text = "Teach In";
			// 
			// TeachIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbActive);
			this.Controls.Add(this.lbHeader);
			this.Controls.Add(this.dbBlockSearch);
			this.Controls.Add(this.groupBox1);
			this.Name = "TeachIn";
			this.Size = new System.Drawing.Size(267, 217);
			this.Load += new System.EventHandler(this.TeachIn_Load);
			this.dbBlockSearch.ResumeLayout(false);
			this.dbBlockSearch.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox dbBlockSearch;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Button btInsert;
		private System.Windows.Forms.Label lbActive;
		private System.Windows.Forms.Label lbHeader;
		private System.Windows.Forms.Button btAdd;
		private System.Windows.Forms.Button btDelete;
		private System.Windows.Forms.TextBox tbTeachIn;

	}
}
