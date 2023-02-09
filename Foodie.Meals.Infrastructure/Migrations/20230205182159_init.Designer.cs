﻿// <auto-generated />
using System;
using Foodie.Meals.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Foodie.Meals.Infrastructure.Migrations
{
    [DbContext(typeof(MealsDbContext))]
    [Migration("20230205182159_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryRestaurant", b =>
                {
                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantsRestaurantId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesCategoryId", "RestaurantsRestaurantId");

                    b.HasIndex("RestaurantsRestaurantId");

                    b.ToTable("CategoryRestaurant");
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 319, DateTimeKind.Unspecified).AddTicks(4016), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Pasta"
                        },
                        new
                        {
                            CategoryId = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 321, DateTimeKind.Unspecified).AddTicks(5521), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Burger"
                        },
                        new
                        {
                            CategoryId = 3,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 321, DateTimeKind.Unspecified).AddTicks(5556), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Pizza"
                        },
                        new
                        {
                            CategoryId = 4,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 321, DateTimeKind.Unspecified).AddTicks(5561), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Salad"
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Country = "USA",
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 323, DateTimeKind.Unspecified).AddTicks(103), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Las Vegas"
                        },
                        new
                        {
                            CityId = 2,
                            Country = "USA",
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 323, DateTimeKind.Unspecified).AddTicks(145), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Los Angeles"
                        },
                        new
                        {
                            CityId = 3,
                            Country = "USA",
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 323, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "New York"
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
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

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("LocationId");

                    b.HasIndex("CityId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            Address = "Kfc Las Vegas",
                            CityId = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 323, DateTimeKind.Unspecified).AddTicks(5661), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "kfc.lasvegas@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 1
                        },
                        new
                        {
                            LocationId = 2,
                            Address = "Kfc Los Angeles",
                            CityId = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 323, DateTimeKind.Unspecified).AddTicks(5695), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "kfc.losangeles@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 1
                        },
                        new
                        {
                            LocationId = 3,
                            Address = "Kfc New York",
                            CityId = 3,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 323, DateTimeKind.Unspecified).AddTicks(5700), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "kfc.newyork@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 1
                        },
                        new
                        {
                            LocationId = 4,
                            Address = "Pizza Hut Las Vegas",
                            CityId = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 323, DateTimeKind.Unspecified).AddTicks(5703), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "pizzahut.lasvegas@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 2
                        },
                        new
                        {
                            LocationId = 5,
                            Address = "Pizza Hut Los Angeles",
                            CityId = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 323, DateTimeKind.Unspecified).AddTicks(5706), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "pizzahut.losangeles@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 2
                        },
                        new
                        {
                            LocationId = 6,
                            Address = "McDonald's Las Vegas",
                            CityId = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 323, DateTimeKind.Unspecified).AddTicks(5713), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "mcdonalds.lasvegas@email.com",
                            PhoneNumber = "123-123-213",
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Meal", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("MealId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Meals");

                    b.HasData(
                        new
                        {
                            MealId = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 324, DateTimeKind.Unspecified).AddTicks(1211), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Longer",
                            Name = "Longer",
                            Price = 12m,
                            RestaurantId = 1
                        },
                        new
                        {
                            MealId = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 324, DateTimeKind.Unspecified).AddTicks(1247), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Zinger",
                            Name = "Zinger",
                            Price = 10m,
                            RestaurantId = 1
                        },
                        new
                        {
                            MealId = 3,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 324, DateTimeKind.Unspecified).AddTicks(1251), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Pizza Texas",
                            Name = "Pizza Texas",
                            Price = 12m,
                            RestaurantId = 2
                        },
                        new
                        {
                            MealId = 4,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 324, DateTimeKind.Unspecified).AddTicks(1254), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Pizza Carbonara",
                            Name = "Pizza Carbonara",
                            Price = 12m,
                            RestaurantId = 2
                        },
                        new
                        {
                            MealId = 5,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 324, DateTimeKind.Unspecified).AddTicks(1257), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Big Mac",
                            Name = "Big Mac",
                            Price = 15m,
                            RestaurantId = 3
                        },
                        new
                        {
                            MealId = 6,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 324, DateTimeKind.Unspecified).AddTicks(1263), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "McRoyal",
                            Name = "McRoyal",
                            Price = 10m,
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 324, DateTimeKind.Unspecified).AddTicks(4221), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "KFC"
                        },
                        new
                        {
                            RestaurantId = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 324, DateTimeKind.Unspecified).AddTicks(4258), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Pizza Hut"
                        },
                        new
                        {
                            RestaurantId = 3,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 5, 19, 21, 59, 324, DateTimeKind.Unspecified).AddTicks(4263), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "McDonald's"
                        });
                });

            modelBuilder.Entity("CategoryRestaurant", b =>
                {
                    b.HasOne("Foodie.Meals.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Foodie.Meals.Domain.Entities.Restaurant", null)
                        .WithMany()
                        .HasForeignKey("RestaurantsRestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Location", b =>
                {
                    b.HasOne("Foodie.Meals.Domain.Entities.City", "City")
                        .WithMany("Locations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Foodie.Meals.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("Locations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Meal", b =>
                {
                    b.HasOne("Foodie.Meals.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("Meals")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.City", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Restaurant", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("Meals");
                });
#pragma warning restore 612, 618
        }
    }
}