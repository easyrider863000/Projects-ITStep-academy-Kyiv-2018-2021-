using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EventDotNet
{
    class Counter
    {
        //public delegate void MyEventHandler(); УБИРАЕМ ОБЇЯВЛЕНИЕ ДЕЛЕГАТА!!!
        //Событие SomeEvent c типом делегата MyEventHandler.
        public event EventHandler SomeEvent;
        public void OnSomeEvent()
        {
            EventHandler myEvent = SomeEvent;
            if (myEvent != null)
                myEvent(this, null);
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
