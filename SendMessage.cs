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
    public partial class SendMessage : Form
    {
        internal string contact;
        private System.Data.SqlClient.SqlConnection con;
        bool validUser = false;


        private System.Data.DataSet myDataSet;
        private SqlDataAdapter da;
        public SendMessage()
        {
            InitializeComponent();
        }
        public SendMessage(string username)
        {
            InitializeComponent();
            con = new System.Data.SqlClient.SqlConnection(TempClass.connectionString);
            con.Open();
            contact = username;
            this.Text = username;
            this.txtMessage.Focus();


        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter("Select * From  tbAddContact", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds, "tbAddContact");
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            if (dr["loginName"].ToString() == contact)
                            {
                                validUser = true;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }


                    if (validUser == true)
                    {


                        SqlDataAdapter adp2 = new SqlDataAdapter("select * from  tbOnlineUsersMessage", con);
                        DataSet ds2 = new DataSet();
                        adp2.Fill(ds2, "tbOnlineUsersMessage");
                        int var = ds2.Tables["tbOnlineUsersMessage"].Rows.Count;
                        DataTable table = null;
                        table = ds2.Tables["tbOnlineUsersMessage"];
                        DataRow newRow = null;
                        newRow = table.NewRow();

                        newRow["ToLoginName"] = contact;
                        newRow["FromLoginName"] = TempClass.username;
                        newRow["Message"] = txtMessage.Text;
                        table.Rows.Add(newRow);
                        SqlCommandBuilder commandBuilder = null;
                        commandBuilder = new SqlCommandBuilder(adp2);
                        adp2.InsertCommand = commandBuilder.GetInsertCommand();
                        adp2.Update(ds2, "tbOnlineUsersMessage");
                        rtbConversation.AppendText(TempClass.username + " : ");
                        rtbConversation.AppendText(txtMessage.Text + " \n");
                        txtMessage.Focus();
                        txtMessage.Clear();

                    }
                    if (validUser == false)
                    {

                        SqlDataAdapter adp3 = new SqlDataAdapter("select * from  tbOfflineUsersMessage", con);
                        DataSet ds3 = new DataSet();
                        adp3.Fill(ds3, "tbOfflineUsersMessage");
                        int var = ds3.Tables["tbOfflineUsersMessage"].Rows.Count;
                        DataTable table = null;
                        table = ds3.Tables["tbOfflineUsersMessage"];
                        DataRow newRow = null;
                        newRow = table.NewRow();

                        newRow["ToLoginName"] = contact;
                        newRow["FromLoginName"] = TempClass.username;
                        newRow["Message"] = txtMessage.Text;
                        table.Rows.Add(newRow);
                        SqlCommandBuilder commandBuilder = null;
                        commandBuilder = new SqlCommandBuilder(adp3);
                        adp3.InsertCommand = commandBuilder.GetInsertCommand();
                        adp3.Update(ds3, "tbOfflineUsersMessage");
                        rtbConversation.AppendText(TempClass.username + " : ");
                        rtbConversation.AppendText(txtMessage.Text + " \n");
                        txtMessage.Focus();
                        txtMessage.Clear();




                    }







                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                txtMessage.Focus();
            }


        }


        private void tmrMessageComing_Tick(object sender, EventArgs e)
        {

            if (TempClass.i >= 1)
            {
                MessageQueue();
                DeleteMessage();
                TempClass.i++;
            }


        }
        private void MessageQueue()
        {
            if (TempClass.j == 0)
            {
                string sql = "SELECT * FROM tbOnlineUsersMessage WHERE ToLoginName=@tologinname";
                SqlCommand SqlCommand1 = con.CreateCommand();
                SqlCommand1.CommandText = sql;
                int res;
                SqlCommand1.Parameters.Add("@tologinname", SqlDbType.VarChar, 100);
                SqlCommand1.Parameters[0].Value = TempClass.username;
                da = new SqlDataAdapter();
                da.SelectCommand = SqlCommand1;
                myDataSet = new System.Data.DataSet();
                res = da.Fill(myDataSet, "tbOnlineUsersMessage");
                string from, msg;
                if (res >= 1)
                {

                    from = myDataSet.Tables["tbOnlineUsersMessage"].Rows[0]["FromLoginName"].ToString();
                    TempClass.FromUsername = from;

                    msg = myDataSet.Tables["tbOnlineUsersMessage"].Rows[0]["Message"].ToString();

                    this.rtbConversation.AppendText(from + " : ");
                    this.rtbConversation.AppendText(msg + " \n");
                    TempClass.j++;
                }
            }
        }
        private void DeleteMessage()
        {
            if (TempClass.j == 1)
            {
                SqlCommand SqlCommand2 = con.CreateCommand();
                SqlCommand2.CommandText = "DELETE FROM tbOnlineUsersMessage WHERE FromLoginName=@fromloginname";

                SqlCommand2.Parameters.Add("@fromloginname", SqlDbType.VarChar, 100);
                SqlCommand2.Parameters[0].Value = TempClass.FromUsername;
                SqlCommand2.ExecuteNonQuery();

                TempClass.j = 0;
            }
        }

        private void SendMessage_FormClosing(object sender, FormClosingEventArgs e)
        {


            TempClass.usernameList.Remove(contact);
            TempClass.ToUsername = "";


        }
        

    }
}
