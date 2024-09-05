using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppDatabase.NewFolder;

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
    }
}
