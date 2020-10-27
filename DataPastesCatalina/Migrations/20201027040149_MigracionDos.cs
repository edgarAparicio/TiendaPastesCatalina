using Microsoft.EntityFrameworkCore.Migrations;

namespace EdgarAparicio.PastesCatalina.Data.Migrations
{
    public partial class MigracionDos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paste_TipoSabor_TipoSaborId",
                table: "Paste");

            migrationBuilder.DropIndex(
                name: "IX_Paste_TipoSaborId",
                table: "Paste");

            migrationBuilder.DropColumn(
                name: "TipoSaborId",
                table: "Paste");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoSabor",
                newName: "IdTipoSabor");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Paste",
                newName: "IdPaste");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoSabor",
                table: "Paste",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paste_IdTipoSabor",
                table: "Paste",
                column: "IdTipoSabor");

            migrationBuilder.AddForeignKey(
                name: "FK_Paste_TipoSabor_IdTipoSabor",
                table: "Paste",
                column: "IdTipoSabor",
                principalTable: "TipoSabor",
                principalColumn: "IdTipoSabor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paste_TipoSabor_IdTipoSabor",
                table: "Paste");

            migrationBuilder.DropIndex(
                name: "IX_Paste_IdTipoSabor",
                table: "Paste");

            migrationBuilder.DropColumn(
                name: "IdTipoSabor",
                table: "Paste");

            migrationBuilder.RenameColumn(
                name: "IdTipoSabor",
                table: "TipoSabor",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdPaste",
                table: "Paste",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "TipoSaborId",
                table: "Paste",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paste_TipoSaborId",
                table: "Paste",
                column: "TipoSaborId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paste_TipoSabor_TipoSaborId",
                table: "Paste",
                column: "TipoSaborId",
                principalTable: "TipoSabor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
