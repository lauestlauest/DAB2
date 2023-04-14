using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAB_2_Solution.Migrations
{
    /// <inheritdoc />
    public partial class staff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Customer_CustomerCPR",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customer_CustomerCPR",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerCPR",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_CustomerCPR",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "AUid",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AUid",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerCPR",
                table: "Customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PostCode",
                table: "Canteens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    CanteenName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_Canteens_CanteenName",
                        column: x => x.CanteenName,
                        principalTable: "Canteens",
                        principalColumn: "CanteenName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AUid",
                table: "Reservations",
                column: "AUid");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AUid",
                table: "Ratings",
                column: "AUid");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_CanteenName",
                table: "Staff",
                column: "CanteenName");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Customer_AUid",
                table: "Ratings",
                column: "AUid",
                principalTable: "Customer",
                principalColumn: "CustomerCPR",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customer_AUid",
                table: "Reservations",
                column: "AUid",
                principalTable: "Customer",
                principalColumn: "CustomerCPR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Customer_AUid",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customer_AUid",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_AUid",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_AUid",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "AUid",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "AUid",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Canteens");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerCPR",
                table: "Customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerCPR",
                table: "Reservations",
                column: "CustomerCPR");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CustomerCPR",
                table: "Ratings",
                column: "CustomerCPR");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Customer_CustomerCPR",
                table: "Ratings",
                column: "CustomerCPR",
                principalTable: "Customer",
                principalColumn: "CustomerCPR",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customer_CustomerCPR",
                table: "Reservations",
                column: "CustomerCPR",
                principalTable: "Customer",
                principalColumn: "CustomerCPR");
        }
    }
}
