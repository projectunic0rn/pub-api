using AutoMapper;
using Domain.Models;
using Infrastructure.Persistence.Entities;

namespace Domain.MappingConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}