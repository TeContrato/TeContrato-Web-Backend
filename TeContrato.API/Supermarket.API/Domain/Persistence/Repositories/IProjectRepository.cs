using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Persistence.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task AddAsync(Project project);
        Task<Project> FindById(int id);
        void Update(Project project);
        void Remove(Project project);
    }
}