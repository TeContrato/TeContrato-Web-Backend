using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communications
{
    public class JobResponse : BaseResponse<Job>
    {
        public JobResponse(Job resource) : base(resource)
        {
        }

        public JobResponse(string message) : base(message)
        {
        }
    }
}