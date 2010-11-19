namespace TcApplication
{
	partial class FormManual
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
			this.tcAppPlcManualData1 = new TwinCAT.App.ManualFunctions.TcAppPlcManualData(this.components);
			this.tcAppPlcManual1 = new TwinCAT.App.ManualFunctions.TcAppPlcManual();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonMode = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tcAppPlcManualData1
			// 
			this.tcAppPlcManualData1.FileName = null;
			// 
			// tcAppPlcManual1
			// 
			this.tcAppPlcManual1.ActiveBackColor = System.Drawing.Color.Blue;
			this.tcAppPlcManual1.ActiveForeColor = System.Drawing.Color.White;
			this.tcAppPlcManual1.ActiveRow = 0;
			this.tcAppPlcManual1.CaptionVisible = false;
			this.tcAppPlcManual1.CurrentGroup = null;
			this.tcAppPlcManual1.CurrentGroupIndex = -1;
			this.tcAppPlcManual1.DataSource = this.tcAppPlcManualData1;
			this.tcAppPlcManual1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcAppPlcManual1.FirstRow = 0;
			this.tcAppPlcManual1.HeadBackColor = System.Drawing.Color.DarkBlue;
			this.tcAppPlcManual1.HeadFont = new System.Drawing.Font("Arial", 14F);
			this.tcAppPlcManual1.HeadForeColor = System.Drawing.Color.White;
			this.tcAppPlcManual1.InactiveBackColor = System.Drawing.Color.White;
			this.tcAppPlcManual1.InactiveForeColor = System.Drawing.Color.Black;
			this.tcAppPlcManual1.InfoBackColor = System.Drawing.Color.White;
			this.tcAppPlcManual1.InfoFont = new System.Drawing.Font("Arial", 12F);
			this.tcAppPlcManual1.InfoForeColor = System.Drawing.Color.Black;
			this.tcAppPlcManual1.Location = new System.Drawing.Point(0, 0);
			this.tcAppPlcManual1.Message = "";
			this.tcAppPlcManual1.MessageBackColor = System.Drawing.Color.Blue;
			this.tcAppPlcManual1.MessageFont = new System.Drawing.Font("Arial", 14F);
			this.tcAppPlcManual1.MessageForeColor = System.Drawing.Color.White;
			this.tcAppPlcManual1.Mode = TwinCAT.App.ManualFunctions.DisplayMode.Show;
			this.tcAppPlcManual1.Name = "tcAppPlcManual1";
			this.tcAppPlcManual1.Size = new System.Drawing.Size(784, 494);
			this.tcAppPlcManual1.TabIndex = 0;
			this.tcAppPlcManual1.TreeViewFont = new System.Drawing.Font("Arial", 10F);
			this.tcAppPlcManual1.TreeVisible = false;
			this.tcAppPlcManual1.VisibleRowCount = 8;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSave.Location = new System.Drawing.Point(64, 472);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(64, 24);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Save";
			this.buttonSave.Visible = false;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonMode
			// 
			this.buttonMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonMode.Location = new System.Drawing.Point(0, 472);
			this.buttonMode.Name = "buttonMode";
			this.buttonMode.Size = new System.Drawing.Size(64, 24);
			this.buttonMode.TabIndex = 3;
			this.buttonMode.Text = "Mode";
			this.buttonMode.Click += new System.EventHandler(this.buttonMode_Click);
			// 
			// FormManual
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(784, 494);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonMode);
			this.Controls.Add(this.tcAppPlcManual1);
			this.Name = "FormManual";
			this.Text = "formManual";
			this.Load += new System.EventHandler(this.FormManual_Load);
			this.Activated += new System.EventHandler(this.Form_Activated);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonSave;
		private TwinCAT.App.ManualFunctions.TcAppPlcManual tcAppPlcManual1;
		private TwinCAT.App.ManualFunctions.TcAppPlcManualData tcAppPlcManualData1;
		private System.Windows.Forms.Button buttonMode;
	}
}