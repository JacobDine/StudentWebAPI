using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly StudentWebAPIContext _context;
    public CoursesController(StudentWebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult getCourses()
    {
        return Ok(_context.Course.ToList());
    }
}
