using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EdgarAparicio.PastesCatalina.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoSabor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSabor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 80, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    TipoSaborId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paste_TipoSabor_TipoSaborId",
                        column: x => x.TipoSaborId,
                        principalTable: "TipoSabor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paste_TipoSaborId",
                table: "Paste",
                column: "TipoSaborId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paste");

            migrationBuilder.DropTable(
                name: "TipoSabor");
        }
    }
}
