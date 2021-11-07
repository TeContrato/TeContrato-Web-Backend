using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Persistence.Repositories;

namespace Supermarket.API.Persistence.Repositories
{
    public class PostsRepository : BaseRepository, IPostRepository
    {
        public PostsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Posts>> ListAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task AddAsync(Posts posts)
        {
            await _context.AddAsync(posts);
        }

        public async Task<Posts> FindById(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public void Remove(Posts posts)
        {
            _context.Remove(posts);
        }
        public void Update(Posts posts)
        {
            _context.Update(posts);
        }
    }
}