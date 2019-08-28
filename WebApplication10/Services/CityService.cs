using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Controllers;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Repositories;

namespace WebApplication10.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await cityRepository.ListAsync();
        }
    }
}
