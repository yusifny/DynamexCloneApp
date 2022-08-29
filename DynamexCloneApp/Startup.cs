using System;
using DynamexCloneApp.DAL;
using DynamexCloneApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DynamexCloneApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(op =>
                op.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddIdentity<AppUser, IdentityRole>(op =>
                {
                    op.User.RequireUniqueEmail = true;

                    op.Password.RequireDigit = true;
                    op.Password.RequiredLength = 8;
                    op.Password.RequireLowercase = true;
                    op.Password.RequireUppercase = true;
                    op.Password.RequireNonAlphanumeric = true;

                    op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                    op.Lockout.MaxFailedAccessAttempts = 3;
                    op.Lockout.AllowedForNewUsers = true;
                }
            ).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name : "areas",
                    pattern : "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{Id?}"
                );
            });
        }
    }
}