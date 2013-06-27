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
    public partial class AdminStatus : Form
    {
        SqlConnection con;
        SqlCommand SqlCommand1;
        bool validUser1 = false, validUser2 = false;
        private System.Data.DataSet myDataSet;
        private SqlDataAdapter da;
        public AdminStatus()
        {
            InitializeComponent();
            TempClass.j = 0;
            con = new SqlConnection(TempClass.connectionString);
            tmrMessageReceive.Enabled = true;
            tmrContactUpdate.Enabled = true;
        }
        private void sendAnInstantMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SelectContact frmContact = new SelectContact())
                {
                    if (frmContact.ShowDialog(this) == DialogResult.OK)
                    {
                        if (frmContact.txtContact.Text == "")
                        {
                            MessageBox.Show("Please enter Contact Name");

                            return;
                        }

                        if (frmContact.txtContact.Text == TempClass.username)
                        {
                            MessageBox.Show("You can not send a message to yourself.");

                            return;
                        }

                        else
                        {
                            TempClass.ToUsername = frmContact.txtContact.Text;

                            SqlDataAdapter adp = new SqlDataAdapter("Select * From tbCreateAccount", con);
                            DataSet ds = new DataSet();
                            adp.Fill(ds, "tbCreateAccount");
                            if (ds.Tables.Count > 0)
                            {

                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    if (dr["loginName"].ToString() == TempClass.ToUsername)
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
                                WindowList(TempClass.ToUsername);
                                validUser1 = false;

                            }
                            else
                            {
                                MessageBox.Show("Not a member of Instant Chat");



                            }


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }


        }
        private void WindowList(string username)
        {

            if (TempClass.usernameList.Contains(username))
            {
                ((SendMessage)TempClass.usernameList[username]).Focus();

            }
            else
            {

                SendMessage frmMessage = new SendMessage(username);
                frmMessage.contact = username;
                frmMessage.Text = username + " - Instant Message";
                TempClass.usernameList.Add(username, frmMessage);
                frmMessage.Show();


            }

        }
        private void Contact_Click(object sender, System.EventArgs e)
        {
            OpenFormMessage(((OnlineContact.UserControl1)sender).Contact);

        }


        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddContact add = new AddContact();

            add.Show();
        }

        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact select = new RemoveContact();
            select.Show();
            this.Hide();
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult reply = MessageBox.Show("Do you want to close the application?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reply == DialogResult.Yes)
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






                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show("User cannot logout");

                }
                finally
                {
                    con.Close();
                    Application.Exit();

                }
            }

        }



        private void AdminStatus_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Text = TempClass.username + " Logged In";
            con = new System.Data.SqlClient.SqlConnection(TempClass.connectionString);
            con.Open();
            MessageNotice();
            UpdatePanelContact();


        }
        public void MessageNotice()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("Select * From  tbOfflineUsersMessage", con);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbOfflineUsersMessage");
                if (ds.Tables.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if ((dr["ToLoginName"].ToString() == TempClass.username))
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
                    OfflineMessages om = new OfflineMessages();

                    om.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        public void UpdatePanelContact()
        {

            try
            {
                Label lblInfo = new Label();
                lblInfo.Text = "Contacts :";
                lblInfo.Location = new System.Drawing.Point(8, 4);
                lblInfo.Size = new System.Drawing.Size(100, 16);
                pnlContacts.Controls.Clear();
                pnlContacts.Controls.Add(lblInfo);
                int i = 20;
                statusBar.Text = "Updating Contact panel...";

                string sql = "SELECT * FROM tbContactList WHERE loginName!=@loginname";
                SqlCommand SqlCommand1 = con.CreateCommand();
                SqlCommand1.CommandText = sql;

                SqlCommand1.Parameters.Add("@loginname", SqlDbType.VarChar, 100);
                SqlCommand1.Parameters[0].Value = TempClass.username;
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = SqlCommand1;
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbContactList");
                int var = ds.Tables["tbContactList"].Rows.Count;
                for (int j = 0; j < var; j++)
                {
                    OnlineContact.UserControl1 temp = new OnlineContact.UserControl1();
                    temp.Contact = ds.Tables["tbContactList"].Rows[j]["loginName"].ToString();
                    string str = ds.Tables["tbContactList"].Rows[j]["userStatus"].ToString();
                    if (str == "Online")
                    {
                        temp.Online = true;

                    }
                    else
                    {
                        temp.Online = false;
                    }
                    temp.Location = new System.Drawing.Point(8, i);
                    temp.Size = new System.Drawing.Size(pnlContacts.Width - 32, 16);

                    temp.DoubleClick += new System.EventHandler(this.Contact_Click);

                    pnlContacts.Controls.Add(temp);
                    i += 18;
                }

                statusBar.Text = "Contacts updated.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }


        }
        private void OpenFormMessage(string contact)
        {

            WindowList(contact);

        }
        protected override void OnClosing(CancelEventArgs e)
        {


            DialogResult reply = MessageBox.Show("Do you want to close the application?",
                 "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reply == DialogResult.Yes)
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






                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show("User cannot logout");

                }
                finally
                {
                    con.Close();
                    Application.Exit();
                }
            }
            if (reply == DialogResult.No)
            {
                e.Cancel = true;

            }
            base.OnClosing(e);

        }




        private void AdminStatus_Resize(object sender, EventArgs e)
        {
            pnlContacts.Width = this.Width - 24;
            pnlContacts.Height = this.Height - 88;
        }

        private void tmrMessageReceive_Tick(object sender, EventArgs e)
        {

            try
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


                if (res >= 1)
                {

                    string from = myDataSet.Tables["tbOnlineUsersMessage"].Rows[0]["FromLoginName"].ToString();
                    if (TempClass.usernameList.Contains(from))
                    {
                        ((SendMessage)TempClass.usernameList[from]).Focus();
                        ((SendMessage)TempClass.usernameList[from]).tmrMessageComing.Enabled = true;
                        TempClass.i = 1;


                    }
                    else
                    {

                        SendMessage frmMessage = new SendMessage(from);
                        frmMessage.contact = from;
                        frmMessage.Text = from + " - Instant Message";
                        TempClass.usernameList.Add(from, frmMessage);
                        frmMessage.Show();

                        frmMessage.tmrMessageComing.Enabled = true;
                        TempClass.i = 1;

                    }





                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }





        }

        private void tmrContactUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM tbContactListChanged";
                SqlCommand SqlCommand1 = con.CreateCommand();
                SqlCommand1.CommandText = sql;

                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = SqlCommand1;
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbContactListChanged");
                int var = ds.Tables["tbContactListChanged"].Rows.Count;
                if (var > 0)
                {
                    UpdatePanelContact();
                    SqlCommand SqlCommand2 = con.CreateCommand();
                    SqlCommand2.CommandText = "Truncate Table tbContactListChanged";
                    SqlCommand2.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }

        }

        private void pnlContacts_Resize(object sender, EventArgs e)
        {
            OnlineContact.UserControl1 o = new OnlineContact.UserControl1();

            o.Width = pnlContacts.Width - 32;
        }

        private void createNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUserInfo newUser = new NewUserInfo();
            this.Hide();
            newUser.Show();
        }

        private void viewAllUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllUsers users = new AllUsers();
            users.Show();
            this.Hide();
        }

        private void updateUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUsers users = new UpdateUsers();
            users.Show();
            this.Hide();
        }

        private void deleteUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUsers del = new DeleteUsers();
            del.Show();
            this.Hide();
        }





        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instant Chat created by Charu Verma");

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
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
                    tmrContactUpdate.Enabled = false;
                    SqlCommand2.ExecuteNonQuery();


                    Application.Exit();
                    System.Diagnostics.Process.Start(Application.ExecutablePath);


                }
                else
                {
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
