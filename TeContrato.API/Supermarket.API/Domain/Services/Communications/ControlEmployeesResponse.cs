using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communications
{
    public class ControlEmployeesResponse : BaseResponse<ControlEmployees>
    {
        public ControlEmployeesResponse(ControlEmployees resource) : base(resource)
        {
        }

        public ControlEmployeesResponse(string message) : base(message)
        {
        }
    }
}