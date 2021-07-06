using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net.NetworkInformation;

namespace System.Windows.Forms.Samples
{
	public partial class MainForm : Form
	{
		// Message Server
		private MessageStore		_store;
		private	Bitmap				_onlineImage;
		private Bitmap				_offlineImage;

		public MainForm()
		{
			// Use system fonts
			this.Font = SystemFonts.IconTitleFont;

			// Designer Generated Code
			InitializeComponent();
		}

		#region Event Handlers
		private void Form1_Load(object sender, EventArgs e)
		{
			// Setup Message Server
			_store = MessageStore.GetMessageStore();

			// Update message count
			this.itemCountLabel.Text = String.Format(this.itemCountLabel.Text, _store.Messages.Count);

			// Setup Online/Offline
			_onlineImage = Properties.Resources.Outlook;
			_offlineImage = Properties.Resources.Error;

			// Check for Network Changes
			NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);

			// Set Status Bar
			UpdateStatusBar();

			// Set icon
			this.Icon = Icon.FromHandle(Properties.Resources.Outlook.GetHicon());

			// Track Preference Changes
			Microsoft.Win32.SystemEvents.UserPreferenceChanged += new Microsoft.Win32.UserPreferenceChangedEventHandler(Form1_UserPreferenceChanged);
		}

		private void Form1_UserPreferenceChanged(object sender, Microsoft.Win32.UserPreferenceChangedEventArgs e)
		{
			if (this.Font != SystemFonts.IconTitleFont)
			{
				// Only respond at RT
				this.Font = SystemFonts.IconTitleFont;
				this.PerformAutoScale();
			}
		}
		#endregion

		#region Online Handling
		private void UpdateStatusBar()
		{
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				this.connectedStatusLabel.Text = "All Folders are up to date.";
				this.connectedImageLabel.Text = " Connected";
				this.connectedImageLabel.Image = _onlineImage;
			}
			else
			{
				this.connectedStatusLabel.Text = "This folder was last updated on " + DateTime.Now.ToShortDateString() + ".";
				this.connectedImageLabel.Text = " Disconnected";
				this.connectedImageLabel.Image = _offlineImage;
			}
		}

		void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
		{
			this.Invoke(new MethodInvoker(this.UpdateStatusBar));
		}
        #endregion

        private void leftSpine1_Load(object sender, EventArgs e)
        {

        }

        private void newTDAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			MessageBox.Show("Hello", "newTDAToolStripMenuItem1_Click");

		}
    }
}