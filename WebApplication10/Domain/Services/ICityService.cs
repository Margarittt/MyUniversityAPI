using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;

namespace WebApplication10.Controllers
{
    public interface ICityService
    {
        Task<IEnumerable<City>> ListAsync();
        //Task<CityResponse> SaveAsync(City city);
        //Task<CityResponse> UpdateAsync(int id, City city);
        //Task<CityResponse> DeleteAsync(int id);
    }
}