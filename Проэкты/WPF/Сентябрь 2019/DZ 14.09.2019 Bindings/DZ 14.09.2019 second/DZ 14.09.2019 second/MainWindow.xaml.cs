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

namespace DZ_14._09._2019_second
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

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            date.Cars.Add(new Car() { Color = "noname", Title = "noname", Year = 0 });
        }
        private void Remove_Clicked(object sender, RoutedEventArgs e)
        {
            date.Cars.Remove(date.SelectedCar);
        }
    }
}
