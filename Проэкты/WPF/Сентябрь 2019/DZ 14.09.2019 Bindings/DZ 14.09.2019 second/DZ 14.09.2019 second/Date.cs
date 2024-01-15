using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_14._09._2019_second
{
    class Date
    {
        public ObservableCollection<Car> Cars { get; set; }
        public Car SelectedCar { get; set; }
        public Date()
        {
            Cars = new ObservableCollection<Car>()
            {
                new Car(){Color="White", Title="BMW 640i", Year=2016},
                new Car(){Color="Black", Title="Lexus is200", Year=2000},
                new Car(){Color="SpaceGray", Title="Mercedes-Benz e55 AMG", Year=1999}
            };
            SelectedCar = Cars[0];
        }
    }
}
