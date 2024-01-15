using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Category SelCategory { get; set; }
        public Producer SelProducer { get; set; }
        public decimal Price { get; set; }
        public ObservableCollection<Photo> Photos { get; set; }

    }
}
