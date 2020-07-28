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
using Infrastructure.Persistence.TableStorage;

namespace MailEngine
{
    public class Startup
    {
        private readonly ILogger _logger;
        private readonly ILogger<MessageQueue> _mqLogger;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILogger<Startup> logger, ILogger<MessageQueue> mqLogger)
        {
            Configuration = configuration;
            _logger = logger;
            _mqLogger = mqLogger;
            InitializeAppSettings();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<ProjectRecommendations>();
            services.AddHostedService<ProjectLaunchShowcase>();
            services.AddSingleton<IMessageQueue, MessageQueue>(provider => new MessageQueue(AppSettings.ServiceBusConnectionString, AppSettings.ServiceBusQueueName, _mqLogger));
            services.AddSingleton<IMailConfigStorage, MailConfigStorage>(provider => new MailConfigStorage(AppSettings.TableStorageConnectionString, AppSettings.StorageTableName));
            _logger.LogInformation("Configured Hosted Service(s)");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }

        private void InitializeAppSettings()
        {
            AppSettings.ConnectionString = Configuration["ConnectionString"];
            AppSettings.ServiceBusConnectionString = Configuration["ServiceBusConnectionString"];
            AppSettings.ServiceBusQueueName = Configuration["ServiceBusQueueName"];
            AppSettings.SendGridTemplatesApiKey = Configuration["SendGridTemplatesApiKey"];
            AppSettings.MainUrl = Configuration["MainUrl"];
            AppSettings.TableStorageConnectionString = Configuration["TableStorageConnectionString"];
            AppSettings.StorageTableName = Configuration["StorageTableName"];
            AppSettings.Env = Configuration["ASPNETCORE_ENVIRONMENT"];
            AppSettings.PubSlackAppQueueName = Configuration["PubSlackAppQueueName"];

            if (AppSettings.ConnectionString == null
            || AppSettings.ServiceBusConnectionString == null
            || AppSettings.ServiceBusQueueName == null
            || AppSettings.SendGridTemplatesApiKey == null
            || AppSettings.MainUrl == null
            || AppSettings.TableStorageConnectionString == null
            || AppSettings.StorageTableName == null
            || AppSettings.PubSlackAppQueueName == null
            || AppSettings.Env == null)
            {
                throw new StartupException(ExceptionMessage.ApplicationMissingStartupVariables);
            }

            _logger.LogInformation("Initialized App Settings");
        }
    }
}
