namespace gerenciamento_estoque.Models
{
    public class ProdutoArmazenado
    {
        public int ProdutoArmazenadoId { get; set; }
        public int ProdutoId { get; set; }
        public int MapaEstoqueId { get; set; }
        public int QuantidadeArmazenada { get; set; }
        // Relacionamentos de navegação
        public Produto Produto { get; set; }
        public MapaEstoque MapaEstoque { get; set; }
    }
}