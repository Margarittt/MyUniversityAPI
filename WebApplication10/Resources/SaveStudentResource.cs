using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Resources
{
    public class SaveStudentResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int FacultyId { get; set; }
    }
}
