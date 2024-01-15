using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Domain.Services
{
    public interface IOrderDetailsService
    {
        Task<IEnumerable<OrderDetails>> ListAsync();
        Task<OrderDetailsResponse> SaveAsync(OrderDetails orderDetails);
        Task<OrderDetailsResponse> UpdateAsync(int id, OrderDetails orderDetails);
        Task<OrderDetailsResponse> DeleteAsync(int id);
    }
}