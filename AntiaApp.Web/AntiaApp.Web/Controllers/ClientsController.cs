using AntiaApp.Data.Entities;
using AntiaApp.Domain.Entities;
using AntiaApp.Domain.ViewModels;
using AntiaApp.Services.DBServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiaApp.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _service;
        private readonly ISiteService _siteService;

        public ClientsController(IClientService clientService, ISiteService siteService)
        {
            _service = clientService;
            _siteService = siteService;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _service.GetById(id.Value);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public async Task<IActionResult> Create()
        {
            ViewData["SiteId"] = new SelectList(await _siteService.GetAll(), "Id", "Nom");
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Telephone,Email,Adresse,SiteId")] AddClientVM vm)
        {
            if (ModelState.IsValid)
            {
                var client = new Client
                {
                    Adresse = vm.Adresse,
                    Nom = vm.Nom,
                    Prenom = vm.Prenom,
                    Telephone = vm.Telephone,
                    SiteId = vm.SiteId,
                    Email = vm.Email,
                };

                await _service.Add(client);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiteId"] = new SelectList(await _siteService.GetAll(), "Id", "Nom", vm.SiteId);
            return View(vm);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = await _service.GetById(id.Value);
            var client = new UpdateClientVM
            {
                Adresse = vm.Adresse,
                Nom = vm.Nom,
                Prenom = vm.Prenom,
                Telephone = vm.Telephone,
                SiteId = vm.SiteId,
                Email = vm.Email,
                Id = vm.Id,
                DateCreation = vm.DateCreation
            };

            if (client == null)
            {
                return NotFound();
            }
            ViewData["SiteId"] = new SelectList(await _siteService.GetAll(), "Id", "Nom", client.SiteId);
            return View(client);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Telephone,Email,Adresse,SiteId")] UpdateClientVM vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var client = new Client
                    {
                        Adresse = vm.Adresse,
                        Nom = vm.Nom,
                        Prenom = vm.Prenom,
                        Telephone = vm.Telephone,
                        SiteId = vm.SiteId,
                        Email = vm.Email,
                        Id = vm.Id, 
                        DateCreation = vm.DateCreation
                    };

                    await _service.Update(client);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.Exists(id))
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
            ViewData["SiteId"] = new SelectList(await _siteService.GetAll(), "Id", "Nom", vm.SiteId);
            return View(vm);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _service.GetById(id.Value);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _service.GetById(id);
            if (client != null)
            {
                await _service.Delete(client);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
