using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.Contracts;
using Infrastructure.Persistence.Entities;
using MailEngine.DTOs;
using Mailer.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using MailEngine.Utility;
using MailEngine.Config;
using Common.DTOs.MailDTOs;

namespace MailEngine.Mails.ScheduledMails
{
    // Summary: ProjectRecommendations is a background service that 
    // sends project recommendations to members
    public class ProjectRecommendations : BackgroundService
    {
        private readonly SendGridService _sendGridService;
        private readonly ILogger _logger;
        private readonly IStorage<UserEntity> _userStorage;
        private readonly IStorage<ProjectEntity> _projectStorage;
        private readonly int _numberOfProjectRecommendations = 3;
        private readonly int _maxVisibleMembers = 3;
        private readonly int _maxVisibleTechnologies = 3;
        private EmailAddress _fromAddress;
        private string _slackLogoUrl = "https://sharedstorage2.blob.core.windows.net/pub/slack-logo.svg";
        private string _discordLogoUrl = "https://sharedstorage2.blob.core.windows.net/pub/discord-logo.svg";
        private Dictionary<string, string> _communicationLogos;
        private readonly IMessageQueue _messageQueue;
        private MailConfig _mailConfig;
        private MailConfigDto _mailConfigDto;
        private readonly string _mailName = "ProjectRecommendations";
        private readonly string _testEmailIndicator;
        public ProjectRecommendations(ILogger<ProjectRecommendations> logger, IMessageQueue messageQueue, IMailConfigStorage mailConfigStorage)
        {
            _logger = logger;
            _sendGridService = new SendGridService();
            _userStorage = new UserEntity();
            _projectStorage = new ProjectEntity();
            _fromAddress = new EmailAddress("Team from Project Unicorn", "admin@projectunicorn.dev");
            // TODO: Read communication platform from database
            _communicationLogos = new Dictionary<string, string>() {
                {"discord", _discordLogoUrl},
                {"slack", _slackLogoUrl}
            };
            _messageQueue = messageQueue;
            _testEmailIndicator = AppSettings.Env == "Staging" || AppSettings.Env == "Development" ? "[TEST EMAIL] " : "";
            _mailConfig = new MailConfig(mailConfigStorage);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _mailConfigDto = await _mailConfig.GetConfig(_mailName);
            _logger.LogDebug($"Starting {_mailConfigDto.Name} mail process...");
            cancellationToken.Register(() => _logger.LogDebug($"{_mailConfigDto.Name} mail background service is stopping."));

            while (!cancellationToken.IsCancellationRequested)
            {
                if (BackgroundTask.ShouldStart(_mailConfigDto.NextSend))
                {
                    _mailConfigDto = await _mailConfig.GetConfig(_mailName);
                    _logger.LogInformation($"Preparing {_mailConfigDto.Name} mail.");
                    List<EmailMessage> emailMessages = await PrepareMail();
                    await _messageQueue.SendMessagesAsync<EmailMessage>(emailMessages);
                    await _mailConfig.UpdateConfigNextSend(_mailName);
                }

                await Task.Delay(1000, cancellationToken);
            }

            _logger.LogDebug($"{_mailConfigDto.Name} mail background service is stopping.");
        }

        private async Task<List<EmailMessage>> PrepareMail()
        {
            List<EmailMessage> emailMessages = new List<EmailMessage>();
            // Get template content from SendGrid
            SendGridTemplateDto template = await _sendGridService.GetMailTemplate(_mailConfigDto.TemplateId);
            // Get recepients and projects
            List<ProjectEntity> projects = await _projectStorage.FindAsync();
            List<UserEntity> users = await _userStorage.FindAsync();

            if (projects.Count() == 0 || users.Count() == 0)
            {
                return emailMessages;
            }

            foreach (UserEntity user in users)
            {
                // Skip if user has no technologies listed
                if (user.UserTechnologies.Count == 0)
                {
                    continue;
                }

                List<ProjectEntity> matchingProjects = new List<ProjectEntity>();

                foreach (ProjectEntity project in projects)
                {
                    // Skip if project has no technologies listed
                    if (project.ProjectTechnologies.Count == 0)
                    {
                        continue;
                    }

                    IEnumerable<string> userTechnologies = user.UserTechnologies.Select(userTech => userTech.Name);
                    IEnumerable<string> projectTechnologies = project.ProjectTechnologies.Select(projectTech => projectTech.Name);
                    // TODO: Debug, intersection yields no results
                    var intersection = userTechnologies.Intersect(projectTechnologies);
                    if (intersection.Count() > 0)
                    {
                        matchingProjects.Add(project);
                    }
                }

                List<ProjectEntity> projectRecommendations = SelectNRandomProjects(matchingProjects, _numberOfProjectRecommendations);
                EmailMessage message = BuildProjectRecommendationsMessage(user, projectRecommendations, template);
                emailMessages.Add(message);
            }

            return emailMessages;
        }

