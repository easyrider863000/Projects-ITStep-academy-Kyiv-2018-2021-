using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace first
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 20124;
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(iPAddress, port);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(ep);
            server.Listen(10);
            Console.WriteLine("Server started!");

            while(true)
            {
                Socket client = server.Accept();
                Console.WriteLine(client.RemoteEndPoint.ToString());

                string str = $"Server info:\nOS: {Environment.UserName}";
                byte[] bytes = Encoding.Default.GetBytes(str);
                client.Send(bytes);

                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }
    }
}
