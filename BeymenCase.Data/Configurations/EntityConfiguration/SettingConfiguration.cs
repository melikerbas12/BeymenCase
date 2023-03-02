using BeymenCase.Core.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeymenCase.Data.Configurations.EntityConfiguration
{
   public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {

            builder.ConfigureBase();

            builder.ToTable("Settings");
        }
    }
}