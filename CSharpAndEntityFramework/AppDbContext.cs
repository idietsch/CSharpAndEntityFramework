using CSharpAndEFLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSharpAndEntityFramework {

    public class AppDbContext : DbContext {

        public virtual DbSet<Customer> Customers { get; set; } //point to Models folder
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Orderline> Orderlines { get; set; }
        

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
                e.ToTable("Products");
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).HasMaxLength(10).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Price);
                e.HasIndex(x => x.Code).IsUnique();
            });
            model.Entity<Order>(e => {
                e.ToTable("Orders");
                e.HasKey(x => x.Id);
                e.Property(x => x.Description);
                e.HasOne(x => x.Customerx);
                e.Property(x => x.CustomerId);
            });
            model.Entity<Orderline>(e => {
                e.ToTable("Orderlines");
                e.HasKey(x => x.Id);
                e.HasOne(x => x.Productx).WithMany(x => x.Orderlines).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
