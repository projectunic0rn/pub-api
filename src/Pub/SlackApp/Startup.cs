using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Common.AppSettings;
using Common.Contracts;
using Common.Exceptions;
using Infrastructure.Messaging;

namespace SlackApp
{
    public class Startup
    {
        private readonly ILogger _logger;
        private readonly ILogger<MessageQueue> _mqLogger;
        public Startup(IConfiguration configuration, ILogger<Startup> logger, ILogger<MessageQueue> mqLogger)
        {
            Configuration = configuration;
            _logger = logger;
            _mqLogger = mqLogger;
            InitializeSettings();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<IMessageQueue>((provider) => new MessageQueue(AppSettings.ServiceBusConnectionString, AppSettings.ServiceBusQueueName, _mqLogger));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use((context, next) =>
            {
                context.Request.EnableBuffering();
                return next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitializeSettings()
        {
            AppSettings.SlackSigningSecret = Configuration["SlackSigningSecret"];
            AppSettings.ServiceBusConnectionString = Configuration["ServiceBusConnectionString"];
            AppSettings.ServiceBusQueueName = Configuration["ServiceBusQueueName"];

            if (AppSettings.SlackSigningSecret == null
            || AppSettings.ServiceBusConnectionString == null
            || AppSettings.ServiceBusQueueName == null)
            {
                throw new StartupException(ExceptionMessage.ApplicationMissingStartupVariables);
            }

            _logger.LogInformation("Initialized App Settings");

        }
    }
}
