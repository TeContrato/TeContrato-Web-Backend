﻿using Supermarket.API.Domain.Persistence.Contexts;

namespace Supermarket.API.Persistence.Repositories
{
    //Todos los repositories a la larga van a tratar con esta clase.
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
