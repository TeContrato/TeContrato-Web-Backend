using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Persistence.Repositories
{
    public interface IControlEmployeesRepository
    {
        Task<IEnumerable<ControlEmployees>> ListAsync();
        Task AddAsync(ControlEmployees controlEmployees);
        Task<ControlEmployees> FindById(int id);
        void Update(ControlEmployees controlEmployees);
        void Remove(ControlEmployees controlEmployees);
    }
}