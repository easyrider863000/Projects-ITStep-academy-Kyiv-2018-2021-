using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Model
{
    public class MyServer
    {
        public TcpListener TcpListener { get; set; }
        public List<TcpClient> Clients { get; set; }
        public MyServer()
        {
            TcpListener = new TcpListener(IPAddress.Parse(Constants.server), Constants.port);
            
            //Listen();
        }
        public void SendThisObjectToClients()
        {
            foreach (var client in Clients)
            {
                NetworkStream stream = client.GetStream();
                byte[] data = SerializeServer.Serialize(this);
                stream.Write(data, 0, data.Length);
            }
        }
        public void Listen()
        {
            try
            {
                TcpListener.Start();
                MessageBox.Show("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    TcpClient tcpClient = TcpListener.AcceptTcpClient();
                    Clients.Add(tcpClient);
                    SendThisObjectToClients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Disconnect();
            }
        }

        public void Disconnect()
        {
            TcpListener.Stop(); //остановка сервера

            for (int i = 0; i < Clients.Count; i++)
            {
                Clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }
    }
}
