using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ArrayListEvents.Models
{
    class ArrayListEvents : ArrayList
    {
        public event ChangedEventHandler Changed;
        //Аргументы события
        private ChangedEventArgs evargs = new ChangedEventArgs();
        //public virtual void OnChanged(ChangedEventArgs args)
        public virtual void OnChanged(ChangedEventArgs args)
        {
            ChangedEventHandler tmp = Changed;
            if (tmp != null) tmp(this, args);
        }
        public override int Add(object value)
        {
            int i = 0;
            evargs.Item = value;
            OnChanged(evargs);
            if (evargs.Permit)
                i = base.Add(value);
            else
                Console.WriteLine("Добавление элемента запрещено." + "Значение =	{0}", value);
            return i;
        }
        public override void Clear()
        {
            evargs.Item = 0;
            OnChanged(evargs);
            base.Clear();
        }

        public override object this[int index]
        {
            set
            {
                evargs.Item = value;
                OnChanged(evargs);
                if (evargs.Permit)
                {
                    Console.WriteLine($"Замена элемента с индексом {index}");
                    base[index] = value;
                }
                else
                    Console.WriteLine($"Замена элемента запрещена. Значение =	{value}");
            }
            get
            {
                return (base[index]);
            }
        }
    }
}
