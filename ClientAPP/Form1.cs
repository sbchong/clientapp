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
        string onemsg = "";

        public ChatForm()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            string msg, msgrec;
            msg = msgrec = "";
            msg = SendTextBox.Text.Trim();
            msgrec = client.Received();

            if (msg != "")
            {

                client.Send(msg);
                SendTextBox.Text = "";
                if (msgrec != onemsg)
                {
                    ReceiveTextBox.Text += msgrec + Environment.NewLine;
                    onemsg = msgrec;
                }
                else
                {
                }
            }
            else
            {
                if (msgrec != onemsg)
                {
                    ReceiveTextBox.Text += msgrec + Environment.NewLine;
                    onemsg = msgrec;
                }
                else
                {
                }
            }
        }
 

        private void ChatForm_Load(object sender, EventArgs e)
        {
            client.Connect("192.168.0.103", 22222);
        }
    }
}
