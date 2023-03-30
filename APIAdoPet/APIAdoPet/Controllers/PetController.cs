using APIAdoPet.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : Controller
{

    public static List<Pet> pets = new();

    [HttpPost]
    public void AddUser([FromBody] Pet pet)
    {
        pets.Add(pet);
    }

    [HttpGet]
    public List<Pet> GetUsers()
    {
        return pets;
    }

    [HttpGet]
    public Pet? GetUsers(int id)
    {
        return pets.FirstOrDefault(x => x.PetId == id);
    }
}
