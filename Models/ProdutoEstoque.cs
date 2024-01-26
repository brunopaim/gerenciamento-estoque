namespace gerenciamento_estoque.Models
{
    public class ProdutoEstoque
    {
        public int ProdutoEstoqueId { get; set; }
        public int ProdutoEntradaId { get; set; }
        public int MapaEstoqueId { get; set; }
        public float VolumeArmazenado { get; set; }
        public ProdutoEntrada? ProdutoEntrada { get; set; }
    }
}