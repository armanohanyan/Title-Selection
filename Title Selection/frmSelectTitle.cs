using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Title_Selection
{
    public partial class frmSelectTitle : Form
    {
        public frmSelectTitle()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string localIP = GetLocalIPAddress();

            if (true)
            {
                MessageBox.Show("ՈՒսանողի անունը մուտքագրված չէ");
            }

            else if (txtFirstName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ՈՒսանողի անունը մուտքագրված չէ");
            }
            else if (txtLastName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ՈՒսանողի ազգանունը մուտքագրված չէ");
            }
            else if (txtMiddleName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ՈՒսանողի հայրանունը մուտքագրված չէ");
            }
            else
            {
                int id = Convert.ToInt32(lblTitleID.Text);
                string firstName = txtFirstName.Text.Trim();
                string middleName = txtMiddleName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                DateTime date = dateTimePicker1.Value;
                SQLHelper.SelectTheme(id, firstName, middleName, lastName, date);
                this.Close();
            }
        }

        private void frmSelectTitle_Load(object sender, EventArgs e)
        {
            lblTitleID.Enabled = false;
            lblTitleID.Visible = false;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
