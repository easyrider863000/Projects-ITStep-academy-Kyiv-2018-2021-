using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.API.Domain.Models;
using Shop.API.Domain.Repositories;
using Shop.API.Persistence.Contexts;

namespace Shop.API.Persistence.Repositories
{
    public class ManufacturerRepository : BaseRepository, IManufacturerRepository
    {
        public ManufacturerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Manufacturer manufacturer)
        {
            await context.Manufacturers.AddAsync(manufacturer);
        }

        public async Task<Manufacturer> FindByIdAsync(int id)
        {
            return await context.Manufacturers.FindAsync(id);
        }

        public async Task<IEnumerable<Manufacturer>> ListAsync()
        {
            return await context.Manufacturers.ToListAsync();
        }

        public void Remove(Manufacturer manufacturer)
        {
            context.Manufacturers.Remove(manufacturer);
        }

        public void Update(Manufacturer manufacturer)
        {
            context.Manufacturers.Update(manufacturer);
        }
    }
}