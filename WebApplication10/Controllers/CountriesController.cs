using System;
using WebApplication10.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Services;
using WebApplication10.Resources;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService countryService;
        private readonly IMapper mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            this.countryService = countryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryResource>> GetAllAsync()
        {
            var countries = await countryService.ListAsync();
            var resources = mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCountryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var country = mapper.Map<SaveCountryResource, Country>(resource);
            var result = await countryService.SaveAsync(country);

            if (!result.Success)
                return BadRequest(result.Message);

            var countryResource = mapper.Map<Country, CountryResource>(result.Country);
            return Ok(countryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCountryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var country = mapper.Map<SaveCountryResource, Country>(resource);
            var result = await countryService.UpdateAsync(id, country);

            if (!result.Success)
                return BadRequest(result.Message);

            var countryResource = mapper.Map<Country, CountryResource>(result.Country);
            return Ok(countryResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await countryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var countryResource = mapper.Map<Country, CountryResource>(result.Country);
            return Ok(countryResource);
        }
    }
}