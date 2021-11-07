using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Persistence.Repositories;

namespace Supermarket.API.Persistence.Repositories
{
    public class ControlEmployeesRepository : BaseRepository, IControlEmployeesRepository
    {
        public ControlEmployeesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ControlEmployees>> ListAsync()
        {
            return await _context.ControlEmployees.ToListAsync();
        }

        public async Task AddAsync(ControlEmployees controlEmployees)
        {
            await _context.AddAsync(controlEmployees);
        }

        public async Task<ControlEmployees> FindById(int id)
        {
            return await _context.ControlEmployees.FindAsync(id);
        }

        public void Remove(ControlEmployees controlEmployees)
        {
            _context.Remove(controlEmployees);
        }
        public void Update(ControlEmployees controlEmployees)
        {
            _context.Update(controlEmployees);
        }
    }
}