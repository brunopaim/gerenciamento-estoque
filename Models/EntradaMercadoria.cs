namespace gerenciamento_estoque.Models
{
    public class EntradaMercadoria
    {
        public int EntradaMercadoriaId { get; set; }
        public string NumeroEntrada { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime Data { get; set; }
        public decimal TotalVolumeCubico { get; set; }
        public decimal PesoTotal { get; set; }
        public decimal ValorTotal { get; set; }
        // Relacionamento com Produtos (uma entrada pode ter vários produtos)
        public List<ProdutoEntrada>? ProdutosEntrada { get; set; }
    
    }
}