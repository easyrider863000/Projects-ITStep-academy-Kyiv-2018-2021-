using CarsApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp.DAL.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        List<Car> cars = Car.GetCars();
        public void Create(Car obj)
        {
            cars.Add(obj);
        }

        public void Delete(Car obj)
        {
            cars.Remove(obj);
        }

        public Car Get(int id)
        {
            return cars.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return cars;
        }

        public void Update(Car obj)
        {
            Car car = this.Get(obj.Id);
            car.ImageURL = obj.ImageURL;
            car.Color = obj.Color;
            car.Model = obj.Model;
            car.Year = obj.Year;
        }
    }
}
