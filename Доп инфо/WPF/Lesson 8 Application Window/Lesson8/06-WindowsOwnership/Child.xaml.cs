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
using System.Windows.Shapes;

namespace _06_WindowsOwnership
{
    /// <summary>
    /// Interaction logic for Child.xaml
    /// </summary>
    public partial class Child : Window
    {
        public Child()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Owner as MainWindow).Title = "Hello from child"; // получение ссылки на родительское окно
        }
    }
}
