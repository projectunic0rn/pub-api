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
using Newtonsoft.Json;

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
        private readonly string _introductionChannelId;

        public EventHandler()
        {
            _githubOrganization = AppSettings.GitHubOrganization;
            _frontendUrl = AppSettings.JwtAudience;
            _introductionChannelId = AppSettings.IntroductionChannelId;
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
            if (slackEventDto.Type != "event_callback")
            {
                return;
            }

            string eventData = slackEventDto.EventRaw.Value.ToString();
            EventType eventType = ParseEventType(eventData);

            if (eventType.SubType == "channel_join")
            {
                return;
            }

            switch (eventType.Type)
            {
                // team_join and user_change use same event type, TeamJoinEventDto.
                case "team_join":
                    SlackEventFullDto<TeamJoinEventDto> teamJoinEvent = MapSlackEventObject<TeamJoinEventDto>(slackEventDto, eventData);
                    await ProcessTeamJoinEvent(teamJoinEvent);
                    break;
                case "user_change":
                    SlackEventFullDto<TeamJoinEventDto> userChangeEvent = MapSlackEventObject<TeamJoinEventDto>(slackEventDto, eventData);
                    await ProcessUserChangeEvent(userChangeEvent);
                    break;
                case "message":
                    SlackEventFullDto<MessageChannelsEventDto> messageEvent = MapSlackEventObject<MessageChannelsEventDto>(slackEventDto, eventData);
                    await ProcessMessageEvent(messageEvent);
                    break;
                default:
                    break;
            }
        }

        private async Task ProcessMessageEvent(SlackEventFullDto<MessageChannelsEventDto> slackEventDto)
        {

            // Validate the message was received posted on introduce yourself channel
            if (slackEventDto.Event.Channel != _introductionChannelId)
            {
                return;
            }

            string workspaceId = slackEventDto.TeamId;
            string workspaceMemberId = slackEventDto.Event.User;

            ChatAppUserEntity workspaceUser = await _chatAppUserStorage.FindAsync(u => u.WorkspaceId == workspaceId && u.WorkspaceMemberId == workspaceMemberId);
            UserEntity user = workspaceUser.User;

            if (String.IsNullOrWhiteSpace(user.Bio))
            {
                user.Bio = slackEventDto.Event.Text;
                await _userStorage.UpdateAsync(user);
            }

            return;
        }

        private async Task ProcessTeamJoinEvent(SlackEventFullDto<TeamJoinEventDto> slackEventDto)
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
                User user = new User(username, slackUserInfoDto.User.Profile.Email, slackUserInfoDto.User.Timezone, slackUserInfoDto.User.Locale, true, "", slackEventDto.Event.User.Profile.Image192);
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
                existingUser.ProfilePictureUrl = slackEventDto.Event.User.Profile.Image192;

                ChatAppUserEntity newChatAppUser = new ChatAppUserEntity()
                {
                    WorkspaceId = workspaceId,
                    WorkspaceMemberId = workspaceMemberId,
                    UserId = existingUser.Id,
                };

                await _userStorage.UpdateAsync(existingUser);
                await _chatAppUserStorage.CreateAsync(newChatAppUser);
            }

            return;
        }

        private async Task ProcessUserChangeEvent(SlackEventFullDto<TeamJoinEventDto> slackEventDto)
        {
            if (slackEventDto.Event.User.IsBot)
            {
                return;
            }
            
            string workspaceId = slackEventDto.Event.User.SlackTeamId;
            string workspaceMemberId = slackEventDto.Event.User.SlackId;

            ChatAppUserEntity workspaceUser = await _chatAppUserStorage.FindAsync(u => u.WorkspaceId == workspaceId && u.WorkspaceMemberId == workspaceMemberId);
            UserEntity existingUser = workspaceUser.User;
            existingUser.Email = slackEventDto.Event.User.Profile.Email;
            existingUser.Timezone = slackEventDto.Event.User.Timezone;
            existingUser.Locale = slackEventDto.Event.User.Locale;
            existingUser.ProfilePictureUrl = slackEventDto.Event.User.Profile.Image192;

            await _userStorage.UpdateAsync(existingUser);
            return;
        }

        private async Task<string> GenerateUsername()
        {
            var member = await _userStorage.FindLastUnicornRecord();
            if (member == null)
            {
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

        private SlackEventFullDto<T> MapSlackEventObject<T>(SlackEventDto slackEventDto, string innerEventData)
        {
            SlackEventFullDto<T> slackEventFullDto = new SlackEventFullDto<T>();
            slackEventFullDto.ApiAppId = slackEventDto.ApiAppId;
            slackEventFullDto.AuthedUsers = slackEventDto.AuthedUsers;
            slackEventFullDto.EventId = slackEventDto.EventId;
            slackEventFullDto.EventTime = slackEventDto.EventTime;
            slackEventFullDto.TeamId = slackEventDto.TeamId;
            slackEventFullDto.Token = slackEventDto.Token;
            slackEventFullDto.Type = slackEventFullDto.Type;

            slackEventFullDto.Event = JsonConvert.DeserializeObject<T>(innerEventData);

            return slackEventFullDto;
        }

        private EventType ParseEventType(string eventData)
        {
            EventType eventType = JsonConvert.DeserializeObject<EventType>(eventData);
            return eventType;
        }
    }
}
