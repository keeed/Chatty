using Chatty.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chatty.Network
{
    public class CustomUdpServer
    {
        private Thread _serverThread;
        private bool _running = false;
        private object _threadLock = new object();

        UdpClient udpClient;

        public CustomUdpServer(string ipAddress, int port, ILogger logger)
        {
            IpAddress = ipAddress;
            Port = port;
            Logger = logger;
        }

        public string IpAddress { get; }
        public int Port { get; }
        public ILogger Logger { get; }

        public bool IsRunning
        {
            get
            {
                if (_serverThread == null)
                {
                    return false;
                }

                return _serverThread.ThreadState == ThreadState.Running;
            }
        }

        public void Start()
        {
            lock (_threadLock)
            {
                _serverThread = new Thread(() => { startServer(); });

                _running = true;
                _serverThread.Start();
                
                Logger.Log("UdpServer", $"UDP Server listening at {IpAddress}:{Port}");
            }
        }

        private void startServer()
        {
            try
            {
                udpClient = new UdpClient(Port);
            }
            catch( Exception ex)
            {
                Logger.Log("UDPServer", ex.Message);
                return;
            }

            while (_running)
            {
                try
                {
                    IPAddress ipaddress = string.IsNullOrEmpty(IpAddress) 
                        ? IPAddress.Any : IPAddress.Parse(IpAddress);
                    IPEndPoint remoteIpEndPoint = new IPEndPoint(ipaddress, Port);
                    byte[] data = udpClient.Receive(ref remoteIpEndPoint);
                    string stringData = Encoding.ASCII.GetString(data);
                    stringData = stringData.Replace("\0", "");
                    stringData = stringData.TrimEnd(Environment.NewLine.ToCharArray());
                    Logger.Log($"{remoteIpEndPoint.Address.ToString()}:{remoteIpEndPoint.Port}", stringData);
                }
                catch(Exception ex)
                {
                    Logger.Log("UDPServer", ex.Message);
                }
            }
        }

        public void Stop()
        {
            lock (_threadLock)
            {
                if (_serverThread.ThreadState != ThreadState.Running)
                {
                    return;
                }

                _running = false;
                try
                {
                    _serverThread.Abort();

                    if (udpClient != null)
                    {
                        udpClient.Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    // In case we encounter any error.
                    Logger.Log("UdpServer", ex.Message);
                }
            }
        }
    }
}
