using System;
using CKD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CKD.DataAccess.FluentConfig
{
    public class FluentProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductCode);

            builder.ToTable("TBL_Products");

            builder.Property(x => x.ProductCode).ValueGeneratedNever();// Ensure the field is not auto-generated

            builder.Property(x => x.ProductVersion).IsRequired();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Notes2).HasMaxLength(500);
            builder.Property(x => x.EngineTypeDesc).IsRequired().HasMaxLength(7);
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.CreateByUserEID);
        }
    }
}