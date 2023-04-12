using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAB_2_Solution.Migrations
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
                    CanteenName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostCode = table.Column<int>(type: "int", nullable: false)
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
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerCPR);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuItemsId = table.Column<int>(type: "int", nullable: false),
                    MealType = table.Column<int>(type: "int", nullable: false),
                    MealName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CanteenName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NrReservations = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuItemsId);
                    table.ForeignKey(
                        name: "FK_Menu_Canteens_CanteenName",
                        column: x => x.CanteenName,
                        principalTable: "Canteens",
                        principalColumn: "CanteenName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingsId = table.Column<int>(type: "int", nullable: false),
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
                    MealId = table.Column<int>(type: "int", nullable: false),
                    CustomerCPR = table.Column<int>(type: "int", nullable: true),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "CustomerCPR");
                    table.ForeignKey(
                        name: "FK_Reservations_Menu_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "Menu",
                        principalColumn: "MenuItemsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_CanteenName",
                table: "Menu",
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

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MenuItemId",
                table: "Reservations",
                column: "MenuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Canteens");
        }
    }
}
