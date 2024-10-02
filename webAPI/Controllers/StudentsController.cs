using webAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly DatabaseContext _context;

        public StudentsController(DatabaseContext context)
        {
            _context = context;
        }


        // GET: api/developer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentWithCourses>>> GetDevelopers()
        {
            List<StudentWithCourses> studentsWithCourses = _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .Select(s => new StudentWithCourses
                {
                    StudentId = s.StudentId,
                    FullName = $"{s.FirstName} {s.LastName}",
                    Courses = s.Enrollments.Select(e => e.Course.CourseName).ToList()
                })
                .ToList();

            return studentsWithCourses;
        }

    }

}
