using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Network.Domain;
using Network.Models;
using Network.Service;
using Network.Services;

namespace Network
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

      
        public void ConfigureServices(IServiceCollection services)
        {
            
            Configuration.Bind("Project", new Config());

            services.AddControllersWithViews();
            services.AddMvc();

            services.AddScoped<ProfileService>();
            services.AddScoped<PostService>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

          
            app.UseStaticFiles();

            
            app.UseRouting();

    
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

     
            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllerRoute("default", "{controller=Profile}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Profile}/{action=Details}/{id?}");
            });
        }
    }
}
