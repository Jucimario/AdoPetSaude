using APIAdoPet.Dtos.PetDtos;
using APIAdoPet.Dtos.UserDtos;
using APIAdoPet.Models;
using AutoMapper;

namespace APIAdoPet.Profiles;

public class DbProfile : Profile
{ 

    public DbProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, CreateUserDto>();

        CreateMap<UpdateUserDto, User>();
        CreateMap<User, UpdateUserDto>();
        
        CreateMap<User, UserDto>();

        CreateMap<PetDto, Pet>();
        CreateMap<Pet, PetDto>();

        CreateMap<CreatePetDto, Pet>();
        CreateMap<UpdatePetDto, Pet>();

    }
}




