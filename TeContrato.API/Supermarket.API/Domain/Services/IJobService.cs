using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Domain.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> ListAsync();
        Task<JobResponse> GetByIdAsync(int id);
        Task<JobResponse> SaveAsync(Job city);
        Task<JobResponse> UpdateAsync(int id, Job city);
        Task<JobResponse> DeleteAsync(int id);
    }
}