using Chatty.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Network
{
    public class CustomUdpClient
    {
        public CustomUdpClient(string ipAddress, int port, ILogger logger)
        {
            IpAddress = ipAddress;
            Port = port;
            Logger = logger;
        }

        public string IpAddress { get; }
        public int Port { get; }
        public ILogger Logger { get; }

        public void SendMessage(string message)
        {
            try
            {
                var udpClient = new UdpClient();

                var ipAddress = string.IsNullOrEmpty(IpAddress)
                    ? IPAddress.Any : IPAddress.Parse(IpAddress);

                udpClient.Connect(ipAddress, Port);
                byte[] data = Encoding.ASCII.GetBytes(message);
                udpClient.Send(data, data.Length);
            }
            catch(Exception ex)
            {
                Logger.Log("UdpClient", ex.Message);
            }
        }
    }
}
