using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.Migrations
{
    /// <inheritdoc />
    public partial class PsychologyPsychotherapyMentalDisorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PsychotherapyTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "PsychotherapyTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PsychologyTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "PsychologyTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MentalDisorders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnosticCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PsychologyTypeId = table.Column<int>(type: "int", nullable: true),
                    PsychotherapyTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentalDisorders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MentalDisorders_PsychologyTypes_PsychologyTypeId",
                        column: x => x.PsychologyTypeId,
                        principalTable: "PsychologyTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MentalDisorders_PsychotherapyTypes_PsychotherapyTypeId",
                        column: x => x.PsychotherapyTypeId,
                        principalTable: "PsychotherapyTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MentalDisorders_PsychologyTypeId",
                table: "MentalDisorders",
                column: "PsychologyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MentalDisorders_PsychotherapyTypeId",
                table: "MentalDisorders",
                column: "PsychotherapyTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MentalDisorders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PsychotherapyTypes");

            migrationBuilder.DropColumn(
                name: "Domain",
                table: "PsychotherapyTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PsychologyTypes");

            migrationBuilder.DropColumn(
                name: "Domain",
                table: "PsychologyTypes");
        }
    }
}
