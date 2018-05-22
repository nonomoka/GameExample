using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncTCPServer server = new AsyncTCPServer();
            server.Start();
            System.Console.ReadLine();
        }
    }


    public class AsyncTCPServer
    {
        public void Start()
        {
            //創建通訊端  
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 23);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //綁定埠和IP  
            socket.Bind(ipe);
            //設置監聽  
            socket.Listen(10);
            //連接用戶端  
            AsyncAccept(socket);
        }

        /// <summary>  
        /// 連接到用戶端  
        /// </summary>  
        /// <param name="socket"></param>  
        private void AsyncAccept(Socket socket)
        {
            socket.BeginAccept(asyncResult =>
            {
                //獲取用戶端通訊端  
                Socket client = socket.EndAccept(asyncResult);
                Console.WriteLine(string.Format("用戶端{0}請求連接...", client.RemoteEndPoint));
                AsyncSend(client, "伺服器收到連接請求");
                AsyncSend(client, string.Format("歡迎你{0}", client.RemoteEndPoint));
                AsyncReveive(client);
            }, null);
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="client"></param>  
        private void AsyncReveive(Socket socket)
        {
            byte[] data = new byte[1024];
            try
            {
                //開始接收消息  
                socket.BeginReceive(data, 0, data.Length, SocketFlags.None,
                asyncResult =>
                {
                    int length = socket.EndReceive(asyncResult);
                    Console.WriteLine(string.Format("用戶端發送消息:{0}", Encoding.GetEncoding("Big5").GetString(data)));
                }, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>  
        /// 發送消息  
        /// </summary>  
        /// <param name="client"></param>  
        /// <param name="p"></param>  
        private void AsyncSend(Socket client, string p)
        {
            if (client == null || p == string.Empty) return;
            //數據轉碼  
            byte[] data = new byte[1024];
            data = Encoding.GetEncoding("Big5").GetBytes(p);
            try
            {
                //開始發送消息  
                client.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>
                {
                    //完成消息發送  
                    int length = client.EndSend(asyncResult);
                    //輸出消息  
                    Console.WriteLine(string.Format("伺服器發出消息:{0}", p));
                }, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

