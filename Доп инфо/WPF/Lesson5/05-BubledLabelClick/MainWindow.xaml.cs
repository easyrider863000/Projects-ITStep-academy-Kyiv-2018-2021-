using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _05_BubledLabelClick
{
  
    public partial class MainWindow : Window
    {
        // Счетчик событий.
        private Int32 eventCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MouseUp_Handler(object sender, RoutedEventArgs e)
        {
            eventCounter++;

            // Сбор информации о событии.
            string message = "#" + eventCounter.ToString() + ":\r\n" +
                " Sender: " + sender.ToString() + "\r\n" +
                " Source: " + e.Source + "\r\n" +
                " Original Source: " + e.OriginalSource;

            // Добавляем сгенерированную строку в ListBox.
            lstMessages.Items.Add(message);

            // Свойство Handled - Получает или задает значение, указывающее текущее состояние обработки
            // маршрутизируемого события по мере продвижения его по маршруту.
            //!!!!!!!!!!!!!!!!! Если True - событие обработано!!!
            e.Handled = (bool)chkHandle.IsChecked;
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            // Сбрасываем счетчик.
            eventCounter = 0;

            // Чистим ListBox.
            lstMessages.Items.Clear();
        }
    }
}
