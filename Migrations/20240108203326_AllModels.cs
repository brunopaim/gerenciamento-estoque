using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_estoque.Migrations
{
    public partial class AllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Peso",
                table: "Produtos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorUnitario",
                table: "Produtos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VolumeCubico",
                table: "Produtos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EntradaMercadorias",
                columns: table => new
                {
                    EntradaMercadoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroEntrada = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalVolumeCubico = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PesoTotal = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaMercadorias", x => x.EntradaMercadoriaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MapaEstoque",
                columns: table => new
                {
                    MapaEstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Linha = table.Column<int>(type: "int", nullable: false),
                    Coluna = table.Column<int>(type: "int", nullable: false),
                    CapacidadeMaxima = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapaEstoque", x => x.MapaEstoqueId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutosEntradas",
                columns: table => new
                {
                    ProdutoEntradaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    EntradaMercadoriaId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    VolumeCubico = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosEntradas", x => x.ProdutoEntradaId);
                    table.ForeignKey(
                        name: "FK_ProdutosEntradas_EntradaMercadorias_EntradaMercadoriaId",
                        column: x => x.EntradaMercadoriaId,
                        principalTable: "EntradaMercadorias",
                        principalColumn: "EntradaMercadoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosEntradas_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutosArmazenados",
                columns: table => new
                {
                    ProdutoArmazenadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    MapaEstoqueId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeArmazenada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosArmazenados", x => x.ProdutoArmazenadoId);
                    table.ForeignKey(
                        name: "FK_ProdutosArmazenados_MapaEstoque_MapaEstoqueId",
                        column: x => x.MapaEstoqueId,
                        principalTable: "MapaEstoque",
                        principalColumn: "MapaEstoqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosArmazenados_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosArmazenados_MapaEstoqueId",
                table: "ProdutosArmazenados",
                column: "MapaEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosArmazenados_ProdutoId",
                table: "ProdutosArmazenados",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosEntradas_EntradaMercadoriaId",
                table: "ProdutosEntradas",
                column: "EntradaMercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosEntradas_ProdutoId",
                table: "ProdutosEntradas",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ProdutosArmazenados");

            migrationBuilder.DropTable(
                name: "ProdutosEntradas");

            migrationBuilder.DropTable(
                name: "MapaEstoque");

            migrationBuilder.DropTable(
                name: "EntradaMercadorias");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ValorUnitario",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "VolumeCubico",
                table: "Produtos");
        }
    }
}
