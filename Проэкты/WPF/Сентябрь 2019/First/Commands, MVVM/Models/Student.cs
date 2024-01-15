using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands__MVVM.Models
{
    static class Student
    {
        public static string Name { get; set; }
        public static string LastName { get; set; }
        public static ObservableCollection<Student> GetStudents()
        {
            return new ObservableCollection<Student>
            {
                new Student();
            }
        }
    }
}
