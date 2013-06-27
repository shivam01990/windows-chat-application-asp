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
    public partial class DeleteUsers : Form
    {
        SqlConnection con;

        DataSet myDataSet;

        bool validUser1 = false;

        private SqlDataAdapter da;

        SqlCommand SqlCommand1;
        public DeleteUsers()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {

            TempClass.admin.Show();
            this.Hide();
            base.OnClosing(e);
        }

        private void DeleteUsers_Load(object sender, EventArgs e)
        {
            // Create Connection object

            con = new SqlConnection(TempClass.connectionString);
            con.Open();
            //  Sql Query            
            string sql = "SELECT * FROM tbCreateAccount where loginName!='admin' OR loginName!='Admin' OR loginName!='ADMIN'";
            SqlCommand1 = new SqlCommand(sql, con);
            SqlDataReader dr = SqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                cbLoginName.Items.Add(dr[0]);
            }

            dr.Close();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {

            string sql = "SELECT * FROM tbCreateAccount where loginName!='admin' OR loginName!='Admin' OR loginName!='ADMIN'";
            SqlCommand1 = new SqlCommand(sql, con);
            //  Create SqlDataAdapter
            da = new SqlDataAdapter();
            da.SelectCommand = SqlCommand1;
            myDataSet = new DataSet();
            da.Fill(myDataSet, "tbCreateAccount");
            dataGrid1.DataSource = myDataSet;
            dataGrid1.DataMember = myDataSet.Tables["tbCreateAccount"].ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str = cbLoginName.Text;
            if (str == "")
            {
                MessageBox.Show("You must select a Login Name");
            }
            else
            {
                if (str.ToLower() != "admin")
                {
                    try
                    {
                        SqlCommand SqlCommand1 = con.CreateCommand();
                        SqlCommand1.CommandText = "DELETE FROM tbCreateAccount WHERE loginName=@loginname";
                        int res;
                        SqlCommand1.Parameters.Add("@loginname", SqlDbType.VarChar, 100);
                        SqlCommand1.Parameters[0].Value = cbLoginName.SelectedItem;
                        res = SqlCommand1.ExecuteNonQuery();
                        if (res >= 1)
                        {
                            MessageBox.Show("Record deleted");

                            cbLoginName.Text = "";

                            cbLoginName.Items.Clear();
                            string sql = "SELECT * FROM tbCreateAccount where loginName!='admin' OR loginName!='Admin' OR loginName!='ADMIN'";
                            SqlCommand1 = new SqlCommand(sql, con);
                            SqlDataReader dr = SqlCommand1.ExecuteReader();
                            while (dr.Read())
                            {
                                cbLoginName.Items.Add(dr[0]);
                            }

                            dr.Close();



                        }
                        else
                        {
                            MessageBox.Show("No matching record is found");

                        }
                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show("Please remove Login Name from contact list first");

                    }
                }
                else
                {
                    MessageBox.Show("Admin record cannot be deleted");
                }
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGrid1.DataSource = null;
            cbLoginName.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string str = cbLoginName.Text;
            if (str == "")
            {
                MessageBox.Show("You must select a Login Name");
            }
            else
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
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("No matching record is found");
                }

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();

            TempClass.admin.Show();
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
