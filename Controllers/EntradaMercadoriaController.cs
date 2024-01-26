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
        return await _context.EntradaMercadorias
            .Include(e => e.ProdutosEntrada).ThenInclude(pe => pe.Produto)
            .ToListAsync();
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
        try
        {
            // Adicione a entrada de mercadoria ao contexto, mas ainda não a salve
            _context.EntradaMercadorias.Add(entradaMercadoria);

            // Associe a entrada de mercadoria aos produtos e adicione-os ao contexto
            foreach (var produtoEntrada in entradaMercadoria.ProdutosEntrada)
            {
                _context.ProdutosEntradas.Add(produtoEntrada);

                foreach (var produtoEstoque in produtoEntrada.ProdutoEstoque)
                {
                    _context.ProdutosEstoque.Add(produtoEstoque);
                }
            }

            // Agora, salve as alterações no banco de dados
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntradaMercadoria", new { id = entradaMercadoria.EntradaMercadoriaId }, entradaMercadoria);
        }
        catch (Exception ex)
        {
            // Trate qualquer exceção que possa ocorrer durante o processo
            return BadRequest($"Erro ao processar a solicitação: {ex.Message}");
        }
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

}
