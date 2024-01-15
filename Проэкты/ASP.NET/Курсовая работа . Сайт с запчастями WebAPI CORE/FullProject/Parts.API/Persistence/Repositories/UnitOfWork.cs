using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PartsDBContext context;
        public UnitOfWork(PartsDBContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}