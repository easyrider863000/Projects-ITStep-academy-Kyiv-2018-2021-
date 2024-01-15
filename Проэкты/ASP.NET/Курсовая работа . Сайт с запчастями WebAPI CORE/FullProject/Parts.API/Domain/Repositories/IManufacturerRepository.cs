using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;

namespace Parts.API.Domain.Repositories
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