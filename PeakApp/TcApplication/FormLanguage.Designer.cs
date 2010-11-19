namespace TcApplication
{
	partial class FormLanguage
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
			this.tcFKeyLanguage = new Beckhoff.App.TcFKey();
			this.btnLanguageSelect = new System.Windows.Forms.Button();
			this.lblLanguages = new System.Windows.Forms.Label();
			this.btnTextData = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tcFKey2
			// 
			this.tcFKeyLanguage.BackColor = System.Drawing.SystemColors.Control;
			this.tcFKeyLanguage.FKeyBtnBackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(102)));
			this.tcFKeyLanguage.FKeyBtnForeColor = System.Drawing.Color.White;
			this.tcFKeyLanguage.FKeyBtnSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(102)));
			this.tcFKeyLanguage.FKeyFlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.tcFKeyLanguage.FKeyHorizontalDistanceLeft = 0;
			this.tcFKeyLanguage.FKeyHorizontalDistanceRight = 0;
			this.tcFKeyLanguage.FKeyImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.tcFKeyLanguage.FKeyLabelBackColor = System.Drawing.Color.Blue;
			this.tcFKeyLanguage.FKeyLabelForeColor = System.Drawing.Color.LightGray;
			this.tcFKeyLanguage.FKeyLabelHeightRelation = 0;
			this.tcFKeyLanguage.FKeyLabelTextString = "F";
			this.tcFKeyLanguage.FKeyLabelWidthRelation = 40;
			this.tcFKeyLanguage.FKeyMax = 8;
			this.tcFKeyLanguage.FKeySelectedMode = false;
			this.tcFKeyLanguage.FKeyStyle = 4;
			this.tcFKeyLanguage.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tcFKeyLanguage.FKeyVerticalDistance = 0;
			this.tcFKeyLanguage.Location = new System.Drawing.Point(48, 40);
			this.tcFKeyLanguage.Name = "tcFKey2";
			this.tcFKeyLanguage.Size = new System.Drawing.Size(208, 400);
			this.tcFKeyLanguage.TabIndex = 0;
			// 
			// btnLanguageSelect
			// 
			this.btnLanguageSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnLanguageSelect.Location = new System.Drawing.Point(328, 328);
			this.btnLanguageSelect.Name = "btnLanguageSelect";
			this.btnLanguageSelect.Size = new System.Drawing.Size(112, 48);
			this.btnLanguageSelect.TabIndex = 1;
			this.btnLanguageSelect.Text = "button1";
			this.btnLanguageSelect.Click += new System.EventHandler(this.btnLanguageSelect_Click);
			// 
			// lblLanguages
			// 
			this.lblLanguages.Location = new System.Drawing.Point(48, 8);
			this.lblLanguages.Name = "lblLanguages";
			this.lblLanguages.Size = new System.Drawing.Size(504, 24);
			this.lblLanguages.TabIndex = 2;
			this.lblLanguages.Text = "label1";
			// 
			// btnTextData
			// 
			this.btnTextData.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnTextData.Location = new System.Drawing.Point(328, 392);
			this.btnTextData.Name = "btnTextData";
			this.btnTextData.Size = new System.Drawing.Size(112, 48);
			this.btnTextData.TabIndex = 3;
			this.btnTextData.Text = "button2";
			this.btnTextData.Click += new System.EventHandler(this.btnTextData_Click);
			// 
			// FormLanguage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(720, 526);
			this.Controls.Add(this.btnTextData);
			this.Controls.Add(this.lblLanguages);
			this.Controls.Add(this.btnLanguageSelect);
			this.Controls.Add(this.tcFKeyLanguage);
			this.Name = "FormLanguage";
			this.Text = "FormLanguage";
			this.Load += new System.EventHandler(this.FormLanguage_Load);
			this.Activated += new System.EventHandler(this.FormLanguage_Activated);
			this.ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button btnTextData;
		private System.Windows.Forms.Label lblLanguages;
		private System.Windows.Forms.Button btnLanguageSelect;
		private Beckhoff.App.TcFKey tcFKeyLanguage;
	}
}