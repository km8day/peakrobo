using System;
using System.Drawing;
using System.Windows.Forms;

namespace TcApplication
{
	/// <summary>
	/// Summary description for OperationModeWindow.
	/// </summary>
	public class OperationModeWindow
	{
		Timer timer1;
		Point point_FKey;
		int endPoint_Y;
		int direction;
		int wndHeight;
		Beckhoff.App.TcFKey fKey;

		public OperationModeWindow()
		{
			point_FKey = new System.Drawing.Point();
			timer1 = new Timer();
			timer1.Interval = 5;
			timer1.Tick += new System.EventHandler(this.timer1_Tick);
		}

		public void Open(int frmHeight, Beckhoff.App.TcFKey tcFKey)
		{
			point_FKey.X = 3 * MainApp.GetDoc().tcFKey1.FKeyButtonObj(1).Width;
			point_FKey.Y = frmHeight;
			direction = 1;
			endPoint_Y = point_FKey.Y - tcFKey.Height - 0;
			tcFKey.Location = point_FKey;
			tcFKey.Visible = true;
			tcFKey.BringToFront();
			wndHeight = frmHeight;
			fKey = tcFKey;
			timer1.Enabled = true;
		}

		public void Close(int wait)
		{
			if (wait == 0)
				endPoint_Y = 60;	// don't wait
			else
				endPoint_Y = 0;
			direction = 0;
			timer1.Enabled = true;
		}

		/// <summary>
		/// Gets the direction.
		/// </summary>
		/// <value>The direction.</value>
		public int Direction
		{
			get { return direction; }
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			// wait
			if (direction == 0)
			{
				endPoint_Y += 1;
				if (endPoint_Y > 50)
				{
					endPoint_Y = wndHeight;
					direction = 2;
				}
			}

			// out
			if (direction == 1)
			{
				point_FKey.Y -= (point_FKey.Y - endPoint_Y) / 10 + 2;
				fKey.Location = point_FKey;
				if (point_FKey.Y < endPoint_Y)
				{
					timer1.Enabled = false;
					fKey.Focus();
				}
			}

			// in
			if (direction == 2)
			{
				point_FKey.Y += (endPoint_Y - point_FKey.Y) / 10 + 2;
				fKey.Location = point_FKey;
				if (point_FKey.Y > endPoint_Y)
				{
					timer1.Enabled = false;
					fKey.Visible = false;
				}
			}
		}

	}
}
