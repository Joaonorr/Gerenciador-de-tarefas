using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasFIESC.Migrations
{
    public partial class CampoDeNomeTarefaObservacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Tarefa",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Observacao",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Observacao");
        }
    }
}
