#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

#endregion

namespace System.Windows.Forms.Samples
{
	public class MessageList : System.Windows.Forms.UserControl
	{
		private Bitmap			_readImage;
		private Bitmap			_unreadImage;
		private MessageStore	_store;
		private	Font			_font;

		private IContainer components;
		private DataGridViewImageColumn dataGridViewImageColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private BindingSource messageBS;
		private DataGridView dataGridView1;

		public MessageList()
		{
			// Initialize UI
			InitializeComponent();
		}

		#region Event Handlers
		private void MessageList_Load(object sender, EventArgs e)
		{
			// Auto dock fill
			this.Dock = DockStyle.Fill;

			// Get images
			_readImage = Properties.Resources.Read;
			_readImage.MakeTransparent(Color.FromArgb(238, 238, 238));
			_unreadImage = Properties.Resources.Unread;

			// Attach to Message Store
			_store = MessageStore.GetMessageStore();

			// Reset DataSource
			this.messageBS.DataSource = _store.Messages;

			// Sort
			this.dataGridView1.DataSource = this.messageBS;
			this.dataGridView1.Sort(this.dataGridView1.Columns[2], ListSortDirection.Descending);

			// Set font
			SetFont();

			// Add UPChanged
			SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
		}

		void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
		{
			// Reset the font (if required)
			SetFont();
		}

		private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			// Set the Sent Column
			if (e.ColumnIndex == 0)
			{
				// Get Image
				e.Value = ((this.messageBS[e.RowIndex] as MailMessage).Read ? _readImage : _unreadImage);
			}
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			// Format the Date Column
			if (e.ColumnIndex == 2)
			{
				DateTime date = (DateTime)e.Value;
				DateTime today = DateTime.Now;

				if ((date.Day == today.Day) && (date.Month == today.Month) && (date.Year == today.Year))
				{
					e.CellStyle.Format = "t";
				}
			}
		}

		private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if ((e.ColumnIndex == 1) && (e.RowIndex >= 0))
			{
				// Draw Merged Cell
				Graphics g = e.Graphics;
				bool selected = ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected);
				Color fcolor = (selected ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor);
				Color bcolor = (selected ? e.CellStyle.SelectionBackColor : e.CellStyle.BackColor);
				Font font = e.CellStyle.Font;

				if (!(this.messageBS[e.RowIndex] as MailMessage).Read)
				{
					font = new Font(font, FontStyle.Bold);
				}

				// Get size information
				string from = (this.messageBS[e.RowIndex] as MailMessage).From;
				string subject = (this.messageBS[e.RowIndex] as MailMessage).Subject;
				Size size = TextRenderer.MeasureText(e.Graphics, from, font);

				// Note that this always aligns top, right
				// Also this should use the ClipBounds but that is not currently working
				int x = e.CellBounds.Left + e.CellStyle.Padding.Left;
				int y = e.CellBounds.Top + e.CellStyle.Padding.Top;
				int width = e.CellBounds.Width - (e.CellStyle.Padding.Left + e.CellStyle.Padding.Right);
				int height = size.Height + (e.CellStyle.Padding.Top + e.CellStyle.Padding.Bottom);

				// Draw background
				g.FillRectangle(new SolidBrush(bcolor), e.CellBounds);

				// Draw first line
				TextRenderer.DrawText(e.Graphics, from, font, new Rectangle(x, y, width, height), fcolor, TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.EndEllipsis);

				// Use grey for second line if not selected
				if (!selected)
				{
					fcolor = Color.Gray;
				}

				// Reset font and y location
				font = e.CellStyle.Font;
				y = y + height - 1;

				TextRenderer.DrawText(e.Graphics, subject, font, new Rectangle(x, y, width, height), fcolor, TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.EndEllipsis);

				// Let them know we handled it
				e.Handled = true;
			}
			else if ((e.ColumnIndex == 0) && (e.RowIndex >= 0))
			{
				e.Paint(e.ClipBounds, e.PaintParts & ~DataGridViewPaintParts.Focus);
				e.Handled = true;
			}
		}

		private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			if (e.RowIndex == this.messageBS.Position)
			{
				e.DrawFocus(e.RowBounds, true);
			}
			else
			{
				// Draw background
				Pen p;
				using (p = new Pen(Color.LightGray))
				{
					e.Graphics.DrawRectangle(p, e.RowBounds);
				}
			}
		}

		private void messageBS_PositionChanged(object sender, EventArgs e)
		{
			// Let the message store know
			_store.SelectedMessage = this.messageBS.Current as MailMessage;
		}
		#endregion

		#region Public Properties
		public int SelectedRow
		{
			set
			{
				this.dataGridView1.Rows[value].Selected = true;
			}
		}
		#endregion

		#region Private Implementation
		private void SetFont()
		{
			// Set the font
			_font = SystemFonts.IconTitleFont;

			if (this.Font != _font)
			{
				// Set font
				this.Font = _font;

				// Set default row height
				this.dataGridView1.RowTemplate.Height = (TextRenderer.MeasureText("I", _font).Height + 5) * 2;
				Debug.WriteLine(this.dataGridView1.RowTemplate.Height.ToString());
			}
		}
		#endregion

		#region Designer Code
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.messageBS = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.messageBS)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.Columns.Add(this.dataGridViewImageColumn2);
			this.dataGridView1.Columns.Add(this.dataGridViewTextBoxColumn3);
			this.dataGridView1.Columns.Add(this.dataGridViewTextBoxColumn4);
			this.dataGridView1.DataSource = this.messageBS;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("en-US");
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(385, 274);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.VirtualMode = true;
			this.dataGridView1.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValueNeeded);
			this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
			this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
			this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
			// 
			// dataGridViewImageColumn2
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("en-US");
			dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4, 4, 2, 2);
			this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewImageColumn2.HeaderText = "";
			this.dataGridViewImageColumn2.Name = "SentColumn";
			this.dataGridViewImageColumn2.ReadOnly = true;
			this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn2.Width = 25;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "To";
			dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("en-US");
			dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewTextBoxColumn3.HeaderText = "Arranged By: Date";
			this.dataGridViewTextBoxColumn3.Name = "To";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "SentDate";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
			dataGridViewCellStyle4.Format = "ddd M/dd";
			dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("en-US");
			dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
			this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewTextBoxColumn4.HeaderText = "Newest on top";
			this.dataGridViewTextBoxColumn4.Name = "SentDate";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn4.Width = 105;
			// 
			// messageBS
			// 
            this.messageBS.DataSource = typeof(System.Windows.Forms.Samples.MailMessage);
			this.messageBS.PositionChanged += new System.EventHandler(this.messageBS_PositionChanged);
			// 
			// MessageList
			// 
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.dataGridView1);
			this.Name = "MessageList";
			this.Size = new System.Drawing.Size(385, 274);
			this.Load += new System.EventHandler(this.MessageList_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.messageBS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
