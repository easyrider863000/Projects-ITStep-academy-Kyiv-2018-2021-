using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;

namespace Parts.API.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
        void Update(Category category);
        Task<Category> FindByIdAsync(int id);
        void Remove(Category category);
    }
}