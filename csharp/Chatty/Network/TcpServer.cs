using Chatty.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chatty.Network
{
    public class TcpServer
    {
        private CustomTcpListener tcpListener;
        private List<Socket> sockets;

        public TcpServer(string ipAddres, int port, ILogger logger)
        {
            IpAddres = ipAddres;
            Port = port;
            Logger = logger;

            sockets = new List<Socket>();
        }

        public string IpAddres { get; }
        public int Port { get; }
        public ILogger Logger { get; }

        public bool Started
        {
            get
            {
                return tcpListener != null ? tcpListener.Active : false;
            }
        }

        public async void Start()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(IpAddres);

                tcpListener = new CustomTcpListener(ipAddress, Port);

                tcpListener.Start();

                Logger.Log("TCPServer", $"Server is now listening at {tcpListener.LocalEndpoint}");
                Logger.Log("TCPServer", "Server is now waiting for a connection...");

                await Task.Run(async () =>
                {
                    await receiveClients();
                });
            }
            catch (InvalidOperationException ex)
            {
                // Server was while listening for a connection.
                // No need to do any special handling.
                if (ex.Message == $"Cannot access a disposed object.\r\nObject name: 'System.Net.Sockets.Socket'.")
                {
                    // Ignore;
                }
                else
                {
                    Logger.Log("TCPServer", ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("TCPServer", ex.Message);
            }
        }

        private async Task receiveClients()
        {
            while (tcpListener.Active)
            {
                try
                {
                    var socket = await tcpListener.AcceptSocketAsync();
                    Logger.Log("TCPServer", $"Client connected. ({socket.RemoteEndPoint})");

                    sockets.Add(socket);

                    var thread = new Thread(() =>
                    {
                        try
                        {
                            while (socket.Connected)
                            {
                                if (!socketConnected(socket))
                                {
                                    break;
                                }
                                listenForMessages(socket);
                            }

                            Logger.Log("TCPServer", $"{socket.RemoteEndPoint} disconnected");
                        }
                        catch(Exception ex)
                        {
                            Logger.Log(ex.Message);
                        }
                    });

                    thread.Start();
                }
                catch (Exception ex)
                {
                    Logger.Log("TCPServer", ex.Message);
                }
            }
        }

        private bool socketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }

        public void Stop()
        {
            if (tcpListener == null)
            {
                return;
            }

            if (tcpListener.Active)
            {
                try
                {
                    foreach(var socket in sockets)
                    {
                        socket?.Close();
                    }
                    tcpListener.Stop();
                }
                catch (Exception ex)
                {
                    Logger.Log("TCPServer", ex.Message);
                }
                finally
                {
                    Logger.Log("TCPServer", "Server stopped.");
                }
            }
        }

        private void listenForMessages(Socket socket)
        {
            try
            {
                byte[] data = new byte[1024];
                // Size is not really useful for now.
                int size = socket.Receive(data);
                var message = Encoding.ASCII.GetString(data);
                message = message.Replace("\0", "");
                message = message.TrimEnd(Environment.NewLine.ToCharArray());
                Logger.Log($"{socket.RemoteEndPoint}", message);
            }
            catch (Exception ex)
            {
                Logger.Log("TCPServer", ex.Message);
            }
        }
    }
}
