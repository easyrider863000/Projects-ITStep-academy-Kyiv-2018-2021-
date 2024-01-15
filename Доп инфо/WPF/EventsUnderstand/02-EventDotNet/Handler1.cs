using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EventDotNet
{
    class Handler1
    {
        //public void Message() Меняем обїявление метода
        public void Message(object o, EventArgs e)
        {

            Console.WriteLine("class Handler1; Событие произошло. i==77!");
        }
    }
}
