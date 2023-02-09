﻿// <auto-generated />
using System;
using Foode.Identity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Foode.Identity.Infrastructure.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    partial class IdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "fe10688b-b67d-4027-84e6-23c256af188d",
                            ConcurrencyStamp = "890df069-eded-465c-9267-7d4533905227",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "35d96949-978e-4f88-851b-bbb750e6d0ad",
                            ConcurrencyStamp = "695078be-51ec-4cf7-9357-6016c4e91bd1",
                            Name = "OrderHandler",
                            NormalizedName = "ORDERHANDLER"
                        },
                        new
                        {
                            Id = "65cff553-91da-46e6-81b5-c6adb8852b5c",
                            ConcurrencyStamp = "1724b40b-96f1-47af-8932-484bd4389997",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ApplicationUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("ApplicationUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("ApplicationUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "f175aa8f-1cf3-427f-8be5-def2bed3c564",
                            RoleId = "fe10688b-b67d-4027-84e6-23c256af188d"
                        },
                        new
                        {
                            UserId = "51d8f926-867b-49c5-a3ba-56a76203a6a5",
                            RoleId = "35d96949-978e-4f88-851b-bbb750e6d0ad"
                        },
                        new
                        {
                            UserId = "6a1ab648-6be8-44f1-87b7-394c34547589",
                            RoleId = "65cff553-91da-46e6-81b5-c6adb8852b5c"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("ApplicationUserTokens");
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("Foodie.Identity.Domain.Entities.ApplicationUser");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = "f175aa8f-1cf3-427f-8be5-def2bed3c564",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a71e28db-4e6a-496c-930b-6ccb8f5ed566",
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 9, 16, 56, 28, 431, DateTimeKind.Unspecified).AddTicks(5605), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "michsco123@foodie.com",
                            EmailConfirmed = true,
                            FirstName = "Michael",
                            LastName = "Scott",
                            LockoutEnabled = false,
                            NormalizedEmail = "MICHSCO123@FOODIE.COM",
                            NormalizedUserName = "MICHSCO123@FOODIE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAED5z+D7R1U8gUnBUm+g039Xk72ihsZ2CyKj2ylB7PlEdFpXHgbTWm/KfjhYGlevLgw==",
                            PhoneNumber = "123-456-789",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "afc1ad89-5b1b-401b-a2a5-3a029c65bce6",
                            TwoFactorEnabled = false,
                            UserName = "michsco123"
                        });
                });

            modelBuilder.Entity("Foodie.Identity.Domain.Entities.Customer", b =>
                {
                    b.HasBaseType("Foodie.Identity.Domain.Entities.ApplicationUser");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = "6a1ab648-6be8-44f1-87b7-394c34547589",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fed507b0-300c-481b-a783-019e16958e89",
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 9, 16, 56, 28, 471, DateTimeKind.Unspecified).AddTicks(1526), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "jimhal123@foodie.com",
                            EmailConfirmed = true,
                            FirstName = "Jim",
                            LastName = "Halpert",
                            LockoutEnabled = false,
                            NormalizedEmail = "JIMHAL123@FOODIE.COM",
                            NormalizedUserName = "JIMHAL123@FOODIE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEAfOk02VpOLUQSM1Xuzv59MKx/Sc6t9XoXQYp8xxMYij7jeWNza5zUz2djB+IfRZcg==",
                            PhoneNumber = "123-456-789",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "b2082f68-27d1-442e-9c41-2af58096c6f8",
                            TwoFactorEnabled = false,
                            UserName = "jimhal123"
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
                            Id = "51d8f926-867b-49c5-a3ba-56a76203a6a5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "04b5befd-5faf-42ee-b84f-37557276c958",
                            CreatedBy = "Seed",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 9, 16, 56, 28, 458, DateTimeKind.Unspecified).AddTicks(2257), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "dwigsch123@foodie.com",
                            EmailConfirmed = true,
                            FirstName = "Dwight",
                            LastName = "Schrute",
                            LockoutEnabled = false,
                            NormalizedEmail = "DWIGSCH123@FOODIE.COM",
                            NormalizedUserName = "DWIGSCH123@FOODIE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAECtUl+MwRGEc/2kQ1JXlRDvw1EQfitUOTGw4te0j3HxH+Gu1f5M0DlRjwp50LWU7Dw==",
                            PhoneNumber = "123-456-789",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "9b9cc225-430a-40fb-a0d2-a9d13e49a565",
                            TwoFactorEnabled = false,
                            UserName = "dwigsch123",
                            LocationId = 0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Foodie.Identity.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Foodie.Identity.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Foodie.Identity.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Foodie.Identity.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
#pragma warning restore 612, 618
        }
    }
}
