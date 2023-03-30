using APIAdoPet.Models;
using Microsoft.AspNetCore.Mvc;
namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    public static List<User> usuarios = new();
    public int MyProperty { get; set; }

    [HttpPost]
    public IActionResult AddUser([FromBody] User user)
    {
        user.UserId = usuarios.Count() + 1;
        usuarios.Add(user);
        return CreatedAtAction(nameof(GetUsersPorId), new { id = user.UserId }, user);
    }

    [HttpGet]
    public List<User> GetUsers([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return (List<User>)usuarios.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetUsersPorId(int id)
    {
        var usuario = usuarios.FirstOrDefault(x => x.UserId == id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }
}
