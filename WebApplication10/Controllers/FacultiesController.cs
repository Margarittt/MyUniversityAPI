using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Services;
using WebApplication10.Resources;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyService facultyService;
        private readonly IMapper mapper;
        public FacultiesController(IFacultyService facultyService, IMapper mapper)
        {
            this.facultyService = facultyService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Lists all existing faculties.
        /// </summary>
        /// <returns>List of faculties.</returns>
        [HttpGet]
        public async Task<IEnumerable<FacultyResource>> ListAsync()
        {
            var faculties = await facultyService.ListAsync();
            var resources = mapper.Map<IEnumerable<Faculty>, IEnumerable<FacultyResource>>(faculties);
            return resources;
        }

        /// <summary>
        /// Saves a new faculty
        /// </summary>
        /// <param name="resource">Faculty data</param>
        /// <returns>Response for request</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveFacultyResource resource)
        {
            var faculty = mapper.Map<SaveFacultyResource, Faculty>(resource);
            var result = await facultyService.SaveAsync(faculty);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing faculty
        /// </summary>
        /// <param name="id">Faculty identifier</param>
        /// <param name="resource">Updated faculty data</param>
        /// <returns>Response for request</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFacultyResource resource)
        {
            var faculty = mapper.Map<SaveFacultyResource, Faculty>(resource);
            var result = await facultyService.UpdateAsync(id, faculty);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a given Faculty
        /// </summary>
        /// <param name="id">Faculty identifier</param>
        /// <returns>Response result</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await facultyService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
