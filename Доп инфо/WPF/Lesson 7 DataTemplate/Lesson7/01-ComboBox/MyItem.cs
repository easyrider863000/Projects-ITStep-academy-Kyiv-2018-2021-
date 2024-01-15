using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ComboBox
{
    public class MyItem
    {
        public string Name { get; set; }
        public string Picture { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
