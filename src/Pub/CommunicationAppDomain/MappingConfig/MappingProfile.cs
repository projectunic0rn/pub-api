using System;
using AutoMapper;
using Common.Models;
using Infrastructure.Persistence.Entities;

namespace CommunicationAppDomain.MappingConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}
