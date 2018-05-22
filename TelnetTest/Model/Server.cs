using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TelnetTest.Model
{
    public enum EConnectionType
    {
        Client = 0,
        Server = 1,
    }
    public class Server
    {
        /// <summary>
        /// End of line constant.
        /// </summary>
        public const string END_LINE = "\r\n";
        /// <summary>
        /// Telnet's default port.
        /// </summary>
        public int port;
        /// <summary>
        /// Server's main socket.
        /// </summary>
        public Socket mainSocket;
        /// <summary>
        /// The IP on which to listen.
        /// </summary>
        public IPAddress ip;
        /// <summary>
        /// The default data size for received data.
        /// </summary>
        private readonly int dataSize;
        /// <summary>
        /// Contains the received data.
        /// </summary>
        private byte[] data;
        /// <summary>
        /// True for allowing incoming connections;
        /// false otherwise.
        /// </summary>
        private bool acceptIncomingConnections;
        /// <summary>
        /// Contains all connected clients indexed
        /// by their socket.
        /// </summary>
        private Dictionary<Socket, Client> clientsList;

        public delegate void ConnectionEventHandler(Client c);
        /// <summary>
        /// Occurs when a client is connected.
        /// </summary>
        public event ConnectionEventHandler ClientConnected;
        /// <summary>
        /// Occurs when a client is disconnected.
        /// </summary>
        public event ConnectionEventHandler ClientDisconnected;
        public delegate void ConnectionBlockedEventHandler(IPEndPoint endPoint);
        /// <summary>
        /// Occurs when an incoming connection is blocked.
        /// </summary>
        public event ConnectionBlockedEventHandler ConnectionBlocked;
        public delegate void MessageReceivedEventHandler(Client c, string message);
        /// <summary>
        /// Occurs when a message is received.
        /// </summary>
        public event MessageReceivedEventHandler MessageReceived;

        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="ip">The IP on which to listen to.</param>
        /// <param name="dataSize">Data size for received data.</param>
        public Server(EConnectionType type,IPAddress ip,int port, int dataSize = 1024)
        {
            this.port = port;
            this.ip = ip;
            this.dataSize = dataSize;
            this.data = new byte[dataSize];

            switch (type)
            {
                case EConnectionType.Client:
                    break;
                case EConnectionType.Server:
                    this.clientsList = new Dictionary<Socket, Client>();
                    this.acceptIncomingConnections = true;
                    break;
            }
            this.mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        public void ServerStart()
        {
            mainSocket.Bind(new IPEndPoint(ip, port));
            mainSocket.Listen(0);
            mainSocket.BeginAccept(new AsyncCallback(HandleIncomingConnection), mainSocket);
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        public void Stop()
        {
            mainSocket.Close();
        }

        /// <summary>
        /// Returns whether incoming connections
        /// are allowed.
        /// </summary>
        /// <returns>True is connections are allowed;
        /// false otherwise.</returns>
        public bool IncomingConnectionsAllowed()
        {
            return acceptIncomingConnections;
        }

        /// <summary>
        /// Denies the incoming connections.
        /// </summary>
        public void DenyIncomingConnections()
        {
            this.acceptIncomingConnections = false;
        }

        /// <summary>
        /// Allows the incoming connections.
        /// </summary>
        public void AllowIncomingConnections()
        {
            this.acceptIncomingConnections = true;
        }

        /// <summary>
        /// Clears the screen for the specified
        /// client.
        /// </summary>
        /// <param name="c">The client on which
        /// to clear the screen.</param>
        public void ClearClientScreen(Client c)
        {
            SendMessageToClient(c, "\u001B[1J\u001B[H");
        }

        /// <summary>
        /// Sends a text message to the specified
        /// client.
        /// </summary>
        /// <param name="c">The client.</param>
        /// <param name="message">The message.</param>
        public void SendMessageToClient(Client c, string message)
        {
            Socket clientSocket = GetSocketByClient(c);
            SendMessageToSocket(clientSocket, message);
        }

        /// <summary>
        /// Sends a text message to the specified
        /// socket.
        /// </summary>
        /// <param name="s">The socket.</param>
        /// <param name="message">The message.</param>
        private void SendMessageToSocket(Socket s, string message)
        {
            System.Console.WriteLine(message);
            byte[] data = Encoding.GetEncoding("Big5").GetBytes(message);
            SendBytesToSocket(s, data);
        }

        /// <summary>
        /// Sends bytes to the specified socket.
        /// </summary>
        /// <param name="s">The socket.</param>
        /// <param name="data">The bytes.</param>
        private void SendBytesToSocket(Socket s, byte[] data)
        {
            s.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendData), s);
        }

        /// <summary>
        /// Sends a message to all connected clients.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SendMessageToAll(string message)
        {
            foreach (Socket s in clientsList.Keys)
            {
                try { SendMessageToSocket(s, message); }
                catch { clientsList.Remove(s); }
            }
        }

        /// <summary>
        /// Gets the client by socket.
        /// </summary>
        /// <param name="clientSocket">The client's socket.</param>
        /// <returns>If the socket is found, the client instance
        /// is returned; otherwise null is returned.</returns>
        private Client GetClientBySocket(Socket clientSocket)
        {
            Client c;

            if (!clientsList.TryGetValue(clientSocket, out c))
                c = null;

            return c;
        }

        /// <summary>
        /// Gets the socket by client.
        /// </summary>
        /// <param name="client">The client instance.</param>
        /// <returns>If the client is found, the socket is
        /// returned; otherwise null is returned.</returns>
        private Socket GetSocketByClient(Client client)
        {
            Socket s;

            s = clientsList.FirstOrDefault(x => x.Value.GetClientID() == client.GetClientID()).Key;

            return s;
        }

        /// <summary>
        /// Kicks the specified client from the server.
        /// </summary>
        /// <param name="client">The client.</param>
        public void KickClient(Client client)
        {
            CloseSocket(GetSocketByClient(client));
            ClientDisconnected(client);
        }

        /// <summary>
        /// Closes the socket and removes the client from
        /// the clients list.
        /// </summary>
        /// <param name="clientSocket">The client socket.</param>
        private void CloseSocket(Socket clientSocket)
        {
            clientSocket.Close();
            clientsList.Remove(clientSocket);
        }

        /// <summary>
        /// Handles an incoming connection.
        /// If incoming connections are allowed,
        /// the client is added to the clients list
        /// and triggers the client connected event.
        /// Else, the connection blocked event is
        /// triggered.
        /// </summary>
        private void HandleIncomingConnection(IAsyncResult result)
        {
            try
            {
                Socket oldSocket = (Socket)result.AsyncState;

                if (acceptIncomingConnections)
                {
                    Socket newSocket = oldSocket.EndAccept(result);

                    uint clientID = (uint)clientsList.Count + 1;
                    Client client = new Client(clientID, (IPEndPoint)newSocket.RemoteEndPoint);
                    clientsList.Add(newSocket, client);

                    // Do Echo
                    // Do Remote Flow Control
                    // Will Echo
                    // Will Suppress Go Ahead
                    SendBytesToSocket(
                        newSocket,
                        new byte[] { 0xff, 0xfd, 0x01, 0xff, 0xfd, 0x21, 0xff, 0xfb, 0x01, 0xff, 0xfb, 0x03 }
                    );
                    client.ResetReceivedData();
                    ClientConnected(client);
                    mainSocket.BeginAccept(new AsyncCallback(HandleIncomingConnection), mainSocket);
                }
                else
                {
                    ConnectionBlocked((IPEndPoint)oldSocket.RemoteEndPoint);
                }
            }

            catch { }
        }

        /// <summary>
        /// Sends data to a socket.
        /// </summary>
        private void SendData(IAsyncResult result)
        {
            try
            {
                Socket sendSocket = (Socket)result.AsyncState;
                sendSocket.EndSend(result);
                sendSocket.BeginReceive(data, 0, dataSize, SocketFlags.None, new AsyncCallback(ReceiveData), sendSocket);
            }

            catch { }
        }

        /// <summary>
        /// Receives and processes data from a socket.
        /// It triggers the message received event in
        /// case the client pressed the return key.
        /// </summary>
        private void ReceiveData(IAsyncResult result)
        {
            try
            {
                Socket recSocket = (Socket)result.AsyncState;
                Client client = GetClientBySocket(recSocket);

                int bytesReceived = recSocket.EndReceive(result);

                if (bytesReceived == 0)
                {
                    CloseSocket(recSocket);
                    mainSocket.BeginAccept(new AsyncCallback(HandleIncomingConnection), mainSocket);
                }
                else if (data[0] < 0xF0) //小於0xF0 表示為單字節(通常為英數字)
                {
                    string receivedData = client.GetReceivedData();

                    // 0x2E = '.', 
                    // 0x0D = carriage return, 
                    // 0x0A = new line
                    if ((data[0] == 0x2E && data[1] == 0x0D && receivedData.Length == 0) ||
                        (data[0] == 0x0D && data[1] == 0x0A))
                    {
                        //sendMessageToSocket(clientSocket, "\u001B[1J\u001B[H");
                        MessageReceived(client, client.GetReceivedData());
                        client.ResetReceivedData();
                    }
                    else
                    {
                        // 0x08 => backspace character
                        if (data[0] == 0x08)
                        {
                            if (receivedData.Length > 0)
                            {
                                client.RemoveLastCharacterReceived();
                                SendBytesToSocket(recSocket, new byte[] { 0x08, 0x20, 0x08 });
                            }

                            else
                                recSocket.BeginReceive(data, 0, dataSize, SocketFlags.None, new AsyncCallback(ReceiveData), recSocket);
                        }
                        // 0x7F => delete character
                        else if (data[0] == 0x7F)
                            recSocket.BeginReceive(data, 0, dataSize, SocketFlags.None, new AsyncCallback(ReceiveData), recSocket);
                        else
                        {
                            client.AppendReceivedData(Encoding.GetEncoding("Big5").GetString(data, 0, bytesReceived));

                            // Echo back the received character
                            // if client is not writing any password
                            if (client.GetCurrentStatus() != EClientStatus.Password)
                                SendBytesToSocket(recSocket, new byte[] { data[0] });

                            // Echo back asterisks if client is
                            // writing a password
                            else
                                SendMessageToSocket(recSocket, "*");

                            recSocket.BeginReceive(data, 0, dataSize, SocketFlags.None, new AsyncCallback(ReceiveData), recSocket);
                        }
                    }
                }
                else
                    recSocket.BeginReceive(data, 0, dataSize, SocketFlags.None, new AsyncCallback(ReceiveData), recSocket);
            }
            catch { }
        }
    }
}
