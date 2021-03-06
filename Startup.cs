using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using DotNetGQL.Model;

namespace DotNetGQL
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNetGQL", Version = "v1" });
            });
            services.AddDbContext<AlexWallotContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlConnection"),ServerVersion.AutoDetect(Configuration.GetConnectionString("MySqlConnection")))
                .UseLazyLoadingProxies());
             services.AddDbContext<Alex_WallotContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection"))
                .UseLazyLoadingProxies());
            services.AddGraphQLServer()
                    .AddQueryType<Query>()
                    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = _env.IsProduction());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNetGQL v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapGraphQL());
        }
    }
}
