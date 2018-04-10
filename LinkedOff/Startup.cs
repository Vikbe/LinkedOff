using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LinkedOff.Data;
using LinkedOff.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace LinkedOff
{
    public class Startup
    {

        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentity<LinkedUser, IdentityRole>(cfg =>
           {
               cfg.User.RequireUniqueEmail = true;
           })
           .AddEntityFrameworkStores<LinkedContext>();

            services.AddAuthentication()
        .AddCookie()
        .AddJwtBearer(cfg =>
        {
            cfg.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = _config["Tokens:Issuer"],
                ValidAudience = _config["Tokens:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
            };

        });



            services.AddDbContext<LinkedContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("LinkedConnectionString"));
            });

            services.AddAutoMapper();

            services.AddTransient<LinkedSeeder>();

            services.AddScoped<ILinkedRepository, LinkedRepository>();
            services.AddMvc(opt =>
            {
                if (_env.IsProduction())
                {
                    opt.Filters.Add(new RequireHttpsAttribute());
                }
            })
               .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
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
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(cfg =>
           {
               cfg.MapRoute("Default",
                   "{controller}/{action}/{id?}",
                   new { controller = "App", Action = "Timeline" });
           });

            if (env.IsDevelopment())
            {
                // Seed the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<LinkedSeeder>();
                    seeder.Seed().Wait();
                }
            }

        }
    }
}
