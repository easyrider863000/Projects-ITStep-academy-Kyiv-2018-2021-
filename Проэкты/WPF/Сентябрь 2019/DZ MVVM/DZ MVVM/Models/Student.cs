using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DZ_MVVM.Models
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Group { get; set; }
        public DateTime YearBirth { get; set; }
        public static ObservableCollection<Student> GetStudents()
        {
            return new ObservableCollection<Student>
            {
                new Student { Name = "Alex", Lastname = "Klar", Group = "12345", YearBirth= DateTime.ParseExact("2003","yyyy",System.Globalization.CultureInfo.InvariantCulture)},
                new Student { Name = "John", Lastname = "Doe", Group = "678910", YearBirth= DateTime.ParseExact("2001","yyyy",System.Globalization.CultureInfo.InvariantCulture)},
                new Student { Name = "Lens", Lastname = "Newman", Group = "1112131415", YearBirth= DateTime.ParseExact("2002","yyyy",System.Globalization.CultureInfo.InvariantCulture)}
            };
        }
    }
}
