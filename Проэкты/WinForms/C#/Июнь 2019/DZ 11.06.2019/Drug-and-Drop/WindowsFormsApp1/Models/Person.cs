using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    [Serializable]
    class Person : Object
    {
        public Person()
        {
            Photos = new List<Photo>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateBirthday { get; set; }
        public string INN { get; set; }
        public List<Photo> Photos { get; set; }
        public string Textd { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

}
