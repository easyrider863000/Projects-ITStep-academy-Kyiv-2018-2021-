using CarsApp.BLL.DTO;
using CarsApp.BLL.Services;
using CarsApp.Extensions;
using CarsApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarsApp.ViewModels
{
    class MainViewModel
    {
        IService<CarDTO> carService;

        public ObservableCollection<CarDTO> Cars { get; set; }

        public CarDTO SelectedCar { get; set; }
        public MainViewModel(IService<CarDTO> carService)
        {
            this.carService = carService;
            Configure();
        }
        private void Configure()
        {
            Cars = carService.GetAll().ToObservableCollection();
            RemoveCommand = new RelayCommand(x =>
            {
                carService.Delete(SelectedCar);
                Cars.Remove(SelectedCar);
            }, x => Cars.Count > 0);
            AddCommand = new RelayCommand(x =>
            {
                CarDTO newCar = new CarDTO();
                carService.Create(newCar);
                Cars.Add(newCar);
            });
            SaveCommand = new RelayCommand(x =>
            {
                carService.Update(SelectedCar);
            });
        }


        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }
    }
}
