using System;
using System.Drawing;
using System.Windows.Forms;
using Beckhoff.Forms;
using Beckhoff.Forms.Nc;
using Beckhoff.EventLogger;

/// <summary>
/// Interface-Definition for the application header.
/// </summary>
public interface IAppHeader
{
	/// <summary>
	/// Gets or sets the Ads Plcserver.
	/// </summary>
	/// <value>The Ads Plc server.</value>
	TcAdsPlcServer AdsPlcServer { get; set; }

	/// <summary>
	/// Gets or sets the Ads Nc server.
	/// </summary>
	/// <value>The Ads Nc server.</value>
	TcAdsNcServer AdsNcServer { get; set; }

	/// <summary>
	/// Gets or sets the user administration.
	/// </summary>
	/// <value>The user administration.</value>
	Beckhoff.App.Security.TcUserAdmin UserAdmin { get; set; }

	/// <summary>
	/// Gets or sets the channel nr.
	/// </summary>
	/// <value>The channel nr.</value>
	int ChannelNr { get; set; }

	/// <summary>
	/// Gets or sets the label channel text.
	/// </summary>
	/// <value>The label channel text.</value>
	string LabelChannelText { get; set; }

	/// <summary>
	/// Gets or sets the backcolor of the caption.
	/// </summary>
	/// <value>The color of the caption back.</value>
	Color CaptionBackColor { get; set; }

	/// <summary>
	/// Gets or sets the color row2.
	/// </summary>
	/// <value>The color row2.</value>
	Color ColorRow2 { get; set; }

	/// <summary>
	/// Gets or sets the color row3.
	/// </summary>
	/// <value>The color row3.</value>
	Color ColorRow3 { get; set; }

	/// <summary>
	/// Gets or sets the company image file.
	/// </summary>
	/// <value>The company image file.</value>
	string CompanyImageFile { get; set; }

	/// <summary>
	/// Gets or sets the label message info.
	/// </summary>
	/// <value>The label message info.</value>
	Label LabelMessageInfo { get; set; }

	/// <summary>
	/// Gets or sets the EventLogLine.
	/// </summary>
	/// <value>The reference of the EventLogLine.</value>
	TcEventLogLine EventLogLine { get; set; }

	/// <summary>
	/// Gets or sets the menu.
	/// </summary>
	/// <value>Gets or sets the menu.</value>
	Beckhoff.App.TcMenu.TcMenu Menu { get; set; }
}
