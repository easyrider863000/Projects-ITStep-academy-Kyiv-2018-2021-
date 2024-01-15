using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public class GoodRepository : BaseRepository, IGoodRepository
    {
        public GoodRepository(PartsDBContext context) : base(context)
        {
        }

        public async Task AddAsync(Good good)
        {
            await context.Good.AddAsync(good);
        }

        public async Task<Good> FindByIdAsync(int id)
        {
            return await context.Good.FindAsync(id);
        }

        public async Task<IEnumerable<Good>> ListAsync()
        {
            return await context.Good.ToListAsync();
        }

        public void Remove(Good good)
        {
            context.Good.Remove(good);
        }

        public void Update(Good good)
        {
            context.Good.Update(good);
        }
    }
}