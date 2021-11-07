using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communications
{
    public class ProjectResponse : BaseResponse<Project>
    {
        public ProjectResponse(Project resource) : base(resource)
        {
        }

        public ProjectResponse(string message) : base(message)
        {
        }
    }
}