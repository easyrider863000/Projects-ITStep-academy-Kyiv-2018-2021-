using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample.Models
{
    public class StorageCategory : ObservableCollection<Category>
    {
        public StorageCategory()
        {
            this.Add(new Category { Id = 1, CategoryName = "PC"});
            this.Add(new Category { Id = 2, CategoryName = "Telephone"});
        }

    }
}
