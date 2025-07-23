using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroApi.Data;
using CadastroApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegiaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegiaoController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/regiao → Listar todas as regiões
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Regiao>>> Get()
        {
            var regioes = await _context.Regioes
                .OrderBy(r => r.Uf)
                .ThenBy(r => r.Nome)
                .ToListAsync();

            return Ok(regioes);
        }

        // ✅ GET: api/regiao/ativas → Listar apenas regiões ativas
        [HttpGet("ativas")]
        public async Task<ActionResult<IEnumerable<Regiao>>> GetAtivas()
        {
            var ativas = await _context.Regioes
                .Where(r => r.Situacao == "Ativo")
                .OrderBy(r => r.Nome)
                .ToListAsync();

            return Ok(ativas);
        }

        // ✅ GET: api/regiao/por-uf/São%20Paulo → Filtrar por UF
        [HttpGet("por-uf/{uf}")]
        public async Task<ActionResult<IEnumerable<Regiao>>> GetPorUf(string uf)
        {
            var regioes = await _context.Regioes
                .Where(r => r.Uf == uf)
                .OrderBy(r => r.Nome)
                .ToListAsync();

            if (!regioes.Any())
                return NotFound($"Nenhuma região encontrada para a UF: {uf}");

            return Ok(regioes);
        }

        // ✅ GET: api/regiao/buscar?termo=Campinas&page=1&pageSize=5 → Busca e paginação
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Regiao>>> Buscar(
            string? termo = null,
            int page = 1,
            int pageSize = 10)
        {
            var query = _context.Regioes.AsQueryable();

            if (!string.IsNullOrEmpty(termo))
                query = query.Where(r => r.Nome.Contains(termo) || r.Uf.Contains(termo));

            var resultados = await query
                .OrderBy(r => r.Nome)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(resultados);
        }

        // ✅ GET: api/regiao/5 → Obter uma região específica
        [HttpGet("{id}")]
        public async Task<ActionResult<Regiao>> GetById(int id)
        {
            var regiao = await _context.Regioes.FindAsync(id);

            if (regiao == null)
                return NotFound($"Região com ID {id} não encontrada.");

            return Ok(regiao);
        }

        // ✅ POST: api/regiao → Criar uma nova região
        [HttpPost]
        public async Task<ActionResult<Regiao>> Post(Regiao regiao)
        {
            _context.Regioes.Add(regiao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = regiao.Id }, regiao);
        }

        // ✅ PUT: api/regiao/5 → Atualizar uma região
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Regiao regiao)
        {
            if (id != regiao.Id)
                return BadRequest("ID da URL e do objeto não coincidem.");

            _context.Entry(regiao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Regioes.Any(r => r.Id == id))
                    return NotFound($"Região com ID {id} não encontrada.");

                throw;
            }

            return NoContent();
        }

        // ✅ DELETE: api/regiao/5 → Excluir uma região
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var regiao = await _context.Regioes.FindAsync(id);

            if (regiao == null)
                return NotFound($"Região com ID {id} não encontrada.");

            _context.Regioes.Remove(regiao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
