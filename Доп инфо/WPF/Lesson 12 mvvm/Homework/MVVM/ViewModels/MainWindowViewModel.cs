using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<User> MyUsers { get; set; }
        public User CurrentUser { get; set; }
        public MainWindowViewModel()
        {
            MyUsers = new Users();
            CurrentUser = MyUsers.FirstOrDefault();
        }
    }
}
