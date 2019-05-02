using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.WEB.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ManicOceanic.WEB.Areas.Identity.IdentityHostingStartup))]
namespace ManicOceanic.WEB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<cs>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("csConnection")));

                services.AddDefaultIdentity<Customer>()
                    .AddEntityFrameworkStores<cs>();
            });
        }
    }
}