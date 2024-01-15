using Homework.Infrastructure;
using Homework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.ViewModels
{
    class MainViewModel
    {
        public DataTable Products { get; set; }
        public DBWorker dbGood;
        public DataTable Manufacturers { get; set; }
        public DBWorker dbManufacturer;
        public DataTable Categories { get; set; }
        public DBWorker dbCategory;
        public System.Windows.Input.ICommand SaveCommand { get; set; }
        public MainViewModel()
        {
            dbGood = new DBWorker("Product");
            Products = dbGood.LoadData();
            dbCategory = new DBWorker("Category");
            Categories = dbCategory.LoadData();
            dbManufacturer = new DBWorker("Manufacturer");
            Manufacturers = dbManufacturer.LoadData();
            SaveCommand = new RelayCommand(x =>
            {
                dbGood.Save(Products);
                dbCategory.Save(Categories);
                dbManufacturer.Save(Manufacturers);
            });
        }
    }
}
