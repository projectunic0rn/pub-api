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
using Microsoft.AspNetCore.JsonPatch;

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
        private readonly string _pubJobsQueueName;

        public Project(INotifier notifier, IMessageQueue messageQueue)
        {
            _projectStorage = new ProjectEntity();
            _projectTypeStorage = new ProjectTypeEntity();
            _communicationPlatformTypeStorage = new CommunicationPlatformTypeEntity();
            _mapper = new InitializeMapper().GetMapper;
            _notifier = notifier;
            _messageQueue = messageQueue;
            _pubSlackAppQueueName = AppSettings.PubSlackAppQueueName;
            _pubJobsQueueName = AppSettings.PubJobsQueueName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectType { get; set; }
        public string RepositoryLink { get; set; }
        public string InvitationLink { get; set; }

        public async Task<List<ProjectDto>> GetProjectsAsync(bool searchableOnly)
        {
            if (searchableOnly)
            {
                List<ProjectEntity> projects = await _projectStorage.FindAsync();
                List<ProjectDto> projectDtos = _mapper.Map<List<ProjectDto>>(projects);
                return projectDtos;
            }
            else
            {
                List<ProjectEntity> projects = await _projectStorage.FindAllAsync();
                List<ProjectDto> projectDtos = _mapper.Map<List<ProjectDto>>(projects);
                return projectDtos;
            }
        }

        public async Task<DetailedProjectDto> GetProjectAsync(Guid id)
        {
            ProjectEntity project = await _projectStorage.FindAsync(m => m.Id == id);
            DetailedProjectDto detailedProjectDto = _mapper.Map<DetailedProjectDto>(project);
            return detailedProjectDto;
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

            if (project.CommunicationPlatform != "other")
            {
                // send workspace app download link if CommunicationPlatform not
                // set to other
                await _notifier.SendProjectPostedNotificationAsync(notificationDto);
            }

            ProjectDto mappedProject = _mapper.Map<ProjectDto>(createdProject);
            await _messageQueue.SendMessageAsync(mappedProject, "projectpost", queueName: _pubSlackAppQueueName);
            await RecomputeProjectCollaboratorSuggestions(mappedProject, true);
            return mappedProject;
        }

        public async Task<DetailedProjectDto> UpdateProjectAsync(DetailedProjectDto project)
        {
            await ValidateProject(new ProjectDto() { CommunicationPlatform = project.CommunicationPlatform });
            var mappedEntity = _mapper.Map<ProjectEntity>(project);
            await RecomputeProjectCollaboratorSuggestions(_mapper.Map<ProjectDto>(project));
            ProjectEntity updatedProject = await _projectStorage.UpdateAsync(mappedEntity);
            DetailedProjectDto detailedProjectDto = _mapper.Map<DetailedProjectDto>(updatedProject);
            return detailedProjectDto;
        }

        public async Task<DetailedProjectDto> PatchProjectAsync(Guid Id, JsonPatchDocument projectPatch)
        {
            ProjectEntity patchedProject = await _projectStorage.FindAsync(m => m.Id == Id);
            projectPatch.ApplyTo(patchedProject);
            await RecomputeProjectCollaboratorSuggestions(_mapper.Map<ProjectDto>(patchedProject));
            ProjectEntity updatedProject = await _projectStorage.UpdateAsync(patchedProject);
            DetailedProjectDto detailedProjectDto = _mapper.Map<DetailedProjectDto>(updatedProject);
            return detailedProjectDto;
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            await _projectStorage.DeleteAsync(id);
        }

        private async Task ValidateProject(ProjectDto project)
        {
            await ValidateCommunicationPlatformType(project);
        }

        private async Task ValidateCommunicationPlatformType(ProjectDto project)
        {
            List<CommunicationPlatformTypeEntity> communicationPlatformTypes = await _communicationPlatformTypeStorage.FindAsync();
            bool communicationPlatformTypeValid = communicationPlatformTypes.Exists(cp => cp.Name == project.CommunicationPlatform);
            var message = ExceptionMessage.InvalidCommunicationPlatform;
            if (!communicationPlatformTypeValid)
            {
                foreach (CommunicationPlatformTypeEntity communicationPlatform in communicationPlatformTypes)
                {
                    message += communicationPlatform.Name + " ";
                }

                throw new ProjectException(message);
            }
        }

        /// <summary>
        /// Decide if project collaborator recommendations needs to be recomputed
        /// if so queue message to pub jobs to recompute.
        /// </summary>
        /// <param name="project">Project to be compared against stored project</param>
        /// <returns></returns>
        private async Task RecomputeProjectCollaboratorSuggestions(ProjectDto projectDto, bool projectCreateOverride = false)
        {
            if (projectCreateOverride)
            {
                await _messageQueue.SendMessageAsync(projectDto, "compute_project_collaborator_suggestions", queueName: _pubJobsQueueName);
                return;
            }

            bool recompute;
            ProjectEntity storedProject = await _projectStorage.FindAsync(p => p.Id == projectDto.Id);
            recompute = ProjectTechnologiesDiff(projectDto, storedProject);

            if (recompute)
            {
                await _messageQueue.SendMessageAsync(projectDto, "compute_project_collaborator_suggestions", queueName: _pubJobsQueueName);
            }

            return;
        }

        /// <summary>
        /// Indicate if there is a diff in technologies between projectDto 
        /// and stored project
        /// </summary>
        /// <param name="projectDto">Project to be compared</param>
        /// <param name="project">Project to be compared</param>
        /// <returns></returns>
        private bool ProjectTechnologiesDiff(ProjectDto projectDto, ProjectEntity project)
        {
            bool result = false;

            if (project == null)
            {
                return result;
            }

            var storedTechnologies = project.ProjectTechnologies.Select(p => p.Name);
            var dtoTechnologies = projectDto.ProjectTechnologies.Select(p => p.Name);

            // 2 conditions, 
            // if stored technologies length does not match dto length they represent different 
            // technologies so return true to recompute, otherwise if both sets are same length check intersection 
            // if intersection count is less then either set then return true. 
            result = storedTechnologies.Count() != dtoTechnologies.Count() || storedTechnologies.Intersect(dtoTechnologies).Count() < storedTechnologies.Count();
            return result;
        }
    }
}