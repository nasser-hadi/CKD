using System;
using CKD.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CKD.DataAccess.FluentConfig
{
    public class FluentProductPartConfig : IEntityTypeConfiguration<ProductPart>
    {
        public void Configure(EntityTypeBuilder<ProductPart> builder)
        {
            // Setting two ProductPart properties as a composite key.
            builder.HasKey(ba => new { ba.Product_ProductCode, ba.Part_TechNo });
            builder.ToTable("TBL_ProductParts");
            
            builder.Property(x => x.Qty);

            builder.HasOne(b => b.Product).WithMany(b => b.ProductParts).HasForeignKey(b => b.Product_ProductCode);

            builder.HasOne(b => b.Part).WithMany(b => b.ProductParts).HasForeignKey(b => b.Part_TechNo);

        }
    }
}
