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
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 309, DateTimeKind.Unspecified).AddTicks(9852), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Pasta" },
                    { 2, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 313, DateTimeKind.Unspecified).AddTicks(3919), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Burger" },
                    { 3, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 313, DateTimeKind.Unspecified).AddTicks(3956), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Pizza" },
                    { 4, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 313, DateTimeKind.Unspecified).AddTicks(3961), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Salad" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "USA", "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 314, DateTimeKind.Unspecified).AddTicks(8647), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Las Vegas" },
                    { 2, "USA", "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 314, DateTimeKind.Unspecified).AddTicks(8681), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Los Angeles" },
                    { 3, "USA", "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 314, DateTimeKind.Unspecified).AddTicks(8685), new TimeSpan(0, 2, 0, 0, 0)), null, null, "New York" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 316, DateTimeKind.Unspecified).AddTicks(1817), new TimeSpan(0, 2, 0, 0, 0)), null, null, "KFC" },
                    { 2, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 316, DateTimeKind.Unspecified).AddTicks(1847), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Pizza Hut" },
                    { 3, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 316, DateTimeKind.Unspecified).AddTicks(1852), new TimeSpan(0, 2, 0, 0, 0)), null, null, "McDonald's" }
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
                table: "Locations",
                columns: new[] { "Id", "Address", "CityId", "CreatedBy", "CreatedDate", "Email", "LastModifiedBy", "LastModifiedDate", "PhoneNumber", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Kfc Las Vegas", 1, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(3809), new TimeSpan(0, 2, 0, 0, 0)), "kfc.lasvegas@email.com", null, null, "123-123-213", 1 },
                    { 2, "Kfc Los Angeles", 2, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(3843), new TimeSpan(0, 2, 0, 0, 0)), "kfc.losangeles@email.com", null, null, "123-123-213", 1 },
                    { 3, "Kfc New York", 3, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(3847), new TimeSpan(0, 2, 0, 0, 0)), "kfc.newyork@email.com", null, null, "123-123-213", 1 },
                    { 4, "Pizza Hut Las Vegas", 1, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(3851), new TimeSpan(0, 2, 0, 0, 0)), "pizzahut.lasvegas@email.com", null, null, "123-123-213", 2 },
                    { 5, "Pizza Hut Los Angeles", 2, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(3854), new TimeSpan(0, 2, 0, 0, 0)), "pizzahut.losangeles@email.com", null, null, "123-123-213", 2 },
                    { 6, "McDonald's Las Vegas", 1, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(3859), new TimeSpan(0, 2, 0, 0, 0)), "mcdonalds.lasvegas@email.com", null, null, "123-123-213", 3 }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(9179), new TimeSpan(0, 2, 0, 0, 0)), "Longer", null, null, "Longer", 12m, 1 },
                    { 2, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(9212), new TimeSpan(0, 2, 0, 0, 0)), "Zinger", null, null, "Zinger", 10m, 1 },
                    { 3, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(9216), new TimeSpan(0, 2, 0, 0, 0)), "Pizza Texas", null, null, "Pizza Texas", 12m, 2 },
                    { 4, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(9219), new TimeSpan(0, 2, 0, 0, 0)), "Pizza Carbonara", null, null, "Pizza Carbonara", 12m, 2 },
                    { 5, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(9222), new TimeSpan(0, 2, 0, 0, 0)), "Big Mac", null, null, "Big Mac", 15m, 3 },
                    { 6, "Seed", new DateTimeOffset(new DateTime(2023, 3, 26, 15, 48, 53, 315, DateTimeKind.Unspecified).AddTicks(9227), new TimeSpan(0, 2, 0, 0, 0)), "McRoyal", null, null, "McRoyal", 10m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRestaurant_RestaurantsId",
                table: "CategoryRestaurant",
                column: "RestaurantsId");

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
        }
    }
}