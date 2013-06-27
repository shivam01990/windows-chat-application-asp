namespace InstantChat
{
    partial class AdminStatus
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.tmrMessageReceive = new System.Windows.Forms.Timer(this.components);
            this.pnlContacts = new System.Windows.Forms.Panel();
            this.tmrContactUpdate = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendAnInstantMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 295);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(207, 23);
            this.statusBar.TabIndex = 5;
            this.statusBar.Text = "statusBar1";
            // 
            // tmrMessageReceive
            // 
            this.tmrMessageReceive.Interval = 2000;
            this.tmrMessageReceive.Tick += new System.EventHandler(this.tmrMessageReceive_Tick);
            // 
            // pnlContacts
            // 
            this.pnlContacts.BackColor = System.Drawing.Color.White;
            this.pnlContacts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlContacts.Location = new System.Drawing.Point(12, 36);
            this.pnlContacts.Name = "pnlContacts";
            this.pnlContacts.Size = new System.Drawing.Size(183, 245);
            this.pnlContacts.TabIndex = 4;
            this.pnlContacts.Resize += new System.EventHandler(this.pnlContacts_Resize);
            // 
            // tmrContactUpdate
            // 
            this.tmrContactUpdate.Interval = 3000;
            this.tmrContactUpdate.Tick += new System.EventHandler(this.tmrContactUpdate_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatToolStripMenuItem,
            this.userAccountToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(207, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip";
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendAnInstantMessageToolStripMenuItem,
            this.addContactToolStripMenuItem,
            this.removeContactToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.chatToolStripMenuItem.Text = "Chat";
            // 
            // sendAnInstantMessageToolStripMenuItem
            // 
            this.sendAnInstantMessageToolStripMenuItem.Name = "sendAnInstantMessageToolStripMenuItem";
            this.sendAnInstantMessageToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.sendAnInstantMessageToolStripMenuItem.Text = "Send An Instant Message";
            this.sendAnInstantMessageToolStripMenuItem.Click += new System.EventHandler(this.sendAnInstantMessageToolStripMenuItem_Click);
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.addContactToolStripMenuItem.Text = "Add Contact";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.addContactToolStripMenuItem_Click);
            // 
            // removeContactToolStripMenuItem
            // 
            this.removeContactToolStripMenuItem.Name = "removeContactToolStripMenuItem";
            this.removeContactToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.removeContactToolStripMenuItem.Text = "Remove Contact";
            this.removeContactToolStripMenuItem.Click += new System.EventHandler(this.removeContactToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // userAccountToolStripMenuItem
            // 
            this.userAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewAccountToolStripMenuItem,
            this.viewAllUsersToolStripMenuItem,
            this.deleteUsersToolStripMenuItem,
            this.updateUsersToolStripMenuItem});
            this.userAccountToolStripMenuItem.Name = "userAccountToolStripMenuItem";
            this.userAccountToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.userAccountToolStripMenuItem.Text = "User Account";
            // 
            // createNewAccountToolStripMenuItem
            // 
            this.createNewAccountToolStripMenuItem.Name = "createNewAccountToolStripMenuItem";
            this.createNewAccountToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.createNewAccountToolStripMenuItem.Text = "Create New Account";
            this.createNewAccountToolStripMenuItem.Click += new System.EventHandler(this.createNewAccountToolStripMenuItem_Click);
            // 
            // viewAllUsersToolStripMenuItem
            // 
            this.viewAllUsersToolStripMenuItem.Name = "viewAllUsersToolStripMenuItem";
            this.viewAllUsersToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.viewAllUsersToolStripMenuItem.Text = "View All Users";
            this.viewAllUsersToolStripMenuItem.Click += new System.EventHandler(this.viewAllUsersToolStripMenuItem_Click);
            // 
            // deleteUsersToolStripMenuItem
            // 
            this.deleteUsersToolStripMenuItem.Name = "deleteUsersToolStripMenuItem";
            this.deleteUsersToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.deleteUsersToolStripMenuItem.Text = "Delete Users";
            this.deleteUsersToolStripMenuItem.Click += new System.EventHandler(this.deleteUsersToolStripMenuItem_Click);
            // 
            // updateUsersToolStripMenuItem
            // 
            this.updateUsersToolStripMenuItem.Name = "updateUsersToolStripMenuItem";
            this.updateUsersToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.updateUsersToolStripMenuItem.Text = "Update Users";
            this.updateUsersToolStripMenuItem.Click += new System.EventHandler(this.updateUsersToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // AdminStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(207, 318);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.pnlContacts);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(215, 352);
            this.MinimumSize = new System.Drawing.Size(215, 352);
            this.Name = "AdminStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Status";
            this.Load += new System.EventHandler(this.AdminStatus_Load);
            this.Resize += new System.EventHandler(this.AdminStatus_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Timer tmrMessageReceive;
        internal System.Windows.Forms.Panel pnlContacts;
        internal System.Windows.Forms.Timer tmrContactUpdate;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendAnInstantMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}