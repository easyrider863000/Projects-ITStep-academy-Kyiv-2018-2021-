using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;

namespace Parts.API.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> ListAsync();
        Task AddAsync(Order order);
        void Update(Order order);
        Task<Order> FindByIdAsync(int id);
        void Remove(Order order);
    }
}