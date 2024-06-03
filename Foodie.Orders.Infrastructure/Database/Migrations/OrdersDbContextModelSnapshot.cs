﻿// <auto-generated />
using System;
using Foodie.Orders.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Foodie.Orders.Infrastructure.Database.Migrations
{
    [DbContext(typeof(OrdersDbContext))]
    partial class OrdersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("BuyersSequence")
                .IncrementsBy(10);

            modelBuilder.HasSequence("ContractorsSequence")
                .IncrementsBy(10);

            modelBuilder.HasSequence("OrderItemsSequence")
                .IncrementsBy(10);

            modelBuilder.HasSequence("OrdersSequence")
                .IncrementsBy(10);

            modelBuilder.Entity("Foodie.Orders.Domain.Buyers.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "BuyersSequence");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buyers", (string)null);
                });

            modelBuilder.Entity("Foodie.Orders.Domain.Contractors.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "ContractorsSequence");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contractors", (string)null);
                });

            modelBuilder.Entity("Foodie.Orders.Domain.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "OrdersSequence");

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int?>("ContractorId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ContractorId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Foodie.Orders.Domain.Orders.Order", b =>
                {
                    b.HasOne("Foodie.Orders.Domain.Buyers.Buyer", null)
                        .WithMany()
                        .HasForeignKey("BuyerId");

                    b.HasOne("Foodie.Orders.Domain.Contractors.Contractor", null)
                        .WithMany()
                        .HasForeignKey("ContractorId");

                    b.OwnsMany("Foodie.Orders.Domain.Orders.Entities.OrderItem", "OrderItems", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseHiLo(b1.Property<int>("Id"), "OrderItemsSequence");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTimeOffset>("CreatedDate")
                                .HasColumnType("datetimeoffset");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTimeOffset?>("LastModifiedDate")
                                .HasColumnType("datetimeoffset");

                            b1.Property<int>("MealId")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.Property<decimal>("UnitPrice")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderId");

                            b1.ToTable("OrderItems", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("Foodie.Orders.Domain.Orders.ValueObjects.DeliveryAddress", "DeliveryAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseHiLo(b1.Property<int>("OrderId"), "OrdersSequence");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("DeliveryAddress");

                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}