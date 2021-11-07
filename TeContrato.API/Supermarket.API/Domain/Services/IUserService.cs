using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Domain.Services
{
    //Una interfaz es para declarar algo que se va a usar, pero no se ha declarado todavía
    //Así como en C++ en clases que declarabas los métodos dentro e implementabas afuera
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> SaveAsync(User city);
        Task<UserResponse> UpdateAsync(int id, User city);
        Task<UserResponse> DeleteAsync(int id);

    }
}
