using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAB_2_Solution.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Staff");
        }
    }
}
