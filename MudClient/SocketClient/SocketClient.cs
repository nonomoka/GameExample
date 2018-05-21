using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MudClient
{
    public class SocketClient
    {

        public Socket clientSocket;
        private IPAddress ip;
        private int port;
        private readonly int dataSize;
        private byte[] data;

        public delegate void ConnectionEventHandler();
        public event ConnectionEventHandler ClientConnected;
        public event ConnectionEventHandler ClientDisconnected;

        public delegate void ConnectionBlockedEventHandler(IPEndPoint endPoint);
        public event ConnectionBlockedEventHandler ConnectionBlocked;

        public delegate void MessageReceivedEventHandler(string message);
        public event MessageReceivedEventHandler MessageReceived;

        public SocketClient(IPAddress ip, int port,int dataSize = 1024)
        {
            this.ip = ip;
            this.port = port;
            this.dataSize = dataSize;
            this.data = new byte[dataSize];
            this.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Start()
        {
            clientSocket.Connect(new IPEndPoint(this.ip, this.port));
        }

    }
}
