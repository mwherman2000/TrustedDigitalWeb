using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Windows.Forms.Design;

namespace TDW.TDADesktop
{
	[Designer(typeof(ParentControlDesigner))]
	public partial class LeftSpinePanel : UserControl
	{
		private int _visibleCount = -1;
		private int _lastCount = -1;
		private int	_maxHeight;

		#region Setup
		public LeftSpinePanel()
		{
			// Set Defaults
			this.Dock = DockStyle.Fill;
			this.TabStop = false;

			// Initialize
			InitializeComponent();
		}

		private void StackBar_Load(object sender, EventArgs e)
		{
			// Setup
			this.stackStrip.ItemHeightChanged += new EventHandler(stackStrip1_ItemHeightChanged);

			// Add Overflow items
			AddOverflowItems();

			// Set Height
			InitializeSplitter();

			// Set parent padding
			this.Parent.Padding = new Padding(3, 3, 0, 3);
		}

		private void AddOverflowItems()
		{
			ToolStripButton item;
			Color			trans = Color.FromArgb(238,238,238);
			string			name;

			// Add items to overflow
			for (int idx = this.stackStrip.ItemCount - 1; idx >= 0; idx--)
			{
				name = this.stackStrip.Items[idx].Tag as string;

				if (null != name)
				{
					item = new ToolStripButton(GetBitmapResource(name));
					item.ImageTransparentColor = trans;
					item.Alignment = ToolStripItemAlignment.Right;
					item.Name = name;

					this.overflowStrip.Items.Add(item);
				}
			}
		}

		private Bitmap GetBitmapResource(string name)
		{
			return Properties.Resources.ResourceManager.GetObject(name) as Bitmap;
		}
		#endregion

		#region Event Handlers
		private void splitContainer1_Paint(object sender, PaintEventArgs e)
		{
			ProfessionalColorTable	pct = new ProfessionalColorTable();
			Rectangle				bounds = (sender as SplitContainer).SplitterRectangle;

			int			squares;
			int			maxSquares = 9;
			int			squareSize = 4;
			int			boxSize = 2;

			// Make sure we need to do work
			if ((bounds.Width > 0) && (bounds.Height > 0))
			{
				Graphics	g = e.Graphics;

				// Setup colors from the provided renderer
				Color		begin = pct.OverflowButtonGradientMiddle;
				Color		end = pct.OverflowButtonGradientEnd;

				// Make sure we need to do work
				using (Brush b = new LinearGradientBrush(bounds, begin, end, LinearGradientMode.Vertical))
				{
					g.FillRectangle(b, bounds);
				}

				// Calculate squares
				if ((bounds.Width > squareSize) && (bounds.Height > squareSize))
				{
					squares = Math.Min((bounds.Width / squareSize), maxSquares);

					// Calculate start
					int		start = (bounds.Width - (squares * squareSize)) / 2;
					int		Y = bounds.Y  + 1;

					// Get brushes
					Brush dark = new SolidBrush(pct.GripDark);
					Brush middle = new SolidBrush(pct.ToolStripBorder);
					Brush light = new SolidBrush(pct.ToolStripDropDownBackground);

					// Draw
					for (int idx = 0; idx < squares; idx++)
					{
						// Draw grips
						g.FillRectangle(dark, start, Y, boxSize, boxSize);
						g.FillRectangle(light, start + 1, Y+1, boxSize, boxSize);
						g.FillRectangle(middle, start + 1, Y+1, 1, 1);
						start += squareSize;
					}

					dark.Dispose();
					middle.Dispose();
					light.Dispose();
				}
			}
		}

		void stackStrip1_ItemHeightChanged(object sender, EventArgs e)
		{
			InitializeSplitter();
		}

