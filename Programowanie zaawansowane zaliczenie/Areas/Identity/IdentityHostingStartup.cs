using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Programowanie_zaawansowane_zaliczenie.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Programowanie_zaawansowane_zaliczenie.Areas.Identity.IdentityHostingStartup))]
namespace Programowanie_zaawansowane_zaliczenie.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            /*builder.ConfigureServices((context, services) => {
                services.AddDbContext<DatabaseContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("DatabaseContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DatabaseContext>();
            });*/
        }
    }
}