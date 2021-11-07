using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communications
{
    public class ClientResponse : BaseResponse<Client>
    {
        public ClientResponse(Client resource) : base(resource)
        {
        }

        public ClientResponse(string message) : base(message)
        {
        }
    }
}
