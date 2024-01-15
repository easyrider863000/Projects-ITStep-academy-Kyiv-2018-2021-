using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ArrayListEvents.Models
{
    class EventReceiver
    {
        private ArrayListEvents List;
        public EventReceiver(ArrayListEvents list)
        {
            List = list;
            // Присоединяет обработчик к событию. OnConnect();
        }
        //Обработчик события - выдает сообщение.
        //Recevier1 Разрешает добавление элементов, меньших 10. 
        private void ListChanged(object sender, ChangedEventArgs args)
        {
            Console.WriteLine("EventReceiver: Сообщаю об изменениях:" + "Item ={0}", args.Item);
            args.Permit = ((int)args.Item < 10);
        }
        public void OnConnect()
        {
            //Присоединяет обработчик к событию
            List.Changed += new ChangedEventHandler(ListChanged);
        }
        public void OffConnect()
        {
            //Отсоединяет обработчик от события и удаляет список 
            List.Changed -= new ChangedEventHandler(ListChanged);
            List = null;
        }
    }
}
