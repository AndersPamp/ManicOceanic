using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ManicOceanic.DATA.Data;
using Microsoft.EntityFrameworkCore;
using ManicOceanic.DOMAIN.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using ManicOceanic.DOMAIN.Services.Interfaces;
using ManicOceanic.DOMAIN.Services;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using ManicOceanic.DATA.Data.Repositories;
using System.Globalization;
using System;
using System.Threading.Tasks;

namespace ManicOceanic.WEB
{
    public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

        private static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var _userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();
            Customer iu = await _userManager.FindByEmailAsync("admin@admin.se");
            if (iu == null)
            {
                iu = new Customer();
                iu.Email = "admin@admin.se";
                iu.UserName = "admin@admin.se";
                iu.SocialSecurityNumber = "123123123123";
                var identityResult = await _userManager.CreateAsync(iu, "Secret1234-");
                await _userManager.UpdateAsync(iu);
            }
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("Manager"))
            {
                await roleManager.CreateAsync(new IdentityRole("Manager"));
            }
            await _userManager.AddToRoleAsync(iu, "Admin");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddDistributedMemoryCache();

      services.AddSession(options =>
      {
          // Set a short timeout for easy testing.
          //options.IdleTimeout = TimeSpan.FromHours(1);
          options.Cookie.HttpOnly = true;
          // Make the session cookie essential
          options.Cookie.IsEssential = true;
      });
            services.AddSession();

            services.AddAutoMapper();

      services.AddDbContext<MOContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddDefaultIdentity<Customer>()
          .AddDefaultUI(UIFramework.Bootstrap4)
          .AddRoles<IdentityRole>()
          .AddEntityFrameworkStores<MOContext>();

      services.AddScoped<IOrderService, OrderService>();
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<ICustomerService, CustomerService>();
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<ICustomerRepository, CustomerRepository>();
      services.AddScoped<IOrderRepository, OrderRepository>();
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
    {
        var cultureInfo = new CultureInfo("en-US");
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseSession();
      app.UseAuthentication();
      app.UseCookiePolicy();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });
            CreateRoles(serviceProvider).Wait();
        }
  }
}
