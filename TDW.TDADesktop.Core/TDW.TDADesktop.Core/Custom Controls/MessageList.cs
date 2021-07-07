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

namespace TDW.TDADesktop
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
		private BindingSource messageListBindingSource;
		private DataGridView messageListDataGridView;

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
			this.messageListBindingSource.DataSource = _store.Messages;

			// Sort
			this.messageListDataGridView.DataSource = this.messageListBindingSource;
			this.messageListDataGridView.Sort(this.messageListDataGridView.Columns[2], ListSortDirection.Descending);

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

		private void messageListDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			// Set the Sent Column
			if (e.ColumnIndex == 0)
			{
				// Get Image
				e.Value = ((this.messageListBindingSource[e.RowIndex] as MailMessage).Read ? _readImage : _unreadImage);
			}
		}

		private void messageListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

		private void messageListDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if ((e.ColumnIndex == 1) && (e.RowIndex >= 0))
			{
				// Draw Merged Cell
				Graphics g = e.Graphics;
				bool selected = ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected);
				Color fcolor = (selected ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor);
				Color bcolor = (selected ? e.CellStyle.SelectionBackColor : e.CellStyle.BackColor);
				Font font = e.CellStyle.Font;

				if (!(this.messageListBindingSource[e.RowIndex] as MailMessage).Read)
				{
					font = new Font(font, FontStyle.Bold);
				}

				// Get size information
				string from = (this.messageListBindingSource[e.RowIndex] as MailMessage).From;
				string subject = (this.messageListBindingSource[e.RowIndex] as MailMessage).Subject;
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

		private void messageListDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			if (e.RowIndex == this.messageListBindingSource.Position)
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

		private void messageListBindingSource_PositionChanged(object sender, EventArgs e)
		{
			// Let the message store know
			_store.SelectedMessage = this.messageListBindingSource.Current as MailMessage;
		}
		#endregion

		#region Public Properties
		public int SelectedRow
		{
			set
			{
				this.messageListDataGridView.Rows[value].Selected = true;
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
				this.messageListDataGridView.RowTemplate.Height = (TextRenderer.MeasureText("I", _font).Height + 5) * 2;
				Debug.WriteLine(this.messageListDataGridView.RowTemplate.Height.ToString());
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
			this.messageListDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.messageListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.messageListDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.messageListBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// messageListDataGridView
			// 
			this.messageListDataGridView.AllowUserToAddRows = false;
			this.messageListDataGridView.AllowUserToDeleteRows = false;
			this.messageListDataGridView.AllowUserToResizeRows = false;
			this.messageListDataGridView.AutoGenerateColumns = false;
			this.messageListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.messageListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.messageListDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.messageListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.messageListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.messageListDataGridView.Columns.Add(this.dataGridViewImageColumn2);
			this.messageListDataGridView.Columns.Add(this.dataGridViewTextBoxColumn3);
			this.messageListDataGridView.Columns.Add(this.dataGridViewTextBoxColumn4);
			this.messageListDataGridView.DataSource = this.messageListBindingSource;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("en-US");
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.messageListDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
			this.messageListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messageListDataGridView.EnableHeadersVisualStyles = false;
			this.messageListDataGridView.Location = new System.Drawing.Point(0, 0);
			this.messageListDataGridView.Margin = new System.Windows.Forms.Padding(0);
			this.messageListDataGridView.Name = "messageListDataGridView";
			this.messageListDataGridView.ReadOnly = true;
			this.messageListDataGridView.RowHeadersVisible = false;
			this.messageListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.messageListDataGridView.Size = new System.Drawing.Size(385, 274);
			this.messageListDataGridView.TabIndex = 0;
			this.messageListDataGridView.VirtualMode = true;
			this.messageListDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.messageListDataGridView_CellValueNeeded);
			this.messageListDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.messageListDataGridView_CellPainting);
			this.messageListDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.messageListDataGridView_CellFormatting);
			this.messageListDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.messageListDataGridView_RowPostPaint);
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
			// messageListBindingSource
			// 
            this.messageListBindingSource.DataSource = typeof(TDW.TDADesktop.MailMessage);
			this.messageListBindingSource.PositionChanged += new System.EventHandler(this.messageListBindingSource_PositionChanged);
			// 
			// MessageList
			// 
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.messageListDataGridView);
			this.Name = "MessageList";
			this.Size = new System.Drawing.Size(385, 274);
			this.Load += new System.EventHandler(this.MessageList_Load);
			((System.ComponentModel.ISupportInitialize)(this.messageListDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.messageListBindingSource)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
