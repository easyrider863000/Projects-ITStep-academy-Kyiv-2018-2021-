using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_INotifyPropertyChanged.Models
{
    public class User : INotifyPropertyChanged
    {
        string name;
      
        int age;
        public string Name
        {
            set
            {
                name = value;
                Notify("Name");
            }
            get
            {
                return name;
            }
        }
       
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                Notify("Age");
            }
        }
        //public string Name { get; set; }
        //public int Age { get; set; }
        public User()
        {

        }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
