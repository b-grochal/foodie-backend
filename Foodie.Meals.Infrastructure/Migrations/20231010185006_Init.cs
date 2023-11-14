﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodie.Meals.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRestaurant",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    RestaurantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRestaurant", x => new { x.CategoriesId, x.RestaurantsId });
                    table.ForeignKey(
                        name: "FK_CategoryRestaurant_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRestaurant_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 612, DateTimeKind.Unspecified).AddTicks(8240), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Pasta" },
                    { 2, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 615, DateTimeKind.Unspecified).AddTicks(7285), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Burger" },
                    { 3, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 615, DateTimeKind.Unspecified).AddTicks(7325), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Pizza" },
                    { 4, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 615, DateTimeKind.Unspecified).AddTicks(7332), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Salad" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "USA" },
                    { 2, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 618, DateTimeKind.Unspecified).AddTicks(7042), new TimeSpan(0, 2, 0, 0, 0)), null, null, "KFC" },
                    { 2, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 618, DateTimeKind.Unspecified).AddTicks(7072), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Pizza Hut" },
                    { 3, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 618, DateTimeKind.Unspecified).AddTicks(7076), new TimeSpan(0, 2, 0, 0, 0)), null, null, "McDonald's" }
                });

            migrationBuilder.InsertData(
                table: "CategoryRestaurant",
                columns: new[] { "CategoriesId", "RestaurantsId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 617, DateTimeKind.Unspecified).AddTicks(3614), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Las Vegas" },
                    { 2, 1, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 617, DateTimeKind.Unspecified).AddTicks(3650), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Los Angeles" },
                    { 3, 1, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 617, DateTimeKind.Unspecified).AddTicks(3655), new TimeSpan(0, 2, 0, 0, 0)), null, null, "New York" }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 618, DateTimeKind.Unspecified).AddTicks(4375), new TimeSpan(0, 2, 0, 0, 0)), "Longer", null, null, "Longer", 12m, 1 },
                    { 2, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 618, DateTimeKind.Unspecified).AddTicks(4407), new TimeSpan(0, 2, 0, 0, 0)), "Zinger", null, null, "Zinger", 10m, 1 },
                    { 3, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 618, DateTimeKind.Unspecified).AddTicks(4413), new TimeSpan(0, 2, 0, 0, 0)), "Pizza Texas", null, null, "Pizza Texas", 12m, 2 },
                    { 4, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 618, DateTimeKind.Unspecified).AddTicks(4416), new TimeSpan(0, 2, 0, 0, 0)), "Pizza Carbonara", null, null, "Pizza Carbonara", 12m, 2 },
                    { 5, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 618, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 2, 0, 0, 0)), "Big Mac", null, null, "Big Mac", 15m, 3 },
                    { 6, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 618, DateTimeKind.Unspecified).AddTicks(4425), new TimeSpan(0, 2, 0, 0, 0)), "McRoyal", null, null, "McRoyal", 10m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "CityId", "CreatedBy", "CreatedDate", "Email", "LastModifiedBy", "LastModifiedDate", "PhoneNumber", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Kfc Las Vegas", 1, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 617, DateTimeKind.Unspecified).AddTicks(8863), new TimeSpan(0, 2, 0, 0, 0)), "kfc.lasvegas@email.com", null, null, "123-123-213", 1 },
                    { 4, "Pizza Hut Las Vegas", 1, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 617, DateTimeKind.Unspecified).AddTicks(8907), new TimeSpan(0, 2, 0, 0, 0)), "pizzahut.lasvegas@email.com", null, null, "123-123-213", 2 },
                    { 6, "McDonald's Las Vegas", 1, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 617, DateTimeKind.Unspecified).AddTicks(8916), new TimeSpan(0, 2, 0, 0, 0)), "mcdonalds.lasvegas@email.com", null, null, "123-123-213", 3 },
                    { 2, "Kfc Los Angeles", 2, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 617, DateTimeKind.Unspecified).AddTicks(8896), new TimeSpan(0, 2, 0, 0, 0)), "kfc.losangeles@email.com", null, null, "123-123-213", 1 },
                    { 5, "Pizza Hut Los Angeles", 2, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 617, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 2, 0, 0, 0)), "pizzahut.losangeles@email.com", null, null, "123-123-213", 2 },
                    { 3, "Kfc New York", 3, "Seed", new DateTimeOffset(new DateTime(2023, 10, 10, 20, 50, 5, 617, DateTimeKind.Unspecified).AddTicks(8902), new TimeSpan(0, 2, 0, 0, 0)), "kfc.newyork@email.com", null, null, "123-123-213", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRestaurant_RestaurantsId",
                table: "CategoryRestaurant",
                column: "RestaurantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RestaurantId",
                table: "Locations",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_RestaurantId",
                table: "Meals",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRestaurant");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
