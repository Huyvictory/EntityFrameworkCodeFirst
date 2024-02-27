using EntityFrameworkCodeFirst.Context;
using EntityFrameworkCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirst.Controllers
{
    [Route("v1/[controller]/")]
    [ApiController]
    public class StudentController : Controller
    {
        private IApplicationDbContext _context;
        public StudentController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChanges();
            return Ok(student);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _context.Students.ToListAsync();
            if (students == null) return NotFound();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _context.Students.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (student == null) return NotFound();
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (student == null) return NotFound();
            _context.Students.Remove(student);
            await _context.SaveChanges();
            return Ok(student.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Student studentUpdate)
        {
            var student = await _context.Students.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (student == null) return NotFound();
            else
            {
                student.Age = studentUpdate.Age;
                student.Name = studentUpdate.Name;
                await _context.SaveChanges();
                return Ok(student.Id);
            }
        }
    }
}
