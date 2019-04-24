using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Entities.Sales;
using Microsoft.EntityFrameworkCore;


namespace ManicOceanic.DOMAIN.Data
{
  public class MOContext : DbContext
  {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public MOContext(DbContextOptions<MOContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasAlternateKey(c => c.SocialSecurityNumber);
            modelBuilder.Entity<Customer>()
                .HasAlternateKey(c => c.CustomerNumber);
        }

    }
}
