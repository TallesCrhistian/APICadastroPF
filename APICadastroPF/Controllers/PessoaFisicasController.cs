using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICadastroPF.Data;
using APICadastroPF.Models;

namespace APICadastroPF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaFisicasController : ControllerBase
    {
        private readonly DataContext _context;

        public PessoaFisicasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PessoaFisicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaFisica>>> GetPessoaFisica()
        {
          if (_context.PessoaFisica == null)
          {
              return NotFound();
          }
            return await _context.PessoaFisica.ToListAsync();
        }

        // GET: api/PessoaFisicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaFisica>> GetPessoaFisica(string id)
        {
          if (_context.PessoaFisica == null)
          {
              return NotFound();
          }
            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return pessoaFisica;
        }

        // PUT: api/PessoaFisicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoaFisica(string id, PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(pessoaFisica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaFisicaExists(id))
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

        // POST: api/PessoaFisicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PessoaFisica>> PostPessoaFisica(PessoaFisica pessoaFisica)
        {
          if (_context.PessoaFisica == null)
          {
              return Problem("Entity set 'DataContext.PessoaFisica'  is null.");
          }
            _context.PessoaFisica.Add(pessoaFisica);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PessoaFisicaExists(pessoaFisica.Cpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPessoaFisica", new { id = pessoaFisica.Cpf }, pessoaFisica);
        }

        // DELETE: api/PessoaFisicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaFisica(string id)
        {
            if (_context.PessoaFisica == null)
            {
                return NotFound();
            }
            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            _context.PessoaFisica.Remove(pessoaFisica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaFisicaExists(string id)
        {
            return (_context.PessoaFisica?.Any(e => e.Cpf == id)).GetValueOrDefault();
        }
    }
}
