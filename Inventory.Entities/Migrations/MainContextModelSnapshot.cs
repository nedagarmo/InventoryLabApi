﻿// <auto-generated />
using System;
using Inventory.Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inventory.Entities.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Inventory.Entities.Models.Movement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 1, 10, 23, 52, 58, 431, DateTimeKind.Utc).AddTicks(672));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WarehouseDestinationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WarehouseOriginId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TypeId");

                    b.HasIndex("WarehouseDestinationId");

                    b.HasIndex("WarehouseOriginId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("Inventory.Entities.Models.MovementType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 1, 10, 23, 52, 58, 427, DateTimeKind.Utc).AddTicks(1936));

                    b.Property<bool>("IsOutlet")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTransfer")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("MovementTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("41841961-b61c-42b4-a88d-5c617409bf79"),
                            CreatedAt = new DateTime(2021, 1, 10, 23, 52, 58, 427, DateTimeKind.Utc).AddTicks(9722),
                            IsOutlet = false,
                            IsTransfer = false,
                            Name = "Entrada por compra"
                        },
                        new
                        {
                            Id = new Guid("37a33133-1db4-4eaf-b96f-db678506d30b"),
                            CreatedAt = new DateTime(2021, 1, 10, 23, 52, 58, 428, DateTimeKind.Utc).AddTicks(205),
                            IsOutlet = true,
                            IsTransfer = false,
                            Name = "Salida por venta"
                        },
                        new
                        {
                            Id = new Guid("2e31f9af-1d4f-4bbf-a25e-818a335c5119"),
                            CreatedAt = new DateTime(2021, 1, 10, 23, 52, 58, 428, DateTimeKind.Utc).AddTicks(209),
                            IsOutlet = false,
                            IsTransfer = true,
                            Name = "Entrada por traslado"
                        },
                        new
                        {
                            Id = new Guid("e19abc4b-e0d4-4bf2-b0aa-dc7ae2b0fe74"),
                            CreatedAt = new DateTime(2021, 1, 10, 23, 52, 58, 428, DateTimeKind.Utc).AddTicks(212),
                            IsOutlet = true,
                            IsTransfer = true,
                            Name = "Salida por traslado"
                        });
                });

            modelBuilder.Entity("Inventory.Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 1, 10, 23, 52, 58, 426, DateTimeKind.Utc).AddTicks(687));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Inventory.Entities.Models.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AccumulatedValue")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 1, 10, 23, 52, 58, 443, DateTimeKind.Utc).AddTicks(3901));

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Inventory.Entities.Models.Warehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 1, 10, 23, 52, 58, 412, DateTimeKind.Utc).AddTicks(1159));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("MaximumQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("Inventory.Entities.Models.Movement", b =>
                {
                    b.HasOne("Inventory.Entities.Models.Product", "Product")
                        .WithMany("Movements")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.Entities.Models.MovementType", "Type")
                        .WithMany("Movements")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.Entities.Models.Warehouse", "WarehouseDestination")
                        .WithMany("DestinationMovements")
                        .HasForeignKey("WarehouseDestinationId");

                    b.HasOne("Inventory.Entities.Models.Warehouse", "WarehouseOrigin")
                        .WithMany("OriginMovements")
                        .HasForeignKey("WarehouseOriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Type");

                    b.Navigation("WarehouseDestination");

                    b.Navigation("WarehouseOrigin");
                });

            modelBuilder.Entity("Inventory.Entities.Models.Stock", b =>
                {
                    b.HasOne("Inventory.Entities.Models.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.Entities.Models.Warehouse", "Wharehouse")
                        .WithMany("Stocks")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Wharehouse");
                });

            modelBuilder.Entity("Inventory.Entities.Models.MovementType", b =>
                {
                    b.Navigation("Movements");
                });

            modelBuilder.Entity("Inventory.Entities.Models.Product", b =>
                {
                    b.Navigation("Movements");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("Inventory.Entities.Models.Warehouse", b =>
                {
                    b.Navigation("DestinationMovements");

                    b.Navigation("OriginMovements");

                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}