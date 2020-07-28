using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Contracts;
using Common.DTOs;
using Domain.Exceptions;
using Domain.MappingConfig;
using Infrastructure.Persistence.Entities;
using Common.AppSettings;

namespace Domain.Models
{
    public class Project : IProject
    {
        private readonly IMapper _mapper;

        private readonly ProjectEntity _projectStorage;
        private readonly IStorage<ProjectTypeEntity> _projectTypeStorage;
        private readonly IStorage<CommunicationPlatformTypeEntity> _communicationPlatformTypeStorage;
        private readonly INotifier _notifier;
        private readonly IMessageQueue _messageQueue;
        private readonly string _pubSlackAppQueueName;

        public Project(INotifier notifier, IMessageQueue messageQueue)
        {
            _projectStorage = new ProjectEntity();
            _projectTypeStorage = new ProjectTypeEntity();
            _communicationPlatformTypeStorage = new CommunicationPlatformTypeEntity();
            _mapper = new InitializeMapper().GetMapper;
            _notifier = notifier;
            _messageQueue = messageQueue;
            _pubSlackAppQueueName = AppSettings.PubSlackAppQueueName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
        public int ProjectType { get; set; }
        public string RepositoryLink { get; set; }
        public string InvitationLink { get; set; }

        public async Task<List<ProjectDto>> GetProjectsAsync(bool searchableOnly)
        {
            if(searchableOnly) {
                List<ProjectEntity> projects = await _projectStorage.FindAsync();
                List<ProjectDto> projectDtos = _mapper.Map<List<ProjectDto>>(projects);
                return projectDtos;
            }
            else {
                List<ProjectEntity> projects = await _projectStorage.FindAllAsync();
                List<ProjectDto> projectDtos = _mapper.Map<List<ProjectDto>>(projects);
                return projectDtos;
            }
        }

        public async Task<ProjectDto> GetProjectAsync(Guid id)
        {
            ProjectEntity project = await _projectStorage.FindAsync(m => m.Id == id);
            ProjectDto projectDto = _mapper.Map<ProjectDto>(project);
            return projectDto;
        }

        public async Task<ProjectDto> CreateProjectAsync(ProjectDto project)
        {
            await ValidateProject(project);
            var mappedEntity = _mapper.Map<ProjectEntity>(project);
            ProjectEntity createdProject = await _projectStorage.CreateAsync(mappedEntity);

            // By default when project is created, there is only 1 ProjectUser
            // the user that created the project aka project owner.
            var projectOwner = project.ProjectUsers.First();
            var notificationDto = new NotificationDto(projectOwner.UserId)
            {
                NotificationObject = project
            };

            await _notifier.SendProjectPostedNotificationAsync(notificationDto);
            ProjectDto mappedProject = _mapper.Map<ProjectDto>(createdProject);
            await _messageQueue.SendMessageAsync(mappedProject, "projectpost", queueName: _pubSlackAppQueueName);
            return mappedProject;
        }

        public async Task<ProjectDto> UpdateProjectAsync(ProjectDto project)
        {
            await ValidateProject(project);
            var mappedEntity = _mapper.Map<ProjectEntity>(project);
            ProjectEntity updatedProject = await _projectStorage.UpdateAsync(mappedEntity);
            return _mapper.Map<ProjectDto>(updatedProject);
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            await _projectStorage.DeleteAsync(id);
        }
        
        private async Task ValidateProject(ProjectDto project)
        {
            await ValidateProjectType(project);
            await ValidateCommunicationPlatformType(project);
        }
        
        private async Task ValidateProjectType(ProjectDto project)
        {
            List<ProjectTypeEntity> projectTypes = await _projectTypeStorage.FindAsync();
            bool projectTypeValid = projectTypes.Exists(pt => pt.Type == project.ProjectType);
            if (!projectTypeValid) 
            { 
                throw new ProjectException(ExceptionMessage.InvalidProjectType); 
            }
        }

        private async Task ValidateCommunicationPlatformType(ProjectDto project)
        {
            List<CommunicationPlatformTypeEntity> communicationPlatformTypes = await _communicationPlatformTypeStorage.FindAsync();
            bool communicationPlatformTypeValid = communicationPlatformTypes.Exists(cp => cp.Name == project.CommunicationPlatform);
            var message = ExceptionMessage.InvalidCommunicationPlatform;
            if (!communicationPlatformTypeValid)
            {
                foreach(CommunicationPlatformTypeEntity communicationPlatform in communicationPlatformTypes)
                {
                    message += communicationPlatform.Name + " ";
                }
                
                throw new ProjectException(message);
            }
        }
    }
}