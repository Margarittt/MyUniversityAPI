using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Repositories;
using WebApplication10.Persistence.Context;

namespace WebApplication10.Persistence.Repositories
{
    public class StudentRepository : BaseRepository,IStudentRepository 
    {
        public StudentRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await context.Students.Include(p => p.Faculty).ToListAsync();
        }

        public async Task AddAsync(Student student)
        {
            await context.Students.AddAsync(student);
        }
        public async Task<Student> FindByIdAsync(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public void Update(Student student)
        {
            context.Students.Update(student);
        }

        public void Remove(Student student)
        {
            context.Students.Remove(student);
        }
    }
}

