using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Resources
{
    public class SaveUniversityResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}
