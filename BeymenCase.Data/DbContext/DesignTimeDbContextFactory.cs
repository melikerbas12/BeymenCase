using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.Extensions.Configuration;
using BeymenCase.Data.Context;

namespace NewInn.General.Infrastructure.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BeymenCaseDbContext>
    {
        public BeymenCaseDbContext CreateDbContext(string[] args)
        {
            
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BeymenCase.WebAPI/"))
                .AddJsonFile("appsettings.Development.json")
                .Build();

            System.Console.WriteLine(configuration);

            var builder = new DbContextOptionsBuilder<BeymenCaseDbContext>();
            var connectionString = configuration.GetConnectionString("PostgreConnection");
            builder.UseNpgsql(connectionString);
            
            return new BeymenCaseDbContext(builder.Options);
        }
    }
}