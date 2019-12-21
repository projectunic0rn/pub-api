using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mailer
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
            services.AddHostedService<MessageListener>();
            _logger.LogInformation("Configured Hosted Service(s)");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }

        private void InitializeAppSettings()
        {
            AppSettings.ServiceBusConnectionString = Configuration["ServiceBusConnectionString"];
            AppSettings.ServiceBusQueueName = Configuration["ServiceBusQueueName"];
            AppSettings.SendGridApiKey = Configuration["SendGridApiKey"];
            _logger.LogInformation("Initialized App Settings");
        }
    }
}
