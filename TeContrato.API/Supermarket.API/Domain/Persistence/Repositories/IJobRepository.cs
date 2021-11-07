using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Persistence.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> ListAsync();
        Task AddAsync(Job job);
        Task<Job> FindById(int id);
        void Update(Job job);
        void Remove(Job job);
    }
}