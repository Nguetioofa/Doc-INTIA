using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AntiaApp.Data.Entities;
using AntiaApp.Domain.Entities;

namespace AntiaApp.Web.Controllers
{
    public class AssurancesController : Controller
    {
        private readonly AntiaAppDbContext _context;

        public AssurancesController(AntiaAppDbContext context)
        {
            _context = context;
        }

        // GET: Assurances
        public async Task<IActionResult> Index()
        {
            var antiaAppDbContext = _context.Assurances.Include(a => a.Client);
            return View(await antiaAppDbContext.ToListAsync());
        }

        // GET: Assurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assurance = await _context.Assurances
                .Include(a => a.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assurance == null)
            {
                return NotFound();
            }

            return View(assurance);
        }

        // GET: Assurances/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Nom");
            return View();
        }

        // POST: Assurances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Montant,DateDebut,DateFin,Statut,Description,ClientId,DateCreation,DateModification")] Assurance assurance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assurance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Nom", assurance.ClientId);
            return View(assurance);
        }

        // GET: Assurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assurance = await _context.Assurances.FindAsync(id);
            if (assurance == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Nom", assurance.ClientId);
            return View(assurance);
        }

        // POST: Assurances/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Montant,DateDebut,DateFin,Statut,Description,ClientId,DateCreation,DateModification")] Assurance assurance)
        {
            if (id != assurance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssuranceExists(assurance.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Nom", assurance.ClientId);
            return View(assurance);
        }

        // GET: Assurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assurance = await _context.Assurances
                .Include(a => a.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assurance == null)
            {
                return NotFound();
            }

            return View(assurance);
        }

        // POST: Assurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assurance = await _context.Assurances.FindAsync(id);
            if (assurance != null)
            {
                _context.Assurances.Remove(assurance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssuranceExists(int id)
        {
            return _context.Assurances.Any(e => e.Id == id);
        }
    }
}
