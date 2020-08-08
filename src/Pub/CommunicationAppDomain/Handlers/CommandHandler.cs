using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.Contracts;
using Common.DTOs.SlackAppDTOs;
using CommunicationAppDomain.Services;
using CommunicationAppDomain.Utilities;
using Infrastructure.Persistence.Entities;
using Microsoft.Extensions.Configuration;

namespace CommunicationAppDomain.Handlers
{
    public class CommandHandler : IChatAppCommandHandler
    {
        private readonly string _githubOrganization;
        private readonly string _mainUrl;
        private readonly IStorage<ProjectEntity> _projectStorage;
        private readonly IStorage<UserEntity> _userStorage;
        private readonly IStorage<ChatAppUserEntity> _chatAppUserStorage;
        private readonly SlackService _slackService;

        public CommandHandler(IConfiguration configuraiion)
        {
            _githubOrganization = configuraiion["GitHubOrganization"];
            _mainUrl = configuraiion["MainUrl"];
            _projectStorage = new ProjectEntity();
            _userStorage = new UserEntity();
            _chatAppUserStorage = new ChatAppUserEntity();
            _slackService = new SlackService();
        }

        public async Task ProcessCommand(SlackCommandDto slackCommandDto)
        {
            SlackCommandResponseDto slackCommandResponse = new SlackCommandResponseDto();
            switch (slackCommandDto.command)
            {
                case "/projects":
                    await ProcessProjectsCommand(slackCommandDto);
                    break;
                case "/github-connect":
                    await ProcessGithubConnectCommand(slackCommandDto);
                    break;
                case "/magic-login-link":
                    await GenerateMagicLoginLink(slackCommandDto);
                    break;
            }

            return;
        }

        private async Task ProcessProjectsCommand(SlackCommandDto slackCommand)
        {
            var projects = (await _projectStorage.FindAsync()).FindAll(p => p.LookingForMembers && p.Searchable);
            var slackCommandResponse = BuildProjectsResponse(projects);
            await _slackService.RespondViaResponsUrl(slackCommand.response_url, slackCommandResponse);
            return;
        }

        private async Task ProcessGithubConnectCommand(SlackCommandDto slackCommand)
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
                await _slackService.RespondViaResponsUrl(slackCommand.response_url, slackCommandResponse);
                return;
            }

            slackCommandResponse.Text = $"Success! You should have gotten an email with an invite to the GitHub org. You can also visit https://github.com/{_githubOrganization} to accept the invite.";
            await _slackService.RespondViaResponsUrl(slackCommand.response_url, slackCommandResponse);
            return;
        }

        private async Task GenerateMagicLoginLink(SlackCommandDto slackCommand)
        {
            var linkExpirationInMinutes = 5;
            string token = TokenHelper.GenerateToken().Replace("/", "");
            string workspaceId = slackCommand.team_id;
            string workspaceMemberId = slackCommand.user_id;

            ChatAppUserEntity workspaceUser = await _chatAppUserStorage.FindAsync(u => u.WorkspaceId == workspaceId && u.WorkspaceMemberId == workspaceMemberId);

            var user = workspaceUser.User;
            user.MagicLoginToken = token;
            user.MagicLoginTokenExpiresAt = DateTimeOffset.Now.AddMinutes(linkExpirationInMinutes);
            await _userStorage.UpdateAsync(user);
            var slackCommandResponse = new SlackCommandResponseDto();

            slackCommandResponse.Text = $"Your magic login link expires in {linkExpirationInMinutes} minutes.\n\n {_mainUrl}/magic-login?token={Uri.EscapeDataString(token)}";
            await _slackService.RespondViaResponsUrl(slackCommand.response_url, slackCommandResponse);
            return;
        }

        private SlackCommandResponseDto BuildProjectsResponse(List<ProjectEntity> projects)
        {
            var slackCommandResponse = new SlackCommandResponseDto();
            if (projects.Count == 0)
            {
                slackCommandResponse.Text = $"It doesn't look like there are any projects looking for members right now. \n Start a new project on {_mainUrl}/projects.";
            }
            else
            {
                slackCommandResponse.Text = $"Here's a list of available projects you can join (visit the <{_mainUrl}/projects|project page> for more advanced filtering). \n";
            }

            foreach (var project in projects)
            {
                slackCommandResponse.Text += $"{project.Name}, <{_mainUrl}/projects/{project.Id}|project page>\n\n";
            }
            return slackCommandResponse;
        }
    }
}
