using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _01_ICommand.Models
{
    public class Student : INotifyPropertyChanged
    {
        string _name;
        int _age;
        public string Name
        {
            set
            {
                _name = value;
                Notify();
            }
            get
            {
                return _name;
            }
        }
        public int Age
        {
            set
            {
                _age = value;
                Notify();
            }
            get
            {
                return _age;
            }
        }
        public void Notify([CallerMemberName]string s = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
