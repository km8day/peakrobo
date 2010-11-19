using Beckhoff.Forms;
using Beckhoff.Forms.Nc;

namespace TcApplication
{
	partial class FormCnc
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
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
				adsNcServer.NcClient.OpModeStateChanged -= new Beckhoff.Forms.Nc.CncOpModeStateChangedEventHandler(NcClient_OpModeStateChanged);
				adsNcServer.Dispose();
				adsPlcServer.Dispose();
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
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.panelChannelOverview = new System.Windows.Forms.Panel();
			this.labelChannelNr4 = new System.Windows.Forms.Label();
			this.labelChannelNr3 = new System.Windows.Forms.Label();
			this.labelChannelNr2 = new System.Windows.Forms.Label();
			this.labelChannelNr1 = new System.Windows.Forms.Label();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.tcChannelStatus3 = new Beckhoff.Forms.Nc.TcChannelStatus();
			this.tcAxesList4 = new Beckhoff.Forms.Nc.TcAxesList();
			this.tcChannelStatus4 = new Beckhoff.Forms.Nc.TcChannelStatus();
			this.tcChannelStatus2 = new Beckhoff.Forms.Nc.TcChannelStatus();
			this.tcAxesList3 = new Beckhoff.Forms.Nc.TcAxesList();
			this.tcChannelStatus1 = new Beckhoff.Forms.Nc.TcChannelStatus();
			this.tcAxesList2 = new Beckhoff.Forms.Nc.TcAxesList();
			this.tcAxesList5 = new Beckhoff.Forms.Nc.TcAxesList();
			this.tcFunctionView = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tcTechnoData1 = new Beckhoff.Forms.Nc.TcTechnologyData();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.blockSearch1 = new TcApplication.BlockSearch();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.syntaxCheck1 = new TcApplication.SyntaxCheck();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.teachIn1 = new TcApplication.TeachIn();
			this.tcAxesList1 = new Beckhoff.Forms.Nc.TcAxesList();
			this.tcFKeyRight = new Beckhoff.App.TcFKey();
			this.tcFKeyLeft = new Beckhoff.App.TcFKey();
			this.tcSpeedControl1 = new Beckhoff.Forms.Nc.TcSpeedControl();
			this.tcFKeyOpMode = new Beckhoff.App.TcFKey();
			this.tcOverride1 = new Beckhoff.Forms.Nc.TcOverride();
			this.tcPlcConnect1 = new Beckhoff.Forms.TcPlcConnect(this.components);
			this.tcPlcConnect2 = new Beckhoff.Forms.TcPlcConnect(this.components);
			this.panelCnc = new System.Windows.Forms.Panel();
			this.opModeAuto1 = new TcApplication.OPModeAuto();
			this.opModeManual1 = new TcApplication.OPModeManual();
			this.opModeMDI1 = new TcApplication.OPModeMDI();
			this.panelChannelOverview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.tcFunctionView.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.panelCnc.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(0, 0);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(104, 24);
			this.radioButton6.TabIndex = 0;
			// 
			// panelChannelOverview
			// 
			this.panelChannelOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.panelChannelOverview.Controls.Add(this.labelChannelNr4);
			this.panelChannelOverview.Controls.Add(this.labelChannelNr3);
			this.panelChannelOverview.Controls.Add(this.labelChannelNr2);
			this.panelChannelOverview.Controls.Add(this.labelChannelNr1);
			this.panelChannelOverview.Controls.Add(this.pictureBox3);
			this.panelChannelOverview.Controls.Add(this.pictureBox7);
			this.panelChannelOverview.Controls.Add(this.pictureBox1);
			this.panelChannelOverview.Controls.Add(this.pictureBox2);
			this.panelChannelOverview.Controls.Add(this.tcChannelStatus3);
			this.panelChannelOverview.Controls.Add(this.tcAxesList4);
			this.panelChannelOverview.Controls.Add(this.tcChannelStatus4);
			this.panelChannelOverview.Controls.Add(this.tcChannelStatus2);
			this.panelChannelOverview.Controls.Add(this.tcAxesList3);
			this.panelChannelOverview.Controls.Add(this.tcChannelStatus1);
			this.panelChannelOverview.Controls.Add(this.tcAxesList2);
			this.panelChannelOverview.Controls.Add(this.tcAxesList5);
			this.panelChannelOverview.Location = new System.Drawing.Point(118, 0);
			this.panelChannelOverview.Name = "panelChannelOverview";
			this.panelChannelOverview.Size = new System.Drawing.Size(788, 632);
			this.panelChannelOverview.TabIndex = 29;
			this.panelChannelOverview.Visible = false;
			// 
			// labelChannelNr4
			// 
			this.labelChannelNr4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.labelChannelNr4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChannelNr4.ForeColor = System.Drawing.Color.White;
			this.labelChannelNr4.Location = new System.Drawing.Point(442, 361);
			this.labelChannelNr4.Name = "labelChannelNr4";
			this.labelChannelNr4.Size = new System.Drawing.Size(104, 16);
			this.labelChannelNr4.TabIndex = 72;
			this.labelChannelNr4.Text = "Kanal";
			this.labelChannelNr4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelChannelNr3
			// 
			this.labelChannelNr3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.labelChannelNr3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChannelNr3.ForeColor = System.Drawing.Color.White;
			this.labelChannelNr3.Location = new System.Drawing.Point(40, 361);
			this.labelChannelNr3.Name = "labelChannelNr3";
			this.labelChannelNr3.Size = new System.Drawing.Size(104, 16);
			this.labelChannelNr3.TabIndex = 72;
			this.labelChannelNr3.Text = "Kanal";
			this.labelChannelNr3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelChannelNr2
			// 
			this.labelChannelNr2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.labelChannelNr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChannelNr2.ForeColor = System.Drawing.Color.White;
			this.labelChannelNr2.Location = new System.Drawing.Point(442, 41);
			this.labelChannelNr2.Name = "labelChannelNr2";
			this.labelChannelNr2.Size = new System.Drawing.Size(104, 16);
			this.labelChannelNr2.TabIndex = 72;
			this.labelChannelNr2.Text = "Kanal";
			this.labelChannelNr2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelChannelNr1
			// 
			this.labelChannelNr1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.labelChannelNr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChannelNr1.ForeColor = System.Drawing.Color.White;
			this.labelChannelNr1.Location = new System.Drawing.Point(40, 41);
			this.labelChannelNr1.Name = "labelChannelNr1";
			this.labelChannelNr1.Size = new System.Drawing.Size(104, 16);
			this.labelChannelNr1.TabIndex = 71;
			this.labelChannelNr1.Text = "Kanal";
			this.labelChannelNr1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.White;
			this.pictureBox3.Location = new System.Drawing.Point(399, 0);
			this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(1, 64);
			this.pictureBox3.TabIndex = 11;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox7
			// 
			this.pictureBox7.BackColor = System.Drawing.Color.White;
			this.pictureBox7.Location = new System.Drawing.Point(399, 320);
			this.pictureBox7.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(1, 64);
			this.pictureBox7.TabIndex = 10;
			this.pictureBox7.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.Location = new System.Drawing.Point(-2, 352);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(784, 1);
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.White;
			this.pictureBox2.Location = new System.Drawing.Point(-2, 31);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(784, 1);
			this.pictureBox2.TabIndex = 8;
			this.pictureBox2.TabStop = false;
			// 
			// tcChannelStatus3
			// 
			this.tcChannelStatus3.AdsNcServer = null;
			this.tcChannelStatus3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcChannelStatus3.Location = new System.Drawing.Point(0, 320);
			this.tcChannelStatus3.Name = "tcChannelStatus3";
			this.tcChannelStatus3.Size = new System.Drawing.Size(400, 64);
			this.tcChannelStatus3.TabIndex = 7;
			// 
			// tcAxesList4
			// 
			this.tcAxesList4.AdsNcServer = null;
			this.tcAxesList4.BackColor = System.Drawing.Color.White;
			this.tcAxesList4.BlockWidth1 = 90;
			this.tcAxesList4.BlockWidth2 = 50;
			this.tcAxesList4.BlockWidth3 = 100;
			this.tcAxesList4.BlockWidth4 = 100;
			this.tcAxesList4.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcAxesList4.FontAxisName = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
			this.tcAxesList4.LanguageManager = null;
			this.tcAxesList4.Location = new System.Drawing.Point(0, 352);
			this.tcAxesList4.Name = "tcAxesList4";
			this.tcAxesList4.Size = new System.Drawing.Size(400, 288);
			this.tcAxesList4.TabIndex = 6;
			// 
			// tcChannelStatus4
			// 
			this.tcChannelStatus4.AdsNcServer = null;
			this.tcChannelStatus4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcChannelStatus4.Location = new System.Drawing.Point(400, 320);
			this.tcChannelStatus4.Name = "tcChannelStatus4";
			this.tcChannelStatus4.Size = new System.Drawing.Size(384, 64);
			this.tcChannelStatus4.TabIndex = 5;
			// 
			// tcChannelStatus2
			// 
			this.tcChannelStatus2.AdsNcServer = null;
			this.tcChannelStatus2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcChannelStatus2.Location = new System.Drawing.Point(400, 0);
			this.tcChannelStatus2.Name = "tcChannelStatus2";
			this.tcChannelStatus2.Size = new System.Drawing.Size(384, 64);
			this.tcChannelStatus2.TabIndex = 3;
			// 
			// tcAxesList3
			// 
			this.tcAxesList3.AdsNcServer = null;
			this.tcAxesList3.BackColor = System.Drawing.Color.White;
			this.tcAxesList3.BlockWidth1 = 90;
			this.tcAxesList3.BlockWidth2 = 50;
			this.tcAxesList3.BlockWidth3 = 100;
			this.tcAxesList3.BlockWidth4 = 100;
			this.tcAxesList3.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcAxesList3.FontAxisName = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
			this.tcAxesList3.LanguageManager = null;
			this.tcAxesList3.Location = new System.Drawing.Point(400, 31);
			this.tcAxesList3.Name = "tcAxesList3";
			this.tcAxesList3.Size = new System.Drawing.Size(384, 289);
			this.tcAxesList3.TabIndex = 2;
			// 
			// tcChannelStatus1
			// 
			this.tcChannelStatus1.AdsNcServer = null;
			this.tcChannelStatus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcChannelStatus1.Location = new System.Drawing.Point(0, 0);
			this.tcChannelStatus1.Name = "tcChannelStatus1";
			this.tcChannelStatus1.Size = new System.Drawing.Size(400, 64);
			this.tcChannelStatus1.TabIndex = 1;
			// 
			// tcAxesList2
			// 
			this.tcAxesList2.AdsNcServer = null;
			this.tcAxesList2.BackColor = System.Drawing.Color.White;
			this.tcAxesList2.BlockWidth1 = 90;
			this.tcAxesList2.BlockWidth2 = 50;
			this.tcAxesList2.BlockWidth3 = 100;
			this.tcAxesList2.BlockWidth4 = 100;
			this.tcAxesList2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcAxesList2.FontAxisName = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
			this.tcAxesList2.LanguageManager = null;
			this.tcAxesList2.Location = new System.Drawing.Point(0, 31);
			this.tcAxesList2.Name = "tcAxesList2";
			this.tcAxesList2.Size = new System.Drawing.Size(400, 289);
			this.tcAxesList2.TabIndex = 0;
			// 
			// tcAxesList5
			// 
			this.tcAxesList5.AdsNcServer = null;
			this.tcAxesList5.BackColor = System.Drawing.Color.White;
			this.tcAxesList5.BlockWidth1 = 90;
			this.tcAxesList5.BlockWidth2 = 50;
			this.tcAxesList5.BlockWidth3 = 100;
			this.tcAxesList5.BlockWidth4 = 100;
			this.tcAxesList5.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcAxesList5.FontAxisName = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
			this.tcAxesList5.LanguageManager = null;
			this.tcAxesList5.Location = new System.Drawing.Point(400, 352);
			this.tcAxesList5.Name = "tcAxesList5";
			this.tcAxesList5.Size = new System.Drawing.Size(384, 288);
			this.tcAxesList5.TabIndex = 4;
			// 
			// tcFunctionView
			// 
			this.tcFunctionView.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tcFunctionView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tcFunctionView.Controls.Add(this.tabPage1);
			this.tcFunctionView.Controls.Add(this.tabPage2);
			this.tcFunctionView.Controls.Add(this.tabPage3);
			this.tcFunctionView.Controls.Add(this.tabPage4);
			this.tcFunctionView.Location = new System.Drawing.Point(506, 232);
			this.tcFunctionView.Margin = new System.Windows.Forms.Padding(0);
			this.tcFunctionView.Multiline = true;
			this.tcFunctionView.Name = "tcFunctionView";
			this.tcFunctionView.SelectedIndex = 0;
			this.tcFunctionView.Size = new System.Drawing.Size(282, 398);
			this.tcFunctionView.TabIndex = 30;
			this.tcFunctionView.SelectedIndexChanged += new System.EventHandler(this.tcFunctionView_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tcTechnoData1);
			this.tabPage1.Location = new System.Drawing.Point(4, 4);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(274, 372);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Techno";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tcTechnoData1
			// 
			this.tcTechnoData1.AdsNcServer = null;
			this.tcTechnoData1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tcTechnoData1.BackColor = System.Drawing.Color.White;
			this.tcTechnoData1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcTechnoData1.EnableTimer = false;
			this.tcTechnoData1.LanguageManager = null;
			this.tcTechnoData1.Location = new System.Drawing.Point(0, 1);
			this.tcTechnoData1.Name = "tcTechnoData1";
			this.tcTechnoData1.RefreshTime = 500;
			this.tcTechnoData1.Size = new System.Drawing.Size(274, 368);
			this.tcTechnoData1.TabIndex = 6;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.blockSearch1);
			this.tabPage2.Location = new System.Drawing.Point(4, 4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(274, 372);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "BlockSearch";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabPage2.Visible = false;
			// 
			// blockSearch1
			// 
			this.blockSearch1.AdsPlcServer = null;
			this.blockSearch1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.blockSearch1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.blockSearch1.Cursor = System.Windows.Forms.Cursors.Default;
			this.blockSearch1.LanguageManager = null;
			this.blockSearch1.Location = new System.Drawing.Point(0, 0);
			this.blockSearch1.Name = "blockSearch1";
			this.blockSearch1.Size = new System.Drawing.Size(274, 236);
			this.blockSearch1.TabIndex = 0;
			this.blockSearch1.TimerEnabled = false;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.syntaxCheck1);
			this.tabPage3.Location = new System.Drawing.Point(4, 4);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(274, 372);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Syntax Check";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.tabPage3.Visible = false;
			// 
			// syntaxCheck1
			// 
			this.syntaxCheck1.AdsPlcServer = null;
			this.syntaxCheck1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.syntaxCheck1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.syntaxCheck1.LanguageManager = null;
			this.syntaxCheck1.Location = new System.Drawing.Point(0, 0);
			this.syntaxCheck1.Name = "syntaxCheck1";
			this.syntaxCheck1.Size = new System.Drawing.Size(274, 372);
			this.syntaxCheck1.TabIndex = 0;
			this.syntaxCheck1.TimerEnabled = false;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.teachIn1);
			this.tabPage4.Location = new System.Drawing.Point(4, 4);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(274, 372);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "TeachIn";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.tabPage4.Visible = false;
			// 
			// teachIn1
			// 
			this.teachIn1.AdsNcServer = null;
			this.teachIn1.AdsPlcServer = null;
			this.teachIn1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.teachIn1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.teachIn1.GenerateLineNumber = true;
			this.teachIn1.LanguageManager = null;
			this.teachIn1.Location = new System.Drawing.Point(0, 0);
			this.teachIn1.Name = "teachIn1";
			this.teachIn1.Size = new System.Drawing.Size(273, 372);
			this.teachIn1.TabIndex = 0;
			// 
			// tcAxesList1
			// 
			this.tcAxesList1.AdsNcServer = null;
			this.tcAxesList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tcAxesList1.BackColor = System.Drawing.Color.White;
			this.tcAxesList1.BlockWidth1 = 80;
			this.tcAxesList1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcAxesList1.FontAxisName = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
			this.tcAxesList1.LanguageManager = null;
			this.tcAxesList1.Location = new System.Drawing.Point(0, 0);
			this.tcAxesList1.Name = "tcAxesList1";
			this.tcAxesList1.Size = new System.Drawing.Size(506, 232);
			this.tcAxesList1.TabIndex = 25;
			// 
			// tcFKeyRight
			// 
			this.tcFKeyRight.BackColor = System.Drawing.Color.Silver;
			this.tcFKeyRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.tcFKeyRight.FKeyBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
			this.tcFKeyRight.FKeyBtnForeColor = System.Drawing.Color.White;
			this.tcFKeyRight.FKeyBtnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.tcFKeyRight.FKeyImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.tcFKeyRight.FKeyLabelAlign = System.Drawing.ContentAlignment.TopLeft;
			this.tcFKeyRight.FKeyLabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.tcFKeyRight.FKeyLabelForeColor = System.Drawing.Color.White;
			this.tcFKeyRight.FKeyLabelWidthRelation = 0;
			this.tcFKeyRight.FKeyMax = 8;
			this.tcFKeyRight.FKeyStyle = 4;
			this.tcFKeyRight.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tcFKeyRight.Location = new System.Drawing.Point(906, 0);
			this.tcFKeyRight.Name = "tcFKeyRight";
			this.tcFKeyRight.Size = new System.Drawing.Size(118, 630);
			this.tcFKeyRight.TabIndex = 18;
			this.tcFKeyRight.FKeyUpEvent += new FKeyDelegate(this.tcFKeyRight_FKeyUpEvent);
			// 
			// tcFKeyLeft
			// 
			this.tcFKeyLeft.BackColor = System.Drawing.Color.Silver;
			this.tcFKeyLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.tcFKeyLeft.FKeyBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
			this.tcFKeyLeft.FKeyBtnForeColor = System.Drawing.Color.White;
			this.tcFKeyLeft.FKeyBtnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.tcFKeyLeft.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.tcFKeyLeft.FKeyLabelAlign = System.Drawing.ContentAlignment.TopLeft;
			this.tcFKeyLeft.FKeyLabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.tcFKeyLeft.FKeyLabelForeColor = System.Drawing.Color.White;
			this.tcFKeyLeft.FKeyLabelWidthRelation = 0;
			this.tcFKeyLeft.FKeyMax = 8;
			this.tcFKeyLeft.FKeyStyle = 4;
			this.tcFKeyLeft.FKeyTextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.tcFKeyLeft.Location = new System.Drawing.Point(0, 0);
			this.tcFKeyLeft.Name = "tcFKeyLeft";
			this.tcFKeyLeft.Size = new System.Drawing.Size(118, 630);
			this.tcFKeyLeft.TabIndex = 27;
			this.tcFKeyLeft.FKeyUpEvent += new FKeyDelegate(this.tcFKeyLeft_FKeyUpEvent);
			// 
			// tcSpeedControl1
			// 
			this.tcSpeedControl1.AdsNcServer = null;
			this.tcSpeedControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tcSpeedControl1.BackColor = System.Drawing.Color.White;
			this.tcSpeedControl1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcSpeedControl1.LanguageManager = null;
			this.tcSpeedControl1.Location = new System.Drawing.Point(506, 129);
			this.tcSpeedControl1.Name = "tcSpeedControl1";
			this.tcSpeedControl1.Size = new System.Drawing.Size(282, 104);
			this.tcSpeedControl1.TabIndex = 29;
			// 
			// tcFKeyOpMode
			// 
			this.tcFKeyOpMode.FKeyBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
			this.tcFKeyOpMode.FKeyBtnForeColor = System.Drawing.Color.White;
			this.tcFKeyOpMode.FKeyBtnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.tcFKeyOpMode.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.tcFKeyOpMode.FKeyLabelAlign = System.Drawing.ContentAlignment.TopLeft;
			this.tcFKeyOpMode.FKeyLabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.tcFKeyOpMode.FKeyLabelForeColor = System.Drawing.Color.WhiteSmoke;
			this.tcFKeyOpMode.FKeyLabelWidthRelation = 0;
			this.tcFKeyOpMode.FKeyMax = 4;
			this.tcFKeyOpMode.FKeyStyle = 4;
			this.tcFKeyOpMode.FKeyTextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.tcFKeyOpMode.Location = new System.Drawing.Point(144, 432);
			this.tcFKeyOpMode.Name = "tcFKeyOpMode";
			this.tcFKeyOpMode.Size = new System.Drawing.Size(136, 160);
			this.tcFKeyOpMode.TabIndex = 15;
			this.tcFKeyOpMode.FKeyUpEvent += new FKeyDelegate(this.tcFKeyOpMode_FKeyUpEvent);
			// 
			// tcOverride1
			// 
			this.tcOverride1.AdsNcServer = null;
			this.tcOverride1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tcOverride1.BackColor = System.Drawing.Color.White;
			this.tcOverride1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.tcOverride1.FeedrateOverrideMax = 120;
			this.tcOverride1.FeedrateOverrideValue = 100;
			this.tcOverride1.LanguageManager = null;
			this.tcOverride1.Location = new System.Drawing.Point(506, 1);
			this.tcOverride1.Name = "tcOverride1";
			this.tcOverride1.PlcVarFeedOverride = "";
			this.tcOverride1.PlcVarSpindleOverride = "";
			this.tcOverride1.Size = new System.Drawing.Size(282, 128);
			this.tcOverride1.SpindleOverrideMax = 130;
			this.tcOverride1.SpindleOverrideValue = 100;
			this.tcOverride1.TabIndex = 28;
			// 
			// tcPlcConnect1
			// 
			this.tcPlcConnect1.AdsPlcServer = null;
			this.tcPlcConnect1.ConnectionTag = "";
			this.tcPlcConnect1.PlcVariableName = null;
			this.tcPlcConnect1.ValueChanged += new Beckhoff.Forms.TcPlcValueChangedEventHandler(this.tcPlcConnect1_ValueChanged);
			// 
			// tcPlcConnect2
			// 
			this.tcPlcConnect2.AdsPlcServer = null;
			this.tcPlcConnect2.ConnectionTag = "";
			this.tcPlcConnect2.PlcVariableName = null;
			this.tcPlcConnect2.ValueChanged += new Beckhoff.Forms.TcPlcValueChangedEventHandler(this.tcPlcConnect2_ValueChanged);
			// 
			// panelCnc
			// 
			this.panelCnc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.panelCnc.Controls.Add(this.tcAxesList1);
			this.panelCnc.Controls.Add(this.opModeAuto1);
			this.panelCnc.Controls.Add(this.tcOverride1);
			this.panelCnc.Controls.Add(this.tcFunctionView);
			this.panelCnc.Controls.Add(this.tcSpeedControl1);
			this.panelCnc.Controls.Add(this.opModeManual1);
			this.panelCnc.Controls.Add(this.opModeMDI1);
			this.panelCnc.Location = new System.Drawing.Point(119, 0);
			this.panelCnc.Name = "panelCnc";
			this.panelCnc.Size = new System.Drawing.Size(788, 629);
			this.panelCnc.TabIndex = 34;
			// 
			// opModeAuto1
			// 
			this.opModeAuto1.ActiveProgramCaption = "Active program :";
			this.opModeAuto1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.opModeAuto1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.opModeAuto1.Location = new System.Drawing.Point(0, 232);
			this.opModeAuto1.Name = "opModeAuto1";
			this.opModeAuto1.Size = new System.Drawing.Size(506, 398);
			this.opModeAuto1.TabIndex = 33;
			this.opModeAuto1.Visible = false;
			this.opModeAuto1.FileNameChanged += new Beckhoff.App.SelectFile.FileSelectedEventHandler(this.opModeAuto1_FileNameChanged);
			// 
			// opModeManual1
			// 
			this.opModeManual1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.opModeManual1.Caption = "Operation Mode - Manual";
			this.opModeManual1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.opModeManual1.Location = new System.Drawing.Point(0, 232);
			this.opModeManual1.Name = "opModeManual1";
			this.opModeManual1.Size = new System.Drawing.Size(506, 398);
			this.opModeManual1.TabIndex = 32;
			this.opModeManual1.Visible = false;
			// 
			// opModeMDI1
			// 
			this.opModeMDI1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.opModeMDI1.Caption = "Operation Mode - MDI";
			this.opModeMDI1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.opModeMDI1.FontName = "Microsoft Sans Serif";
			this.opModeMDI1.Location = new System.Drawing.Point(0, 232);
			this.opModeMDI1.MdiText = "G91 G01 X100 Y10 F500\r\nZ10";
			this.opModeMDI1.Name = "opModeMDI1";
			this.opModeMDI1.Size = new System.Drawing.Size(506, 398);
			this.opModeMDI1.TabIndex = 31;
			this.opModeMDI1.Visible = false;
			// 
			// FormCnc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1024, 630);
			this.Controls.Add(this.tcFKeyRight);
			this.Controls.Add(this.tcFKeyLeft);
			this.Controls.Add(this.tcFKeyOpMode);
			this.Controls.Add(this.panelCnc);
			this.Controls.Add(this.panelChannelOverview);
			this.Name = "FormCnc";
			this.Text = "FormCnc";
			this.Deactivate += new System.EventHandler(this.FormCnc_Deactivate);
			this.Load += new System.EventHandler(this.FormCnc_Load);
			this.Activated += new System.EventHandler(this.FormCnc_Activated);
			this.panelChannelOverview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.tcFunctionView.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.panelCnc.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Beckhoff.Forms.Nc.TcChannelStatus tcChannelStatus3;
		private Beckhoff.Forms.Nc.TcAxesList tcAxesList4;
		private Beckhoff.Forms.Nc.TcSpeedControl tcSpeedControl1;
		private Beckhoff.Forms.Nc.TcChannelStatus tcChannelStatus4;
		private Beckhoff.Forms.Nc.TcChannelStatus tcChannelStatus2;
		private Beckhoff.Forms.Nc.TcAxesList tcAxesList3;
		private System.Windows.Forms.TabPage tabPage2;
		private BlockSearch blockSearch1;
		private Beckhoff.Forms.Nc.TcTechnologyData tcTechnoData1;
		private OPModeMDI opModeMDI1;
		private System.Windows.Forms.TabPage tabPage1;
		private OPModeAuto opModeAuto1;
		private System.Windows.Forms.TabPage tabPage3;
		private SyntaxCheck syntaxCheck1;
		private TeachIn teachIn1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabControl tcFunctionView;
		private System.Windows.Forms.RadioButton radioButton6;
		private Beckhoff.Forms.Nc.TcAxesList tcAxesList1;
		private OPModeManual opModeManual1;
		private Beckhoff.App.TcFKey tcFKeyRight;
		private Beckhoff.Forms.Nc.TcAxesList tcAxesList5;
		private Beckhoff.App.TcFKey tcFKeyLeft;
		private Beckhoff.Forms.Nc.TcChannelStatus tcChannelStatus1;
		private Beckhoff.App.TcFKey tcFKeyOpMode;
		private Beckhoff.Forms.Nc.TcOverride tcOverride1;
		private System.Windows.Forms.Panel panelChannelOverview;
		private Beckhoff.Forms.Nc.TcAxesList tcAxesList2;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox7;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Label labelChannelNr4;
		private System.Windows.Forms.Label labelChannelNr3;
		private System.Windows.Forms.Label labelChannelNr2;
		private System.Windows.Forms.Label labelChannelNr1;
		private TcPlcConnect tcPlcConnect1;
		private TcPlcConnect tcPlcConnect2;
		private System.Windows.Forms.Panel panelCnc;
	}
}