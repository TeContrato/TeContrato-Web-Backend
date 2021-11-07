using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communications
{
    public class ProjectControlResponse : BaseResponse<ProjectControl>
    {
        public ProjectControlResponse(ProjectControl resource) : base(resource)
        {
        }

        public ProjectControlResponse(string message) : base(message)
        {
        }
    }
}