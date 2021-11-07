using System.Collections.Generic;
using Google.Protobuf;

namespace Supermarket.API.Domain.Models
{
    public class City
    {
        public int Ccity { get; set; }
        public string Ncity { get; set; }

        public IList<Client> Clients { get; set; }
        
        public IList<Contractor> Contractors { get; set; }
    }
}
