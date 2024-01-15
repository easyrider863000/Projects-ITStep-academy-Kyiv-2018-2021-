using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Domain.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ListAsync();
        Task<OrderResponse> SaveAsync(Order order);
        Task<OrderResponse> UpdateAsync(int id, Order order);
        Task<OrderResponse> DeleteAsync(int id);
    }
}