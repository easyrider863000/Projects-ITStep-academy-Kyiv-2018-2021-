using _05_ArrayListEvents.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ArrayListEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayListEvents arrayList = new ArrayListEvents();

            EventReceiver eventReceiver = new EventReceiver(arrayList);

            eventReceiver.OnConnect();
            arrayList.Add(7);
            arrayList.Add(12);
            arrayList[0] = 9;

        }
    }
}
