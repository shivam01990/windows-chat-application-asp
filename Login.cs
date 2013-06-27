using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace InstantChat
{
    public partial class Login : Form
    {
        SqlConnection con;
        bool validUser1 = false, validUser2;
        int i;
        public Login()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {

            Application.Exit();
            base.OnClosing(e);
        }

        private void btnNetworkSetting_Click(object sender, EventArgs e)
        {
            NetworkSetting frmNetworkSettings = new NetworkSetting();
            frmNetworkSettings.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please enter Login Name");
                txtUsername.Focus();
                return;

            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter Password");
                txtPassword.Focus();
                return;

            }
            if (cbType.Text == "")
            {
                MessageBox.Show("Please Select the Type");
                cbType.Focus();
                return;
            }

            if (File.Exists("NetSet.txt"))
            {
                FileStream fs = new FileStream("NetSet.txt", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                TempClass.hostIP = br.ReadString();

                fs.Close();
                br.Close();
                /*This code will connect InstantChat project with Chat database, 
                            created in Microsoft SQL Server 2005 having SQL authentication.
                            User has to change this connection code as per his compuer node.*/

                TempClass.connectionString = ("Data Source=" + TempClass.hostIP + ";Initial Catalog=Chat;User ID=sa");
            }
            else
            {
                NetworkSetting serverAdd = new NetworkSetting();
                serverAdd.Show();
            }

            if (TempClass.hostIP != "")
            {
                try
                {
                    con = new System.Data.SqlClient.SqlConnection(TempClass.connectionString);
                    con.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("Select * From  tbCreateAccount", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds, "tbCreateAccount");
                    if (ds.Tables.Count > 0)
                    {

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if ((dr["loginName"].ToString() == txtUsername.Text) && (dr["passwd"].ToString() == txtPassword.Text) && (dr["type"].ToString() == cbType.SelectedItem.ToString()) && (dr["type"].ToString() == "Administrator"))
                            {

                                i = 1;
                                break;
                            }
                            else if ((dr["loginName"].ToString() == txtUsername.Text) && (dr["passwd"].ToString() == txtPassword.Text) && (dr["type"].ToString() == cbType.SelectedItem.ToString()) && (dr["type"].ToString() == "User"))
                            {

                                i = 2;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }

                    }
                    if (i == 1 || i == 2)
                    {
                        SqlDataAdapter adp2 = new SqlDataAdapter("Select * From  tbAddContact", con);
                        DataSet ds2 = new DataSet();
                        adp2.Fill(ds2, "tbAddContact");
                        if (ds2.Tables.Count > 0)
                        {
                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                            {
                                if (dr2["loginName"].ToString() == txtUsername.Text)
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
                        SqlDataAdapter adp4 = new SqlDataAdapter("Select * From  tbContactList", con);
                        DataSet ds4 = new DataSet();
                        adp4.Fill(ds4, "tbContactList");
                        if (ds4.Tables.Count > 0)
                        {

                            foreach (DataRow dr in ds4.Tables[0].Rows)
                            {
                                if ((dr["loginName"].ToString() == txtUsername.Text) && (dr["userStatus"].ToString() == "Offline"))
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
                        if (validUser2 == true)
                        {
                            SqlCommand SqlCommand1 = con.CreateCommand();
                            SqlCommand1.CommandText = "UPDATE  tbContactList SET userStatus=@userStatus  WHERE loginName=@loginname";

                            SqlCommand1.Parameters.Add("@userStatus", SqlDbType.VarChar, 10);

                            SqlCommand1.Parameters.Add("@loginname", SqlDbType.VarChar, 100);
                            SqlCommand1.Parameters[0].Value = "Online";
                            SqlCommand1.Parameters[1].Value = txtUsername.Text;
                            SqlCommand1.ExecuteNonQuery();




                        }
                        if (validUser1 == true)
                        {
                            MessageBox.Show("User already Logged In");

                            con.Close();
                            TempClass.username = txtUsername.Text;
                            if (i == 1)
                            {
                                AdminStatus cs = new AdminStatus();

                                TempClass.admin = cs;
                                this.Hide();
                                TempClass.admin.Show();


                            }

                            if (i == 2)
                            {
                                UserStatus cs = new UserStatus();

                                TempClass.user = cs;
                                this.Hide();
                                TempClass.user.Show();

                            }

                        }
                        if (validUser1 == false)
                        {
                            SqlDataAdapter adp3 = new SqlDataAdapter("select * from  tbAddContact", con);
                            DataSet ds3 = new DataSet();
                            adp3.Fill(ds3, "tbAddContact");
                            int var = ds3.Tables["tbAddContact"].Rows.Count;

                            DataTable table = null;
                            table = ds3.Tables["tbAddContact"];

                            DataRow newRow = null;

                            newRow = table.NewRow();

                            newRow["loginName"] = txtUsername.Text;

                            table.Rows.Add(newRow);
                            SqlCommandBuilder commandBuilder = null;
                            commandBuilder = new SqlCommandBuilder(adp3);
                            adp3.InsertCommand = commandBuilder.GetInsertCommand();
                            adp3.Update(ds3, "tbAddContact");
                            con.Close();
                            TempClass.username = txtUsername.Text;
                            if (i == 1)
                            {
                                AdminStatus cs = new AdminStatus();

                                TempClass.admin = cs;
                                this.Hide();
                                TempClass.admin.Show();

                            }

                            if (i == 2)
                            {
                                UserStatus cs = new UserStatus();


                                TempClass.user = cs;
                                this.Hide();
                                TempClass.user.Show();

                            }
                        }


                    }
                    if (i == 0)
                    {

                        MessageBox.Show("Provided information does not match.\nPlease Check Your Data");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Provided information does not match.\nPlease Check Your Data");
                }

            }

        }

       



    }
}
