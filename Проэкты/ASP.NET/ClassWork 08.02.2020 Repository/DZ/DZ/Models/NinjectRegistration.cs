using DAL_Paggination;
using DAL_Paggination.Models;
using DAL_Paggination.Repositories;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DZ.Models
{
    public class NinjectRegistration:NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Good>>().To<GoodRepository>();
            Bind<IRepository<Category>>().To<CategoryRepository>();
            Bind<IRepository<Manufacturer>>().To<ManufacturerRepository>();
        }
    }
}