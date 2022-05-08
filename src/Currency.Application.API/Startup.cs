
using Didar.Application.API.Infrastructure.Persistence;
using Didar.Application.API.Middleware;
using Didar.Application.API.Service;
using Didar.Application.API.Service.GrpcService;
using Didar.Packaging.Grpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace Didar.Application.API
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
            services.AddDbContext<CurrencyBbContext>(option =>
                       option.UseSqlServer(Configuration.GetConnectionString("CurrencyConnectionString")));

            services.AddGrpcClient<PackagingProtoService.PackagingProtoServiceClient>
               (o => o.Address = new Uri(Configuration["GrpcSettings:PackagingUrl"]));

            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddSingleton<IPackagingGrpcService, PackagingGrpcService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Currency.Application.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.MapWhen(
                httpContext => httpContext.Request.Path.StartsWithSegments("/api/v1") 
                           && !httpContext.Request.Path.StartsWithSegments("/api/v1/Upgrade"),
                subApp => subApp.UseCheckUserAuthorization()
                       );


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Currency.Application.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



        }
    }
}
