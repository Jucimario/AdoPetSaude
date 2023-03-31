﻿using APIAdoPet.Context;
using APIAdoPet.Dtos;
using APIAdoPet.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : Controller
{
    private AppDbContext _context;
    private IMapper _mapper;

    public PetController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Pet>> GetPets([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        try
        {

            var pets = _context.Pets.AsNoTracking().Skip(skip).Take(take).ToList();
            return pets;

            //return (List<Pet>)_context.Pets.AsNoTracking().Include(p => p.User).Skip(skip).Take(take).ToList();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                     "Ocorreu um problema ao tratar a sua solicitação.");
        }

    }

    [HttpGet("{id}")]
    public ActionResult GetPetsId(int id)
    {
        var pet = _context.Pets.FirstOrDefault(x => x.Id == id);

        if (pet == null)
            return NotFound($"Pet não encontrado...");

        return Ok(pet);
    }


    [HttpPost]
    public ActionResult AddPet([FromBody] CreatePetDto petDto)
    {

        if (petDto is null)
            return BadRequest("Dados inválidos");

        Pet pet = _mapper.Map<Pet>(petDto);
        _context.Pets.Add(pet);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetPetsId), new { id = pet.Id }, pet);
    }
    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Pet pet)
    {
        try
        {
            var petSelecionado = _context.Pets.FirstOrDefault(p => p.Id == id);

            if (id != petSelecionado.Id)
            {
                return BadRequest("Dados inválidos");
            }

            _context.Entry(pet).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(pet);
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
            var pet = _context.Pets.FirstOrDefault(p => p.Id == id);

            if (pet == null)
            {
                return NotFound($"Pet não encontrado...");
            }
            _context.Pets.Remove(pet);
            _context.SaveChanges();
            return Ok(pet);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                           "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }
}
