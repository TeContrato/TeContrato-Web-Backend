using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources
{
    public class SaveClientResource
    {
        [Required]
        [MaxLength(30)]
        public string Tbio { get; set; }
        public string Taddress { get; set; }
    }
}