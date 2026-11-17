using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly StudentWebAPIContext _context;
    public StudentsController(StudentWebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult getStudents()
    {
        return Ok(_context.Student.ToList());
    }

    [HttpPost]
    public IActionResult PostStudent(Student student)
    {
        _context.Student.Add(student);
        _context.SaveChanges();
        return Ok("Student added successfully");
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id) 
    {
        Student student = _context.Student.Find(id);
        if (student == null)
            return NotFound();
        return Ok(student);
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteStudent(int id)
    {
        Student student = _context.Student.Find(id);
        if (student == null)
            return NotFound();
        else 
        {
            _context.Student.Remove(student);
            _context.SaveChanges();
            return Ok("Student deleted successfully");
        }
    }

    [HttpPut]
    public IActionResult PutStudent(Student student)
    {
        /*  var s = _context.Student.Find(student.Id);
          if (s == null)
              return NotFound();
          else
          {
              s.Name = student.Name;
              s.City = student.City;
              s.Age = student.Age;
              _context.SaveChanges();
              return Ok("Student updated successfully");
          }
        */

        try {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok("Student updated successfully");
    }
}
