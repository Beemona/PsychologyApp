using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.Migrations
{
    /// <inheritdoc />
    public partial class MentalDisorderCategoryAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "MentalDisorders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "MentalDisorders");
        }
    }
}
