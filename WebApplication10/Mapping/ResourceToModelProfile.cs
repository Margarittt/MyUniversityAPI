using AutoMapper;
using WebApplication10.Domain.Models;
using WebApplication10.Resources;

namespace WebApplication10.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCountryResource, Country>();
            CreateMap<SaveCityResource, City>();
            CreateMap<SaveUniversityResource, University>();
            CreateMap<SaveFacultyResource, Faculty>();
            CreateMap<SaveStudentResource, Student>();
        }
    }
}
