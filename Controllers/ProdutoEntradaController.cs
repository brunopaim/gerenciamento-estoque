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

    // GET: api/ProdutoEntrada
    [HttpGet]
    public async Task<IActionResult> GetProdutosEntrada()
    {
        var produtosEntrada = await _context.ProdutosEntradas.ToListAsync();
        return Ok(produtosEntrada);
    }

    // GET: api/ProdutoEntrada/5
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

    // POST: api/ProdutoEntrada
    [HttpPost]
    public async Task<IActionResult> PostProdutoEntrada(ProdutoEntrada produtoEntrada)
    {
        _context.ProdutosEntradas.Add(produtoEntrada);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProdutoEntrada), new { id = produtoEntrada.ProdutoEntradaId }, produtoEntrada);
    }

    // PUT: api/ProdutoEntrada/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProdutoEntrada(int id, ProdutoEntrada produtoEntrada)
    {
        if (id != produtoEntrada.ProdutoEntradaId)
        {
            return BadRequest();
        }

        _context.Entry(produtoEntrada).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProdutoEntradaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/ProdutoEntrada/5
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