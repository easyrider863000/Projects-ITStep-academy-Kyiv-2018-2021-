﻿using System;
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

namespace _02_WindowEvents
{
    /// <summary>
    /// Interaction logic for WindowClosing.xaml
    /// </summary>
    public partial class WindowClosing : Window
    {
        public WindowClosing()
        {
            InitializeComponent();
        }
        private void Button_Click_Yes(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_No(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
