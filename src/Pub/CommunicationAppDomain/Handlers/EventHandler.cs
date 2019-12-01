using System;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.Contracts;
using Common.Models;
using Common.DTOs.SlackAppDTOs;
using Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text;
using CommunicationAppDomain.Services;
using CommunicationAppDomain.ChatMessages;
using AutoMapper;
using CommunicationAppDomain.MappingConfig;
using System.Linq;

namespace CommunicationAppDomain.Handlers
{
    public class EventHandler : IChatAppEventHandler
    {
        private readonly IMapper _mapper;
        private readonly string _githubOrganization;
        private readonly string _frontendUrl;
        private readonly UserEntity _userStorage;
        private readonly IStorage<ChatAppUserEntity> _chatAppUserStorage;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly SlackService _slackService;

        public EventHandler()
        {
            _githubOrganization = AppSettings.GitHubOrganization;
            _frontendUrl = AppSettings.JwtAudience;
            _userStorage = new UserEntity();
            _chatAppUserStorage = new ChatAppUserEntity();
            _slackService = new SlackService();
            _passwordHasher = new PasswordHasher<User>();
            _mapper = new InitializeMapper().GetMapper;
        }

        public UrlVerificationResponseDto UrlVerification(SlackEventDto slackEventDto)
        {
            var urlVerificationResponseDto = new UrlVerificationResponseDto { challenge = slackEventDto.Challenge };
            return urlVerificationResponseDto;
        }

        public async Task ProcessEvent(SlackEventDto slackEventDto)
        {
            if (slackEventDto.Type == "event_callback")
            {
                switch (slackEventDto.Event.Type)
                {
                    case "team_join":
                        await ProcessTeamJoinEvent(slackEventDto);
                        break;
                    case "user_change":
                        await ProcessUserChangeEvent(slackEventDto);
                        break;
                    default:
                        break;
                }
            }
            return;
        }

        private async Task ProcessTeamJoinEvent(SlackEventDto slackEventDto)
        {
            if (slackEventDto.Event.User.IsBot)
            {
                return;
            }
            
            string workspaceId = slackEventDto.Event.User.SlackTeamId;
            string workspaceMemberId = slackEventDto.Event.User.SlackId;

            SlackUserInfoDto slackUserInfoDto = await _slackService.GetSlackUserInfo(workspaceMemberId);
            string chatAppMemberEmail = slackUserInfoDto.User.Profile.Email;

            UserEntity existingUser = await _userStorage.FindAsync(u => u.Email == chatAppMemberEmail);

            if (existingUser == null)
            {
                // User email is not registered to frontend so
                // register user and also associate new chat app 
                // user to new user entity
                string username = await GenerateUsername();
                string password = GenerateTemporaryPassword();
                User user = new User(username, slackUserInfoDto.User.Profile.Email, slackUserInfoDto.User.Timezone, slackUserInfoDto.User.Locale, true, slackEventDto.Event.User.Profile.Image192);
                UserEntity userEntity = _mapper.Map<UserEntity>(user);
                userEntity.HashedPassword = HashPassword(user, password);


                UserEntity newUser = await _userStorage.CreateAsync(userEntity);
                ChatAppUserEntity newChatAppUser = new ChatAppUserEntity()
                {
                    WorkspaceId = workspaceId,
                    WorkspaceMemberId = workspaceMemberId,
                    UserId = newUser.Id,
                };

                await _chatAppUserStorage.CreateAsync(newChatAppUser);
                await SendOnboardingSlackMessage(workspaceMemberId, user.Email, password);
            }
            else
            {
                // User email is already register to frontend
                // associate new chat user record with existing user
                ChatAppUserEntity newChatAppUser = new ChatAppUserEntity()
                {
                    WorkspaceId = workspaceId,
                    WorkspaceMemberId = workspaceMemberId,
                    UserId = existingUser.Id,
                };

                await _chatAppUserStorage.CreateAsync(newChatAppUser);
            }

            return;
        }

        private async Task ProcessUserChangeEvent(SlackEventDto slackEventDto)
        {
            SlackUserInfoDto slackUserInfoDto = await _slackService.GetSlackUserInfo(slackEventDto.Event.User.SlackId);

            string chatAppMemberEmail = slackUserInfoDto.User.Profile.Email;
            UserEntity existingUser = await _userStorage.FindAsync(u => u.Email == chatAppMemberEmail);
            existingUser.Email = slackUserInfoDto.User.Profile.Email;
            existingUser.Timezone = slackUserInfoDto.User.Timezone;
            existingUser.Locale = slackUserInfoDto.User.Locale;
            existingUser.ProfilePictureUrl = slackEventDto.Event.User.Profile.Image192;

            await _userStorage.UpdateAsync(existingUser);
            return;
        }

        private async Task<string> GenerateUsername()
        {
            var member = await _userStorage.FindLastUnicornRecord();
            if(member == null) {
                return $"unicorn1";
            }
            var usernameValue = member.Username.Substring(7);
            var usernameNumber = int.Parse(usernameValue);
            var newUsernameValue = usernameNumber + 1;
            return $"unicorn{newUsernameValue}";
        }

        private string GenerateTemporaryPassword()
        {
            const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            var length = 6;
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return $"unicorn{res.ToString()}";
        }

        private async Task SendOnboardingSlackMessage(string slackId, string signinId, string signinPassword)
        {
            string message = Messages.OnboardingMessage(slackId, signinId, signinPassword);
            await _slackService.ChatPostMessage(slackId, message);
        }

        private string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }
    }
}
