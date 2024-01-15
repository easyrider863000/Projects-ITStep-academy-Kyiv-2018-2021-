using CarsApp.BLL.DTO;
using CarsApp.DAL.Models;
using CarsApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp.BLL.Services
{
    public class CarService : IService<CarDTO>
    {
        IRepository<Car> repo;
        public CarService(IRepository<Car> repo)
        {
            this.repo = repo;
        }
        public void Create(CarDTO obj)
        {
            Car newCar = new Car
            {
                Id = obj.Id,
                Color = obj.Color,
                Model = obj.Model,
                ImageURL = obj.ImageURL,
                Year = obj.Year
            };
            repo.Create(newCar);
        }

        public void Delete(CarDTO obj)
        {
            Car carDelete = repo.Get(obj.Id);
            repo.Delete(carDelete);
        }

        public CarDTO Get(int id)
        {
            Car carGet = repo.Get(id);
            return new CarDTO
            {
                Id = carGet.Id,
                Color = carGet.Color,
                ImageURL = carGet.ImageURL,
                Year = carGet.Year,
                Model = carGet.Model
                
            };
        }

        public IEnumerable<CarDTO> GetAll()
        {
            return repo
                    .GetAll()
                     .Select(x => new CarDTO
                     {
                         Id = x.Id,
                         Color = x.Color,
                         ImageURL = x.ImageURL,
                         Year = x.Year,
                         Model = x.Model
                     });
        }

        public void Update(CarDTO obj)
        {
            Car carUpdate = repo.Get(obj.Id);
            carUpdate.Color = obj.Color;
            carUpdate.ImageURL = obj.ImageURL;
            carUpdate.Model = obj.Model;
            carUpdate.Year = obj.Year;
            repo.Update(carUpdate);
        }
    }
}
