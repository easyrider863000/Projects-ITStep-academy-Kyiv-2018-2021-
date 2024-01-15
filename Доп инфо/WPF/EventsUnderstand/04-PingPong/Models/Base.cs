using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_PingPong.Models
{
    class Base
    {
        //Свойства класса: событие и его аргументы
        //Событие Changed, зажигаемое при всех изменениях
        //элементов списка.
        public event ChangedEventHandler Changed;
        //Аргументы события
        private ChangedEventArgs evargs = new ChangedEventArgs();
        //Методы класса: процедура On и переопределяемые методы.
        //Процедура On, включающая событие
        protected virtual void OnChanged(ChangedEventArgs args)
        {
            if (Changed != null) Changed(this, args);
        }
        public void Step()
        {
            evargs.IsBall = !evargs.IsBall;
            OnChanged(evargs);
        }
        public virtual void Change(object sender, ChangedEventArgs args)
        {
            Thread.Sleep(1000);
            this.Step();
        }
    }
}
