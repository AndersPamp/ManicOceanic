using ManicOceanic.DOMAIN.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Owin;
using System;
using ManicOceanic.DOMAIN.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;

namespace ManicOceanic.DOMAIN
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<MOContext>(options => 
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddDefaultIdentity<Customer>()
        .AddDefaultUI(UIFramework.Bootstrap4)
        .AddEntityFrameworkStores<MOContext>();
    }
    

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello World!");
      });
      app.UseAuthentication();
      app.UseStaticFiles();
      app.UseAuthentication();
;    }
  }
  public class IdentityConfig
  {
    private readonly MOContext _context;

    public IdentityConfig(MOContext context)
    {

    }
    public void Configuration(IAppBuilder app)
    {
      app.CreatePerOwinContext(() => _context);
    }
  }
}
