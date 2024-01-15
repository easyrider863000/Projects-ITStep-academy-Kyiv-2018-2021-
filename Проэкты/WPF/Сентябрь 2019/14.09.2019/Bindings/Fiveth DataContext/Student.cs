using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fiveth_DataContext
{
    class Student:INotifyPropertyChanged
    { 
        private string _name;
        private string _lastname;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Notify();
            }
        }
        public string LastName
        {
            get => _lastname;
            set
            {
                _lastname = value;
                Notify();
            }
        }
        protected void Notify([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
