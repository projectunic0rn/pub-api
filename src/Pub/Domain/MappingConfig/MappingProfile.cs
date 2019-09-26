using AutoMapper;
using Domain.Models;
using Infrastructure.Persistence.Entities;
using Common.DTOs;

namespace Domain.MappingConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<ProjectTypeDto, ProjectTypeEntity>().ReverseMap();
            CreateMap<ProjectDto, ProjectEntity>().ReverseMap();
            CreateMap<ProjectTypeDto, ProjectTypeEntity>().ReverseMap();
            CreateMap<ProjectTechnologyDto, TechnologyEntity>().ReverseMap();
            CreateMap<ProjectUserDto, ProjectUserEntity>().ReverseMap();
        }
    }
}