using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Domain.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<ProjectResponse> GetByIdAsync(int id);
        Task<ProjectResponse> SaveAsync(Project city);
        Task<ProjectResponse> UpdateAsync(int id, Project city);
        Task<ProjectResponse> DeleteAsync(int id);
    }
}