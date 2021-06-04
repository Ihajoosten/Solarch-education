using System;
using Pitstop.Infrastructure.Messaging.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using StudyProgramManagementAPI.Repositories;

namespace StudyProgramManagementAPI
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add repo
            var studyProgramConnectionString = _configuration.GetConnectionString("StudyProgramManagementCN");
            services.AddTransient<IStudyProgramRepository>((sp) =>
                new SqlServerStudyProgramRepository(studyProgramConnectionString));

            // add messagepublisher
            services.UseRabbitMQMessagePublisher(_configuration);

            // add commandhandlers
            // services.AddCommandHandlers();

            // Add framework services.
            services
                .AddMvc((options) => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudyProgramManagement API", Version = "v1" });
            });

            services.AddHealthChecks(checks =>
            {
                checks.WithDefaultCacheDuration(TimeSpan.FromSeconds(1));
                checks.AddSqlCheck("StudyProgramManagementCN", _configuration.GetConnectionString("StudyProgramManagementCN"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime, IStudyProgramRepository studyProgramRepository)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(_configuration)
                .Enrich.WithMachineName()
                .CreateLogger();

            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudyProgramManagement API - v1");
            });

            // initialize database
            studyProgramRepository.EnsureDatabase();
        }
    }
}
