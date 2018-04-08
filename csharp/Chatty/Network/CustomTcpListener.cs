using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Network
{
    public class CustomTcpListener : TcpListener
    {
        public CustomTcpListener(IPEndPoint localEP) : base(localEP)
        {
        }

        public CustomTcpListener(IPAddress localaddr, int port) : base(localaddr, port)
        {
        }

        public new bool Active
        {
            get
            {
                return base.Active;
            }
        }
    }
}
