using Central.DAL.EFCore.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Central.Core.Interfaces.Repositories;
using Central.Core.Interfaces.Services;
using Central.Core.Interfaces.Services.Clients;
using Central.Core.Services;
using Central.Core.Services.Clients;
using Central.DAL.EFCore.Repositories;
using Central.DAL.EFCore.Util;
using MySql.Data.MySqlClient.Memcached;

namespace Central.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Controller Register
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            #endregion

            #region Services Register
            services.AddScoped<IElectionService, ElectionService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IOptionsService, OptionsService>();
            services.AddScoped<IDepartmentalVoteService, DepartamentalVoteService>();
            #endregion

            #region Http Client Register
            
            var departmentsConfiguration = new DepartmentsConfiguration();
            Configuration.GetSection("DepartmentsConfiguration").Bind(departmentsConfiguration);
            foreach (var config in departmentsConfiguration)
            {
                if (config.Value.Active)
                {
                    services.AddHttpClient<IDepartmentClient, DepartmentClient>(config.Key, client =>
                    {
                        client.BaseAddress = new Uri(config.Value.Domain);
                        return new DepartmentClient(client, config.Key);
                    }).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler {
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                    });
                }
            }

            #endregion

            #region Repositories Register
            services.AddScoped<IElectionRepository, ElectionRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentalVoteRepository, DepartmentalVoteRepository>();
            services.AddScoped<IOptionsRepository, OptionsRepository>();
            #endregion

            #region DbContext Register
            //This defines the connection string used for the DbContext
            services.AddDbContext<CentralContext>(c =>
                c.UseMySQL(Configuration.GetConnectionString("DbConnection")));
            #endregion

            #region Swagger Register
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Central.Api", Version = "v1" });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Central.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
