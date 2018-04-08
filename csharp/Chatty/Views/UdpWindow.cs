using Chatty.Logging;
using Chatty.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatty.Views
{
    public partial class UdpWindow : Form, ILogger, IAlert
    {
        private CustomUdpServer _server;
        private CustomUdpClient _client;

        public UdpWindow()
        {
            InitializeComponent();

            textboxChatInput.Enabled = false;
            buttonSend.Enabled = false;
        }

        public void Alert(string title, string sender, string message, MessageBoxIcon messageBoxIcon)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<string, string, string, MessageBoxIcon>(Alert),
                    new object[]
                    {
                        title, sender, message, messageBoxIcon
                    });
            }
            else
            {
                MessageBox.Show(this, $"{sender} - {message}", title, MessageBoxButtons.OK, messageBoxIcon);
            }
        }

        public void Alert(string title, string message, MessageBoxIcon messageBoxIcon)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<string, string, MessageBoxIcon>(Alert),
                    new object[]
                    {
                        title, message, messageBoxIcon
                    });
            }
            else
            {
                MessageBox.Show(this, message, title, MessageBoxButtons.OK, messageBoxIcon);
            }
        }

        public void Log(string message)
        {
            try
            {
                if (textboxChat.InvokeRequired)
                {
                    Invoke(new Action<string>(Log), new object[] { message });
                }
                else
                {
                    textboxChat.AppendText($"[{DateTime.Now.ToString()}] - {message} {Environment.NewLine}");
                }
            }
            catch (Exception)
            {
                // Problematic for threads...
            }
        }

        public void Log(string sender, string message)
        {
            try
            {
                if (textboxChat.InvokeRequired)
                {
                    Invoke(new Action<string, string>(Log), new object[] { sender, message });
                }
                else
                {
                    textboxChat.AppendText($"[{DateTime.Now.ToString()}] - [{sender}] - {message} {Environment.NewLine}");
                }
            }
            catch (Exception)
            {
                // Problematic for threads...
            }
        }

        private void buttonServerToggle_Click(object sender, EventArgs e)
        {
            object criticalSection = new object();

            lock (criticalSection)
            {
                if (_server == null)
                {
                    string ipAddress = textboxServerIP.Text;
                    int port = 0;
                    int.TryParse(textboxPort.Text, out port);

                    _server = new CustomUdpServer(ipAddress, port, this);

                    _server.Start();
                    updateServerStatus("Running", "Stop Server", Color.Green);
                }
                else if (!_server.IsRunning)
                {
                    string ipAddress = textboxServerIP.Text;
                    int port = 0;
                    int.TryParse(textboxPort.Text, out port);

                    _server = new CustomUdpServer(ipAddress, port, this);

                    _server.Start();
                    updateServerStatus("Running", "Stop Server", Color.Green);
                }
                else
                {
                    _server.Stop();
                    updateServerStatus("Not Running", "Start Server", Color.Red);
                }
            }
        }

        private void updateServerStatus(string serverStatus, string buttonToggleText, Color foreColor)
        {
            if (buttonServerToggle.InvokeRequired)
            {
                Invoke(new Action<string, string, Color>(updateServerStatus),
                    new object[] { serverStatus, buttonToggleText, foreColor });
            }
            else
            {
                buttonServerToggle.Text = buttonToggleText;
                labelServerStatus.Text = serverStatus;
                labelServerStatus.ForeColor = foreColor;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void sendMessage()
        {
            try
            {
                _client.SendMessage(textboxChatInput.Text);
                Log("You", textboxChatInput.Text);
                textboxChatInput.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void textboxChatInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                sendMessage();
            }
        }

        private void UdpWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _server.Stop();
            }
            catch (Exception)
            {

            }
        }

        private void buttonCreateClient_Click(object sender, EventArgs e)
        {
            int port = 0;
            int.TryParse(textboxClientPort.Text, out port);
            _client = new CustomUdpClient(textboxClientIP.Text, port, this);

            MessageBox.Show(
                this, 
                "UDP Client Created", 
                "Success", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);

            textboxChatInput.Enabled = true;
            buttonSend.Enabled = true;
        }
    }
}