using Microsoft.EntityFrameworkCore.Migrations;
using System.Security.Cryptography.X509Certificates;

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
            migrationBuilder.Sql("EXEC sp_rename 'Customer.AUid', 'CustomerCPR'");
            migrationBuilder.Sql("EXEC sp_rename 'Reservations.AUid', 'CustomerCPR'");
            migrationBuilder.Sql("EXEC sp_rename 'Ratings.AUid', 'CustomerCPR'");
        }
    }
}
