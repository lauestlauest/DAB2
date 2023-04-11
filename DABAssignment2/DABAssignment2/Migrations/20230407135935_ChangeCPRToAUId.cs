using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DABAssignment2.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCPRToAUId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("CustomerCPR", "dbo.Customer", "AuId");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("AuId", "dbo.Customer", "CustomerCPR");
        }
    }
}
