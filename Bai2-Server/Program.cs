using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Bai2_Server
{
    class Program
    {
        static void Main(string[] args)
        {

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(ipep);

            Console.WriteLine("Waiting for client...:");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);

            byte[] data = new byte[4];
            server.ReceiveFrom(data, ref Remote);
            int ClientChoosen = BitConverter.ToInt32(data, 0);

            Random rand = new Random();
            int ServerChoosen = rand.Next(0, 2);
            
            if(ClientChoosen == ServerChoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Draw");
                server.SendTo(send, Remote);
            }
            if (ClientChoosen > ServerChoosen)
            {
                if (ServerChoosen == 0 && ClientChoosen == 2)
                {
                    byte[] send = Encoding.ASCII.GetBytes("Lose");
                    server.SendTo(send, Remote);
                }
                else
                {
                    byte[] send = Encoding.ASCII.GetBytes("Win");
                    server.SendTo(send, Remote);
                }
            }
            if(ClientChoosen < ServerChoosen)
            {
                if(ServerChoosen == 2 && ClientChoosen == 0)
                {
                    byte[] send = Encoding.ASCII.GetBytes("Win");
                    server.SendTo(send, Remote);
                }
                else
                {
                    byte[] send = Encoding.ASCII.GetBytes("Lose");
                    server.SendTo(send, Remote);
                }
            }
        }
    }
}
