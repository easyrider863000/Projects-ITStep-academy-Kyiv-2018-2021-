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

namespace _05_CheckBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var checkBox1 = new CheckBox
            {
                Content = "Unchecked",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            checkBox1.Checked += CheckBox_Checked; ;
            checkBox1.Unchecked += CheckBox_Unchecked;
            var checkBox2 = new CheckBox
            {
                Content = "Checked",
                HorizontalAlignment = HorizontalAlignment.Center,
                IsChecked = true,
                VerticalAlignment = VerticalAlignment.Center
            };
            checkBox2.Checked += CheckBox_Checked;
            checkBox2.Unchecked += CheckBox_Unchecked;
            var checkBox3 = new CheckBox
            {
                Content = "Indeterminate",
                HorizontalAlignment = HorizontalAlignment.Center,
                IsChecked = null,
                IsThreeState = true,
                VerticalAlignment = VerticalAlignment.Center
            };
            checkBox3.Checked += CheckBox_Checked;
            checkBox3.Indeterminate += CheckBox_Indeterminate;
            checkBox3.Unchecked += CheckBox_Unchecked;



            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.Children.Add(checkBox1);
            grid.Children.Add(checkBox2);
            grid.Children.Add(checkBox3);
            Grid.SetRow(checkBox1, 0);
            Grid.SetRow(checkBox2, 1);
            Grid.SetRow(checkBox3, 2);
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("CheckBox - Checked!");
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("CheckBox - Checked!");
        }
       
        private void CheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("CheckBox - Checked!");
        }
    }
}
