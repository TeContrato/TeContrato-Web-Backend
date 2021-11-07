using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Domain.Services
{
    public interface IProjectControlService
    {
        Task<IEnumerable<ProjectControl>> ListAsync();
        Task<ProjectControlResponse> GetByIdAsync(int id);
        Task<ProjectControlResponse> SaveAsync(ProjectControl city);
        Task<ProjectControlResponse> UpdateAsync(int id, ProjectControl city);
        Task<ProjectControlResponse> DeleteAsync(int id);
    }
}