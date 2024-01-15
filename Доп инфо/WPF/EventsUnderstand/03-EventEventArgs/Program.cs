using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EventEventArgs
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
        }
    }
}
