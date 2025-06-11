using CKD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CKD.DataAccess.FluentConfig
{
    /// <summary>
    /// Configure Fluent Api for the Product class
    /// </summary>
    public class ConfigureFluentApiProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TBL_Products");

            builder.HasKey(x => x.ProductCode);

            builder.Property(x => x.ProductCode).ValueGeneratedNever();// Ensure the field is not auto-generated

            builder.Property(x => x.ProductVersion).IsRequired();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Notes).HasMaxLength(1000);
            builder.Property(x => x.EngineTypeDesc).IsRequired().HasMaxLength(10);
            builder.Property(u => u.Image).IsRequired(false);// This makes the field nullable
            builder.Property(u => u.Usage).IsRequired(false).HasMaxLength(25);// This makes the field nullable
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.CreateByUserEID);
        }
    }
}
