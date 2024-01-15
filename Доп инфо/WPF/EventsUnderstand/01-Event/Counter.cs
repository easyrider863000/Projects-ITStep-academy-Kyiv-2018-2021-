using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Event
{
    class Counter
    {
        public delegate void MyEventHandler();
        //Событие SomeEvent c типом делегата MyEventHandler.
        public event MyEventHandler SomeEvent;
        public void OnSomeEvent()
        {
            MyEventHandler myEvent = SomeEvent;
            if (myEvent != null)
                myEvent();
        }

        public void Count()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 71)
                {
                    OnSomeEvent();
                }
            }
        }
    }
}
