using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public class StatusDeliveryRepository : BaseRepository, IStatusDeliveryRepository
    {
        public StatusDeliveryRepository(PartsDBContext context) : base(context)
        {
        }

        public async Task AddAsync(StatusDelivery statusDelivery)
        {
            await context.StatusDelivery.AddAsync(statusDelivery);
        }

        public async Task<StatusDelivery> FindByIdAsync(int id)
        {
            return await context.StatusDelivery.FindAsync(id);
        }

        public async Task<IEnumerable<StatusDelivery>> ListAsync()
        {
            return await context.StatusDelivery.ToListAsync();
        }

        public void Remove(StatusDelivery statusDelivery)
        {
            context.StatusDelivery.Remove(statusDelivery);
        }

        public void Update(StatusDelivery statusDelivery)
        {
            context.StatusDelivery.Update(statusDelivery);
        }
    }
}