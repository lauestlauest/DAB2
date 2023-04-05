using System;
using DABAssignment2.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DABAssignment2.Migrations
{
    public partial class RemoveJITItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {  migrationBuilder.DropTable("JITItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
            
        }
    }
}
