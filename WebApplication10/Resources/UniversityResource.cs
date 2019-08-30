using WebApplication10.Domain.Models;

namespace WebApplication10.Resources
{
    public class UniversityResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CityResource City { get; set; }
    }
}
