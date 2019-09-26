using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Common.Contracts;
using Domain.Models;
using Domain.Helpers;
using Common.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API
{
    public class Startup
    {
        private readonly string _apiName = AppSettings.ApiName;
        private readonly string _apiVersion = AppSettings.ApiV1;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            InitializeSettings();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = $"{_apiName}", Version = $"{_apiVersion}" });
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
                });

            services.AddScoped<IProject, Project>();
            services.AddScoped<IProjectUser, ProjectUser>();
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<IUtilities, Utilities>();
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"{_apiName} {_apiVersion}");
                c.RoutePrefix = string.Empty;
            });
            
            app.UseAuthentication();
            app.UseMvc();
        }

        private void InitializeSettings()
        {
            AppSettings.JwtIssuer = Configuration["JwtIssuer"];
            AppSettings.JwtAudience = Configuration["JwtAudience"];
            AppSettings.JwtSecretKey = Configuration["JwtSecretKey"];
            AppSettings.ConnectionString = Configuration["ConnectionString"];
        }
    }
}
