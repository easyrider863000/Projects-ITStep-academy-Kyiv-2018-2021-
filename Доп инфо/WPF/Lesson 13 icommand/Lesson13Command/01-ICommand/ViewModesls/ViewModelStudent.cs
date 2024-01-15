using _01_ICommand.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _01_ICommand.ViewModesls
{
    public class ViewModelStudent : INotifyPropertyChanged
    {
        public ObservableCollection<Student> collection { get; set; }
        private Student _SelectedStudent;

        public Student SelectedStudent
        {
            get { return _SelectedStudent; }
            set
            {
                _SelectedStudent = value;
                Notify("SelectedStudent");
            }
        }

        public ViewModelStudent()
        {
            collection = new ObservableCollection<Student>()
            {
              new Student {  Age=21, Name="Nata"},
              new Student {  Age=18, Name="Igor"},
              new Student {  Age=33, Name="Masha"}
            };


        }
        RelayCommand add;

        public ICommand AddCommand
        {
            get
            {
                if (add == null)
                    add = new RelayCommand(x =>
                    {
                        SelectedStudent = new Student() { Age = 0, Name = "?" };
                        collection.Add(SelectedStudent);
                        // SelectedStudent = s;
                    }, null);
                return add;
            }
        }




        RelayCommand remove;
        public ICommand RemoveCommand
        {
            get
            {
                if (remove == null)
                {
                   
                        remove = new RelayCommand(x =>
                        {
                            if (MessageBox.Show("You delete record?", "Delete record", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                            {
                                collection.Remove(SelectedStudent);
                            }
                        }, x => SelectedStudent != null);
                    
                }
                return remove;
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
