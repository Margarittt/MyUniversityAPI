using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Services.ResponseResult;

namespace WebApplication10.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> ListAsync();
        Task<ResponseModel<Country>> SaveAsync(Country country);
        Task<CountryResponse> UpdateAsync(int id, Country country);
        Task<CountryResponse> DeleteAsync(int id);
    }
}
