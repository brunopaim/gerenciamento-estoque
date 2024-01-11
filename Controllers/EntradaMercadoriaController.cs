using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gerenciamento_estoque.Data;
using gerenciamento_estoque.Models;

namespace gerenciamento_estoque.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntradaMercadoriaController : ControllerBase
{
    private readonly ProdutoContext _context;

    public EntradaMercadoriaController(ProdutoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EntradaMercadoria>>> GetEntradasMercadoria()
    {
        return await _context.EntradaMercadorias.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EntradaMercadoria>> GetEntradaMercadoria(int id)
    {
        var entradaMercadoria = await _context.EntradaMercadorias.FindAsync(id);

        if (entradaMercadoria == null)
        {
            return NotFound();
        }

        return entradaMercadoria;
    }

    [HttpPost]
    public async Task<ActionResult<EntradaMercadoria>> PostEntradaMercadoria(EntradaMercadoria entradaMercadoria)
    {
        // Lógica para gerar um número de entrada (pode ser um timestamp neste exemplo)
        entradaMercadoria.NumeroEntrada = GenerateEntryNumber();

        // Configure a entrada de mercadoria e salve no banco de dados
        _context.EntradaMercadorias.Add(entradaMercadoria);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEntradaMercadoria", new { id = entradaMercadoria.EntradaMercadoriaId }, entradaMercadoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEntradaMercadoria(int id, EntradaMercadoria entradaMercadoria)
    {
        if (id != entradaMercadoria.EntradaMercadoriaId)
        {
            return BadRequest();
        }

        _context.Entry(entradaMercadoria).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EntradaMercadoriaExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEntradaMercadoria(int id)
    {
        var entradaMercadoria = await _context.EntradaMercadorias.FindAsync(id);
        if (entradaMercadoria == null)
        {
            return NotFound();
        }

        _context.EntradaMercadorias.Remove(entradaMercadoria);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EntradaMercadoriaExists(int id)
    {
        return _context.EntradaMercadorias.Any(e => e.EntradaMercadoriaId == id);
    }

    private string GenerateEntryNumber()
    {
        // Gere um número de entrada com base no timestamp atual
        return DateTime.Now.ToString("yyyyMMddHHmmssfff");
    }
}
