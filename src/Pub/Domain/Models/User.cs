using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.AppSettings;
using Common.Contracts;
using Common.DTOs;
using Domain.MappingConfig;
using Infrastructure.Persistence.Entities;

namespace Domain.Models
{
    public class User : IUser
    {
        private readonly IMapper _mapper;

        private readonly IStorage<UserEntity> _userStorage;
        private readonly ProjectEntity _projectStorage;
        private readonly TechnologyEntity _techStorage;
        private readonly string _pubJobsQueueName;
        private readonly IMessageQueue _messageQueue;

        public User(IMessageQueue messageQueue)
        {
            _userStorage = new UserEntity();
            _techStorage = new TechnologyEntity();
            _projectStorage = new ProjectEntity();
            _mapper = new InitializeMapper().GetMapper;
            _pubJobsQueueName = AppSettings.PubJobsQueueName;
            _messageQueue = messageQueue;
        }

        public async Task<List<RecentDevDto>> GetRecentDevsAsync()
        {
            List<UserEntity> users = await _userStorage.FindAllAsync(u => u.LookingForProject && !string.IsNullOrEmpty(u.Bio));
            List<RecentDevDto> recentDevsDto = _mapper.Map<List<RecentDevDto>>(users);
            return recentDevsDto;
        }

        public async Task<UserProfileDto> GetUserAsync(Guid id)
        {
            UserEntity user = await _userStorage.FindAsync(u => u.Id == id);
            UserProfileDto userDto = _mapper.Map<UserProfileDto>(user);
            return userDto;
        }

        public async Task<UserContactDto> GetUserContactAsync(Guid id)
        {
            UserEntity user = await _userStorage.FindAsync(u => u.Id == id);
            UserContactDto userContactDto = _mapper.Map<UserContactDto>(user);
            return userContactDto;
        }

        public async Task<UserDto> UpdateUserAsync(UserDto user)
        {
            UserEntity userEntity = await _userStorage.FindAsync(u => u.Id == user.Id);
            List<TechnologyEntity> technologiesToDelete = new List<TechnologyEntity>(userEntity.UserTechnologies);
            userEntity.UserTechnologies.RemoveAll(t => t.UserId == user.Id);

            userEntity.Bio = user.Bio;
            userEntity.ProfilePictureUrl = user.ProfilePictureUrl;
            userEntity.Username = user.Username;
            userEntity.Email = user.Email;
            userEntity.LookingForProject = user.LookingForProject;
            userEntity.GitHubUsername = user.GitHubUsername;
            userEntity.UserTechnologies.AddRange(MapTechnologies(user.Technologies));
            await RecomputeProjectCollaboratorSuggestions(user);
            await _userStorage.UpdateAsync(userEntity);
            await _techStorage.DeleteAsync(technologiesToDelete);
            UserDto userDto = _mapper.Map<UserDto>(userEntity);
            return userDto;
        }

        private List<TechnologyEntity> MapTechnologies(List<UserTechnologyDto> technologyDtos)
        {
            List<TechnologyEntity> technologies = new List<TechnologyEntity>();
            foreach (var technologyDto in technologyDtos)
            {
                TechnologyEntity techEntity = new TechnologyEntity()
                {
                    UserId = technologyDto.UserId,
                    Name = technologyDto.Name,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                technologies.Add(techEntity);
            }
            return technologies;
        }

        /// <summary>
        /// Decide if project collaborator recommendations needs to be recomputed
        /// for certain projects if so queue message to pub jobs to recompute.
        /// </summary>
        /// <param name="userDto">User to be compared against stored user</param>
        /// <returns></returns>
        private async Task RecomputeProjectCollaboratorSuggestions(UserDto userDto)
        {
            UserEntity storedUser = await _userStorage.FindAsync(u => u.Id == userDto.Id);
            List<Guid?> projectIds;

            // Recompute if user not looking for project and previous state
            // is set to looking for project
            if (!userDto.LookingForProject && storedUser.LookingForProject)
            {
                projectIds = await _projectStorage.FindProjectsWithAnyTechnologies(storedUser.UserTechnologies.Select(t => t.Name).ToArray());
                await _messageQueue.SendMessagesAsync(await RetrieveProjects(projectIds), "compute_project_collaborator_suggestions", queueName: _pubJobsQueueName);
                return;
            }

            // if user is looking for project find technology diffs if any
            // and recompute suggestions.
            HashSet<string> technologiesDiff;
            technologiesDiff = UserTechnologiesDiff(userDto, storedUser);

            if (technologiesDiff.Count == 0)
            {
                return;
            }

            projectIds = await _projectStorage.FindProjectsWithAnyTechnologies(technologiesDiff.ToArray());
            await _messageQueue.SendMessagesAsync(await RetrieveProjects(projectIds), "compute_project_collaborator_suggestions", queueName: _pubJobsQueueName);

            return;
        }

        /// <summary>
        /// Indicate if there is a diff in technologies between userDto 
        /// and stored user. If so return the diff as hashset.
        /// </summary>
        /// <param name="userDto">User to be compared</param>
        /// <param name="user">User to be compared</param>
        /// <returns></returns>
        private HashSet<string> UserTechnologiesDiff(UserDto userDto, UserEntity user)
        {
            if (user == null)
            {
                return new HashSet<string>();
            }

            var storedTechnologies = user.UserTechnologies.Select(t => t.Name).ToHashSet();
            var dtoTechnologies = userDto.Technologies.Select(t => t.Name).ToHashSet();

            // take diff between both technology sets
            storedTechnologies.SymmetricExceptWith(dtoTechnologies);

            return storedTechnologies;
        }

        /// <summary>
        /// Query db for projects from list of project ids and 
        /// return projects as list of project dtos
        /// </summary>
        /// <param name="projectIds">List of projects id's to query</param>
        /// <returns></returns>
        private async Task<List<ProjectDto>> RetrieveProjects(List<Guid?> projectIds)
        {
            var projects = new List<ProjectDto>();

            foreach (var Id in projectIds)
            {
                var project = await _projectStorage.FindAsync(p => p.Id == Id);
                projects.Add(_mapper.Map<ProjectDto>(project));
            }

            return projects;
        }
    }
}
