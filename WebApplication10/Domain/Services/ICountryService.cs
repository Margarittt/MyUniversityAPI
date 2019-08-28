using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;

namespace WebApplication10.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> ListAsync();
        Task<ResponseModel<Country>> SaveAsync(Country country);
        Task<ResponseModel<Country>> UpdateAsync(int id, Country country);
        Task<ResponseModel<Country>> DeleteAsync(int id);
    }
}
