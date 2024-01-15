using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _03_CustomCommand
{
    public class DataCommands
    {
        // Пользовательская команда.
        private static RoutedUICommand requery;

        static DataCommands()
        {
            // InputGestureCollection - горячие клавиши, на которые команда будет реагировать.
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R"));

            requery = new RoutedUICommand("Requery", "Requery", typeof(DataCommands), inputs);
            // 1 параметр: Текст, который будет отображаться, если команда будет присвоена пункту меню.
            // 2 параметр: Имя команды.
            // 3 параметр: Класс объявляющий команду.
            // 4 параметр: Горячие клавиши.
        }

        public static RoutedUICommand Requery
        {
            get { return requery; }
        }
    }
}
