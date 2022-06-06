using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic.Abstract;
using BussinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.ADONET;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Context;
using DataAccess.DataSeed;
using GamesectionAPI.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GamesectionAPI
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
            services.AddCors(options => options.AddPolicy(name: "GamesectionAPI", builder =>
            {
                builder.WithOrigins("https://localhost:56564").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            }
                ));
            services.AddControllers();
            services.AddSignalR();
            //services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<ICategoryDAL, EfCategory>();
            //services.AddScoped<IGameService, GameManager>();
            //services.AddScoped<IGameDAL, EfGame>();
            //services.AddDbContext<GamesectionDbContext>();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //DataSeed.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("GamesectionAPI");

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(name:"default",
                    //pattern:"{controller=Game}/{action=Index}/{id?}"); 
                //endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                endpoints.MapHub<CounterHub>("/CounterHub");
            });
        }
    }
}
