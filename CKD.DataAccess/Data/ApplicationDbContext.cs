using System;
using CKD.DataAccess.FluentConfig;
using CKD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<ProductPart> ProductParts { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Fluent API 

            modelBuilder.ApplyConfiguration(new FluentProductConfig());
            modelBuilder.ApplyConfiguration(new FluentPartConfig());

            modelBuilder.ApplyConfiguration(new FluentProductPartConfig());
        }
    }
}
