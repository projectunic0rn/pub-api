using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.Contracts;
using Common.DTOs.SlackAppDTOs;
using CommunicationAppDomain.Services;
using CommunicationAppDomain.Utilities;
using Infrastructure.Persistence.Entities;

namespace CommunicationAppDomain.Handlers
{
    public class CommandHandler : IChatAppCommandHandler
    {
        private readonly string _githubOrganization;
        private readonly string _appUrl;
        private readonly string _mainUrl;
        private readonly IStorage<ProjectEntity> _projectStorage;
        private readonly IStorage<UserEntity> _userStorage;
        private readonly IStorage<ChatAppUserEntity> _chatAppUserStorage;

        public CommandHandler()
        {
            _githubOrganization = AppSettings.GitHubOrganization;
            _appUrl = AppSettings.AppUrl;
            _mainUrl = AppSettings.MainUrl;
            _projectStorage = new ProjectEntity();
            _userStorage = new UserEntity();
            _chatAppUserStorage = new ChatAppUserEntity();
        }

        public async Task<SlackCommandResponseDto> ProcessCommand(SlackCommandDto slackCommandDto)
        {
            SlackCommandResponseDto slackCommandResponse = new SlackCommandResponseDto();
            switch (slackCommandDto.command)
            {
                case "/projects":
                    slackCommandResponse = await ProcessProjectsCommand(slackCommandDto);
                    break;
                case "/github-connect":
                    slackCommandResponse = await ProcessGithubConnectCommand(slackCommandDto);
                    break;
                case "/magic-login-link":
                    slackCommandResponse = await GenerateMagicLoginLink(slackCommandDto);
                    break;
            }

            return slackCommandResponse;
        }

        private async Task<SlackCommandResponseDto> ProcessProjectsCommand(SlackCommandDto slackCommand)
        {
            var projects = (await _projectStorage.FindAsync()).FindAll(p => p.LookingForMembers == true);
            var slackCommandResponse = BuildProjectsResponse(projects);
            return slackCommandResponse;
        }

        private async Task<SlackCommandResponseDto> ProcessGithubConnectCommand(SlackCommandDto slackCommand)
        {
            string workspaceId = slackCommand.team_id;
            string workspaceMemberId = slackCommand.user_id;

            ChatAppUserEntity workspaceUser = await _chatAppUserStorage.FindAsync(u => u.WorkspaceId == workspaceId && u.WorkspaceMemberId == workspaceMemberId);

            var githubService = new GitHubService();
            var slackCommandResponse = new SlackCommandResponseDto();
            var user = workspaceUser.User;
            try
            {
                var organizationMembership = await githubService.InviteToGithubOrg(slackCommand.text);
                user.GitHubUsername = slackCommand.text;
                await _userStorage.UpdateAsync(user);
            }
            catch
            {
                slackCommandResponse.Text = "Sorry, something happened with our GitHub api call. :(\n Please try once more. If that doesn't work, reach out to <@UBW8QQG86> to be added manually.";
                return slackCommandResponse;
            }

            slackCommandResponse.Text = $"Success! You should have gotten an email with an invite to the GitHub org. You can also visit https://github.com/{_githubOrganization} to accept the invite.";
            return slackCommandResponse;
        }

        private async Task<SlackCommandResponseDto> GenerateMagicLoginLink(SlackCommandDto slackCommand)
        {
            var linkExpirationInMinutes = 5;
            var token = TokenHelper.GenerateToken();
            token = token.Replace("/", "");
            string workspaceId = slackCommand.team_id;
            string workspaceMemberId = slackCommand.user_id;

            ChatAppUserEntity workspaceUser = await _chatAppUserStorage.FindAsync(u => u.WorkspaceId == workspaceId && u.WorkspaceMemberId == workspaceMemberId);

            var user = workspaceUser.User;
            user.MagicLoginToken = token;
            user.MagicLoginTokenExpiresAt = DateTimeOffset.Now.AddMinutes(linkExpirationInMinutes);
            await _userStorage.UpdateAsync(user);
            var slackCommandResponse = new SlackCommandResponseDto();

            slackCommandResponse.Text = $"Your magic login link expires in {linkExpirationInMinutes} minutes.\n\n {_mainUrl}/magic-login?token={token}";
            return slackCommandResponse;
        }

        private SlackCommandResponseDto BuildProjectsResponse(List<ProjectEntity> projects)
        {
            var slackCommandResponse = new SlackCommandResponseDto();
            if (projects.Count == 0)
            {
                slackCommandResponse.Text = $"It doesn't look like there are any projects looking for members right now. \n Start a new project on {_appUrl}/projects.";
            }
            else
            {
                slackCommandResponse.Text = $"Here's a list of available projects you can join (visit the <{_appUrl}/projects|project page> for more advanced filtering). \n";
            }

            foreach (var project in projects)
            {
                slackCommandResponse.Text += $"{project.Name}, <{_appUrl}/projects/{project.Id}|project page>\n\n";
            }
            return slackCommandResponse;
        }
    }
}
