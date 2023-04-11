using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAB_2_Solution.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("CustomerCPR", "Customer", "AUid");
            migrationBuilder.RenameColumn("CustomerCPR", "Reservations", "AUid");
            migrationBuilder.RenameColumn("CustomerCPR", "Ratings", "AUid");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("AUid", "Customer", "CustomerCPR");
            migrationBuilder.RenameColumn("AUid", "Reservation", "CustomerCPR");
            migrationBuilder.RenameColumn("AUid", "Ratings", "CustomerCPR");
        }
    }
}
