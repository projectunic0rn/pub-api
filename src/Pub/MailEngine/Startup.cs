using Common.AppSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MailEngine.Mails.ScheduledMails;
using Common.Contracts;
using Common.Exceptions;
using Infrastructure.Messaging;
using System.Collections.Generic;
using Infrastructure.Persistence.TableStorage;

namespace MailEngine
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
            InitializeAppSettings();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<ProjectRecommendations>();
            services.AddHostedService<ProjectLaunchShowcase>();
            services.AddSingleton<IMessageQueue, MessageQueue>(provider => new MessageQueue(AppSettings.ServiceBusConnectionString, AppSettings.ServiceBusQueueName));
            services.AddSingleton<IMailConfigStorage, MailConfigStorage>(provider => new MailConfigStorage(AppSettings.TableStorageConnectionString, AppSettings.StorageTableName));
            _logger.LogInformation("Configured Hosted Service(s)");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }

        private void InitializeAppSettings()
        {
            AppSettings.ConnectionString = Configuration["ConnectionString"];
            AppSettings.ServiceBusConnectionString = Configuration["ServiceBusConnectionString"];
            AppSettings.ServiceBusQueueName = Configuration["ServiceBusQueueName"];
            AppSettings.SendGridTemplatesApiKey = Configuration["SendGridApiKey"];
            AppSettings.AppUrl = Configuration["AppUrl"];
            AppSettings.TableStorageConnectionString = Configuration["TableStorageConnectionString"];
            AppSettings.StorageTableName = Configuration["StorageTableName"];
            
            if (AppSettings.ConnectionString == null
            || AppSettings.ServiceBusConnectionString == null
            || AppSettings.ServiceBusQueueName == null
            || AppSettings.SendGridTemplatesApiKey == null
            || AppSettings.AppUrl == null
            || AppSettings.TableStorageConnectionString == null
            || AppSettings.StorageTableName == null)
            {
                throw new StartupException(ExceptionMessage.ApplicationMissingStartupVariables);
            }

            _logger.LogInformation("Initialized App Settings");
        }
    }
}
