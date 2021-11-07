using System.Threading.Tasks;

namespace Supermarket.API.Domain.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}