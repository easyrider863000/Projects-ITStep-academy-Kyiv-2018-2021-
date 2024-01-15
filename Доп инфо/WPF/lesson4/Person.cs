using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ListPerson.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateBirthday { get; set; }
        public string INN { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
