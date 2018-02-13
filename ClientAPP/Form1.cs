using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientAPP
{
    public partial class ChatForm : Form
    {
        ClientControl client = new ClientControl();

        public ChatForm()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            string msg,msgrec;
            msg = SendTextBox.Text.Trim();
            msgrec = client.Received2();
            if (msg != "")
            {
                client.Send(msg);
                SendTextBox.Text = "";
                ReceiveTextBox.Text += client.Received1() + Environment.NewLine;
            }
            else
            {
                ReceiveTextBox.Text += client.Received1() + Environment.NewLine;
            }
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            client.Connect("192.168.0.103", 22222);
        }
    }
}
