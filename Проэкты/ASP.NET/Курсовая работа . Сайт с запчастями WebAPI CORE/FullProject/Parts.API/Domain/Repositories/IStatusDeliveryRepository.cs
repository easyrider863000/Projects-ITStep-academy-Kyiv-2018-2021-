using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;

namespace Parts.API.Domain.Repositories
{
    public interface IStatusDeliveryRepository
    {
        Task<IEnumerable<StatusDelivery>> ListAsync();
        Task AddAsync(StatusDelivery statusDelivery);
        void Update(StatusDelivery statusDelivery);
        Task<StatusDelivery> FindByIdAsync(int id);
        void Remove(StatusDelivery statusDelivery);
    }
}