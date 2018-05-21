using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelnetTest.Model;

namespace MudClient
{
    public partial class Form1 : Form
    {
        //對話框記錄
        AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
        private static Server s;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void txbInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string input = this.txbInputBox.Text.Trim();
                if (!String.IsNullOrWhiteSpace(input))
                {
                    this.txbInputBox.AutoCompleteCustomSource.Add(input);
                }
                byte[] data = Encoding.GetEncoding("Big5").GetBytes(input);
                //client.clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(sendData), client.clientSocket);
                this.txbInputBox.Text = String.Empty;
                this.txbInputBox.Focus();
            }
        }
        #region 連線部分
        private void btnConnection_Click(object sender, EventArgs e)
        {
            s = new Server(IPAddress.Parse(txbServerIP.Text.Trim()));
            s.ClientConnected += ClientConnected;
            s.ClientStart(txbServerIP.Text.Trim(), int.Parse(txbPort.Text.Trim()));
            //client = new SocketClient(IPAddress.Parse(txbServerIP.Text.Trim()), int.Parse(txbPort.Text.Trim()));
            //client.ClientConnected += clientConnected;
            //client.ClientDisconnected += clientDisconnected;
            //client.ConnectionBlocked += connectionBlocked;
            //client.MessageReceived += messageReceived;
            //client.Start();
        }

        private void ClientConnected(Client c)
        {
            this.txbMainWindow.AppendText(c.getReceivedData());
        }

        private void clientDisconnected(Client c)
        {
            this.txbMainWindow.AppendText(c.getReceivedData());
        }

        private void txbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
              e.KeyChar == (Char)48 ~ 57 -----> 0~9
              e.KeyChar == (Char)8 -----------> Backpace
              e.KeyChar == (Char)13-----------> Enter
            */

            if (e.KeyChar == (Char)48 || e.KeyChar == (Char)49 ||
              e.KeyChar == (Char)50 || e.KeyChar == (Char)51 ||
              e.KeyChar == (Char)52 || e.KeyChar == (Char)53 ||
              e.KeyChar == (Char)54 || e.KeyChar == (Char)55 ||
              e.KeyChar == (Char)56 || e.KeyChar == (Char)57 || e.KeyChar == (Char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
