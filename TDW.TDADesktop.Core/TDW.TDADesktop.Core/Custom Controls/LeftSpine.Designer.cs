namespace TDW.TDADesktop
{
	partial class LeftSpinePanel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.stackStripSplitter = new System.Windows.Forms.SplitContainer();
            this.subledgersView = new TDW.TDADesktop.FolderView();
            this.headerStrip1 = new TDW.TDADesktop.HeaderStrip();
            this.ledgerStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.headerStrip2 = new TDW.TDADesktop.HeaderStrip();
            this.ledgerStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.stackStrip = new TDW.TDADesktop.StackStrip();
            this.ledgerStripButtonTroubleshooting = new System.Windows.Forms.ToolStripButton();
            this.ledgerStripButtonMasterSecrets = new System.Windows.Forms.ToolStripButton();
            this.ledgerStripButtonKeyRings = new System.Windows.Forms.ToolStripButton();
            this.ledgerStripButtonWallets = new System.Windows.Forms.ToolStripButton();
            this.ledgerStripButtonAuthorizations = new System.Windows.Forms.ToolStripButton();
            this.ledgerStripButtonVDRUIR = new System.Windows.Forms.ToolStripButton();
            this.ledgerStripButtonVDRSEPR = new System.Windows.Forms.ToolStripButton();
            this.ledgerStripButtonVDRRL = new System.Windows.Forms.ToolStripButton();
            this.ledgerStripButtonVDRLedgers = new System.Windows.Forms.ToolStripButton();
            this.ledgerStripButtonVDRAccounts = new System.Windows.Forms.ToolStripButton();
            this.ledgerStripButtonVDRSmartContracts = new System.Windows.Forms.ToolStripButton();
            this.overflowStrip = new TDW.TDADesktop.BaseStackStrip();
            this.ledgerStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.addorRemoveButtonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.stackStripSplitter)).BeginInit();
            this.stackStripSplitter.Panel1.SuspendLayout();
            this.stackStripSplitter.Panel2.SuspendLayout();
            this.stackStripSplitter.SuspendLayout();
            this.headerStrip1.SuspendLayout();
            this.headerStrip2.SuspendLayout();
            this.stackStrip.SuspendLayout();
            this.overflowStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackStripSplitter
            // 
            this.stackStripSplitter.BackColor = System.Drawing.Color.Transparent;
            this.stackStripSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackStripSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.stackStripSplitter.Location = new System.Drawing.Point(0, 0);
            this.stackStripSplitter.Margin = new System.Windows.Forms.Padding(4);
            this.stackStripSplitter.Name = "stackStripSplitter";
            this.stackStripSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // stackStripSplitter.Panel1
            // 
            this.stackStripSplitter.Panel1.Controls.Add(this.subledgersView);
            this.stackStripSplitter.Panel1.Controls.Add(this.headerStrip1);
            this.stackStripSplitter.Panel1.Controls.Add(this.headerStrip2);
            // 
            // stackStripSplitter.Panel2
            // 
            this.stackStripSplitter.Panel2.Controls.Add(this.stackStrip);
            this.stackStripSplitter.Panel2.Controls.Add(this.overflowStrip);
            this.stackStripSplitter.Size = new System.Drawing.Size(416, 774);
            this.stackStripSplitter.SplitterDistance = 334;
            this.stackStripSplitter.SplitterWidth = 9;
            this.stackStripSplitter.TabIndex = 0;
            this.stackStripSplitter.TabStop = false;
            this.stackStripSplitter.Text = "splitContainer1";
            this.stackStripSplitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.stackStripSplitter_SplitterMoved);
            this.stackStripSplitter.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Paint);
            // 
            // subledgersView
            // 
            this.subledgersView.BackColor = System.Drawing.SystemColors.Window;
            this.subledgersView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subledgersView.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.subledgersView.Location = new System.Drawing.Point(0, 54);
            this.subledgersView.Margin = new System.Windows.Forms.Padding(4);
            this.subledgersView.Name = "subledgersView";
            this.subledgersView.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.subledgersView.Size = new System.Drawing.Size(416, 280);
            this.subledgersView.TabIndex = 2;
            // 
            // headerStrip1
            // 
            this.headerStrip1.AutoSize = false;
            this.headerStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.headerStrip1.ForeColor = System.Drawing.Color.Black;
            this.headerStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.headerStrip1.HeaderStyle = TDW.TDADesktop.AreaHeaderStyle.Small;
            this.headerStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.headerStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ledgerStripLabel2});
            this.headerStrip1.Location = new System.Drawing.Point(0, 31);
            this.headerStrip1.Name = "headerStrip1";
            this.headerStrip1.Size = new System.Drawing.Size(416, 23);
            this.headerStrip1.TabIndex = 0;
            this.headerStrip1.Text = "headerStrip1";
            // 
            // ledgerStripLabel2
            // 
            this.ledgerStripLabel2.Name = "ledgerStripLabel2";
            this.ledgerStripLabel2.Size = new System.Drawing.Size(163, 20);
            this.ledgerStripLabel2.Text = "Subledgers";
            // 
            // headerStrip2
            // 
            this.headerStrip2.AutoSize = false;
            this.headerStrip2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.headerStrip2.ForeColor = System.Drawing.Color.White;
            this.headerStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.headerStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.headerStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ledgerStripLabel1});
            this.headerStrip2.Location = new System.Drawing.Point(0, 0);
            this.headerStrip2.Name = "headerStrip2";
            this.headerStrip2.Size = new System.Drawing.Size(416, 31);
            this.headerStrip2.TabIndex = 1;
            this.headerStrip2.Text = "headerStrip2";
            // 
            // ledgerStripLabel1
            // 
            this.ledgerStripLabel1.Name = "ledgerStripLabel1";
            this.ledgerStripLabel1.Size = new System.Drawing.Size(176, 28);
            this.ledgerStripLabel1.Text = "Pick a Ledger...";
            // 
            // stackStrip
            // 
            this.stackStrip.AutoSize = false;
            this.stackStrip.CanOverflow = false;
            this.stackStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackStrip.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.stackStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stackStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.stackStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ledgerStripButtonTroubleshooting,
            this.ledgerStripButtonMasterSecrets,
            this.ledgerStripButtonKeyRings,
            this.ledgerStripButtonWallets,
            this.ledgerStripButtonAuthorizations,
            this.ledgerStripButtonVDRUIR,
            this.ledgerStripButtonVDRSEPR,
            this.ledgerStripButtonVDRRL,
            this.ledgerStripButtonVDRLedgers,
            this.ledgerStripButtonVDRAccounts,
            this.ledgerStripButtonVDRSmartContracts});
            this.stackStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.stackStrip.Location = new System.Drawing.Point(0, 0);
            this.stackStrip.Name = "stackStrip";
            this.stackStrip.Padding = new System.Windows.Forms.Padding(0);
            this.stackStrip.Size = new System.Drawing.Size(416, 392);
            this.stackStrip.TabIndex = 0;
            this.stackStrip.Tag = "Read";
            this.stackStrip.Text = "stackStrip1";
            // 
            // ledgerStripButtonTroubleshooting
            // 
            this.ledgerStripButtonTroubleshooting.CheckOnClick = true;
            this.ledgerStripButtonTroubleshooting.Image = global::TDW.TDADesktop.Properties.Resources.Shortcut24;
            this.ledgerStripButtonTroubleshooting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonTroubleshooting.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonTroubleshooting.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonTroubleshooting.Name = "ledgerStripButtonTroubleshooting";
            this.ledgerStripButtonTroubleshooting.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonTroubleshooting.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonTroubleshooting.Tag = "Shortcut";
            this.ledgerStripButtonTroubleshooting.Text = "Troubleshooting";
            this.ledgerStripButtonTroubleshooting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonTroubleshooting.Click += new System.EventHandler(this.ledgerStripButtonTroubleshooting_Click);
            // 
            // ledgerStripButtonMasterSecrets
            // 
            this.ledgerStripButtonMasterSecrets.CheckOnClick = true;
            this.ledgerStripButtonMasterSecrets.Image = global::TDW.TDADesktop.Properties.Resources.Folder24;
            this.ledgerStripButtonMasterSecrets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonMasterSecrets.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonMasterSecrets.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonMasterSecrets.Name = "ledgerStripButtonMasterSecrets";
            this.ledgerStripButtonMasterSecrets.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonMasterSecrets.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonMasterSecrets.Tag = "NewContact";
            this.ledgerStripButtonMasterSecrets.Text = "Master Secrets";
            this.ledgerStripButtonMasterSecrets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonMasterSecrets.Click += new System.EventHandler(this.ledgerStripButtonMasterSecrets_Click);
            // 
            // ledgerStripButtonKeyRings
            // 
            this.ledgerStripButtonKeyRings.Checked = false;
            this.ledgerStripButtonKeyRings.CheckOnClick = true;
            this.ledgerStripButtonKeyRings.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.ledgerStripButtonKeyRings.Image = global::TDW.TDADesktop.Properties.Resources.Folder24;
            this.ledgerStripButtonKeyRings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonKeyRings.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonKeyRings.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonKeyRings.Name = "ledgerStripButtonKeyRings";
            this.ledgerStripButtonKeyRings.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonKeyRings.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonKeyRings.Tag = "Read";
            this.ledgerStripButtonKeyRings.Text = "Key Rings";
            this.ledgerStripButtonKeyRings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonKeyRings.Click += new System.EventHandler(this.ledgerStripButtonKeyRings_Click);
            // 
            // ledgerStripButtonWallets
            // 
            this.ledgerStripButtonWallets.CheckOnClick = true;
            this.ledgerStripButtonWallets.Image = global::TDW.TDADesktop.Properties.Resources.Contacts24;
            this.ledgerStripButtonWallets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonWallets.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonWallets.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonWallets.Name = "ledgerStripButtonWallets";
            this.ledgerStripButtonWallets.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonWallets.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonWallets.Tag = "Wallets";
            this.ledgerStripButtonWallets.Text = "Wallets";
            this.ledgerStripButtonWallets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonWallets.Click += new System.EventHandler(this.ledgerStripButtonWallets_Click);
            // 
            // ledgerStripButtonAuthorizations
            // 
            this.ledgerStripButtonAuthorizations.CheckOnClick = true;
            this.ledgerStripButtonAuthorizations.Image = global::TDW.TDADesktop.Properties.Resources.Calendar24;
            this.ledgerStripButtonAuthorizations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonAuthorizations.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonAuthorizations.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonAuthorizations.Name = "ledgerStripButtonAuthorizations";
            this.ledgerStripButtonAuthorizations.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonAuthorizations.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonAuthorizations.Tag = "Shortcut";
            this.ledgerStripButtonAuthorizations.Text = "Authorizations";
            this.ledgerStripButtonAuthorizations.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonAuthorizations.Click += new System.EventHandler(this.ledgerStripButtonAuthorizations_Click);
            // 
            // ledgerStripButtonVDRUIR
            // 
            this.ledgerStripButtonVDRUIR.CheckOnClick = true;
            this.ledgerStripButtonVDRUIR.Image = global::TDW.TDADesktop.Properties.Resources.Contacts24;
            this.ledgerStripButtonVDRUIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonVDRUIR.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonVDRUIR.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonVDRUIR.Name = "ledgerStripButtonVDRUIR";
            this.ledgerStripButtonVDRUIR.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonVDRUIR.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonVDRUIR.Tag = "NewTask";
            this.ledgerStripButtonVDRUIR.Text = "VDR: Identifiers";
            this.ledgerStripButtonVDRUIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonVDRUIR.Click += new System.EventHandler(this.ledgerStripButtonVDRUIR_Click);
            // 
            // ledgerStripButtonVDRSEPR
            // 
            this.ledgerStripButtonVDRSEPR.CheckOnClick = true;
            this.ledgerStripButtonVDRSEPR.Image = global::TDW.TDADesktop.Properties.Resources.Folder24;
            this.ledgerStripButtonVDRSEPR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonVDRSEPR.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonVDRSEPR.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonVDRSEPR.Name = "ledgerStripButtonVDRSEPR";
            this.ledgerStripButtonVDRSEPR.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonVDRSEPR.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonVDRSEPR.Tag = "Folder";
            this.ledgerStripButtonVDRSEPR.Text = "VDR: Service Endpoints";
            this.ledgerStripButtonVDRSEPR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonVDRSEPR.Click += new System.EventHandler(this.ledgerStripButtonVDRSEPR_Click);
            // 
            // ledgerStripButtonVDRRL
            // 
            this.ledgerStripButtonVDRRL.CheckOnClick = true;
            this.ledgerStripButtonVDRRL.Image = global::TDW.TDADesktop.Properties.Resources.Folder24;
            this.ledgerStripButtonVDRRL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonVDRRL.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonVDRRL.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonVDRRL.Name = "ledgerStripButtonVDRRL";
            this.ledgerStripButtonVDRRL.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonVDRRL.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonVDRRL.Tag = "Shortcut";
            this.ledgerStripButtonVDRRL.Text = "VDR: Revocation List";
            this.ledgerStripButtonVDRRL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonVDRRL.Click += new System.EventHandler(this.ledgerStripButtonVDRRL_Click);
            // 
            // ledgerStripButtonVDRLedgers
            // 
            this.ledgerStripButtonVDRLedgers.CheckOnClick = true;
            this.ledgerStripButtonVDRLedgers.Image = global::TDW.TDADesktop.Properties.Resources.Folder24;
            this.ledgerStripButtonVDRLedgers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonVDRLedgers.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonVDRLedgers.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonVDRLedgers.Name = "ledgerStripButtonVDRLedgers";
            this.ledgerStripButtonVDRLedgers.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonVDRLedgers.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonVDRLedgers.Tag = "Shortcut";
            this.ledgerStripButtonVDRLedgers.Text = "VDR: Ledgers";
            this.ledgerStripButtonVDRLedgers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonVDRLedgers.Click += new System.EventHandler(this.ledgerStripButtonVDRLedgers_Click);
            // 
            // ledgerStripButtonVDRAccounts
            // 
            this.ledgerStripButtonVDRAccounts.CheckOnClick = true;
            this.ledgerStripButtonVDRAccounts.Image = global::TDW.TDADesktop.Properties.Resources.Contacts24;
            this.ledgerStripButtonVDRAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonVDRAccounts.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonVDRAccounts.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonVDRAccounts.Name = "ledgerStripButtonVDRAccounts";
            this.ledgerStripButtonVDRAccounts.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonVDRAccounts.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonVDRAccounts.Tag = "NewAppointment";
            this.ledgerStripButtonVDRAccounts.Text = "VDR: Accounts";
            this.ledgerStripButtonVDRAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonVDRAccounts.Click += new System.EventHandler(this.ledgerStripButtonVDRAccounts_Click);
            // 
            // ledgerStripButtonVDRSmartContracts
            // 
            this.ledgerStripButtonVDRSmartContracts.CheckOnClick = true;
            this.ledgerStripButtonVDRSmartContracts.Image = global::TDW.TDADesktop.Properties.Resources.Tasks24;
            this.ledgerStripButtonVDRSmartContracts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ledgerStripButtonVDRSmartContracts.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ledgerStripButtonVDRSmartContracts.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripButtonVDRSmartContracts.Name = "ledgerStripButtonVDRSmartContracts";
            this.ledgerStripButtonVDRSmartContracts.Padding = new System.Windows.Forms.Padding(2);
            this.ledgerStripButtonVDRSmartContracts.Size = new System.Drawing.Size(415, 32);
            this.ledgerStripButtonVDRSmartContracts.Tag = "Shortcut";
            this.ledgerStripButtonVDRSmartContracts.Text = "VDR: Smart Contracts";
            this.ledgerStripButtonVDRSmartContracts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ledgerStripButtonVDRSmartContracts.Click += new System.EventHandler(this.ledgerStripButtonVDRSmartContracts_Click);
            // 
            // overflowStrip
            // 
            this.overflowStrip.AutoSize = false;
            this.overflowStrip.CanOverflow = false;
            this.overflowStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.overflowStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.overflowStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.overflowStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ledgerStripDropDownButton1});
            this.overflowStrip.Location = new System.Drawing.Point(0, 392);
            this.overflowStrip.Name = "overflowStrip";
            this.overflowStrip.Size = new System.Drawing.Size(416, 39);
            this.overflowStrip.TabIndex = 1;
            this.overflowStrip.Text = "overflowStrip";
            // 
            // ledgerStripDropDownButton1
            // 
            this.ledgerStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ledgerStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.ledgerStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addorRemoveButtonsToolStripMenuItem});
            this.ledgerStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ledgerStripDropDownButton1.Margin = new System.Windows.Forms.Padding(0);
            this.ledgerStripDropDownButton1.Name = "ledgerStripDropDownButton1";
            this.ledgerStripDropDownButton1.Padding = new System.Windows.Forms.Padding(3);
            this.ledgerStripDropDownButton1.Size = new System.Drawing.Size(20, 39);
            this.ledgerStripDropDownButton1.Text = "ledgerStripDropDownButton1";
            // 
            // addorRemoveButtonsToolStripMenuItem
            // 
            this.addorRemoveButtonsToolStripMenuItem.Name = "addorRemoveButtonsToolStripMenuItem";
            this.addorRemoveButtonsToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.addorRemoveButtonsToolStripMenuItem.Text = "&Add or Remove Buttons";
            // 
            // LeftSpinePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.stackStripSplitter);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LeftSpinePanel";
            this.Size = new System.Drawing.Size(416, 774);
            this.Load += new System.EventHandler(this.StackBar_Load);
            this.stackStripSplitter.Panel1.ResumeLayout(false);
            this.stackStripSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stackStripSplitter)).EndInit();
            this.stackStripSplitter.ResumeLayout(false);
            this.headerStrip1.ResumeLayout(false);
            this.headerStrip1.PerformLayout();
            this.headerStrip2.ResumeLayout(false);
            this.headerStrip2.PerformLayout();
            this.stackStrip.ResumeLayout(false);
            this.stackStrip.PerformLayout();
            this.overflowStrip.ResumeLayout(false);
            this.overflowStrip.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer stackStripSplitter;
		private FolderView subledgersView;
		private HeaderStrip headerStrip1;
		private System.Windows.Forms.ToolStripLabel ledgerStripLabel2;
		private HeaderStrip headerStrip2;
		private System.Windows.Forms.ToolStripLabel ledgerStripLabel1;
		private StackStrip stackStrip;
		private System.Windows.Forms.ToolStripButton ledgerStripButtonKeyRings;
		private System.Windows.Forms.ToolStripButton ledgerStripButtonVDRAccounts;
		private System.Windows.Forms.ToolStripButton ledgerStripButtonMasterSecrets;
		private System.Windows.Forms.ToolStripButton ledgerStripButtonVDRUIR;
		private System.Windows.Forms.ToolStripButton ledgerStripButtonWallets;
		private System.Windows.Forms.ToolStripButton ledgerStripButtonVDRSEPR;
		private System.Windows.Forms.ToolStripButton ledgerStripButtonVDRRL;
        private System.Windows.Forms.ToolStripButton ledgerStripButtonVDRLedgers;
        private System.Windows.Forms.ToolStripButton ledgerStripButtonVDRSmartContracts;
        private System.Windows.Forms.ToolStripButton ledgerStripButtonAuthorizations;
        private System.Windows.Forms.ToolStripButton ledgerStripButtonTroubleshooting;
        private BaseStackStrip overflowStrip;
		private System.Windows.Forms.ToolStripDropDownButton ledgerStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem addorRemoveButtonsToolStripMenuItem;
	}
}
