using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjBiblioteca.Infrastructure.Data.Migrations
{
    public partial class CreateTableEmprestimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Livro",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Autor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    EmprestimoID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    DataDevolucao = table.Column<DateTime>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.EmprestimoID);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    LivroID = table.Column<int>(nullable: false),
                    AutorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => new { x.LivroID, x.AutorID });
                    table.ForeignKey(
                        name: "FK_LivroAutor_Autor_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autor",
                        principalColumn: "AutorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Livro_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livro",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroEmprestimo",
                columns: table => new
                {
                    EmprestimoID = table.Column<int>(nullable: false),
                    LivroID = table.Column<int>(nullable: false),
                    LivroEmprestimoEmprestimoID = table.Column<int>(nullable: true),
                    LivroEmprestimoLivroID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroEmprestimo", x => new { x.LivroID, x.EmprestimoID });
                    table.ForeignKey(
                        name: "FK_LivroEmprestimo_Emprestimo_EmprestimoID",
                        column: x => x.EmprestimoID,
                        principalTable: "Emprestimo",
                        principalColumn: "EmprestimoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroEmprestimo_Livro_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livro",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroEmprestimo_LivroEmprestimo_LivroEmprestimoLivroID_Livr~",
                        columns: x => new { x.LivroEmprestimoLivroID, x.LivroEmprestimoEmprestimoID },
                        principalTable: "LivroEmprestimo",
                        principalColumns: new[] { "LivroID", "EmprestimoID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_UsuarioID",
                table: "Emprestimo",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_AutorID",
                table: "LivroAutor",
                column: "AutorID");

            migrationBuilder.CreateIndex(
                name: "IX_LivroEmprestimo_EmprestimoID",
                table: "LivroEmprestimo",
                column: "EmprestimoID");

            migrationBuilder.CreateIndex(
                name: "IX_LivroEmprestimo_LivroEmprestimoLivroID_LivroEmprestimoEmpre~",
                table: "LivroEmprestimo",
                columns: new[] { "LivroEmprestimoLivroID", "LivroEmprestimoEmprestimoID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAutor");

            migrationBuilder.DropTable(
                name: "LivroEmprestimo");

            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuario",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Livro",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Autor",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
