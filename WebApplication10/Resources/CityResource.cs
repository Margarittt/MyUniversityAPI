namespace WebApplication10.Resources
{
    public class CityResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryResource Country { get; set; }
    }
}
