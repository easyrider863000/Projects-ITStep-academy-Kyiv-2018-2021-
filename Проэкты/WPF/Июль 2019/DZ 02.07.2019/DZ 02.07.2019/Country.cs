using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace DZ_02._07._2019
{
    public class Country
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<string> Photos { get; set; }
        public int Current { get; set; }
        public override string ToString()
        {
            return $"{Name}  {Date.ToShortDateString()}";
        }
    }
    public static class DataLayer
    {
        public static List<Country> GetCountries()
        {
            return new List<Country>()
            {
                new Country(){Current = 0, Name = "Spain", Date = DateTime.Parse("08/18/2019"), Photos = new List<string>(){ "Images\\1.jpg", "Images\\2.jpg", "Images\\3.jpg" } },
                new Country(){Current = 0, Name = "Ukrane", Date = DateTime.Parse("10/22/2019"), Photos = new List<string>(){ "Images\\4.jpg", "Images\\5.jpg", "Images\\6.jpg" } },
                new Country(){Current = 0, Name = "Poland", Date = DateTime.Parse("12/29/2019"), Photos = new List<string>(){ "Images\\7.jpg", "Images\\8.jpg", "Images\\9.jpg" } }
            };
        }
    }
}
