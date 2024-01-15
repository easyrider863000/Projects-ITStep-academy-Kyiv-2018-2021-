using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModels
{
    public  class  DataLayer
    {
        public static List<Person> GetPerson()
        {
            List<Person> list = new List<Person>()
                {
                    new Person() { Id = 1,  FirstName = "Igor", LastName = "Krivonos",  DateBirthday = new DateTime(1999,8,15), INN="111111111"},
                    new Person() { Id = 2,  FirstName = "Ivan", LastName = "Darada",  DateBirthday = new DateTime(1990,4,22), INN="222222222"},
                    new Person() { Id = 3,  FirstName = "Petr", LastName = "Sivoy",  DateBirthday = new DateTime(1989,3,17), INN="333333333"},
                    new Person() { Id = 4,  FirstName = "Dasha", LastName = "Sejneko",  DateBirthday = new DateTime(1991,2,21), INN="777777777"},
                    new Person() { Id = 6,  FirstName = "Masha", LastName = "Rakov",  DateBirthday = new DateTime(1998,2,21), INN="999999999"},
                    new Person() { Id = 7,  FirstName = "Igor", LastName = "Krivonos",  DateBirthday = new DateTime(1999,8,15), INN="111111111"},
                    new Person() { Id = 8,  FirstName = "Vasja", LastName = "Prudnikov",  DateBirthday = new DateTime(1990,4,22), INN="222222222"},
                    new Person() { Id = 9,  FirstName = "Anna", LastName = "Sivoy",  DateBirthday = new DateTime(1989,3,17), INN="333333333"},
                    new Person() { Id = 11,  FirstName = "Pavel", LastName = "Sejneko",  DateBirthday = new DateTime(1991,2,21), INN="777777777"},
                    new Person() { Id = 12,  FirstName = "Jon", LastName = "Smitt",  DateBirthday = new DateTime(1998,2,21), INN="999999999"},

                };
            return list;
        }
    }
}
