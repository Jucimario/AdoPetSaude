using APIAdoPet.Dtos.PetDtos;
using APIAdoPet.Models;
using AutoMapper;

namespace APIAdoPet.Profiles;

public class PetProfile : Profile
{

    public PetProfile()
    {
        CreateMap<PetDto, Pet>();
        CreateMap<Pet, PetDto>();        

        CreateMap<CreatePetDto, Pet>();

        CreateMap<UpdatePetDto, Pet>();

        CreateMap<ReadPetDto, Pet>();
        CreateMap<Pet, ReadPetDto>();
    }

}

