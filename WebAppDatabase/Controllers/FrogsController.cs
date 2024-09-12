using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppDatabase.NewFolder;
using WebAppDatabase.NewFolder1;

namespace WebAppDatabase.Controllers
{
    [Route("api/[controller]")] // RouteProperty
    [ApiController]
    public class FrogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FrogsController(ApplicationDbContext context)
        {
            _context = context; 
        }

        [HttpGet]

        public IActionResult GetFrogs(string firstname)
        {
            IQueryable<Student> query = _context.Students.Include(x => x.Classroom);
            if(!string.IsNullOrWhiteSpace(firstname))
            {
                query = query.Where(x => x.FirstName == firstname);
            }
            query = query.OrderBy(x => x.LastName);
            var students = query.ToList();
            /*var students = _context.Students.Where(x => x.FirstName == "Tonda").ToList();*/
            return Ok(students);
        }

        [HttpGet("{id}")]

        public IActionResult GetFrog(int id)
        {
            // var student = _context.Students.Find(id);
            var student = _context.Students.Where(x => x.StudentId == id).SingleOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
            //Single() - přesně jeden záznam, pokud není, tak vyjímka
            //SingleOrDefault() - přesně jeden záznam, pokud není, tak null
            //First() - první záznam, pokud není, tak vyjímka
            //FirstOrDefault() - první záznam, pokud není, tak null
            //Last() - poslední záznam, pokud není, tak vyjímka
            //LastOrDefault() - poslední záznam, pokud není, tak null
            //ToList() - všechny záznamy
            //ToArray() - všechny záznamy
            //Query() - IQueryable
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
