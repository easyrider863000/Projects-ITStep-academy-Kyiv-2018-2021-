using System.Threading.Tasks;
using Parts.API.Domain.Models;

namespace Parts.API.Domain.Services
{
    public interface IAuthService
    {
        Task<Client> Authenticate(string login, string password);
    }
}