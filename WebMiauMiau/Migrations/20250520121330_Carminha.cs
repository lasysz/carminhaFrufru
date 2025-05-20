
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMiauMiau.Migrations
{
    /// <inheritdoc />
    public partial class Carminha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Miau",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Raca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idade = table.Column<int>(type: "int", nullable: false),
                    cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miau", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Miau");
        }
    }
}
