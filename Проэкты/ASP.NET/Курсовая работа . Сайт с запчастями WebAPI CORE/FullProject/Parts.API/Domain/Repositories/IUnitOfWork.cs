using System.Threading.Tasks;

namespace Parts.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}