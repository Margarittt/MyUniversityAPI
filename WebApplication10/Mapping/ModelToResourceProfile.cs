using AutoMapper;
using WebApplication10.Domain.Models;
using WebApplication10.Resources;

namespace WebApplication10.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Country, CountryResource>();
            CreateMap<City, CityResource>();
            CreateMap<University, UniversityResource>();
            CreateMap<Faculty, FacultyResource>();
            CreateMap<Student, StudentResource>();
        }
    }
}
