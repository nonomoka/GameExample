using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TelnetTest.Model;

namespace TelnetTest
{
    class Program
    {
        private static Server s;

        static void Main(string[] args)
        {
            s = new Server(EConnectionType.Server,IPAddress.Any,23);
            s.ClientConnected += clientConnected;
            s.ClientDisconnected += clientDisconnected;
            s.ConnectionBlocked += connectionBlocked;
            s.MessageReceived += messageReceived;
            s.ServerStart();

            Console.WriteLine("SERVER STARTED: " + DateTime.Now);

            do
            {
                ; // nothing really
            } while (Console.ReadKey(true).KeyChar != 'q');

            s.Stop();
        }

        private static void clientConnected(Client c)
        {
            Console.WriteLine("CONNECTED: " + c);

            s.SendMessageToClient(c, "Telnet Server\r\n歡迎進入這個世界:\r\nLogin: ");
        }

        private static void clientDisconnected(Client c)
        {
            Console.WriteLine("DISCONNECTED: " + c);
        }

        private static void connectionBlocked(IPEndPoint ep)
        {
            Console.WriteLine(string.Format("BLOCKED: {0}:{1} at {2}", ep.Address, ep.Port, DateTime.Now));
        }

        private static void messageReceived(Client c, string message)
        {
            Console.WriteLine("MESSAGE: " + message);

            if (message.ToLower() != "quit")
            {
                EClientStatus status = c.GetCurrentStatus();

                switch (c.GetCurrentStatus())
                {
                    case EClientStatus.Login:
                        //TODO:帳號驗證 Default:nono
                        if (message == "nono")
                        {
                            s.SendMessageToClient(c, "\r\nPassword: ");
                            c.SetStatus(EClientStatus.Password);
                        }
                        else
                        {
                            s.SendMessageToClient(c, "\r\n帳號錯誤，請重新輸入!!\r\nLogin:");
                        }
                        break;

                    case EClientStatus.Password:
                        //TODO:密碼驗證 Default:nono
                        if (message == "nono")
                        {
                            s.SendMessageToClient(c, "\r\n登入成功\r\n");
                            c.SetStatus(EClientStatus.LoggedIn);
                        }
                        else
                        {
                            s.SendMessageToClient(c, "\r\n密碼錯誤，請重新輸入!!\r\nPassword:");
                        }
                        break;

                     case EClientStatus.LoggedIn:
                        s.SendMessageToClient(c, "\r\n你打啥我看不懂?!\r\n > ");
                        break;
                } 
            }
            else
                s.KickClient(c);
        }
    }
}