        private List<ProjectEntity> SelectNRandomProjects(List<ProjectEntity> matchingProjects, int n)
        {
            List<ProjectEntity> projectEntities = new List<ProjectEntity>();
            int matchingProjectsCount = matchingProjects.Count();

            if (matchingProjectsCount == 0)
            {
                return projectEntities;
            }

            if (matchingProjectsCount < n)
            {
                return matchingProjects;
            }
            matchingProjects.Shuffle();
            projectEntities = matchingProjects.Take(_numberOfProjectRecommendations).ToList();
            return projectEntities;
        }

        private EmailMessage BuildProjectRecommendationsMessage(UserEntity user, List<ProjectEntity> projects, SendGridTemplateDto template)
        {
            EmailMessage message = new EmailMessage();
            EmailAddress toAddress = new EmailAddress("", user.Email);
            EmailAddress fromAddress = _fromAddress;
            MailEngine.DTOs.Version templateV1 = template.Versions.First();
            MailContent htmlContent = new MailContent("text/html");
            MailContent plainTextContent = new MailContent("text/plain");
            message.ToAddresses.Add(toAddress);
            message.FromAddresses.Add(fromAddress);
            message.Subject = $"{templateV1.Subject} {_testEmailIndicator}";
            htmlContent.Value = ReplaceMessageVariables(templateV1.HtmlContent, user, projects);
            plainTextContent.Value = ReplaceMessageVariables(templateV1.PlainContent, user, projects);
            message.Content.Add(htmlContent);
            message.Content.Add(plainTextContent);
            return message;
        }

