using DZ_MVVM.Models;
using System.Collections.ObjectModel;
using DZ_MVVM.Views;
using System;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

namespace DZ_MVVM.ViewModels
{
    
    class MainViewModel
    {
        bool if_desc = false;
        #region Properties
        public ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent { get; set; }

        #endregion


        #region Commands 

        public System.Windows.Input.ICommand AddCommand { get; set; }
        public System.Windows.Input.ICommand RemoveCommand { get; set; }
        public System.Windows.Input.ICommand SaveCommand { get; set; }
        public System.Windows.Input.ICommand SortCommand { get; set; }
        public System.Windows.Input.ICommand HowSortCommand { get; set; }

        #endregion
        public MainViewModel()
        {
            if (File.Exists("Data.json"))
            {
                Students = JsonConvert.DeserializeObject<ObservableCollection<Student>>(File.ReadAllText("Data.json"));
            }
            else
            {
                Students = Student.GetStudents();
            }


            AddCommand = new RelayCommand(x =>
            {
                Students.Add(new Student { Name = "New", Lastname = "Student", Group="12345", YearBirth=DateTime.Now });
            });
            RemoveCommand = new RelayCommand(x => Students.Remove((Student)x));
            SaveCommand = new RelayCommand(x =>
            {
                File.WriteAllText("Data.json", JsonConvert.SerializeObject(Students));
            });
            SortCommand = new RelayCommand(x =>
            {
                ObservableCollection<Student> tmp;
                if (x.ToString() == "Name")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<Student>(from word in Students
                                                                                orderby word.Name.Length
                                                                                select word) : new ObservableCollection<Student>(from word in Students
                                                                                                                                 orderby word.Name.Length descending
                                                                                                                                 select word);
                }
                else if(x.ToString() == "Surname")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<Student>(from word in Students
                                                                                orderby word.Lastname.Length
                                                                                select word) : new ObservableCollection<Student>(from word in Students
                                                                                                                                 orderby word.Lastname.Length descending
                                                                                                                                 select word);
                }
                else if (x.ToString() == "Group")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<Student>(from word in Students
                                                                                orderby word.Group.Length
                                                                                select word) : new ObservableCollection<Student>(from word in Students
                                                                                                                                 orderby word.Group.Length descending
                                                                                                                                 select word);
                }
                else if (x.ToString() == "YearBirth")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<Student>(from word in Students
                                                                                orderby word.YearBirth.Year
                                                                                select word) : new ObservableCollection<Student>(from word in Students
                                                                                                                                 orderby word.YearBirth.Year descending
                                                                                                                                 select word);
                }
                else
                {
                    tmp = new ObservableCollection<Student>();
                }
                Students.Clear();
                foreach(var i in tmp)
                {
                    Students.Add(i);
                }
            });
            HowSortCommand = new RelayCommand(x =>
            {
                if_desc = Convert.ToBoolean(x.ToString());
            });
        }
    }
}
