using BeymenCase.Core.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BeymenCase.ConfLib.Context
{
    public class ConfigurationDbContext : DbContext
    {
        public ConfigurationDbContext(string databaseConnection): base()
        {
            ConnectionString = databaseConnection.ToString();
        }

        public string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }
        public DbSet<Setting> Settings { get; set; }
    }

}