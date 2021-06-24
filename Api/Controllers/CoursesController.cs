using System;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repo;
        private readonly IParticipantRepository _partRepo;

        public CoursesController(ICourseRepository repo, IParticipantRepository partRepo)
        {
            _repo = repo;
            _partRepo = partRepo;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCourses()
        {
            var result = await _repo.GetCoursesAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            try
            {
                var course = await _repo.GetCourseByIdAsync(id);

                if (course == null) return NotFound();

                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("find/{coursenum}")]
        public async Task<IActionResult> GetCourseByCourseNum(int coursenum)
        {
            try
            {
                var course = await _repo.GetCourseByCourseNumAsync(coursenum);

                if (course == null) return NotFound();

                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddCourse(Course course)
        {
            try
            {
                await _repo.AddAsync(course);

                if (await _repo.SavAllChangesAsync()) return StatusCode(201);

                return StatusCode(500, "Kunde ej lägga till kurs");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course courseModel)
        {
            var course = await _repo.GetCourseByIdAsync(id);
            course.CourseDesc = courseModel.CourseDesc;
            course.CourseLength = courseModel.CourseLength;
            course.Retired = courseModel.Retired;

            _repo.Update(course);
            var result = await _repo.SavAllChangesAsync();

            return NoContent();
        }
    }
}