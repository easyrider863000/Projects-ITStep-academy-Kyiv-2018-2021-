using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public class ManufacturerRepository : BaseRepository, IManufacturerRepository
    {
        public ManufacturerRepository(PartsDBContext context) : base(context)
        {
        }

        public async Task AddAsync(Manufacturer manufacturer)
        {
            await context.Manufacturer.AddAsync(manufacturer);
        }

        public async Task<Manufacturer> FindByIdAsync(int id)
        {
            return await context.Manufacturer.FindAsync(id);
        }

        public async Task<IEnumerable<Manufacturer>> ListAsync()
        {
            return await context.Manufacturer.ToListAsync();
        }

        public void Remove(Manufacturer manufacturer)
        {
            context.Manufacturer.Remove(manufacturer);
        }

        public void Update(Manufacturer manufacturer)
        {
            context.Manufacturer.Update(manufacturer);
        }
    }
}