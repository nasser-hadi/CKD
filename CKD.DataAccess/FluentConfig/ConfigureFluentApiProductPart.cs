using CKD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKD.DataAccess.FluentConfig
{
    public class ConfigureFluentApiProductPart : IEntityTypeConfiguration<ProductPart>
    {
        public void Configure(EntityTypeBuilder<ProductPart> builder)
        {
            builder.HasKey(ba => new { ba.Product_ProductCode, ba.Part_TechNo });
            builder.ToTable("TBL_ProductParts");
            //builder.Property(x => x.TechNo).ValueGeneratedNever();// Ensure the field is not auto-generated
            builder.Property(x => x.Qty);

            builder.HasOne(b => b.Product).WithMany(b => b.ProductParts).HasForeignKey(b => b.Product_ProductCode);

            builder.HasOne(b => b.Part).WithMany(b => b.ProductParts).HasForeignKey(b => b.Part_TechNo);

        }
    }
}
