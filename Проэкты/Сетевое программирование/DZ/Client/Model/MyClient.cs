using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class MyClient:INotifyPropertyChanged
    {
        public TcpClient Client { get; set; }
        private MyServer Server { get; set; }
        public string Id { get; private set; }
        public NetworkStream Stream { get; set; }
        public string UserName { get; set; } //сделать доступ набирать username пользователю перед connect
        public Task ListenMessages { get; set; }
        private List<string> _messages;
        public List<string> Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
                Notify();
            }
        }
        public MyClient()
        {
            Id = Guid.NewGuid().ToString();
            ListenMessages = new Task(() =>
            {
                Listen();
            });
        }

        public void Connect()
        {
            Client = new TcpClient(Dns.GetHostName(), Constants.port);
            Client.ConnectAsync(Constants.server, Constants.port);
            Stream = Client.GetStream();
            ListenMessages.Start();
        }
        public void Listen()
        {
            while (true)
            {
                try
                {
                    byte[] msg = GetMessage();
                    if (SerializeServer.IsDeserializeble(msg))
                    {
                        Server = SerializeServer.Deserialize(msg);
                    }
                    else
                    {
                        Messages.Add(Encoding.UTF8.GetString(msg, 0, msg.Length));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public byte[] GetMessage()
        {
            byte[] bytes = new byte[5000];
            Stream.ReadAsync(bytes, 0, bytes.Length);
            return bytes;
        }
        public void SendMessage(string msg)
        {
            byte[] data = Encoding.Unicode.GetBytes(msg);
            Stream.Write(data, 0, data.Length);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
