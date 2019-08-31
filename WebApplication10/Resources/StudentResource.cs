namespace WebApplication10.Resources
{
    public class StudentResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FacultyResource Faculty { get; set; }
    }
}
