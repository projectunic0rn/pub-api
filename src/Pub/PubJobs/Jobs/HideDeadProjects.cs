using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Common.Services;
using Common.DTOs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PubJobs.Jobs
{
    /// <summary>
    /// Flags projects with expired workspace invite link. If invalid, project
    /// searchable property is set to false and project owner is notified (if
    /// project owner exists).
    /// </summary>
    public class HideDeadProjects : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly Dictionary<string, IWorkspaceService> _workspaceServices;
        private readonly PubService _pubService;
        private readonly INotifier _notifier;

        public HideDeadProjects(ILogger<HideDeadProjects> logger, PubService pubService, INotifier notifier)
        {
            _logger = logger;
            _pubService = pubService;
            _workspaceServices = new Dictionary<string, IWorkspaceService>();
            _workspaceServices.Add("slack", new SlackService());
            _workspaceServices.Add("discord", new DiscordService());
            _notifier = notifier;
            _logger.LogInformation($"Initialized {GetType().Name}");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Executing {GetType().Name}");
                var projects = await _pubService.GetProjects();

                foreach (var project in projects.Data)
                {
                    _workspaceServices.TryGetValue(project.CommunicationPlatform, out IWorkspaceService service);
                    var invite = await service.GetInviteStatus(project.CommunicationPlatformUrl);
                    if (!invite.Valid)
                    {
                        project.Searchable = false;
                        await _pubService.UpdateProject(project);
                        var projectOwner = GetProjectOwner(project);
                        if(projectOwner == default(ProjectUserDto))
                        {
                            // no owner found for project
                            continue;
                        }

                        var notificationDto = new NotificationDto(projectOwner.UserId)
                        {
                            NotificationObject = project
                        };
                        await _notifier.SendInvalidWorkspaceInviteNotificationAsync(notificationDto);
                    }

                    if (invite.Valid)
                    {
                        if(!project.Searchable)
                        {
                            project.Searchable = true;
                            await _pubService.UpdateProject(project);
                        }
                    }

                }

                _logger.LogDebug($"Found {projects.Data.Count} projects.");
                await Task.Delay(1800000, stoppingToken);
            }
        }

        private ProjectUserDto GetProjectOwner(ProjectDto projects)
        {
            List<ProjectUserDto> projectUsers = projects.ProjectUsers;
            ProjectUserDto projectUser = projectUsers.Find(p => p.IsOwner);
            return projectUser;
        }
    }
}