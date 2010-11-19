namespace TcApplication
{
	partial class FormMessages
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
			this.labelEventLogStatus = new System.Windows.Forms.Label();
			this.cBLanguage = new System.Windows.Forms.ComboBox();
			this.buttonLocate = new System.Windows.Forms.Button();
			this.tcLog4NetView1 = new Beckhoff.EventLogger.TcLog4NetView();
			this.tcEventLoggerList1 = new Beckhoff.EventLogger.TcEventLogList();
			this.tcEventLoggerData1 = new Beckhoff.EventLogger.TcEventLogDataAdapter(this.components);
			this.SuspendLayout();
			// 
			// labelEventLogStatus
			// 
			this.labelEventLogStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.labelEventLogStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.labelEventLogStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEventLogStatus.ForeColor = System.Drawing.Color.White;
			this.labelEventLogStatus.Location = new System.Drawing.Point(0, 0);
			this.labelEventLogStatus.Name = "labelEventLogStatus";
			this.labelEventLogStatus.Size = new System.Drawing.Size(832, 32);
			this.labelEventLogStatus.TabIndex = 2;
			this.labelEventLogStatus.Text = "Active Messages";
			this.labelEventLogStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cBLanguage
			// 
			this.cBLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cBLanguage.Items.AddRange(new object[] {
            "1031",
            "1033",
            "1034",
            "1036",
            "1040"});
			this.cBLanguage.Location = new System.Drawing.Point(652, 5);
			this.cBLanguage.Name = "cBLanguage";
			this.cBLanguage.Size = new System.Drawing.Size(88, 21);
			this.cBLanguage.TabIndex = 1;
			this.cBLanguage.SelectedIndexChanged += new System.EventHandler(this.cBLanguage_SelectedIndexChanged);
			// 
			// buttonLocate
			// 
			this.buttonLocate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLocate.Location = new System.Drawing.Point(749, -2);
			this.buttonLocate.Name = "buttonLocate";
			this.buttonLocate.Size = new System.Drawing.Size(75, 32);
			this.buttonLocate.TabIndex = 22;
			this.buttonLocate.Text = "locate";
			this.buttonLocate.UseVisualStyleBackColor = true;
			this.buttonLocate.Click += new System.EventHandler(this.buttonLocate_Click);
			// 
			// tcLog4NetView1
			// 
			this.tcLog4NetView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tcLog4NetView1.ButtonErrorText = "Errors";
			this.tcLog4NetView1.ButtonMessageText = "Messages";
			this.tcLog4NetView1.ButtonWarningText = "Warnings";
			this.tcLog4NetView1.CaptionColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcLog4NetView1.ColCaptionDate = "Date";
			this.tcLog4NetView1.ColCaptionLevel = "Level";
			this.tcLog4NetView1.ColCaptionMessage = "Message";
			this.tcLog4NetView1.ColCaptionModule = "Module";
			this.tcLog4NetView1.ColCaptionMsgExt = "MsgExt";
			this.tcLog4NetView1.ColCaptionThread = "Thread";
			this.tcLog4NetView1.ColCaptionTime = "Time";
			this.tcLog4NetView1.DetailCaptionText = "Detailed Messages";
			this.tcLog4NetView1.DetailHeightRelation = 40;
			this.tcLog4NetView1.FilterTimeText = new string[] {
        "Any time",
        "Last hour",
        "Last 12 hours",
        "Last 24 hours",
        "Last 7 days",
        "Last 30 days",
        "Custom range ..."};
			this.tcLog4NetView1.Location = new System.Drawing.Point(0, 32);
			this.tcLog4NetView1.Name = "tcLog4NetView1";
			this.tcLog4NetView1.ShowCol = new bool[] {
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true};
			this.tcLog4NetView1.Size = new System.Drawing.Size(824, 480);
			this.tcLog4NetView1.TabIndex = 4;
			this.tcLog4NetView1.Visible = false;
			// 
			// tcEventLoggerList1
			// 
			this.tcEventLoggerList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tcEventLoggerList1.CaptionColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(131)))), ((int)(((byte)(190)))));
			this.tcEventLoggerList1.ColCaptionClass = "Class";
			this.tcEventLoggerList1.ColCaptionConfirm = "Confirm";
			this.tcEventLoggerList1.ColCaptionDate = "Date";
			this.tcEventLoggerList1.ColCaptionDescription = "Description";
			this.tcEventLoggerList1.ColCaptionId = "ID";
			this.tcEventLoggerList1.ColCaptionMessage = "Message";
			this.tcEventLoggerList1.ColCaptionNr = "Nr.";
			this.tcEventLoggerList1.ColCaptionPrority = "Priority";
			this.tcEventLoggerList1.ColCaptionSource = "Source Id";
			this.tcEventLoggerList1.ColCaptionSourceName = "Source Name";
			this.tcEventLoggerList1.ColCaptionState = "State";
			this.tcEventLoggerList1.ColCaptionTime = "Time";
			this.tcEventLoggerList1.ColCaptionValue = "Value";
			this.tcEventLoggerList1.DataAdapter = this.tcEventLoggerData1;
			this.tcEventLoggerList1.DetailCaptionText = "Detailed Messages";
			this.tcEventLoggerList1.Location = new System.Drawing.Point(0, 32);
			this.tcEventLoggerList1.Name = "tcEventLoggerList1";
			this.tcEventLoggerList1.ShowCol = new bool[] {
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        false,
        false,
        false};
			this.tcEventLoggerList1.ShowDetailWindow = false;
			this.tcEventLoggerList1.Size = new System.Drawing.Size(824, 480);
			this.tcEventLoggerList1.TabIndex = 0;
			this.tcEventLoggerList1.SelectedIndexChanged += new Beckhoff.EventLogger.SelectedIndexChangedEventHandler(this.tcEventLoggerList1_SelectedIndexChanged);
			// 
			// tcEventLoggerData1
			// 
			this.tcEventLoggerData1.AdsServerNetId = "";
			// 
			// FormMessages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(826, 512);
			this.Controls.Add(this.buttonLocate);
			this.Controls.Add(this.tcLog4NetView1);
			this.Controls.Add(this.tcEventLoggerList1);
			this.Controls.Add(this.cBLanguage);
			this.Controls.Add(this.labelEventLogStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormMessages";
			this.Text = "MessageLogger";
			this.Deactivate += new System.EventHandler(this.FormMessages_Deactivate);
			this.Load += new System.EventHandler(this.FormMessages_Load);
			this.Activated += new System.EventHandler(this.FormMessages_Activated);
			this.ResumeLayout(false);

		}

		#endregion

		public Beckhoff.EventLogger.TcEventLogDataAdapter tcEventLoggerData1;
		private System.Windows.Forms.Button buttonLocate;
		private Beckhoff.EventLogger.TcLog4NetView tcLog4NetView1;
		private System.Windows.Forms.ComboBox cBLanguage;
		private System.Windows.Forms.Label labelEventLogStatus;
		public Beckhoff.EventLogger.TcEventLogList tcEventLoggerList1;
	}
}