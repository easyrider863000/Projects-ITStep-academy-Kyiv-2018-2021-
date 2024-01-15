using Commands__MVVM.Infractructure;
using Commands__MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commands__MVVM.ViewModels
{
    class MainViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ObservableCollection<Student> Students{ get; set; }
        public Student SelectedStudent { get; set; }
        public MainViewModel()
        {
            Students = Student.GetStudents();
            AddCommand = new RelayCommand(x =>
            {
                Students.Add(new Student { Name = "a", LastName = "a" });
            }, X => Students.Count <= 5);
            RemoveCommand = new RelayCommand(x =>
            {
                Students.Remove(SelectedStudent);
            });
        }
    }
}
