using System;
using DABAssignment2.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DABAssignment2.Migrations
{
    public partial class RemoveJITItemsTable : Migration
    {
        //Not testet
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Menu","MealType", 2,null);
            migrationBuilder.AddCheckConstraint( "newRangeForMealType", "Menu", "MealType between 0 and 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint("newRangeForMealType", "Menu", null);
        }

    }
}
