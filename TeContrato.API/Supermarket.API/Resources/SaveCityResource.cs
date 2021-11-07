using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources
{
    public class SaveCityResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
