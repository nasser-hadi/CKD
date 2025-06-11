using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CKD.DataAccess.Models;
using System;

namespace CKD.DataAccess.FluentConfig
{
    public class ConfigureFluentApiEngineType : IEntityTypeConfiguration<EngineType>
    {
        public void Configure(EntityTypeBuilder<EngineType> builder)
        {
            builder.ToTable("TBL_EngineTypes");

            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).UseIdentityColumn(seed: 11, increment: 1); // Start at 11, increment by 1

            builder.Property(x => x.Name).IsRequired().HasMaxLength(15);
        }
    }
}
