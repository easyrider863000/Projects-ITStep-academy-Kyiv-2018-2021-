using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample.Models
{
    public class StorageProduct : ObservableCollection<Product>
    {
        public StorageProduct()
        {
            this.Add(new Product()
            {
                 Id=1, ProductName= "test IBM PC", SelCategory = new Category { Id = 1, CategoryName = "PC" },
                  SelProducer = new Producer { Id = 1, ProducerName = "IBM", Country = "USA" },
                   Price = 2100M
            });
            this.Add(new Product()
            {
                Id = 2,
                ProductName = "test PC Ba-Ba",
                SelCategory = new Category { Id = 1, CategoryName = "PC" },
                SelProducer =  new Producer { Id = 2, ProducerName = "Ba-Ba", Country = "China" },
                Price = 3333M
            });
            this.Add(new Product()
            {
                Id = 3,
                ProductName = "test Telephone Hitachi",
                SelCategory = new Category {  Id = 2, CategoryName = "Telephone"  },
                SelProducer = new Producer { Id = 3, ProducerName = "Hitachi", Country = "Korea" },
                Price = 4444M
            });
        }
    }
}
