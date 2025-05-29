using CKD.DataAccess.FluentConfig;
using CKD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CKD.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Part> Parts { get; set; }

        public DbSet<ProductPart> ProductParts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Fluent API for Models

            modelBuilder.ApplyConfiguration(new ConfigureFluentApiProduct());
            modelBuilder.ApplyConfiguration(new ConfigureFluentApiPart());

            modelBuilder.ApplyConfiguration(new ConfigureFluentApiProductPart());
        }
    }
}
