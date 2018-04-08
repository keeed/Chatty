using Chatty.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Servers
{
    public class TCPServer
    {
        protected TcpListener TcpListener { get; set; }

        public TCPServer(string ipAddress, int port, ILogger logger)
        {
            IpAddress = ipAddress;
            Port = port;
            Logger = logger;
        }

        public string IpAddress { get; }
        public int Port { get; }
        public ILogger Logger { get; }

        public void Start()
        {
            try
            {
                // Convert the given string IP Address to an actual IP Address.
                IPAddress ipAddress = IPAddress.Parse(IpAddress);

                TcpListener = new TcpListener(ipAddress, Port);

                Logger.Log("TCP Server", $"Attempting to start server at {ipAddress}:{Port}");

                TcpListener.Start();

                Logger.Log("TCP Server", $"Server now running at {ipAddress}:{Port}");
                Logger.Log("TCP Server", $"Endpoint is {TcpListener.LocalEndpoint}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Stop()
        {
            try
            {
                if (TcpListener != null)
                {
                    TcpListener.Stop();
                }
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }
    }
}
