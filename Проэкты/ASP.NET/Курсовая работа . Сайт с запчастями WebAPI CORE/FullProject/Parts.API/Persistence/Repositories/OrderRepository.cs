using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(PartsDBContext context) : base(context)
        {
        }

        public async Task AddAsync(Order order)
        {
            await context.Order.AddAsync(order);
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            return await context.Order.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await context.Order.ToListAsync();
        }

        public void Remove(Order order)
        {
            context.Order.Remove(order);
        }

        public void Update(Order order)
        {
            context.Order.Update(order);
        }
    }
}