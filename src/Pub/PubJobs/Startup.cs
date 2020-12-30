using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Common.AppSettings;
using PubJobs.BackgroundServices;
using Common.Exceptions;
using Common.Services;
using Common.Contracts;
using MailEngine.Mails.ScheduledMails;
using Infrastructure.Messaging;
using Infrastructure.Persistence.TableStorage;

namespace PubJobs
{
    public class Startup
    {
        private readonly Dictionary<string, string> _workspaceAppUrls;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _workspaceAppUrls = Configuration["ASPNETCORE_ENVIRONMENT"] == "Production" ?
                new Dictionary<string, string> { { "slack", "https://pub-slack-workspace.azurewebsites.net" }, { "discord", "https://pub-discord-workspace.azurewebsites.net" } }
                :
                new Dictionary<string, string> { { "slack", "https://pub-slack-workspace-test.azurewebsites.net" }, { "discord", "https://pub-discord-workspace-test.azurewebsites.net" } };

        }

        public IConfiguration Configuration { get; }
        private Settings _settings { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Settings settings = Configuration.Get<Settings>();
            _settings = settings;
            services.AddSingleton(p => settings);
            services.AddSingleton<INotifier, TransactionalMailNotifier>();
            services.AddSingleton(pub => new PubService(_settings.PubApiEndpoint, _settings.ApiKey));

            services.AddSingleton<IMessageQueue>((container) =>
            {
                container.GetRequiredService<ILogger<Startup>>().LogError("PubJobs v0.0.2");
                var logger = container.GetRequiredService<ILogger<MessageQueue>>();
                return new MessageQueue(_settings.ServiceBusConnectionString, _settings.ServiceBusQueueName, logger);
            });
            services.AddSingleton<IMailConfigStorage, MailConfigStorage>(provider => new MailConfigStorage(_settings.TableStorageConnectionString, _settings.StorageTableName));
            services.AddSingleton(provider => new WorkspaceAppService(_workspaceAppUrls));

            services.AddHostedService<HideDeadProjects>();
            services.AddHostedService<MessageListener>();
            ValidateSettings();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }

        private void ValidateSettings()
        {
            // TODO: Remove dependency on AppSettings.cs to load app variables
            // using it here since SendGridService.cs is using AppSettings.SendGridTemplatesApiKey
            // directly to read send grid api key. Because of that we need to set AppSettings.SendGrid...
            // var directly. In future have SendGridService.cs depend on _settings.SendGridTemplatesApiKey
            AppSettings.SendGridTemplatesApiKey = Configuration["SendGridTemplatesApiKey"];
            AppSettings.ConnectionString = Configuration["ConnectionString"];

            if (_settings.PubApiEndpoint == null
                || _settings.ServiceBusConnectionString == null
                || _settings.ServiceBusQueueName == null
                || _settings.PubJobsQueueName == null
                || _settings.ConnectionString == null
                || _settings.ApiKey == null
                || _settings.SendGridTemplatesApiKey == null
                || _settings.TableStorageConnectionString == null
                || _settings.MailTrackingTableName == null
                || _settings.StorageTableName == null)
            {
                string message = ExceptionMessage.ApplicationMissingStartupVariables;
                var ex = new StartupException(message);
                throw ex;
            }
        }
    }
}
