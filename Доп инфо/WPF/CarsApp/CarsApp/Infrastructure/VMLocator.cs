using CarsApp.BLL.Modules;
using CarsApp.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp.Infrastructure
{
    class VMLocator
    {
        IKernel kernel;
        public VMLocator()
        {
            kernel = new StandardKernel(new CarsAppNinjectModule());
        }
        public MainViewModel MainViewModel
        {
            get => kernel.Get<MainViewModel>();
        }
    }
}
