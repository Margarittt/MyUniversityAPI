using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Domain.Models;
using WebApplication10.Resources;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService cityService;
        private readonly IMapper mapper;

        public CitiesController(ICityService cityService, IMapper mapper)
        {
            this.cityService = cityService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Lists all existing cities.
        /// </summary>
        /// <returns>List of cities.</returns>
        [HttpGet]
        public async Task<IEnumerable<CityResource>> ListAsync()
        {
            var cities = await cityService.ListAsync();
            var resources = mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(cities);
            return resources;
        }
    }
}