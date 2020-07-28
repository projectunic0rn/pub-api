using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Common.Contracts;
using Domain.Models;
using Domain.Helpers;
using Common.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MailEngine.Mails.ScheduledMails;
using Infrastructure.Messaging;
using Infrastructure.Persistence.TableStorage;
using Common.Exceptions;
using API.AuthScheme;
using API.ApiKeys;
using Microsoft.AspNetCore.Authorization;
using Common.Services;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        private readonly ILogger _logger;
        private readonly ILogger<MessageQueue> _mqLogger;
        private readonly string _apiName = AppSettings.ApiName;
        private readonly string _apiVersion = AppSettings.ApiV1;
        private readonly Dictionary<string, string> _workspaceAppUrls;
        private Settings _settings { get; set; }

        public Startup(IConfiguration configuration, ILogger<Startup> logger, ILogger<MessageQueue> mqLogger)
        {
            Configuration = configuration;
            _logger = logger;
            _mqLogger = mqLogger;
            _workspaceAppUrls = Configuration["ASPNETCORE_ENVIRONMENT"] == "Production" ?
                new Dictionary<string, string> { { "slack", "https://pub-slack-workspace.azurewebsites.net" }, { "discord", "https://pub-discord-workspace.azurewebsites.net" } } 
                :
                new Dictionary<string, string> { { "slack", "https://pub-slack-workspace-test.azurewebsites.net" }, { "discord", "https://pub-discord-workspace-test.azurewebsites.net" } };
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowLocal",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{_apiName}", Version = $"{_apiVersion}" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = AppSettings.JwtIssuer,
                        ValidAudience = AppSettings.JwtAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JwtSecretKey))
                    };
                })
                .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.DefaultScheme, config =>{});

            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme,
                    ApiKeyAuthenticationOptions.DefaultScheme);
                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });

            Settings settings = Configuration.Get<Settings>();
            _settings = settings;
            services.AddSingleton(p => settings);

            services.AddScoped<IProject, Project>();
            services.AddScoped<IProjectUser, ProjectUser>();
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<IUtilities, Utilities>();
            services.AddScoped<INotifier, TransactionalMailNotifier>();
            services.AddScoped<IUser, User>();
            services.AddSingleton<IFetchApiKey, ApiKeysStore>(provider => new ApiKeysStore(AppSettings.ApiKey));
            services.AddSingleton<IMessageQueue, MessageQueue>(provider => new MessageQueue(AppSettings.ServiceBusConnectionString, AppSettings.ServiceBusQueueName, _mqLogger));
            services.AddSingleton<IMailConfigStorage, MailConfigStorage>(provider => new MailConfigStorage(AppSettings.TableStorageConnectionString, AppSettings.StorageTableName));
            services.AddSingleton(provider => new WorkspaceAppService(_workspaceAppUrls));
            InitializeSettings();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("AllowLocal");
            }
            else
            {
                app.UseHttpsRedirection();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"{_apiName} {_apiVersion}");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitializeSettings()
        {
            AppSettings.ServiceBusConnectionString = Configuration["ServiceBusConnectionString"];
            AppSettings.ServiceBusQueueName = Configuration["ServiceBusQueueName"];

            AppSettings.JwtIssuer = Configuration["JwtIssuer"];
            AppSettings.JwtAudience = Configuration["JwtAudience"];
            AppSettings.JwtSecretKey = Configuration["JwtSecretKey"];
            AppSettings.ConnectionString = Configuration["ConnectionString"];

            AppSettings.FeedbackRecipients = Configuration["FeedbackRecipients"];
            AppSettings.Env = Configuration["ASPNETCORE_ENVIRONMENT"];

            AppSettings.TableStorageConnectionString = Configuration["TableStorageConnectionString"];
            AppSettings.StorageTableName = Configuration["StorageTableName"];
            AppSettings.SendGridTemplatesApiKey = Configuration["SendGridTemplatesApiKey"];
            AppSettings.ApiKey = Configuration["ApiKey"];
            AppSettings.PubSlackAppQueueName = Configuration["PubSlackAppQueueName"];

            if (AppSettings.ServiceBusConnectionString == null
            || AppSettings.ServiceBusQueueName == null
            || AppSettings.JwtIssuer == null
            || AppSettings.JwtAudience == null
            || AppSettings.JwtSecretKey == null
            || AppSettings.ConnectionString == null
            || AppSettings.FeedbackRecipients == null
            || AppSettings.Env == null
            || AppSettings.TableStorageConnectionString == null
            || AppSettings.StorageTableName == null
            || _settings.MailTrackingTableName == null
            || AppSettings.SendGridTemplatesApiKey == null
            || AppSettings.ApiKey == null
            || AppSettings.PubSlackAppQueueName == null)
            {
                throw new StartupException(ExceptionMessage.ApplicationMissingStartupVariables);
            }

            _logger.LogInformation("Initialized App Settings");
        }
    }
}
