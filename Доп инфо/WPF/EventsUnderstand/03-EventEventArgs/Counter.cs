using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EventEventArgs
{
    public class MyEventArgs : EventArgs
    {
        public int Current { get; set; }
        public MyEventArgs()
        {
            ListSelected = new List<int>();
        }
        public List<int> ListSelected { get; set; }
    }
    public delegate void ChangedEventHandler(object sender, MyEventArgs args);
    public class Counter
    {
        public event ChangedEventHandler SomeEvent;
        private MyEventArgs evargs = new MyEventArgs();
        public void OnSomeEvent(MyEventArgs args)
        {
            ChangedEventHandler myEvent = SomeEvent;
            evargs = args;
            if (myEvent != null)
            {
                myEvent(this, args);
            }
        }

        public void Count()
        {
            MyEventArgs args = new MyEventArgs()
            {
                ListSelected = new List<int>() { 1, 2, 3, 77 }
            };
            for (int i = 0; i < 100; i++)
            {
                if (args.ListSelected.Count > 0 && args.ListSelected.Contains(i))
                {
                    args.Current = i;
                    OnSomeEvent(args);
                }
            }
        }
    }
}
