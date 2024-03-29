using gerenciamento_estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_estoque.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos {get; set;}
        public DbSet<EntradaMercadoria> EntradaMercadorias {get; set;}
        public DbSet<ProdutoEntrada> ProdutosEntradas {get; set;}
        public DbSet<ProdutoEstoque> ProdutosEstoque {get; set;}
        public DbSet<MapaEstoque> MapaEstoque {get; set;}
    }
}