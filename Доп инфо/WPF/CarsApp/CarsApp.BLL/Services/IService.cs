using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp.BLL.Services
{
    public interface IService<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
