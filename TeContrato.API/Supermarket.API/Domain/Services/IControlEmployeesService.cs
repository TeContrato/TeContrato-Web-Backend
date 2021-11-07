using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Domain.Services
{
    public interface IControlEmployeesService
    {
        Task<IEnumerable<ControlEmployees>> ListAsync();
        Task<ControlEmployeesResponse> GetByIdAsync(int id);
        Task<ControlEmployeesResponse> SaveAsync(ControlEmployees city);
        Task<ControlEmployeesResponse> UpdateAsync(int id, ControlEmployees city);
        Task<ControlEmployeesResponse> DeleteAsync(int id);
    }
}