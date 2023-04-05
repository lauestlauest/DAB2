﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAssignment2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canteens",
                columns: table => new
                {
                    CanteenName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canteens", x => x.CanteenName);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerCPR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerCPR);
                });

            migrationBuilder.CreateTable(
                name: "JITItems",
                columns: table => new
                {
                    JITItemsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JITMealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanteenName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JITItems", x => x.JITItemsId);
                    table.ForeignKey(
                        name: "FK_JITItems_Canteens_CanteenName",
                        column: x => x.CanteenName,
                        principalTable: "Canteens",
                        principalColumn: "CanteenName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCPR = table.Column<int>(type: "int", nullable: false),
                    CanteenName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    RatingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingsId);
                    table.ForeignKey(
                        name: "FK_Ratings_Canteens_CanteenName",
                        column: x => x.CanteenName,
                        principalTable: "Canteens",
                        principalColumn: "CanteenName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Customer_CustomerCPR",
                        column: x => x.CustomerCPR,
                        principalTable: "Customer",
                        principalColumn: "CustomerCPR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCPR = table.Column<int>(type: "int", nullable: false),
                    MealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanteenName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Reservations_Canteens_CanteenName",
                        column: x => x.CanteenName,
                        principalTable: "Canteens",
                        principalColumn: "CanteenName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Customer_CustomerCPR",
                        column: x => x.CustomerCPR,
                        principalTable: "Customer",
                        principalColumn: "CustomerCPR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JITItems_CanteenName",
                table: "JITItems",
                column: "CanteenName");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CanteenName",
                table: "Ratings",
                column: "CanteenName");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CustomerCPR",
                table: "Ratings",
                column: "CustomerCPR");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CanteenName",
                table: "Reservations",
                column: "CanteenName");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerCPR",
                table: "Reservations",
                column: "CustomerCPR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JITItems");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Canteens");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
