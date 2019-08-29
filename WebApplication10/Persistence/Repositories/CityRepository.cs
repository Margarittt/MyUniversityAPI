using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Repositories;
using WebApplication10.Persistence.Context;

namespace WebApplication10.Persistence.Repositories
{
    public class CityRepository : BaseRepository,ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<City>> ListAsync()
        {
            return await context.Cities.Include(p => p.Country)
                                          .ToListAsync();
        }
        public async Task AddAsync(City city)
        {
            await context.Cities.AddAsync(city);
        }
        public async Task<City> FindByIdAsync(int id)
        {
           return  await context.Cities.FindAsync(id);
        }

        public void Update(City city)
        {
            context.Cities.Update(city);
        }

        public void Remove(City city)
        {
            context.Cities.Remove(city);
        }
    }
}
