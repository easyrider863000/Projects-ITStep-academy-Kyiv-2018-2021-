using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public class OrderDetailsRepository : BaseRepository, IOrderDetailsRepository
    {
        public OrderDetailsRepository(PartsDBContext context) : base(context)
        {
        }

        public async Task AddAsync(OrderDetails orderDetails)
        {
            await context.OrderDetails.AddAsync(orderDetails);
        }

        public async Task<OrderDetails> FindByIdAsync(int id)
        {
            return await context.OrderDetails.FindAsync(id);
        }

        public async Task<IEnumerable<OrderDetails>> ListAsync()
        {
            return await context.OrderDetails.ToListAsync();
        }

        public void Remove(OrderDetails orderDetails)
        {
            context.OrderDetails.Remove(orderDetails);
        }

        public void Update(OrderDetails orderDetails)
        {
            context.OrderDetails.Update(orderDetails);
        }
    }
}