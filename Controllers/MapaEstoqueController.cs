using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gerenciamento_estoque.Data;
using gerenciamento_estoque.Models;

namespace gerenciamento_estoque.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MapaEstoqueController : ControllerBase
{
    private readonly ProdutoContext _context;

    public MapaEstoqueController(ProdutoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MapaEstoque>>> GetMapaEstoque()
    {
        return await _context.MapaEstoque.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MapaEstoque>> GetMapaEstoque(int id)
    {
        var mapaEstoque = await _context.MapaEstoque.FindAsync(id);

        if (mapaEstoque == null)
        {
            return NotFound();
        }

        return mapaEstoque;
    }

   /*[HttpPost]
    public async Task<ActionResult<MapaEstoque>> PostMapaEstoque(MapaEstoque mapaEstoque)
    {
        // Adiciona a lógica para organizar automaticamente os produtos em espaços disponíveis
        OrganizeProductsInStock(mapaEstoque);

        // Adiciona o mapa de estoque e salva no banco de dados
        _context.MapaEstoque.Add(mapaEstoque);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMapaEstoque", new { id = mapaEstoque.MapaEstoqueId }, mapaEstoque);
    }

    private void OrganizeProductsInStock(MapaEstoque mapaEstoque)
    {
        var produtos = _context.Produtos.ToList();

        foreach (var produto in produtos)
        {
            var celulasDisponiveis = GetAvailableSpaces(mapaEstoque.MapaEstoqueId);

            foreach (var celula in celulasDisponiveis)
            {
                // Verifique se a capacidade máxima da célula permite adicionar o produto
                if (celula.CapacidadeMaxima > 0)
                {
                    celula.ProdutosArmazenados ??= new List<ProdutoArmazenado>();

                    celula.ProdutosArmazenados.Add(new ProdutoArmazenado
                    {
                        Produto = produto,
                        QuantidadeArmazenada = 1,
                    });

                    // Reduza a capacidade máxima da célula
                    celula.CapacidadeMaxima--;

                    // Você pode precisar ajustar a lógica de acordo com sua estrutura exata
                }
            }
        }
    }


    public IEnumerable<MapaEstoque> GetAvailableSpaces(int mapaEstoqueId)
    {
        var mapaEstoque = _context.MapaEstoque
            .Include(m => m.ProdutosArmazenados)
            .FirstOrDefault(m => m.MapaEstoqueId == mapaEstoqueId);

        if (mapaEstoque == null)
        {
            return Enumerable.Empty<MapaEstoque>();
        }

        // Agora, podemos verificar quais células têm ProdutosArmazenados vazios
        var celulasVazias = mapaEstoque.ProdutosArmazenados
            .Where(pa => pa == null || pa.Produto == null)
            .Select(pa => new MapaEstoque
            {
                // Preencha as propriedades necessárias do MapaEstoque aqui
                // Você pode querer incluir mais informações sobre a célula, se necessário
            });

        return celulasVazias;
    }*/


}
