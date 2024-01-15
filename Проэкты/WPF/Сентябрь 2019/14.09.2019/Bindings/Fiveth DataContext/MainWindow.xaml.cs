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

namespace Fiveth_DataContext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Date date = new Date();
        public MainWindow()
        {
            InitializeComponent();
            grid.DataContext = date;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            date.Strings.Add("newString");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            date.Strings.Remove(date.SelectedString);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            date.Student.Name = "Alex";
            date.Student.LastName = "Ivanov";
        }
    }
}
