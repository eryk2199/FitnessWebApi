using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMealIngredientsUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "MealIngredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "MealIngredients");
        }
    }
}
