using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APICadastroPF.Data;
using APICadastroPF.Models;

namespace APICadastroPF.Controllers
{
    public class PessoaFisicasController : Controller
    {
        private readonly DataContext _context;

        public PessoaFisicasController(DataContext context)
        {
            _context = context;
        }

        // GET: PessoaFisicas
        public async Task<IActionResult> Index()
        {
              return _context.PessoaFisica != null ? 
                          View(await _context.PessoaFisica.ToListAsync()) :
                          Problem("Entity set 'DataContext.PessoaFisica'  is null.");
        }

        // GET: PessoaFisicas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PessoaFisica == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoaFisica
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaFisicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,Nome,Sobrenome,Telefone,Endereco")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaFisica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PessoaFisica == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }
            return View(pessoaFisica);
        }

        // POST: PessoaFisicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cpf,Nome,Sobrenome,Telefone,Endereco")] PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.Cpf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaFisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaFisicaExists(pessoaFisica.Cpf))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PessoaFisica == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoaFisica
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // POST: PessoaFisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PessoaFisica == null)
            {
                return Problem("Entity set 'DataContext.PessoaFisica'  is null.");
            }
            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);
            if (pessoaFisica != null)
            {
                _context.PessoaFisica.Remove(pessoaFisica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaFisicaExists(string id)
        {
          return (_context.PessoaFisica?.Any(e => e.Cpf == id)).GetValueOrDefault();
        }
    }
}
