using Microsoft.AspNetCore.Mvc;
using CadastroApi.Data;
using CadastroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegiaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegiaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var regioes = await _context.Regioes.ToListAsync();
            return Ok(regioes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null) return NotFound();
            return Ok(regiao);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Regiao regiao)
        {
            _context.Regioes.Add(regiao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = regiao.Id }, regiao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Regiao regiao)
        {
            if (id != regiao.Id) return BadRequest();

            _context.Entry(regiao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null) return NotFound();

            _context.Regioes.Remove(regiao);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 🔹 Exemplo de LINQ Query Expression (buscar por UF)
        [HttpGet("buscar/{uf}")]
        public async Task<IActionResult> BuscarPorUf(string uf)
        {
            var regioes = await (from r in _context.Regioes
                                 where r.Uf.ToUpper() == uf.ToUpper()
                                 select r).ToListAsync();

            return Ok(regioes);
        }
    }
}
