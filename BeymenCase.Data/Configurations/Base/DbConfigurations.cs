using System;
using System.Collections;
using System.Collections.Generic;
using BeymenCase.Data.Configurations.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BeymenCase.Data.Configurations
{
    public static class DbConfigurations
    {

        public static void DbConfiguration(this ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new SettingConfiguration());
        }

        public static void DbSeedData(this ModelBuilder modelBuilder)
        {

        }
    }
}