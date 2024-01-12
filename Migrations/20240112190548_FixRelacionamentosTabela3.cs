using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_estoque.Migrations
{
    public partial class FixRelacionamentosTabela3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosArmazenados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutosArmazenados",
                columns: table => new
                {
                    ProdutoArmazenadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MapaEstoqueId = table.Column<int>(type: "int", nullable: false),
                    ProdutoEntradaId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeArmazenada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosArmazenados", x => x.ProdutoArmazenadoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosArmazenados_MapaEstoqueId",
                table: "ProdutosArmazenados",
                column: "MapaEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosArmazenados_ProdutoEntradaId",
                table: "ProdutosArmazenados",
                column: "ProdutoEntradaId");
        }
    }
}
