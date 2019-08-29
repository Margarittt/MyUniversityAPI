using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Resources;

namespace WebApplication10.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> ListAsync();
        Task<ResponseModel<CountryResource>> SaveAsync(Country country);
        Task<ResponseModel<CountryResource>> UpdateAsync(int id, Country country);
        Task<ResponseModel<CountryResource>> DeleteAsync(int id);
    }
}
