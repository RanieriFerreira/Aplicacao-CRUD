using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_Empresa.Migrations
{
    public partial class AddMany2ManyList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosProjetos_ProjetoId",
                table: "FuncionariosProjetos",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosProjetos_Funcionarios_FuncionarioId",
                table: "FuncionariosProjetos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosProjetos_Projetos_ProjetoId",
                table: "FuncionariosProjetos",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosProjetos_Funcionarios_FuncionarioId",
                table: "FuncionariosProjetos");

            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosProjetos_Projetos_ProjetoId",
                table: "FuncionariosProjetos");

            migrationBuilder.DropIndex(
                name: "IX_FuncionariosProjetos_ProjetoId",
                table: "FuncionariosProjetos");
        }
    }
}
