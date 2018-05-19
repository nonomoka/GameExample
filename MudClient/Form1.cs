using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MudClient
{
    public partial class Form1 : Form
    {
        AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

        public Form1()
        {
            InitializeComponent();
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string strTextToAdd = this.InputBox.Text;
                if (!String.IsNullOrWhiteSpace(strTextToAdd))
                {
                    this.InputBox.AutoCompleteCustomSource.Add(strTextToAdd);
                }
                this.InputBox.Text = String.Empty;
                this.InputBox.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
