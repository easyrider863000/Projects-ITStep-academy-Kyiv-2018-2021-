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

namespace _01_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Binding binding = new Binding();
            //binding.ElementName = "sliderFontSize";
            //binding.Path = new PropertyPath("Value");
            ////binding.Mode = BindingMode.OneWay;
            //txtBlock.SetBinding(TextBlock.FontSizeProperty, binding);
        }
    }
}
