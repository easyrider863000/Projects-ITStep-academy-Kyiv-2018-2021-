//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading.Tasks;

//namespace Client.Model
//{
//    public class ClientObject
//    {
//        protected internal string Id { get; private set; }
//        protected internal NetworkStream Stream { get; private set; }
//        string userName;
//        TcpClient client;
//        ServerObject server; // объект сервера

//        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
//        {
//            Id = Guid.NewGuid().ToString();
//            client = tcpClient;
//            server = serverObject;
//            serverObject.AddConnection(this);
//        }

//        public void Process()
//        {
//            try
//            {
//                Stream = client.GetStream();
//                // получаем имя пользователя
//                string message = GetMessage();
//                userName = message;

//                message = userName+"-"+server.clients.IndexOf(this)+ ": вошел в чат";
//                // посылаем сообщение о входе в чат всем подключенным пользователям
//                server.BroadcastMessage(message, this.Id);
//                Console.WriteLine(message);
//                // в бесконечном цикле получаем сообщения от клиента
//                string whom;
//                while (true)
//                {
//                    try
//                    {
//                        message = GetMessage();
//                        whom = message.Substring(0, message.IndexOf(' '));
//                        message = message.Substring(message.IndexOf(' ', message.IndexOf(' ') + 1));
//                        message = String.Format("{0}-{1}: {2}", userName, server.clients.IndexOf(this), message);
//                        Console.WriteLine(message);
//                        if (whom != "broadcast")
//                        {
//                            for(int i = 0;i<server.clients.Count;i++)
//                            {
//                                if(server.clients[i].userName==whom)
//                                {
//                                    server.WhomMessage(message, server.clients[i].Id);
//                                }
//                            }
//                        }
//                        else
//                        {
//                            server.BroadcastMessage(message, this.Id);
//                        }
                        
//                        //byte[] data = Encoding.Unicode.GetBytes(message);
//                        //server.clients[0].Stream.Write(data, 0, data.Length);
//                    }
//                    catch
//                    {
//                        message = String.Format("{0}-{1}: покинул чат", userName, server.clients.IndexOf(this));
//                        Console.WriteLine(message);
//                        server.BroadcastMessage(message, this.Id);
//                        break;
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            finally
//            {
//                // в случае выхода из цикла закрываем ресурсы
//                server.RemoveConnection(this.Id);
//                Close();
//            }
//        }

//        // чтение входящего сообщения и преобразование в строку
//        private string GetMessage()
//        {
//            byte[] data = new byte[64]; // буфер для получаемых данных
//            StringBuilder builder = new StringBuilder();
//            int bytes = 0;
//            do
//            {
//                bytes = Stream.Read(data, 0, data.Length);
//                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
//            }
//            while (Stream.DataAvailable);
            
//            return builder.ToString();
//        }
//        public List<ClientObject> GetListOfClients()
//        {
//            return server.clients;
//        }

//        // закрытие подключения
//        protected internal void Close()
//        {
//            if (Stream != null)
//                Stream.Close();
//            if (client != null)
//                client.Close();
//        }
//    }
//}
