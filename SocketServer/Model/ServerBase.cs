using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer.Model
{
    public class ServerBase
    {
        //接收連線的Socket
        private Socket Sock;
        //接收連線的Port(通訊埠)
        private int Port = 8250;
        //聊天室使用者清單
        private List<User> Users = new List<User>();
        //做為顯示訊息的視窗
        public static Form Frm;
        //啟動連線
        public void Start(Form F)
        {
            //設定視窗
            Frm = F;
            //設定Socket
            Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //設定端口
            IPEndPoint EP = new IPEndPoint(IPAddress.Any, Port);
            //綁住端口
            Sock.Bind(EP);
            //開始接新連線
            Sock.Listen(1000);
            Sock.BeginAccept(newConnection, null);
        }
        private void newConnection(IAsyncResult Result)
        {
            //新連線取得，並結束接收新連線
            Socket newSock = Sock.EndAccept(Result);
            //開始接收新連線
            Sock.BeginAccept(newConnection, null);
            //由新連線建立新使用者
            User X = new User(newSock);
            //加入到使用者清單
            Users.Add(X);
            //開始接受使用者傳送的資料
            X.Sock.BeginReceive(X.Data, 0, 1024, SocketFlags.None, EndRead, X);
        }
        private void EndRead(IAsyncResult Result)
        {
            //收到資料，分析使用者
            User X = (User)Result.AsyncState;
            //取得接受的資料量，並停止接收資料
            int Len = X.Sock.EndReceive(Result);
            if (Len > 0)
            {//有資料
                String MSG = Encoding.UTF8.GetString(X.Data, 0, Len);//將位元資料轉成字串
                //Frm.ShowText("伺服器::"+MSG);
                //廣播訊息
                foreach (User Q in Users)
                {
                    Send(Q.Sock, MSG);
                }
            }
            else
            {//對方結束連線
                Frm.ShowText("某人結束連線!");
                //廣播訊息
                foreach (User Q in Users)
                {
                    Send(Q.Sock, "某人結束連線!");
                }
                //移除離線使用者
                Users.Remove(X);
            }
            //繼續接收資料
            X.Sock.BeginReceive(X.Data, 0, 1024, SocketFlags.None, EndRead, X);
        }
        //傳送資料
        private void Send(Socket Sock, String msg)
        {
            Byte[] Buffer = Encoding.UTF8.GetBytes(msg);//轉成位元資料
            Sock.BeginSend(Buffer, 0, Buffer.Length, SocketFlags.None, EndSend, Sock);//開始傳送
        }
        private void EndSend(IAsyncResult Result)
        {
            //傳送完畢，停止傳送
            ((Socket)Result.AsyncState).EndSend(Result);
        }
    }

    class User
    {
        //使用者Socket
        public Socket Sock;
        //資料緩衝區
        public Byte[] Data = new Byte[1024];
        //建構子
        public User(Socket s)
        {
            Sock = s;
        }
    }
}
