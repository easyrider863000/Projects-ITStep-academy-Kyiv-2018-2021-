using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EventEventArgs
{
    class Handler
    {
        public void Message(object o, MyEventArgs args)
        {
            //args.ListSelected = new List<int>() { 5, 9, 77 };
            Console.WriteLine($"class Handler; Событие произошло. args.Current = {args.Current}");
        }
    }
}
