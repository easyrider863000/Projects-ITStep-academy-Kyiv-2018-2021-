using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Domain.Services
{
    public interface IGoodService
    {
        Task<IEnumerable<Good>> ListAsync();
        Task<GoodResponse> SaveAsync(Good good);
        Task<GoodResponse> UpdateAsync(int id, Good good);
        Task<GoodResponse> DeleteAsync(int id);
    }
}