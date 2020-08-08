using System;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.Contracts;
using Common.Models;
using Common.DTOs.SlackAppDTOs;
using Common.DTOs;
using Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text;
using CommunicationAppDomain.Services;
using CommunicationAppDomain.ChatMessages;
using AutoMapper;
using CommunicationAppDomain.MappingConfig;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CommunicationAppDomain.Handlers
{
    public class EventHandler : IChatAppEventHandler
    {
        private readonly IMapper _mapper;
        private readonly UserEntity _userStorage;
        private readonly ChatAppUserEntity _chatAppUserStorage;
        private readonly TechnologyEntity _technologiesStorage;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly SlackService _slackService;
        private readonly string _introductionChannelId;
        private readonly string _privateIntroChannelId;
        private readonly string _privateRegistrationChannelId;
        private readonly string _privateProjectsChannelId;
        private readonly string _projectIdeasChannel;
        private readonly string _mainUrl;
        private readonly PrivilegedMembersDto _privilegedMembers;

        public EventHandler(IConfiguration configuration)
        {
            _introductionChannelId = configuration["IntroductionChannelId"];
            _privateIntroChannelId = configuration["PrivateIntroChannelId"];
            _privateRegistrationChannelId = configuration["PrivateRegistrationChannelId"];
            _privateProjectsChannelId = configuration["PrivateProjectsChannelId"];
            _projectIdeasChannel = configuration["ProjectIdeasChannelId"];
            _userStorage = new UserEntity();
            _chatAppUserStorage = new ChatAppUserEntity();
            _technologiesStorage = new TechnologyEntity();
            _slackService = new SlackService();
            _passwordHasher = new PasswordHasher<User>();
            _mapper = new InitializeMapper().GetMapper;
            _privilegedMembers = JsonConvert.DeserializeObject<PrivilegedMembersDto>(configuration["PrivilegedMembers"]);
            _mainUrl = configuration["MainUrl"];
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
                // manage user technologie through reaction events
                case "reaction_added":
                    SlackEventFullDto<ReactionEventDto> reactionAddedEvent = MapSlackEventObject<ReactionEventDto>(slackEventDto, eventData);
                    await ProcessReactionAddedEvent(reactionAddedEvent);
                    break;
                case "reaction_removed":
                    SlackEventFullDto<ReactionEventDto> reactionRemovedEvent = MapSlackEventObject<ReactionEventDto>(slackEventDto, eventData);
                    await ProcessReactionRemovedEvent(reactionRemovedEvent);
                    break;
                default:
                    break;
            }
        }

        private async Task ProcessReactionAddedEvent(SlackEventFullDto<ReactionEventDto> slackEventDto)
        {
            string channelId = slackEventDto.Event.Item.Channel;
            // process reaction event based on channel
            if (channelId == _introductionChannelId)
            {
                await ProcessReactionIntroAddedEvent(slackEventDto);
            }

            if (channelId == _privateIntroChannelId)
            {
                await ProcessPrivateIntroReactionAddedEvent(slackEventDto);
            }

            if (channelId == _privateRegistrationChannelId)
            {
                await ProcessPrivateRegistrationReactionAddedEvent(slackEventDto);
            }

            if (channelId == _privateProjectsChannelId)
            {
                await ProcessPrivateProjectsReactionAddedEvent(slackEventDto);
            }
        }

        private async Task ProcessPrivateIntroReactionAddedEvent(SlackEventFullDto<ReactionEventDto> slackEventDto)
        {
            string reaction = slackEventDto.Event.Reaction;

            if (reaction == "developers")
            {
                string workspaceMemberId = await ParseMemberFromMessage(slackEventDto);
                await ProcessDeveloperRecommendationsReaction(slackEventDto, workspaceMemberId);
                return;
            }

            if (reaction == "projects")
            {
                string workspaceMemberId = await ParseMemberFromMessage(slackEventDto);
                await ProcessProjectRecommendationsReaction(slackEventDto, workspaceMemberId);
                return;
            }

            return;
        }

        private async Task ProcessRegistrationMessageReaction(SlackEventFullDto<ReactionEventDto> slackEventDto, string workspaceMemberId)
        {
            string message = Messages.OnboardingDm(workspaceMemberId);
            await _slackService.ChatPostMessage(workspaceMemberId, message, true);
            return;
        }

        private async Task ProcessDeveloperRecommendationsReaction(SlackEventFullDto<ReactionEventDto> slackEventDto, string workspaceMemberId)
        {
            string workspaceId = slackEventDto.TeamId;
            UserEntity user = await GetUserEntity(workspaceId, workspaceMemberId);
            var userTechnologies = user.UserTechnologies.Select(t => t.Name);

            // retrieve all slack member records with matching technologies
            List<DeveloperTechnologies> technologies = await _chatAppUserStorage.GetDeveloperTechnologiesAsync(userTechnologies.ToArray());
            // Remove self technologies and convert to lookup
            technologies.RemoveAll(t => t.WorkspaceMemberId == workspaceMemberId);
            if (technologies.Count == 0)
            {
                // no members with technologies, no
                // recommendations available
                await _slackService.ChatPostMessage(_privateIntroChannelId, $"no collaborator recommendations for <@{workspaceMemberId}> and tech {string.Join(", ", userTechnologies)}");
                return;
            }

            var technologiesLookup = technologies.ToLookup(t => t.WorkspaceMemberId, t => t.Name);
            // hashset used to filter out duplicates from list in order to generate powerset
            var uniqueTechnologiesList = new HashSet<string>(technologies.Select(t => t.Name)).ToList();
            List<List<string>> technologiesPowerSet = GeneratePowerSet(uniqueTechnologiesList);
            string message = Messages.DeveloperRecommendationsBasedOnSkillsMessage(workspaceMemberId);
            Dictionary<string, List<string>> developerRecommendations = FindRecommendations(technologiesPowerSet, technologiesLookup);

            foreach (var recommendation in developerRecommendations)
            {
                if (recommendation.Value.Count == 0)
                {
                    // exclude the empty set
                    continue;
                }

                string memberList = string.Empty;
                foreach(var memberId in recommendation.Value)
                {
                    memberList = $"{memberList}\n<@{memberId}>";
                }

                string techList = $"\n{recommendation.Key}\n";
                message = $"{message}{techList}{memberList}\n";
            }

            await _slackService.ChatPostMessage(workspaceMemberId, message, true);
            return;
        }

        private async Task ProcessProjectRecommendationsReaction(SlackEventFullDto<ReactionEventDto> slackEventDto, string workspaceMemberId)
        {
            string workspaceId = slackEventDto.TeamId;
            UserEntity user = await GetUserEntity(workspaceId, workspaceMemberId);
            var userTechnologies = user.UserTechnologies.Select(t => t.Name);

            // retrieve all slack member records with matching technologies
            List<ProjectTechnologies> projects = await _technologiesStorage.GetProjectTechnologiesAsync(userTechnologies.ToArray());
            // Remove self technologies and convert to lookup
            if (projects.Count == 0)
            {
                // no projects with associated technologies, 
                // no project recommendations available
                await _slackService.ChatPostMessage(_privateIntroChannelId, $"no project recommendations for <@{workspaceMemberId}> and tech {string.Join(", ", userTechnologies)}");
                return;
            }

            var projectsLookup = projects.ToLookup(p => p.Id.ToString(), p => p.TechnologyName);
            // hashset used to filter out duplicates from list in order to generate powerset
            var uniqueTechnologiesList = new HashSet<string>(projects.Select(p => p.TechnologyName)).ToList();
            List<List<string>> technologiesPowerSet = GeneratePowerSet(uniqueTechnologiesList);
            string message = Messages.ProjectRecommendationsBasedOnSkillsMessage(workspaceMemberId);
            Dictionary<string, List<string>> projectRecommendations = FindRecommendations(technologiesPowerSet, projectsLookup);

            foreach (var recommendation in projectRecommendations)
            {
                if (recommendation.Value.Count == 0)
                {
                    // exclude the empty set
                    continue;
                }

                string techList = $"{recommendation.Key}\n";
                string projectRecommendationList = string.Empty;

                foreach (var projectId in recommendation.Value)
                {
                    var project = projects.Find(p => p.Id.ToString() == projectId);
                    projectRecommendationList = $"{projectRecommendationList}\nProject: {project.ProjectName}\nDescription: {project.ProjectDescription}\nWorkspace: {project.ProjectWorkspaceLink}\n\n";
                }

                message = $"{message}{techList}{projectRecommendationList}";
            }

            await _slackService.ChatPostMessage(workspaceMemberId, message, true, false);
            return;
        }

        private Dictionary<string, List<string>> FindRecommendations(List<List<string>> powerset, ILookup<string, string> itemsLookups)
        {
            Dictionary<string, List<string>> recommendations = new Dictionary<string, List<string>>();

            foreach (var set in powerset)
            {
                if (set.Count == 0)
                {
                    continue;
                }

                var memberList = new List<string>();
                recommendations.Add(string.Join(", ", set), memberList);
                foreach (IGrouping<string, string> technologyList in itemsLookups)
                {
                    string memberId = technologyList.Key;
                    int setLength = set.Count;
                    int technologyLength = technologyList.Count();
                    // if size of both sets are equal continue otherwise continue
                    // to next member
                    if (setLength != technologyLength)
                    {
                        continue;
                    }

                    if ((set.Intersect(technologyList)).Count() == setLength)
                    {
                        memberList.Add(memberId);
                    }
                }
            }

            return recommendations;
        }

        private async Task ProcessPrivateRegistrationReactionAddedEvent(SlackEventFullDto<ReactionEventDto> slackEventDto)
        {
            string reaction = slackEventDto.Event.Reaction;
            if (reaction == "message")
            {
                string workspaceMemberId = await ParseMemberFromMessage(slackEventDto);
                await ProcessRegistrationMessageReaction(slackEventDto, workspaceMemberId);
            }

            if (reaction == "mail")
            {
                // TODO: Implement mail for members that register via UI but
                // never join slack group
            }
        }

        private async Task ProcessPrivateProjectsReactionAddedEvent(SlackEventFullDto<ReactionEventDto> slackEventDto)
        {
            string reaction = slackEventDto.Event.Reaction;
            if (reaction == "share")
            {
                SlackMessageDto message = await _slackService.ChatRetrieveMessage(slackEventDto.Event.Item.Channel, slackEventDto.Event.Item.Ts);
                MessageDetailsDto messageDetails = message.Messages.FirstOrDefault();
                ProjectDto project = JsonConvert.DeserializeObject<ProjectDto>(messageDetails.Text);
                string projectMessage = Messages.ProjectPostedMessage(project, $"{_mainUrl}/projects/{project.Id}");
                await _slackService.ChatPostMessage(_projectIdeasChannel, projectMessage);
            }
        }

        private async Task ProcessReactionIntroAddedEvent(SlackEventFullDto<ReactionEventDto> slackEventDto)
        {
            if (InvalidTechnologyReaction(slackEventDto))
            {
                return;
            }

            // get technology from reaction and persist
            string reaction = slackEventDto.Event.Reaction;
            string technologyName = reaction.Remove(reaction.LastIndexOf("-"));
            string workspaceId = slackEventDto.TeamId;
            string workspaceMemberId = slackEventDto.Event.ItemUser;
            UserEntity user = await GetUserEntity(workspaceId, workspaceMemberId);
            TechnologyEntity technology = new TechnologyEntity()
            {
                Name = technologyName,
                UserId = user.Id
            };

            TechnologyEntity technologyExists = user.UserTechnologies.Find(t => t.Name == technologyName);
            // avoid duplicate entries by checking if
            // technology already exists in db
            if (technologyExists != null)
            {
                return;
            }

            await _technologiesStorage.CreateAsync(technology);
            return;
        }

        private async Task ProcessReactionRemovedEvent(SlackEventFullDto<ReactionEventDto> slackEventDto)
        {
            if (InvalidTechnologyReaction(slackEventDto))
            {
                return;
            }

            string reactionName = slackEventDto.Event.Reaction;
            SlackMessageDto messageDto = await _slackService.ChatRetrieveMessage(slackEventDto.Event.Item.Channel, slackEventDto.Event.Item.Ts);
            MessageDetailsDto initialMessage = messageDto.Messages.First();
            Reaction reaction = initialMessage.Reactions?.Find(r => r.Name == reactionName);

            // Only delete technology if it's the last
            // instance of the particular reaction and
            // if the remaining reactions do not belong 
            // to privileged members.
            if (reaction != null)
            {
                bool reactedByPrivilegedUsers = reaction.Users.Intersect(_privilegedMembers.Members).Count() > 0;
                bool reactedByOwner = reaction.Users.Contains(initialMessage.User);

                if (reactedByPrivilegedUsers || reactedByOwner)
                {
                    return;
                }
            }

            string technologyName = reactionName.Remove(reactionName.LastIndexOf("-"));
            string workspaceId = slackEventDto.TeamId;
            string workspaceMemberId = slackEventDto.Event.ItemUser;
            UserEntity user = await GetUserEntity(workspaceId, workspaceMemberId);
            TechnologyEntity technology = user.UserTechnologies.Find(tech => tech.Name == technologyName);

            // if technology has been deleted that for
            // some reason doesn't exist in db return
            if (technology == null)
            {
                return;
            }
            await _technologiesStorage.DeleteAsync(technology.Id);
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

            UserEntity user = await GetUserEntity(workspaceId, workspaceMemberId);

            if (string.IsNullOrWhiteSpace(user.Bio))
            {
                user.Bio = slackEventDto.Event.Text;
                await _userStorage.UpdateAsync(user);
                await _slackService.ChatPostMessage(_privateIntroChannelId, $"<@{workspaceMemberId}> posted intro.");
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
                string message = Messages.OnboardingMessage(workspaceMemberId, user.Email, password);
                await _slackService.ChatPostMessage(workspaceMemberId, message);
                await _slackService.ChatPostMessage(_privateRegistrationChannelId, $"<@{workspaceMemberId}>, `{username}`, `{user.Email}` joined the slack group. Send follow up.");
            }
            else
            {
                // User email is already register to frontend
                // associate new chat user record with existing user
                // TODO: Picture may be overwritten here if member
                // previously uploaded a profile pic through frontend,
                // remove once we have profile upload functionality on UI.
                existingUser.ProfilePictureUrl = slackEventDto.Event.User.Profile.Image192;

                ChatAppUserEntity newChatAppUser = new ChatAppUserEntity()
                {
                    WorkspaceId = workspaceId,
                    WorkspaceMemberId = workspaceMemberId,
                    UserId = existingUser.Id,
                };

                await _userStorage.UpdateAsync(existingUser);
                await _chatAppUserStorage.CreateAsync(newChatAppUser);
                string message = Messages.OnboardingRegisteredMessage(workspaceMemberId);
                await _slackService.ChatPostMessage(workspaceMemberId, message);
                await _slackService.ChatPostMessage(_privateRegistrationChannelId, $"<@{workspaceMemberId}>, `{existingUser.Username}`, `{existingUser.Username}` registered and joined the slack group. Send follow up.");
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

            UserEntity existingUser = await GetUserEntity(workspaceId, workspaceMemberId);
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

        private async Task<UserEntity> GetUserEntity(string workspaceId, string workspaceMemberId)
        {
            ChatAppUserEntity workspaceUser = await _chatAppUserStorage.FindAsync(u => u.WorkspaceId == workspaceId && u.WorkspaceMemberId == workspaceMemberId);
            UserEntity user = workspaceUser.User;
            return user;
        }

        private bool InvalidTechnologyReaction(SlackEventFullDto<ReactionEventDto> slackEventDto)
        {
            bool invalidTechnologyReaction = false;
            // Validate reaction performed in intro channel
            if (slackEventDto.Event.Item.Channel != _introductionChannelId)
            {
                invalidTechnologyReaction = true;
            }

            // Validate reaction is performed on message
            if (slackEventDto.Event.Item.Type != "message")
            {
                invalidTechnologyReaction = true;
            }

            // Validate reaction performed by privileged member
            // or message owner
            string reactingMember = slackEventDto.Event.User;
            string messageOwner = slackEventDto.Event.ItemUser;
            if (!_privilegedMembers.Members.Contains(reactingMember) && reactingMember != messageOwner)
            {
                invalidTechnologyReaction = true;
            }

            // Validate reaction is of type -tech or -lang
            string reaction = slackEventDto.Event.Reaction;
            if (!reaction.Contains("-lang") && !reaction.Contains("-tech"))
            {
                invalidTechnologyReaction = true;
            }

            return invalidTechnologyReaction;
        }

        private List<List<T>> GeneratePowerSet<T>(List<T> items)
        {
            List<List<T>> powerSet = new List<List<T>>();
            int n = items.Count;
            int powerSetCount = 1 << n;
            for (int setMask = 0; setMask < powerSetCount; setMask++)
            {
                var subset = new List<T>();
                for (int i = 0; i < n; i++)
                {
                    if ((setMask & (1 << i)) > 0)
                    {
                        subset.Add(items[i]);
                    }
                }
                powerSet.Add(subset);
            }

            return powerSet;
        }

        private async Task<string> ParseMemberFromMessage(SlackEventFullDto<ReactionEventDto> slackEventDto)
        {
            SlackMessageDto messageDto = await _slackService.ChatRetrieveMessage(slackEventDto.Event.Item.Channel, slackEventDto.Event.Item.Ts);
            MessageDetailsDto initialMessage = messageDto.Messages.FirstOrDefault();
            int startIndex = initialMessage.Text.IndexOf('@') + 1;
            int endIndex = initialMessage.Text.IndexOf('>') - 1;
            int length = endIndex - startIndex + 1;
            string memberId = initialMessage.Text.Substring(startIndex, length);

            return memberId;
        }
    }
}
