using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Domain.Services
{
    public interface IStatusDeliveryService
    {
        Task<IEnumerable<StatusDelivery>> ListAsync();
        Task<StatusDeliveryResponse> SaveAsync(StatusDelivery statusDelivery);
        Task<StatusDeliveryResponse> UpdateAsync(int id, StatusDelivery statusDelivery);
        Task<StatusDeliveryResponse> DeleteAsync(int id);
    }
}