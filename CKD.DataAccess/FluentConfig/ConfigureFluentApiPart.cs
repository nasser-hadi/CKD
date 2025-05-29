using CKD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CKD.DataAccess.FluentConfig
{
    public class ConfigureFluentApiPart : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasKey(x => x.TechNo);

            builder.ToTable("TBL_Parts");

            builder.Property(x => x.TechNo).ValueGeneratedNever();// Ensure the field is not auto-generated

            builder.Property(x => x.FarsiName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.EnglishName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Version);
            builder.Property(x => x.IsSet);
        }
    }
}
