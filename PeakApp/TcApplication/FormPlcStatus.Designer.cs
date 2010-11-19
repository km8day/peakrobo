namespace TcApplication
{
	partial class FormPlcStatus
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
			this.labelCaption = new System.Windows.Forms.Label();
			this.tcPlcStatus1 = new Beckhoff.App.PlcStatus.TcPlcStatus();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// labelCaption
			// 
			this.labelCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.labelCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.labelCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCaption.ForeColor = System.Drawing.Color.White;
			this.labelCaption.Location = new System.Drawing.Point(0, 0);
			this.labelCaption.Name = "labelCaption";
			this.labelCaption.Size = new System.Drawing.Size(576, 32);
			this.labelCaption.TabIndex = 3;
			this.labelCaption.Text = "PLC Status";
			this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tcPlcStatus1
			// 
			this.tcPlcStatus1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tcPlcStatus1.ConfigFileName = "MaschParam.ini";
			this.tcPlcStatus1.LanguageManager = null;
			this.tcPlcStatus1.Location = new System.Drawing.Point(0, 32);
			this.tcPlcStatus1.Name = "tcPlcStatus1";
			this.tcPlcStatus1.Size = new System.Drawing.Size(576, 280);
			this.tcPlcStatus1.TabIndex = 4;
			this.tcPlcStatus1.UserLevel = Beckhoff.App.Security.TcUserLevel.Administrator;
			// 
			// timer1
			// 
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// FormPlcStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(576, 310);
			this.Controls.Add(this.tcPlcStatus1);
			this.Controls.Add(this.labelCaption);
			this.Name = "FormPlcStatus";
			this.Text = "FormPlcStatus";
			this.Deactivate += new System.EventHandler(this.FormPlcStatus_Deactivate);
			this.Load += new System.EventHandler(this.FormPlcStatus_Load);
			this.Activated += new System.EventHandler(this.Form_Activated);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private Beckhoff.App.PlcStatus.TcPlcStatus tcPlcStatus1;
		private System.Windows.Forms.Label labelCaption;
	}
}