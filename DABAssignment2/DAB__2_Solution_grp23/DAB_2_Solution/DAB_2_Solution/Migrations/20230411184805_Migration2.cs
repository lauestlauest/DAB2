using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAB_2_Solution.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Menu", "MealType", 2);
        }
        protected override  void Down(MigrationBuilder migrationBuilder) { }

    }
}
