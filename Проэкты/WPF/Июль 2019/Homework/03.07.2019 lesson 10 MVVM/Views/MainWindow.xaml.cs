using _03._07._2019_lesson_10_MVVM.Models;
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

namespace _03._07._2019_lesson_10_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow window = new NewUserWindow();
            window.ShowDialog();
        }

        private void TxtFirstName_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
