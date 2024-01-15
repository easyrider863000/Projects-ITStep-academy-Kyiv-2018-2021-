using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EventDotNet
{
    class Handler
    {
        //public void Message()
        public void Message(object o, EventArgs e)
        {
            Console.WriteLine("class Handler; Событие произошло. i==77!");
        }

    }
}
