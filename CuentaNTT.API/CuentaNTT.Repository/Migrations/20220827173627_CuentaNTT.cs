using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuentaNTT.Repository.Migrations
{
    public partial class CuentaNTT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personaNTT",
                columns: table => new
                {
                    per_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    per_identificacion = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    per_nombre = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    per_genero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    per_edad = table.Column<int>(type: "int", nullable: false),
                    per_direccion = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    per_telefono = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true),
                    per_clientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personaNTT", x => x.per_id);
                });

            migrationBuilder.CreateTable(
                name: "clienteNTT",
                columns: table => new
                {
                    cli_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cli_usuario = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    cli_contrasena = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    cli_salt = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    cli_estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    cli_personaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clienteNTT", x => x.cli_id);
                    table.ForeignKey(
                        name: "FK_clienteNTT_personaNTT_cli_personaId",
                        column: x => x.cli_personaId,
                        principalTable: "personaNTT",
                        principalColumn: "per_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cuentaNTT",
                columns: table => new
                {
                    cue_numero_cuenta = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    cue_tipo_cuenta = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    cue_saldo_inicial = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    cue_estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    cue_clienteId = table.Column<int>(type: "int", nullable: false),
                    cue_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuentaNTT", x => x.cue_numero_cuenta);
                    table.ForeignKey(
                        name: "FK_cuentaNTT_clienteNTT_cue_clienteId",
                        column: x => x.cue_clienteId,
                        principalTable: "clienteNTT",
                        principalColumn: "cli_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movimientoNTT",
                columns: table => new
                {
                    mov_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mov_usuario = table.Column<DateTime>(type: "datetime", nullable: false),
                    mov_tipo_movimiento = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    mov_valor = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    mov_saldo = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    mov_cuentaId = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoNTT", x => x.mov_id);
                    table.ForeignKey(
                        name: "FK_movimientoNTT_cuentaNTT_mov_cuentaId",
                        column: x => x.mov_cuentaId,
                        principalTable: "cuentaNTT",
                        principalColumn: "cue_numero_cuenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clienteNTT_cli_personaId",
                table: "clienteNTT",
                column: "cli_personaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cuentaNTT_cue_clienteId",
                table: "cuentaNTT",
                column: "cue_clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoNTT_mov_cuentaId",
                table: "movimientoNTT",
                column: "mov_cuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimientoNTT");

            migrationBuilder.DropTable(
                name: "cuentaNTT");

            migrationBuilder.DropTable(
                name: "clienteNTT");

            migrationBuilder.DropTable(
                name: "personaNTT");
        }
    }
}
