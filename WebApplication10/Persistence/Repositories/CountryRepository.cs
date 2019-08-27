using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Repositories;
using WebApplication10.Persistence.Context;

namespace WebApplication10.Persistence.Repositories
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await context.Countries.ToListAsync();
        }
        public async Task AddAsync(Country country)
        {
            await context.Countries.AddAsync(country);
        }
        public async Task<Country> FindByIdAsync(int id)
        {
            return await context.Countries.FindAsync(id);
        }

        public void Update(Country country)
        {
            context.Countries.Update(country);
        }
        public void Remove(Country country)
        {
            context.Countries.Remove(country);
        }
    }
}
