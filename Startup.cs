using Commander.Data;
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
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Commander
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
            services.AddDbContext<CommanderContext>(options => options.UseSqlServer
                (Configuration.GetConnectionString("MSSQLCommanderConnection")));

            services.AddControllers().AddNewtonsoftJson(setup => 
            {
                setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();  
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICommanderRepo, SQLCommanderRepo>();

            services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "Commander", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Your middleware gets configured here.
        public void Configure(IApplicationBuilder iApplicationBuilder, IWebHostEnvironment iWebHostEnvironment)
        {
            if (iWebHostEnvironment.IsDevelopment())
            {
                iApplicationBuilder.UseDeveloperExceptionPage();
                iApplicationBuilder.UseSwagger();
                iApplicationBuilder.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Commander v1"));
            }

            iApplicationBuilder.UseHttpsRedirection();

            iApplicationBuilder.UseRouting();

            iApplicationBuilder.UseAuthorization();

            iApplicationBuilder.UseEndpoints(iEndPointRouteBuilder =>
            {
                iEndPointRouteBuilder.MapControllers();
            });
        }
    }
}
