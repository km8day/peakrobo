namespace TcApplication
{
	partial class OPModeMDI
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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.labelBoxMDI = new System.Windows.Forms.Label();
			this.textBoxMDI = new System.Windows.Forms.TextBox();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.groupBox3.Controls.Add(this.labelBoxMDI);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(0, -7);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(368, 39);
			this.groupBox3.TabIndex = 45;
			this.groupBox3.TabStop = false;
			// 
			// labelBoxMDI
			// 
			this.labelBoxMDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBoxMDI.ForeColor = System.Drawing.Color.White;
			this.labelBoxMDI.Location = new System.Drawing.Point(8, 16);
			this.labelBoxMDI.Name = "labelBoxMDI";
			this.labelBoxMDI.Size = new System.Drawing.Size(256, 16);
			this.labelBoxMDI.TabIndex = 39;
			this.labelBoxMDI.Text = "Operation Mode - MDI";
			this.labelBoxMDI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxMDI
			// 
			this.textBoxMDI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMDI.Location = new System.Drawing.Point(0, 32);
			this.textBoxMDI.MaxLength = 280;
			this.textBoxMDI.Multiline = true;
			this.textBoxMDI.Name = "textBoxMDI";
			this.textBoxMDI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxMDI.Size = new System.Drawing.Size(368, 240);
			this.textBoxMDI.TabIndex = 46;
			this.textBoxMDI.Text = "G91 G01 X100 Y10 F500\r\nZ10";
			// 
			// OPModeMDI
			// 
			this.Controls.Add(this.textBoxMDI);
			this.Controls.Add(this.groupBox3);
			this.Name = "OPModeMDI";
			this.Size = new System.Drawing.Size(368, 272);
			this.Load += new System.EventHandler(this.OPModeMDI_Load);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBoxMDI;
		private System.Windows.Forms.Label labelBoxMDI;
	}
}
