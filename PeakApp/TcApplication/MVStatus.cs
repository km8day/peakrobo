using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TcApplication
{
	public partial class MVStatus : UserControl
	{
		#region Private Instance Fields

		private Label[] labelValue;
		private int maxFields = 0;

		#endregion

		#region Public Instance Constructors

		public MVStatus()
		{
			InitializeComponent();
		}

		#endregion

		#region Public Instance Fields

		public void Value(int field, string valueString)
		{
			if (0 <= field && field < maxFields)
			{
				labelValue[field].Text = valueString;
			}
		}

		public void ValueBackColor(int field, Color backColor)
		{
			if (0 <= field && field < maxFields)
			{
				labelValue[field].BackColor = backColor;
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the caption.
		/// </summary>
		/// <value>The caption.</value>
		[Description("The caption of MVBox"), Category("MViewBox")]
		public string Caption
		{
			get { return labelCaption.Text; }
			set { labelCaption.Text = value; }
		}

		/// <summary>
		/// Gets or sets the number of fields..
		/// </summary>
		/// <value>The caption.</value>
		[Description("The number of fields."), Category("MViewBox")]
		public int Fields
		{
			get { return maxFields; }
			set
			{
				if (maxFields != value)
				{
					maxFields = value;
					Init();
				}
			}
		}

		/// <summary>
		/// Gets or sets the text align.
		/// </summary>
		/// <value>The text align.</value>
		[Description("Gets or sets the text align."), Category("MViewBox")]
		public ContentAlignment TextAlign
		{
			get { return labelCaption.TextAlign; }
			set
			{
				if (labelCaption.TextAlign != value)
				{
					labelCaption.TextAlign = value;
					for (int i = 0; i < maxFields; i++)
					{
						if (labelValue != null)
							labelValue[i].TextAlign = value;
					}
				}
			}
		}

		#endregion

		#region Private Functions

		private void Init()
		{
			SuspendLayout();

			if (labelValue != null)
			{
				for (int i = 0; i < labelValue.GetLength(0); i++)
					this.Controls.Remove(labelValue[i]);
			}

			labelValue = null;
			labelValue = new Label[maxFields];

			for (int i = 0; i < maxFields; i++)
			{
				labelValue[i] = new Label();
				labelValue[i].Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
				labelValue[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
				labelValue[i].Location = new System.Drawing.Point(0, (i+1) * 16);
				labelValue[i].Name = "";
				labelValue[i].Size = new System.Drawing.Size(Width, 16);
				labelValue[i].TabIndex = 8;
				labelValue[i].Text = "";
				labelValue[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				this.Controls.Add(labelValue[i]);
			}
			ResumeLayout(false);
		}

		#endregion

	}
}
