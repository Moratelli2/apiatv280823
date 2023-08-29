using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIatv280823.Data;
using APIatv280823.Models;

namespace APIatv280823.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquacoesController : ControllerBase
    {
        private readonly APIatv280823Context _context;

        public EquacoesController(APIatv280823Context context)
        {
            _context = context;
        }

        // GET: api/Equacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equacao>>> GetEquacao()
        {
          if (_context.Equacao == null)
          {
              return NotFound();
          }
            return await _context.Equacao.ToListAsync();
        }

        // GET: api/Equacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equacao>> GetEquacao(int id)
        {
          if (_context.Equacao == null)
          {
              return NotFound();
          }
            var equacao = await _context.Equacao.FindAsync(id);

            if (equacao == null)
            {
                return NotFound();
            }

            return equacao;
        }

        // PUT: api/Equacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquacao(int id, Equacao equacao)
        {
            if (id != equacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(equacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquacaoExists(id))
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

        // POST: api/Equacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equacao>> PostEquacao(Equacao equacao)
        {
          if (_context.Equacao == null)
          {
              return Problem("Entity set 'APIatv280823Context.Equacao'  is null.");
          }
            equacao.Delta = equacao.B * equacao.B - 4 * equacao.A * equacao.C;
            equacao.X1 = (-equacao.B + ((float)Math.Sqrt(equacao.Delta))) / (2f * equacao.A);
            equacao.X2 = (-equacao.B - ((float)Math.Sqrt(equacao.Delta))) / (2f * equacao.A);

            _context.Equacao.Add(equacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquacao", new { id = equacao.Id }, equacao);
        }

        // DELETE: api/Equacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquacao(int id)
        {
            if (_context.Equacao == null)
            {
                return NotFound();
            }
            var equacao = await _context.Equacao.FindAsync(id);
            if (equacao == null)
            {
                return NotFound();
            }

            _context.Equacao.Remove(equacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquacaoExists(int id)
        {
            return (_context.Equacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
