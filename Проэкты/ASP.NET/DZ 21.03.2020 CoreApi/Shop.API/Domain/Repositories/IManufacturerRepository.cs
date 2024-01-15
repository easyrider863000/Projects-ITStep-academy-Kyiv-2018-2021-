using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.API.Domain.Models;

namespace Shop.API.Domain.Repositories
{
    public interface IManufacturerRepository
    {
        Task<IEnumerable<Manufacturer>> ListAsync();
        Task AddAsync(Manufacturer manufacturer);
        void Update(Manufacturer manufacturer);
        Task<Manufacturer> FindByIdAsync(int id);
        void Remove(Manufacturer manufacturer);
    }
}


