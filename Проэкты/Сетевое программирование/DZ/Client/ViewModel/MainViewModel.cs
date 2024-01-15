using Client.Model;
using System.Collections.ObjectModel;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Client.Infrastracture;
using System.Windows.Input;
using System.Globalization;

namespace Client.ViewModel
{
    public class MyMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null)
                return values[0].ToString() + " " + values[1].ToString();
            else
                return "broadcast " + values[1].ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class MainViewModel : INotifyPropertyChanged
    {
        #region Variables
        //private const string host = "127.0.0.1";
        //private const int port = 8888;
        //static TcpClient client;
        //public ClientObject clientObject;
        static NetworkStream Stream;
        public MyClient Client { get; set; }
        private string ip;
        private string host;
        private string msg;

        public ObservableCollection<String> ListUsers { get; set; }
        public string tBoxMessages { get; set; }
        public string sendToMessages { get; set; }
        public string Messages
        {
            get { return msg; }
            set
            {
                msg = value;
                Notify();
            }
        }

        private Task listenMsg;
        public string ClientIP
        {
            get { return ip; }
            set
            {
                ip = value;
                Notify();
            }
        }
        public string ClientHost
        {
            get { return host; }
            set
            {
                host = value;
                Notify();
            }
        }
        #endregion

        #region Commands
        public RelayCommand ConnectCommand { get; set; }
        public ICommand WriteCommand { get; set; }
        public MainViewModel()
        {
            host = Dns.GetHostName();
            #pragma warning disable CS0618
            ClientIP = Dns.GetHostByName(host).AddressList[0].ToString();
            ClientHost = host;
#pragma warning restore CS0618

            Client = new MyClient();
            Client.Connect();

            ConnectCommand = new Infrastracture.RelayCommand(x =>
            {
                try
                {
                    //client.Connect(host, port); //подключение клиента
                    //Client.Connect();
                    listenMsg = new Task(() =>
                    {
                        ReceiveMessage();
                    });

                    Stream = Client.Client.GetStream(); // получаем поток

                    string message = host;
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    Stream.Write(data, 0, data.Length);
                    //Thread.Sleep(2000);
                    listenMsg.Start();
                    Messages += $"Добро пожаловать, {host}" + '\n';
                    //SendMessage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }, x => Client.Client!=null && !Client.Client.Connected);
            WriteCommand = new RelayCommand(x =>
            {
                string messg = x.ToString();
                //MessageBox.Show(messg);
                SendMessage(messg);
            }, x=> tBoxMessages.Length>1);//заменить на распознование username
        }

        // отправка сообщений
        static void SendMessage(string text)
        {
            byte[] data = Encoding.Unicode.GetBytes(text);
            Stream.Write(data, 0, data.Length);
        }
        // получение сообщений
        public void ReceiveMessage()
        {
            ListUsers = new ObservableCollection<string>();

            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = Stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (Stream.DataAvailable);

                    string message = builder.ToString();

                    if (message.Substring(message.LastIndexOf(':')) == ": вошел в чат")
                    {
                        ListUsers.Add(message.Substring(0, message.LastIndexOf(':')));
                        Notify("ListUsers");
                    }
                    else
                    {
                        Messages += message + '\n';
                        Notify("Messages");
                    }

                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Подключение прервано!"+ex.Message); //соединение было прервано
                    break;
                }
            }
        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify([CallerMemberName]string property="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}

