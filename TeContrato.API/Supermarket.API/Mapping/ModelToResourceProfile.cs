using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Resources;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<City, CityResource>();
            CreateMap<Client, ClientResource>();
            CreateMap<Contractor, ContractorResource>();
            CreateMap<Project, ProjectResource>();
            CreateMap<Posts, PostsResource>();
            CreateMap<Employees, EmployeesResource>();
            CreateMap<Job, JobResource>();
            CreateMap<ControlEmployees, ControlEmployeeResource>();
            CreateMap<ProjectControl, ProjectControlResource>();
        }
    }
}
