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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Lists all existing students.
        /// </summary>
        /// <returns>List of students.</returns>
        [HttpGet]
        public async Task<IEnumerable<StudentResource>> ListAsync()
        {
            var students = await studentService.ListAsync();
            var resources = mapper.Map<IEnumerable<Student>, IEnumerable<StudentResource>>(students);
            return resources;
        }

        /// <summary>
        /// Saves a new student
        /// </summary>
        /// <param name="resource">Student data</param>
        /// <returns>Response for request</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveStudentResource resource)
        {
            var student = mapper.Map<SaveStudentResource, Student>(resource);
            var result = await studentService.SaveAsync(student);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing student
        /// </summary>
        /// <param name="id">Student identifier</param>
        /// <param name="resource">Updated student data</param>
        /// <returns>Response for request</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveStudentResource resource)
        {
            var student = mapper.Map<SaveStudentResource, Student>(resource);
            var result = await studentService.UpdateAsync(id, student);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a given Student
        /// </summary>
        /// <param name="id">Student identifier</param>
        /// <returns>Response result</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await studentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
