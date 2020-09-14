using AutoMapper;
using Common.Models;
using Infrastructure.Persistence.Entities;
using Common.DTOs;

namespace Domain.MappingConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<UserContactDto, UserEntity>().ReverseMap();
            CreateMap<UserDto, UserEntity>().ReverseMap().ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.UserTechnologies));
            CreateMap<UserProfileDto, UserEntity>().ReverseMap().ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.UserTechnologies));
            CreateMap<RecentDevDto, UserEntity>().ReverseMap();
            CreateMap<UserTechnologyDto, TechnologyEntity>().ReverseMap();
            CreateMap<ProjectTypeDto, ProjectTypeEntity>().ReverseMap();
            CreateMap<ProjectDto, ProjectEntity>().ReverseMap();
            CreateMap<ProjectDto, DetailedProjectDto>().ReverseMap();
            CreateMap<DetailedProjectDto, ProjectEntity>().ReverseMap();
            CreateMap<ProjectTypeDto, ProjectTypeEntity>().ReverseMap();
            CreateMap<ProjectCollaboratorSuggestionDto, ProjectCollaboratorSuggestionEntity>().ReverseMap()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl));
            CreateMap<ProjectTechnologyDto, TechnologyEntity>().ReverseMap();
            CreateMap<CommunicationPlatformTypeDto, CommunicationPlatformTypeEntity>().ReverseMap();
            CreateMap<ProjectUserDto, ProjectUserEntity>().ReverseMap().ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));
            CreateMap<DetailedProjectUserDto, ProjectUserEntity>().ReverseMap()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.Timezone, opt => opt.MapFrom(src => src.User.Timezone))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl));
        }
    }
}
