using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Persistence.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> ListAsync();
        Task AddAsync(Client client);
        Task<Client> FindById(int id);
        void Update(Client client);
        void Remove(Client client);
    }
}
