using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;

namespace Parts.API.Domain.Repositories
{
    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetails>> ListAsync();
        Task AddAsync(OrderDetails orderDetails);
        void Update(OrderDetails orderDetails);
        Task<OrderDetails> FindByIdAsync(int id);
        void Remove(OrderDetails orderDetails);
    }
}