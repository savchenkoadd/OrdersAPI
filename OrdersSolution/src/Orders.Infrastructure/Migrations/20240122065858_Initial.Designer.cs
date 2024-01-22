﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orders.Infrastructure.Db;

#nullable disable

namespace Orders.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240122065858_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Orders.Core.Entities.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("PlacedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d94dee42-f00a-4361-9668-269a3795cb4a"),
                            CustomerName = "John",
                            OrderNumber = "Order_2024_1",
                            PlacedDate = new DateTime(2024, 1, 22, 8, 58, 58, 929, DateTimeKind.Local).AddTicks(3941),
                            TotalAmount = 1200.0
                        },
                        new
                        {
                            Id = new Guid("62d513f7-cd0a-4d59-b415-9cf0c67a29e4"),
                            CustomerName = "Mike",
                            OrderNumber = "Order_2024_2",
                            PlacedDate = new DateTime(2024, 1, 22, 8, 58, 58, 929, DateTimeKind.Local).AddTicks(3996),
                            TotalAmount = 600.0
                        });
                });

            modelBuilder.Entity("Orders.Core.Entities.Orders.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("OrderItems", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("72c023c4-0b70-48b1-870c-8fa117f861f1"),
                            OrderId = new Guid("d94dee42-f00a-4361-9668-269a3795cb4a"),
                            ProductName = "Laptop",
                            Quantity = 1,
                            TotalPrice = 1200.0,
                            UnitPrice = 1200.0
                        },
                        new
                        {
                            Id = new Guid("2550ec20-daa8-4868-8eec-c84f00041e9c"),
                            OrderId = new Guid("62d513f7-cd0a-4d59-b415-9cf0c67a29e4"),
                            ProductName = "Phone",
                            Quantity = 2,
                            TotalPrice = 600.0,
                            UnitPrice = 300.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