		private void stackStripSplitter_SplitterMoved(object sender, SplitterEventArgs e)
		{
			if ((_maxHeight > 0) && ((this.stackStripSplitter.Height - e.SplitY) > _maxHeight))
			{
				// Limit to max height
				this.stackStripSplitter.SplitterDistance = this.stackStripSplitter.Height - _maxHeight;

				// Set to max
				_visibleCount = this.stackStrip.ItemCount;
			}
			else if ((_visibleCount > 0) && (this.stackStrip.ItemCount > 0))
			{
				// Make sure overflow is correct
				_visibleCount = (this.stackStrip.Height / this.stackStrip.ItemHeight);

				// See if this changed
				if (_lastCount != _visibleCount)
				{
					int		count = this.overflowStrip.Items.Count;

					// Update overflow items
					for (int idx = 1; idx < count; idx++)
					{
						this.overflowStrip.Items[idx].Visible = (idx < (count - _visibleCount));
					}

					// Update last
					_lastCount = _visibleCount;
				}
			}
		}
		#endregion

		#region Private API
		private void InitializeSplitter()
		{
			// Set slider increment
			if (this.stackStrip.ItemHeight > 0)
			{
				this.stackStripSplitter.SplitterIncrement = this.stackStrip.ItemHeight;

				// Find visible count
				if (_visibleCount < 0)
				{
					_visibleCount = this.stackStrip.InitialDisplayCount;
				}

				// Setup BaseStackStrip
				this.overflowStrip.Height = this.stackStrip.ItemHeight;

				// Set splitter distance
				int min = this.stackStrip.ItemHeight + this.overflowStrip.Height;
				int distance = this.stackStripSplitter.Height - this.stackStripSplitter.SplitterWidth - ((_visibleCount * this.stackStrip.ItemHeight) + this.overflowStrip.Height);

				// Set Max
				_maxHeight = (this.stackStrip.ItemHeight * this.stackStrip.ItemCount) + this.overflowStrip.Height + this.stackStripSplitter.SplitterWidth;

				// In case it's sized too small on startup
				if (distance < 0)
				{
					distance = min;
				}

				// Set Min/Max
				this.stackStripSplitter.SplitterDistance = distance;
				this.stackStripSplitter.Panel1MinSize = min;
			}
		}
        #endregion

        private void ledgerStripButtonTroubleshooting_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonTroubleshooting.Text;
			this.ledgerStripLabel2.Text = String.Format($"{this.ledgerStripLabel1.Text} Subledgers");

		}

        private void ledgerStripButtonMasterSecrets_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonMasterSecrets.Text;
			this.ledgerStripLabel2.Text = String.Format($"{this.ledgerStripLabel1.Text} Subledgers");
		}

        private void ledgerStripButtonWallets_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonWallets.Text;
			this.ledgerStripLabel2.Text = String.Format($"{this.ledgerStripLabel1.Text} Subledgers");
		}

        private void ledgerStripButtonKeyRings_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonKeyRings.Text;
			this.ledgerStripLabel2.Text =String.Format($"{this.ledgerStripLabel1.Text} Subledgers");
		}

        private void ledgerStripButtonAuthorizations_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonAuthorizations.Text;
			this.ledgerStripLabel2.Text = String.Format($"{this.ledgerStripLabel1.Text} Subledgers");
		}

        private void ledgerStripButtonVDRUIR_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonVDRUIR.Text;
			this.ledgerStripLabel2.Text = String.Format($"{this.ledgerStripLabel1.Text} Subledgers");
		}

        private void ledgerStripButtonVDRSEPR_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonVDRSEPR.Text;
			this.ledgerStripLabel2.Text = String.Format($"{this.ledgerStripLabel1.Text} Subledgers");
		}

        private void ledgerStripButtonVDRRL_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonVDRRL.Text;
			this.ledgerStripLabel2.Text = String.Format($"{this.ledgerStripLabel1.Text} Subledgers");
		}

        private void ledgerStripButtonVDRLedgers_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonVDRLedgers.Text;
			this.ledgerStripLabel2.Text = String.Format($"{this.ledgerStripLabel1.Text} Subledgers");
		}

        private void ledgerStripButtonVDRAccounts_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonVDRAccounts.Text;
			this.ledgerStripLabel2.Text = String.Format($"{this.ledgerStripLabel1.Text} Subledgers");
		}

        private void ledgerStripButtonVDRSmartContracts_Click(object sender, EventArgs e)
        {
			this.ledgerStripLabel1.Text = this.ledgerStripButtonVDRSmartContracts.Text;
			this.ledgerStripLabel2.Text = String.Format($"{this.ledgerStripLabel1.Text} Subledgers");
		}
    }
}
