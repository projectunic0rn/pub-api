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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Common.AppSettings;
using Common.Contracts;
using CommunicationAppDomain.Handlers;
using Common.Exceptions;

namespace SlackApp
{
    public class Startup
    {
        private readonly ILogger _logger;
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
            InitializeSettings();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IChatAppEventHandler, CommunicationAppDomain.Handlers.EventHandler>();
            services.AddScoped<IChatAppCommandHandler, CommandHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            app.UseMvc();
        }

        private void InitializeSettings()
        {
            AppSettings.ConnectionString = Configuration["ConnectionString"];
            AppSettings.AppUrl = Configuration["AppUrl"];
            AppSettings.MainUrl = Configuration["MainUrl"];
            AppSettings.IntroductionChannelId = Configuration["IntroductionChannelId"];
            AppSettings.SlackSigningSecret = Configuration["SlackSigningSecret"];
            AppSettings.SlackAuthToken = Configuration["SlackAuthToken"];
            AppSettings.GitHubOrganization = Configuration["GithubOrganization"];
            AppSettings.GitHubAppId = Configuration["GithubAppId"];
            AppSettings.GitHubAppInstallationId = Configuration["GithubAppInstallationId"];
            AppSettings.GitHubAppPrivateRSAKey = Configuration["GithubAppPrivateRSAKey"];
            AppSettings.PrivilegedMembers = Configuration["PrivilegedMembers"];

            if (AppSettings.ConnectionString == null
            || AppSettings.AppUrl == null
            || AppSettings.MainUrl == null
            || AppSettings.IntroductionChannelId == null
            || AppSettings.SlackSigningSecret == null
            || AppSettings.SlackAuthToken == null
            || AppSettings.GitHubOrganization == null
            || AppSettings.GitHubAppId == null
            || AppSettings.GitHubAppInstallationId == null
            || AppSettings.GitHubAppPrivateRSAKey == null
            || AppSettings.PrivilegedMembers == null)
            {
                throw new StartupException(ExceptionMessage.ApplicationMissingStartupVariables);
            }

            _logger.LogInformation("Initialized App Settings");

        }
    }
}
