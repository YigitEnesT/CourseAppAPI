using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presantation.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CourseController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var courses = await _manager.CourseService.GetAllCoursesAsync(false);
            return Ok(courses);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCourseAsync([FromRoute] int id)
        {
            var course = await _manager.CourseService.GetOneCourseByIdAsync(id, false);
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneCourseAsync([FromBody] CourseDtoForInsertion courseDto)
        {
            if (courseDto is null)
                return BadRequest();
            var course = await _manager.CourseService.CreateOneCourseAsync(courseDto);
            return StatusCode(201, course);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCourseAsync([FromRoute(Name = "id")] int id, [FromBody] CourseDtoForUpdate courseDto)
        {

            if (courseDto is null)
                return BadRequest();

            await _manager.CourseService.UpdateOneCourseAsync(id, courseDto, false);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCourseAsync([FromRoute] int id)
        {
            await _manager.CourseService.DeleteOneCourseAsync(id, false);
            return NoContent();
        }
    }
}
