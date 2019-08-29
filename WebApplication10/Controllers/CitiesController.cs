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
         /// <summary>
         /// Saves a new city
         /// </summary>
         /// <param name="resource">City data</param>
         /// <returns>Response for request</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCityResource resource)
        {
            var city = mapper.Map<SaveCityResource, City>(resource);
            var result = await cityService.SaveAsync(city);

            if (!result.Success)
                return BadRequest(result);

            var cityResource = mapper.Map<City, CityResource>(city);
            result.Data = cityResource;
            return Ok(result);
        }

         /// <summary>
         /// Updates an existing country
         /// </summary>
         /// <param name="id">City identifier</param>
         /// <param name="resource">Updated city data</param>
         /// <returns>Response for request</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,[FromBody] SaveCityResource resource)
        {
            var city = mapper.Map<SaveCityResource, City>(resource);
            var result = await cityService.UpdateAsync(id,city);

            if (!result.Success)
                return BadRequest(result);

            var cityResource =  mapper.Map<City, CityResource>(city);
            cityResource.Id = id;
            result.Data = cityResource;
            return Ok(result);
        }

        /// <summary>
        /// Deletes a given City
        /// </summary>
        /// <param name="id">City identifier</param>
        /// <returns>Response result</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await cityService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}