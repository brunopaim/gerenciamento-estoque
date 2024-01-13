namespace gerenciamento_estoque.Models
{
    public class ProdutoEntrada
    {
        public int ProdutoEntradaId { get; set; }
        public int ProdutoId { get; set; }
        public int EntradaMercadoriaId { get; set; }
        public string NumeroEntrada { get; set; }
        public int MapaEstoqueId { get; set; }
        public int Quantidade { get; set; }
        public decimal VolumeCubico { get; set; }
        public decimal Peso { get; set; }
        public decimal ValorUnitario { get; set; }
        // Relacionamentos de navegação
        public Produto? Produto { get; set; }
    }
}