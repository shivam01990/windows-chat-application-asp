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
    public partial class UpdateUsers : Form
    {
        SqlConnection con;
        DataSet myDataSet;

        SqlDataAdapter da;
        SqlCommand SqlCommand1;
        string sql;
        int count;
        bool validUser1 = false;
        public UpdateUsers()
        {
            InitializeComponent();
            con = new SqlConnection(TempClass.connectionString);
            con.Open();
            if (TempClass.username == "admin")
            {
                sql = "SELECT * FROM tbCreateAccount";
            }
            else
            {
                sql = "SELECT * FROM tbCreateAccount where loginName!='admin' OR loginName!='Admin' OR loginName!='ADMIN'";
            }
            SqlCommand1 = new SqlCommand(sql, con);
            SqlDataReader dr = SqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                cbLoginName.Items.Add(dr[0]);
                count++;
            }

            dr.Close();
        }
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            cbLoginName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPwd.Text = "";
            txtGender.Text = "";
            txtType.Text = "";
            if (TempClass.username == "admin")
            {
                sql = "SELECT * FROM tbCreateAccount";
            }
            else
            {
                sql = "SELECT * FROM tbCreateAccount where loginName!='admin' OR loginName!='Admin' OR loginName!='ADMIN'";
            }


            SqlCommand1 = new SqlCommand(sql, con);
            //  Create SqlDataAdapter
            da = new SqlDataAdapter();
            da.SelectCommand = SqlCommand1;
            myDataSet = new DataSet();
            da.Fill(myDataSet, "tbCreateAccount");
            dataGrid1.DataSource = myDataSet;
            dataGrid1.DataMember = myDataSet.Tables["tbCreateAccount"].ToString();


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGrid1.DataSource = null;
            cbLoginName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPwd.Text = "";
            txtGender.Text = "";
            txtType.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();

            TempClass.admin.Show();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand SqlCommand1 = con.CreateCommand();
                SqlCommand1.CommandText = "UPDATE tbCreateAccount SET firstName=@firstname,lastName=@lastname,passwd=@passwd,gender=@gender,type=@type WHERE loginName=@loginname";
                int res;
                SqlCommand1.Parameters.Add("@firstname", SqlDbType.VarChar, 100);
                SqlCommand1.Parameters.Add("@lastname", SqlDbType.VarChar, 100);
                SqlCommand1.Parameters.Add("@passwd", SqlDbType.VarChar, 100);
                SqlCommand1.Parameters.Add("@gender", SqlDbType.VarChar, 10);
                SqlCommand1.Parameters.Add("@type", SqlDbType.VarChar, 20);
                SqlCommand1.Parameters.Add("@loginname", SqlDbType.VarChar, 100);
                SqlCommand1.Parameters[0].Value = txtFirstName.Text;
                SqlCommand1.Parameters[1].Value = txtLastName.Text;
                SqlCommand1.Parameters[2].Value = txtPwd.Text;
                SqlCommand1.Parameters[3].Value = txtGender.Text;
                SqlCommand1.Parameters[4].Value = txtType.Text;
                SqlCommand1.Parameters[5].Value = cbLoginName.SelectedItem;
                res = SqlCommand1.ExecuteNonQuery();
                if (res >= 1)
                {



                    try
                    {
                        string sql = "SELECT * FROM tbCreateAccount WHERE loginName=@loginname";
                        SqlCommand SqlCommand2 = con.CreateCommand();
                        SqlCommand2.CommandText = sql;
                        int res2;
                        SqlCommand2.Parameters.Add("@loginname", SqlDbType.VarChar, 100);
                        SqlCommand2.Parameters[0].Value = cbLoginName.SelectedItem;
                        da = new SqlDataAdapter();
                        da.SelectCommand = SqlCommand2;
                        myDataSet = new DataSet();
                        res2 = da.Fill(myDataSet, "tbCreateAccount");

                        if (res2 >= 1)
                        {
                            dataGrid1.DataSource = myDataSet;
                            dataGrid1.DataMember = myDataSet.Tables["tbCreateAccount"].ToString();

                            txtFirstName.Text = myDataSet.Tables["tbCreateAccount"].Rows[0]["firstName"].ToString();

                            txtLastName.Text = myDataSet.Tables["tbCreateAccount"].Rows[0]["lastName"].ToString();

                            txtPwd.Text = myDataSet.Tables["tbCreateAccount"].Rows[0]["passwd"].ToString();



                            txtGender.Text = myDataSet.Tables["tbCreateAccount"].Rows[0]["gender"].ToString();
                            txtType.Text = myDataSet.Tables["tbCreateAccount"].Rows[0]["type"].ToString();
                            MessageBox.Show("User's information is updated.");

                        }

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error");
                    }

                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Provided information does not match.\nPlease Check Your Data");
            }

        }


        private void cbLoginName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM tbCreateAccount WHERE loginName=@loginname";
                SqlCommand SqlCommand1 = con.CreateCommand();
                SqlCommand1.CommandText = sql;
                int res;
                SqlCommand1.Parameters.Add("@loginname", SqlDbType.VarChar, 100);
                SqlCommand1.Parameters[0].Value = cbLoginName.SelectedItem;
                da = new SqlDataAdapter();
                da.SelectCommand = SqlCommand1;
                myDataSet = new DataSet();
                res = da.Fill(myDataSet, "tbCreateAccount");

                if (res >= 1)
                {
                    dataGrid1.DataSource = myDataSet;
                    dataGrid1.DataMember = myDataSet.Tables["tbCreateAccount"].ToString();

                    txtFirstName.Text = myDataSet.Tables["tbCreateAccount"].Rows[0]["firstName"].ToString();

                    txtLastName.Text = myDataSet.Tables["tbCreateAccount"].Rows[0]["lastName"].ToString();

                    txtPwd.Text = myDataSet.Tables["tbCreateAccount"].Rows[0]["passwd"].ToString();



                    txtGender.Text = myDataSet.Tables["tbCreateAccount"].Rows[0]["gender"].ToString();
                    txtType.Text = myDataSet.Tables["tbCreateAccount"].Rows[0]["type"].ToString();

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {

            this.Hide();
            TempClass.admin.Show();
            base.OnClosing(e);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand1 = con.CreateCommand();
                SqlCommand1.CommandText = "DELETE FROM tbAddContact WHERE loginName=@loginname";
                SqlCommand1.Parameters.Add("@loginname", SqlDbType.VarChar, 100);
                SqlCommand1.Parameters[0].Value = TempClass.username;
                SqlCommand1.ExecuteNonQuery();


                SqlDataAdapter adp4 = new SqlDataAdapter("Select * From tbContactList", con);
                DataSet ds4 = new DataSet();
                adp4.Fill(ds4, "tbContactList");
                if (ds4.Tables.Count > 0)
                {

                    foreach (DataRow dr in ds4.Tables[0].Rows)
                    {
                        if ((dr["loginName"].ToString() == TempClass.username) && (dr["userStatus"].ToString() == "Online"))
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
                if (validUser1 == true)
                {
                    SqlCommand SqlCommand2 = con.CreateCommand();
                    SqlCommand2.CommandText = "UPDATE tbContactList SET userStatus=@userstatus WHERE loginName=@username";

                    SqlCommand2.Parameters.Add("@userstatus", SqlDbType.VarChar, 10);

                    SqlCommand2.Parameters.Add("@username", SqlDbType.VarChar, 100);
                    SqlCommand2.Parameters[0].Value = "Offline";
                    SqlCommand2.Parameters[1].Value = TempClass.username;

                    SqlCommand2.ExecuteNonQuery();
                    Application.Exit();
                    System.Diagnostics.Process.Start(Application.ExecutablePath);


                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("User cannot logout");

            }
        }
    }
}
