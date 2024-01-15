using CarsApp.BLL.DTO;
using CarsApp.BLL.Services;
using CarsApp.DAL.Models;
using CarsApp.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp.BLL.Modules
{
    public class CarsAppNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Car>>().To<CarRepository>();
            Bind<IService<CarDTO>>().To<CarService>();
        }
    }
}
