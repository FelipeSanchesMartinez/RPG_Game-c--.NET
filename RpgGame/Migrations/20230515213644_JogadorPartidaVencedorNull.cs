using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgGame.Migrations
{
    /// <inheritdoc />
    public partial class JogadorPartidaVencedorNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Partida_PartidaJogadorVencedorId",
                table: "Partida");

            migrationBuilder.AlterColumn<long>(
                name: "PartidaJogadorVencedorId",
                table: "Partida",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_PartidaJogadorVencedorId",
                table: "Partida",
                column: "PartidaJogadorVencedorId",
                unique: true,
                filter: "[PartidaJogadorVencedorId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Partida_PartidaJogadorVencedorId",
                table: "Partida");

            migrationBuilder.AlterColumn<long>(
                name: "PartidaJogadorVencedorId",
                table: "Partida",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partida_PartidaJogadorVencedorId",
                table: "Partida",
                column: "PartidaJogadorVencedorId",
                unique: true);
        }
    }
}
