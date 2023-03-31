using APIAdoPet.Dtos;
using APIAdoPet.Models;
using AutoMapper;

namespace APIAdoPet.Profiles;

public class DbProfile : Profile
{ 

    public DbProfile()
    {
        CreateMap<CreateUseDto, User>();

        CreateMap<CreatePetDto, Pet>();

    }
}
