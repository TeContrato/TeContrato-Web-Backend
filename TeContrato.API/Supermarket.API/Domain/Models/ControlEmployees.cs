using System.Collections.Generic;

namespace Supermarket.API.Domain.Models
{
    public class ControlEmployees
    {
        public int id { get; set; }
        public IList<ProjectControl> ProjectControl_Control { get; set; }
        public IList<Employees> Employees_Cemployee { get; set; }
    }
}