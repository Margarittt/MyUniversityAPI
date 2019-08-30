using System;
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
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversityService universityService;
        private readonly IMapper mapper;
        public UniversitiesController(IUniversityService universityService, IMapper mapper)
        {
            this.universityService = universityService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Lists all existing universities.
        /// </summary>
        /// <returns>List of universities.</returns>
        [HttpGet]
        public async Task<IEnumerable<UniversityResource>> ListAsync()
        {
            var universities = await universityService.ListAsync();
            var resources = mapper.Map<IEnumerable<University>, IEnumerable<UniversityResource>>(universities);
            return resources;
        }

        /// <summary>
        /// Saves a new university
        /// </summary>
        /// <param name="resource">University data</param>
        /// <returns>Response for request</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUniversityResource resource)
        {
            var university = mapper.Map<SaveUniversityResource, University>(resource);
            var result = await universityService.SaveAsync(university);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing university
        /// </summary>
        /// <param name="id">University identifier</param>
        /// <param name="resource">Updated university data</param>
        /// <returns>Response for request</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUniversityResource resource)
        {
            var university = mapper.Map<SaveUniversityResource, University>(resource);
            var result = await universityService.UpdateAsync(id, university);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a given University
        /// </summary>
        /// <param name="id">University identifier</param>
        /// <returns>Response result</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await universityService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
