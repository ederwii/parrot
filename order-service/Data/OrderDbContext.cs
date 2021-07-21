using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PR.Data.Models;

namespace PR.Data
{
    public class OrderDbContext : DbContext
    {

        public OrderDbContext()
        {
        }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        { }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=.;Database=course;Trusted_Connection=True;");

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasIndex(u => u.Name)
                .IsUnique();

            builder.Entity<Order>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<OrderProduct>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Order>().Property(x=>x.OrderDate).HasDefaultValueSql("getutcdate()");
            builder.Entity<OrderProduct>().HasKey(sc => new { sc.OrderId, sc.ProductName });
        }
    }
}
