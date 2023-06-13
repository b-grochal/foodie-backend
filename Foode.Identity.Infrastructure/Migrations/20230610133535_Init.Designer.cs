﻿// <auto-generated />
using System;
using Foode.Identity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Foode.Identity.Infrastructure.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20230610133535_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.ApplicationUserRefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("ExpirationTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.ToTable("ApplicationUserRefreshTokens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = 1,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 6, 10, 15, 35, 34, 902, DateTimeKind.Unspecified).AddTicks(1978), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = 2,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 6, 10, 15, 35, 34, 902, DateTimeKind.Unspecified).AddTicks(2051), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = 3,
                            ApplicationUserId = 3,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 6, 10, 15, 35, 34, 902, DateTimeKind.Unspecified).AddTicks(2057), new TimeSpan(0, 2, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("Foodie.Identity.Domain.Entities.ApplicationUser");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 6, 10, 15, 35, 34, 382, DateTimeKind.Unspecified).AddTicks(2981), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "michsco123@foodie.com",
                            FirstName = "Michael",
                            IsLocked = false,
                            LastName = "Scott",
                            PasswordHash = "$2a$11$XztFnn9kdY4w9RcdvH0lPO/.HKpy80bmobGQg68J3y27uGgj4nY7q",
                            PhoneNumber = "123-456-789",
                            Role = 1
                        });
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.Customer", b =>
                {
                    b.HasBaseType("Foodie.Identity.Domain.Entities.ApplicationUser");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 6, 10, 15, 35, 34, 752, DateTimeKind.Unspecified).AddTicks(4031), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "jimhal123@foodie.com",
                            FirstName = "Jim",
                            IsLocked = false,
                            LastName = "Halpert",
                            PasswordHash = "$2a$11$J3NpQhzDMy88B3m9XYNzeuCPn8E8sFrmVaymGtTCa8s9Rf/horrbe",
                            PhoneNumber = "123-456-789",
                            Role = 3
                        });
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.OrderHandler", b =>
                {
                    b.HasBaseType("Foodie.Identity.Domain.Entities.ApplicationUser");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.ToTable("OrderHandlers");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 6, 10, 15, 35, 34, 605, DateTimeKind.Unspecified).AddTicks(5155), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "dwigsch123@foodie.com",
                            FirstName = "Dwight",
                            IsLocked = false,
                            LastName = "Schrute",
                            PasswordHash = "$2a$11$7cnkWriTdzObp27Z6HWxPuYc2KPETwYOhnotyqA/IKPMlvMuOdnwi",
                            PhoneNumber = "123-456-789",
                            Role = 2,
                            LocationId = 1
                        });
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.ApplicationUserRefreshToken", b =>
                {
                    b.HasOne("Foodie.Identity.Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithOne("ApplicationUserRefreshToken")
                        .HasForeignKey("Foodie.Identity.Domain.Entities.ApplicationUserRefreshToken", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.Admin", b =>
                {
                    b.HasOne("Foodie.Identity.Domain.Entities.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("Foodie.Identity.Domain.Entities.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.Customer", b =>
                {
                    b.HasOne("Foodie.Identity.Domain.Entities.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("Foodie.Identity.Domain.Entities.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.OrderHandler", b =>
                {
                    b.HasOne("Foodie.Identity.Domain.Entities.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("Foodie.Identity.Domain.Entities.OrderHandler", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserRefreshToken");
                });
#pragma warning restore 612, 618
        }
    }
}