namespace TcApplication
{
	partial class MVStatus
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
			this.labelCaption = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelCaption
			// 
			this.labelCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.labelCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.labelCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelCaption.Location = new System.Drawing.Point(0, 0);
			this.labelCaption.Name = "labelCaption";
			this.labelCaption.Size = new System.Drawing.Size(104, 16);
			this.labelCaption.TabIndex = 7;
			this.labelCaption.Text = "Station";
			this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MVStatus2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelCaption);
			this.Name = "MVStatus2";
			this.Size = new System.Drawing.Size(104, 150);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Label labelCaption;
	}
}
