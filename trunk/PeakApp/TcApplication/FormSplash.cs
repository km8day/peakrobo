using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TcApplication
{
	public partial class FormSplash : Form
	{
		public FormSplash()
		{
			InitializeComponent();

			ShowPicture(Application.StartupPath + "\\Bitmap\\BeckhoffMain.jpg");
		}

		public void Parameters(string text, int left, int top, Font font, Color backColor, Color foreColor)
		{
			label1.Text = text;
			label1.Left = left;
			label1.Top = top;
			label1.Font = font;
			label1.BackColor = backColor;
			label1.ForeColor = foreColor;
		}

		void ShowPicture(string pictureFile)
		{
			// Sets up an image object to be displayed.
			try
			{
				/*
				// Stretches the image to fit the pictureBox.
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
				mainScreenBitmap = new Bitmap(pictureFile);
				pictureBox1.ClientSize = new Size(524, 374);
				pictureBox1.Image = (Image)mainScreenBitmap;
				*/

				// Stretches the image to fit the pictureBox.
				//pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
				if (System.IO.File.Exists(pictureFile))
					pictureBox1.Image = new Bitmap(pictureFile);
			}
			catch
			{
				MessageBox.Show("MainScreen Bitmap " + pictureFile + " could not be found!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

	}
}
