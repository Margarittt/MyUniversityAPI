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
    public class UniversityRepository : BaseRepository, IUniversityRepository
    {
        public UniversityRepository(AppDbContext context) : base(context)
        {

        }
        public async  Task<IEnumerable<University>> ListAsync()
        {
            return await context.Universities.Include(p => p.City).ToListAsync();
        }

        public async Task AddAsync(University university)
        {
            await context.Universities.AddAsync(university);
        }
        public async Task<University> FindByIdAsync(int id)
        {
            return await context.Universities.FindAsync(id);
        }

        public void Update(University university)
        {
            context.Universities.Update(university);
        }

        public void Remove(University university)
        {
            context.Universities.Remove(university);
        }
    }
}
