using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Domain.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employees>> ListAsync();
        Task<EmployeesResponse> GetByIdAsync(int id);
        Task<EmployeesResponse> SaveAsync(Employees city);
        Task<EmployeesResponse> UpdateAsync(int id, Employees city);
        Task<EmployeesResponse> DeleteAsync(int id);
    }
}