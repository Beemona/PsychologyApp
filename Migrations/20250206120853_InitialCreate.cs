using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PsychologyTypeId = table.Column<int>(type: "int", nullable: true),
                    PsychotherapyTypeId = table.Column<int>(type: "int", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partners_PsychologyTypes_PsychologyTypeId",
                        column: x => x.PsychologyTypeId,
                        principalTable: "PsychologyTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partners_PsychotherapyTypes_PsychotherapyTypeId",
                        column: x => x.PsychotherapyTypeId,
                        principalTable: "PsychotherapyTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partners_PsychologyTypeId",
                table: "Partners",
                column: "PsychologyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_PsychotherapyTypeId",
                table: "Partners",
                column: "PsychotherapyTypeId");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partners");

        }
    }
}
