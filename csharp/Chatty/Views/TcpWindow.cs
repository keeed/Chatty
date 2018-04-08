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
    public partial class TcpWindow : Form, ILogger, IAlert
    {
        private TcpServer _server;
        private CustomTcpClient _customTcpClient;

        public TcpWindow()
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
            catch(Exception)
            {

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
            catch(Exception)
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
                    startServer();
                }
                else if (!_server.Started)
                {
                    startServer();
                }
                else if (_server.Started)
                {
                    try
                    {
                        _server.Stop();
                    }
                    catch (Exception ex)
                    {
                        Log(ex.Message);
                    }
                    finally
                    {
                        updateServerStatus("Not Running", "Start Server", Color.Red);
                    }
                }
                else
                {
                    updateServerStatus("Not Running", "Start Server", Color.Red);

                }
            }
        }

        private void startServer()
        {
            Task.Run(() =>
            {
                try
                {
                    string ipAddress = textboxServerIP.Text;
                    int port = int.Parse(textboxPort.Text);

                    _server = new TcpServer(ipAddress, port, this);
                    _server.Start();

                    updateServerStatus("Running", "Stop Server", Color.Green);
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                }
            });
        }

        private void onClientError()
        {

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

        private void buttonClientConnect_Click(object sender, EventArgs e)
        { 
            object criticalSection = new object();

            lock (criticalSection)
            {
                if (_customTcpClient == null)
                {
                    connectToClient();
                }
                else if (!_customTcpClient.IsConnected)
                {
                    connectToClient();
                }
                else
                {
                    disconnectClient();
                }
            }
        }

        private void disconnectClient()
        {
            try
            {
                _customTcpClient.Disconnect();

                clientDisconnected();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void connectToClient()
        {
            object criticalSection = new object();
            lock (criticalSection)
            {
                Task.Run(() =>
                {
                    try
                    {
                        string ipAddress = textboxClientIP.Text;
                        int port = int.Parse(textboxClientPort.Text);
                        _customTcpClient = new CustomTcpClient(ipAddress, port, this, this);

                        _customTcpClient.Connect();
                        clientConnected();
                    }
                    catch (Exception ex)
                    {
                        Log(ex.Message);
                    }
                });
            }
        }

        private void clientConnected()
        {
            if (this.buttonClientConnect.InvokeRequired)
            {
                Invoke(new Action(clientConnected));
            }
            else
            {
                labelClientStatus.Text = "Connected";
                labelClientStatus.ForeColor = Color.Green;
                buttonClientConnect.Text = "Disconnect";

                textboxChatInput.Enabled = true;
                buttonSend.Enabled = true;
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
                _customTcpClient.SendMessage(textboxChatInput.Text, clientDisconnected);
                Log("You", textboxChatInput.Text);
                textboxChatInput.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                clientDisconnected();
            }
        }

        private void clientDisconnected()
        {
            if (this.buttonClientConnect.InvokeRequired)
            {
                Invoke(new Action(clientDisconnected));
            }
            else
            {
                labelClientStatus.Text = "Not Connected";
                labelClientStatus.ForeColor = Color.Red;
                buttonClientConnect.Text = "Connect";

                textboxChatInput.Enabled = false;
                buttonSend.Enabled = false;
            }
        }

        private void textboxChatInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                sendMessage();
            }
        }

        private void TcpWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _server.Stop();
            }
            catch( Exception)
            {
                // Swallow exception
            }
        }
    }
}