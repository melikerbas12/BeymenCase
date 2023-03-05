using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeymenCase.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeymenCase.Data.Configurations
{
    public static class BaseConfiguration
    {
        public static void ConfigureBase<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseIdEntityModel
        {
            builder
                .HasKey(a => a.Id);

            builder.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NOW()");

            builder
                .Property(m => m.IsActive)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("True");
        }

    }
}