using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Resources;

namespace WebApplication10.Domain.Services
{
    public interface IUniversityService
    {
        Task<IEnumerable<University>> ListAsync();
        Task<ResponseModel<UniversityResource>> SaveAsync(University university);
        Task<ResponseModel<UniversityResource>> UpdateAsync(int id, University university);
        Task<ResponseModel<UniversityResource>> DeleteAsync(int id);
    }
}
