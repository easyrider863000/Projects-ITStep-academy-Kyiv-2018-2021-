using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(PartsDBContext context) : base(context)
        {
        }

        public async Task AddAsync(Category category)
        {
            await context.Category.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await context.Category.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await context.Category.ToListAsync();
        }

        public void Remove(Category category)
        {
            context.Category.Remove(category);
        }

        public void Update(Category category)
        {
            context.Category.Update(category);
        }
    }
}