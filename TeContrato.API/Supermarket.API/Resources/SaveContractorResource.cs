using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources
{
    public class SaveContractorResource
    {
        [Required]
        [MaxLength(30)]
        public string Tbio { get; set; }
        public string Numphone { get; set; }
    }
}