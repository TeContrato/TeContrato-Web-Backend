using System.Collections.Generic;

namespace Supermarket.API.Domain.Models
{
    public class Client
    {
        public int Cuser { get; set; }
        public string Tbio { get; set; }
        public string Taddress { get; set; }
        public City Ccity { get; set; }
        public IList<Project> CProject { get; set; }
        public IList<Posts> Posts { get; set; }
        public IList<Job> Jobs { get; set; }

    }
}
