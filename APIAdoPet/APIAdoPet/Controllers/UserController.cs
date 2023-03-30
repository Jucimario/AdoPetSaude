using APIAdoPet.Context;
using APIAdoPet.Models;
using Microsoft.AspNetCore.Mvc;
namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private AppDbContext _context;
    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] User user)
    {

        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUsersPorId), new { id = user.Id }, user);
    }

    [HttpGet]
    public IEnumerable<User> GetUsers([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return (List<User>)_context.Users.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetUsersPorId(int id)
    {
        var usuario = _context.Users.FirstOrDefault(x => x.Id == id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }
}
