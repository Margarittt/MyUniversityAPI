using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Resources
{
    public class SaveCityResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
