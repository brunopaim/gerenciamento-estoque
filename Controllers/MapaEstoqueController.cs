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
        return await _context.MapaEstoque
            .Include(m => m.ProdutoEntrada)
                .ThenInclude(pe => pe.Produto)
            .ToListAsync();
    }
}
