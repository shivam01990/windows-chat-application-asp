namespace InstantChat
{
    partial class AllUsers
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gpAllUsers = new System.Windows.Forms.GroupBox();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lbType = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lbGender = new System.Windows.Forms.Label();
            this.lbPwd = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.lbLoginName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.gpAllUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(641, 422);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(56, 30);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.CaptionBackColor = System.Drawing.Color.MediumSlateBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.GridLineColor = System.Drawing.Color.Lavender;
            this.dataGrid1.HeaderBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(296, 70);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.PreferredColumnWidth = 90;
            this.dataGrid1.Size = new System.Drawing.Size(402, 232);
            this.dataGrid1.TabIndex = 57;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(523, 308);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 39);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(203, 293);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(46, 28);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(151, 293);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(46, 28);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(99, 293);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(46, 28);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(47, 293);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(46, 28);
            this.btnFirst.TabIndex = 1;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "All Details of Users";
            // 
            // gpAllUsers
            // 
            this.gpAllUsers.Controls.Add(this.txtLoginName);
            this.gpAllUsers.Controls.Add(this.labelPosition);
            this.gpAllUsers.Controls.Add(this.txtGender);
            this.gpAllUsers.Controls.Add(this.txtType);
            this.gpAllUsers.Controls.Add(this.lbType);
            this.gpAllUsers.Controls.Add(this.txtPwd);
            this.gpAllUsers.Controls.Add(this.txtLastName);
            this.gpAllUsers.Controls.Add(this.txtFirstName);
            this.gpAllUsers.Controls.Add(this.lbGender);
            this.gpAllUsers.Controls.Add(this.lbPwd);
            this.gpAllUsers.Controls.Add(this.lbLastName);
            this.gpAllUsers.Controls.Add(this.lbFirstName);
            this.gpAllUsers.Controls.Add(this.lbLoginName);
            this.gpAllUsers.Location = new System.Drawing.Point(12, 65);
            this.gpAllUsers.Name = "gpAllUsers";
            this.gpAllUsers.Size = new System.Drawing.Size(278, 282);
            this.gpAllUsers.TabIndex = 50;
            this.gpAllUsers.TabStop = false;
            this.gpAllUsers.Text = "View All Users";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(178, 44);
            this.txtLoginName.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(95, 21);
            this.txtLoginName.TabIndex = 59;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(104, 17);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(95, 13);
            this.labelPosition.TabIndex = 58;
            this.labelPosition.Text = "Record Position";
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(178, 158);
            this.txtGender.Margin = new System.Windows.Forms.Padding(2);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(95, 21);
            this.txtGender.TabIndex = 56;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(178, 186);
            this.txtType.Margin = new System.Windows.Forms.Padding(2);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(95, 21);
            this.txtType.TabIndex = 55;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(10, 189);
            this.lbType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(162, 13);
            this.lbType.TabIndex = 54;
            this.lbType.Text = "Type (Administrator/User):";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(178, 126);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(2);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(95, 21);
            this.txtPwd.TabIndex = 52;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(178, 97);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(95, 21);
            this.txtLastName.TabIndex = 51;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(178, 69);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(95, 21);
            this.txtFirstName.TabIndex = 50;
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Location = new System.Drawing.Point(10, 161);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(140, 13);
            this.lbGender.TabIndex = 49;
            this.lbGender.Text = "Gender (Male/Female):";
            // 
            // lbPwd
            // 
            this.lbPwd.AutoSize = true;
            this.lbPwd.Location = new System.Drawing.Point(10, 131);
            this.lbPwd.Name = "lbPwd";
            this.lbPwd.Size = new System.Drawing.Size(66, 13);
            this.lbPwd.TabIndex = 47;
            this.lbPwd.Text = "Password:";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(10, 102);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(72, 13);
            this.lbLastName.TabIndex = 46;
            this.lbLastName.Text = "Last Name:";
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Location = new System.Drawing.Point(10, 73);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(73, 13);
            this.lbFirstName.TabIndex = 45;
            this.lbFirstName.Text = "First Name:";
            // 
            // lbLoginName
            // 
            this.lbLoginName.AutoSize = true;
            this.lbLoginName.Location = new System.Drawing.Point(10, 47);
            this.lbLoginName.Name = "lbLoginName";
            this.lbLoginName.Size = new System.Drawing.Size(79, 13);
            this.lbLoginName.TabIndex = 44;
            this.lbLoginName.Text = "Login Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(588, 422);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(413, 308);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(91, 39);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "SHOW ALL";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // AllUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(704, 453);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpAllUsers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnShow);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(712, 487);
            this.MinimumSize = new System.Drawing.Size(712, 487);
            this.Name = "AllUsers";
            this.Text = "All Users";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.gpAllUsers.ResumeLayout(false);
            this.gpAllUsers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.GroupBox gpAllUsers;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.Label lbPwd;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Label lbLoginName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnShow;
    }
}