using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasFIESC.Migrations
{
    public partial class AddUsuarioNomeToTarefaModelEditandoOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "usuarioNome",
                table: "Tarefa",
                newName: "UsuarioNome");

            migrationBuilder.RenameColumn(
                name: "usuarioNome",
                table: "Observacao",
                newName: "UsuarioNome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioNome",
                table: "Tarefa",
                newName: "usuarioNome");

            migrationBuilder.RenameColumn(
                name: "UsuarioNome",
                table: "Observacao",
                newName: "usuarioNome");
        }
    }
}
