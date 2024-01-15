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

namespace task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        App app;
        bool clicked;
        public MainWindow()
        {
            InitializeComponent();
            app = Application.Current as App;
            clicked = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!clicked)
            {
                clicked = true;
                app.Activated += Some_Event;
                app.Startup += Some_Event;
                Some_Event(app,e);
            }
        }

        private void Some_Event(object sender, EventArgs e)
        {
            txt.Text += $"{e.ToString()}";
            MessageBox.Show(e.ToString());
        }
    }
}
