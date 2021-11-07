using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Persistence.Repositories;

namespace Supermarket.API.Persistence.Repositories
{
    //Se crea un repository porque estamos tratando de mantener en un solo lugar el código ligado a la persistencia, para que no se mezcle
    //con el código de lógica de negocio. Solo para mantener el código separado.
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Remove(User user)
        {
            _context.Remove(user);
        }
        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
