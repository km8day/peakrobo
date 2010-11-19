using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Beckhoff.App.TcMenu;

namespace TcApplication
{
	public partial class Header6p5 : UserControl, IAppHeader
	{
		string imageFileName;
		string channelText = "";
		Color colorCaption;
		Color colorRow2;
		Color colorRow3;
		int selectedChannelNr;
		TcMenu menu;
		Beckhoff.App.Security.TcUserAdmin userAdmin;

		/// <summary>
		/// Initializes a new instance of the <see cref="Header12"/> class.
		/// </summary>
		public Header6p5()
		{
			InitializeComponent();
			timerDateTime_Tick(null, null);
			channelText = labelChannelNr.Text;
		}

		#region IAppHeader Members

		#region Properties

		/// <summary>
		/// Gets or sets the Ads server reference.
		/// </summary>
		/// <value>The reference of the Ads server.</value>
		[Description("Gets or sets the Ads server reference."), Category("TcApp")]
		public Beckhoff.Forms.Nc.TcAdsNcServer AdsNcServer
		{
			get { return tcChannelStatus1.AdsNcServer; }
			set { tcChannelStatus1.AdsNcServer = value; }
		}

		/// <summary>
		/// Gets or sets the Ads server reference.
		/// </summary>
		/// <value>The reference of the Ads server.</value>
		[Description("Gets or sets the Ads server reference."), Category("TcApp")]
		public Beckhoff.Forms.TcAdsPlcServer AdsPlcServer
		{
			get { return tcSystemState1.AdsPlcServer; }
			set { tcSystemState1.AdsPlcServer = value; }
		}

		/// <summary>
		/// Gets or sets the user administration.
		/// </summary>
		/// <value>The reference of the user administration.</value>
		[Description("Gets or sets the user administration."), Category("TcApp")]
		public Beckhoff.App.Security.TcUserAdmin UserAdmin
		{
			get { return userAdmin; }
			set { userAdmin = value; }
		}

		/// <summary>
		/// Gets or sets the backcolor of the caption.
		/// </summary>
		/// <value>The backcolor of the caption.</value>
		[Description("Gets or sets the backcolor of the caption."), Category("TcApp")]
		public Color CaptionBackColor
		{
			get
			{
				return colorCaption;
			}
			set
			{
				colorCaption = value;
				tcSystemState1.BackColor = colorCaption;
				tcChannelStatus1.BackColor = colorCaption;
				labelChannelNr.BackColor = colorCaption;
				panel2.BackColor = colorCaption;
			}
		}

		/// <summary>
		/// Gets or sets the color of the second row.
		/// </summary>
		/// <value>The color of the second row.</value>
		[Description("The color of the second row."), Category("TcApp")]
		public Color ColorRow2
		{
			get
			{
				return colorRow2;
			}
			set
			{
				colorRow2 = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the third row.
		/// </summary>
		/// <value>The color of the third row.</value>
		[Description("Gets or sets the color of the third row."), Category("TcApp")]
		public Color ColorRow3
		{
			get
			{
				return colorRow3;
			}
			set
			{
				colorRow3 = value;
			}
		}

		/// <summary>
		/// Gets or sets the company image file.
		/// </summary>
		/// <value>The company image file.</value>
		[Description("Gets or sets the company image file."), Category("TcApp")]
		public string CompanyImageFile
		{
			get
			{
				return imageFileName;
			}
			set
			{
				try
				{
					imageFileName = value;
					if (string.IsNullOrEmpty(imageFileName))
						return;

					if (System.IO.File.Exists(imageFileName))
						picBoxCompanyName.Image = Image.FromFile(imageFileName);
					else
						MainApp.log.Error("Company image file could not be found! " + imageFileName);
				}
				catch (Exception ex)
				{
					MainApp.log.Error("Company image file could not be found!", ex);
				}
			}
		}

		/// <summary>
		/// Gets or sets the label message info.
		/// </summary>
		/// <value>The label message info.</value>
		[Description("Gets or sets the label message info."), Category("TcApp")]
		public Label LabelMessageInfo
		{
			get { return labelMessageInfo; }
			set { labelMessageInfo = value; }
		}

		/// <summary>
		/// Gets or sets the EventLogLine.
		/// </summary>
		/// <value>The EventLogLine.</value>
		[Description("Gets or sets the EventLogLine."), Category("TcApp")]
		public Beckhoff.EventLogger.TcEventLogLine EventLogLine
		{
			get { return tcEventLoggerLine1; }
			set { tcEventLoggerLine1 = value; }
		}

		/// <summary>
		/// Gets or sets the number of the selected CNC channel.
		/// </summary>
		/// <value>The cnc channel number.</value>
		[Description("Gets or sets the number of the selected CNC channel."), Category("TcApp")]
		public int ChannelNr
		{
			get
			{
				return selectedChannelNr;
			}
			set
			{
				selectedChannelNr = value;
				tcChannelStatus1.ChannelNumber = selectedChannelNr;
				labelChannelNr.Text = channelText + " " + selectedChannelNr.ToString(); ;
			}
		}

		/// <summary>
		/// Gets or sets the text of the channel label.
		/// </summary>
		/// <value>The company image file.</value>
		[Description("Gets or sets the text of the channel label."), Category("TcApp")]
		public string LabelChannelText
		{
			get
			{
				return channelText;
			}
			set
			{
				channelText = value;
				labelChannelNr.Text = channelText + " " + selectedChannelNr.ToString(); ;
			}
		}

		/// <summary>
		/// Gets or sets the menu.
		/// </summary>
		/// <value>The menu structure.</value>
		[Description("Gets or sets the menu."), Category("TcApp")]
		public TcMenu Menu
		{
			get { return menu; }
			set { menu = value; }
		}

		#endregion

		#endregion

		#region Events

		private void tcEventLoggerLine1_DoubleClick(object sender, EventArgs e)
		{
			if (menu != null)
			{
				if (menu != null && menu.FormExists("FormMessages"))
					menu.ShowForm("FormMessages");

				/*
				string formName = menu.FindFormName(Type.GetType("TcApplication.FormMessages"));
				if (formName.Length != 0)
					menu.ShowForm(formName);
				*/
			}
		}

		private void picBoxCompanyName_DoubleClick(object sender, EventArgs e)
		{
			FormSystemInfo formInfo = new FormSystemInfo();
			formInfo.ShowDialog();
		}

		#endregion

		#region Private

		private void timerDateTime_Tick(object sender, EventArgs e)
		{
			labelDate.Text = DateTime.Now.ToShortDateString();
			labelTime.Text = DateTime.Now.ToString("T");
		}

		#endregion

	}
}
