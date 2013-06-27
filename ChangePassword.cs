using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InstantChat
{
    public partial class ChangePassword : Form
    {
        SqlConnection con;
        public ChangePassword()
        {
            InitializeComponent();
            con = new SqlConnection(TempClass.connectionString);
            con.Open();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtUsername.Text == TempClass.username)
            {
                if (this.txtNewPassword.Text == txtConfirmPassword.Text)
                {

                    SqlCommand SqlCommand1 = con.CreateCommand();
                    SqlCommand1.CommandText = "UPDATE tbCreateAccount SET passwd=@newpasswd WHERE loginName=@loginname and passwd=@currentpwd";
                    int res;

                    SqlCommand1.Parameters.Add("@newpasswd", SqlDbType.VarChar, 100);
                    SqlCommand1.Parameters.Add("@loginname", SqlDbType.VarChar, 100);
                    SqlCommand1.Parameters.Add("@currentpwd", SqlDbType.VarChar, 100);
                    SqlCommand1.Parameters[0].Value = txtNewPassword.Text;
                    SqlCommand1.Parameters[1].Value = txtUsername.Text;
                    SqlCommand1.Parameters[2].Value = txtCurPassword.Text;

                    res = SqlCommand1.ExecuteNonQuery();
                    if (res >= 1)
                    {
                        MessageBox.Show("Password Changed");

                    }
                    else
                    {
                        MessageBox.Show("Error changing password. Please check the username and current password fields");

                    }
                }
                else
                {
                    MessageBox.Show("Your password fields New Password and Confirm Password do not match");

                }
            }
            else
            {
                MessageBox.Show("Please check your Login Name");

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
