using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources
{
    public class SaveEmployeesResource
    {
        [Required]
        [MaxLength(30)]
        public string Nemployee { get; set; }
        public string Tposition { get; set; }
    }
}