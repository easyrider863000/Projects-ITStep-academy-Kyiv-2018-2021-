using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DZ_02._07._2019
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Country> countries;
        public MainWindow()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
            InitializeComponent();
            countries = new ObservableCollection<Country>(DataLayer.GetCountries());
            lbCountries.ItemsSource = countries;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbImage.Source = new BitmapImage(new Uri(countries[lbCountries.SelectedIndex].Photos[countries[lbCountries.SelectedIndex].Current],UriKind.Relative));
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if (lbCountries.SelectedIndex >= 0)
            {
                if (countries[lbCountries.SelectedIndex].Current < countries[lbCountries.SelectedIndex].Photos.Count - 1)
                    countries[lbCountries.SelectedIndex].Current += 1;
                else
                    countries[lbCountries.SelectedIndex].Current = 0;
                lbImage.Source = new BitmapImage(new Uri(countries[lbCountries.SelectedIndex].Photos[countries[lbCountries.SelectedIndex].Current], UriKind.Relative));
            }
        }

        private void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            
            if (lbCountries.SelectedIndex >= 0)
            {
                if (countries[lbCountries.SelectedIndex].Current == 0)
                    countries[lbCountries.SelectedIndex].Current = 2;
                else
                    countries[lbCountries.SelectedIndex].Current -= 1;
                lbImage.Source = new BitmapImage(new Uri(countries[lbCountries.SelectedIndex].Photos[countries[lbCountries.SelectedIndex].Current], UriKind.Relative));
            }
        }
    }
}
