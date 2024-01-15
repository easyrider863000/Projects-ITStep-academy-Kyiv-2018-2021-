using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DataTrigger
{
    public class Country
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public Country()
        {

        }

        public Country(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
