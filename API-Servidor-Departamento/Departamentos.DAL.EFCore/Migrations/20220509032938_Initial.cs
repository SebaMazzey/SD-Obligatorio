using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Departamentos.DAL.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Circuitos",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuitos", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Opciones",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "varchar(767)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opciones", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    CI = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    VotoRealizado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.CI);
                });

            migrationBuilder.CreateTable(
                name: "DispositivosHabilitados",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(767)", nullable: false),
                    Numero_Circuito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispositivosHabilitados", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_DispositivosHabilitados_Circuitos_Numero_Circuito",
                        column: x => x.Numero_Circuito,
                        principalTable: "Circuitos",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Votos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Numero_Circuito = table.Column<int>(type: "int", nullable: false),
                    Nombre_Opcion = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votos_Circuitos_Numero_Circuito",
                        column: x => x.Numero_Circuito,
                        principalTable: "Circuitos",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votos_Opciones_Nombre_Opcion",
                        column: x => x.Nombre_Opcion,
                        principalTable: "Opciones",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DispositivosHabilitados_Numero_Circuito",
                table: "DispositivosHabilitados",
                column: "Numero_Circuito");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Nombre_Opcion",
                table: "Votos",
                column: "Nombre_Opcion");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Numero_Circuito",
                table: "Votos",
                column: "Numero_Circuito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispositivosHabilitados");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Votos");

            migrationBuilder.DropTable(
                name: "Circuitos");

            migrationBuilder.DropTable(
                name: "Opciones");
        }
    }
}
