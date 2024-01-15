using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.API.Domain.Models;
using Shop.API.Domain.Services.Communication;

namespace Shop.API.Domain.Services
{
    public interface IManufacturerService
    {
        Task<IEnumerable<Manufacturer>> ListAsync();
        Task<ManufacturerResponse> SaveAsync(Manufacturer manufacturer);
        Task<ManufacturerResponse> UpdateAsync(int id, Manufacturer manufacturer);
        Task<ManufacturerResponse> DeleteAsync(int id);        
    }
}