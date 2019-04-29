using AutoMapper;
using ManicOceanic.DOMAIN.Repositories;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using ManicOceanic.DOMAIN.Services;
using ManicOceanic.DOMAIN.Services.Interfaces;
using ManicOceanic.DOMAIN.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Owin;
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
      services.AddScoped<IOrderService, OrderService>();
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<ICustomerService, CustomerService>();
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<ICustomerRepository, CustomerRepository>();
      services.AddScoped<IOrderRepository, OrderRepository>();
      services.AddAutoMapper();
      
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
    }
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

