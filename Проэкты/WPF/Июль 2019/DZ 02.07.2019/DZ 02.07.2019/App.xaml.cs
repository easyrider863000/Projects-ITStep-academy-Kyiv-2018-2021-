using DZ_02._07._2019.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DZ_02._07._2019
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (!string.IsNullOrEmpty(Settings.Default.Culture))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Settings.Default.Culture);
            }
            if (!string.IsNullOrEmpty(Settings.Default.UICulture))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.UICulture);
            }

            base.OnStartup(e);
        }
    }
}
