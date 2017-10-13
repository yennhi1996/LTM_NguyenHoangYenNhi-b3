using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace Bai2_Client
{
    public partial class Form1 : Form
    {
        Socket client;
        IPEndPoint ipserver;
        EndPoint remote;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ipserver = new IPEndPoint(IPAddress.Parse("127.0.0.0"), 9050);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            remote = (EndPoint)ipserver;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Keo";
            int a = 0;
            byte[] send = BitConverter.GetBytes(a);
            client.SendTo(send, ipserver);


            byte[] rec = new byte[25];
            remote = (EndPoint)ipserver;
            client.ReceiveFrom(rec, ref remote);

            textBox1.Text = Encoding.ASCII.GetString(rec);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox2.Text = "Bua";
            int a = 1;
            byte[] send = BitConverter.GetBytes(a);
            client.SendTo(send, ipserver);


            byte[] rec = new byte[25];
            remote = (EndPoint)ipserver;
            client.ReceiveFrom(rec, ref remote);

            textBox1.Text = Encoding.ASCII.GetString(rec);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox2.Text = "Bao";
            int a = 2;
            byte[] send = BitConverter.GetBytes(a);
            client.SendTo(send, ipserver);


            byte[] rec = new byte[25];
            remote = (EndPoint)ipserver;
            client.ReceiveFrom(rec, ref remote);

            textBox1.Text = Encoding.ASCII.GetString(rec);
        }
    }
}
