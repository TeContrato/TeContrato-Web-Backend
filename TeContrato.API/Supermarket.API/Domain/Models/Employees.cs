using System.Collections.Generic;

namespace Supermarket.API.Domain.Models
{
    public class Employees
    {
        public int Cemployee { get; set; }
        public string Nemployee { get; set; }
        public string Tposition { get; set; }
        public int Mpayment { get; set; }
        public string Tworks { get; set; }
        public IList<Job> Cjob { get; set; }
        
        public ControlEmployees CControlEmployees { get; set; }
    }
}