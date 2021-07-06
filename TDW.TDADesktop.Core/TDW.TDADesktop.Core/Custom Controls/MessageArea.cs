using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms.Samples
{
	public partial class MessageArea : UserControl
	{
		public MessageArea()
		{
			InitializeComponent();
		}

		#region Event Handlers
		private void MessageArea_Load(object sender, EventArgs e)
		{
			if (null != this.Parent)
			{
				this.Parent.Padding = new Padding(0, 3, 0, 3);
			}

			// Set dock
			this.Dock = DockStyle.Fill;
		}
		#endregion
	}
}
