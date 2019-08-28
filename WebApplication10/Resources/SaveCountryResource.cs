using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Resources
{
    public class SaveCountryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
