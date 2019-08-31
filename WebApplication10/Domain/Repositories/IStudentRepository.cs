using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;

namespace WebApplication10.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> ListAsync();
        Task AddAsync(Student student);
        Task<Student> FindByIdAsync(int id);
        void Update(Student student);
        void Remove(Student student);
    }
}
