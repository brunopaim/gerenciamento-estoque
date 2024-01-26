namespace gerenciamento_estoque.Models
{
    public class MapaEstoque
    {
        public int MapaEstoqueId { get; set; }
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public int CapacidadeMaxima { get; set; }
        // Relacionamento com ProdutosArmazenados (uma célula pode ter vários produtos)
        public List<ProdutoEstoque>? ProdutoEstoque { get; set; }
    }
}