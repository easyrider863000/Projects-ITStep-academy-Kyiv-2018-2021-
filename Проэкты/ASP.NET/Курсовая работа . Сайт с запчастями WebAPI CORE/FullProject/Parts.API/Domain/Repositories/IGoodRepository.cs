using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;

namespace Parts.API.Domain.Repositories
{
    public interface IGoodRepository
    {
        Task<IEnumerable<Good>> ListAsync();
        Task AddAsync(Good good);
        void Update(Good good);
        Task<Good> FindByIdAsync(int id);
        void Remove(Good good);
    }
}