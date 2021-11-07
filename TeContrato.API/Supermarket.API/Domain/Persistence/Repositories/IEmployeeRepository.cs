using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Persistence.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employees>> ListAsync();
        Task AddAsync(Employees employees);
        Task<Employees> FindById(int id);
        void Update(Employees employees);
        void Remove(Employees employees);
    }
}