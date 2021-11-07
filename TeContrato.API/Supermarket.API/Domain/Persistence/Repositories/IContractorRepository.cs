using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Persistence.Repositories
{
    public interface IContractorRepository
    {
        Task<IEnumerable<Contractor>> ListAsync();
        Task AddAsync(Contractor contractor);
        Task<Contractor> FindById(int id);
        void Update(Contractor contractor);
        void Remove(Contractor contractor);
    }
}
