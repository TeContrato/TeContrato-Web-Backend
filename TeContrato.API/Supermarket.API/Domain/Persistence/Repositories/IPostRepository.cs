using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Persistence.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Posts>> ListAsync();
        Task AddAsync(Posts posts);
        Task<Posts> FindById(int id);
        void Update(Posts posts);
        void Remove(Posts posts);
    }
}