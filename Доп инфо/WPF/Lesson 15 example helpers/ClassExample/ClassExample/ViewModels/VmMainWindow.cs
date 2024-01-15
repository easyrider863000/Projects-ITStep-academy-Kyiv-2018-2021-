using ClassExample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample.ViewModels
{
    public class VmMainWindow
    {
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }

        public ObservableCollection<Producer> Producers { get; set; }
        public ObservableCollection<Category> Categorys { get; set; }
        public VmMainWindow()
        {
            Products = new StorageProduct();
            Producers = new StorageProducer();
            Categorys = new StorageCategory();
            SelectedProduct = Products.FirstOrDefault();
        }

    }
}
