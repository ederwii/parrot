﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PR.Data;

namespace PR.Data.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("PR.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PR.Data.Models.OrderProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("PR.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PR.Data.Models.OrderProduct", b =>
                {
                    b.HasOne("PR.Data.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PR.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PR.Data.Models.Product", b =>
                {
                    b.HasOne("PR.Data.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("PR.Data.Models.Order", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
