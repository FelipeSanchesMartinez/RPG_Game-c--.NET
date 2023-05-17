using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgGame.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personagem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Vida = table.Column<int>(type: "int", nullable: false),
                    Forca = table.Column<int>(type: "int", nullable: false),
                    Defesa = table.Column<int>(type: "int", nullable: false),
                    Agilidade = table.Column<int>(type: "int", nullable: false),
                    QtdDados = table.Column<int>(type: "int", nullable: false),
                    FacesDado = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartidaJogador",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonagemId = table.Column<long>(type: "bigint", nullable: false),
                    Vida = table.Column<int>(type: "int", nullable: false),
                    PrimeiroTurno = table.Column<bool>(type: "bit", nullable: false),
                    ResultadoDadoPrimeiroTurno = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidaJogador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartidaJogador_Personagem_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidaJogador1Id = table.Column<long>(type: "bigint", nullable: false),
                    PartidaJogador2Id = table.Column<long>(type: "bigint", nullable: false),
                    PartidaJogadorTurnoId = table.Column<long>(type: "bigint", nullable: false),
                    PartidaJogadorVencedorId = table.Column<long>(type: "bigint", nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partida_PartidaJogador_PartidaJogador1Id",
                        column: x => x.PartidaJogador1Id,
                        principalTable: "PartidaJogador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partida_PartidaJogador_PartidaJogador2Id",
                        column: x => x.PartidaJogador2Id,
                        principalTable: "PartidaJogador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partida_PartidaJogador_PartidaJogadorTurnoId",
                        column: x => x.PartidaJogadorTurnoId,
                        principalTable: "PartidaJogador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partida_PartidaJogador_PartidaJogadorVencedorId",
                        column: x => x.PartidaJogadorVencedorId,
                        principalTable: "PartidaJogador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartidaLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidaId = table.Column<long>(type: "bigint", nullable: false),
                    PartidaJogadorId = table.Column<long>(type: "bigint", nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DadoResultado = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<int>(type: "int", nullable: false),
                    Atributo = table.Column<int>(type: "int", nullable: false),
                    Agilidade = table.Column<int>(type: "int", nullable: false),
                    Defendeu = table.Column<bool>(type: "bit", nullable: false),
                    DanoDadoResultado = table.Column<int>(type: "int", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: true),
                    DanoTotal = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidaLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartidaLog_PartidaJogador_PartidaJogadorId",
                        column: x => x.PartidaJogadorId,
                        principalTable: "PartidaJogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartidaLog_Partida_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partida_PartidaJogador1Id",
                table: "Partida",
                column: "PartidaJogador1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partida_PartidaJogador2Id",
                table: "Partida",
                column: "PartidaJogador2Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partida_PartidaJogadorTurnoId",
                table: "Partida",
                column: "PartidaJogadorTurnoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partida_PartidaJogadorVencedorId",
                table: "Partida",
                column: "PartidaJogadorVencedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartidaJogador_PersonagemId",
                table: "PartidaJogador",
                column: "PersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidaLog_PartidaId",
                table: "PartidaLog",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidaLog_PartidaJogadorId",
                table: "PartidaLog",
                column: "PartidaJogadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartidaLog");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "PartidaJogador");

            migrationBuilder.DropTable(
                name: "Personagem");
        }
    }
}
