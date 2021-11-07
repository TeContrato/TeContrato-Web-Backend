using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Persistence.Repositories;

namespace Supermarket.API.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task AddAsync(Project project)
        {
            await _context.AddAsync(project);
        }

        public async Task<Project> FindById(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public void Remove(Project project)
        {
            _context.Remove(project);
        }
        public void Update(Project project)
        {
            _context.Update(project);
        }
    }
}