using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PR.Data.Models;

namespace PR.Data
{
    public class OrderDbContext : DbContext
    {
        public string DbPath { get; private set; }

        public OrderDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}parrot.db";
        }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        { }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
