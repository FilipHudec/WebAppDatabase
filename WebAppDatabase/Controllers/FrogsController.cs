using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppDatabase.NewFolder;
using WebAppDatabase.NewFolder1;

namespace WebAppDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FrogsController(ApplicationDbContext context)
        {
            _context = context; 
        }

        [HttpGet]

        public IActionResult GetFrogs()
        {
            var students = _context.Students.Where(x => x.FirstName == "Tonda").ToList();
            return Ok(students);
        }

        [HttpGet("{id}")]

        public IActionResult GetFrog(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public IActionResult CreateFrog([FromBody] Student student) 
        {
            if (student.FirstName == "Květoslav") return BadRequest("bad news");
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFrog), new { id = student.StudentId }, student);
        }
    }
}
