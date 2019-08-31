using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Resources;

namespace WebApplication10.Domain.Services
{
    public interface IFacultyService
    {
        Task<IEnumerable<Faculty>> ListAsync();
        Task<ResponseModel<FacultyResource>> SaveAsync(Faculty faculty);
        Task<ResponseModel<FacultyResource>> UpdateAsync(int id, Faculty faculty);
        Task<ResponseModel<FacultyResource>> DeleteAsync(int id);
    }
}
