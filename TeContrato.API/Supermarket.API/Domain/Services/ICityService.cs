using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Domain.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> ListAsync();
        Task<CityResponse> GetByIdAsync(int id);
        Task<CityResponse> SaveAsync(City city);
        Task<CityResponse> UpdateAsync(int id, City city);
        Task<CityResponse> DeleteAsync(int id);
    }
}
