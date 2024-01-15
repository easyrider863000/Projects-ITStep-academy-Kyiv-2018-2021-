using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Domain.Services
{
    public interface IManufacturerService
    {
        Task<IEnumerable<Manufacturer>> ListAsync();
        Task<ManufacturerResponse> SaveAsync(Manufacturer manufacturer);
        Task<ManufacturerResponse> UpdateAsync(int id, Manufacturer manufacturer);
        Task<ManufacturerResponse> DeleteAsync(int id);
    }
}