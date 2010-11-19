namespace TcApplication
{
	partial class FormMaschPara
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
            this.labelCaption = new System.Windows.Forms.Label();
            this.tcMachineParam1 = new Beckhoff.App.MachineParam.TcMachineParam();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
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
            this.labelCaption.Size = new System.Drawing.Size(704, 30);
            this.labelCaption.TabIndex = 2;
            this.labelCaption.Text = "Machine Data";
            this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcMachineParam1
            // 
            this.tcMachineParam1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMachineParam1.ConfigFileName = "MaschParam.ini";
            this.tcMachineParam1.ConfigHasChanged = false;
            this.tcMachineParam1.LanguageManager = null;
            this.tcMachineParam1.Location = new System.Drawing.Point(0, 30);
            this.tcMachineParam1.Name = "tcMachineParam1";
            this.tcMachineParam1.Size = new System.Drawing.Size(704, 347);
            this.tcMachineParam1.TabIndex = 3;
            this.tcMachineParam1.TreeViewVisible = true;
            this.tcMachineParam1.UserLevel = Beckhoff.App.Security.TcUserLevel.Administrator;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(608, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 21);
            this.button1.TabIndex = 4;
            this.button1.Text = "Read List";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMaschPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(704, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tcMachineParam1);
            this.Controls.Add(this.labelCaption);
            this.Name = "FormMaschPara";
            this.Text = "FormMaschPara";
            this.Deactivate += new System.EventHandler(this.FormMaschPara_Deactivate);
            this.Load += new System.EventHandler(this.FormMaschPar_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private Beckhoff.App.MachineParam.TcMachineParam tcMachineParam1;
		private System.Windows.Forms.Label labelCaption;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	}
}