using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SenDeOku.Identity;
using SenDeOku.Models;

namespace SenDeOku
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false)
                    .AddRazorRuntimeCompilation();
            string connectionStr = @"Server=(localdb)\MSSQLLocalDB;Database=SenDeOkuDB;Trusted_Connection=true";
            services.AddDbContext<OfficeContext>(options => options.UseSqlServer(connectionStr));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connectionStr));
            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.SignIn.RequireConfirmedEmail = true;
            });
            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Kullanici/Login";
                option.LogoutPath = "/Kullanici/Logout";
                option.AccessDeniedPath = "/Kullanici/Denied";
                option.SlidingExpiration = false;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(1440);
                option.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".SenDeOku.User.Cookie",
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);
        }

        public void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Kullanici}/{action=Index}");
        }

    }
}
