
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SlackAppBot.HostedServices;
using Common.Contracts;
using Common.AppSettings;
using CommunicationAppDomain.Handlers;

namespace SlackAppBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Some projects read config directly from app settings.
                    // Set them here from the Configuration as needed for test
                    // environments
                    // TODO: Consider more approachable secrets management where
                    // we don't need to assign each individual secret - instead 
                    // inject configurations directly into class via constructor
                    // w/ configuration parameter
                    AppSettings.ConnectionString = hostContext.Configuration["ConnectionString"];
                    AppSettings.MainUrl = hostContext.Configuration["MainUrl"];
                    AppSettings.GitHubOrganization = hostContext.Configuration["GithubOrganization"];
                    AppSettings.GitHubAppId = hostContext.Configuration["GitHubAppId"];
                    AppSettings.GitHubAppInstallationId = hostContext.Configuration["GitHubAppInstallationId"];
                    AppSettings.GitHubAppPrivateRSAKey = hostContext.Configuration["GitHubAppPrivateRSAKey"];
                    AppSettings.PrivateIntroChannelId = hostContext.Configuration["PrivateIntroChannelId"];
                    AppSettings.PrivateRegistrationChannelId = hostContext.Configuration["PrivateRegistrationChannelId"];
                    AppSettings.PrivateProjectsChannelId = hostContext.Configuration["PrivateProjectsChannelId"];
                    AppSettings.PrivateFeedbackChannelId = hostContext.Configuration["PrivateFeedbackChannelId"];
                    AppSettings.IntroductionChannelId = hostContext.Configuration["IntroductionChannelId"];
                    AppSettings.SlackAuthToken = hostContext.Configuration["SlackAuthToken"];
                    AppSettings.PrivilegedMembers = hostContext.Configuration["PrivilegedMembers"];

                    services.AddScoped<IChatAppEventHandler, EventHandler>();
                    services.AddScoped<IChatAppCommandHandler, CommandHandler>();
                    services.AddHostedService<MessageListener>();
                });
    }
}