        private string ReplaceMessageVariables(string message, UserEntity user, List<ProjectEntity> projects)
        {
            IEnumerable<string> userTechnologies = user.UserTechnologies.Select(userTech => userTech.Name);
            Dictionary<string, string> _messageVariablesKeyValues = new Dictionary<string, string>() {
                { "{{skills}}", string.Join(",", userTechnologies.ToArray()) },
                { "{{currentYear}}", DateTime.Now.Year.ToString()},
                {"{{footerEmail}}", _fromAddress.Address},
            };

            int projectContentStart = message.IndexOf("{{startproject}}");
            int projectContentEnd = message.IndexOf("{{endproject}}");
            string projectContent = message.Substring(projectContentStart, (projectContentEnd - projectContentStart) + 14);
            string newMailContent = message.Replace(projectContent, "{{insertProject}} ".Multiply(projects.Count));

            foreach (KeyValuePair<string, string> kvp in _messageVariablesKeyValues)
            {
                newMailContent = newMailContent.Replace(kvp.Key, kvp.Value);
            }

            foreach (ProjectEntity project in projects)
            {
                int maxVisibleMembers = _maxVisibleMembers;
                int maxVisibleTechnologies = _maxVisibleTechnologies;

                string content = new string(projectContent);
                int technologyContentStart = content.IndexOf("{{starttechnologies}}");
                int technologyContentEnd = content.IndexOf("{{endtechnologies}}");
                int extraTechnologyContentStart = content.IndexOf("{{startextratechnologies}}");
                int extraTechnologyContentEnd = content.IndexOf("{{endextratechnologies}}");
                string technologyContent = content.Substring(technologyContentStart, (technologyContentEnd - technologyContentStart) + 19);
                string extraTechnologiesContent = content.Substring(extraTechnologyContentStart, (extraTechnologyContentEnd - extraTechnologyContentStart) + 24);
                int projectTechnologiesCount = project.ProjectTechnologies.Count;
                int visibleTechnologiesCount = projectTechnologiesCount > maxVisibleTechnologies ? maxVisibleTechnologies : projectTechnologiesCount;
                int extraTechnologiesCount = projectTechnologiesCount > maxVisibleTechnologies ? (projectTechnologiesCount - maxVisibleTechnologies) : 0;
                content = content.Replace(technologyContent, "{{insertTechnology}} ".Multiply(visibleTechnologiesCount));
                content = content.Replace(extraTechnologiesContent, "{{insertExtraTechnology}} ".Multiply(extraTechnologiesCount != 0 ? 1 : 0));

                int memberContentStart = content.IndexOf("{{startmembers}}");
                int memberContentEnd = content.IndexOf("{{endmembers}}");
                int extraMembersContentStart = content.IndexOf("{{startextramembers}}");
                int extraMembersContentEnd = content.IndexOf("{{endextramembers}}");
                string memberContent = content.Substring(memberContentStart, (memberContentEnd - memberContentStart) + 14);
                string extraMembersContent = content.Substring(extraMembersContentStart, (extraMembersContentEnd - extraMembersContentStart) + 19);
                int projectMembersCount = project.ProjectUsers.Count;
                int visibleMembersCount = projectMembersCount > maxVisibleMembers ? maxVisibleMembers : projectMembersCount;
                int extraMembersCount = projectMembersCount > maxVisibleMembers ? (projectMembersCount - maxVisibleMembers) : 0;
                content = content.Replace(memberContent, "{{insertMember}} ".Multiply(visibleMembersCount));
                content = content.Replace(extraMembersContent, "{{insertExtraMember}} ".Multiply(extraMembersCount != 0 ? 1 : 0));

                int technologyCount = 0;
                foreach (TechnologyEntity technology in project.ProjectTechnologies)
                {
                    technologyCount++;
                    if (technologyCount <= maxVisibleTechnologies)
                    {
                        string technologySection = new string(technologyContent);
                        technologySection = technologySection.Replace("{{this}}", technology.Name);
                        technologySection = technologySection
                        .Replace("{{starttechnologies}}", string.Empty)
                        .Replace("{{endtechnologies}}", string.Empty)
                        .Replace("{{#each this.technologies}}", string.Empty)
                        .Replace("{{/each}}", string.Empty);
                        content = content.ReplaceFirst("{{insertTechnology}}", technologySection);
                    }
                }

                if (extraTechnologiesCount > 0)
                {
                    IEnumerable<TechnologyEntity> extraTechnologies = project.ProjectTechnologies.TakeLast((extraTechnologiesCount));
                    List<string> extraTechName = new List<string>();

                    foreach (TechnologyEntity tech in extraTechnologies)
                    {
                        extraTechName.Add(tech.Name);
                    }

                    string extraTechnologySection = new string(extraTechnologiesContent);
                    extraTechnologySection = extraTechnologySection.Replace("{{this.extraTechnologiesCount}}", extraTechnologiesCount.ToString());
                    extraTechnologySection = extraTechnologySection.Replace("{{this.extraTechnologies}}", string.Join(",", extraTechName.ToArray()));
                    extraTechnologySection = extraTechnologySection
                    .Replace("{{startextratechnologies}}", string.Empty)
                    .Replace("{{endextratechnologies}}", string.Empty)
                    .Replace("{{#if this.extraTechnologiesCount}}", string.Empty)
                    .Replace("{{/if}}", string.Empty);
                    content = content.ReplaceFirst("{{insertExtraTechnology}}", extraTechnologySection);
                }

                int memberCount = 0;
                foreach (ProjectUserEntity projectMember in project.ProjectUsers)
                {
                    memberCount++;
                    if (memberCount <= maxVisibleMembers)
                    {
                        string memberSection = new string(memberContent);
                        memberSection = memberSection.Replace("{{this}}", projectMember.User.Username);
                        memberSection = memberSection
                        .Replace("{{startmembers}}", string.Empty)
                        .Replace("{{endmembers}}", string.Empty)
                        .Replace("{{#each this.members}}", string.Empty)
                        .Replace("{{/each}}", string.Empty);
                        content = content.ReplaceFirst("{{insertMember}}", memberSection);
                    }
                }

                if (extraMembersCount > 0)
                {
                    IEnumerable<ProjectUserEntity> extraMembers = project.ProjectUsers.TakeLast((extraMembersCount));
                    List<string> extraMemberName = new List<string>();
                    foreach (ProjectUserEntity member in extraMembers)
                    {
                        extraMemberName.Add(member.User.Username);
                    }

                    string extraMembersSection = new string(extraMembersContent);
                    extraMembersSection = extraMembersSection.Replace("{{this.extraMembersCount}}", extraMembersCount.ToString());
                    extraMembersSection = extraMembersSection.Replace("{{this.extraMembers}}", string.Join(",", extraMemberName.ToArray()));
                    extraMembersSection = extraMembersSection
                    .Replace("{{startextramembers}}", string.Empty)
                    .Replace("{{endextramembers}}", string.Empty)
                    .Replace("{{#if this.extraMembersCount}}", string.Empty)
                    .Replace("{{/if}}", string.Empty);
                    content = content.ReplaceFirst("{{insertExtraMember}}", extraMembersSection);
                }

                content = content
                .Replace("{{this.title}}", project.Name)
                .Replace("{{this.description}}", project.Description)
                .Replace("{{this.projectUrl}}", $"{AppSettings.AppUrl}/projects/{project.Id.ToString()}")
                .Replace("{{this.communicationPlatformIcon}}", _communicationLogos[project.CommunicationPlatform])
                .Replace("{{startproject}}", string.Empty)
                .Replace("{{endproject}}", string.Empty)
                .Replace("{{#each projects}}", string.Empty)
                .Replace("{{/each}}", string.Empty);

                newMailContent = newMailContent.ReplaceFirst("{{insertProject}}", content);
            }

            return newMailContent;
        }
    }
}