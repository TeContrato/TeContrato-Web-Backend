using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources
{
    public class SavePostsResource
    {
        [Required]
        [MaxLength(30)]
        public string Ntitle { get; set; }
        public string Tbody { get; set; }
    }
}