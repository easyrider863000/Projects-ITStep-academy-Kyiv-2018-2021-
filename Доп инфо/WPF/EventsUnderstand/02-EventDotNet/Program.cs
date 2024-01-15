using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EventDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Console.WriteLine("Пока никто не подписалcя на события");
            counter.Count();
            Console.WriteLine("----------------------------------------");
            Handler handler = new Handler();
            counter.SomeEvent += handler.Message;
            Console.WriteLine("подписалcя на события Handler handler");
            counter.Count();
            Console.WriteLine("----------------------------------------");
            Handler1 handler1 = new Handler1();
            counter.SomeEvent += handler1.Message;
            Console.WriteLine("подписалcя на события Handler handler и  Handler1 handler1 ");
            counter.Count();
            Console.WriteLine("----------------------------------------");
            counter.SomeEvent -= handler.Message;
            Console.WriteLine("Handler handler - отписалcя от получения события; Handler1 handler1 - остался");
            counter.Count();
        }
    }
}
