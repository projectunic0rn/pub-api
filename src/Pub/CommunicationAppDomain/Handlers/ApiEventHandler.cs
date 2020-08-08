using System.Threading.Tasks;
using Common.DTOs;
using Common.Services;
using Common.AppSettings;
using System.Linq;
using Newtonsoft.Json;

namespace CommunicationAppDomain.Handlers
{
    public class ApiEventHandler
    {
        private readonly SlackService _slackService;
        private readonly string _privateRegistrationChannelId;
        private readonly string _privateProjectChannelId;
        private readonly string _privateFeedbackChannelId;
        public ApiEventHandler()
        {
            _slackService = new SlackService();
            _privateRegistrationChannelId = AppSettings.PrivateRegistrationChannelId;
            _privateProjectChannelId = AppSettings.PrivateProjectsChannelId;
            _privateFeedbackChannelId = AppSettings.PrivateFeedbackChannelId;
        }

        public async Task ProcessProjectPost(ProjectDto project)
        {
            var tech = project.ProjectTechnologies.Select(t => t.Name);
            await _slackService.ChatPostMessage(_privateProjectChannelId, JsonConvert.SerializeObject(project));
        }

        public async Task ProcessRegistration(RegistrationDto registration)
        {
            await _slackService.ChatPostMessage(_privateRegistrationChannelId, $"{registration.Username}, {registration.Email} registered.");
        }

        public async Task ProcessFeedback(FeedbackDto feedback)
        {
            await _slackService.ChatPostMessage(_privateFeedbackChannelId, $"New Feedback\n\n{feedback.Content}");
        }
    }
}
