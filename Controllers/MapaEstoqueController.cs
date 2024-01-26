using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gerenciamento_estoque.Data;
using gerenciamento_estoque.Models;
using Newtonsoft.Json;

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

        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

         var mapaEstoque = await _context.MapaEstoque
            .Include(m => m.ProdutoEstoque)
                .ThenInclude(pe => pe.ProdutoEntrada)
                    .ThenInclude(p => p.Produto)
            .ToListAsync();

        var json = JsonConvert.SerializeObject(mapaEstoque, settings);
        return Ok(json);    }
}
