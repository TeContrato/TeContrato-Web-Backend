﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Persistence.Repositories;

namespace Supermarket.API.Persistence.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {

        public ClientRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task AddAsync(Client client)
        {
            await _context.AddAsync(client);
        }

        public async Task<Client> FindById(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public void Remove(Client client)
        {
            _context.Remove(client);
        }
        public void Update(Client client)
        {
            _context.Update(client);
        }
    }
}
