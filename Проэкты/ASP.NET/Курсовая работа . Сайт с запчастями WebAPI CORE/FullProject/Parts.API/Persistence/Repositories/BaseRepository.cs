using Parts.API.Domain.Models;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly PartsDBContext context;
        public BaseRepository(PartsDBContext context)
        {
            this.context = context;
        }
    }
}