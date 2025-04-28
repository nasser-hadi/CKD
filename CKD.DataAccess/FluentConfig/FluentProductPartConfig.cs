using CKD.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKD.DataAccess.FluentConfig
{
    public class FluentProductPartConfig : IEntityTypeConfiguration<ProductPart>
    {
        public void Configure(EntityTypeBuilder<ProductPart> builder)
        {
            // Setting two ProductPart properties as a composite key.
            builder.HasKey(ba => new { ba.Product_ProductCode, ba.Part_TechNo });
            builder.ToTable("TBL_ProductParts");
            
            builder.Property(x => x.Quantity);
        }
    }
}
