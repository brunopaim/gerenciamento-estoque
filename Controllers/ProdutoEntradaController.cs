using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gerenciamento_estoque.Data;
using gerenciamento_estoque.Models;

namespace gerenciamento_estoque.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoEntradaController : ControllerBase
{
    private readonly ProdutoContext _context;

    public ProdutoEntradaController(ProdutoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProdutosEntrada()
    {
        var produtosEntrada = await _context.ProdutosEntradas
            .Include(pe => pe.Produto)
            .ToListAsync();
        return Ok(produtosEntrada);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdutoEntrada(int id)
    {
        var produtoEntrada = await _context.ProdutosEntradas.FindAsync(id);

        if (produtoEntrada == null)
        {
            return NotFound();
        }

        return Ok(produtoEntrada);
    }

    [HttpPost]
    public async Task<IActionResult> PostProdutoEntrada(ProdutoEntrada produtoEntrada)
    {
        _context.ProdutosEntradas.Add(produtoEntrada);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProdutoEntrada), new { id = produtoEntrada.ProdutoEntradaId }, produtoEntrada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProdutoEntrada(int id)
    {
        var produtoEntrada = await _context.ProdutosEntradas.FindAsync(id);
        if (produtoEntrada == null)
        {
            return NotFound();
        }

        _context.ProdutosEntradas.Remove(produtoEntrada);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProdutoEntradaExists(int id)
    {
        return _context.ProdutosEntradas.Any(e => e.ProdutoEntradaId == id);
    }
}