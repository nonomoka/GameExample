using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Model
{
    public class ClientBase
    { 
        //與伺服器連線的Socket
        private Socket Sock;
        //資料緩衝區
        private Byte[] Data = new Byte[1024];
        //開始連線
        public void Start()
        {
            Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Sock.Connect("59.127.188.199", 8250);
            //開始接收
            Sock.BeginReceive(Data, 0, 1024, SocketFlags.None, EndRead, null);
        }
        //結束接收
        public void EndRead(IAsyncResult I)
        {
            int len = Sock.EndReceive(I);
            ServerBase.Frm.ShowText("網路訊息>>" + Encoding.UTF8.GetString(Data, 0, len));
            Sock.BeginReceive(Data, 0, 1024, SocketFlags.None, EndRead, null);
        }
        //開始傳送
        public void Send(String msg)
        {
            Byte[] Buffer = Encoding.UTF8.GetBytes(msg);
            Sock.BeginSend(Buffer, 0, Buffer.Length, SocketFlags.None, EndSend, Sock);
        }
        //結束傳送
        private void EndSend(IAsyncResult Result)
        {
            Sock.EndSend(Result);
        }
    }
}
}
