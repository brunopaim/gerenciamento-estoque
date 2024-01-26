using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_estoque.Migrations
{
    public partial class FixFinalMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EntradaMercadorias",
                columns: table => new
                {
                    EntradaMercadoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroEntrada = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeUsuario = table.Column<string>(type: "longtext", nullable: false)
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
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Peso = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    VolumeCubico = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutosEntradas",
                columns: table => new
                {
                    ProdutoEntradaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    NumeroEntrada = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutosEstoque",
                columns: table => new
                {
                    ProdutoEstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdutoEntradaId = table.Column<int>(type: "int", nullable: false),
                    MapaEstoqueId = table.Column<int>(type: "int", nullable: false),
                    VolumeArmazenado = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosEstoque", x => x.ProdutoEstoqueId);
                    table.ForeignKey(
                        name: "FK_ProdutosEstoque_MapaEstoque_MapaEstoqueId",
                        column: x => x.MapaEstoqueId,
                        principalTable: "MapaEstoque",
                        principalColumn: "MapaEstoqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosEstoque_ProdutosEntradas_ProdutoEntradaId",
                        column: x => x.ProdutoEntradaId,
                        principalTable: "ProdutosEntradas",
                        principalColumn: "ProdutoEntradaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosEntradas_EntradaMercadoriaId",
                table: "ProdutosEntradas",
                column: "EntradaMercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosEntradas_ProdutoId",
                table: "ProdutosEntradas",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosEstoque_MapaEstoqueId",
                table: "ProdutosEstoque",
                column: "MapaEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosEstoque_ProdutoEntradaId",
                table: "ProdutosEstoque",
                column: "ProdutoEntradaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosEstoque");

            migrationBuilder.DropTable(
                name: "MapaEstoque");

            migrationBuilder.DropTable(
                name: "ProdutosEntradas");

            migrationBuilder.DropTable(
                name: "EntradaMercadorias");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
