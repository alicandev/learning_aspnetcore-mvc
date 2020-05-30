using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExploreCalifornia
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup (IConfiguration configuration)
        {
            _configuration = configuration;
        } 
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BlogDataContext>(options => 
                options.UseSqlServer(_configuration.GetConnectionString("BlogDataContext"))
            );

            services.AddDbContext<IdentityDataContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("IdentityDataContext"))
            );

            services.AddTransient<FormattingServices>();
            
            services.AddTransient(x => new FeatureToggles {
                DeveloperExceptions = _configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions")
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>();

            services.AddMvc(options => options.EnableEndpointRouting = false);
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FeatureToggles features)
        {
            if (features.DeveloperExceptions) 
                app.UseDeveloperExceptionPage();
            else 
                app.UseExceptionHandler("/error.html");
            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Path.Value.Contains("invalid")) throw new Exception("Woah!");
                await next();
            });
            
            app.UseFileServer();
            app.UseCookiePolicy();
            app.UseAuthentication();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute("Default", 
                    "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}