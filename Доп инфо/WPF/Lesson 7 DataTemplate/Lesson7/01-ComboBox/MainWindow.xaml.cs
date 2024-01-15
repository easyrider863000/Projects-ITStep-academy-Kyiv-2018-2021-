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

namespace _01_ComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<MyItem> items = new List<MyItem>();
            items.Add(new MyItem() { Name = "Яблоко", Picture = "1.jpg" });
            items.Add(new MyItem() { Name = "Апельсин", Picture = "2.jpg" });
            items.Add(new MyItem() { Name = "Ананас", Picture = "3.jpg" });
            items.Add(new MyItem() { Name = "Авокадо", Picture = "4.jpg" });
            items.Add(new MyItem() { Name = "Банан", Picture = "5.jpg" });

            Binding binding = new Binding();
            binding.Source = items;

            comboBox1.SetBinding(ComboBox.ItemsSourceProperty, binding);
        }
    }
}
