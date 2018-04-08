using Chatty.Views;
using System;
using System.Windows.Forms;

namespace Chatty
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void buttonLaunchTcp_Click(object sender, EventArgs e)
        {
            try
            {
                var tcpClient = new TcpWindow();

                tcpClient.StartPosition = FormStartPosition.CenterScreen;

                tcpClient.Visible = true;
                tcpClient.Show(this);
            }
            catch(Exception)
            {
                // Swallow exception hehe :)
            }
        }

        private void buttonLaunchUdp_Click(object sender, EventArgs e)
        {
            try
            {
                var tcpClient = new UdpWindow();

                tcpClient.StartPosition = FormStartPosition.CenterScreen;

                tcpClient.Visible = true;
                tcpClient.Show(this);
            }
            catch (Exception)
            {
                // Swallow exception hehe :)
            }
        }
    }
}
