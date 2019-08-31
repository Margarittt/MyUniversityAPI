using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Resources;

namespace WebApplication10.Domain.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> ListAsync();
        Task<ResponseModel<StudentResource>> SaveAsync(Student student);
        Task<ResponseModel<StudentResource>> UpdateAsync(int id, Student student);
        Task<ResponseModel<StudentResource>> DeleteAsync(int id);
    }
}
