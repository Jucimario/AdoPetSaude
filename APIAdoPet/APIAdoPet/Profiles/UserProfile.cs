using APIAdoPet.Dtos.PetDtos;
using APIAdoPet.Dtos.UserDtos;
using APIAdoPet.Models;
using AutoMapper;

namespace APIAdoPet.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, CreateUserDto>();

        CreateMap<UpdateUserDto, User>();
        CreateMap<User, UpdateUserDto>();

        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();

        CreateMap<ReadUserDto, User>();
        CreateMap<User, ReadUserDto>();
    }
   
}
