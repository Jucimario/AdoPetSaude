using APIAdoPet.Context;
using APIAdoPet.Dtos.UserDtos;
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
        try
        {
            var usuarios = _context.Users.Skip(skip).Take(take).ToList();
            var users = _mapper.Map<List<UserDto>>(usuarios);

            return Ok(users);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                       "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpGet("{id}")]
    public ActionResult GetUsersPorId(int id)
    {
        try
        {
            var usuario = _context.Users.AsNoTracking().Include(p => p.Pets).FirstOrDefault(x => x.Id == id);

            var user = _mapper.Map<UserDto>(usuario);
            if (usuario == null)
                return NotFound();

            return Ok(user);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                       "Ocorreu um problema ao tratar a sua solicitação.");
        }

    }

    [HttpPost]
    public ActionResult AddUser([FromBody] CreateUserDto userDto)
    {
        try
        {
            User user = _mapper.Map<User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsersPorId), new { id = user.Id }, user);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                            "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, [FromBody] UpdateUserDto userDto)
    {
        try
        {
            var user = _context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var sabendo = _mapper.Map(userDto, user);
            _context.Entry(sabendo).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
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

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                           "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }
}
