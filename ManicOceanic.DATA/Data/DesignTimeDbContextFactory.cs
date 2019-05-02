using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace ManicOceanic.DATA.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MOContext>
    {
        public MOContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MOContext>();
            var connectionString =
                "Server=tcp:ec-teams.database.windows.net,1433;Initial Catalog=Manic-Oceanic;Persist Security Info=False;User ID=ecteam;Password=Ec@181818;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            builder.UseSqlServer(connectionString);
            return new MOContext(builder.Options);
        }
    }
}