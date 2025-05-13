using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SalesWebMvc.Models;
using System.IO;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContextFactory : IDesignTimeDbContextFactory<SalesWebMvcContext>
    {
        public SalesWebMvcContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SalesWebMvcContext>();

            var connectionString = configuration.GetConnectionString("SalesWebMvcContext");

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new SalesWebMvcContext(optionsBuilder.Options);
        }
    }
}
