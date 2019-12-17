using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CardsAgainstMadLibs.Hubs;
using CardsAgainstMadLibs.Models;
using Microsoft.EntityFrameworkCore;

namespace CardsAgainstMadLibs
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
            services.AddDbContext<CardsAgainstMadLibsContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
            services.AddControllersWithViews();
            services.AddSignalR();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    // pattern: "{controller=Home}/{action=Index}/{id?}");
                    pattern: "{controller=LoginReg}/{action=LandingPage}/{id?}");
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
