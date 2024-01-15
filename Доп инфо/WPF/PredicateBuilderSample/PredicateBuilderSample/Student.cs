using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateBuilderSample
{
    public class Student
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public static IEnumerable<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student {Name = "John", Year = 1985},
                new Student {Name = "Alex", Year = 1990},
                new Student {Name = "Igor", Year = 2000},
                new Student {Name = "Slava", Year = 2002},
                new Student {Name = "Oleh", Year = 2005},
                new Student {Name = "Lilia", Year = 1988},
                new Student {Name = "Alexandra", Year = 1989}
            };
        }
    }
}
