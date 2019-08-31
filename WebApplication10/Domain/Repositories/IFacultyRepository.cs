using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;

namespace WebApplication10.Domain.Repositories
{
    public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> ListAsync();
        Task AddAsync(Faculty faculty);
        Task<Faculty> FindByIdAsync(int id);
        void Update(Faculty faculty);
        void Remove(Faculty faculty);
    }
}
