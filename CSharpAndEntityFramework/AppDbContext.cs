using CSharpAndEFLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSharpAndEntityFramework {

    public class AppDbContext : DbContext {

        public virtual DbSet<Customer> Customers { get; set; } //point to Models folder
        public virtual DbSet<Order> Orders { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {  }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseLazyLoadingProxies();
                var connStr = @"server=localhost;database=CustEfDb;trusted_connection=true;";
                builder.UseSqlServer(connStr);
            }
        }

    }
}
