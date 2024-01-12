using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_estoque.Migrations
{
    public partial class FixRelacionamentosTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosArmazenados_Produtos_ProdutoId",
                table: "ProdutosArmazenados");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "ProdutosArmazenados",
                newName: "ProdutoEntradaId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutosArmazenados_ProdutoId",
                table: "ProdutosArmazenados",
                newName: "IX_ProdutosArmazenados_ProdutoEntradaId");

            migrationBuilder.AddColumn<int>(
                name: "MapaEstoqueId",
                table: "ProdutosEntradas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "EntradaMercadorias",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosEntradas_MapaEstoqueId",
                table: "ProdutosEntradas",
                column: "MapaEstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosArmazenados_ProdutosEntradas_ProdutoEntradaId",
                table: "ProdutosArmazenados",
                column: "ProdutoEntradaId",
                principalTable: "ProdutosEntradas",
                principalColumn: "ProdutoEntradaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosEntradas_MapaEstoque_MapaEstoqueId",
                table: "ProdutosEntradas",
                column: "MapaEstoqueId",
                principalTable: "MapaEstoque",
                principalColumn: "MapaEstoqueId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosArmazenados_ProdutosEntradas_ProdutoEntradaId",
                table: "ProdutosArmazenados");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosEntradas_MapaEstoque_MapaEstoqueId",
                table: "ProdutosEntradas");

            migrationBuilder.DropIndex(
                name: "IX_ProdutosEntradas_MapaEstoqueId",
                table: "ProdutosEntradas");

            migrationBuilder.DropColumn(
                name: "MapaEstoqueId",
                table: "ProdutosEntradas");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "EntradaMercadorias");

            migrationBuilder.RenameColumn(
                name: "ProdutoEntradaId",
                table: "ProdutosArmazenados",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutosArmazenados_ProdutoEntradaId",
                table: "ProdutosArmazenados",
                newName: "IX_ProdutosArmazenados_ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosArmazenados_Produtos_ProdutoId",
                table: "ProdutosArmazenados",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
