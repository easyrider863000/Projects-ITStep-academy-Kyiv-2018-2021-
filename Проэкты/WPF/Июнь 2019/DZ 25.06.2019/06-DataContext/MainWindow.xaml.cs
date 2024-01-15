using MyModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace _06_DataContext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> collection;

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("people.bin"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream("people.bin", FileMode.OpenOrCreate))
                {
                    collection = bf.Deserialize(fs) as ObservableCollection<Person>;
                }
            }
            else
            {
                collection = new ObservableCollection<Person>(DataLayer.GetPerson());
            }
            this.DataContext = collection;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            collection.Add(new Person() { FirstName = "noname" });
            lbPerson.SelectedItem = lbPerson.Items.Count - 1;
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if(lbPerson.SelectedItem != null)
            {
                collection.RemoveAt(lbPerson.SelectedIndex);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("people.bin", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, collection);
            }
        }
    }
}
