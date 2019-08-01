using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.Service.Domain.Repositories;
using Project.Service.Services;
using AutoMapper;
using Project.Service.Persistence.Repositories;
using Project.Service.Persistence.Contexts;
using Project.Service.Domain.Services;

namespace Project.Mvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AppDbContext>
                (item => item.UseSqlServer(Configuration.GetConnectionString("AppConn")));


            services.AddScoped<IVehicleMakeRepository, VehicleMakeRepository>();
            services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();


            services.AddScoped<IVehicleMakeService, VehicleMakeService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();

            services.AddAutoMapper();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
