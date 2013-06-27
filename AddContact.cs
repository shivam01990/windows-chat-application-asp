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
    public partial class AddContact : Form
    {
        SqlConnection con;
        bool validUser1 = false, validUser2 = false;
        public AddContact()
        {
            InitializeComponent();
            con = new SqlConnection(TempClass.connectionString);
            con.Open();
        }
        private void btnAdd_Click(object sender, EventArgs e)
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

                        SqlDataAdapter adp3 = new SqlDataAdapter("select * from tbContactList", con);
                        DataSet ds3 = new DataSet();
                        adp3.Fill(ds3, "tbContactList");
                        int var = ds3.Tables["tbContactList"].Rows.Count;
                        DataTable table = null;
                        table = ds3.Tables["tbContactList"];
                        DataRow newRow = null;
                        SqlCommandBuilder commandBuilder3 = null;
                        commandBuilder3 = new SqlCommandBuilder(adp3);
                        if (validUser1 == true && validUser2 == true)
                        {
                            newRow = table.NewRow();
                            newRow["loginName"] = txtContact.Text;
                            newRow["userStatus"] = "Online";
                            table.Rows.Add(newRow);
                            adp3.InsertCommand = commandBuilder3.GetInsertCommand();
                            adp3.Update(ds3, "tbContactList");


                            this.Hide();
                            TempClass.admin.Show();

                        }
                        else if (validUser1 == true && validUser2 == false)
                        {

                            newRow = table.NewRow();
                            newRow["loginName"] = txtContact.Text;
                            newRow["userStatus"] = "Offline";
                            table.Rows.Add(newRow);
                            adp3.InsertCommand = commandBuilder3.GetInsertCommand();
                            adp3.Update(ds3, "tbContactList");



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
                        MessageBox.Show(txtContact.Text + " is already included in buddy list");
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
                    MessageBox.Show("Admin record cannot be included in buddy list");
                    txtContact.Text = "";
                    txtContact.Focus();
                }
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Hide();
            TempClass.admin.Show();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            con.Close();

            this.Hide();
            TempClass.admin.Show();
            base.OnClosing(e);
        }
       
    }
}
