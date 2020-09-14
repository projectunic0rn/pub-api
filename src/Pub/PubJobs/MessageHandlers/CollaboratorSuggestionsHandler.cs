using System;
using System.Threading.Tasks;
using Common.Contracts;
using Common.DTOs;
using Infrastructure.Persistence.Entities;
using System.Linq;
using System.Collections.Generic;

namespace PubJobs.MessageHandlers
{
    public class CollaboratorSuggestionsHandler
    {
        private readonly TechnologyEntity _technologyStorage;
        private readonly IStorage<ProjectCollaboratorSuggestionEntity> _projectCollaboratorSuggestionsStorage;

        public CollaboratorSuggestionsHandler()
        {
            _technologyStorage = new TechnologyEntity();
            _projectCollaboratorSuggestionsStorage = new ProjectCollaboratorSuggestionEntity();
        }

        public async Task ComputeProjectCollaboratorSuggestions(ProjectDto project)
        {
            await _projectCollaboratorSuggestionsStorage.DeleteAllAsync(pcs => pcs.ProjectId == project.Id);
            IEnumerable<Guid> currentProjectUsers = project.ProjectUsers.Select(u => u.UserId);

            IEnumerable<string> tech = project.ProjectTechnologies.Select(t => t.Name);
            List<DeveloperTechnologies> developers = await _technologyStorage.GetDeveloperTechnologiesAsync(tech.ToArray());
            List<Guid> collaboratorSuggestions = new HashSet<Guid>(developers.Select(d => d.UserId)).ToList();

            // Remove current project team members from suggestions
            foreach (Guid Id in currentProjectUsers)
            {
                collaboratorSuggestions.Remove(Id);
            }

            foreach (Guid Id in collaboratorSuggestions)
            {
                await _projectCollaboratorSuggestionsStorage.CreateAsync(new ProjectCollaboratorSuggestionEntity() { ProjectId = project.Id, UserId = Id });
            }
            
        }

        public Task ComputeDeveloperCollaboratorSuggestions(Guid developerId)
        {
            throw new NotImplementedException();
        }
    }
}
