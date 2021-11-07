using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources
{
    public class SaveJobResource
    {
        [Required]
        [MaxLength(30)]
        public string Njob { get; set; }
        public string Tdescription { get; set; }
    }
}