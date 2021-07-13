using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PalRaiserMVC.Models;

[assembly: HostingStartup(typeof(PalRaiserMVC.Areas.Identity.IdentityHostingStartup))]
namespace PalRaiserMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(
                    context.Configuration.GetConnectionString("DefaultConnection")));
               
                services.AddDefaultIdentity<AuthUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                }).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();
            });
        }
    }
}