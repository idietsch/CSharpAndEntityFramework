using CSharpAndEFLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSharpAndEntityFramework {

    public class AppDbContext : DbContext {

        public virtual DbSet<Customer> Customers { get; set; } //point to Models folder
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {  }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseLazyLoadingProxies();
                var connStr = @"server=localhost;database=CustEfDb;trusted_connection=true;";
                builder.UseSqlServer(connStr);
            }
        }
        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<Product>(e => {
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).HasMaxLength(10).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Price);
                e.HasIndex(x => x.Code).IsUnique();
            });
        }
    }
}
