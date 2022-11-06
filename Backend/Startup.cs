using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.Options;
using Backend.Services;
using System.Linq;

namespace Backend
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = new ConfigurationBuilder()
              .AddJsonFile("appSettings.json", optional: true)
              .AddJsonFile("appsettings.Development.json", optional: true)
              .AddEnvironmentVariables()
              .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("ChatRoom"));
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend", Version = "v1" });
            });
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
        }

        public void Configure(IApplicationBuilder app, DataContext context)
        {
            app.UseHttpsRedirection();

            // TODO: Fix this if we have a domain
            app.UseCors(policy =>
                policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());

            context.Database.Migrate();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend v1"));
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
