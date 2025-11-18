using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AntiaApp.Data.Entities;
using AntiaApp.Domain.Entities;
using AntiaApp.Services.DBServices;

namespace AntiaApp.Web.Controllers
{
    public class SitesController : Controller
    {
        private readonly ISiteService _service;
        private readonly LogManager _log;

        public SitesController(ISiteService siteService, LogManager log)
        {
            _service = siteService;
            _log = log;
        }

        // GET: Sites
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _service.GetById(id.Value);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Ville,Adresse,Telephone")] Site site)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(site);
                _log.Info("New site", typeof(SitesController).Name, nameof(Create), site);
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _service.GetById(id.Value);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Ville,Adresse,Telephone")] Site site)
        {
            if (id != site.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(site);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    _log.Critical(ex.Message, typeof(SitesController).Name, nameof(Edit), ex.StackTrace, site.Id);
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _service.GetById(id.Value);

            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _service.GetById(id);
            if (site != null)
            {
                 await _service.Delete(site);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
