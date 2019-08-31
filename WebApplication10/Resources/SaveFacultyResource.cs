using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Resources
{
    public class SaveFacultyResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int UniversityId { get; set; }
    }
}
