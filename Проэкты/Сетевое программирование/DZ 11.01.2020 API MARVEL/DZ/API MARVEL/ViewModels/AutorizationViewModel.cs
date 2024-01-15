using API_MARVEL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace API_MARVEL.ViewModels
{
    public class AutorizationViewModel
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public bool DialogResult { get; set; }
        public ICommand SendKey { get; set; }
        public AutorizationViewModel()
        {
            SendKey = new RelayCommand(x =>
            {
                PublicKey = x.ToString().Split(' ')[0];
                PrivateKey = x.ToString().Split(' ')[1];
            });
        }
    }
}
