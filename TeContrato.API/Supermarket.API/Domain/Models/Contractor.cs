using System.Collections.Generic;

namespace Supermarket.API.Domain.Models
{
    public class Contractor
    {
        public int Cuser { get; set; }
        public string Tbio { get; set; }
        public string Neducation { get; set; }
        public int Numphone { get; set; }
        
        public IList<Project> CProject { get; set; }
        public City Ccity { get; set; }
        
        public IList<Posts> Posts { get; set; }
        
        public IList<Job> Jobs { get; set; }
        

        
    }
}
