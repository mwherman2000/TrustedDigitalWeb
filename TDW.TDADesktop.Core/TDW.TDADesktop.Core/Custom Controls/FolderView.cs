#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Data;
using System.Text;
using System.Windows.Forms;

#endregion

namespace TDW.TDADesktop
{
	public class FolderView : System.Windows.Forms.UserControl
	{
		private ImageList	folderImages;
		private TreeView	subledgersTreeView;
		private IContainer	components;

		private	Font		_font;
		private	Font		_boldFont;

		MessageStore		_store = null;
		private int			_deletedCount;
		private int			_unreadCount;
		private int			_draftsCount;

		public FolderView()
		{
			// Set the Font
			SetFont();

			// Initialize
			InitializeComponent();

			// Set Node Fonts
			SetNodeFonts(this.subledgersTreeView.Nodes);

			// Set dock to top
			this.Dock = DockStyle.Fill;

			// Attach to the MessageStore
			_store = MessageStore.GetMessageStore();

			this._unreadCount = _store.UnreadCount;
			this._draftsCount = _store.DraftsCount;
			this._deletedCount = _store.DeletedCount;

			// Check for changes
			_store.PropertyChanged += new PropertyChangedEventHandler(MessageStore_PropertyChanged);
		}

		#region Designer Code
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderView));
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Deleted Items");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Drafts");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Customers");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Everett");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Internal");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Whidbey");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Inbox", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Junk E-mail");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Outbox");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Sent Items");
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Dummy");
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Sync Issues", new System.Windows.Forms.TreeNode[] {
            treeNode11});
			System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Synchronization Failures");
			System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Root Folder");
			System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Search Folders", new System.Windows.Forms.TreeNode[] {
            treeNode14});
			System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Erin Anderson 1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode12,
            treeNode13,
            treeNode15});
			System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Empty");
			System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Archive Folders", new System.Windows.Forms.TreeNode[] {
            treeNode17});
			this.folderImages = new System.Windows.Forms.ImageList(this.components);
			this.subledgersTreeView = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// folderImages
			// 
			this.folderImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("folderImages.ImageStream")));
			this.folderImages.Images.SetKeyName(0, "Task.bmp");
			this.folderImages.Images.SetKeyName(1, "Address.bmp");
			this.folderImages.Images.SetKeyName(2, "Archive.bmp");
			this.folderImages.Images.SetKeyName(3, "Delete.bmp");
			this.folderImages.Images.SetKeyName(4, "Drafts.bmp");
			this.folderImages.Images.SetKeyName(5, "Error.bmp");
			this.folderImages.Images.SetKeyName(6, "Find.bmp");
			this.folderImages.Images.SetKeyName(7, "Folder.bmp");
			this.folderImages.Images.SetKeyName(8, "Forward.bmp");
			this.folderImages.Images.SetKeyName(9, "Help.bmp");
			this.folderImages.Images.SetKeyName(10, "Inbox.bmp");
			this.folderImages.Images.SetKeyName(11, "Junk.bmp");
			this.folderImages.Images.SetKeyName(12, "Move.bmp");
			this.folderImages.Images.SetKeyName(13, "New.bmp");
			this.folderImages.Images.SetKeyName(14, "Notes.bmp");
			this.folderImages.Images.SetKeyName(15, "Outbox.bmp");
			this.folderImages.Images.SetKeyName(16, "Outlook.bmp");
			this.folderImages.Images.SetKeyName(17, "Post.bmp");
			this.folderImages.Images.SetKeyName(18, "Print.bmp");
			this.folderImages.Images.SetKeyName(19, "Read.bmp");
			this.folderImages.Images.SetKeyName(20, "Send.bmp");
			this.folderImages.Images.SetKeyName(21, "Sent.bmp");
			this.folderImages.Images.SetKeyName(22, "OutlookToday.bmp");
			this.folderImages.Images.SetKeyName(23, "Recycle.bmp");
			this.folderImages.Images.SetKeyName(24, "Search.bmp");
			// 
			// subledgersTreeView
			// 
			this.subledgersTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.subledgersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.subledgersTreeView.HideSelection = false;
			this.subledgersTreeView.ImageIndex = 0;
			this.subledgersTreeView.ImageList = this.folderImages;
			this.subledgersTreeView.Location = new System.Drawing.Point(0, 4);
			this.subledgersTreeView.Name = "subledgersTreeView";
			treeNode1.ImageKey = "Recycle.bmp";
			treeNode1.Name = "Node1";
			treeNode1.SelectedImageKey = "Recycle.bmp";
			treeNode1.Tag = "Bold";
			treeNode1.Text = "Deleted Items";
			treeNode2.ImageKey = "Drafts.bmp";
			treeNode2.Name = "Node2";
			treeNode2.SelectedImageKey = "Drafts.bmp";
			treeNode2.Tag = "Bold";
			treeNode2.Text = "Drafts";
			treeNode3.ImageKey = "Folder.bmp";
			treeNode3.Name = "Node10";
			treeNode3.SelectedImageKey = "Folder.bmp";
			treeNode3.Text = "Customers";
			treeNode4.ImageKey = "Folder.bmp";
			treeNode4.Name = "Node11";
			treeNode4.SelectedImageKey = "Folder.bmp";
			treeNode4.Text = "Everett";
			treeNode5.ImageKey = "Folder.bmp";
			treeNode5.Name = "Node12";
			treeNode5.SelectedImageKey = "Folder.bmp";
			treeNode5.Text = "Internal";
			treeNode6.ImageKey = "Folder.bmp";
			treeNode6.Name = "Node13";
			treeNode6.SelectedImageKey = "Folder.bmp";
			treeNode6.Text = "Whidbey";
			treeNode7.ImageKey = "Inbox.bmp";
			treeNode7.Name = "Node3";
			treeNode7.SelectedImageKey = "Inbox.bmp";
			treeNode7.Tag = "Bold";
			treeNode7.Text = "Inbox";
			treeNode8.ImageKey = "Junk.bmp";
			treeNode8.Name = "Node4";
			treeNode8.SelectedImageKey = "Junk.bmp";
			treeNode8.Text = "Junk E-mail";
			treeNode9.ImageKey = "Outbox.bmp";
			treeNode9.Name = "Node5";
			treeNode9.SelectedImageKey = "Outbox.bmp";
			treeNode9.Text = "Outbox";
			treeNode10.ImageKey = "Sent.bmp";
			treeNode10.Name = "Node6";
			treeNode10.SelectedImageKey = "Sent.bmp";
			treeNode10.Text = "Sent Items";
			treeNode11.ImageKey = "Folder.bmp";
			treeNode11.Name = "Node14";
			treeNode11.SelectedImageKey = "Folder.bmp";
			treeNode11.Text = "Dummy";
			treeNode12.ImageKey = "Folder.bmp";
			treeNode12.Name = "Node7";
			treeNode12.SelectedImageKey = "Folder.bmp";
			treeNode12.Text = "Sync Issues";
			treeNode13.ImageKey = "Forward.bmp";
			treeNode13.Name = "Node8";
			treeNode13.SelectedImageKey = "Forward.bmp";
			treeNode13.Text = "Synchronization Failures";
			treeNode14.ImageKey = "Folder.bmp";
			treeNode14.Name = "Node15";
			treeNode14.Text = "Root Folder";
			treeNode15.ImageKey = "Search.bmp";
			treeNode15.Name = "Node9";
			treeNode15.SelectedImageKey = "Search.bmp";
			treeNode15.Text = "Search Folders";
			treeNode16.ImageKey = "OutlookToday.bmp";
			treeNode16.Name = "Node0";
			treeNode16.SelectedImageKey = "OutlookToday.bmp";
			treeNode16.Text = "Erin Anderson 2";
			treeNode17.ImageKey = "Folder.bmp";
			treeNode17.Name = "Node17";
			treeNode17.SelectedImageKey = "Folder.bmp";
			treeNode17.Text = "Empty";
			treeNode18.ImageKey = "Archive.bmp";
			treeNode18.Name = "Node16";
			treeNode18.SelectedImageKey = "Archive.bmp";
			treeNode18.Text = "Archive Folders";
			this.subledgersTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode18});
			this.subledgersTreeView.SelectedImageIndex = 0;
			this.subledgersTreeView.Size = new System.Drawing.Size(281, 274);
			this.subledgersTreeView.TabIndex = 0;
			this.subledgersTreeView.TabStop = false;
			this.subledgersTreeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.subledgersTreeView_DrawNode);
			// 
			// FolderView
			// 
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.subledgersTreeView);
			this.Name = "FolderView";
			this.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.Size = new System.Drawing.Size(281, 278);
			this.Load += new System.EventHandler(this.FolderView_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		int UnreadCount
		{
			get { return _unreadCount; }
			set
			{
				if (value != _unreadCount)
				{
					_unreadCount = value;
					this.subledgersTreeView.Invalidate();
				}
			}
		}

		int DraftsCount
		{
			get { return _draftsCount; }
			set
			{
				if (value != _draftsCount)
				{
					_draftsCount = value;
					this.subledgersTreeView.Invalidate();
				}
			}
		}

		int DeletedCount
		{
			get { return _deletedCount; }
			set
			{
				if (value != _deletedCount)
				{
					_deletedCount = value;
					this.subledgersTreeView.Invalidate();
				}
			}
		}

        public TreeView SubledgersTreeView { get => subledgersTreeView; }
        #endregion

        #region TreeView Drawing
        private void DrawAnnotatedText(DrawTreeNodeEventArgs e, int count, Color exColor, string left, string right)
		{
			// Setup
			Font	font = ((0 == count) ? this._font : this._boldFont);
			Color	foreColor = (((e.Node.IsSelected) && (e.Node.TreeView.Focused)) ? SystemColors.HighlightText : e.Node.ForeColor);

			// Draw Text
			TextRenderer.DrawText(e.Graphics, e.Node.Text, font, new Point(e.Bounds.X, e.Bounds.Y), foreColor);

			// Draw count in regular font
			if (0 != count)
			{
				string exText = left + count.ToString() + right;
				int width = TextRenderer.MeasureText((e.Node.Text + "  "), font).Width;

				TextRenderer.DrawText(e.Graphics, exText, _font, new Point(e.Bounds.X + width, e.Bounds.Y), exColor);
			}
		}

		private void subledgersTreeView_DrawNode(object sender, System.Windows.Forms.DrawTreeNodeEventArgs e)
		{
			// Draw default by default
			e.DrawDefault = true;
			if (e.Node.Text.Contains("Deleted"))
			{
				// Draw Deleted
				DrawAnnotatedText(e, this.DeletedCount, Color.Blue, "(", ")");

				// Turn off drawing
				e.DrawDefault = false;
			}
			else if (e.Node.Text.Contains("Inbox"))
			{
				// Draw Inbox
				DrawAnnotatedText(e, this.UnreadCount, Color.Green, "[", "]");

				// Turn off drawing
				e.DrawDefault = false;
			}
			else if (e.Node.Text.Contains("Drafts"))
			{
				// Draw Drafts
				DrawAnnotatedText(e, this.DraftsCount, Color.Blue, "(", ")");

				// Turn off drawing
				e.DrawDefault = false;
			}
		}

		private void SetFont()
		{
			_font = SystemFonts.IconTitleFont;
			_boldFont = new Font(_font, FontStyle.Bold);

			this.Font = _boldFont;
		}

		private void SetNodeFonts(TreeNodeCollection nodes)
		{
			this.subledgersTreeView.Font = _boldFont;

			foreach (TreeNode node in nodes)
			{
				if (!(node.Tag is string) || ((node.Tag as string) != "Bold"))
				{
					// Set Node font
					node.NodeFont = _font;
				}

				// Set child fonts
				if (null != node.Nodes)
				{
					SetNodeFonts(node.Nodes);
				}
			}
		}
		#endregion

		#region Event Handlers
		private void FolderView_Load(object sender, EventArgs e)
		{
			// Set Owner Draw Mode to Text
			if ((null == this.Site) || (!this.Site.DesignMode))
			{
				this.subledgersTreeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
			}

			// Set Selected Item
			foreach (TreeNode node in this.subledgersTreeView.Nodes[0].Nodes)
			{
				if (node.Text.Contains("Inbox"))
				{
					this.subledgersTreeView.SelectedNode = node;
					node.Expand();
					break;
				}
			}
		}

		void MessageStore_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "UnreadCount")
			{
				this.UnreadCount = _store.UnreadCount;
			}
			else if (e.PropertyName == "DraftsCount")
			{
				this.DraftsCount = _store.DraftsCount;
			}
			else if (e.PropertyName == "DeletedCount")
			{
				this.DeletedCount = _store.DeletedCount;
			}
		}
		#endregion
	}
}
