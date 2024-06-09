﻿// <auto-generated />
using System;
using Foodie.Meals.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Foodie.Meals.Infrastructure.Database.Migrations
{
    [DbContext(typeof(MealsDbContext))]
    partial class MealsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryRestaurant", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "RestaurantsId");

                    b.HasIndex("RestaurantsId");

                    b.ToTable("CategoryRestaurant");

                    b.HasData(
                        new
                        {
                            CategoriesId = 2,
                            RestaurantsId = 1
                        },
                        new
                        {
                            CategoriesId = 3,
                            RestaurantsId = 2
                        },
                        new
                        {
                            CategoriesId = 2,
                            RestaurantsId = 3
                        });
                });

            modelBuilder.Entity("Foodie.Common.Infrastructure.Database.Audits.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedColumns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Pasta"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Burger"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Salad"
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            IsDeleted = false,
                            Name = "Las Vegas"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            IsDeleted = false,
                            Name = "Los Angeles"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            IsDeleted = false,
                            Name = "New York"
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Germany"
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Kfc Las Vegas",
                            CityId = 1,
                            Email = "kfc.lasvegas@email.com",
                            IsDeleted = false,
                            PhoneNumber = "123-123-213",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Kfc Los Angeles",
                            CityId = 2,
                            Email = "kfc.losangeles@email.com",
                            IsDeleted = false,
                            PhoneNumber = "123-123-213",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            Address = "Kfc New York",
                            CityId = 3,
                            Email = "kfc.newyork@email.com",
                            IsDeleted = false,
                            PhoneNumber = "123-123-213",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 4,
                            Address = "Pizza Hut Las Vegas",
                            CityId = 1,
                            Email = "pizzahut.lasvegas@email.com",
                            IsDeleted = false,
                            PhoneNumber = "123-123-213",
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            Address = "Pizza Hut Los Angeles",
                            CityId = 2,
                            Email = "pizzahut.losangeles@email.com",
                            IsDeleted = false,
                            PhoneNumber = "123-123-213",
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 6,
                            Address = "McDonald's Las Vegas",
                            CityId = 1,
                            Email = "mcdonalds.lasvegas@email.com",
                            IsDeleted = false,
                            PhoneNumber = "123-123-213",
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Meals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Longer",
                            IsDeleted = false,
                            Name = "Longer",
                            Price = 12m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Zinger",
                            IsDeleted = false,
                            Name = "Zinger",
                            Price = 10m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Pizza Texas",
                            IsDeleted = false,
                            Name = "Pizza Texas",
                            Price = 12m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Pizza Carbonara",
                            IsDeleted = false,
                            Name = "Pizza Carbonara",
                            Price = 12m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Big Mac",
                            IsDeleted = false,
                            Name = "Big Mac",
                            Price = 15m,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 6,
                            Description = "McRoyal",
                            IsDeleted = false,
                            Name = "McRoyal",
                            Price = 10m,
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "KFC"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Pizza Hut"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "McDonald's"
                        });
                });

            modelBuilder.Entity("CategoryRestaurant", b =>
                {
                    b.HasOne("Foodie.Meals.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Foodie.Meals.Domain.Entities.Restaurant", null)
                        .WithMany()
                        .HasForeignKey("RestaurantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.City", b =>
                {
                    b.HasOne("Foodie.Meals.Domain.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
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

            modelBuilder.Entity("Foodie.Meals.Domain.Entities.Country", b =>
                {
                    b.Navigation("Cities");
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
