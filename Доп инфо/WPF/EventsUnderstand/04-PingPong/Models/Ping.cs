using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_PingPong.Models
{
    class Ping : Base
    {
        public override void Change(object sender, ChangedEventArgs args)
        {
            Console.WriteLine("Message from Ping: Сообщаю об изменениях:" + "IsBall ={0}", args.IsBall);
            Thread.Sleep(1000);
            this.Step();
        }
    }
}
