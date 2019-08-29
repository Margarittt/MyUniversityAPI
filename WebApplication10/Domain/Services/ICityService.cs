using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Services;
using WebApplication10.Resources;

namespace WebApplication10.Controllers
{
    public interface ICityService
    {
        Task<IEnumerable<City>> ListAsync();
        Task<ResponseModel<CityResource>> SaveAsync(City city);
        Task<ResponseModel<CityResource>> UpdateAsync(int id,City city);
        Task<ResponseModel<CityResource>> DeleteAsync(int id);
    }
}