using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Domain.Services
{
    public interface IContractorService
    {
        Task<IEnumerable<Contractor>> ListAsync();
        Task<ContractorResponse> GetByIdAsync(int id);
        Task<ContractorResponse> SaveAsync(Contractor contractor);
        Task<ContractorResponse> UpdateAsync(int id, Contractor contractor);
        Task<ContractorResponse> DeleteAsync(int id);
    }
}
