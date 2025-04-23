using CKD.DataAccess.FluentConfig;
using CKD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Part> Parts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Fluent API 

            modelBuilder.ApplyConfiguration(new FluentProductConfig());
            modelBuilder.ApplyConfiguration(new FluentPartConfig());

        }
    }
}
