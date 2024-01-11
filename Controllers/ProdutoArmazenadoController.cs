using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gerenciamento_estoque.Data;
using gerenciamento_estoque.Models;

namespace gerenciamento_estoque.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProdutoArmazenadoController : ControllerBase
{
    private readonly ProdutoContext _context;

    public ProdutoArmazenadoController(ProdutoContext context)
    {
        _context = context;
    }

    [HttpGet("zona/{mapaEstoqueId}")]
    public async Task<ActionResult<IEnumerable<ProdutoArmazenado>>> GetProdutosArmazenadosByZona(int mapaEstoqueId)
    {
        var produtosArmazenados = await _context.ProdutosArmazenados
            .Where(pa => pa.MapaEstoqueId == mapaEstoqueId)
            .Include(pa => pa.Produto)
            .ToListAsync();

        if (produtosArmazenados == null || produtosArmazenados.Count == 0)
        {
            return NotFound();
        }

        return produtosArmazenados;
    }

    [HttpGet("{produtoArmazenadoId}")]
    public async Task<ActionResult<ProdutoArmazenado>> GetProdutoArmazenado(int produtoArmazenadoId)
    {
        var produtoArmazenado = await _context.ProdutosArmazenados.FindAsync(produtoArmazenadoId);

        if (produtoArmazenado == null)
        {
            return NotFound();
        }

        return produtoArmazenado;
    }

    // Adicione outras operações conforme necessário

    private bool ProdutoArmazenadoExists(int id)
    {
        return _context.ProdutosArmazenados.Any(e => e.ProdutoArmazenadoId == id);
    }
}