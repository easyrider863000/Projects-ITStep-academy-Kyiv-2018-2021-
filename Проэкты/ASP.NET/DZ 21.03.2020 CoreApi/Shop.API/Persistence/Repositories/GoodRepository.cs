using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.API.Domain.Models;
using Shop.API.Domain.Repositories;
using Shop.API.Persistence.Contexts;

namespace Shop.API.Persistence.Repositories
{
    public class GoodRepository : BaseRepository, IGoodRepository
    {
        public GoodRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Good good)
        {
            await context.Goods.AddAsync(good);
        }

        public async Task<Good> FindByIdAsync(int id)
        {
            return await context.Goods.FindAsync(id);
        }

        public async Task<IEnumerable<Good>> ListAsync()
        {
            return await context.Goods.ToListAsync();
        }

        public void Remove(Good good)
        {
            context.Goods.Remove(good);
        }

        public void Update(Good good)
        {
            context.Goods.Update(good);
        }
        public bool ExistCategory(int id){
            if(context.Categories.Find(id)!=null){
                return true;
            }
            return false;
        }
        public bool ExistManufacturer(int id){
            if(context.Manufacturers.Find(id)!=null){
                return true;
            }
            return false;
        }
    }
}