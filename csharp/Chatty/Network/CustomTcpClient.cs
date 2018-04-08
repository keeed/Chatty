using Chatty.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Network
{
    public class CustomTcpClient
    {
        private TcpClient _tcpClient;
        private Stream _stream;

        public CustomTcpClient(string ipAddress, int port, ILogger logger, IAlert alert)
        {
            IpAddress = ipAddress;
            Port = port;
            Logger = logger;
            Alert = alert;
        }

        public string IpAddress { get; }
        public int Port { get; }
        public ILogger Logger { get; }
        public IAlert Alert { get; }

        public bool IsConnected
        {
            get
            {
                try
                {
                    if (_tcpClient == null)
                    {
                        return false;
                    }
                    return _tcpClient.Connected;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }

        public void Connect()
        {
            try
            {
                _tcpClient = new TcpClient();

                _tcpClient.Connect(IpAddress, Port);

                _stream = _tcpClient.GetStream();

                Alert.Alert(
                    "Success",
                    "TCPClient",
                    $"Successfully connected to {IpAddress}:{Port}",
                    System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Alert.Alert(
                    "Error",
                    "TCPClient",
                    $"Cannot connect to {IpAddress}:{Port} {Environment.NewLine} Reason: {ex.Message}",
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public void Disconnect()
        {
            try
            {
                //_stream?.Close();
                _tcpClient?.Close();
            }
            catch (Exception ex)
            {
                Alert.Alert(
                    "Error",
                    "TCPClient",
                    $"Error encountered while disconnecting from {IpAddress}:{Port} {Environment.NewLine} Reason: {ex.Message}",
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public async void SendMessage(string message, Action errorCallBack)
        {
            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(message + Environment.NewLine);
                _stream.Write(data, 0, data.Length);
                await _stream.FlushAsync();
            }
            catch (Exception ex)
            {
                Alert.Alert(
                    "Error",
                    "TCPClient",
                    $"Cannot send message to {IpAddress}:{Port} {Environment.NewLine} Reason: {ex.Message}",
                    System.Windows.Forms.MessageBoxIcon.Error);

                errorCallBack();
                Disconnect();
            }
        }
    }
}
