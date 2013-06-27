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
    public partial class OfflineMessages : Form
    {
        private System.Data.SqlClient.SqlConnection con;
        private System.Data.DataSet myDataSet;
        private SqlDataAdapter da;
        public OfflineMessages()
        {
            InitializeComponent();
            con = new System.Data.SqlClient.SqlConnection(TempClass.connectionString);
            
        }
        protected override void OnClosing(CancelEventArgs e)
        {

            this.Hide();
            base.OnClosing(e);
            btnOK_Click(this, e);
        }

        private void OfflineMessages_Load(object sender, EventArgs e)
        {
            con.Open();
            string sql = "SELECT * FROM tbOfflineUsersMessage WHERE ToLoginName=@tologinname";
            SqlCommand SqlCommand1 = con.CreateCommand();
            SqlCommand1.CommandText = sql;
            int res;
            SqlCommand1.Parameters.Add("@tologinname", SqlDbType.VarChar, 100);
            SqlCommand1.Parameters[0].Value = TempClass.username;
            da = new SqlDataAdapter();
            da.SelectCommand = SqlCommand1;
            myDataSet = new System.Data.DataSet();
            res = da.Fill(myDataSet, "tbOfflineUsersMessage");

            for (int i = 0; i < res; i++)
            {

                string from = myDataSet.Tables["tbOfflineUsersMessage"].Rows[i]["FromLoginName"].ToString();

                string msg = myDataSet.Tables["tbOfflineUsersMessage"].Rows[i]["Message"].ToString();

                rtbOfflineMessages.AppendText(from + " : ");
                rtbOfflineMessages.AppendText(msg + " \n");
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            SqlCommand SqlCommand1 = con.CreateCommand();
            SqlCommand1.CommandText = "DELETE FROM tbOfflineUsersMessage WHERE ToLoginName=@tologinname";
            int res;
            SqlCommand1.Parameters.Add("@tologinname", SqlDbType.VarChar, 100);
            SqlCommand1.Parameters[0].Value = TempClass.username;
            res = SqlCommand1.ExecuteNonQuery();
            con.Close();
           
            this.Hide();

        }
    }
}
