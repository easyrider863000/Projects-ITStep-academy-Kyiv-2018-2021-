using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DataTrigger
{
    public class Countries : ObservableCollection<Country>
    {
        public Countries()
        {
            this.Add(new Country("Ukraine", "UA"));
            this.Add(new Country("Russia", "RU"));
            this.Add(new Country("United States of America", "USA"));
        }
    }
}
