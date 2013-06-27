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
    public partial class RemoveContact : Form
    {
        SqlConnection con;
        bool validUser1 = false, validUser2 = false;
        public RemoveContact()
        {
            InitializeComponent();
            con = new SqlConnection(TempClass.connectionString);
            con.Open();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            if (txtContact.Text == "")
            {
                MessageBox.Show("Please enter Contact Name");


            }

            else
            {
                if (txtContact.Text.ToLower() != "admin")
                {

                    try
                    {
                        SqlDataAdapter adp = new SqlDataAdapter("Select * From tbCreateAccount", con);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "tbCreateAccount");
                        if (ds.Tables.Count > 0)
                        {

                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                if (dr["loginName"].ToString() == txtContact.Text)
                                {
                                    validUser1 = true;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        SqlDataAdapter adp2 = new SqlDataAdapter("Select * From tbAddContact", con);
                        DataSet ds2 = new DataSet();
                        adp2.Fill(ds2, "tbAddContact");
                        if (ds2.Tables.Count > 0)
                        {
                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                            {
                                if (dr2["loginName"].ToString() == txtContact.Text)
                                {
                                    validUser2 = true;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }


                        if (validUser1 == true && validUser2 == true)
                        {
                            SqlCommand SqlCommand1 = con.CreateCommand();
                            SqlCommand1.CommandText = "DELETE FROM tbContactList WHERE loginName=@loginname";

                            SqlCommand1.Parameters.Add("@loginname", SqlDbType.VarChar, 100);
                            SqlCommand1.Parameters[0].Value = txtContact.Text;
                            SqlCommand1.ExecuteNonQuery();


                            con.Close();

                            this.Hide();
                            TempClass.admin.Show();

                        }
                        else if (validUser1 == true && validUser2 == false)
                        {

                            SqlCommand SqlCommand1 = con.CreateCommand();
                            SqlCommand1.CommandText = "DELETE FROM tbContactList WHERE loginName=@loginname";

                            SqlCommand1.Parameters.Add("@loginname", SqlDbType.VarChar, 100);
                            SqlCommand1.Parameters[0].Value = txtContact.Text;
                            SqlCommand1.ExecuteNonQuery();


                            con.Close();

                            this.Hide();
                            TempClass.admin.Show();

                        }
                        else
                        {
                            MessageBox.Show("Enter valid User Contact");


                            txtContact.Text = "";
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(txtContact.Text + " is already deleted from buddy list");
                        txtContact.Text = "";
                        txtContact.Focus();
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Admin record is not included in buddy list");
                    txtContact.Text = "";
                    txtContact.Focus();
                }
            }





        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            TempClass.admin.Show();
        }
        protected override void OnClosing(CancelEventArgs e)
        {

            this.Hide();
            TempClass.admin.Show();
            base.OnClosing(e);
        }
       
    }
}
