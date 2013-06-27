namespace InstantChat
{
    partial class OfflineMessages
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
            this.btnOK = new System.Windows.Forms.Button();
            this.rtbOfflineMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(437, 221);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rtbOfflineMessages
            // 
            this.rtbOfflineMessages.BackColor = System.Drawing.Color.White;
            this.rtbOfflineMessages.Location = new System.Drawing.Point(8, 7);
            this.rtbOfflineMessages.Name = "rtbOfflineMessages";
            this.rtbOfflineMessages.ReadOnly = true;
            this.rtbOfflineMessages.Size = new System.Drawing.Size(513, 208);
            this.rtbOfflineMessages.TabIndex = 3;
            this.rtbOfflineMessages.Text = "";
            // 
            // OfflineMessages
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(530, 252);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtbOfflineMessages);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(538, 286);
            this.Name = "OfflineMessages";
            this.Text = "Offline Messages";
            this.Load += new System.EventHandler(this.OfflineMessages_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.RichTextBox rtbOfflineMessages;
    }
}