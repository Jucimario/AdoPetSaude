using APIAdoPet.Context;
using APIAdoPet.Dtos;
using APIAdoPet.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private AppDbContext _context;
    private IMapper _mapper;
    public UserController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return (List<User>)_context.Users.Skip(skip).Take(take).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult GetUsersPorId(int id)
    {
        var usuario = _context.Users.FirstOrDefault(x => x.Id == id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }


    [HttpPost]
    public ActionResult AddUser([FromBody] CreateUseDto userDto)
    {

        User user = _mapper.Map<User>(userDto);
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUsersPorId), new { id = user.Id }, user);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, User user)
    {
        try
        {
            if (id != user.Id)
            {
                return BadRequest("Dados inválidos");
            }
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(user);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }


    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(p => p.Id == id);

            if (user == null)
            {
                return NotFound($"Usuario não encontrado...");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok(user);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                           "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }
}
