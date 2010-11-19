using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TcApplication
{
	public partial class OPModeMDI : UserControl
	{
		public OPModeMDI()
		{
			InitializeComponent();
		}

		#region Events

		private void OPModeMDI_Load(object sender, EventArgs e)
		{
			if (MainApp.GetDoc() != null)
			{
				TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
				Font newFont = (Font)tc.ConvertFromString(MainApp.appSettings.ncFontName);
				textBoxMDI.Font = newFont;
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the backcolor of the caption.
		/// </summary>
		/// <value>The backcolor of the caption.</value>
		[Description(""), Category("TcCnc")]
		public Color CaptionBackColor
		{
			get { return groupBox3.BackColor; }
			set { groupBox3.BackColor = value; }
		}

		/// <summary>
		/// Gets or sets the caption text of the control.
		/// </summary>
		/// <value>The Mdi caption text of the control.</value>
		[Description(""), Category("TcCnc")]
		public string Caption
		{
			get { return labelBoxMDI.Text; }
			set { labelBoxMDI.Text = value; }
		}

		/// <summary>
		/// Gets or sets the current Mdi text in the control.
		/// </summary>
		/// <value>The Mdi text displayed in the control.</value>
		[Description(""), Category("TcCnc")]
		public string MdiText
		{
			get { return textBoxMDI.Text; }
			set { textBoxMDI.Text = value; }
		}

		/// <summary>
		/// Gets the face name of this System.Drawing.Font.
		/// </summary>
		/// <value>A string representation of the face name of this System.Drawing.Font.</value>
		[Description(""), Category("TcCnc")]
		public string FontName
		{
			get { return textBoxMDI.Font.Name; }
			set
			{
				TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
				Font newFont = (Font)tc.ConvertFromString(value);
				textBoxMDI.Font = newFont;
			}
		}

		#endregion

	}
}
