using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace InstantChat
{
    public partial class NetworkSetting : Form
    {
        public NetworkSetting()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIP.Text == "")
                {
                    MessageBox.Show("Please Provide IP Address of Server Machine.");

                    txtIP.Focus();
                }
                else
                {

                    TempClass.hostIP = txtIP.Text;
                    FileStream fs = new FileStream("NetSet.txt", FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(TempClass.hostIP);
                    bw.Close();
                    fs.Close();
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }

        }
            
    }
}
