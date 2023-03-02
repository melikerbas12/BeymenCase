using BeymenCase.Core.Models.DataModels;
using BeymenCase.Data.Configurations.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BeymenCase.Data.Context
{
   public class BeymenCaseDbContext : DbContext
    {
        public BeymenCaseDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.ApplyConfiguration(new SettingConfiguration());

        }
    }
}