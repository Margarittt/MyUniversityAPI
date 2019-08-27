using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;

namespace WebApplication10.Domain.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> ListAsync();
        Task AddAsync(Country country);
        Task<Country> FindByIdAsync(int id);
        void Update(Country country);
        void Remove(Country country);
    }
}
