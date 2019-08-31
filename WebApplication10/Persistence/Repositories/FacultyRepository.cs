using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Repositories;
using WebApplication10.Persistence.Context;

namespace WebApplication10.Persistence.Repositories
{
    public class FacultyRepository : BaseRepository, IFacultyRepository
    {
        public FacultyRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Faculty>> ListAsync()
        {
            return await context.Faculties.Include(p => p.University).ToListAsync();
        }

        public async Task AddAsync(Faculty faculty)
        {
            await context.Faculties.AddAsync(faculty);
        }
        public async Task<Faculty> FindByIdAsync(int id)
        {
            return await context.Faculties.FindAsync(id);
        }

        public void Update(Faculty faculty)
        {
            context.Faculties.Update(faculty);
        }

        public void Remove(Faculty faculty)
        {
            context.Faculties.Remove(faculty);
        }
    }
}

