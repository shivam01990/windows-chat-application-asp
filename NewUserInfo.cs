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
    public partial class NewUserInfo : Form
    {
        string pwd, confirmPwd;
        int compare;
        private SqlConnection con;
        public NewUserInfo()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {



            this.Hide();
            TempClass.admin.Show();
        }

        private void NewUserInfo_Load(object sender, EventArgs e)
        {
            cbType.Items.Add("User");
            cbType.Items.Add("Administrator");
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "")
            {
                MessageBox.Show("You must enter a Login Name.");
                txtUsername.Focus();
            }
            else if (txtFirstName.Text == "")
            {
                MessageBox.Show("You must enter a First Name.");
                txtFirstName.Focus();
            }


            else if (txtLastName.Text == "")
            {
                MessageBox.Show("You must enter a Last Name.");
                txtLastName.Focus();
            }

            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter a Password");
                txtPassword.Focus();
            }
            else if (txtConfirmPwd.Text == "")
            {
                MessageBox.Show("Please Confirm Password");
                txtConfirmPwd.Focus();
            }
            else if ((txtPassword.Text != "") & (txtConfirmPwd.Text != ""))
            {
                pwd = txtPassword.Text;
                confirmPwd = txtConfirmPwd.Text;
                compare = pwd.CompareTo(confirmPwd);
                if (compare != 0)
                {
                    MessageBox.Show("Password and Confirm Password do not match");

                    txtConfirmPwd.Focus();
                }


                else
                {
                    if ((rbMale.Checked == false) & (rbFemale.Checked == false))
                    {

                        MessageBox.Show("Select a Gender");
                    }
                    else if (cbType.Text == "")
                    {

                        MessageBox.Show("You must Select a type");
                        cbType.Focus();
                    }
                    else
                    {
                        try
                        {

                            con = new System.Data.SqlClient.SqlConnection(TempClass.connectionString);
                            con.Open();
                            SqlDataAdapter adp = new SqlDataAdapter("select * from tbCreateAccount", con);
                            DataSet ds = new DataSet();
                            adp.Fill(ds, "tbCreateAccount");
                            int var = ds.Tables["tbCreateAccount"].Rows.Count;
                            string gender = null;
                            if (rbMale.Checked == true)
                            {
                                gender = rbMale.Text;
                            }
                            else if (rbFemale.Checked == true)
                            {
                                gender = rbFemale.Text;
                            }
                            DataTable table = null;
                            table = ds.Tables["tbCreateAccount"];

                            DataRow newRow = null;

                            newRow = table.NewRow();

                            newRow["loginName"] = txtUsername.Text;
                            newRow["firstName"] = txtFirstName.Text;
                            newRow["lastName"] = txtLastName.Text;
                            newRow["passwd"] = txtPassword.Text;

                            newRow["gender"] = gender;
                            newRow["type"] = cbType.Text;

                            table.Rows.Add(newRow);
                            SqlCommandBuilder commandBuilder = null;
                            commandBuilder = new SqlCommandBuilder(adp);
                            adp.InsertCommand = commandBuilder.GetInsertCommand();
                            adp.Update(ds, "tbCreateAccount");
                            con.Close();
                            MessageBox.Show("New Account of " + txtFirstName.Text + " is Created\nLogin Name: " + txtUsername.Text + "\nPassword: " + txtPassword.Text);

                            txtUsername.Text = "";
                            txtFirstName.Text = "";
                            txtLastName.Text = "";
                            txtPassword.Text = "";
                            txtConfirmPwd.Text = "";
                            rbFemale.Checked = false;
                            rbMale.Checked = false;
                            cbType.Text = "";



                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Login Name is not available.\nPlease choose another Login Name");

                            txtUsername.Focus();
                        }
                    }

                }
            }


        }

        protected override void OnClosing(CancelEventArgs e)
        {

            this.Hide();
            TempClass.admin.Show();
            base.OnClosing(e);
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "")
            {
                string str = txtFirstName.Text.ToString();
                foreach (char c in str)
                {
                    if (Char.IsDigit(c))
                    {
                        MessageBox.Show("Please Enter First Name Properly");
                        txtFirstName.Text = "";
                        return;

                    }
                }
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text != "")
            {
                string str = txtLastName.Text.ToString();
                foreach (char c in str)
                {
                    if (Char.IsDigit(c))
                    {
                        MessageBox.Show("Please Enter Last Name Properly");
                        txtLastName.Text = "";
                        return;

                    }
                }
            }
        }
       
    }
}
