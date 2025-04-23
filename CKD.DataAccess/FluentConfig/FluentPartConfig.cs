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
    public class FluentPartConfig : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasKey(x => x.TechNo);

            builder.ToTable("TBL_Parts");

            builder.Property(x => x.TechNo).ValueGeneratedNever();// Ensure the field is not auto-generated

            builder.Property(x => x.FarsiName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.EnglishName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Version);
            builder.Property(x => x.IsSet);
        }
    }
}
