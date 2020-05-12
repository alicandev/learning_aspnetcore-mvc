using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FeatureToggles>(x => new FeatureToggles {
                DeveloperExceptions = _configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions")
            });
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FeatureToggles features)
        {
            if (features.DeveloperExceptions)
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/error.html");

            app.Use(async (ctx, next) =>
            {
                if(ctx.Request.Path.Value.Contains("invalid"))
                    throw new Exception("Woah!");
                await next();
            });

            app.UseMvc(routes =>
                routes.MapRoute(
                    "Default",
                    "{controller=Home}/{action=Index}/{id?}"
                )
            );
            
            app.UseFileServer();
        }
    }
}