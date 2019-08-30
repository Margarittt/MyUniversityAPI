using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;

namespace WebApplication10.Domain.Repositories
{
    public interface IUniversityRepository
    {
        Task<IEnumerable<University>> ListAsync();
        Task AddAsync(University university);
        Task<University> FindByIdAsync(int id);
        void Update(University university);
        void Remove(University university);
    }
}
