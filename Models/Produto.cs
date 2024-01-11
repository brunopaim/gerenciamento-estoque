namespace gerenciamento_estoque.Models;
public class Produto
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; }
    public decimal Peso { get; set; }
    public decimal VolumeCubico { get; set; }
    public decimal ValorUnitario { get; set; }
}