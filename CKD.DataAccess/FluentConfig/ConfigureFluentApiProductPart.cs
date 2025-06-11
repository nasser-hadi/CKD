using CKD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CKD.DataAccess.FluentConfig
{
    public class ConfigureFluentApiProductPart : IEntityTypeConfiguration<ProductPart>
    {
        public void Configure(EntityTypeBuilder<ProductPart> builder)
        {
            builder.ToTable("TBL_ProductParts");

            builder.HasKey(ba => new { ba.Product_ProductCode, ba.Part_TechNo });

            builder.Property(x => x.Quantity);

            builder.HasOne(b => b.Product).WithMany(b => b.ProductParts).HasForeignKey(b => b.Product_ProductCode);

            builder.HasOne(b => b.Part).WithMany(b => b.ProductParts).HasForeignKey(b => b.Part_TechNo);
        }
    }
}
