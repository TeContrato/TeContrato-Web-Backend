using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Domain.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Posts>> ListAsync();
        Task<PostsResponse> GetByIdAsync(int id);
        Task<PostsResponse> SaveAsync(Posts posts);
        Task<PostsResponse> UpdateAsync(int id, Posts posts);
        Task<PostsResponse> DeleteAsync(int id);
    }
}