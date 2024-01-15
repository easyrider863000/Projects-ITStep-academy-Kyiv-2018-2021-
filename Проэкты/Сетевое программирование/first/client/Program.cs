using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 20123;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            client.Connect(ep);
            byte[] bytes = new byte[256];
            client.Receive(bytes);

            Console.WriteLine(Encoding.Default.GetString(bytes));
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            Console.ReadKey();
        }
    }
}
