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

namespace _08_OnlyNumbers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Событие  PreviewTextInput не срабатывает для Contrl, Shift, Alt и Space
        // События клавиатуры являются туннельными.
        private void pnl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            short value;

            // Если: введена не цифра
            if (!Int16.TryParse(e.Text, out value))
            {
                // То: Указываем, что событие обработано и распространятся далее не должно.
                e.Handled = true;
            }
        }

        private void pnl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
