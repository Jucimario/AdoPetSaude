using APIAdoPet.Context;
using APIAdoPet.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : Controller
{
    private AppDbContext _context;
    public PetController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddPet([FromBody] Pet pet)
    {
        _context.Pets.Add(pet);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetPetsId), new { id = pet.Id }, pet);
    }

    [HttpGet]
    public IEnumerable<Pet> GetPets([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return (List<Pet>)_context.Pets.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetPetsId(int id)
    {
        var pet = _context.Pets.FirstOrDefault(x => x.Id == id);

        if (pet == null)
            return NotFound();

        return Ok(pet);
    }
}
