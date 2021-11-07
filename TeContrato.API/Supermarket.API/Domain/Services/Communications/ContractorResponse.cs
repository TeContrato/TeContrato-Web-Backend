using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communications
{
    public class ContractorResponse : BaseResponse<Contractor>
    {
        public ContractorResponse(Contractor resource) : base(resource)
        {
        }

        public ContractorResponse(string message) : base(message)
        {
        }
    }
}
